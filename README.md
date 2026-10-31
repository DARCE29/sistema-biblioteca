# Sistema de gestión de biblioteca

Aplicación de escritorio en C# con Windows Forms (.NET Framework 4.7.2). La hicimos en equipo para el curso de Programación Orientada a Objetos de la Universidad Latina de Costa Rica, en 2025.

## Qué hace

- Inicio de sesión y creación de usuarios de tres tipos: estudiante, profesor y administrativo
- Catálogo de libros con búsqueda por título, autor, categoría y disponibilidad
- Préstamos, con un límite de 5 libros para profesores y 3 para los demás usuarios
- Reportes

## Cómo correrlo

1. Abrir `Proyecto2025POO.sln` en Visual Studio.
2. Ejecutar con F5.

Los datos se guardan en archivos de texto (`usuarios.txt`, `libros.txt` y `prestamos.txt`) en la misma carpeta del ejecutable. Si no existen, se crean al guardar el primer registro.

Para crear usuarios profesor o administrativo, el programa pide un código de autorización que está en `Crear Usuario.cs`.
