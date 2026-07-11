using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Proyecto_POE.Presentacion
{
    public partial class FrmMenuPrincipal : Form
    {
        private bool _isLoggingOut = false;

        // DLLs para arrastrar formulario sin bordes
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public FrmMenuPrincipal()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.FormClosed += FrmMenuPrincipal_FormClosed;
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            // Cargar Logo de Universidad de Guayaquil
            string rootPath = AppDomain.CurrentDomain.BaseDirectory;
            string imagePath = Path.Combine(rootPath, "Imagenes", "logo_ug.png");

            // Intento alternativo por si corre en debug
            if (!File.Exists(imagePath))
            {
                var parent1 = Directory.GetParent(rootPath);
                var parent2 = parent1?.Parent;
                var parent3 = parent2?.Parent;
                if (parent3 != null)
                {
                    imagePath = Path.Combine(parent3.FullName, "Imagenes", "logo_ug.png");
                }
            }

            if (File.Exists(imagePath))
            {
                try
                {
                    picLogo.Image = Image.FromFile(imagePath);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("No se pudo cargar el logo: " + ex.Message);
                }
            }

            // Inicializar estados de los botones del módulo
            btnModuloAdministrador.BackColor = Color.FromArgb(15, 255, 255, 255);
            btnModuloEstudiante.BackColor = Color.FromArgb(15, 255, 255, 255);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            _isLoggingOut = true;
            
            // Buscar y mostrar el Login existente
            foreach (Form f in Application.OpenForms)
            {
                if (f is FrmLogin login)
                {
                    login.Show();
                    this.Close();
                    return;
                }
            }

            // Si no se encuentra (caso extraño), crear uno nuevo
            var newLogin = new FrmLogin();
            newLogin.Show();
            this.Close();
        }

        private void FrmMenuPrincipal_FormClosed(object? sender, FormClosedEventArgs e)
        {
            if (!_isLoggingOut)
            {
                Application.Exit();
            }
        }

        private void DragForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0xA1, 0x2, 0);
            }
        }

        // ============================================================
        // DISEÑO Y EFECTOS GRÁFICOS (DEGRADADOS Y GLASSMORPHISM)
        // ============================================================
        private void FrmMenuPrincipal_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Degradado de fondo premium azul universitario oscuro
            using (var brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(12, 22, 42),  // Deep Navy
                Color.FromArgb(24, 48, 82),  // Indigo UG
                LinearGradientMode.Vertical))
            {
                g.FillRectangle(brush, this.ClientRectangle);
            }

            // Dibujar detalles vectoriales abstractos de fondo
            using (var pen = new Pen(Color.FromArgb(8, 255, 255, 255), 2f))
            {
                g.DrawEllipse(pen, -150, -150, 400, 400);
                g.DrawEllipse(pen, 500, 250, 350, 350);
            }
        }

        private void btnModule_Paint(object sender, PaintEventArgs e)
        {
            Button? btn = sender as Button;
            if (btn == null) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Redondear el botón dinámicamente
            using (var path = GetRoundedRectanglePath(btn.ClientRectangle, 10))
            {
                btn.Region = new Region(path);

                // Dibujar fondo glassmorphic
                using (var bgBrush = new SolidBrush(btn.BackColor))
                {
                    g.FillPath(bgBrush, path);
                }

                // Dibujar borde brillante semi-transparente
                Color borderColor = btn.Focused ? Color.FromArgb(180, 210, 255) : Color.FromArgb(30, 255, 255, 255);
                using (var borderPen = new Pen(borderColor, 1.5f))
                {
                    g.DrawPath(borderPen, path);
                }
            }

            // Dibujar el texto y ícono manualmente
            TextRenderer.DrawText(g, btn.Text, btn.Font, btn.ClientRectangle, btn.ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak);
        }

        private void btnCerrarSesion_Paint(object sender, PaintEventArgs e)
        {
            Button? btn = sender as Button;
            if (btn == null) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (var path = GetRoundedRectanglePath(btn.ClientRectangle, 6))
            {
                btn.Region = new Region(path);
            }
        }

        private void btnModule_MouseEnter(object sender, EventArgs e)
        {
            Button? btn = sender as Button;
            if (btn == null) return;

            // Efecto de iluminación al pasar el cursor (hover)
            btn.BackColor = Color.FromArgb(35, 255, 255, 255);
            btn.ForeColor = Color.FromArgb(180, 210, 255);
            btn.Invalidate();
        }

        private void btnModule_MouseLeave(object sender, EventArgs e)
        {
            Button? btn = sender as Button;
            if (btn == null) return;

            // Retornar al estado original
            btn.BackColor = Color.FromArgb(15, 255, 255, 255);
            btn.ForeColor = Color.White;
            btn.Invalidate();
        }


        private GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            Rectangle arc = new Rectangle(rect.X, rect.Y, diameter, diameter);

            path.AddArc(arc, 180, 90);
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = rect.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = rect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
    }
}
