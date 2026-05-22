using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_POE.Presentacion
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            // No hace falta cargar datos en el menu
        }

        private void btnModuloAdministrador_Click(object sender, EventArgs e)
        {
            var frm = new FrmAdministrador();
            frm.Show();
        }

        private void btnModuloEstudiante_Click(object sender, EventArgs e)
        {
            var frm = new FrmEstudiante();
            frm.Show();
        }

        private void FrmMenuPrincipal_Paint(object sender, PaintEventArgs e)
        {
            if (ClientRectangle.Width == 0 || ClientRectangle.Height == 0) return;
            // Degradado de fondo azul universitario
            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(15, 32, 90),
                Color.FromArgb(36, 74, 163),
                System.Drawing.Drawing2D.LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void lblVersion_Click(object sender, EventArgs e)
        {

        }
    }
}
