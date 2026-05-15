-- PROYECTO FINAL POE 2026 - BASE DE DATOS GLOBAL UNIFICADA
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'TutoriasDB')
BEGIN
    CREATE DATABASE TutoriasDB;
END
GO
USE TutoriasDB;
GO

-- 1. Tabla de Asignaturas (Materias)
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Asignaturas]') AND type in (N'U'))
BEGIN
    CREATE TABLE Asignaturas (
        IdAsignatura INT PRIMARY KEY IDENTITY(1,1),
        Codigo NVARCHAR(50) NOT NULL UNIQUE,
        Nombre NVARCHAR(255) NOT NULL,
        Facultad NVARCHAR(255) DEFAULT 'Facultad de Matemáticas y Física',
        Activo BIT DEFAULT 1
    );
END
GO

-- 2. Tabla de Tutores
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tutores]') AND type in (N'U'))
BEGIN
    CREATE TABLE Tutores (
        IdTutor INT PRIMARY KEY IDENTITY(1,1),
        Nombres NVARCHAR(100) NOT NULL,
        Apellidos NVARCHAR(100) NOT NULL,
        Especialidad NVARCHAR(255) NOT NULL,
        FotoRuta NVARCHAR(MAX) NULL,
        Activo BIT DEFAULT 1
    );
END
GO

-- 3. Tabla de Estudiantes
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Estudiantes]') AND type in (N'U'))
BEGIN
    CREATE TABLE Estudiantes (
        IdEstudiante INT PRIMARY KEY IDENTITY(1,1),
        Matricula NVARCHAR(50) NOT NULL UNIQUE,
        Nombres NVARCHAR(100) NOT NULL,
        Apellidos NVARCHAR(100) NOT NULL,
        Email NVARCHAR(255) NULL,
        Activo BIT DEFAULT 1
    );
END
GO

-- 4. Tabla de Sesiones de Tutoría (Relacionada con Materia y Tutor)
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SesionesTutoria]') AND type in (N'U'))
BEGIN
    CREATE TABLE SesionesTutoria (
        IdSesion INT PRIMARY KEY IDENTITY(1,1),
        IdAsignatura INT NULL FOREIGN KEY REFERENCES Asignaturas(IdAsignatura),
        IdTutor INT NULL FOREIGN KEY REFERENCES Tutores(IdTutor),
        Fecha DATE NOT NULL,
        HoraInicio TIME NOT NULL,
        HoraFin TIME NOT NULL,
        Ubicacion NVARCHAR(255) NOT NULL,
        OrdenSecuencial INT NOT NULL,
        Activo BIT DEFAULT 1
    );
    CREATE INDEX IX_Sesiones_Fecha_Ubicacion ON SesionesTutoria (Fecha, Ubicacion);
END
ELSE
BEGIN
    -- Reparación para tablas existentes
    IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('SesionesTutoria') AND name = 'IdAsignatura')
        ALTER TABLE SesionesTutoria ADD IdAsignatura INT NULL FOREIGN KEY REFERENCES Asignaturas(IdAsignatura);
    
    IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('SesionesTutoria') AND name = 'IdTutor')
        ALTER TABLE SesionesTutoria ADD IdTutor INT NULL FOREIGN KEY REFERENCES Tutores(IdTutor);
END
GO

-- 5. Tabla de Inscripciones / Asistencia
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Estudiante_Sesiones]') AND type in (N'U'))
BEGIN
    CREATE TABLE Estudiante_Sesiones (
        IdInscripcion INT PRIMARY KEY IDENTITY(1,1),
        IdEstudiante INT NOT NULL FOREIGN KEY REFERENCES Estudiantes(IdEstudiante),
        IdSesion INT NOT NULL FOREIGN KEY REFERENCES SesionesTutoria(IdSesion),
        Asistencia BIT DEFAULT 0,
        Activo BIT DEFAULT 1
    );
END
GO

-- 6. Tabla de Feedback (Calificaciones)
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Feedback]') AND type in (N'U'))
BEGIN
    CREATE TABLE Feedback (
        IdFeedback INT PRIMARY KEY IDENTITY(1,1),
        IdEstudiante INT NOT NULL FOREIGN KEY REFERENCES Estudiantes(IdEstudiante),
        IdSesion INT NOT NULL FOREIGN KEY REFERENCES SesionesTutoria(IdSesion),
        Calificacion INT NOT NULL CHECK (Calificacion >= 1 AND Calificacion <= 5),
        Comentarios NVARCHAR(MAX) NULL,
        FechaRegistro DATETIME DEFAULT GETDATE(),
        Activo BIT DEFAULT 1
    );
END
GO

-- Se han consolidado las definiciones de tabla arriba para evitar duplicidad.

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Actividades]') AND type in (N'U'))
BEGIN
    CREATE TABLE Actividades (
        IdActividad INT PRIMARY KEY IDENTITY(1,1),
        IdAsignatura INT NULL FOREIGN KEY REFERENCES Asignaturas(IdAsignatura),
        Titulo NVARCHAR(255) NOT NULL,
        Descripcion NVARCHAR(MAX) NULL,
        FechaPublicacion DATETIME DEFAULT GETDATE(),
        FechaVencimiento DATETIME NULL,
        Activo BIT DEFAULT 1
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Galeria]') AND type in (N'U'))
BEGIN
    CREATE TABLE Galeria (
        IdImagen INT PRIMARY KEY IDENTITY(1,1),
        IdActividad INT NULL FOREIGN KEY REFERENCES Actividades(IdActividad),
        Titulo NVARCHAR(255) NULL,
        RutaLocal NVARCHAR(MAX) NOT NULL,
        FechaSubida DATETIME DEFAULT GETDATE(),
        Activo BIT DEFAULT 1
    );
END
GO
