using System;
using System.Drawing;
using System.Windows.Forms;
using Proyecto_POE.Presentacion.GestionSesiones;
using Proyecto_POE.Presentacion.ResultadosGestion;

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

        // Mismo degradado de fondo que FrmMenuPrincipal
        private void FrmAdministrador_Paint(object sender, PaintEventArgs e)
        {
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
