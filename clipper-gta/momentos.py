#!/usr/bin/env python3
"""
Buscador de momentos: encuentra los picos del chat de un VOD de Twitch y genera un CSV
listo para `clipper.py --batch`.

1) Descarga el chat con TwitchDownloader (gratis):
     TwitchDownloaderCLI chatdownload --id 1234567890 -o chat.json
2) Busca momentos:
     python momentos.py chat.json --url https://www.twitch.tv/videos/1234567890 --credit @streamer
3) Revisa clips.csv (pon títulos-gancho, borra los malos) y edita:
     python clipper.py --batch clips.csv -o salida/
"""
import argparse
import csv
import json
import re
import statistics
from collections import Counter

BIN = 10          # segundos por ventana
CHAT_DELAY = 8    # el chat reacciona ~5-10 s después del momento
BEFORE = 22       # segundos antes de la reacción donde empieza el clip
AFTER = 10        # segundos después
MIN_SEP = 90      # separación mínima entre momentos (s)

# Emotes / palabras que indican reacción fuerte
HYPE = re.compile(
    r"\b(kekw|lul|lmao+|lmfao|omegalul|pog+|pogchamp|poggers|pogu|w+|ez|clip(\s?it)?|"
    r"jaja+|jsjs+|xd+|jajaja+|nooo+|wtf|omg|que\s?paso|qué\s?pasó|monkas|pepelaugh|"
    r"icant|aware|sadge|ratio|goat|insane|bro)\b|\?{3,}|!{3,}",
    re.I)


def hms(t):
    t = max(0, int(t))
    return f"{t // 3600:02d}:{t % 3600 // 60:02d}:{t % 60:02d}"


def main():
    p = argparse.ArgumentParser(description="Momentos virales desde el chat de Twitch")
    p.add_argument("chat", help="JSON de TwitchDownloader (chatdownload)")
    p.add_argument("--url", required=True, help="URL del VOD")
    p.add_argument("--credit", default="", help="@streamer")
    p.add_argument("--top", type=int, default=15, help="cuántos momentos sacar")
    p.add_argument("-o", "--output", default="clips.csv")
    a = p.parse_args()

    data = json.load(open(a.chat, encoding="utf-8"))
    comments = data.get("comments", [])
    msgs, hype, sample = Counter(), Counter(), {}
    for c in comments:
        t = c.get("content_offset_seconds", 0)
        body = (c.get("message") or {}).get("body", "")
        b = int(t // BIN)
        msgs[b] += 1
        hype[b] += len(HYPE.findall(body))
        sample.setdefault(b, []).append(body)
    if not msgs:
        raise SystemExit("El JSON no tiene mensajes de chat.")

    last = max(msgs)
    raw = [msgs[i] + 2 * hype[i] for i in range(last + 1)]
    # Puntuación relativa al ritmo normal del chat en los 5 min alrededor
    scores = []
    for i, v in enumerate(raw):
        ctx = raw[max(0, i - 15): i + 15]
        med = statistics.median(ctx)
        mad = statistics.median([abs(x - med) for x in ctx]) or 1
        scores.append((v - med) / mad)

    picked = []
    for i in sorted(range(len(scores)), key=lambda i: -scores[i]):
        if len(picked) >= a.top or scores[i] < 3:
            break
        t = i * BIN - CHAT_DELAY
        if all(abs(t - q) >= MIN_SEP for q, _ in picked):
            picked.append((t, i))
    picked.sort()

    with open(a.output, "w", newline="", encoding="utf-8") as f:
        w = csv.writer(f)
        w.writerow(["url", "start", "end", "title", "credit", "mode", "facecam", "chat"])
        for t, i in picked:
            top_words = Counter(m.lower() for m in sample.get(i, []) if len(m) < 25).most_common(3)
            w.writerow([a.url, hms(t - BEFORE), hms(t + AFTER), "", a.credit, "", "",
                        " | ".join(m for m, _ in top_words)])
    print(f"✔ {len(picked)} momentos en {a.output}")
    for t, i in picked:
        print(f"  {hms(t)}  puntuación {scores[i]:.1f}  ({msgs[i]} mensajes)")
    print("Revisa el CSV, escribe un título-gancho por fila y lanza clipper.py --batch")


if __name__ == "__main__":
    main()
