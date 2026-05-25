using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Proyecto_POE.Datos
{
    public class ConexionBD
    {
        // Se recomienda usar App.config para la cadena de conexión.
        // Es estática para que todas las instancias de DAO compartan la conexión que resulte exitosa tras la inicialización.
        private static string cadenaConexion = ConfigurationManager.ConnectionStrings["TutoriaConn"]?.ConnectionString 
                                                ?? "Data Source=.;Initial Catalog=TutoriasDB;Integrated Security=True;TrustServerCertificate=True";

        public SqlConnection LeerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }

        public void InicializarBaseDeDatos()
        {
            List<string> connectionStringsToTry = new List<string> { cadenaConexion };

            // Cadenas de conexión de respaldo (fallbacks) comunes
            string fallbackLocalDB = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;TrustServerCertificate=True";
            string fallbackSQLExpress = "Data Source=.\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;TrustServerCertificate=True";

            // Intentamos agregar los fallbacks sin duplicar
            if (!connectionStringsToTry.Contains(fallbackLocalDB))
                connectionStringsToTry.Add(fallbackLocalDB);
            if (!connectionStringsToTry.Contains(fallbackSQLExpress))
                connectionStringsToTry.Add(fallbackSQLExpress);

            Exception lastException = null;
            bool success = false;
            string successfulString = "";

            foreach (var connString in connectionStringsToTry)
            {
                try
                {
                    string masterConnectionString = connString;
                    
                    // Modificamos a base de datos master para poder crear la DB si no existe
                    if (masterConnectionString.Contains("Initial Catalog="))
                    {
                        var parts = masterConnectionString.Split(';');
                        for (int i = 0; i < parts.Length; i++)
                        {
                            if (parts[i].Trim().StartsWith("Initial Catalog", StringComparison.OrdinalIgnoreCase))
                            {
                                parts[i] = "Initial Catalog=master";
                            }
                        }
                        masterConnectionString = string.Join(";", parts);
                    }
                    else if (masterConnectionString.Contains("Database="))
                    {
                        var parts = masterConnectionString.Split(';');
                        for (int i = 0; i < parts.Length; i++)
                        {
                            if (parts[i].Trim().StartsWith("Database", StringComparison.OrdinalIgnoreCase))
                            {
                                parts[i] = "Database=master";
                            }
                        }
                        masterConnectionString = string.Join(";", parts);
                    }

                    using (SqlConnection conn = new SqlConnection(masterConnectionString))
                    {
                        conn.Open();
                        string queryCheckDB = "IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'TutoriasDB') CREATE DATABASE TutoriasDB;";
                        using (SqlCommand cmd = new SqlCommand(queryCheckDB, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Si llega aquí, la conexión al servidor de DB y la base de datos se inicializaron con éxito.
                    // Ajustamos el Initial Catalog de la cadena de conexión final a TutoriasDB.
                    string targetConnString = connString;
                    if (targetConnString.Contains("Initial Catalog="))
                    {
                        var parts = targetConnString.Split(';');
                        for (int i = 0; i < parts.Length; i++)
                        {
                            if (parts[i].Trim().StartsWith("Initial Catalog", StringComparison.OrdinalIgnoreCase))
                            {
                                parts[i] = "Initial Catalog=TutoriasDB";
                            }
                        }
                        targetConnString = string.Join(";", parts);
                    }
                    else if (targetConnString.Contains("Database="))
                    {
                        var parts = targetConnString.Split(';');
                        for (int i = 0; i < parts.Length; i++)
                        {
                            if (parts[i].Trim().StartsWith("Database", StringComparison.OrdinalIgnoreCase))
                            {
                                parts[i] = "Database=TutoriasDB";
                            }
                        }
                        targetConnString = string.Join(";", parts);
                    }

                    successfulString = targetConnString;
                    success = true;
                    break;
                }
                catch (Exception ex)
                {
                    lastException = ex;
                    System.Diagnostics.Debug.WriteLine($"Intento fallido con: {connString}. Error: {ex.Message}");
                }
            }

            if (!success)
            {
                if (lastException != null)
                    throw lastException;
                else
                    throw new Exception("No se pudo conectar a ningún servidor de base de datos SQL Server.");
            }

            // Guardamos globalmente la conexión que funcionó
            cadenaConexion = successfulString;

            // Ejecutamos las verificaciones y actualizaciones de esquema en la base de datos conectada
            EjecutarVerificacionesEsquema();
        }

        private void EjecutarVerificacionesEsquema()
        {
            using (SqlConnection conn = LeerConexion())
            {
                conn.Open();

                // 1. ASIGNATURAS
                string queryAsignaturas = @"
                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Asignaturas]') AND type in (N'U'))
                    BEGIN
                        CREATE TABLE Asignaturas (
                            IdAsignatura INT PRIMARY KEY IDENTITY(1,1),
                            Codigo NVARCHAR(50) NOT NULL UNIQUE,
                            Nombre NVARCHAR(255) NOT NULL,
                            Facultad NVARCHAR(255) DEFAULT 'Facultad de Matemáticas y Física',
                            Area NVARCHAR(255) NULL,
                            Descripcion NVARCHAR(MAX) NULL,
                            Modalidad NVARCHAR(100) NULL,
                            Activo BIT DEFAULT 1
                        );
                    END
                    ELSE
                    BEGIN
                        IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Asignaturas') AND name = 'Area')
                            ALTER TABLE Asignaturas ADD Area NVARCHAR(255) NULL;
                        
                        IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Asignaturas') AND name = 'Descripcion')
                            ALTER TABLE Asignaturas ADD Descripcion NVARCHAR(MAX) NULL;

                        IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Asignaturas') AND name = 'Modalidad')
                            ALTER TABLE Asignaturas ADD Modalidad NVARCHAR(100) NULL;

                        IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Asignaturas') AND name = 'Activo')
                            ALTER TABLE Asignaturas ADD Activo BIT DEFAULT 1;
                    END";
                using (SqlCommand cmd = new SqlCommand(queryAsignaturas, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // 2. TUTORES
                string queryTutores = @"
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
                    ELSE
                    BEGIN
                        IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Tutores') AND name = 'FotoRuta')
                            ALTER TABLE Tutores ADD FotoRuta NVARCHAR(MAX) NULL;
                        
                        IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Tutores') AND name = 'Activo')
                            ALTER TABLE Tutores ADD Activo BIT DEFAULT 1;
                    END";
                using (SqlCommand cmd = new SqlCommand(queryTutores, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // 3. ESTUDIANTES
                string queryEstudiantes = @"
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
                    ELSE
                    BEGIN
                        IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Estudiantes') AND name = 'Email')
                            ALTER TABLE Estudiantes ADD Email NVARCHAR(255) NULL;

                        IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Estudiantes') AND name = 'Activo')
                            ALTER TABLE Estudiantes ADD Activo BIT DEFAULT 1;
                    END";
                using (SqlCommand cmd = new SqlCommand(queryEstudiantes, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // 4. SESIONES
                string querySesiones = @"
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
                    END
                    ELSE
                    BEGIN
                        IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('SesionesTutoria') AND name = 'IdAsignatura')
                            ALTER TABLE SesionesTutoria ADD IdAsignatura INT NULL FOREIGN KEY REFERENCES Asignaturas(IdAsignatura);
                        
                        IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('SesionesTutoria') AND name = 'IdTutor')
                            ALTER TABLE SesionesTutoria ADD IdTutor INT NULL FOREIGN KEY REFERENCES Tutores(IdTutor);

                        IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('SesionesTutoria') AND name = 'Activo')
                            ALTER TABLE SesionesTutoria ADD Activo BIT DEFAULT 1;
                    END";
                using (SqlCommand cmd = new SqlCommand(querySesiones, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // 5. ESTUDIANTE_SESIONES
                string queryEstudianteSesiones = @"
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
                    ELSE
                    BEGIN
                        IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Estudiante_Sesiones') AND name = 'Asistencia')
                            ALTER TABLE Estudiante_Sesiones ADD Asistencia BIT DEFAULT 0;

                        IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Estudiante_Sesiones') AND name = 'Activo')
                            ALTER TABLE Estudiante_Sesiones ADD Activo BIT DEFAULT 1;
                    END";
                using (SqlCommand cmd = new SqlCommand(queryEstudianteSesiones, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // 6. FEEDBACK
                string queryFeedback = @"
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
                    ELSE
                    BEGIN
                        IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Feedback') AND name = 'Comentarios')
                            ALTER TABLE Feedback ADD Comentarios NVARCHAR(MAX) NULL;

                        IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Feedback') AND name = 'FechaRegistro')
                            ALTER TABLE Feedback ADD FechaRegistro DATETIME DEFAULT GETDATE();

                        IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Feedback') AND name = 'Activo')
                            ALTER TABLE Feedback ADD Activo BIT DEFAULT 1;
                    END";
                using (SqlCommand cmd = new SqlCommand(queryFeedback, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // 7. ACTIVIDADES
                string queryActividades = @"
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
                    ELSE
                    BEGIN
                        IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Actividades') AND name = 'FechaPublicacion')
                            ALTER TABLE Actividades ADD FechaPublicacion DATETIME DEFAULT GETDATE();

                        IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Actividades') AND name = 'FechaVencimiento')
                            ALTER TABLE Actividades ADD FechaVencimiento DATETIME NULL;

                        IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Actividades') AND name = 'Activo')
                            ALTER TABLE Actividades ADD Activo BIT DEFAULT 1;
                    END";
                using (SqlCommand cmd = new SqlCommand(queryActividades, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // 8. GALERIA
                string queryGaleria = @"
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
                    ELSE
                    BEGIN
                        IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Galeria') AND name = 'Titulo')
                            ALTER TABLE Galeria ADD Titulo NVARCHAR(255) NULL;

                        IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Galeria') AND name = 'FechaSubida')
                            ALTER TABLE Galeria ADD FechaSubida DATETIME DEFAULT GETDATE();

                        IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Galeria') AND name = 'Activo')
                            ALTER TABLE Galeria ADD Activo BIT DEFAULT 1;
                    END";
                using (SqlCommand cmd = new SqlCommand(queryGaleria, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
