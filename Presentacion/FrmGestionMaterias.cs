using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Proyecto_POE.Entidades;
using Proyecto_POE.Datos;

namespace Proyecto_POE.Presentacion
{
    public partial class FrmGestionMaterias : Form
    {
        private AsignaturaDAO _asignaturaDAO = new AsignaturaDAO();
        private BindingList<Asignatura> _bindingList;

        public FrmGestionMaterias()
        {
            InitializeComponent();
            _bindingList = new BindingList<Asignatura>();
        }

        private void FrmGestionMaterias_Load(object sender, EventArgs e)
        {
            ConfigurarControles();
            CargarDatos();
            ConfigurarEventosEstilo();
        }

        private void CargarDatos()
        {
            var lista = _asignaturaDAO.ObtenerTodas();
            _bindingList = new BindingList<Asignatura>(lista);
            dgvMaterias.DataSource = _bindingList;
            listBox1.DataSource = _bindingList;
            listBox1.DisplayMember = "Nombre";
        }

        private void ConfigurarControles()
        {
            // Limpiar y cargar áreas
            cmbArea.Items.Clear();
            cmbArea.Items.AddRange(new string[] { "Exactas", "Sociales", "Salud", "Ingeniería", "Educación", "Artes" });
            cmbArea.SelectedIndex = -1;

            // Configurar DataGridView
            dgvMaterias.AutoGenerateColumns = false;
            dgvMaterias.Columns.Clear();
            dgvMaterias.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = "Materia", Name = "colNombre" });
            dgvMaterias.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Facultad", HeaderText = "Facultad", Name = "colFacultad" });
            dgvMaterias.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Area", HeaderText = "Área", Name = "colArea" });
            dgvMaterias.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Modalidad", HeaderText = "Modalidad", Name = "colModalidad" });

            dgvMaterias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMaterias.MultiSelect = false;
            dgvMaterias.ReadOnly = true;
            dgvMaterias.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;

            // Evento para cambio automático de imagen
            cmbArea.SelectedIndexChanged += cmbArea_SelectedIndexChanged;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is Asignatura m)
            {
                MostrarDetalles(m);
            }
        }

        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbArea.SelectedIndex == -1) return;
            string area = cmbArea.SelectedItem?.ToString() ?? "";
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string assetsPath = Path.Combine(baseDir, "Imagenes");

            // Limpiar imagen anterior para evitar confusión si falla la carga
            pictureBox1.Image = null;

            try
            {
                switch (area)
                {
                    case "Sociales": CargarImagenSafe(Path.Combine(assetsPath, "sociales.png")); break;
                    case "Salud": CargarImagenSafe(Path.Combine(assetsPath, "salud.png")); break;
                    case "Ingeniería": CargarImagenSafe(Path.Combine(assetsPath, "ingenieria.png")); break;
                    case "Educación": CargarImagenSafe(Path.Combine(assetsPath, "educacion.png")); break;
                    case "Artes": CargarImagenSafe(Path.Combine(assetsPath, "artes.png")); break;
                    case "Exactas": pictureBox1.LoadAsync("https://images.unsplash.com/photo-1635070041078-e363dbe005cb?q=80&w=400"); break;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al cargar imagen: " + ex.Message);
            }
        }

        private void CargarImagenSafe(string path)
        {
            if (File.Exists(path))
            {
                using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    pictureBox1.Image = Image.FromStream(stream);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            Asignatura nueva = new Asignatura
            {
                Codigo = Guid.NewGuid().ToString().Substring(0, 8).ToUpper(), 
                Nombre = txtMateria.Text.Trim(),
                Facultad = txtFacultad.Text.Trim(),
                Area = cmbArea.SelectedItem?.ToString() ?? "",
                Descripcion = txtDescripcion.Text.Trim(),
                Modalidad = rbPresencial.Checked ? "Presencial" : "Virtual"
            };

            if (_asignaturaDAO.Insertar(nueva))
            {
                MessageBox.Show("Materia registrada en base de datos.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();
                LimpiarFormulario();
            }
            else
            {
                MessageBox.Show("Error al guardar en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtMateria.Text)) return false;
            if (cmbArea.SelectedIndex == -1) return false;
            return true;
        }

        private void LimpiarFormulario()
        {
            txtMateria.Clear();
            txtFacultad.Clear();
            txtDescripcion.Clear();
            cmbArea.SelectedIndex = -1;
            rbPresencial.Checked = false;
            rbVirtual.Checked = false;
        }

        private void ConfigurarEventosEstilo()
        {
            btnGuardar.MouseEnter += (s, e) => btnGuardar.BackColor = Color.LightGreen;
            btnGuardar.MouseLeave += (s, e) => btnGuardar.BackColor = SystemColors.Control;
        }

        private void btnLimpiar_Click(object sender, EventArgs e) => LimpiarFormulario();

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMaterias.CurrentRow != null && dgvMaterias.CurrentRow.DataBoundItem is Asignatura a)
            {
                var confirm = MessageBox.Show($"¿Está seguro de eliminar la materia '{a.Nombre}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        if (_asignaturaDAO.Eliminar(a.IdAsignatura))
                        {
                            MessageBox.Show("Materia eliminada de la base de datos.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarDatos();
                            LimpiarFormulario();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar la materia de la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog abrir = new OpenFileDialog())
            {
                abrir.Filter = "Archivos de imagen|*.jpg;*.png;*.jpeg";
                if (abrir.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(abrir.FileName);
                }
            }
        }

        private void dgvMaterias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMaterias.CurrentRow != null) MostrarDetalles((Asignatura)dgvMaterias.CurrentRow.DataBoundItem);
        }

        private void MostrarDetalles(Asignatura m)
        {
            txtMateria.Text = m.Nombre;
            txtFacultad.Text = m.Facultad;
            cmbArea.SelectedItem = m.Area;
            txtDescripcion.Text = m.Descripcion;
            rbPresencial.Checked = (m.Modalidad == "Presencial");
            rbVirtual.Checked = (m.Modalidad == "Virtual");
        }
    }
}
