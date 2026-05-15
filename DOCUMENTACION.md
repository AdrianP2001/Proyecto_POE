# Documentación Técnica: Proyecto Tutorías POE 2026

Este documento contiene las especificaciones técnicas, diagramas y manuales requeridos para la entrega final del proyecto.

---

## 📊 Documentación UML

### 1. Diagrama de Casos de Uso (PlantUML)
```plantuml
@startuml
left to right direction
actor "Administrador" as Admin
actor "Estudiante" as Est

package "Sistema de Tutorías" {
  usecase "Gestionar Materias" as UC1
  usecase "Gestionar Tutores" as UC2
  usecase "Registrar Sesiones de Tutoría" as UC3
  usecase "Consultar Agenda" as UC4
  usecase "Enviar Feedback / Calificar" as UC5
  usecase "Exportar Reporte PDF" as UC6
}

Admin --> UC1
Admin --> UC2
Admin --> UC3
Admin --> UC6

Est --> UC4
Est --> UC5
@endum
```

### 2. Diagrama de Clases (Arquitectura 3-Capas)
```plantuml
@startuml
package "Capa Presentación" {
    class FrmGestionSesiones {
        - SesionManager manager
        + btnGuardar_Click()
        + CargarDatos()
    }
}

package "Capa Negocio" {
    class SesionManager {
        - SesionDAO dao
        + ProcesarRegistro(Sesion)
        + ObtenerCronograma()
    }
}

package "Capa Datos" {
    class SesionDAO {
        - ConexionBD conexion
        + Registrar(Sesion)
        + Listar() : List<Sesion>
    }
    class ConexionBD {
        + LeerConexion() : SqlConnection
    }
}

package "Capa Entidades" {
    class Sesion {
        + int ID
        + DateTime Fecha
        + TimeSpan HoraInicio
        + TimeSpan HoraFin
        + String Ubicacion
        + int OrdenSecuencial
    }
}

FrmGestionSesiones ..> SesionManager
SesionManager ..> SesionDAO
SesionDAO ..> ConexionBD
SesionDAO ..> Sesion
@endum
```

### 3. Diagrama de Entidad-Relación (Base de Datos)
```plantuml
@startuml
entity "SesionesTutoria" as sesion {
    * IdSesion : int <<PK>>
    --
    Fecha : date
    HoraInicio : time
    HoraFin : time
    Ubicacion : nvarchar
    OrdenSecuencial : int
}

entity "Asignaturas" as asignatura {
    * IdAsignatura : int <<PK>>
    --
    Codigo : nvarchar
    Nombre : nvarchar
}

entity "Tutores" as tutor {
    * IdTutor : int <<PK>>
    --
    Nombres : nvarchar
    Apellidos : nvarchar
    Especialidad : nvarchar
}

entity "Estudiantes" as estudiante {
    * IdEstudiante : int <<PK>>
    --
    Matricula : nvarchar
    Nombres : nvarchar
    Email : nvarchar
}

entity "Feedback" as fb {
    * IdFeedback : int <<PK>>
    --
    IdEstudiante : int <<FK>>
    IdSesion : int <<FK>>
    Calificacion : int
    Comentarios : text
}

sesion }|--|| asignatura : pertenece
sesion }|--|| tutor : dictada por
fb }|--|| estudiante : escrito por
fb }|--|| sesion : sobre
@endum
```

---

## 📑 Especificación de Casos de Uso

| ID | Caso de Uso | Actor | Descripción |
|:---|:---|:---|:---|
| CU-01 | **Registrar Sesión de Tutoría** | Administrador | Permite crear un horario. El sistema valida automáticamente que no existan cruces en el mismo aula/enlace. |
| CU-02 | **Consultar Agenda** | Estudiante | El estudiante filtra por facultad para ver las tutorías disponibles en la semana. |
| CU-03 | **Enviar Feedback** | Estudiante | Tras asistir a una sesión, el estudiante califica al tutor (1-5 estrellas) y deja un comentario. |

---

## 🛠️ Escenarios Prácticos

### Escenario 1: Conflicto de Horario
- **Precondición:** Existe una tutoría de "Cálculo" de 10:00 a 11:00.
- **Acción:** El admin intenta registrar "Física" de 10:30 a 11:30 en la misma fecha.
- **Resultado esperado:** El sistema muestra un mensaje de error advirtiendo el conflicto y bloquea el registro.

### Escenario 2: Exportación de Informe
- **Acción:** El admin selecciona el botón "Exportar PDF" en el módulo de resultados.
- **Resultado esperado:** Se genera un archivo PDF con el resumen de asistencia e impacto por materia del mes actual.

---

## 📖 Manual de Usuario

### Acceso al Diseñador Visual (Para Desarrolladores)
1. Abrir la solución en Visual Studio.
2. Navegar a `Presentacion > GestionSesiones`.
3. Clic derecho en `FrmGestionSesiones.cs` > **Ver Diseñador**.
4. Use la **Cuadro de Herramientas** (Toolbox) para añadir controles.

### Uso del Sistema
1. **Paso 1:** Configurar la conexión en SQL Server.
2. **Paso 2:** Iniciar la aplicación. Se abrirá por defecto el panel de Gestión de Sesiones.
3. **Paso 3:** Ingrese Fecha, Hora y Ubicación. Haga clic en **Guardar**.
4. **Paso 4:** Observe cómo la lista inferior se actualiza automáticamente con el orden secuencial.

---

*Documento generado para la revisión del Segundo Parcial.*
