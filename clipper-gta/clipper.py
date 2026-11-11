#!/usr/bin/env python3
"""
Clipper: convierte un momento de stream (Twitch/Kick/YouTube o archivo local)
en un vertical 9:16 listo para TikTok / YouTube Shorts.

Edición automática (basada en reports/Estrategias virales clips GTA 6.md):
  - Descarga solo el tramo indicado (--start / --end)
  - Quita silencios y tiempos muertos
  - Formato 1080x1920: blur, zoom o facecam arriba + juego abajo
  - Zoom "punch-in" (+ efecto de sonido opcional) en los picos de audio
  - Subtítulos karaoke 2-4 palabras, palabra activa con "pop", palabras clave en color,
    dentro de las zonas seguras de TikTok/Shorts
  - Audio normalizado a -14 LUFS
  - Título-gancho arriba y crédito al streamer abajo
  - Archivo .txt con descripción, hashtags y aviso de spoilers

Uso:
  python clipper.py URL_O_ARCHIVO --start 01:23:10 --end 01:23:45 --title "NO PUEDE SER" --credit "@streamer"
  python clipper.py --batch clips.csv -o salida/
"""
import argparse
import os
import re
import subprocess
import sys
import tempfile
from pathlib import Path

W, H = 1080, 1920

# ---- Ajustes (valores de partida; afínalos con tus analíticas) ----
SILENCE_DB = -35        # por debajo de esto se considera silencio
SILENCE_MIN = 0.6       # huecos más largos que esto se recortan (s)
SILENCE_PAD = 0.12      # margen que se deja a cada lado (s)
ZOOM = 1.15             # intensidad del punch-in
ZOOM_DUR = 1.0          # duración de cada zoom (s)
PEAK_GAP = 4.0          # separación mínima entre zooms/SFX (s)
MIN_LEN_FX = 12         # no meter zooms/SFX en clips más cortos que esto (s)

# Palabras clave -> color ASS (&HBBGGRR&)
KEYWORDS = {
    "&H3C3CFF&": ["muerto", "muere", "murió", "mató", "matar", "dead", "kill", "killed",
                  "policía", "policia", "cops", "police", "disparo", "bala", "explota"],
    "&H5AE65A&": ["dinero", "plata", "pasta", "millón", "millones", "money", "cash",
                  "robo", "robar", "atraco", "heist", "banco"],
    "&HFFC83C&": ["gta", "vice", "city", "lucia", "jason", "bug", "glitch", "secreto"],
}
SPOILER_WORDS = ["final del juego", "misión final", "mision final", "créditos finales",
                 "ending", "final mission", "last mission", "spoiler", "el final"]


def run(cmd, **kw):
    print("»", " ".join(str(c) for c in cmd[:5]), "...")
    return subprocess.run(cmd, check=True, **kw)


def to_sec(t: str) -> float:
    s = 0.0
    for p in t.split(":"):
        s = s * 60 + float(p)
    return s


def duration(path: Path) -> float:
    r = subprocess.run(["ffprobe", "-v", "error", "-show_entries", "format=duration",
                        "-of", "csv=p=0", str(path)], capture_output=True, text=True)
    return float(r.stdout.strip() or 0)


# ---------------- 1. Obtener el clip ----------------
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


# ---------------- 2. Quitar silencios ----------------
def cut_silences(src: Path, workdir: Path) -> Path:
    r = subprocess.run(["ffmpeg", "-hide_banner", "-i", str(src), "-af",
                        f"silencedetect=n={SILENCE_DB}dB:d={SILENCE_MIN}", "-f", "null", "-"],
                       capture_output=True, text=True)
    starts = [float(x) for x in re.findall(r"silence_start: ([\d.]+)", r.stderr)]
    ends = [float(x) for x in re.findall(r"silence_end: ([\d.]+)", r.stderr)]
    total = duration(src)
    ends += [total] * (len(starts) - len(ends))
    keep, pos = [], 0.0
    for s, e in zip(starts, ends):
        if s + SILENCE_PAD > pos:
            keep.append((pos, s + SILENCE_PAD))
        pos = max(pos, e - SILENCE_PAD)
    if pos < total:
        keep.append((pos, total))
    removed = total - sum(b - a for a, b in keep)
    if removed < 0.3:
        return src
    print(f"  recortando {removed:.1f}s de silencio ({len(starts)} huecos)")
    expr = "+".join(f"between(t,{a:.3f},{b:.3f})" for a, b in keep)
    out = workdir / "cut.mp4"
    run(["ffmpeg", "-y", "-loglevel", "error", "-i", str(src),
         "-vf", f"select='{expr}',setpts=N/FRAME_RATE/TB",
         "-af", f"aselect='{expr}',asetpts=N/SR/TB",
         "-c:v", "libx264", "-preset", "veryfast", "-crf", "18", "-c:a", "aac", str(out)])
    return out


# ---------------- 3. Picos de audio (para zoom / SFX) ----------------
def audio_peaks(src: Path, max_peaks=3):
    import numpy as np
    raw = subprocess.run(["ffmpeg", "-loglevel", "error", "-i", str(src), "-ac", "1",
                          "-ar", "8000", "-f", "s16le", "-"], capture_output=True).stdout
    a = np.frombuffer(raw, dtype=np.int16).astype(np.float32)
    win = 800  # 0.1 s
    n = len(a) // win
    if n < MIN_LEN_FX * 10:
        return []
    rms = np.sqrt((a[: n * win].reshape(n, win) ** 2).mean(axis=1))
    rms = np.convolve(rms, np.ones(3) / 3, mode="same")
    thr = rms.mean() + 1.5 * rms.std()
    peaks = []
    for i in np.argsort(rms)[::-1]:
        if rms[i] < thr or len(peaks) >= max_peaks:
            break
        t = i / 10
        if all(abs(t - p) >= PEAK_GAP for p in peaks):
            peaks.append(t)
    return sorted(peaks)


# ---------------- 4. Subtítulos ----------------
def ass_time(t: float) -> str:
    t = max(t, 0)
    return f"{int(t // 3600)}:{int(t % 3600 // 60):02d}:{t % 60:05.2f}"


def clean(w: str) -> str:
    return w.strip().upper().replace("\\", "").replace("{", "(").replace("}", ")")


def kw_color(word: str):
    w = re.sub(r"[^\wáéíóúñü]", "", word.lower())
    for color, words in KEYWORDS.items():
        if w in words:
            return color
    return None


def transcribe(src: Path, lang):
    from faster_whisper import WhisperModel
    model_name = os.environ.get("WHISPER_MODEL", "small")
    print(f"» transcribiendo con whisper ({model_name})...")
    model = WhisperModel(model_name, device="auto", compute_type="int8")
    segments, info = model.transcribe(str(src), language=lang, word_timestamps=True,
                                      vad_filter=True)
    words = [w for seg in segments for w in (seg.words or [])]
    print(f"  idioma: {info.language}, palabras: {len(words)}")
    return words


def build_ass(words, workdir: Path) -> Path:
    # Grupos de máx. 4 palabras; corta en pausas > 0.3 s o si el grupo dura > 1.4 s
    groups, cur = [], []
    for w in words:
        if cur and (len(cur) >= 4 or w.start - cur[-1].end > 0.3 or w.end - cur[0].start > 1.4):
            groups.append(cur)
            cur = []
        cur.append(w)
    if cur:
        groups.append(cur)

    lines = []
    for gi, g in enumerate(groups):
        next_start = groups[gi + 1][0].start if gi + 1 < len(groups) else None
        for i, w in enumerate(g):
            parts = []
            for j, x in enumerate(g):
                txt = clean(x.word)
                if j == i:  # palabra activa: amarilla y con "pop"
                    parts.append("{\\c&H00E6FF&\\fscx125\\fscy125\\t(0,90,\\fscx112\\fscy112)}"
                                 + txt + "{\\c&HFFFFFF&\\fscx100\\fscy100}")
                elif kw_color(x.word):
                    parts.append("{\\c" + kw_color(x.word) + "}" + txt + "{\\c&HFFFFFF&}")
                else:
                    parts.append(txt)
            end = g[i + 1].start if i + 1 < len(g) else w.end + 0.15
            if next_start is not None:
                end = min(end, next_start)  # nunca solapar con el siguiente grupo
            lines.append(f"Dialogue: 0,{ass_time(w.start)},{ass_time(end)},Sub,,0,0,0,,"
                         + " ".join(parts))

    ass = workdir / "subs.ass"
    # Zonas seguras: abajo ~640 px libres, derecha 160 px (botones), izquierda 100 px
    ass.write_text(f"""[Script Info]
ScriptType: v4.00+
PlayResX: {W}
PlayResY: {H}
WrapStyle: 0

[V4+ Styles]
Format: Name, Fontname, Fontsize, PrimaryColour, SecondaryColour, OutlineColour, BackColour, Bold, Italic, Underline, StrikeOut, ScaleX, ScaleY, Spacing, Angle, BorderStyle, Outline, Shadow, Alignment, MarginL, MarginR, MarginV, Encoding
Style: Sub,Arial Black,88,&H00FFFFFF,&H00FFFFFF,&H00000000,&H90000000,-1,0,0,0,100,100,1,0,1,8,4,2,100,160,640,1

[Events]
Format: Layer, Start, End, Style, Name, MarginL, MarginR, MarginV, Effect, Text
""" + "\n".join(lines) + "\n", encoding="utf-8")
    return ass


# ---------------- 5. Render ----------------
def drawtext(text, y, size, max_chars=20):
    """Texto centrado; si es largo lo parte en varias líneas para que no se salga."""
    safe = re.sub(r"[':\\%,;\[\]]", "", text)
    lines, cur = [], ""
    for word in safe.split():
        if cur and len(cur) + 1 + len(word) > max_chars:
            lines.append(cur)
            cur = word
        else:
            cur = f"{cur} {word}".strip()
    if cur:
        lines.append(cur)
    return ",".join(
        f"drawtext=text='{ln}':fontcolor=white:fontsize={size}:"
        f"borderw=7:bordercolor=black:x=(w-text_w)/2:y={y + k * int(size * 1.15)}"
        for k, ln in enumerate(lines))


def render(src: Path, out: Path, mode, subs, title, credit, facecam=None,
           peaks=(), sfx=None):
    if facecam:
        # facecam = "x,y,w,h" en fracciones 0-1 del video original (ej 0,0,0.25,0.3)
        fx, fy, fw, fh = [float(v) for v in facecam.split(",")]
        cam_h = 700
        vf = (f"[0:v]split[a][b];"
              f"[a]crop=iw*{fw}:ih*{fh}:iw*{fx}:ih*{fy},"
              f"scale={W}:{cam_h}:force_original_aspect_ratio=increase,crop={W}:{cam_h}[cam];"
              f"[b]scale=-2:{H - cam_h},crop={W}:{H - cam_h}[game];"
              f"[cam][game]vstack,setsar=1[base]")
    elif mode == "zoom":
        vf = f"[0:v]scale=-2:{H},crop={W}:{H},setsar=1[base]"
    else:  # blur: fondo desenfocado + video completo al centro
        vf = (f"[0:v]split[a][b];"
              f"[a]scale={W}:{H}:force_original_aspect_ratio=increase,crop={W}:{H},"
              f"boxblur=25:5,eq=brightness=-0.15[bg];"
              f"[b]scale={W}:-2[fg];"
              f"[bg][fg]overlay=(W-w)/2:(H-h)/2,setsar=1[base]")

    post = []
    if peaks:  # punch-in zoom en cada pico
        z = "+".join(f"between(t,{p - 0.05:.2f},{p + ZOOM_DUR:.2f})" for p in peaks)
        post.append(f"scale=w='trunc({W}*(1+{ZOOM - 1}*({z}))/2)*2':"
                    f"h='trunc({H}*(1+{ZOOM - 1}*({z}))/2)*2':eval=frame")
        post.append(f"crop={W}:{H}:(iw-{W})/2:(ih-{H})/2")
    if title:
        post.append(drawtext(title, 200, 76))
    if credit:
        post.append(drawtext(credit, H - 300, 46))
    if subs:
        post.append(f"ass={subs.name}")
    vf += ";[base]" + (",".join(post) if post else "null") + "[v]"

    inputs = ["-i", str(Path(src).resolve())]
    loud = "loudnorm=I=-14:TP=-1.5:LRA=11"
    if sfx and peaks:
        inputs += ["-i", str(Path(sfx).resolve())]
        n = len(peaks)
        af = f"[1:a]volume=0.6,asplit={n}" + "".join(f"[s{i}]" for i in range(n)) + ";"
        af += "".join(f"[s{i}]adelay={int(p * 1000)}:all=1[d{i}];" for i, p in enumerate(peaks))
        af += "[0:a]" + "".join(f"[d{i}]" for i in range(n))
        af += f"amix=inputs={n + 1}:duration=first:normalize=0,{loud}[a]"
    else:
        af = f"[0:a]{loud}[a]"

    cmd = (["ffmpeg", "-y", "-loglevel", "error"] + inputs +
           ["-filter_complex", vf + ";" + af, "-map", "[v]", "-map", "[a]",
            "-c:v", "libx264", "-preset", "medium", "-crf", "20", "-pix_fmt", "yuv420p",
            "-r", "30", "-c:a", "aac", "-b:a", "160k", "-ar", "48000",
            "-movflags", "+faststart", str(Path(out).resolve())])
    print("» ffmpeg render ...")
    subprocess.run(cmd, check=True, cwd=str(subs.parent) if subs else None)


# ---------------- 6. Metadatos ----------------
def write_meta(out: Path, title, credit, text):
    streamer = (credit or "").lstrip("@").strip()
    tags = ["#gta6", "#gtavi", "#gta", "#gaming"] + ([f"#{streamer}"] if streamer else [])
    hook = title or (text[:55] + "…" if len(text) > 55 else text) or "Esto pasó en GTA 6"
    if "gta" not in hook.lower():
        hook = f"{hook} | GTA 6"
    spoilers = [w for w in SPOILER_WORDS if w in text.lower()]
    meta = [
        "=== TIKTOK (descripción) ===",
        f"{hook} {('· ' + credit) if credit else ''}".strip(),
        " ".join(tags[:5]),
        "",
        "=== YOUTUBE SHORTS ===",
        f"Título: {hook[:56]} #gta6",
        f"Descripción: {hook}. Clip de {credit or 'stream'} (créditos al streamer).",
        " ".join(tags[:3]),
        "",
        "=== TRANSCRIPCIÓN ===",
        text,
    ]
    if spoilers:
        meta.insert(0, f"⚠ POSIBLE SPOILER ({', '.join(spoilers)}): revisa antes de subir\n")
        print(f"⚠ posible spoiler detectado: {spoilers}")
    out.with_suffix(".txt").write_text("\n".join(meta), encoding="utf-8")


# ---------------- Proceso completo ----------------
def process(src, out, start=None, end=None, title=None, credit=None,
            mode="blur", facecam=None, lang=None, subs=True,
            cut=True, fx=True, sfx=None):
    out = Path(out)
    out.parent.mkdir(parents=True, exist_ok=True)
    with tempfile.TemporaryDirectory() as d:
        wd = Path(d)
        clip = trim(Path(src), start, end, wd) if os.path.exists(src) else download(src, wd, start, end)
        if cut:
            clip = cut_silences(clip, wd)
        peaks = audio_peaks(clip) if fx else []
        if peaks:
            print(f"  zoom en picos: {', '.join(f'{p:.1f}s' for p in peaks)}")
        words = transcribe(clip, lang) if subs else []
        ass = build_ass(words, wd) if words else None
        render(clip, out, mode, ass, title, credit, facecam, peaks, sfx)
        write_meta(out, title, credit, " ".join(w.word.strip() for w in words))
    print(f"✔ listo: {out}  (+ {out.with_suffix('.txt').name})")


def batch(csv_path, outdir, **opts):
    """CSV con columnas: url,start,end,title,credit,mode,facecam (solo url obligatoria)."""
    import csv
    with open(csv_path, newline="", encoding="utf-8-sig") as f:
        rows = [r for r in csv.DictReader(f) if (r.get("url") or "").strip()]
    ok = 0
    for n, r in enumerate(rows, 1):
        g = lambda k: (r.get(k) or "").strip() or None
        name = re.sub(r"[^\w-]+", "_", g("title") or "clip")[:40]
        out = Path(outdir) / f"{n:03d}_{name}.mp4"
        print(f"\n=== [{n}/{len(rows)}] {g('url')} ===")
        try:
            process(g("url"), out, g("start"), g("end"), g("title"), g("credit"),
                    g("mode") or "blur", g("facecam"), **opts)
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
    p.add_argument("--title", help="texto-gancho arriba (incluye 'GTA 6')")
    p.add_argument("--credit", help="crédito abajo, ej @streamer")
    p.add_argument("--mode", choices=["blur", "zoom"], default="blur")
    p.add_argument("--facecam", help="zona de la cámara x,y,w,h en fracciones (ej 0,0,0.25,0.3)")
    p.add_argument("--lang", default=None, help="idioma de subtítulos (es, en...). Auto si se omite")
    p.add_argument("--sfx", help="efecto de sonido (mp3/wav) que suena en cada zoom")
    p.add_argument("--no-subs", action="store_true")
    p.add_argument("--no-cut", action="store_true", help="no quitar silencios")
    p.add_argument("--no-fx", action="store_true", help="sin zooms/SFX automáticos")
    p.add_argument("-o", "--output", default="output/clip.mp4")
    a = p.parse_args()

    opts = dict(lang=a.lang, subs=not a.no_subs, cut=not a.no_cut, fx=not a.no_fx, sfx=a.sfx)
    if a.batch:
        outdir = Path(a.output).parent if a.output.endswith(".mp4") else a.output
        batch(a.batch, outdir, **opts)
    elif a.src:
        process(a.src, a.output, a.start, a.end, a.title, a.credit, a.mode, a.facecam, **opts)
    else:
        p.error("falta URL/archivo o --batch")


if __name__ == "__main__":
    sys.exit(main())
