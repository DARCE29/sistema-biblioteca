# Clipper GTA 6 → TikTok / YouTube Shorts

Dos scripts gratis y sin marca de agua:

- **`momentos.py`** — encuentra los mejores momentos de un VOD de Twitch con los picos del chat
  (KEKW, JAJAJA, ????, "clip it"…) y crea `clips.csv`.
- **`clipper.py`** — convierte cada momento en un vertical 9:16 listo para subir:
  quita silencios, zoom + efecto de sonido en los picos, subtítulos karaoke con palabras clave
  en color (en zona segura), audio a −14 LUFS, título-gancho, crédito y un `.txt` con
  descripción + hashtags + aviso de spoilers.

Estrategia completa: [`reports/Estrategias virales clips GTA 6.md`](reports/Estrategias%20virales%20clips%20GTA%206.md)

## Flujo de trabajo (las herramientas trabajan en equipo)

```
 1. ENCONTRAR            2. ANOTAR              3. EDITAR              4. PUBLICAR
 ┌──────────────┐       ┌──────────────┐       ┌──────────────┐       ┌──────────────┐
 │ Opus Clip /  │       │ clips.csv    │       │ clipper.py   │       │ TikTok +     │
 │ Vizard GRATIS│ ───►  │ link + min.  │ ───►  │ --batch      │ ───►  │ YT Shorts    │
 │ (o chat/VOD) │       │ + título     │       │ (sin marca)  │       │ (programados)│
 └──────────────┘       └──────────────┘       └──────────────┘       └──────────────┘
```

1. **Encontrar momentos (automático)**
   ```
   TwitchDownloaderCLI chatdownload --id 1234567890 -o chat.json
   python momentos.py chat.json --url https://www.twitch.tv/videos/1234567890 --credit @streamer
   ```
   Crea `clips.csv` con los 15 picos del chat. Alternativas: los **clips más vistos del día**
   (`twitch.tv/STREAMER/clips?range=24hr`) u Opus Clip/Vizard gratis (solo para anotar minutos).
2. **Revisar** `clips.csv`: borra los malos, ajusta minutos y escribe un **título-gancho** por fila
   (40–60 caracteres, siempre con "GTA 6").
3. **Editar todo de una vez:**
   ```
   python clipper.py --batch clips.csv -o salida/
   ```
4. **Publicar** desde `salida/`: 2–4 al día en TikTok y Shorts, programados
   (programador nativo o Buffer gratis). Copia descripción y hashtags del `.txt` de cada clip.
   Si el `.txt` dice **⚠ POSIBLE SPOILER**, no lo subas.

> Si un día quieres pagar una sola herramienta que encuentre momentos de gaming en Twitch,
> **Eklipse** (~$20–25/mes) reemplaza el paso 1.
> **Higgsfield** déjalo para cuando hagas contenido propio (efectos/IA generativa).

## Instalación (una vez, Windows)

1. Instala **Python 3.11+** desde python.org (marca "Add Python to PATH").
2. Instala **ffmpeg**: en PowerShell → `winget install Gyan.FFmpeg`
3. En esta carpeta: `pip install -r requirements.txt`
4. Descarga **TwitchDownloaderCLI** (gratis) de github.com/lay295/TwitchDownloader/releases

La primera vez que genere subtítulos descarga el modelo de voz (~500 MB).

## Columnas del CSV

| columna | obligatoria | ejemplo | nota |
|---|---|---|---|
| url | ✅ | link del VOD/clip o archivo local | solo baja el tramo indicado, no el VOD entero |
| start / end | | `01:23:10` / `01:23:45` | 15–40 s viraliza; +60 s para TikTok Rewards |
| title | | `NO PUEDE SER LO QUE PASÓ` | gancho arriba, corto y en mayúsculas |
| credit | | `@streamer` | siempre da crédito |
| mode | | `blur` (defecto) / `zoom` | blur = video entero con fondo desenfocado; zoom = recorta el centro |
| facecam | | `"0,0,0.25,0.3"` | cámara arriba + juego abajo. x,y,ancho,alto en fracción de la pantalla (0,0 = esquina sup. izq.) |

## Un solo clip

```
python clipper.py "https://www.twitch.tv/videos/123" --start 01:23:10 --end 01:23:45 --title "NO PUEDE SER" --credit "@streamer"
```

Opciones extra:
- `--sfx whoosh.mp3` → efecto de sonido en cada zoom (sácalos de Pixabay/Freesound)
- `--no-cut` (no quitar silencios), `--no-fx` (sin zooms), `--no-subs`
- `--lang es` (fija idioma), `WHISPER_MODEL=medium` (subtítulos más precisos, más lento)
- Ajustes finos (umbral de silencio, intensidad del zoom, palabras clave) al inicio de `clipper.py`.

## Aviso

Subir clips de otros sin permiso puede generar reclamos de copyright. Da crédito, prioriza
streamers que permiten clips y pídeles permiso cuando puedas.
