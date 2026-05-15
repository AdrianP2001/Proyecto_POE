USE TutoriasDB;
GO

-- 1. Insertar Materias
INSERT INTO Asignaturas (Codigo, Nombre, Facultad)
VALUES 
('PRG201', 'Programacion Orientada a Objetos', 'Facultad de Ingenieria'),
('BDD301', 'Bases de Datos I', 'Facultad de Ingenieria'),
('MAT101', 'Calculo Diferencial', 'Facultad de Ciencias');

-- 2. Insertar Tutores
INSERT INTO Tutores (Nombres, Apellidos, Especialidad)
VALUES 
('Marcos', 'Villacis', 'Desarrollo .NET'),
('Elena', 'Torres', 'Analisis de Datos');

-- 3. Insertar Estudiantes
INSERT INTO Estudiantes (Matricula, Nombres, Apellidos, Email)
VALUES 
('2026001', 'Juan', 'Cevallos', 'juan@ejemplo.com'),
('2026002', 'Ana', 'Perez', 'ana@ejemplo.com'),
('2026003', 'Luis', 'Garcia', 'luis@ejemplo.com');

-- 4. Insertar Sesiones (Relacionadas)
DECLARE @IdPOO INT = (SELECT IdAsignatura FROM Asignaturas WHERE Codigo = 'PRG201');
DECLARE @IdTutorMarcos INT = (SELECT IdTutor FROM Tutores WHERE Nombres = 'Marcos');

INSERT INTO SesionesTutoria (IdAsignatura, IdTutor, Fecha, HoraInicio, HoraFin, Ubicacion, OrdenSecuencial)
VALUES 
(@IdPOO, @IdTutorMarcos, GETDATE(), '09:00', '11:00', 'Laboratorio 1', 1),
(@IdPOO, @IdTutorMarcos, DATEADD(day, 1, GETDATE()), '14:00', '16:00', 'Aula Virtual', 2);

-- 5. Insertar Asistencias
DECLARE @IdSesion1 INT = (SELECT TOP 1 IdSesion FROM SesionesTutoria ORDER BY IdSesion ASC);
DECLARE @IdEst1 INT = (SELECT IdEstudiante FROM Estudiantes WHERE Matricula = '2026001');
DECLARE @IdEst2 INT = (SELECT IdEstudiante FROM Estudiantes WHERE Matricula = '2026002');

INSERT INTO Estudiante_Sesiones (IdEstudiante, IdSesion, Asistencia)
VALUES (@IdEst1, @IdSesion1, 1), (@IdEst2, @IdSesion1, 1);

-- 6. Insertar Feedback
INSERT INTO Feedback (IdEstudiante, IdSesion, Calificacion, Comentarios)
VALUES 
(@IdEst1, @IdSesion1, 5, 'Excelente tutoria, muy clara.'),
(@IdEst2, @IdSesion1, 4, 'Buen material de apoyo.');

PRINT 'Datos de prueba de gestion insertados correctamente.';
GO
