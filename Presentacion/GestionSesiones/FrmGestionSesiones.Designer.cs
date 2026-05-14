namespace Proyecto_POE.Presentacion.GestionSesiones
{
    partial class FrmGestionSesiones
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dtpFecha = new DateTimePicker();
            dtpInicio = new DateTimePicker();
            dtpFin = new DateTimePicker();
            txtUbicacion = new TextBox();
            btnGuardar = new Button();
            dgvSesiones = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSesiones).BeginInit();
            SuspendLayout();
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(134, 35);
            dtpFecha.Margin = new Padding(4, 3, 4, 3);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(139, 23);
            dtpFecha.TabIndex = 0;
            // 
            // dtpInicio
            // 
            dtpInicio.Format = DateTimePickerFormat.Time;
            dtpInicio.Location = new Point(134, 75);
            dtpInicio.Margin = new Padding(4, 3, 4, 3);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.ShowUpDown = true;
            dtpInicio.Size = new Size(139, 23);
            dtpInicio.TabIndex = 1;
            // 
            // dtpFin
            // 
            dtpFin.Format = DateTimePickerFormat.Time;
            dtpFin.Location = new Point(134, 115);
            dtpFin.Margin = new Padding(4, 3, 4, 3);
            dtpFin.Name = "dtpFin";
            dtpFin.ShowUpDown = true;
            dtpFin.Size = new Size(139, 23);
            dtpFin.TabIndex = 2;
            // 
            // txtUbicacion
            // 
            txtUbicacion.Location = new Point(188, 154);
            txtUbicacion.Margin = new Padding(4, 3, 4, 3);
            txtUbicacion.Name = "txtUbicacion";
            txtUbicacion.Size = new Size(233, 23);
            txtUbicacion.TabIndex = 3;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(134, 202);
            btnGuardar.Margin = new Padding(4, 3, 4, 3);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(140, 35);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar Sesión";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // dgvSesiones
            // 
            dgvSesiones.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSesiones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSesiones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSesiones.Location = new Point(35, 254);
            dgvSesiones.Margin = new Padding(4, 3, 4, 3);
            dgvSesiones.Name = "dgvSesiones";
            dgvSesiones.Size = new Size(630, 208);
            dgvSesiones.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 40);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 6;
            label1.Text = "Fecha:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 81);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(68, 15);
            label2.TabIndex = 7;
            label2.Text = "Hora Inicio:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(35, 121);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 8;
            label3.Text = "Hora Fin:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(35, 162);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(145, 15);
            label4.TabIndex = 9;
            label4.Text = "Ubicación / Enlace Virtual:";
            // 
            // FrmGestionSesiones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 496);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvSesiones);
            Controls.Add(btnGuardar);
            Controls.Add(txtUbicacion);
            Controls.Add(dtpFin);
            Controls.Add(dtpInicio);
            Controls.Add(dtpFecha);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FrmGestionSesiones";
            Text = "Proyecto FINAL - Gestión de Horarios y Sesiones";
            Load += FrmGestionSesiones_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSesiones).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.TextBox txtUbicacion;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dgvSesiones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
