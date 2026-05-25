USE TutoriasDB;
GO

-- Limpiar tablas existentes en orden de dependencia para evitar conflictos de claves foráneas
DELETE FROM Feedback;
DELETE FROM Estudiante_Sesiones;
DELETE FROM Galeria;
DELETE FROM Actividades;
DELETE FROM SesionesTutoria;
DELETE FROM Estudiantes;
DELETE FROM Tutores;
DELETE FROM Asignaturas;

-- Reiniciar contadores de identidad
DBCC CHECKIDENT ('Feedback', RESEED, 0);
DBCC CHECKIDENT ('Estudiante_Sesiones', RESEED, 0);
DBCC CHECKIDENT ('Galeria', RESEED, 0);
DBCC CHECKIDENT ('Actividades', RESEED, 0);
DBCC CHECKIDENT ('SesionesTutoria', RESEED, 0);
DBCC CHECKIDENT ('Estudiantes', RESEED, 0);
DBCC CHECKIDENT ('Tutores', RESEED, 0);
DBCC CHECKIDENT ('Asignaturas', RESEED, 0);

-- 1. Insertar Asignaturas de Prueba
INSERT INTO Asignaturas (Codigo, Nombre, Facultad, Area, Descripcion, Modalidad, Activo)
VALUES 
('MAT101', N'Cálculo Diferencial e Integral', N'Facultad de Matemáticas y Física', N'Exactas', N'Curso introductorio al análisis matemático, límites, derivadas e integrales.', N'Presencial', 1),
('FIS101', N'Física Moderna y Mecánica', N'Facultad de Matemáticas y Física', N'Exactas', N'Estudio del movimiento, leyes de Newton, energía y conceptos básicos de relatividad.', N'Presencial', 1),
('PRG201', N'Programación Orientada a Objetos', N'Facultad de Ingeniería', N'Ingeniería', N'Diseño e implementación de software usando clases, herencia, polimorfismo y C#.', N'Virtual', 1),
('BDD301', N'Sistemas de Bases de Datos', N'Facultad de Ingeniería', N'Ingeniería', N'Fundamentos de bases de datos relacionales, lenguaje SQL y modelado entidad-relación.', N'Virtual', 1);

-- 2. Insertar Tutores de Prueba
INSERT INTO Tutores (Nombres, Apellidos, Especialidad, Activo)
VALUES 
(N'Ana', N'López', N'Matemáticas y Física', 1),
(N'Carlos', N'Mendoza', N'Ciencias de la Computación', 1),
(N'Beatriz', N'Ramírez', N'Ingeniería de Software', 1);

-- 3. Insertar Estudiantes de Prueba
INSERT INTO Estudiantes (Matricula, Nombres, Apellidos, Email, Activo)
VALUES 
('20230001', N'Juan', N'Pérez', 'juan.perez@universidad.edu', 1),
('20230002', N'María', N'Gómez', 'maria.gomez@universidad.edu', 1);

-- Variables locales para vincular relaciones de forma dinámica
DECLARE @IdCalculo INT = (SELECT TOP 1 IdAsignatura FROM Asignaturas WHERE Codigo = 'MAT101');
DECLARE @IdFisica INT = (SELECT TOP 1 IdAsignatura FROM Asignaturas WHERE Codigo = 'FIS101');
DECLARE @IdPOE INT = (SELECT TOP 1 IdAsignatura FROM Asignaturas WHERE Codigo = 'PRG201');
DECLARE @IdBases INT = (SELECT TOP 1 IdAsignatura FROM Asignaturas WHERE Codigo = 'BDD301');

DECLARE @IdTutorAna INT = (SELECT TOP 1 IdTutor FROM Tutores WHERE Nombres = N'Ana');
DECLARE @IdTutorCarlos INT = (SELECT TOP 1 IdTutor FROM Tutores WHERE Nombres = N'Carlos');
DECLARE @IdTutorBeatriz INT = (SELECT TOP 1 IdTutor FROM Tutores WHERE Nombres = N'Beatriz');

-- 4. Insertar Sesiones de Tutoría relacionadas con Materia y Tutor
INSERT INTO SesionesTutoria (IdAsignatura, IdTutor, Fecha, HoraInicio, HoraFin, Ubicacion, OrdenSecuencial, Activo)
VALUES 
(@IdCalculo, @IdTutorAna, GETDATE(), '10:00:00', '12:00:00', N'Laboratorio A1', 1, 1),
(@IdPOE, @IdTutorCarlos, GETDATE(), '14:00:00', '16:00:00', N'Aula Virtual Zoom', 2, 1),
(@IdFisica, @IdTutorAna, DATEADD(day, 1, GETDATE()), '11:00:00', '13:00:00', N'Laboratorio A2', 3, 1),
(@IdBases, @IdTutorBeatriz, DATEADD(day, 1, GETDATE()), '15:00:00', '17:00:00', N'Aula Virtual Teams', 4, 1);

-- 5. Insertar Actividades (Tareas/Entregables)
INSERT INTO Actividades (IdAsignatura, Titulo, Descripcion, FechaPublicacion, FechaVencimiento, Activo)
VALUES 
(@IdCalculo, N'Ejercicios de Derivadas', N'Resolver los 10 ejercicios del libro de Stewart del capítulo 3.', GETDATE(), DATEADD(day, 7, GETDATE()), 1),
(@IdPOE, N'Proyecto Final de C#', N'Desarrollar una aplicación de escritorio con WinForms y SQL Server.', GETDATE(), DATEADD(day, 14, GETDATE()), 1),
(@IdFisica, N'Informe de Laboratorio', N'Redactar el reporte de la práctica de cinemática.', GETDATE(), DATEADD(day, 5, GETDATE()), 1);

-- 6. Insertar Imágenes para la Galería (vinculadas a actividades reales)
DECLARE @IdActividadPOE INT = (SELECT TOP 1 IdActividad FROM Actividades WHERE Titulo = N'Proyecto Final de C#');
DECLARE @IdActividadCalculo INT = (SELECT TOP 1 IdActividad FROM Actividades WHERE Titulo = N'Ejercicios de Derivadas');

INSERT INTO Galeria (IdActividad, Titulo, RutaLocal, FechaSubida, Activo)
VALUES 
(@IdActividadPOE, N'Diagrama de Clases', 'ImagenesPrueba\diagrama.png', GETDATE(), 1),
(@IdActividadPOE, N'Prototipo de Interfaz', 'ImagenesPrueba\prototipo.png', GETDATE(), 1),
(@IdActividadCalculo, N'Pizarra de Derivadas', 'ImagenesPrueba\pizarra.png', GETDATE(), 1);

-- 7. Insertar Feedback de Prueba Inicial
DECLARE @IdEstJuan INT = (SELECT TOP 1 IdEstudiante FROM Estudiantes WHERE Matricula = '20230001');
DECLARE @IdEstMaria INT = (SELECT TOP 1 IdEstudiante FROM Estudiantes WHERE Matricula = '20230002');
DECLARE @IdSesion1 INT = (SELECT TOP 1 IdSesion FROM SesionesTutoria WHERE IdAsignatura = @IdCalculo);
DECLARE @IdSesion2 INT = (SELECT TOP 1 IdSesion FROM SesionesTutoria WHERE IdAsignatura = @IdPOE);

INSERT INTO Feedback (IdEstudiante, IdSesion, Calificacion, Comentarios, FechaRegistro, Activo)
VALUES 
(@IdEstJuan, @IdSesion1, 5, N'Excelente sesión, la tutora explica muy claro los límites.', GETDATE(), 1),
(@IdEstMaria, @IdSesion2, 4, N'Buena explicación práctica del patrón MVC en WinForms.', GETDATE(), 1);

PRINT 'Datos de prueba actualizados e insertados correctamente con acentos y caracteres especiales.';
GO
