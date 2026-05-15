namespace Proyecto_POE.Presentacion
{
    partial class FrmAdministrador
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new System.Windows.Forms.Panel();
            lblSubtitulo = new System.Windows.Forms.Label();
            lblTitulo = new System.Windows.Forms.Label();
            pnlBotones = new System.Windows.Forms.Panel();
            btnGestionHorario = new System.Windows.Forms.Button();
            btnResultadosGestion = new System.Windows.Forms.Button();
            lblVersion = new System.Windows.Forms.Label();
            pnlHeader.SuspendLayout();
            pnlBotones.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = System.Drawing.Color.Transparent;
            pnlHeader.Controls.Add(lblSubtitulo);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            pnlHeader.Location = new System.Drawing.Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new System.Drawing.Size(680, 140);
            pnlHeader.TabIndex = 1;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.BackColor = System.Drawing.Color.Transparent;
            lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(180, 210, 255);
            lblSubtitulo.Location = new System.Drawing.Point(0, 82);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new System.Drawing.Size(680, 40);
            lblSubtitulo.TabIndex = 0;
            lblSubtitulo.Text = "Seleccione un submodulo de administracion";
            lblSubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = System.Drawing.Color.Transparent;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.White;
            lblTitulo.Location = new System.Drawing.Point(0, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new System.Drawing.Size(680, 60);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "⚙️  Modulo Administrador";
            lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBotones
            // 
            pnlBotones.BackColor = System.Drawing.Color.Transparent;
            pnlBotones.Controls.Add(btnGestionHorario);
            pnlBotones.Controls.Add(btnResultadosGestion);
            pnlBotones.Location = new System.Drawing.Point(60, 160);
            pnlBotones.Name = "pnlBotones";
            pnlBotones.Size = new System.Drawing.Size(560, 210);
            pnlBotones.TabIndex = 0;
            // 
            // btnGestionHorario
            // 
            btnGestionHorario.BackColor = System.Drawing.Color.FromArgb(255, 200, 0);
            btnGestionHorario.Cursor = System.Windows.Forms.Cursors.Hand;
            btnGestionHorario.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(100, 180, 255);
            btnGestionHorario.FlatAppearance.BorderSize = 2;
            btnGestionHorario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnGestionHorario.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            btnGestionHorario.ForeColor = System.Drawing.Color.FromArgb(15, 32, 90);
            btnGestionHorario.Location = new System.Drawing.Point(20, 20);
            btnGestionHorario.Name = "btnGestionHorario";
            btnGestionHorario.Size = new System.Drawing.Size(240, 160);
            btnGestionHorario.TabIndex = 0;
            btnGestionHorario.Text = "📅\r\n\r\nGestion de\r\nSesiones";
            btnGestionHorario.UseVisualStyleBackColor = false;
            btnGestionHorario.Click += btnGestionHorario_Click;
            // 
            // btnResultadosGestion
            // 
            btnResultadosGestion.BackColor = System.Drawing.Color.FromArgb(220, 80, 80);
            btnResultadosGestion.Cursor = System.Windows.Forms.Cursors.Hand;
            btnResultadosGestion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(80, 160, 255);
            btnResultadosGestion.FlatAppearance.BorderSize = 2;
            btnResultadosGestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnResultadosGestion.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            btnResultadosGestion.ForeColor = System.Drawing.Color.White;
            btnResultadosGestion.Location = new System.Drawing.Point(300, 20);
            btnResultadosGestion.Name = "btnResultadosGestion";
            btnResultadosGestion.Size = new System.Drawing.Size(240, 160);
            btnResultadosGestion.TabIndex = 1;
            btnResultadosGestion.Text = "📊\r\n\r\nResultados\r\nde Gestion";
            btnResultadosGestion.UseVisualStyleBackColor = false;
            btnResultadosGestion.Click += btnResultadosGestion_Click;
            // 
            // lblVersion
            // 
            lblVersion.BackColor = System.Drawing.Color.Transparent;
            lblVersion.Dock = System.Windows.Forms.DockStyle.Bottom;
            lblVersion.Font = new System.Drawing.Font("Segoe UI", 8F);
            lblVersion.ForeColor = System.Drawing.Color.FromArgb(120, 160, 220);
            lblVersion.Location = new System.Drawing.Point(0, 400);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new System.Drawing.Size(680, 30);
            lblVersion.TabIndex = 2;
            lblVersion.Text = "Modulo Administrador  —  Sistema de Tutorias POE 2026";
            lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmAdministrador
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(15, 32, 90);
            ClientSize = new System.Drawing.Size(680, 430);
            Controls.Add(pnlBotones);
            Controls.Add(pnlHeader);
            Controls.Add(lblVersion);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmAdministrador";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Sistema de Tutorias — Modulo Administrador";
            Paint += FrmAdministrador_Paint;
            pnlHeader.ResumeLayout(false);
            pnlBotones.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnGestionHorario;
        private System.Windows.Forms.Button btnResultadosGestion;
        private System.Windows.Forms.Label lblVersion;
    }
}
