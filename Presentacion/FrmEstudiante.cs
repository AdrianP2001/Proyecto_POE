using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TutoriasApp.Entidades;
using TutoriasApp.Negocio;

namespace TutoriasApp.Presentacion
{
    public partial class FrmEstudiante : Form
    {
        // Managers de negocio
        private readonly ConsultaTutoriasManager _consultaManager = new ConsultaTutoriasManager();
        private readonly CalendarioManager _calendarioManager = new CalendarioManager();
        private readonly GaleriaManager _galeriaManager = new GaleriaManager();
        private readonly FeedbackManager _feedbackManager = new FeedbackManager();

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
        }

        // ============================================================
        // TAB 1 — CONSULTA DE TUTORÍAS
        // ============================================================
        private void CargarConsultaTutorias()
        {
            var grupos = _consultaManager.ObtenerTodos();
            lstGrupos.Items.Clear();
            lstGrupos.Tag = grupos;
            foreach (var g in grupos)
                lstGrupos.Items.Add(g);
        }

        private void lstGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstGrupos.SelectedItem is GrupoEstudio seleccionado)
                MostrarDetalleGrupo(seleccionado.IdGrupo);
        }

        private void MostrarDetalleGrupo(int idGrupo)
        {
            var detalle = _consultaManager.ObtenerDetalleCompleto(idGrupo);
            if (detalle == null) return;

            lblNombreMateria.Text = detalle.NombreMateria;
            txtDescripcionGrupo.Text = detalle.Descripcion;

            // Tutores
            lstTutores.Items.Clear();
            foreach (var t in detalle.Tutores)
                lstTutores.Items.Add($"👤 {t.Nombre}  |  {t.Especialidad}  |  {t.Email}");

            // Horarios
            lstHorarios.Items.Clear();
            foreach (var s in detalle.Horarios)
                lstHorarios.Items.Add($"📅 {s.Fecha:dd/MM/yyyy}   🕐 {s.HoraInicio:hh\\:mm} – {s.HoraFin:hh\\:mm}   📍 {s.Ubicacion}");

            // Recursos
            lstRecursos.Items.Clear();
            foreach (var r in detalle.Recursos)
                lstRecursos.Items.Add($"🔗 {r.Descripcion}");

            lstRecursos.Tag = detalle.Recursos;
        }

        private void lstRecursos_DoubleClick(object sender, EventArgs e)
        {
            if (lstRecursos.Tag is List<Recurso> recursos && lstRecursos.SelectedIndex >= 0)
            {
                var recurso = recursos[lstRecursos.SelectedIndex];
                try { System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(recurso.Url) { UseShellExecute = true }); }
                catch { MessageBox.Show("No se pudo abrir el enlace.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
        }

        // ============================================================
        // TAB 2 — CALENDARIO DE ACTIVIDADES
        // ============================================================
        private void CargarCalendario()
        {
            var facultades = _calendarioManager.ObtenerFacultades();
            cmbFacultadFiltro.Items.Clear();
            cmbFacultadFiltro.Items.Add(new Facultad { IdFacultad = 0, Nombre = "— Todas las Facultades —" });
            foreach (var f in facultades)
                cmbFacultadFiltro.Items.Add(f);
            cmbFacultadFiltro.SelectedIndex = 0;
            ActualizarAgenda(null);
        }

        private void cmbFacultadFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            int? idFac = null;
            if (cmbFacultadFiltro.SelectedItem is Facultad f && f.IdFacultad > 0)
                idFac = f.IdFacultad;
            ActualizarAgenda(idFac);
        }

        private void ActualizarAgenda(int? idFacultad)
        {
            var grupos = _calendarioManager.ObtenerAgenda(idFacultad);
            dgvCalendario.DataSource = null;
            var tabla = new System.Data.DataTable();
            tabla.Columns.Add("Materia");
            tabla.Columns.Add("Descripción del Grupo");
            tabla.Columns.Add("Cupo");

            foreach (var g in grupos)
                tabla.Rows.Add(g.NombreMateria, g.Descripcion, g.Cupo);

            dgvCalendario.DataSource = tabla;
            dgvCalendario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ============================================================
        // TAB 3 — GALERÍA DE FOTOS
        // ============================================================
        private void CargarGaleria()
        {
            flowGaleria.Controls.Clear();
            var fotos = _galeriaManager.ObtenerFotos();

            if (fotos.Count == 0)
            {
                lblGaleriaMensaje.Text = "No hay fotos registradas en la galería todavía.";
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

                string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, foto.RutaImagen);
                if (File.Exists(ruta))
                    pb.Image = Image.FromFile(ruta);
                else
                    pb.BackColor = Color.FromArgb(230, 235, 245);

                var tooltip = new ToolTip();
                tooltip.SetToolTip(pb, foto.Descripcion);
                pb.Click += (s, e) => MostrarFotoAmpliada((PictureBox)s!);
                flowGaleria.Controls.Add(pb);
            }
        }

        private void MostrarFotoAmpliada(PictureBox pb)
        {
            if (pb.Image == null) return;
            picVistaPrevia.Image = pb.Image;
            if (pb.Tag is FotoSesion f)
                lblDescripcionFoto.Text = f.Descripcion;
        }

        // ============================================================
        // TAB 4 — FEEDBACK Y VALORACIÓN
        // ============================================================
        private void CargarFeedback()
        {
            // Cargar tutores en ComboBox de votación
            var tutores = new TutorDAO_Helper(_feedbackManager).ObtenerTodos();
            cmbTutoresVoto.Items.Clear();
            foreach (var t in tutores)
                cmbTutoresVoto.Items.Add(t);
            if (cmbTutoresVoto.Items.Count > 0)
                cmbTutoresVoto.SelectedIndex = 0;

            // Cargar grupos en ComboBox de comentarios (opcional)
            var grupos = _consultaManager.ObtenerTodos();
            cmbGrupoComentario.Items.Clear();
            cmbGrupoComentario.Items.Add(new GrupoEstudio { IdGrupo = 0, NombreMateria = "Sin grupo específico", Descripcion = "" });
            foreach (var g in grupos)
                cmbGrupoComentario.Items.Add(g);
            cmbGrupoComentario.SelectedIndex = 0;

            ActualizarTutorDelMes();
        }

        private void ActualizarTutorDelMes()
        {
            var tutor = _feedbackManager.ObtenerTutorDelMes();
            if (tutor != null)
            {
                lblTutorDelMesNombre.Text = tutor.Nombre;
                lblTutorDelMesEspecialidad.Text = tutor.Especialidad;
                lblTutorDelMesPromedio.Text = $"⭐ {tutor.PromedioVotos:F1} / 5.0";
            }
            else
            {
                lblTutorDelMesNombre.Text = "Sin votos este mes";
                lblTutorDelMesEspecialidad.Text = "";
                lblTutorDelMesPromedio.Text = "";
            }
        }

        private void btnEnviarComentario_Click(object sender, EventArgs e)
        {
            int? idGrupo = null;
            if (cmbGrupoComentario.SelectedItem is GrupoEstudio g && g.IdGrupo > 0)
                idGrupo = g.IdGrupo;

            string rpta = _feedbackManager.RegistrarComentario(txtNombreEstudiante.Text, txtComentario.Text, idGrupo);
            if (rpta == "OK")
            {
                MessageBox.Show("✅ Comentario enviado. ¡Gracias por tu feedback!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombreEstudiante.Clear();
                txtComentario.Clear();
            }
            else
                MessageBox.Show(rpta, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnVotar_Click(object sender, EventArgs e)
        {
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

            string rpta = _feedbackManager.VotarTutor(tutor.IdTutor, estrellas);
            if (rpta == "OK")
            {
                MessageBox.Show($"✅ Voto registrado: {estrellas} estrella(s) para {tutor.Nombre}.", "Voto Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizarTutorDelMes();
            }
            else
                MessageBox.Show(rpta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // Helper interno para obtener tutores en feedback sin romper la capa
        private class TutorDAO_Helper
        {
            private readonly FeedbackManager _fm;
            public TutorDAO_Helper(FeedbackManager fm) { _fm = fm; }
            public List<Tutor> ObtenerTodos() => new TutorDAO_Direct().Listar();
        }

        private class TutorDAO_Direct
        {
            public List<Tutor> Listar() => new Datos.TutorDAO().Listar();
        }
    }
}
