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
                MostrarDetalleAsignatura(seleccionado.IdAsignatura, seleccionado.Nombre);
        }

        private void MostrarDetalleAsignatura(int idAsignatura, string nombreMateria)
        {
            lblNombreMateria.Text = nombreMateria;
            txtDescripcionGrupo.Text = $"Asignatura: {nombreMateria}";

            // Tutores (Por ahora mostramos todos los tutores)
            lstTutores.Items.Clear();
            var tutores = _tutoriasManager.ListarTutores();
            foreach (var t in tutores)
                lstTutores.Items.Add($"👤 {t.Nombres} {t.Apellidos}  |  {t.Especialidad}");

            // Horarios
            lstHorarios.Items.Clear();
            lstHorarios.Items.Add("📅 Horarios pendientes de asignar");

            // Recursos
            lstRecursos.Items.Clear();
            lstRecursos.Items.Add("🔗 Recursos bibliográficos en la plataforma virtual.");
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
            tabla.Columns.Add("Título");
            tabla.Columns.Add("Descripción");
            tabla.Columns.Add("Fecha de Vencimiento");

            if (idAsignatura.HasValue)
            {
                var actividades = _actividadesManager.ListarActividadesPorAsignatura(idAsignatura.Value);
                foreach (var act in actividades)
                    tabla.Rows.Add(act.Titulo, act.Descripcion, act.FechaVencimiento?.ToString("dd/MM/yyyy") ?? "Sin límite");
            }
            
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
        // TAB 4 — FEEDBACK Y VALORACIÓN
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
            cmbGrupoComentario.Items.Add(new Asignatura { IdAsignatura = 0, Nombre = "Sin asignatura específica" });
            foreach (var a in asignaturas)
                cmbGrupoComentario.Items.Add(a);
            cmbGrupoComentario.SelectedIndex = 0;

            ActualizarTutorDelMes();
        }

        private void ActualizarTutorDelMes()
        {
            lblTutorDelMesNombre.Text = "Próximamente";
            lblTutorDelMesEspecialidad.Text = "";
            lblTutorDelMesPromedio.Text = "";
        }

        private void btnEnviarComentario_Click(object sender, EventArgs e)
        {
            int idSesion = 1; 
            
            try
            {
                var f = new Feedback
                {
                    IdEstudiante = 1,
                    IdSesion = idSesion,
                    Calificacion = 5,
                    Comentarios = txtComentario.Text,
                    FechaRegistro = DateTime.Now,
                    Activo = true
                };

                _feedbackManager.RegistrarFeedback(f);
                MessageBox.Show("✅ Comentario enviado. ¡Gracias por tu feedback!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombreEstudiante.Clear();
                txtComentario.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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

            if (estrellas == 0)
            {
                MessageBox.Show("Por favor, seleccione una cantidad de estrellas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var f = new Feedback
                {
                    IdEstudiante = 1,
                    IdSesion = 1, 
                    Calificacion = estrellas,
                    Comentarios = "Votación directa al tutor",
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
