# Proyecto FINAL: Gestión de Red de Tutorías Académicas 🎓

[![.NET 8.0](https://img.shields.io/badge/.NET-8.0-512bd4?logo=dotnet)](https://dotnet.microsoft.com/download)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-2022-red?logo=microsoft-sql-server)](https://www.microsoft.com/sql-server)
[![MVC Architecture](https://img.shields.io/badge/Architecture-MVC%20/%203--Layer-blue)](#arquitectura)

## 📝 Descripción del Proyecto
Este sistema es una solución integral desarrollada en **C# con WinForms**, diseñada para optimizar la gestión de tutorías académicas y recursos para estudiantes. Sigue un enfoque de **Programación Orientada a Objetos (POO)** y una arquitectura de **3 capas**, garantizando modularidad, escalabilidad y facilidad de mantenimiento.

El proyecto permite a los administradores gestionar el cronograma de tutorías y a los estudiantes acceder a recursos, consultar horarios y proporcionar feedback sobre el desempeño de los tutores.

---

## 🏗️ Arquitectura
El proyecto está organizado bajo el patrón de **3 Capas (N-Tier)**, lo que separa las responsabilidades y facilita el trabajo en equipo a través de GitHub:

- **Capa de Presentación (`Presentacion/`):** Interfaces gráficas de usuario (Forms) y validaciones de entrada.
- **Capa de Negocio (`Negocio/`):** Lógica de orquestación, validaciones de cruces de horarios y reglas del sistema.
- **Capa de Datos (`Datos/`):** Acceso directo a SQL Server, manejo de conexiones y ejecución de procedimientos/queries.
- **Capa de Entidades (`Entidades/`):** Modelos de datos compartidos entre todas las capas.

---

## 🚀 Funcionalidades Principales

### 👨‍💼 Módulo Administrador
- **Gestión de Materias:** Registro de células de estudio, facultades y áreas académicas.
- **Registro de Tutores:** Gestión de perfiles con especialidades y fotografía.
- **Gestión de Horarios y Sesiones:** Control total sobre el cronograma (aula, fecha, hora) y orden secuencial automático.
- **Reportes:** Exportación de informes de gestión en formato **PDF**.

### 🎓 Módulo Estudiante
- **Consulta de Tutorías:** Buscador de materias y detalle de tutores/horarios.
- **Calendario Activo:** Visualización de la agenda filtrada por facultades.
- **Interacción:** Sistema de feedback, comentarios y galería de fotos de sesiones realizadas.

---

## 🛠️ Instalación y Configuración

1. **Clonar el repositorio:**
   ```bash
   git clone https://github.com/AdrianP2001/Proyecto_POE.git
   ```
2. **Base de Datos:**
   - Abre SQL Server Management Studio.
   - Ejecuta el archivo `DB_Global_Tutorias.sql` para crear el esquema.
   - (Opcional) Ejecuta `DatosDePrueba_Estudiante.sql` para cargar información inicial.
3. **Configuración de Conexión:**
   - Abre `App.config` en Visual Studio.
   - Ajusta el `Data Source` a tu instancia local (ej. `.` o `.\SQLEXPRESS`).
4. **Ejecutar:**
   - Abre `Proyecto_POE.sln` y presiona `F5`.

---

## 📚 Documentación Detallada

Para cumplir con los entregables del proyecto, hemos creado una sección específica con:
- [Diagramas de Clases y Casos de Uso](DOCUMENTACION.md#documentación-uml)
- [Especificación de Casos de Uso](DOCUMENTACION.md#casos-de-uso)
- [Escenarios de Prueba](DOCUMENTACION.md#escenarios)
- [Manual de Usuario](DOCUMENTACION.md#manual-de-usuario)

---

## 👥 Equipo de Trabajo
*Proyecto desarrollado para la asignatura de Programación Orientada a Eventos.*

- **Líder de Proyecto (Master):** [Tu Nombre/Usuario]
- **Colaboradores:** Emanuel, Adrian, [Otros nombres].

---
*© 2026 - Facultad de Matemáticas y Física*
