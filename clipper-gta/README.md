# Clipper GTA 6 → TikTok / YouTube Shorts

Script que convierte momentos de streams (Twitch, Kick, YouTube) en videos verticales 9:16
listos para subir: **subtítulos automáticos estilo TikTok, título-gancho y crédito al streamer**.
Gratis y sin marca de agua.

## Flujo de trabajo (las herramientas trabajan en equipo)

```
 1. ENCONTRAR            2. ANOTAR              3. EDITAR              4. PUBLICAR
 ┌──────────────┐       ┌──────────────┐       ┌──────────────┐       ┌──────────────┐
 │ Opus Clip /  │       │ clips.csv    │       │ clipper.py   │       │ TikTok +     │
 │ Vizard GRATIS│ ───►  │ link + min.  │ ───►  │ --batch      │ ───►  │ YT Shorts    │
 │ (o chat/VOD) │       │ + título     │       │ (sin marca)  │       │ (programados)│
 └──────────────┘       └──────────────┘       └──────────────┘       └──────────────┘
```

1. **Encontrar momentos (5–10 min)**
   - Pega el VOD en **Opus Clip** o **Vizard** (plan gratis, 60 min/mes cada uno). Te marca los
     mejores momentos → **solo anota el minuto** (su export lleva marca de agua, no lo uses).
   - Sin créditos: en Twitch revisa los **clips más vistos del día** del streamer
     (`twitch.tv/STREAMER/clips?range=24hr`) o salta en el VOD a donde el chat explota.
2. **Anotar** cada momento en una fila de `clips.csv` (copia `clips_ejemplo.csv`).
3. **Editar todo de una vez:**
   ```
   python clipper.py --batch clips.csv -o salida/
   ```
4. **Publicar** desde `salida/`: 2–4 al día en TikTok y Shorts, programados
   (programador nativo o Metricool). Pon el @ del streamer en la descripción.

> Si un día quieres pagar una sola herramienta que encuentre momentos de gaming en Twitch,
> **Eklipse** (~$20–25/mes) reemplaza el paso 1.
> **Higgsfield** déjalo para cuando hagas contenido propio (efectos/IA generativa).

## Instalación (una vez, Windows)

1. Instala **Python 3.11+** desde python.org (marca "Add Python to PATH").
2. Instala **ffmpeg**: en PowerShell → `winget install Gyan.FFmpeg`
3. En esta carpeta: `pip install -r requirements.txt`

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

Opciones extra: `--lang es` (fija idioma), `--no-subs`, `WHISPER_MODEL=medium` (subtítulos más
precisos, más lento).

## Aviso

Subir clips de otros sin permiso puede generar reclamos de copyright. Da crédito, prioriza
streamers que permiten clips y pídeles permiso cuando puedas.
