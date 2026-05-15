using System;
using System.Drawing;
using System.Windows.Forms;
using Proyecto_POE.Negocio.ResultadosGestion;

namespace Proyecto_POE.Presentacion.ResultadosGestion
{
    public partial class FrmResultadosGestion : Form
    {
        private ReporteManager manager = new ReporteManager();

        public FrmResultadosGestion()
        {
            InitializeComponent();
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            this.Text = "Resultados de Gestión e Impacto Académico";
            this.Size = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
        }

        private void FrmResultadosGestion_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            dgvResultados.DataSource = null;
            dgvResultados.DataSource = manager.ObtenerEstadisticas();
            
            if (dgvResultados.Columns["PromedioCalificacion"] != null)
                dgvResultados.Columns["PromedioCalificacion"].DefaultCellStyle.Format = "N2";
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF Files|*.pdf";
            sfd.FileName = "Informe_Gestion_" + DateTime.Now.ToString("yyyyMMdd") + ".pdf";
            sfd.Title = "Guardar Informe de Gestión";
            sfd.CheckPathExists = true;
            sfd.OverwritePrompt = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string resultado = manager.GenerarInformePDF(sfd.FileName);
                if (resultado == "OK")
                {
                    MessageBox.Show("Informe exportado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarGrilla();
        }
    }
}
