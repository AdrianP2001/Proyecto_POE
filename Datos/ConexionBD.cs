using System.Configuration;
using System.Data.SqlClient;

namespace Proyecto_POE.Datos
{
    public class ConexionBD
    {
        // Se recomienda usar App.config para la cadena de conexión
        private string cadenaConexion = ConfigurationManager.ConnectionStrings["TutoriaConn"]?.ConnectionString 
                                        ?? "Data Source=.;Initial Catalog=TutoriasDB;Integrated Security=True;TrustServerCertificate=True";

        public SqlConnection LeerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }

        public void InicializarBaseDeDatos()
        {
            try
            {
                string masterConnectionString = cadenaConexion;
                
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

                using (SqlConnection conn = LeerConexion())
                {
                    conn.Open();

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
                        END";

                    using (SqlCommand cmd = new SqlCommand(queryAsignaturas, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

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
                        END";
                    using (SqlCommand cmd = new SqlCommand(queryTutores, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

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
                        END";
                    using (SqlCommand cmd = new SqlCommand(queryEstudiantes, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

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
                        END";
                    using (SqlCommand cmd = new SqlCommand(querySesiones, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

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
                        END";
                    using (SqlCommand cmd = new SqlCommand(queryEstudianteSesiones, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

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
                        END";
                    using (SqlCommand cmd = new SqlCommand(queryFeedback, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

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
                        END";
                    using (SqlCommand cmd = new SqlCommand(queryActividades, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

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
                        END";
                    using (SqlCommand cmd = new SqlCommand(queryGaleria, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al inicializar la base de datos: " + ex.Message);
            }
        }
    }
}
