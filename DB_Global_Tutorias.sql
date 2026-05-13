-- PROYECTO FINAL POE 2026 - BASE DE DATOS GLOBAL
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'TutoriasDB')
BEGIN
    CREATE DATABASE TutoriasDB;
END
GO
USE TutoriasDB;
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SesionesTutoria]') AND type in (N'U'))
BEGIN
    CREATE TABLE SesionesTutoria (
        IdSesion INT PRIMARY KEY IDENTITY(1,1),
        Fecha DATE NOT NULL,
        HoraInicio TIME NOT NULL,
        HoraFin TIME NOT NULL,
        Ubicacion NVARCHAR(255) NOT NULL,
        OrdenSecuencial INT NOT NULL,
        Activo BIT DEFAULT 1
    );
    CREATE INDEX IX_Sesiones_Fecha_Ubicacion ON SesionesTutoria (Fecha, Ubicacion);
END
GO
