namespace Proyecto_POE.Presentacion.GestionMaterias
{
    partial class FrmGestionMaterias
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            lblTitulo = new Label();
            lblMateria = new Label();
            txtMateria = new TextBox();
            lblFacultad = new Label();
            txtFacultad = new TextBox();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            cmbArea = new ComboBox();
            dtpFecha = new DateTimePicker();
            rbPresencial = new RadioButton();
            lblModalidad = new Label();
            rbVirtual = new RadioButton();
            chkLunes = new CheckBox();
            lblFecha = new Label();
            lblDias = new Label();
            chkMiercoles = new CheckBox();
            chkViernes = new CheckBox();
            listBox1 = new ListBox();
            pictureBox1 = new PictureBox();
            lblArea = new Label();
            lblLista = new Label();
            btnImagen = new Button();
            btnGuardar = new Button();
            btnLimpiar = new Button();
            btnEliminar = new Button();
            dgvMaterias = new DataGridView();
            pnlSidebar = new Panel();
            pnlMain = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMaterias).BeginInit();
            pnlSidebar.SuspendLayout();
            pnlMain.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.MidnightBlue;
            lblTitulo.Location = new Point(12, 10);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(227, 60);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "REGISTRO DE \r\nCÉLULAS DE ESTUDIO\r\n";
            // 
            // lblMateria
            // 
            lblMateria.AutoSize = true;
            lblMateria.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblMateria.Location = new Point(12, 85);
            lblMateria.Margin = new Padding(4, 0, 4, 0);
            lblMateria.Name = "lblMateria";
            lblMateria.Size = new Size(125, 15);
            lblMateria.TabIndex = 1;
            lblMateria.Text = "Nombre de la Materia:";
            // 
            // txtMateria
            // 
            txtMateria.BorderStyle = BorderStyle.FixedSingle;
            txtMateria.Font = new Font("Segoe UI", 9F);
            txtMateria.Location = new Point(12, 105);
            txtMateria.Margin = new Padding(4);
            txtMateria.Name = "txtMateria";
            txtMateria.Size = new Size(250, 23);
            txtMateria.TabIndex = 2;
            // 
            // lblFacultad
            // 
            lblFacultad.AutoSize = true;
            lblFacultad.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblFacultad.Location = new Point(12, 140);
            lblFacultad.Margin = new Padding(4, 0, 4, 0);
            lblFacultad.Name = "lblFacultad";
            lblFacultad.Size = new Size(55, 15);
            lblFacultad.TabIndex = 3;
            lblFacultad.Text = "Facultad:";
            // 
            // txtFacultad
            // 
            txtFacultad.BorderStyle = BorderStyle.FixedSingle;
            txtFacultad.Font = new Font("Segoe UI", 9F);
            txtFacultad.Location = new Point(12, 160);
            txtFacultad.Margin = new Padding(4);
            txtFacultad.Name = "txtFacultad";
            txtFacultad.Size = new Size(250, 23);
            txtFacultad.TabIndex = 4;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblDescripcion.ForeColor = Color.MidnightBlue;
            lblDescripcion.Location = new Point(12, 450);
            lblDescripcion.Margin = new Padding(4, 0, 4, 0);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(124, 15);
            lblDescripcion.TabIndex = 5;
            lblDescripcion.Text = "Descripción de temas:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.BorderStyle = BorderStyle.FixedSingle;
            txtDescripcion.Font = new Font("Segoe UI", 9F);
            txtDescripcion.Location = new Point(12, 470);
            txtDescripcion.Margin = new Padding(4);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(250, 100);
            txtDescripcion.TabIndex = 6;
            // 
            // cmbArea
            // 
            cmbArea.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbArea.Font = new Font("Segoe UI", 9F);
            cmbArea.FormattingEnabled = true;
            cmbArea.Location = new Point(12, 215);
            cmbArea.Margin = new Padding(4);
            cmbArea.Name = "cmbArea";
            cmbArea.Size = new Size(250, 23);
            cmbArea.TabIndex = 7;
            // 
            // dtpFecha
            // 
            dtpFecha.Font = new Font("Segoe UI", 9F);
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(12, 270);
            dtpFecha.Margin = new Padding(4);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(120, 23);
            dtpFecha.TabIndex = 8;
            // 
            // rbPresencial
            // 
            rbPresencial.AutoSize = true;
            rbPresencial.Font = new Font("Segoe UI", 9F);
            rbPresencial.Location = new Point(15, 325);
            rbPresencial.Margin = new Padding(4);
            rbPresencial.Name = "rbPresencial";
            rbPresencial.Size = new Size(78, 19);
            rbPresencial.TabIndex = 9;
            rbPresencial.TabStop = true;
            rbPresencial.Text = "Presencial";
            rbPresencial.UseVisualStyleBackColor = true;
            // 
            // lblModalidad
            // 
            lblModalidad.AutoSize = true;
            lblModalidad.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblModalidad.ForeColor = Color.MidnightBlue;
            lblModalidad.Location = new Point(12, 305);
            lblModalidad.Margin = new Padding(4, 0, 4, 0);
            lblModalidad.Name = "lblModalidad";
            lblModalidad.Size = new Size(67, 15);
            lblModalidad.TabIndex = 10;
            lblModalidad.Text = "Modalidad:";
            // 
            // rbVirtual
            // 
            rbVirtual.AutoSize = true;
            rbVirtual.Font = new Font("Segoe UI", 9F);
            rbVirtual.Location = new Point(100, 325);
            rbVirtual.Margin = new Padding(4);
            rbVirtual.Name = "rbVirtual";
            rbVirtual.Size = new Size(59, 19);
            rbVirtual.TabIndex = 11;
            rbVirtual.TabStop = true;
            rbVirtual.Text = "Virtual";
            rbVirtual.UseVisualStyleBackColor = true;
            // 
            // chkLunes
            // 
            chkLunes.AutoSize = true;
            chkLunes.Font = new Font("Segoe UI", 9F);
            chkLunes.Location = new Point(15, 380);
            chkLunes.Margin = new Padding(4);
            chkLunes.Name = "chkLunes";
            chkLunes.Size = new Size(57, 19);
            chkLunes.TabIndex = 12;
            chkLunes.Text = "Lunes";
            chkLunes.UseVisualStyleBackColor = true;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblFecha.Location = new Point(12, 250);
            lblFecha.Margin = new Padding(4, 0, 4, 0);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(100, 15);
            lblFecha.TabIndex = 13;
            lblFecha.Text = "Fecha de registro:";
            // 
            // lblDias
            // 
            lblDias.AutoSize = true;
            lblDias.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblDias.ForeColor = Color.MidnightBlue;
            lblDias.Location = new Point(12, 360);
            lblDias.Margin = new Padding(4, 0, 4, 0);
            lblDias.Name = "lblDias";
            lblDias.Size = new Size(96, 15);
            lblDias.TabIndex = 14;
            lblDias.Text = "Días disponibles:";
            // 
            // chkMiercoles
            // 
            chkMiercoles.AutoSize = true;
            chkMiercoles.Font = new Font("Segoe UI", 9F);
            chkMiercoles.Location = new Point(80, 380);
            chkMiercoles.Margin = new Padding(4);
            chkMiercoles.Name = "chkMiercoles";
            chkMiercoles.Size = new Size(77, 19);
            chkMiercoles.TabIndex = 15;
            chkMiercoles.Text = "Miércoles";
            chkMiercoles.UseVisualStyleBackColor = true;
            // 
            // chkViernes
            // 
            chkViernes.AutoSize = true;
            chkViernes.Font = new Font("Segoe UI", 9F);
            chkViernes.Location = new Point(165, 380);
            chkViernes.Margin = new Padding(4);
            chkViernes.Name = "chkViernes";
            chkViernes.Size = new Size(64, 19);
            chkViernes.TabIndex = 16;
            chkViernes.Text = "Viernes";
            chkViernes.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            listBox1.Font = new Font("Segoe UI", 9F);
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(515, 315);
            listBox1.Margin = new Padding(4);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(200, 154);
            listBox1.TabIndex = 17;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(20, 20);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 200);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 18;
            pictureBox1.TabStop = false;
            // 
            // lblArea
            // 
            lblArea.AutoSize = true;
            lblArea.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblArea.Location = new Point(12, 195);
            lblArea.Margin = new Padding(4, 0, 4, 0);
            lblArea.Name = "lblArea";
            lblArea.Size = new Size(96, 15);
            lblArea.TabIndex = 20;
            lblArea.Text = "Área Académica:";
            // 
            // lblLista
            // 
            lblLista.AutoSize = true;
            lblLista.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblLista.ForeColor = Color.MidnightBlue;
            lblLista.Location = new Point(515, 295);
            lblLista.Name = "lblLista";
            lblLista.Size = new Size(95, 15);
            lblLista.TabIndex = 22;
            lblLista.Text = "Lista de Materias";
            // 
            // btnImagen
            // 
            btnImagen.BackColor = Color.AliceBlue;
            btnImagen.FlatStyle = FlatStyle.Flat;
            btnImagen.Font = new Font("Segoe UI", 9F);
            btnImagen.Location = new Point(20, 227);
            btnImagen.Name = "btnImagen";
            btnImagen.Size = new Size(200, 30);
            btnImagen.TabIndex = 23;
            btnImagen.Text = " Cargar Imagen";
            btnImagen.UseVisualStyleBackColor = false;
            btnImagen.Click += btnImagen_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGuardar.Location = new Point(250, 20);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 40);
            btnGuardar.TabIndex = 24;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLimpiar.Location = new Point(250, 70);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(100, 40);
            btnLimpiar.TabIndex = 25;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEliminar.Location = new Point(250, 120);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 40);
            btnEliminar.TabIndex = 26;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dgvMaterias
            // 
            dgvMaterias.AllowUserToAddRows = false;
            dgvMaterias.AllowUserToDeleteRows = false;
            dgvMaterias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMaterias.BackgroundColor = Color.White;
            dgvMaterias.BorderStyle = BorderStyle.None;
            dgvMaterias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = Color.LightSteelBlue;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvMaterias.DefaultCellStyle = dataGridViewCellStyle1;
            dgvMaterias.Location = new Point(20, 295);
            dgvMaterias.Name = "dgvMaterias";
            dgvMaterias.ReadOnly = true;
            dgvMaterias.RowHeadersVisible = false;
            dgvMaterias.Size = new Size(475, 175);
            dgvMaterias.TabIndex = 27;
            dgvMaterias.CellClick += dgvMaterias_CellClick;
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.WhiteSmoke;
            pnlSidebar.Controls.Add(lblTitulo);
            pnlSidebar.Controls.Add(lblMateria);
            pnlSidebar.Controls.Add(txtMateria);
            pnlSidebar.Controls.Add(lblFacultad);
            pnlSidebar.Controls.Add(txtFacultad);
            pnlSidebar.Controls.Add(lblArea);
            pnlSidebar.Controls.Add(cmbArea);
            pnlSidebar.Controls.Add(lblFecha);
            pnlSidebar.Controls.Add(dtpFecha);
            pnlSidebar.Controls.Add(lblModalidad);
            pnlSidebar.Controls.Add(rbPresencial);
            pnlSidebar.Controls.Add(rbVirtual);
            pnlSidebar.Controls.Add(lblDias);
            pnlSidebar.Controls.Add(chkLunes);
            pnlSidebar.Controls.Add(chkMiercoles);
            pnlSidebar.Controls.Add(chkViernes);
            pnlSidebar.Controls.Add(lblDescripcion);
            pnlSidebar.Controls.Add(txtDescripcion);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(280, 500);
            pnlSidebar.TabIndex = 28;
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(pictureBox1);
            pnlMain.Controls.Add(btnImagen);
            pnlMain.Controls.Add(btnGuardar);
            pnlMain.Controls.Add(btnLimpiar);
            pnlMain.Controls.Add(btnEliminar);
            pnlMain.Controls.Add(dgvMaterias);
            pnlMain.Controls.Add(lblLista);
            pnlMain.Controls.Add(listBox1);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(280, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(750, 500);
            pnlMain.TabIndex = 29;
            // 
            // FrmGestionMaterias
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1030, 500);
            Controls.Add(pnlMain);
            Controls.Add(pnlSidebar);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FrmGestionMaterias";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Células de Estudio";
            Load += FrmGestionMaterias_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMaterias).EndInit();
            pnlSidebar.ResumeLayout(false);
            pnlSidebar.PerformLayout();
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private Panel pnlMain;
        private Label lblTitulo;
        private Label lblMateria;
        private TextBox txtMateria;
        private Label lblFacultad;
        private TextBox txtFacultad;
        private Label lblDescripcion;
        private TextBox txtDescripcion;
        private ComboBox cmbArea;
        private DateTimePicker dtpFecha;
        private RadioButton rbPresencial;
        private Label lblModalidad;
        private RadioButton rbVirtual;
        private CheckBox chkLunes;
        private Label lblFecha;
        private Label lblDias;
        private CheckBox chkMiercoles;
        private CheckBox chkViernes;
        private ListBox listBox1;
        private PictureBox pictureBox1;
        private Label lblArea;
        private Label lblLista;
        private Button btnImagen;
        private Button btnGuardar;
        private Button btnLimpiar;
        private Button btnEliminar;
        private DataGridView dgvMaterias;
    }
}
