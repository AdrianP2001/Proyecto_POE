USE TutoriasDB;
GO

-- 1. Insertar Asignaturas de Prueba
INSERT INTO Asignaturas (Codigo, Nombre, Activo)
VALUES 
('MAT101', 'Cálculo Diferencial e Integral', 1),
('FIS101', 'Física Moderna y Mecánica', 1),
('PRG201', 'Programación Orientada a Objetos', 1),
('BDD301', 'Sistemas de Bases de Datos', 1);

-- 2. Insertar Tutores de Prueba
INSERT INTO Tutores (Nombres, Apellidos, Especialidad, Activo)
VALUES 
('Ana', 'López', 'Matemáticas y Física', 1),
('Carlos', 'Mendoza', 'Ciencias de la Computación', 1),
('Beatriz', 'Ramírez', 'Ingeniería de Software', 1);

-- 3. Insertar Estudiantes de Prueba
INSERT INTO Estudiantes (Matricula, Nombres, Apellidos, Email, Activo)
VALUES 
('20230001', 'Juan', 'Pérez', 'juan.perez@universidad.edu', 1),
('20230002', 'María', 'Gómez', 'maria.gomez@universidad.edu', 1);

-- 4. Insertar una Sesión de Tutoría (para asociar feedback)
INSERT INTO SesionesTutoria (Fecha, HoraInicio, HoraFin, Ubicacion, OrdenSecuencial, Activo)
VALUES 
(GETDATE(), '10:00', '12:00', 'Laboratorio A1', 1, 1),
(GETDATE(), '14:00', '16:00', 'Aula Virtual Zoom', 2, 1);

-- 5. Insertar Actividades (Tareas)
-- Vinculamos la actividad 1 con Cálculo (Id=1) y la 2 con POE (Id=3)
INSERT INTO Actividades (IdAsignatura, Titulo, Descripcion, FechaPublicacion, FechaVencimiento, Activo)
VALUES 
(1, 'Ejercicios de Derivadas', 'Resolver los 10 ejercicios del libro de Stewart.', GETDATE(), DATEADD(day, 7, GETDATE()), 1),
(3, 'Proyecto Final de C#', 'Desarrollar una aplicación de escritorio con WinForms y SQL Server.', GETDATE(), DATEADD(day, 14, GETDATE()), 1);

-- 6. Insertar Imágenes para la Galería
-- Vinculamos a la actividad 2 (Proyecto Final)
INSERT INTO Galeria (IdActividad, Titulo, RutaLocal, FechaSubida, Activo)
VALUES 
(2, 'Diagrama de Clases', 'ImagenesPrueba\diagrama.png', GETDATE(), 1),
(2, 'Prototipo de Interfaz', 'ImagenesPrueba\prototipo.png', GETDATE(), 1);

PRINT 'Datos de prueba insertados con éxito en el Módulo de Estudiantes.'
GO
