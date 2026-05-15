-- SCRIPT DE DEPURACIÓN Y REPARACIÓN DE BASE DE DATOS
USE TutoriasDB;
GO

PRINT '--- Iniciando Depuración de Esquema ---'

-- 1. Verificar y Corregir tabla SesionesTutoria (Relaciones faltantes)
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('SesionesTutoria') AND name = 'IdAsignatura')
BEGIN
    PRINT 'Añadiendo IdAsignatura a SesionesTutoria...';
    ALTER TABLE SesionesTutoria ADD IdAsignatura INT NULL FOREIGN KEY REFERENCES Asignaturas(IdAsignatura);
END

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('SesionesTutoria') AND name = 'IdTutor')
BEGIN
    PRINT 'Añadiendo IdTutor a SesionesTutoria...';
    ALTER TABLE SesionesTutoria ADD IdTutor INT NULL FOREIGN KEY REFERENCES Tutores(IdTutor);
END

-- 2. Verificar y Corregir tabla Asignaturas (Campos del PDF)
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Asignaturas') AND name = 'Facultad')
BEGIN
    PRINT 'Añadiendo Facultad a Asignaturas...';
    ALTER TABLE Asignaturas ADD Facultad NVARCHAR(255) DEFAULT 'Facultad de Matemáticas y Física';
END

-- 3. Limpieza de datos huérfanos (opcional pero recomendado para debug)
-- DELETE FROM SesionesTutoria WHERE IdAsignatura IS NULL;

PRINT '--- Depuración Completada Exitosamente ---'
GO
