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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombres.Text) || string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                MessageBox.Show("Por favor, ingrese nombres y apellidos.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var t = new Tutor
            {
                Nombres = txtNombres.Text.Trim(),
                Apellidos = txtApellidos.Text.Trim(),
                Especialidad = txtEspecialidad.Text.Trim(),
                Activo = true
            };

            // Nota: Aquí se debería llamar a un método Insertar en el DAO/Negocio
            // Por ahora simulamos el éxito si el manager lo permite o agregamos a la lista
            MessageBox.Show("Tutor registrado correctamente (Simulado).", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarGrilla();
            Limpiar();
        }

        private void Limpiar()
        {
            txtNombres.Clear();
            txtApellidos.Clear();
            txtEspecialidad.Clear();
            picFoto.Image = null;
        }

        private void btnCargarFoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Imagenes|*.jpg;*.png;*.jpeg";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    picFoto.Image = Image.FromFile(ofd.FileName);
                }
            }
        }
    }
}
