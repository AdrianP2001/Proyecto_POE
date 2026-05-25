using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Proyecto_POE.Entidades;
using Proyecto_POE.Negocio;

namespace Proyecto_POE.Presentacion
{
    public partial class FrmGestionTutores : Form
    {
        private GestorTutorias _tutoriasManager = new GestorTutorias();
        private BindingSource _bindingSource = new BindingSource();
        private Tutor _tutorSeleccionado = null;
        private string rutaFotoTemporal = "";

        public FrmGestionTutores()
        {
            InitializeComponent();
        }

        private void FrmGestionTutores_Load(object sender, EventArgs e)
        {
            ConfigurarControles();
            CargarGrilla();
        }

        private void ConfigurarControles()
        {
            dgvTutores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTutores.MultiSelect = false;
            dgvTutores.ReadOnly = true;
            dgvTutores.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvTutores.AutoGenerateColumns = false;
            dgvTutores.Columns.Clear();
            dgvTutores.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nombres", HeaderText = "Nombres", Name = "colNombres", Width = 150 });
            dgvTutores.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Apellidos", HeaderText = "Apellidos", Name = "colApellidos", Width = 150 });
            dgvTutores.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Especialidad", HeaderText = "Especialidad", Name = "colEspecialidad", Width = 200 });

            dgvTutores.SelectionChanged += dgvTutores_SelectionChanged;
        }

        private void CargarGrilla()
        {
            dgvTutores.SelectionChanged -= dgvTutores_SelectionChanged;
            dgvTutores.DataSource = null;
            var lista = _tutoriasManager.ListarTutores();
            _bindingSource.DataSource = lista;
            dgvTutores.DataSource = _bindingSource;
            dgvTutores.ClearSelection();
            dgvTutores.SelectionChanged += dgvTutores_SelectionChanged;
        }

        private void dgvTutores_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTutores.SelectedRows.Count > 0)
            {
                _tutorSeleccionado = dgvTutores.SelectedRows[0].DataBoundItem as Tutor;
                if (_tutorSeleccionado != null)
                {
                    txtNombres.Text = _tutorSeleccionado.Nombres;
                    txtApellidos.Text = _tutorSeleccionado.Apellidos;
                    txtEspecialidad.Text = _tutorSeleccionado.Especialidad;
                    rutaFotoTemporal = "";

                    if (picFoto.Image != null)
                    {
                        picFoto.Image.Dispose();
                        picFoto.Image = null;
                    }

                    if (!string.IsNullOrEmpty(_tutorSeleccionado.FotoRuta))
                    {
                        string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _tutorSeleccionado.FotoRuta);
                        if (File.Exists(fullPath))
                        {
                            try
                            {
                                using (var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                                {
                                    picFoto.Image = Image.FromStream(stream);
                                }
                            }
                            catch (Exception ex)
                            {
                                System.Diagnostics.Debug.WriteLine("Error al cargar la foto de disco: " + ex.Message);
                            }
                        }
                    }

                    btnGuardar.Text = "Actualizar";
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombres.Text) || string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                MessageBox.Show("Por favor, ingrese nombres y apellidos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fotoDestino = _tutorSeleccionado != null ? _tutorSeleccionado.FotoRuta : "";
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

            if (_tutorSeleccionado == null)
            {
                // Modo Registro
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
                        MessageBox.Show("Tutor registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            else
            {
                // Modo Edición
                _tutorSeleccionado.Nombres = txtNombres.Text.Trim();
                _tutorSeleccionado.Apellidos = txtApellidos.Text.Trim();
                _tutorSeleccionado.Especialidad = txtEspecialidad.Text.Trim();
                _tutorSeleccionado.FotoRuta = fotoDestino;

                try
                {
                    if (_tutoriasManager.ModificarTutor(_tutorSeleccionado))
                    {
                        MessageBox.Show("Tutor actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarGrilla();
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el tutor en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_tutorSeleccionado == null)
            {
                MessageBox.Show("Por favor, seleccione un tutor de la lista para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show($"¿Está seguro de eliminar al tutor {_tutorSeleccionado.Nombres} {_tutorSeleccionado.Apellidos}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    if (_tutoriasManager.EliminarTutor(_tutorSeleccionado.IdTutor))
                    {
                        MessageBox.Show("Tutor eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarGrilla();
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el tutor en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            txtNombres.Clear();
            txtApellidos.Clear();
            txtEspecialidad.Clear();
            if (picFoto.Image != null)
            {
                picFoto.Image.Dispose();
                picFoto.Image = null;
            }
            rutaFotoTemporal = "";
            _tutorSeleccionado = null;
            btnGuardar.Text = "Guardar";

            dgvTutores.SelectionChanged -= dgvTutores_SelectionChanged;
            dgvTutores.ClearSelection();
            dgvTutores.SelectionChanged += dgvTutores_SelectionChanged;
        }

        private void btnCargarFoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Imagenes|*.jpg;*.png;*.jpeg";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (picFoto.Image != null)
                    {
                        picFoto.Image.Dispose();
                        picFoto.Image = null;
                    }
                    try
                    {
                        using (var stream = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                        {
                            picFoto.Image = Image.FromStream(stream);
                        }
                        rutaFotoTemporal = ofd.FileName;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar la imagen seleccionada: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
