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
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Sesion nueva = new Sesion
            {
                Fecha = dtpFecha.Value,
                HoraInicio = dtpInicio.Value.TimeOfDay,
                HoraFin = dtpFin.Value.TimeOfDay,
                Ubicacion = txtUbicacion.Text
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

        private void LimpiarFormulario()
        {
            txtUbicacion.Clear();
            dtpFecha.Value = DateTime.Now;
        }
    }
}
