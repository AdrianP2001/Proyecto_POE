-- Script de Base de Datos para Gestión de Tutorías
CREATE DATABASE TutoriasDB;
GO
USE TutoriasDB;
GO

CREATE TABLE SesionesTutoria (
    IdSesion INT PRIMARY KEY IDENTITY(1,1),
    Fecha DATE NOT NULL,
    HoraInicio TIME NOT NULL,
    HoraFin TIME NOT NULL,
    Ubicacion NVARCHAR(255) NOT NULL,
    OrdenSecuencial INT NOT NULL,
    Activo BIT DEFAULT 1
);
GO

CREATE INDEX IX_Sesiones_Fecha_Ubicacion ON SesionesTutoria (Fecha, Ubicacion);
GO
