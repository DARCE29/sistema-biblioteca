"""
Voz IA gratis con edge-tts (voces neuronales de Microsoft).

Voces recomendadas (cámbiala con la variable de entorno VOZ):
  es-MX-JorgeNeural   (hombre, LATAM)   ← por defecto
  es-MX-DaliaNeural   (mujer, LATAM)
  es-ES-AlvaroNeural  (hombre, España)
  es-ES-ElviraNeural  (mujer, España)
Lista completa:  edge-tts --list-voices | grep es-
"""
import os
from pathlib import Path

VOZ = os.environ.get("VOZ", "es-MX-JorgeNeural")
RITMO = os.environ.get("VOZ_RITMO", "+12%")  # un poco más rápido = más retención


def hablar(texto: str, salida: Path, voz: str = None, ritmo: str = None) -> Path:
    import edge_tts
    salida = Path(salida)
    salida.parent.mkdir(parents=True, exist_ok=True)
    edge_tts.Communicate(texto, voz or VOZ, rate=ritmo or RITMO).save_sync(str(salida))
    return salida
