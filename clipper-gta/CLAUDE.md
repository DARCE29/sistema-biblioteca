# Fábrica de contenido GTA 6

Proyecto para ganar dinero con contenido de GTA 6 (salió el 19 nov 2026): clips de streamers,
compilaciones y guías con voz IA para TikTok y YouTube Shorts, en español.

## Forma de trabajar (obligatorio)

- Responde **corto y preciso**, en español.
- **Antes de construir algo nuevo, da 2–3 opciones con una recomendación y espera a que el usuario elija.**
- Al terminar cada paso, di qué debe probar el usuario y qué resultado esperar.
- El usuario decide, prueba y publica; Claude construye, investiga, ejecuta y ajusta.
- Este proyecto vive aparte del trabajo del usuario (su proyecto de biblioteca): no mezclarlos.

## Qué hay

| Archivo | Qué hace |
|---|---|
| `fabrica.py` | Orquestador: `vod` (stream → clips), `compilacion` (clips → video >60 s), `guia` (tema → video largo + Short con voz IA) |
| `momentos.py` | Picos del chat de Twitch (JSON de TwitchDownloaderCLI) → `clips.csv` |
| `clipper.py` | Momento → vertical 9:16: quita silencios, zoom/SFX en picos, subtítulos karaoke, −14 LUFS, gancho, crédito, `.txt` con descripción |
| `ia.py` | Claude (`claude-opus-5-5`): ganchos, metadatos y guiones (JSON). Sin `ANTHROPIC_API_KEY` usa plantillas |
| `voz.py` | Voz IA gratis con edge-tts (`VOZ=es-MX-JorgeNeural` por defecto) |
| `guia.py` | Guion → voz → b-roll con cortes cada 3–5 s → subtítulos → 16:9 + 9:16 |
| `reports/Estrategias virales clips GTA 6.md` | Investigación completa: ganchos, edición, algoritmos, monetización, herramientas |
| `research_notes/` | Notas fuente de la investigación |

Salidas en `cola/<fecha>_<nombre>/` (ignorada por git).

## Estado

- Todo probado solo con video/voz/IA **simulados** en la nube. **Falta la primera prueba real en el PC**:
  instalar Python 3.11+, ffmpeg (`winget install Gyan.FFmpeg`), `pip install -r requirements.txt`,
  TwitchDownloaderCLI, y opcional `ANTHROPIC_API_KEY`.
- Pendiente conocido: en `--batch` el nombre del archivo se decide antes del gancho IA (salen como `001_clip.mp4`).

## Estrategia acordada (resumen del informe)

- Las vistas de TikTok/Shorts pagan casi nada (Shorts ~$0,02–0,17/1K; Creator Rewards no está en España, en LATAM solo México).
- **El dinero real: campañas de clipping** (Content Rewards de Whop, ~$1–2/1K vistas; hay campañas en español).
  Redes de GTA 6: GTA Clipper (Discord 20K+), RUCKUS (gta6clipping.com). Pago real medio ~$0,39/1K: volumen constante, no virales sueltos.
- **Jugada grande:** red de clipping en español (vender campañas a streamers hispanos y servidores RP, comisión 10–20%).
- Después: guías largas en YouTube (pagan más) y contenido propio.
- Evitar: spoilers del final, filtraciones, vender cuentas/dinero del juego, bots de vistas.
- GTA 6 salió solo en consola y solo modo historia: no hay online, mods ni RP todavía.

## Opciones pendientes que el usuario aún no eligió

1. Primera prueba real guiada en el PC (recomendada).
2. Tablero de control (plan, tareas, campañas, métricas por clip).
3. Kit de venta a streamers + estructura del Discord de la red de clipping.
