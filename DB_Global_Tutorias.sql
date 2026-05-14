-- PROYECTO FINAL POE 2026 - BASE DE DATOS GLOBAL
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'TutoriasDB')
BEGIN
    CREATE DATABASE TutoriasDB;
END
GO
USE TutoriasDB;
GO

-- =============================================
-- TABLAS BASE (Módulo Sesiones)
-- =============================================
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

-- =============================================
-- MÓDULO ESTUDIANTE
-- =============================================

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Facultades]') AND type in (N'U'))
BEGIN
    CREATE TABLE Facultades (
        IdFacultad INT PRIMARY KEY IDENTITY(1,1),
        Nombre NVARCHAR(100) NOT NULL
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tutores]') AND type in (N'U'))
BEGIN
    CREATE TABLE Tutores (
        IdTutor INT PRIMARY KEY IDENTITY(1,1),
        Nombre NVARCHAR(150) NOT NULL,
        Especialidad NVARCHAR(200),
        FotoPath NVARCHAR(500),
        Email NVARCHAR(200)
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Materias]') AND type in (N'U'))
BEGIN
    CREATE TABLE Materias (
        IdMateria INT PRIMARY KEY IDENTITY(1,1),
        Nombre NVARCHAR(150) NOT NULL,
        Descripcion NVARCHAR(500),
        FotoPath NVARCHAR(500),
        IdFacultad INT FOREIGN KEY REFERENCES Facultades(IdFacultad)
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GruposEstudio]') AND type in (N'U'))
BEGIN
    CREATE TABLE GruposEstudio (
        IdGrupo INT PRIMARY KEY IDENTITY(1,1),
        IdMateria INT FOREIGN KEY REFERENCES Materias(IdMateria),
        Descripcion NVARCHAR(500),
        Cupo INT DEFAULT 20
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GrupoTutores]') AND type in (N'U'))
BEGIN
    CREATE TABLE GrupoTutores (
        IdGrupo INT FOREIGN KEY REFERENCES GruposEstudio(IdGrupo),
        IdTutor INT FOREIGN KEY REFERENCES Tutores(IdTutor),
        PRIMARY KEY (IdGrupo, IdTutor)
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Recursos]') AND type in (N'U'))
BEGIN
    CREATE TABLE Recursos (
        IdRecurso INT PRIMARY KEY IDENTITY(1,1),
        IdGrupo INT FOREIGN KEY REFERENCES GruposEstudio(IdGrupo),
        Descripcion NVARCHAR(300),
        Url NVARCHAR(500)
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HorariosGrupo]') AND type in (N'U'))
BEGIN
    CREATE TABLE HorariosGrupo (
        IdHorario INT PRIMARY KEY IDENTITY(1,1),
        IdGrupo INT FOREIGN KEY REFERENCES GruposEstudio(IdGrupo),
        IdSesion INT FOREIGN KEY REFERENCES SesionesTutoria(IdSesion)
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FotosSesion]') AND type in (N'U'))
BEGIN
    CREATE TABLE FotosSesion (
        IdFoto INT PRIMARY KEY IDENTITY(1,1),
        IdSesion INT FOREIGN KEY REFERENCES SesionesTutoria(IdSesion),
        RutaImagen NVARCHAR(500) NOT NULL,
        Descripcion NVARCHAR(300)
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Comentarios]') AND type in (N'U'))
BEGIN
    CREATE TABLE Comentarios (
        IdComentario INT PRIMARY KEY IDENTITY(1,1),
        NombreEstudiante NVARCHAR(150),
        Comentario NVARCHAR(1000) NOT NULL,
        FechaRegistro DATETIME DEFAULT GETDATE(),
        IdGrupo INT NULL FOREIGN KEY REFERENCES GruposEstudio(IdGrupo)
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VotacionTutor]') AND type in (N'U'))
BEGIN
    CREATE TABLE VotacionTutor (
        IdVoto INT PRIMARY KEY IDENTITY(1,1),
        IdTutor INT FOREIGN KEY REFERENCES Tutores(IdTutor),
        Calificacion TINYINT NOT NULL CHECK (Calificacion BETWEEN 1 AND 5),
        FechaVoto DATETIME DEFAULT GETDATE()
    );
END
GO

-- =============================================
-- DATOS DE PRUEBA
-- =============================================
IF NOT EXISTS (SELECT TOP 1 1 FROM Facultades)
BEGIN
    INSERT INTO Facultades (Nombre) VALUES
        ('Facultad de Ingeniería'),
        ('Facultad de Ciencias de la Educación'),
        ('Facultad de Derecho y Ciencias Sociales');
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM Tutores)
BEGIN
    INSERT INTO Tutores (Nombre, Especialidad, Email, FotoPath) VALUES
        ('Carlos Mendoza', 'Programación Orientada a Objetos', 'cmendoza@universidad.edu.ec', 'Recursos\Fotos\Tutores\tutor1.jpg'),
        ('Ana García', 'Cálculo y Matemáticas', 'agarcia@universidad.edu.ec', 'Recursos\Fotos\Tutores\tutor2.jpg'),
        ('Luis Torres', 'Derecho Constitucional', 'ltorres@universidad.edu.ec', 'Recursos\Fotos\Tutores\tutor3.jpg');
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM Materias)
BEGIN
    INSERT INTO Materias (Nombre, Descripcion, IdFacultad, FotoPath) VALUES
        ('Programación Orientada a Eventos', 'Desarrollo de aplicaciones de escritorio con C# y .NET', 1, 'Recursos\Fotos\Materias\poe.png'),
        ('Cálculo Diferencial', 'Fundamentos del cálculo diferencial e integral para ingeniería', 1, 'Recursos\Fotos\Materias\calculo.png'),
        ('Derecho Constitucional', 'Estudio de la constitución y derechos fundamentales', 3, 'Recursos\Fotos\Materias\derecho.png');
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM GruposEstudio)
BEGIN
    INSERT INTO GruposEstudio (IdMateria, Descripcion, Cupo) VALUES
        (1, 'Grupo A - POE: WinForms y base de datos con C#', 15),
        (1, 'Grupo B - POE: Desarrollo avanzado y patrones de diseño', 12),
        (2, 'Grupo A - Cálculo: Derivadas e integrales aplicadas', 20),
        (3, 'Grupo A - Derecho: Análisis constitucional comparado', 18);
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM GrupoTutores)
BEGIN
    INSERT INTO GrupoTutores (IdGrupo, IdTutor) VALUES
        (1, 1), (2, 1), (3, 2), (4, 3);
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM Recursos)
BEGIN
    INSERT INTO Recursos (IdGrupo, Descripcion, Url) VALUES
        (1, 'Guía oficial WinForms en C#', 'https://docs.microsoft.com/dotnet/desktop/winforms/'),
        (1, 'Ejercicios de POE - Semana 1', 'https://campus.universidad.edu.ec/poe1'),
        (2, 'Patrones de Diseño GoF', 'https://refactoring.guru/design-patterns'),
        (3, 'Khan Academy - Cálculo', 'https://es.khanacademy.org/math/calculus-1'),
        (4, 'Constitución del Ecuador 2008', 'https://www.asambleanacional.gob.ec/constitucion');
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM SesionesTutoria)
BEGIN
    INSERT INTO SesionesTutoria (Fecha, HoraInicio, HoraFin, Ubicacion, OrdenSecuencial) VALUES
        (DATEADD(day, 3, CAST(GETDATE() AS DATE)),  '08:00', '10:00', 'Aula 301 - Bloque A', 1),
        (DATEADD(day, 5, CAST(GETDATE() AS DATE)),  '10:00', '12:00', 'Laboratorio 2 - Sistemas', 2),
        (DATEADD(day, 7, CAST(GETDATE() AS DATE)),  '14:00', '16:00', 'Aula 105 - Bloque B', 3),
        (DATEADD(day, 10, CAST(GETDATE() AS DATE)), '08:00', '10:00', 'Sala Virtual - Teams', 4);
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM HorariosGrupo)
BEGIN
    INSERT INTO HorariosGrupo (IdGrupo, IdSesion) VALUES
        (1, 1), (2, 2), (3, 3), (4, 4);
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM Comentarios)
BEGIN
    INSERT INTO Comentarios (NombreEstudiante, Comentario, IdGrupo) VALUES
        ('María Pérez', 'Excelente metodología de enseñanza. Los ejercicios prácticos son muy útiles.', 1),
        ('Juan Rodríguez', 'Me gustaría que hubiera más sesiones por semana. El tutor explica muy bien.', 1),
        ('Sofia Almeida', 'El material de apoyo es completo. Recomendaría más ejemplos del mundo real.', 3);
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM VotacionTutor)
BEGIN
    INSERT INTO VotacionTutor (IdTutor, Calificacion) VALUES
        (1, 5), (1, 4), (1, 5), (2, 4), (2, 5), (3, 3), (3, 4);
END
GO
