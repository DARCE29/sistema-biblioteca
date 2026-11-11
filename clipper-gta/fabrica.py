#!/usr/bin/env python3
"""
FÁBRICA DE CONTENIDO GTA 6 — un comando por tarea.

  1) Clips de un stream (chat → momentos → clips con gancho IA → cola de publicación):
       python fabrica.py vod https://www.twitch.tv/videos/123456 --credit @streamer
     (opcional: --facecam 0,0,0.25,0.3  --top 12  --sfx whoosh.mp3)

  2) Compilación >60 s (monetiza en TikTok y sirve de video largo) con intro de voz IA:
       python fabrica.py compilacion cola/2026-11-19_streamer --titulo "LOS 5 MOMENTOS MÁS LOCOS DE GTA 6"

  3) Guía con voz IA (YouTube largo + Short):
       python fabrica.py guia "Cómo ganar dinero rápido en GTA 6" --notas notas.txt --broll clips/

Todo sale en cola/<fecha>_<nombre>/ con su .txt de descripción y hashtags, listo para programar.
"""
import argparse
import csv
import datetime
import re
import shutil
import subprocess
import sys
import tempfile
from pathlib import Path

HERE = Path(__file__).resolve().parent
sys.path.insert(0, str(HERE))

import clipper  # noqa: E402
import ia  # noqa: E402
import voz  # noqa: E402


def cola_dir(nombre: str) -> Path:
    d = HERE / "cola" / f"{datetime.date.today()}_{re.sub(r'[^\w-]+', '_', nombre)}"
    d.mkdir(parents=True, exist_ok=True)
    return d


# ---------------- 1. VOD → clips ----------------
def cmd_vod(a):
    m = re.search(r"videos/(\d+)", a.url) or re.search(r"^(\d+)$", a.url)
    streamer = a.credit.lstrip("@") if a.credit else "stream"
    out = cola_dir(streamer)
    chat = Path(a.chat) if a.chat else out / "chat.json"

    if not chat.exists():
        exe = shutil.which("TwitchDownloaderCLI") or shutil.which("TwitchDownloaderCLI.exe")
        if not (exe and m):
            sys.exit("Necesito el chat: instala TwitchDownloaderCLI o pasa --chat chat.json "
                     "(o usa clipper.py --batch con un CSV hecho a mano).")
        print("» descargando chat del VOD...")
        subprocess.run([exe, "chatdownload", "--id", m.group(1), "-o", str(chat)], check=True)

    csv_path = out / "momentos.csv"
    print("» buscando momentos en el chat...")
    subprocess.run([sys.executable, str(HERE / "momentos.py"), str(chat), "--url", a.url,
                    "--credit", a.credit or "", "--top", str(a.top), "-o", str(csv_path)],
                   check=True)
    if a.facecam or a.mode:
        rows = list(csv.DictReader(open(csv_path, encoding="utf-8")))
        for r in rows:
            r["facecam"] = r.get("facecam") or (a.facecam or "")
            r["mode"] = r.get("mode") or (a.mode or "")
        with open(csv_path, "w", newline="", encoding="utf-8") as f:
            w = csv.DictWriter(f, fieldnames=list(rows[0]) if rows else ["url"])
            w.writeheader()
            w.writerows(rows)

    print("» editando clips (ganchos con IA si hay ANTHROPIC_API_KEY)...")
    clipper.batch(csv_path, out, lang=a.lang, subs=True, cut=True, fx=True,
                  sfx=a.sfx, ia=not a.no_ia)
    print(f"\n✔ Cola lista en {out}/  → revisa, borra los flojos y programa 3-5 al día.")
    print(f"  Siguiente: python fabrica.py compilacion \"{out}\"")


# ---------------- 2. Compilación ----------------
def cmd_compilacion(a):
    src = Path(a.carpeta)
    clips = sorted(p for p in src.glob("*.mp4") if not p.name.startswith("compilacion"))[: a.max]
    if len(clips) < 2:
        sys.exit("Necesito al menos 2 clips en la carpeta.")
    titulo = a.titulo
    if not titulo:
        textos = " | ".join(p.with_suffix(".txt").read_text("utf-8")[:300]
                            for p in clips if p.with_suffix(".txt").exists())
        r = ia.gancho_clip(f"Compilación de {len(clips)} clips: {textos}", a.credit or "")
        titulo = r["titulo_gancho"] if r else f"TOP {len(clips)} MOMENTOS DE GTA 6"
    out = src / "compilacion.mp4"
    with tempfile.TemporaryDirectory() as d:
        wd = Path(d)
        intro_txt = (a.intro or f"{titulo.capitalize()}. Quédate hasta el final, "
                     f"el número uno es una locura.")
        intro_a = voz.hablar(intro_txt, wd / "intro.mp3")
        di = clipper.duration(intro_a)
        # intro: primer frame del último clip (el "número 1") desenfocado + título
        intro_v = wd / "intro.mp4"
        safe = re.sub(r"[':\\%,;\[\]]", "", titulo)
        subprocess.run(["ffmpeg", "-y", "-loglevel", "error", "-sseof", "-3", "-i", str(clips[-1]),
                        "-i", str(intro_a), "-t", f"{di + 0.3:.2f}", "-filter_complex",
                        f"[0:v]boxblur=20:4,eq=brightness=-0.2,"
                        f"drawtext=text='{safe}':fontcolor=white:fontsize=84:borderw=8:"
                        f"bordercolor=black:x=(w-text_w)/2:y=(h-text_h)/2[v];"
                        f"[1:a]apad,aresample=48000[a]",
                        "-map", "[v]", "-map", "[a]", "-r", "30", "-c:v", "libx264",
                        "-c:a", "aac", str(intro_v)], check=True)
        # cuenta atrás: del último al primero, el mejor (último) al final
        seq = [intro_v] + list(reversed(clips))
        inputs, fc = [], ""
        for i, p in enumerate(seq):
            inputs += ["-i", str(p)]
            fc += (f"[{i}:v]scale=1080:1920:force_original_aspect_ratio=increase,"
                   f"crop=1080:1920,fps=30,setsar=1[v{i}];[{i}:a]aresample=48000[a{i}];")
        fc += "".join(f"[v{i}][a{i}]" for i in range(len(seq)))
        fc += f"concat=n={len(seq)}:v=1:a=1[v][a];[a]loudnorm=I=-14:TP=-1.5:LRA=11[ao]"
        subprocess.run(["ffmpeg", "-y", "-loglevel", "error"] + inputs +
                       ["-filter_complex", fc, "-map", "[v]", "-map", "[ao]",
                        "-c:v", "libx264", "-preset", "medium", "-crf", "20",
                        "-pix_fmt", "yuv420p", "-c:a", "aac", "-b:a", "160k",
                        "-movflags", "+faststart", str(out)], check=True)
    total = clipper.duration(out)
    out.with_suffix(".txt").write_text(
        f"{titulo}\n#gta6 #gtavi #gta #gaming\nDuración: {total:.0f}s "
        f"({'✔ >60s, apto TikTok Rewards' if total > 61 else '⚠ menos de 60s'})\n", "utf-8")
    print(f"✔ compilación: {out} ({total:.0f}s)")


# ---------------- 3. Guía ----------------
def cmd_guia(a):
    import guia
    import json
    if a.guion:
        g = json.loads(Path(a.guion).read_text("utf-8"))
    else:
        notas = Path(a.notas).read_text("utf-8") if a.notas else ""
        print("» escribiendo guion con IA...")
        g = ia.guion_guia(a.tema, notas, a.minutos)
        if not g:
            sys.exit("Sin IA: escribe un guion con el formato de guion_ejemplo.json y usa --guion.")
    guia.crear_guia(g, a.broll, HERE / "cola", a.musica)


def main():
    p = argparse.ArgumentParser(description="Fábrica de contenido GTA 6")
    sub = p.add_subparsers(dest="cmd", required=True)

    v = sub.add_parser("vod", help="VOD de Twitch → clips listos")
    v.add_argument("url")
    v.add_argument("--credit", default="")
    v.add_argument("--chat", help="chat.json ya descargado")
    v.add_argument("--top", type=int, default=12)
    v.add_argument("--facecam")
    v.add_argument("--mode", choices=["blur", "zoom"])
    v.add_argument("--sfx")
    v.add_argument("--lang", default="es")
    v.add_argument("--no-ia", action="store_true")
    v.set_defaults(fn=cmd_vod)

    c = sub.add_parser("compilacion", help="clips de una carpeta → compilación >60 s")
    c.add_argument("carpeta")
    c.add_argument("--titulo")
    c.add_argument("--intro", help="texto de la intro (voz IA)")
    c.add_argument("--credit", default="")
    c.add_argument("--max", type=int, default=5)
    c.set_defaults(fn=cmd_compilacion)

    g = sub.add_parser("guia", help="tema → guía con voz IA (largo + short)")
    g.add_argument("tema", nargs="?")
    g.add_argument("--guion")
    g.add_argument("--notas")
    g.add_argument("--minutos", type=float, default=4.0)
    g.add_argument("--broll", required=True)
    g.add_argument("--musica")
    g.set_defaults(fn=cmd_guia)

    a = p.parse_args()
    a.fn(a)


if __name__ == "__main__":
    main()
