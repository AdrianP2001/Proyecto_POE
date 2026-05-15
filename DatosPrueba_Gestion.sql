USE TutoriasDB;
GO

-- Limpieza rápida para pruebas (opcional)
-- DELETE FROM Feedback; DELETE FROM Estudiante_Sesiones; DELETE FROM SesionesTutoria; DELETE FROM Asignaturas; DELETE FROM Tutores; DELETE FROM Estudiantes;

-- 1. Insertar Materias
INSERT INTO Asignaturas (Codigo, Nombre, Facultad)
VALUES 
('PRG201', 'Programación Orientada a Objetos', 'Facultad de Ingeniería'),
('BDD301', 'Bases de Datos I', 'Facultad de Ingeniería'),
('MAT101', 'Cálculo Diferencial', 'Facultad de Ciencias');

-- 2. Insertar Tutores
INSERT INTO Tutores (Nombres, Apellidos, Especialidad)
VALUES 
('Marcos', 'Villacís', 'Desarrollo .NET'),
('Elena', 'Torres', 'Análisis de Datos');

-- 3. Insertar Estudiantes
INSERT INTO Estudiantes (Matricula, Nombres, Apellidos, Email)
VALUES 
('2026001', 'Juan', 'Cevallos', 'juan@ejemplo.com'),
('2026002', 'Ana', 'Pérez', 'ana@ejemplo.com'),
('2026003', 'Luis', 'García', 'luis@ejemplo.com');

-- 4. Insertar Sesiones (Relacionadas)
DECLARE @IdPOO INT = (SELECT IdAsignatura FROM Asignaturas WHERE Codigo = 'PRG201');
DECLARE @IdTutorMarcos INT = (SELECT IdTutor FROM Tutores WHERE Nombres = 'Marcos');

INSERT INTO SesionesTutoria (IdAsignatura, IdTutor, Fecha, HoraInicio, HoraFin, Ubicacion, OrdenSecuencial)
VALUES 
(@IdPOO, @IdTutorMarcos, GETDATE(), '09:00', '11:00', 'Laboratorio 1', 1),
(@IdPOO, @IdTutorMarcos, DATEADD(day, 1, GETDATE()), '14:00', '16:00', 'Aula Virtual', 2);

-- 5. Insertar Asistencias (Simular impacto)
DECLARE @IdSesion1 INT = (SELECT TOP 1 IdSesion FROM SesionesTutoria ORDER BY IdSesion ASC);
DECLARE @IdEst1 INT = (SELECT IdEstudiante FROM Estudiantes WHERE Matricula = '2026001');
DECLARE @IdEst2 INT = (SELECT IdEstudiante FROM Estudiantes WHERE Matricula = '2026002');

INSERT INTO Estudiante_Sesiones (IdEstudiante, IdSesion, Asistencia)
VALUES (@IdEst1, @IdSesion1, 1), (@IdEst2, @IdSesion1, 1);

-- 6. Insertar Feedback
INSERT INTO Feedback (IdEstudiante, IdSesion, Calificacion, Comentarios)
VALUES 
(@IdEst1, @IdSesion1, 5, 'Excelente tutoría, muy clara.'),
(@IdEst2, @IdSesion1, 4, 'Buen material de apoyo.');

PRINT 'Datos de prueba de gestión insertados correctamente.';
GO
