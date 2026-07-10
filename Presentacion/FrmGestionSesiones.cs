using System;
using System.Windows.Forms;
using Proyecto_POE.Entidades;
using Proyecto_POE.Negocio;

namespace Proyecto_POE.Presentacion
{
    public partial class FrmGestionSesiones : Form
    {
        private SesionManager manager = new SesionManager();

        public FrmGestionSesiones()
        {
            InitializeComponent();
        }

        private void FrmGestionSesiones_Load(object sender, EventArgs e)
        {
            CargarDatos();
            CargarComboboxes();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Sesion nueva = new Sesion
            {
                Fecha = dtpFecha.Value,
                HoraInicio = dtpInicio.Value.TimeOfDay,
                HoraFin = dtpFin.Value.TimeOfDay,
                Ubicacion = txtUbicacion.Text,
                IdAsignatura = cmbAsignatura.SelectedValue != null ? (int?)Convert.ToInt32(cmbAsignatura.SelectedValue) : null,
                IdTutor = cmbTutor.SelectedValue != null ? (int?)Convert.ToInt32(cmbTutor.SelectedValue) : null
            };

            string rpta = manager.ProcesarRegistro(nueva);

            if (rpta == "OK")
            {
                MessageBox.Show("Sesión registrada con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();
                LimpiarFormulario();
            }
            else
            {
                MessageBox.Show(rpta, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CargarDatos()
        {
            dgvSesiones.DataSource = null;
            dgvSesiones.DataSource = manager.ObtenerCronograma();

            // Formato profesional para las columnas de tiempo
            if (dgvSesiones.Columns["HoraInicio"] != null)
                dgvSesiones.Columns["HoraInicio"].DefaultCellStyle.Format = "hh\\:mm";
            
            if (dgvSesiones.Columns["HoraFin"] != null)
                dgvSesiones.Columns["HoraFin"].DefaultCellStyle.Format = "hh\\:mm";

            // Ocultar ID si se desea una vista más limpia para el usuario
            if (dgvSesiones.Columns["ID"] != null)
                dgvSesiones.Columns["ID"].Visible = false;
        }

        private void CargarComboboxes()
        {
            try
            {
                var gestorAsig = new GestorAsignaturas();
                var asignaturas = gestorAsig.ListarAsignaturas();
                cmbAsignatura.DataSource = asignaturas;
                cmbAsignatura.DisplayMember = "Nombre";
                cmbAsignatura.ValueMember = "IdAsignatura";

                var gestorTutor = new GestorTutorias();
                var tutores = gestorTutor.ListarTutores();
                
                var tutoresDisplay = new System.Collections.Generic.List<object>();
                foreach (var t in tutores)
                {
                    tutoresDisplay.Add(new { IdTutor = t.IdTutor, NombreCompleto = $"{t.Nombres} {t.Apellidos}" });
                }
                
                cmbTutor.DataSource = tutoresDisplay;
                cmbTutor.DisplayMember = "NombreCompleto";
                cmbTutor.ValueMember = "IdTutor";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar asignaturas o tutores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            txtUbicacion.Clear();
            dtpFecha.Value = DateTime.Now;
            if (cmbAsignatura.Items.Count > 0) cmbAsignatura.SelectedIndex = 0;
            if (cmbTutor.Items.Count > 0) cmbTutor.SelectedIndex = 0;
        }
    }
}
