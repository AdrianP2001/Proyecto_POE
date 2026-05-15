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
            lblTitulo = new System.Windows.Forms.Label();
            btnGestionHorario = new System.Windows.Forms.Button();
            btnResultadosGestion = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.White;
            lblTitulo.Location = new System.Drawing.Point(12, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new System.Drawing.Size(460, 50);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "⚙️ Módulo Administrador";
            lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGestionHorario
            // 
            btnGestionHorario.BackColor = System.Drawing.Color.FromArgb(255, 255, 30);
            btnGestionHorario.Cursor = System.Windows.Forms.Cursors.Hand;
            btnGestionHorario.FlatAppearance.BorderSize = 0;
            btnGestionHorario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnGestionHorario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            btnGestionHorario.ForeColor = System.Drawing.Color.Black;
            btnGestionHorario.Location = new System.Drawing.Point(40, 90);
            btnGestionHorario.Name = "btnGestionHorario";
            btnGestionHorario.Size = new System.Drawing.Size(400, 80);
            btnGestionHorario.TabIndex = 1;
            btnGestionHorario.Text = "📅 Gestión de Horarios y Sesiones";
            btnGestionHorario.UseVisualStyleBackColor = false;
            btnGestionHorario.Click += btnGestionHorario_Click;
            // 
            // btnResultadosGestion
            // 
            btnResultadosGestion.BackColor = System.Drawing.Color.FromArgb(255, 100, 100);
            btnResultadosGestion.Cursor = System.Windows.Forms.Cursors.Hand;
            btnResultadosGestion.FlatAppearance.BorderSize = 0;
            btnResultadosGestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnResultadosGestion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            btnResultadosGestion.ForeColor = System.Drawing.Color.White;
            btnResultadosGestion.Location = new System.Drawing.Point(40, 190);
            btnResultadosGestion.Name = "btnResultadosGestion";
            btnResultadosGestion.Size = new System.Drawing.Size(400, 80);
            btnResultadosGestion.TabIndex = 2;
            btnResultadosGestion.Text = "📊 Resultados de Gestión y Reportes";
            btnResultadosGestion.UseVisualStyleBackColor = false;
            btnResultadosGestion.Click += btnResultadosGestion_Click;
            // 
            // FrmAdministrador
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(15, 32, 90);
            ClientSize = new System.Drawing.Size(484, 311);
            Controls.Add(btnResultadosGestion);
            Controls.Add(btnGestionHorario);
            Controls.Add(lblTitulo);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmAdministrador";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Módulo Administrador";
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnGestionHorario;
        private System.Windows.Forms.Button btnResultadosGestion;
    }
}
