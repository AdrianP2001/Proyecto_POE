using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Proyecto_POE.Entidades;
using Proyecto_POE.Negocio;

namespace Proyecto_POE.Presentacion
{
    public partial class FrmEstudiante : Form
    {
        // Managers de negocio
        private readonly GestorAsignaturas _asignaturasManager = new GestorAsignaturas();
        private readonly GestorActividades _actividadesManager = new GestorActividades();
        private readonly GestorGaleria _galeriaManager = new GestorGaleria();
        private readonly GestorFeedback _feedbackManager = new GestorFeedback();
        private readonly GestorTutorias _tutoriasManager = new GestorTutorias();

        public Estudiante? EstudianteActual { get; set; }

        public FrmEstudiante()
        {
            InitializeComponent();
        }

        private void FrmEstudiante_Load(object sender, EventArgs e)
        {
            CargarConsultaTutorias();
            CargarCalendario();
            CargarGaleria();
            CargarFeedback();

            if (EstudianteActual != null)
            {
                txtNombreEstudiante.Text = $"{EstudianteActual.Nombres} {EstudianteActual.Apellidos}";
                txtNombreEstudiante.ReadOnly = true;
            }
        }

        // ============================================================
        // TAB 1 — CONSULTA DE TUTORIAS
        // ============================================================
        private void CargarConsultaTutorias()
        {
            var asignaturas = _asignaturasManager.ListarAsignaturas();
            lstGrupos.Items.Clear();
            
            lstGrupos.DisplayMember = "Nombre";
            lstGrupos.ValueMember = "IdAsignatura";

            foreach (var a in asignaturas)
                lstGrupos.Items.Add(a);
        }

        private void lstGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstGrupos.SelectedItem is Asignatura seleccionado)
                MostrarDetalleAsignatura(seleccionado);
        }

        private void MostrarDetalleAsignatura(Asignatura asignatura)
        {
            lblNombreMateria.Text = asignatura.Nombre;
            txtDescripcionGrupo.Text = $"Código: {asignatura.Codigo}\r\nFacultad: {asignatura.Facultad}\r\nÁrea: {asignatura.Area}\r\nModalidad: {asignatura.Modalidad}\r\nDescripción: {asignatura.Descripcion}";

            // Tutores asignados (a través de sus sesiones de tutoría)
            lstTutores.Items.Clear();
            var tutores = new Proyecto_POE.Datos.TutorDAO().ObtenerPorAsignatura(asignatura.IdAsignatura);
            if (tutores.Count == 0)
            {
                lstTutores.Items.Add("👤 No hay tutores asignados a esta asignatura.");
            }
            else
            {
                foreach (var t in tutores)
                    lstTutores.Items.Add($"👤 {t.Nombres} {t.Apellidos}  |  {t.Especialidad}");
            }

            // Horarios y Sesiones
            lstHorarios.Items.Clear();
            var sesiones = new Proyecto_POE.Datos.SesionDAO().ObtenerPorAsignatura(asignatura.IdAsignatura);
            if (sesiones.Count == 0)
            {
                lstHorarios.Items.Add("📅 No hay sesiones programadas para esta asignatura.");
            }
            else
            {
                foreach (var s in sesiones)
                {
                    lstHorarios.Items.Add($"📅 {s.Fecha.ToString("dd/MM/yyyy")} | 🕒 {s.HoraInicio:hh\\:mm} - {s.HoraFin:hh\\:mm} | 📍 {s.Ubicacion} (Tutor: {s.TutorNombre})");
                }
            }

            // Recursos / Actividades
            lstRecursos.Items.Clear();
            var actividades = _actividadesManager.ListarActividadesPorAsignatura(asignatura.IdAsignatura);
            if (actividades.Count == 0)
            {
                lstRecursos.Items.Add("📝 No hay actividades o recursos registrados para esta asignatura.");
            }
            else
            {
                foreach (var act in actividades)
                {
                    lstRecursos.Items.Add($"📝 {act.Titulo} - {act.Descripcion} (Vence: {act.FechaVencimiento?.ToString("dd/MM/yyyy") ?? "Sin límite"})");
                }
            }
        }

        private void lstRecursos_DoubleClick(object sender, EventArgs e)
        {
            // Omitido
        }

        // ============================================================
        // TAB 2 — CALENDARIO DE ACTIVIDADES
        // ============================================================
        private void CargarCalendario()
        {
            var asignaturas = _asignaturasManager.ListarAsignaturas();
            cmbFacultadFiltro.Items.Clear();
            cmbFacultadFiltro.Items.Add(new Asignatura { IdAsignatura = 0, Nombre = "— Todas las Asignaturas —" });
            cmbFacultadFiltro.DisplayMember = "Nombre";

            foreach (var a in asignaturas)
                cmbFacultadFiltro.Items.Add(a);
            
            cmbFacultadFiltro.SelectedIndex = 0;
            ActualizarAgenda(null);
        }

        private void cmbFacultadFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            int? idAsignatura = null;
            if (cmbFacultadFiltro.SelectedItem is Asignatura a && a.IdAsignatura > 0)
                idAsignatura = a.IdAsignatura;
            ActualizarAgenda(idAsignatura);
        }

        private void ActualizarAgenda(int? idAsignatura)
        {
            dgvCalendario.DataSource = null;
            var tabla = new System.Data.DataTable();
            tabla.Columns.Add("Titulo");
            tabla.Columns.Add("Descripcion");
            tabla.Columns.Add("Fecha de Vencimiento");

            List<Actividad> actividades;
            if (idAsignatura.HasValue)
            {
                actividades = _actividadesManager.ListarActividadesPorAsignatura(idAsignatura.Value);
            }
            else
            {
                actividades = _actividadesManager.ListarTodas();
            }

            foreach (var act in actividades)
                tabla.Rows.Add(act.Titulo, act.Descripcion, act.FechaVencimiento?.ToString("dd/MM/yyyy") ?? "Sin limite");
            
            dgvCalendario.DataSource = tabla;
            dgvCalendario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ============================================================
        // TAB 3 — GALERIA DE FOTOS
        // ============================================================
        private void CargarGaleria()
        {
            flowGaleria.Controls.Clear();
            var fotos = _galeriaManager.ObtenerFotos();

            if (fotos.Count == 0)
            {
                lblGaleriaMensaje.Text = "No hay fotos registradas en la galeria todavia.";
                lblGaleriaMensaje.Visible = true;
                return;
            }

            lblGaleriaMensaje.Visible = false;
            foreach (var foto in fotos)
            {
                var pb = new PictureBox
                {
                    Width = 160, Height = 120,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BorderStyle = BorderStyle.FixedSingle,
                    Cursor = Cursors.Hand,
                    Tag = foto,
                    Margin = new Padding(6)
                };

                string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, foto.RutaLocal);
                if (File.Exists(ruta))
                    pb.Image = Image.FromFile(ruta);
                else
                    pb.BackColor = Color.FromArgb(230, 235, 245);

                var tooltip = new ToolTip();
                tooltip.SetToolTip(pb, foto.Titulo);
                pb.Click += (s, e) => MostrarFotoAmpliada((PictureBox)s!);
                flowGaleria.Controls.Add(pb);
            }
        }

        private void MostrarFotoAmpliada(PictureBox pb)
        {
            if (pb.Image == null) return;
            picVistaPrevia.Image = pb.Image;
            if (pb.Tag is ImagenGaleria f)
                lblDescripcionFoto.Text = f.Titulo;
        }

        // ============================================================
        // TAB 4 — FEEDBACK Y VALORACION
        // ============================================================
        private void CargarFeedback()
        {
            var tutores = _tutoriasManager.ListarTutores();
            cmbTutoresVoto.Items.Clear();
            cmbTutoresVoto.DisplayMember = "Nombres";
            foreach (var t in tutores)
                cmbTutoresVoto.Items.Add(t);
                
            if (cmbTutoresVoto.Items.Count > 0)
                cmbTutoresVoto.SelectedIndex = 0;

            var asignaturas = _asignaturasManager.ListarAsignaturas();
            cmbGrupoComentario.Items.Clear();
            cmbGrupoComentario.DisplayMember = "Nombre";
            cmbGrupoComentario.Items.Add(new Asignatura { IdAsignatura = 0, Nombre = "Sin asignatura especifica" });
            foreach (var a in asignaturas)
                cmbGrupoComentario.Items.Add(a);
            cmbGrupoComentario.SelectedIndex = 0;

            ActualizarTutorDelMes();
        }

        private void ActualizarTutorDelMes()
        {
            var data = new Proyecto_POE.Datos.TutorDAO().ObtenerTutorDelMes();
            if (data != null)
            {
                lblTutorDelMesNombre.Text = $"{data.Item1.Nombres} {data.Item1.Apellidos}";
                lblTutorDelMesEspecialidad.Text = data.Item1.Especialidad;
                lblTutorDelMesPromedio.Text = $"⭐ {data.Item2:F1}";
            }
            else
            {
                lblTutorDelMesNombre.Text = "Aún sin calificaciones";
                lblTutorDelMesEspecialidad.Text = "";
                lblTutorDelMesPromedio.Text = "⭐ 0.0";
            }
        }

        private void btnEnviarComentario_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreEstudiante.Text.Trim();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Por favor, ingrese su nombre.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var estudiante = new Proyecto_POE.Datos.EstudianteDAO().ObtenerOCrearPorNombre(nombre);
                int idAsignatura = 0;
                if (cmbGrupoComentario.SelectedItem is Asignatura a)
                {
                    idAsignatura = a.IdAsignatura;
                }

                int idSesion = new Proyecto_POE.Datos.SesionDAO().ObtenerOCrearSesionParaAsignatura(idAsignatura);

                var f = new Feedback
                {
                    IdEstudiante = estudiante.IdEstudiante,
                    IdSesion = idSesion,
                    Calificacion = 5,
                    Comentarios = txtComentario.Text,
                    FechaRegistro = DateTime.Now,
                    Activo = true
                };

                _feedbackManager.RegistrarFeedback(f);
                MessageBox.Show("✅ Comentario enviado. Gracias por tu feedback!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombreEstudiante.Clear();
                txtComentario.Clear();
                ActualizarTutorDelMes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnVotar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreEstudiante.Text.Trim();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Por favor, ingrese su nombre para registrar el voto en la pestaña de comentarios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbTutoresVoto.SelectedItem is not Tutor tutor)
            {
                MessageBox.Show("Seleccione un tutor.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int estrellas = 0;
            if (rb1Estrella.Checked) estrellas = 1;
            else if (rb2Estrellas.Checked) estrellas = 2;
            else if (rb3Estrellas.Checked) estrellas = 3;
            else if (rb4Estrellas.Checked) estrellas = 4;
            else if (rb5Estrellas.Checked) estrellas = 5;

            if (estrellas == 0)
            {
                MessageBox.Show("Por favor, seleccione una cantidad de estrellas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var estudiante = new Proyecto_POE.Datos.EstudianteDAO().ObtenerOCrearPorNombre(nombre);
                int idSesion = new Proyecto_POE.Datos.SesionDAO().ObtenerOCrearSesionParaTutor(tutor.IdTutor);

                var f = new Feedback
                {
                    IdEstudiante = estudiante.IdEstudiante,
                    IdSesion = idSesion, 
                    Calificacion = estrellas,
                    Comentarios = $"Votación directa al tutor {tutor.Nombres} {tutor.Apellidos}",
                    FechaRegistro = DateTime.Now,
                    Activo = true
                };
                
                _feedbackManager.RegistrarFeedback(f);
                MessageBox.Show($"✅ Voto registrado: {estrellas} estrella(s) para {tutor.Nombres}.", "Voto Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizarTutorDelMes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
