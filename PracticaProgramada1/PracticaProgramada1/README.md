# Practica Programada 1

## Integrantes finales del grupo
- María José Alvarado Fernández
- Angelik Guatemala Camacho
- Javier Méndez Gonzalez
- Keisly Angélica Pasos Solano

## Enlace del repositorio (GitHub)
https://github.com/Alvarado-Majo/Practica_Programada-1/tree/main

## Especificación básica del proyecto

### a. Arquitectura del proyecto
- Estructura en capas:
  - `PracticaProgramada1` — Aplicación web con Razor Pages (TargetFramework: `net10.0`).
  - `Practica.BILL` — Capa de lógica de negocio (Class Library, .NET Framework 4.8).
  - `Practica.DAL` — Capa de acceso a datos (Class Library, .NET Framework 4.8).
- Separación de responsabilidades: UI (Razor Pages), Business (BILL), Data (DAL).
- Archivos estáticos y librerías front-end en `PracticaProgramada1/wwwroot/lib`.

### b. Libraries o paquetes de NuGet utilizados
- No se detectaron `PackageReference` en el `csproj` principal (`PracticaProgramada1.csproj`).
- Librerías front-end incluidas en `wwwroot/lib`:
  - `jquery`
  - `bootstrap`
  - `jquery-validation`
  - `jquery-validation-unobtrusive`
- Las librerías de las capas de clase usan ensamblados del framework (`System`, `System.Core`, etc.) (ver `Practica.BILL.csproj` y `Practica.DAL.csproj`).

### c. Principios de SOLID y patrones de diseño utilizados
- Principios aplicados (a nivel de arquitectura y responsabilidades):
  - SRP (Single Responsibility Principle): cada capa tiene responsabilidades diferenciadas.
  - SoC (Separation of Concerns): UI / Business / Data separadas en proyectos distintos.
  - DIP e IoC consideraciones: diseño orientado a dependencias entre capas (se sugiere usar interfaces para inyección si se extiende).
- Patrones de diseño:
  - Arquitectura por capas (Layered Architecture).
  - Patrón Repository y/o patrón Service (estructura prevista en la `Practica.DAL` y `Practica.BILL`).

Nota: Detalles concretos de implementación (p. ej. interfaces y clases) pueden consultarse en las carpetas `Practica.BILL` y `Practica.DAL`.
