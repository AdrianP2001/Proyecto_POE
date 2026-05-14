namespace TutoriasApp.Presentacion
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnGestionSesiones = new System.Windows.Forms.Button();
            this.btnModuloEstudiante = new System.Windows.Forms.Button();
            this.lblVersion = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.Controls.Add(this.lblSubtitulo);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(680, 140);

            // lblTitulo
            this.lblTitulo.AutoSize = false;
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.None;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(680, 60);
            this.lblTitulo.Text = "🎓  Sistema de Tutorías";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblSubtitulo
            this.lblSubtitulo.AutoSize = false;
            this.lblSubtitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(180, 210, 255);
            this.lblSubtitulo.Location = new System.Drawing.Point(0, 82);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(680, 40);
            this.lblSubtitulo.Text = "Proyecto Final POE 2026  —  Seleccione un módulo";
            this.lblSubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // pnlBotones
            this.pnlBotones.BackColor = System.Drawing.Color.Transparent;
            this.pnlBotones.Controls.Add(this.btnGestionSesiones);
            this.pnlBotones.Controls.Add(this.btnModuloEstudiante);
            this.pnlBotones.Location = new System.Drawing.Point(60, 160);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(560, 210);

            // btnGestionSesiones
            this.btnGestionSesiones.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 30);
            this.btnGestionSesiones.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(100, 180, 255);
            this.btnGestionSesiones.FlatAppearance.BorderSize = 2;
            this.btnGestionSesiones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestionSesiones.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnGestionSesiones.ForeColor = System.Drawing.Color.White;
            this.btnGestionSesiones.Location = new System.Drawing.Point(20, 20);
            this.btnGestionSesiones.Name = "btnGestionSesiones";
            this.btnGestionSesiones.Size = new System.Drawing.Size(240, 160);
            this.btnGestionSesiones.Text = "📅\r\n\r\nGestión de\r\nSesiones";
            this.btnGestionSesiones.UseVisualStyleBackColor = false;
            this.btnGestionSesiones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGestionSesiones.Click += new System.EventHandler(this.btnGestionSesiones_Click);

            // btnModuloEstudiante
            this.btnModuloEstudiante.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnModuloEstudiante.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(80, 160, 255);
            this.btnModuloEstudiante.FlatAppearance.BorderSize = 2;
            this.btnModuloEstudiante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModuloEstudiante.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnModuloEstudiante.ForeColor = System.Drawing.Color.White;
            this.btnModuloEstudiante.Location = new System.Drawing.Point(300, 20);
            this.btnModuloEstudiante.Name = "btnModuloEstudiante";
            this.btnModuloEstudiante.Size = new System.Drawing.Size(240, 160);
            this.btnModuloEstudiante.Text = "👨‍🎓\r\n\r\nMódulo\r\nEstudiante";
            this.btnModuloEstudiante.UseVisualStyleBackColor = false;
            this.btnModuloEstudiante.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModuloEstudiante.Click += new System.EventHandler(this.btnModuloEstudiante_Click);

            // lblVersion
            this.lblVersion.AutoSize = false;
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(120, 160, 220);
            this.lblVersion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(680, 30);
            this.lblVersion.Text = "Desarrollado con C# · .NET 8 · WinForms · SQL Server";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // FrmMenuPrincipal
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(15, 32, 90);
            this.ClientSize = new System.Drawing.Size(680, 430);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.lblVersion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Tutorías — Menú Principal";
            this.Load += new System.EventHandler(this.FrmMenuPrincipal_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmMenuPrincipal_Paint);
            this.pnlHeader.ResumeLayout(false);
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);
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
