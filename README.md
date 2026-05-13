# Proyecto de Gestión de Tutorías Académicas

Este es el proyecto base para la aplicación de **Gestión de Red de Tutorías Académicas y Recursos Estudiantiles**.

## Estructura del Proyecto (Arquitectura en 3 Capas)

- **TutoriasApp.Entidades**: Contiene las clases POCO (Plain Old CLR Objects) que representan los modelos de datos.
- **TutoriasApp.Datos**: Capa encargada de la persistencia de datos y comunicación con SQL Server.
- **TutoriasApp.Negocio**: Contiene la lógica de negocio, validaciones y reglas del sistema.
- **TutoriasApp.Presentacion**: Interfaz de usuario desarrollada en Windows Forms.

## Configuración Inicial

1. Ejecutar el script SQL ubicado en `TutoriasDB.sql` en su instancia local de SQL Server.
2. Abrir la solución `TutoriasApp.sln` en Visual Studio.
3. Actualizar la cadena de conexión en el archivo `App.config` si es necesario.

## Módulo: Gestión de Horarios y Sesiones (Líder)

Este módulo permite:
- Registrar el cronograma de tutorías.
- Validar automáticamente cruces de horarios y aulas.
- Gestionar el orden secuencial de las sesiones programadas.
