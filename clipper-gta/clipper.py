#!/usr/bin/env python3
"""
Clipper: convierte un clip horizontal (Twitch/Kick/YouTube o archivo local)
en un vertical 9:16 listo para TikTok / YouTube Shorts.

Edición mínima automática:
  - Recorte opcional (--start / --end)
  - Formato 1080x1920 (fondo desenfocado o zoom al centro)
  - Subtítulos automáticos palabra a palabra (faster-whisper)
  - Título arriba y crédito al streamer abajo (opcionales)

Uso:
  python clipper.py URL_O_ARCHIVO [--start 00:01:10 --end 00:01:45]
                    [--title "TEXTO"] [--credit "@streamer"]
                    [--mode blur|zoom] [--lang es] [--no-subs] [-o salida.mp4]
"""
import argparse
import os
import re
import subprocess
import sys
import tempfile
from pathlib import Path

W, H = 1080, 1920


def run(cmd):
    print("»", " ".join(str(c) for c in cmd[:6]), "...")
    subprocess.run(cmd, check=True)


def download(src: str, workdir: Path, start=None, end=None) -> Path:
    """Descarga con yt-dlp. Si hay start/end baja SOLO ese tramo (no el VOD entero)."""
    out = workdir / "source.%(ext)s"
    cmd = ["yt-dlp", "-f", "bv*[height<=1080]+ba/b[height<=1080]/b",
           "--merge-output-format", "mp4", "-o", str(out)]
    if start or end:
        cmd += ["--download-sections", f"*{start or '0'}-{end or 'inf'}",
                "--force-keyframes-at-cuts"]
    run(cmd + [src])
    return next(workdir.glob("source.*"))


def trim(src: Path, start, end, workdir: Path) -> Path:
    if not start and not end:
        return src
    out = workdir / "trim.mp4"
    cmd = ["ffmpeg", "-y", "-loglevel", "error"]
    if start:
        cmd += ["-ss", start]
    cmd += ["-i", str(src)]
    if end:
        cmd += ["-t", str(to_sec(end) - to_sec(start or "0"))]
    cmd += ["-c:v", "libx264", "-preset", "veryfast", "-crf", "18", "-c:a", "aac", str(out)]
    run(cmd)
    return out


def to_sec(t: str) -> float:
    parts = [float(p) for p in t.split(":")]
    s = 0.0
    for p in parts:
        s = s * 60 + p
    return s


def ass_time(t: float) -> str:
    h = int(t // 3600)
    m = int(t % 3600 // 60)
    s = t % 60
    return f"{h}:{m:02d}:{s:05.2f}"


def ass_escape(s: str) -> str:
    return s.replace("\\", "").replace("{", "(").replace("}", ")")


def transcribe(src: Path, lang, workdir: Path) -> Path:
    from faster_whisper import WhisperModel
    model_name = os.environ.get("WHISPER_MODEL", "small")
    print(f"» transcribiendo con whisper ({model_name})...")
    model = WhisperModel(model_name, device="auto", compute_type="int8")
    segments, info = model.transcribe(str(src), language=lang, word_timestamps=True,
                                      vad_filter=True)
    words = [w for seg in segments for w in (seg.words or [])]
    print(f"  idioma: {info.language}, palabras: {len(words)}")

    # Agrupar en bloques de hasta 3 palabras / 1.2 s
    groups, cur = [], []
    for w in words:
        if cur and (len(cur) >= 3 or w.end - cur[0].start > 1.2):
            groups.append(cur)
            cur = []
        cur.append(w)
    if cur:
        groups.append(cur)

    lines = []
    for g in groups:
        for i, w in enumerate(g):
            # Palabra actual resaltada en amarillo, resto en blanco
            txt = " ".join(
                ("{\\c&H00FFFF&}" + ass_escape(x.word.strip().upper()) + "{\\c&HFFFFFF&}")
                if j == i else ass_escape(x.word.strip().upper())
                for j, x in enumerate(g))
            end = g[i + 1].start if i + 1 < len(g) else w.end
            lines.append(f"Dialogue: 0,{ass_time(w.start)},{ass_time(end)},Sub,,0,0,0,,{txt}")

    ass = workdir / "subs.ass"
    ass.write_text(f"""[Script Info]
ScriptType: v4.00+
PlayResX: {W}
PlayResY: {H}

[V4+ Styles]
Format: Name, Fontname, Fontsize, PrimaryColour, SecondaryColour, OutlineColour, BackColour, Bold, Italic, Underline, StrikeOut, ScaleX, ScaleY, Spacing, Angle, BorderStyle, Outline, Shadow, Alignment, MarginL, MarginR, MarginV, Encoding
Style: Sub,Arial,82,&H00FFFFFF,&H00FFFFFF,&H00000000,&H80000000,-1,0,0,0,100,100,0,0,1,7,3,2,60,60,560,1

[Events]
Format: Layer, Start, End, Style, Name, MarginL, MarginR, MarginV, Effect, Text
""" + "\n".join(lines) + "\n", encoding="utf-8")
    return ass


def drawtext(text, y, size):
    safe = re.sub(r"[':\\%]", "", text)
    return (f"drawtext=text='{safe}':fontcolor=white:fontsize={size}:"
            f"borderw=6:bordercolor=black:x=(w-text_w)/2:y={y}")


def render(src: Path, out: Path, mode, subs, title, credit, facecam=None):
    if facecam:
        # facecam = "x,y,w,h" en fracciones 0-1 del video original (ej 0,0,0.25,0.3)
        fx, fy, fw, fh = [float(v) for v in facecam.split(",")]
        cam_h = 640
        vf = (f"[0:v]split[a][b];"
              f"[a]crop=iw*{fw}:ih*{fh}:iw*{fx}:ih*{fy},"
              f"scale={W}:{cam_h}:force_original_aspect_ratio=increase,crop={W}:{cam_h}[cam];"
              f"[b]scale=-2:{H - cam_h},crop={W}:{H - cam_h}[game];"
              f"[cam][game]vstack[v]")
    elif mode == "zoom":
        vf = f"[0:v]scale=-2:{H},crop={W}:{H}[v]"
    else:  # blur: fondo desenfocado + video completo al centro
        vf = (f"[0:v]split[a][b];"
              f"[a]scale={W}:{H}:force_original_aspect_ratio=increase,crop={W}:{H},"
              f"boxblur=25:5,eq=brightness=-0.15[bg];"
              f"[b]scale={W}:-2[fg];"
              f"[bg][fg]overlay=(W-w)/2:(H-h)/2[v]")
    post = []
    if title:
        post.append(drawtext(title, 220, 78))
    if credit:
        post.append(drawtext(credit, H - 260, 48))
    if subs:
        post.append(f"ass={subs.name}")
    if post:
        vf = vf[:-3] + "[v0];[v0]" + ",".join(post) + "[v]"

    cmd = (["ffmpeg", "-y", "-loglevel", "error", "-i", str(Path(src).resolve()),
         "-filter_complex", vf, "-map", "[v]", "-map", "0:a?",
         "-c:v", "libx264", "-preset", "medium", "-crf", "20", "-pix_fmt", "yuv420p",
         "-r", "30", "-c:a", "aac", "-b:a", "160k", "-movflags", "+faststart", str(Path(out).resolve())])
    print("» ffmpeg render ...")
    subprocess.run(cmd, check=True, cwd=str(subs.parent) if subs else None)


def process(src, out, start=None, end=None, title=None, credit=None,
            mode="blur", facecam=None, lang=None, subs=True):
    out = Path(out)
    out.parent.mkdir(parents=True, exist_ok=True)
    with tempfile.TemporaryDirectory() as d:
        wd = Path(d)
        if os.path.exists(src):
            clip = trim(Path(src), start, end, wd)
        else:
            clip = download(src, wd, start, end)
        ass = transcribe(clip, lang, wd) if subs else None
        render(clip, out, mode, ass, title, credit, facecam)
    print(f"✔ listo: {out}")


def batch(csv_path, outdir, lang, subs):
    """CSV con columnas: url,start,end,title,credit,mode,facecam (solo url obligatoria)."""
    import csv
    with open(csv_path, newline="", encoding="utf-8-sig") as f:
        rows = [r for r in csv.DictReader(f) if (r.get("url") or "").strip()]
    ok = 0
    for n, r in enumerate(rows, 1):
        g = lambda k: (r.get(k) or "").strip() or None
        name = re.sub(r"[^\w-]+", "_", g("title") or f"clip")[:40]
        out = Path(outdir) / f"{n:03d}_{name}.mp4"
        print(f"\n=== [{n}/{len(rows)}] {g('url')} ===")
        try:
            process(g("url"), out, g("start"), g("end"), g("title"), g("credit"),
                    g("mode") or "blur", g("facecam"), lang, subs)
            ok += 1
        except Exception as e:  # sigue con el siguiente clip
            print(f"✘ error: {e}")
    print(f"\nTerminado: {ok}/{len(rows)} clips en {outdir}/")


def main():
    p = argparse.ArgumentParser(description="Clip horizontal -> vertical para TikTok/Shorts")
    p.add_argument("src", nargs="?", help="URL (Twitch/Kick/YouTube) o archivo local")
    p.add_argument("--batch", help="CSV con muchos clips (ver clips_ejemplo.csv)")
    p.add_argument("--start", help="inicio, ej 01:23:10")
    p.add_argument("--end", help="fin, ej 01:23:45")
    p.add_argument("--title", help="texto arriba (gancho)")
    p.add_argument("--credit", help="crédito abajo, ej @streamer")
    p.add_argument("--mode", choices=["blur", "zoom"], default="blur")
    p.add_argument("--facecam", help="zona de la cámara x,y,w,h en fracciones (ej 0,0,0.25,0.3)")
    p.add_argument("--lang", default=None, help="idioma de subtítulos (es, en...). Auto si se omite")
    p.add_argument("--no-subs", action="store_true")
    p.add_argument("-o", "--output", default="output/clip.mp4")
    a = p.parse_args()

    if a.batch:
        batch(a.batch, Path(a.output).parent if a.output.endswith(".mp4") else a.output,
              a.lang, not a.no_subs)
    elif a.src:
        process(a.src, a.output, a.start, a.end, a.title, a.credit,
                a.mode, a.facecam, a.lang, not a.no_subs)
    else:
        p.error("falta URL/archivo o --batch")


if __name__ == "__main__":
    sys.exit(main())
