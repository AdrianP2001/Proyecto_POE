using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_POE.Presentacion
{
    public partial class FrmAdministrador : Form
    {
        public FrmAdministrador()
        {
            InitializeComponent();
        }

        private void btnGestionHorario_Click(object sender, EventArgs e)
        {
            var frm = new FrmGestionSesiones();
            frm.ShowDialog();
        }

        private void btnResultadosGestion_Click(object sender, EventArgs e)
        {
            var frm = new FrmResultadosGestion();
            frm.ShowDialog();
        }

        private void btnGestionMaterias_Click(object sender, EventArgs e)
        {
            var frm = new FrmGestionMaterias();
            frm.ShowDialog();
        }

        private void btnGestionTutores_Click(object sender, EventArgs e)
        {
            var frm = new FrmGestionTutores();
            frm.ShowDialog();
        }

        // Mismo degradado de fondo que FrmMenuPrincipal
        private void FrmAdministrador_Paint(object sender, PaintEventArgs e)
        {
            if (ClientRectangle.Width == 0 || ClientRectangle.Height == 0) return;
            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(15, 32, 90),
                Color.FromArgb(36, 74, 163),
                System.Drawing.Drawing2D.LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
    }
}
