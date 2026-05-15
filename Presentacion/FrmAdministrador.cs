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
    }
}
