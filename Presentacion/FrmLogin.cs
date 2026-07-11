using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Proyecto_POE.Entidades;
using Proyecto_POE.Datos;

namespace Proyecto_POE.Presentacion
{
    public partial class FrmLogin : Form
    {
        private bool _isAdmin = false;
        private readonly EstudianteDAO _estudianteDAO = new EstudianteDAO();

        // DLLs para arrastrar formulario sin bordes
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public FrmLogin()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
        }

        private void FrmLogin_Load(object sender, EventArgs e)
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

            // Seleccionar perfil Estudiante por defecto
            SelectProfile(false);
            
            // Colocar los placeholders en posición
            ActualizarPlaceholders();
        }

        private void SelectProfile(bool admin)
        {
            _isAdmin = admin;
            lblError.Visible = false;

            if (_isAdmin)
            {
                // Estilo botón Administrador Activo
                btnTabAdmin.BackColor = Color.FromArgb(24, 43, 73);
                btnTabAdmin.ForeColor = Color.White;

                // Estilo botón Estudiante Inactivo
                btnTabEstudiante.BackColor = Color.Transparent;
                btnTabEstudiante.ForeColor = Color.FromArgb(100, 110, 125);

                // Campos
                lblInput1Placeholder.Text = "Nombre de Usuario (admin)";
                pnlInput2.Visible = true;
                lblHelpText.Text = "Credenciales por defecto: admin / admin";
            }
            else
            {
                // Estilo botón Estudiante Activo
                btnTabEstudiante.BackColor = Color.FromArgb(24, 43, 73);
                btnTabEstudiante.ForeColor = Color.White;

                // Estilo botón Administrador Inactivo
                btnTabAdmin.BackColor = Color.Transparent;
                btnTabAdmin.ForeColor = Color.FromArgb(100, 110, 125);

                // Campos
                lblInput1Placeholder.Text = "Número de Matrícula (ej: 2026001)";
                pnlInput2.Visible = false;
                txtInput2.Clear();
                lblHelpText.Text = "Para pruebas de Estudiante usa: 20230001 o 2026001";
            }

            txtInput1.Clear();
            txtInput2.Clear();
            ActualizarPlaceholders();
            pnlRight.Invalidate(true);
        }

        private void btnTabEstudiante_Click(object sender, EventArgs e)
        {
            SelectProfile(false);
        }

        private void btnTabAdmin_Click(object sender, EventArgs e)
        {
            SelectProfile(true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void DragForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0xA1, 0x2, 0);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userVal = txtInput1.Text.Trim();
            string passVal = txtInput2.Text.Trim();

            if (string.IsNullOrWhiteSpace(userVal))
            {
                ShowErrorMessage(_isAdmin ? "Ingrese el usuario." : "Ingrese su matrícula.");
                return;
            }

            if (_isAdmin)
            {
                if (string.IsNullOrWhiteSpace(passVal))
                {
                    ShowErrorMessage("Ingrese la contraseña.");
                    return;
                }

                if (userVal.ToLower() == "admin" && passVal == "admin")
                {
                    // Ingreso Admin
                    this.Hide();
                    var frmMenu = new FrmMenuPrincipal();
                    frmMenu.Show();
                }
                else
                {
                    ShowErrorMessage("Usuario o contraseña incorrectos.");
                }
            }
            else
            {
                // Ingreso Estudiante
                try
                {
                    Estudiante est = _estudianteDAO.ObtenerPorMatricula(userVal);
                    if (est != null)
                    {
                        this.Hide();
                        var frmEst = new FrmEstudiante();
                        frmEst.EstudianteActual = est;
                        frmEst.FormClosed += (s, args) => this.Close();
                        frmEst.Show();
                    }
                    else
                    {
                        ShowErrorMessage("Matrícula no registrada o inactiva.");
                    }
                }
                catch (Exception ex)
                {
                    ShowErrorMessage("Error al conectar con la BD: " + ex.Message);
                }
            }
        }

        private void ShowErrorMessage(string message)
        {
            lblError.Text = "⚠  " + message;
            lblError.Visible = true;
        }

        // ============================================================
        // EFECTOS VISUALES Y DISEÑO PERSONALIZADO (CERO IA RÍGIDA)
        // ============================================================
        private void pnlLeft_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Degradado de fondo premium azul universitario
            using (var brush = new LinearGradientBrush(
                pnlLeft.ClientRectangle,
                Color.FromArgb(16, 28, 54),  // Azul oscuro noche
                Color.FromArgb(32, 60, 99),  // Indigo UG
                LinearGradientMode.Vertical))
            {
                g.FillRectangle(brush, pnlLeft.ClientRectangle);
            }

            // Dibujar círculos decorativos sutiles para darle dinamismo
            using (var pen = new Pen(Color.FromArgb(15, 255, 255, 255), 1.5f))
            {
                g.DrawEllipse(pen, -100, -100, 300, 300);
                g.DrawEllipse(pen, -50, -50, 200, 200);
            }

            using (var path = new GraphicsPath())
            {
                path.AddEllipse(200, 350, 250, 250);
                using (var pathBrush = new PathGradientBrush(path))
                {
                    pathBrush.CenterColor = Color.FromArgb(20, 100, 180, 255);
                    pathBrush.SurroundColors = new Color[] { Color.Transparent };
                    g.FillPath(pathBrush, path);
                }
            }
        }

        private void pnlSelectorBg_Paint(object sender, PaintEventArgs e)
        {
            // Bordes suaves y redondeados del selector
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = GetRoundedRectanglePath(pnlSelectorBg.ClientRectangle, 6))
            {
                using (var brush = new SolidBrush(Color.FromArgb(235, 240, 245)))
                {
                    g.FillPath(brush, path);
                }
            }
        }

        private void pnlInput_Paint(object sender, PaintEventArgs e)
        {
            Panel? pnl = sender as Panel;
            if (pnl == null) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            TextBox? txt = pnl.Controls.Count > 0 ? pnl.Controls[0] as TextBox : null;
            bool isFocused = txt != null && txt.Focused;

            // Dibujar fondo redondeado
            using (var path = GetRoundedRectanglePath(pnl.ClientRectangle, 5))
            {
                using (var bgBrush = new SolidBrush(Color.White))
                {
                    g.FillPath(bgBrush, path);
                }

                // Borde activo (Navy) o inactivo (Gris suave)
                Color borderColor = isFocused ? Color.FromArgb(24, 43, 73) : Color.FromArgb(215, 222, 230);
                int borderWidth = isFocused ? 2 : 1;

                using (var borderPen = new Pen(borderColor, borderWidth))
                {
                    g.DrawPath(borderPen, path);
                }
            }
        }

        private void btnLogin_Paint(object sender, PaintEventArgs e)
        {
            // Redondear el botón de login
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (var path = GetRoundedRectanglePath(btnLogin.ClientRectangle, 6))
            {
                btnLogin.Region = new Region(path);
            }
        }

        private GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            Rectangle arc = new Rectangle(rect.X, rect.Y, diameter, diameter);

            // Top Left
            path.AddArc(arc, 180, 90);
            // Top Right
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 90);
            // Bottom Right
            arc.Y = rect.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            // Bottom Left
            arc.X = rect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        // ============================================================
        // ACCIONES DE PLACEHOLDERS E INPUTS
        // ============================================================
        private void ActualizarPlaceholders()
        {
            lblInput1Placeholder.Visible = string.IsNullOrEmpty(txtInput1.Text);
            lblInput2Placeholder.Visible = string.IsNullOrEmpty(txtInput2.Text);
        }

        private void txtInput_Enter(object sender, EventArgs e)
        {
            TextBox? txt = sender as TextBox;
            if (txt == null) return;

            Panel? parent = txt.Parent as Panel;
            if (parent != null) parent.Invalidate();

            ActualizarPlaceholders();
        }

        private void txtInput_Leave(object sender, EventArgs e)
        {
            TextBox? txt = sender as TextBox;
            if (txt == null) return;

            Panel? parent = txt.Parent as Panel;
            if (parent != null) parent.Invalidate();

            ActualizarPlaceholders();
        }

        private void lblPlaceholder_Click(object sender, EventArgs e)
        {
            Label? lbl = sender as Label;
            if (lbl == null) return;

            Panel? parent = lbl.Parent as Panel;
            if (parent != null && parent.Controls.Count > 0)
            {
                TextBox? txt = parent.Controls[0] as TextBox;
                if (txt != null) txt.Focus();
            }
        }
    }
}
