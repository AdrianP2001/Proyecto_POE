namespace Proyecto_POE.Presentacion
{
    partial class FrmMenuPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblSubtitulo = new Label();
            lblTitulo = new Label();
            pnlBotones = new Panel();
            btnGestionSesiones = new Button();
            btnModuloEstudiante = new Button();
            lblVersion = new Label();
            pnlHeader.SuspendLayout();
            pnlBotones.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.Transparent;
            pnlHeader.Controls.Add(lblSubtitulo);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(680, 140);
            pnlHeader.TabIndex = 1;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.BackColor = Color.Transparent;
            lblSubtitulo.Font = new Font("Segoe UI", 11F);
            lblSubtitulo.ForeColor = Color.FromArgb(180, 210, 255);
            lblSubtitulo.Location = new Point(0, 82);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(680, 40);
            lblSubtitulo.TabIndex = 0;
            lblSubtitulo.Text = "Proyecto Final POE 2026  —  Seleccione un modulo";
            lblSubtitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(0, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(680, 60);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "🎓  Sistema de Tutorias";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlBotones
            // 
            pnlBotones.BackColor = Color.Transparent;
            pnlBotones.Controls.Add(btnGestionSesiones);
            pnlBotones.Controls.Add(btnModuloEstudiante);
            pnlBotones.Location = new Point(60, 160);
            pnlBotones.Name = "pnlBotones";
            pnlBotones.Size = new Size(560, 210);
            pnlBotones.TabIndex = 0;
            // 
            // btnGestionSesiones
            // 
            btnGestionSesiones.BackColor = Color.FromArgb(255, 255, 30);
            btnGestionSesiones.Cursor = Cursors.Hand;
            btnGestionSesiones.FlatAppearance.BorderColor = Color.FromArgb(100, 180, 255);
            btnGestionSesiones.FlatAppearance.BorderSize = 2;
            btnGestionSesiones.FlatStyle = FlatStyle.Flat;
            btnGestionSesiones.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnGestionSesiones.ForeColor = Color.White;
            btnGestionSesiones.Location = new Point(20, 20);
            btnGestionSesiones.Name = "btnGestionSesiones";
            btnGestionSesiones.Size = new Size(240, 160);
            btnGestionSesiones.TabIndex = 0;
            btnGestionSesiones.Text = "📅\r\n\r\nGestion de\r\nSesiones";
            btnGestionSesiones.UseVisualStyleBackColor = false;
            btnGestionSesiones.Click += btnGestionSesiones_Click;
            // 
            // btnModuloEstudiante
            // 
            btnModuloEstudiante.BackColor = Color.FromArgb(0, 120, 215);
            btnModuloEstudiante.Cursor = Cursors.Hand;
            btnModuloEstudiante.FlatAppearance.BorderColor = Color.FromArgb(80, 160, 255);
            btnModuloEstudiante.FlatAppearance.BorderSize = 2;
            btnModuloEstudiante.FlatStyle = FlatStyle.Flat;
            btnModuloEstudiante.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnModuloEstudiante.ForeColor = Color.White;
            btnModuloEstudiante.Location = new Point(300, 20);
            btnModuloEstudiante.Name = "btnModuloEstudiante";
            btnModuloEstudiante.Size = new Size(240, 160);
            btnModuloEstudiante.TabIndex = 1;
            btnModuloEstudiante.Text = "👨‍🎓\r\n\r\nModulo\r\nEstudiante";
            btnModuloEstudiante.UseVisualStyleBackColor = false;
            btnModuloEstudiante.Click += btnModuloEstudiante_Click;
            // 
            // lblVersion
            // 
            lblVersion.BackColor = Color.Transparent;
            lblVersion.Dock = DockStyle.Bottom;
            lblVersion.Font = new Font("Segoe UI", 8F);
            lblVersion.ForeColor = Color.FromArgb(120, 160, 220);
            lblVersion.Location = new Point(0, 400);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(680, 30);
            lblVersion.TabIndex = 2;
            lblVersion.Text = "Desarrollado con C# · .NET 8 · WinForms · SQL Server";
            lblVersion.TextAlign = ContentAlignment.MiddleCenter;
            lblVersion.Click += lblVersion_Click;
            // 
            // FrmMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 32, 90);
            ClientSize = new Size(680, 430);
            Controls.Add(pnlBotones);
            Controls.Add(pnlHeader);
            Controls.Add(lblVersion);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmMenuPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Tutorias — Menu Principal";
            Load += FrmMenuPrincipal_Load;
            Paint += FrmMenuPrincipal_Paint;
            pnlHeader.ResumeLayout(false);
            pnlBotones.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnGestionSesiones;
        private System.Windows.Forms.Button btnModuloEstudiante;
        private System.Windows.Forms.Label lblVersion;
    }
}
