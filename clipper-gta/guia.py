#!/usr/bin/env python3
"""
Guías automáticas: tema → guion (Claude) → voz IA → b-roll + subtítulos →
video largo 16:9 para YouTube + Short 9:16.

Uso:
  python guia.py "Cómo ganar dinero rápido en GTA 6" --notas notas.txt --broll clips/ -o guias/
  python guia.py --guion guion.json --broll clips/            (usar un guion ya escrito/editado)

--broll: carpeta con videos de gameplay (tus clips, grabaciones de tu consola, etc.).
--notas: datos verificados para la guía (la IA no inventa fuera de ellos).
"""
import argparse
import json
import random
import re
import subprocess
import sys
import tempfile
from pathlib import Path

import clipper
import ia
import voz

VIDEO_EXT = {".mp4", ".mov", ".mkv", ".webm"}


def dur(p) -> float:
    return clipper.duration(Path(p))


def make_broll(files, total, w, h, wd: Path, min_s=3.0, max_s=5.0) -> Path:
    """Encadena trozos de 3-5 s de los videos (un cambio de plano cada pocos segundos)."""
    rnd = random.Random(7)
    durs = {f: dur(f) for f in files}
    parts, t, i = [], 0.0, 0
    while t < total + 0.5:
        f = files[i % len(files)]
        i += 1
        d = min(rnd.uniform(min_s, max_s), max(durs[f] - 0.1, 0.5))
        start = rnd.uniform(0, max(durs[f] - d, 0))
        part = wd / f"b{len(parts):03d}.mp4"
        subprocess.run(["ffmpeg", "-y", "-loglevel", "error", "-ss", f"{start:.2f}", "-i", str(f),
                        "-t", f"{d:.2f}", "-an", "-vf",
                        f"scale={w}:{h}:force_original_aspect_ratio=increase,crop={w}:{h},"
                        f"fps=30,setsar=1", "-c:v", "libx264", "-preset", "veryfast",
                        "-crf", "20", str(part)], check=True)
        parts.append(part)
        t += d
    lst = wd / "broll.txt"
    lst.write_text("".join(f"file '{p.name}'\n" for p in parts))
    out = wd / f"broll_{w}x{h}.mp4"
    subprocess.run(["ffmpeg", "-y", "-loglevel", "error", "-f", "concat", "-safe", "0",
                    "-i", lst.name, "-c", "copy", out.name], check=True, cwd=wd)
    return out


def narrar(bloques, wd: Path, tag: str):
    """bloques = [(texto_voz, texto_pantalla)] → (audio.mp3, [(inicio, fin, texto_pantalla)])."""
    audios, marcas, t = [], [], 0.0
    for k, (texto, pantalla) in enumerate(bloques):
        if not texto.strip():
            continue
        a = voz.hablar(texto, wd / f"{tag}_{k:02d}.mp3")
        d = dur(a)
        marcas.append((t, t + d, pantalla))
        audios.append(a)
        t += d + 0.25
    lst = wd / f"{tag}_voz.txt"
    # pequeño silencio entre bloques para respirar
    sil = wd / "sil.mp3"
    if not sil.exists():
        subprocess.run(["ffmpeg", "-y", "-loglevel", "error", "-f", "lavfi", "-i",
                        "anullsrc=r=24000:cl=mono", "-t", "0.25", "-c:a", "libmp3lame", str(sil)],
                       check=True)
    lst.write_text("".join(f"file '{a.name}'\nfile 'sil.mp3'\n" for a in audios))
    out = wd / f"{tag}_voz.wav"
    subprocess.run(["ffmpeg", "-y", "-loglevel", "error", "-f", "concat", "-safe", "0",
                    "-i", lst.name, "-ar", "48000", "-ac", "1", out.name], check=True, cwd=wd)
    return out, marcas


def render(broll, voice, marcas, out: Path, w, h, titulo_fijo=None, musica=None, wd=None):
    words = clipper.transcribe(voice, "es")
    vertical = h > w
    ass = clipper.build_ass(words, wd, w=w, h=h,
                            margin_v=640 if vertical else 90, size=88 if vertical else 62)
    post = []
    if titulo_fijo:
        post.append(clipper.drawtext(titulo_fijo, 200, 76))
    for a, b, txt in marcas:  # texto de cada sección arriba mientras suena
        if txt and not vertical:
            safe = re.sub(r"[':\\%,;\[\]]", "", txt)
            post.append(f"drawtext=text='{safe}':fontcolor=white:fontsize=56:borderw=6:"
                        f"bordercolor=black:x=(w-text_w)/2:y=60:enable='between(t,{a:.2f},{b:.2f})'")
    post.append(f"ass={ass.name}")
    vf = "[0:v]" + ",".join(post) + "[v]"
    inputs = ["-i", str(Path(broll).resolve()), "-i", str(Path(voice).resolve())]
    if musica:
        inputs += ["-stream_loop", "-1", "-i", str(Path(musica).resolve())]
        af = ("[2:a]volume=0.10[m];[1:a][m]amix=inputs=2:duration=first:normalize=0,"
              "loudnorm=I=-14:TP=-1.5:LRA=11[a]")
    else:
        af = "[1:a]loudnorm=I=-14:TP=-1.5:LRA=11[a]"
    out.parent.mkdir(parents=True, exist_ok=True)
    subprocess.run(["ffmpeg", "-y", "-loglevel", "error"] + inputs +
                   ["-filter_complex", vf + ";" + af, "-map", "[v]", "-map", "[a]", "-shortest",
                    "-c:v", "libx264", "-preset", "medium", "-crf", "20", "-pix_fmt", "yuv420p",
                    "-c:a", "aac", "-b:a", "160k", "-movflags", "+faststart",
                    str(out.resolve())], check=True, cwd=wd)


def slug(s):
    return re.sub(r"[^\w-]+", "_", s.lower())[:50].strip("_")


def crear_guia(guion: dict, broll_dir, outdir, musica=None):
    files = sorted(p for p in Path(broll_dir).iterdir() if p.suffix.lower() in VIDEO_EXT)
    if not files:
        sys.exit(f"No hay videos en {broll_dir}")
    outdir = Path(outdir) / slug(guion["titulo_youtube"])
    outdir.mkdir(parents=True, exist_ok=True)
    (outdir / "guion.json").write_text(json.dumps(guion, ensure_ascii=False, indent=2), "utf-8")

    with tempfile.TemporaryDirectory() as d:
        wd = Path(d)
        # --- Video largo 16:9 ---
        bloques = [(guion["gancho_voz"], guion["titulo_youtube"])]
        bloques += [(s["texto_voz"], s["texto_pantalla"]) for s in guion["secciones"]]
        bloques += [(guion["cierre_voz"], "")]
        print("» voz IA (video largo)...")
        voice, marcas = narrar(bloques, wd, "largo")
        print("» b-roll 16:9...")
        broll = make_broll(files, dur(voice), 1920, 1080, wd)
        render(broll, voice, marcas, outdir / "guia_youtube.mp4", 1920, 1080,
               musica=musica, wd=wd)

        # --- Short 9:16 ---
        print("» voz IA (short)...")
        voice_s, marcas_s = narrar([(guion["short_texto_voz"], "")], wd, "short")
        broll_s = make_broll(files, dur(voice_s), 1080, 1920, wd, 2.0, 3.5)
        render(broll_s, voice_s, marcas_s, outdir / "guia_short.mp4", 1080, 1920,
               titulo_fijo=guion["short_gancho"], musica=musica, wd=wd)

    tags = " ".join(guion["hashtags"][:5])
    (outdir / "publicar.txt").write_text("\n".join([
        "=== YOUTUBE (video largo) ===", f"Título: {guion['titulo_youtube']}",
        f"Texto miniatura: {guion['miniatura_texto']}", "", guion["descripcion_youtube"], tags, "",
        "=== SHORT / TIKTOK ===", guion["short_gancho"], tags,
    ]), "utf-8")
    print(f"✔ listo: {outdir}/ (guia_youtube.mp4, guia_short.mp4, publicar.txt, guion.json)")
    return outdir


def main():
    p = argparse.ArgumentParser(description="Guía automática con voz IA")
    p.add_argument("tema", nargs="?", help="tema de la guía")
    p.add_argument("--guion", help="usar un guion.json ya escrito en vez de generarlo")
    p.add_argument("--notas", help="archivo .txt con datos verificados")
    p.add_argument("--minutos", type=float, default=4.0)
    p.add_argument("--broll", required=True, help="carpeta con videos de gameplay")
    p.add_argument("--musica", help="música de fondo (sin copyright)")
    p.add_argument("-o", "--output", default="guias")
    a = p.parse_args()

    if a.guion:
        guion = json.loads(Path(a.guion).read_text("utf-8"))
    elif a.tema:
        notas = Path(a.notas).read_text("utf-8") if a.notas else ""
        print("» escribiendo guion con IA...")
        guion = ia.guion_guia(a.tema, notas, a.minutos)
        if not guion:
            sys.exit("No se pudo generar el guion (¿falta ANTHROPIC_API_KEY?). "
                     "Escribe uno a mano con el formato de guion_ejemplo.json y usa --guion.")
    else:
        p.error("indica un tema o --guion")
    crear_guia(guion, a.broll, a.output, a.musica)


if __name__ == "__main__":
    main()
