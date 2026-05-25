using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Proyecto_POE.Entidades;
using Proyecto_POE.Negocio;

namespace Proyecto_POE.Presentacion
{
    public partial class FrmGestionTutores : Form
    {
        private GestorTutorias _tutoriasManager = new GestorTutorias();
        private BindingSource _bindingSource = new BindingSource();

        public FrmGestionTutores()
        {
            InitializeComponent();
        }

        private void FrmGestionTutores_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            dgvTutores.DataSource = null;
            var lista = _tutoriasManager.ListarTutores();
            _bindingSource.DataSource = lista;
            dgvTutores.DataSource = _bindingSource;
        }

        private string rutaFotoTemporal = "";

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombres.Text) || string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                MessageBox.Show("Por favor, ingrese nombres y apellidos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fotoDestino = "";
            if (!string.IsNullOrEmpty(rutaFotoTemporal) && File.Exists(rutaFotoTemporal))
            {
                try
                {
                    string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                    string imgDir = Path.Combine(baseDir, "Imagenes", "Tutores");
                    if (!Directory.Exists(imgDir))
                        Directory.CreateDirectory(imgDir);
                    
                    string ext = Path.GetExtension(rutaFotoTemporal);
                    string uniqueName = "tutor_" + Guid.NewGuid().ToString() + ext;
                    string destPath = Path.Combine(imgDir, uniqueName);
                    
                    File.Copy(rutaFotoTemporal, destPath, true);
                    fotoDestino = Path.Combine("Imagenes", "Tutores", uniqueName);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error al copiar foto de tutor: " + ex.Message);
                }
            }

            var t = new Tutor
            {
                Nombres = txtNombres.Text.Trim(),
                Apellidos = txtApellidos.Text.Trim(),
                Especialidad = txtEspecialidad.Text.Trim(),
                FotoRuta = fotoDestino,
                Activo = true
            };

            try
            {
                if (_tutoriasManager.RegistrarTutor(t))
                {
                    MessageBox.Show("Tutor registrado correctamente en la base de datos.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrilla();
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("Error al registrar el tutor en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar()
        {
            txtNombres.Clear();
            txtApellidos.Clear();
            txtEspecialidad.Clear();
            picFoto.Image = null;
            rutaFotoTemporal = "";
        }

        private void btnCargarFoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Imagenes|*.jpg;*.png;*.jpeg";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    picFoto.Image = Image.FromFile(ofd.FileName);
                    rutaFotoTemporal = ofd.FileName;
                }
            }
        }
    }
}
