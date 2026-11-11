"""
IA con Claude: títulos-gancho, descripciones y guiones de guías en español.

Requiere la variable de entorno ANTHROPIC_API_KEY (o `ant auth login`).
Si no hay credenciales, las funciones devuelven None y el resto del flujo sigue
funcionando con plantillas.
"""
import json
import os

MODEL = os.environ.get("CLAUDE_MODEL", "claude-opus-5-5")

ESTILO = """Eres el editor de un canal hispano de clips y guías de GTA 6 (salió el 19 nov 2026)
para TikTok y YouTube Shorts. Reglas:
- Ganchos de 40-60 caracteres, MAYÚSCULAS, que incluyan "GTA 6", que generen curiosidad
  sin mentir sobre lo que pasa en el clip.
- Español neutro (que entienda España y LATAM).
- Nunca spoilers del final de la historia ni filtraciones.
- Máximo 5 hashtags, siempre #gta6."""


def _client():
    try:
        import anthropic
        return anthropic.Anthropic()
    except Exception:
        return None


def _json_call(prompt: str, schema: dict, effort="medium", max_tokens=16000):
    """Llamada con salida JSON garantizada por esquema. Devuelve dict o None."""
    client = _client()
    if client is None:
        return None
    try:
        resp = client.beta.messages.create(
            model=MODEL,
            max_tokens=max_tokens,
            betas=["server-side-fallback-2026-07-01"],
            fallbacks="default",  # si el modelo rechaza, otro modelo responde
            system=ESTILO,
            output_config={"effort": effort,
                           "format": {"type": "json_schema", "schema": schema}},
            messages=[{"role": "user", "content": prompt}],
        )
    except Exception as e:  # sin clave, sin red, límite de uso...
        print(f"  (IA no disponible: {type(e).__name__}) → uso plantilla")
        return None
    if resp.stop_reason == "refusal":
        print("  (IA rechazó la petición) → uso plantilla")
        return None
    text = next((b.text for b in resp.content if b.type == "text"), "")
    try:
        return json.loads(text)
    except json.JSONDecodeError:
        return None


def _obj(props: dict) -> dict:
    return {"type": "object", "properties": props,
            "required": list(props), "additionalProperties": False}


STR = {"type": "string"}
STRS = {"type": "array", "items": STR}


def gancho_clip(transcripcion: str, streamer: str = "", chat: str = ""):
    """Título-gancho + metadatos para un clip. Devuelve dict o None."""
    schema = _obj({
        "titulo_gancho": STR,        # texto en pantalla
        "descripcion_tiktok": STR,   # frase con palabra clave al inicio
        "titulo_short": STR,         # <= 60 caracteres
        "hashtags": STRS,            # 3-5, con #
        "spoiler": {"type": "boolean"},
    })
    prompt = (f"Clip de {streamer or 'un streamer'} jugando GTA 6.\n"
              f"Lo que se dice en el clip:\n\"\"\"{transcripcion[:3000]}\"\"\"\n"
              f"Reacción del chat: {chat or '(sin datos)'}\n\n"
              "Escribe el título-gancho para poner en pantalla, la descripción de TikTok, "
              "el título del Short y los hashtags. Marca spoiler=true si revela el final "
              "de la historia o misiones finales.")
    return _json_call(prompt, schema, effort="low", max_tokens=4000)


def guion_guia(tema: str, notas: str = "", minutos: float = 4.0):
    """Guion de una guía en video (voz en off). Devuelve dict o None."""
    seccion = _obj({"titulo": STR, "texto_voz": STR, "texto_pantalla": STR})
    schema = _obj({
        "titulo_youtube": STR,
        "miniatura_texto": STR,
        "gancho_voz": STR,
        "secciones": {"type": "array", "items": seccion},
        "cierre_voz": STR,
        "descripcion_youtube": STR,
        "hashtags": STRS,
        "short_gancho": STR,
        "short_texto_voz": STR,
    })
    palabras = int(minutos * 150)
    prompt = (f"Escribe el guion de una guía de YouTube sobre: {tema}\n"
              f"Duración objetivo: ~{minutos} minutos (~{palabras} palabras de voz en total).\n"
              f"Información verificada que puedes usar (no inventes datos fuera de esto):\n"
              f"\"\"\"{notas or '(sin notas: mantente en consejos generales y verificables)'}\"\"\"\n\n"
              "Estructura: gancho de 1-2 frases que prometa el resultado; 3-7 secciones "
              "concretas (cada una con texto para la voz IA y un texto corto para pantalla); "
              "cierre que pida seguir el canal. Frases cortas, ritmo rápido, sin relleno. "
              "Incluye también una versión Short de 30-45 s (gancho + texto de voz).")
    return _json_call(prompt, schema, effort="medium")
