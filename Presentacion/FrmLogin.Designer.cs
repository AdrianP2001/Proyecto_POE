namespace Proyecto_POE.Presentacion
{
    partial class FrmLogin
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lblLeftTitle = new System.Windows.Forms.Label();
            this.lblLeftSub = new System.Windows.Forms.Label();
            this.lblFeature1 = new System.Windows.Forms.Label();
            this.lblFeature2 = new System.Windows.Forms.Label();
            this.lblFeature3 = new System.Windows.Forms.Label();
            this.lblLeftFooter = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblRightTitle = new System.Windows.Forms.Label();
            this.lblRightSub = new System.Windows.Forms.Label();
            this.pnlSelectorBg = new System.Windows.Forms.Panel();
            this.btnTabEstudiante = new System.Windows.Forms.Button();
            this.btnTabAdmin = new System.Windows.Forms.Button();
            this.pnlInput1 = new System.Windows.Forms.Panel();
            this.txtInput1 = new System.Windows.Forms.TextBox();
            this.lblInput1Placeholder = new System.Windows.Forms.Label();
            this.pnlInput2 = new System.Windows.Forms.Panel();
            this.txtInput2 = new System.Windows.Forms.TextBox();
            this.lblInput2Placeholder = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblHelpText = new System.Windows.Forms.Label();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlSelectorBg.SuspendLayout();
            this.pnlInput1.SuspendLayout();
            this.pnlInput2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(43)))), ((int)(((byte)(73)))));
            this.pnlLeft.Controls.Add(this.lblLeftTitle);
            this.pnlLeft.Controls.Add(this.lblLeftSub);
            this.pnlLeft.Controls.Add(this.lblFeature1);
            this.pnlLeft.Controls.Add(this.lblFeature2);
            this.pnlLeft.Controls.Add(this.lblFeature3);
            this.pnlLeft.Controls.Add(this.lblLeftFooter);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(340, 480);
            this.pnlLeft.TabIndex = 0;
            this.pnlLeft.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlLeft_Paint);
            this.pnlLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragForm_MouseDown);
            // 
            // lblLeftTitle
            // 
            this.lblLeftTitle.AutoSize = true;
            this.lblLeftTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblLeftTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLeftTitle.ForeColor = System.Drawing.Color.White;
            this.lblLeftTitle.Location = new System.Drawing.Point(30, 60);
            this.lblLeftTitle.Name = "lblLeftTitle";
            this.lblLeftTitle.Size = new System.Drawing.Size(277, 37);
            this.lblLeftTitle.TabIndex = 0;
            this.lblLeftTitle.Text = "Sistema de Tutorías";
            this.lblLeftTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragForm_MouseDown);
            // 
            // lblLeftSub
            // 
            this.lblLeftSub.BackColor = System.Drawing.Color.Transparent;
            this.lblLeftSub.Font = new System.Drawing.Font("Segoe UI Light", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLeftSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(215)))), ((int)(((byte)(235)))));
            this.lblLeftSub.Location = new System.Drawing.Point(32, 102);
            this.lblLeftSub.Name = "lblLeftSub";
            this.lblLeftSub.Size = new System.Drawing.Size(280, 45);
            this.lblLeftSub.TabIndex = 1;
            this.lblLeftSub.Text = "Universidad de Guayaquil\r\nPlataforma de Acompañamiento Académico";
            this.lblLeftSub.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragForm_MouseDown);
            // 
            // lblFeature1
            // 
            this.lblFeature1.AutoSize = true;
            this.lblFeature1.BackColor = System.Drawing.Color.Transparent;
            this.lblFeature1.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFeature1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(245)))));
            this.lblFeature1.Location = new System.Drawing.Point(35, 200);
            this.lblFeature1.Name = "lblFeature1";
            this.lblFeature1.Size = new System.Drawing.Size(217, 19);
            this.lblFeature1.TabIndex = 2;
            this.lblFeature1.Text = "✔   Consulta y Reserva de Horarios";
            this.lblFeature1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragForm_MouseDown);
            // 
            // lblFeature2
            // 
            this.lblFeature2.AutoSize = true;
            this.lblFeature2.BackColor = System.Drawing.Color.Transparent;
            this.lblFeature2.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFeature2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(245)))));
            this.lblFeature2.Location = new System.Drawing.Point(35, 240);
            this.lblFeature2.Name = "lblFeature2";
            this.lblFeature2.Size = new System.Drawing.Size(221, 19);
            this.lblFeature2.TabIndex = 3;
            this.lblFeature2.Text = "✔   Retroalimentación y Valoración";
            this.lblFeature2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragForm_MouseDown);
            // 
            // lblFeature3
            // 
            this.lblFeature3.AutoSize = true;
            this.lblFeature3.BackColor = System.Drawing.Color.Transparent;
            this.lblFeature3.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFeature3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(245)))));
            this.lblFeature3.Location = new System.Drawing.Point(35, 280);
            this.lblFeature3.Name = "lblFeature3";
            this.lblFeature3.Size = new System.Drawing.Size(206, 19);
            this.lblFeature3.TabIndex = 4;
            this.lblFeature3.Text = "✔   Exportación de Reportes PDF";
            this.lblFeature3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragForm_MouseDown);
            // 
            // lblLeftFooter
            // 
            this.lblLeftFooter.AutoSize = true;
            this.lblLeftFooter.BackColor = System.Drawing.Color.Transparent;
            this.lblLeftFooter.Font = new System.Drawing.Font("Segoe UI Light", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLeftFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(170)))), ((int)(((byte)(200)))));
            this.lblLeftFooter.Location = new System.Drawing.Point(32, 430);
            this.lblLeftFooter.Name = "lblLeftFooter";
            this.lblLeftFooter.Size = new System.Drawing.Size(183, 15);
            this.lblLeftFooter.TabIndex = 5;
            this.lblLeftFooter.Text = "© 2026 Facultad de Matemáticas y Física";
            this.lblLeftFooter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragForm_MouseDown);
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlRight.Controls.Add(this.btnClose);
            this.pnlRight.Controls.Add(this.btnMinimize);
            this.pnlRight.Controls.Add(this.picLogo);
            this.pnlRight.Controls.Add(this.lblRightTitle);
            this.pnlRight.Controls.Add(this.lblRightSub);
            this.pnlRight.Controls.Add(this.pnlSelectorBg);
            this.pnlRight.Controls.Add(this.pnlInput1);
            this.pnlRight.Controls.Add(this.pnlInput2);
            this.pnlRight.Controls.Add(this.lblError);
            this.pnlRight.Controls.Add(this.btnLogin);
            this.pnlRight.Controls.Add(this.lblHelpText);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(340, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(460, 480);
            this.pnlRight.TabIndex = 1;
            this.pnlRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragForm_MouseDown);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
            this.btnClose.Location = new System.Drawing.Point(415, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(45, 30);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMinimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
            this.btnMinimize.Location = new System.Drawing.Point(370, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(45, 30);
            this.btnMinimize.TabIndex = 10;
            this.btnMinimize.Text = "—";
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(195, 35);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(70, 70);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 8;
            this.picLogo.TabStop = false;
            this.picLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragForm_MouseDown);
            // 
            // lblRightTitle
            // 
            this.lblRightTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRightTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.lblRightTitle.Location = new System.Drawing.Point(0, 115);
            this.lblRightTitle.Name = "lblRightTitle";
            this.lblRightTitle.Size = new System.Drawing.Size(460, 30);
            this.lblRightTitle.TabIndex = 0;
            this.lblRightTitle.Text = "¡Bienvenido!";
            this.lblRightTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRightTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragForm_MouseDown);
            // 
            // lblRightSub
            // 
            this.lblRightSub.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRightSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(145)))));
            this.lblRightSub.Location = new System.Drawing.Point(0, 148);
            this.lblRightSub.Name = "lblRightSub";
            this.lblRightSub.Size = new System.Drawing.Size(460, 20);
            this.lblRightSub.TabIndex = 1;
            this.lblRightSub.Text = "Ingresa tus credenciales para continuar";
            this.lblRightSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRightSub.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragForm_MouseDown);
            // 
            // pnlSelectorBg
            // 
            this.pnlSelectorBg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.pnlSelectorBg.Controls.Add(this.btnTabEstudiante);
            this.pnlSelectorBg.Controls.Add(this.btnTabAdmin);
            this.pnlSelectorBg.Location = new System.Drawing.Point(60, 180);
            this.pnlSelectorBg.Name = "pnlSelectorBg";
            this.pnlSelectorBg.Size = new System.Drawing.Size(340, 40);
            this.pnlSelectorBg.TabIndex = 2;
            this.pnlSelectorBg.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSelectorBg_Paint);
            // 
            // btnTabEstudiante
            // 
            this.btnTabEstudiante.BackColor = System.Drawing.Color.Transparent;
            this.btnTabEstudiante.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabEstudiante.FlatAppearance.BorderSize = 0;
            this.btnTabEstudiante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabEstudiante.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTabEstudiante.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.btnTabEstudiante.Location = new System.Drawing.Point(3, 3);
            this.btnTabEstudiante.Name = "btnTabEstudiante";
            this.btnTabEstudiante.Size = new System.Drawing.Size(164, 34);
            this.btnTabEstudiante.TabIndex = 0;
            this.btnTabEstudiante.Text = "Estudiante";
            this.btnTabEstudiante.UseVisualStyleBackColor = false;
            this.btnTabEstudiante.Click += new System.EventHandler(this.btnTabEstudiante_Click);
            // 
            // btnTabAdmin
            // 
            this.btnTabAdmin.BackColor = System.Drawing.Color.Transparent;
            this.btnTabAdmin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabAdmin.FlatAppearance.BorderSize = 0;
            this.btnTabAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabAdmin.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTabAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(145)))));
            this.btnTabAdmin.Location = new System.Drawing.Point(173, 3);
            this.btnTabAdmin.Name = "btnTabAdmin";
            this.btnTabAdmin.Size = new System.Drawing.Size(164, 34);
            this.btnTabAdmin.TabIndex = 1;
            this.btnTabAdmin.Text = "Administrador";
            this.btnTabAdmin.UseVisualStyleBackColor = false;
            this.btnTabAdmin.Click += new System.EventHandler(this.btnTabAdmin_Click);
            // 
            // pnlInput1
            // 
            this.pnlInput1.BackColor = System.Drawing.Color.White;
            this.pnlInput1.Controls.Add(this.txtInput1);
            this.pnlInput1.Controls.Add(this.lblInput1Placeholder);
            this.pnlInput1.Location = new System.Drawing.Point(60, 245);
            this.pnlInput1.Name = "pnlInput1";
            this.pnlInput1.Size = new System.Drawing.Size(340, 45);
            this.pnlInput1.TabIndex = 3;
            this.pnlInput1.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlInput_Paint);
            // 
            // txtInput1
            // 
            this.txtInput1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInput1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtInput1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.txtInput1.Location = new System.Drawing.Point(12, 12);
            this.txtInput1.Name = "txtInput1";
            this.txtInput1.Size = new System.Drawing.Size(315, 20);
            this.txtInput1.TabIndex = 0;
            this.txtInput1.Enter += new System.EventHandler(this.txtInput_Enter);
            this.txtInput1.Leave += new System.EventHandler(this.txtInput_Leave);
            // 
            // lblInput1Placeholder
            // 
            this.lblInput1Placeholder.AutoSize = true;
            this.lblInput1Placeholder.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblInput1Placeholder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblInput1Placeholder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(160)))), ((int)(((byte)(175)))));
            this.lblInput1Placeholder.Location = new System.Drawing.Point(10, 13);
            this.lblInput1Placeholder.Name = "lblInput1Placeholder";
            this.lblInput1Placeholder.Size = new System.Drawing.Size(161, 19);
            this.lblInput1Placeholder.TabIndex = 1;
            this.lblInput1Placeholder.Text = "Número de Matrícula (ej: 2026001)";
            this.lblInput1Placeholder.Click += new System.EventHandler(this.lblPlaceholder_Click);
            // 
            // pnlInput2
            // 
            this.pnlInput2.BackColor = System.Drawing.Color.White;
            this.pnlInput2.Controls.Add(this.txtInput2);
            this.pnlInput2.Controls.Add(this.lblInput2Placeholder);
            this.pnlInput2.Location = new System.Drawing.Point(60, 305);
            this.pnlInput2.Name = "pnlInput2";
            this.pnlInput2.Size = new System.Drawing.Size(340, 45);
            this.pnlInput2.TabIndex = 4;
            this.pnlInput2.Visible = false;
            this.pnlInput2.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlInput_Paint);
            // 
            // txtInput2
            // 
            this.txtInput2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInput2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtInput2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.txtInput2.Location = new System.Drawing.Point(12, 12);
            this.txtInput2.Name = "txtInput2";
            this.txtInput2.PasswordChar = '●';
            this.txtInput2.Size = new System.Drawing.Size(315, 20);
            this.txtInput2.TabIndex = 0;
            this.txtInput2.Enter += new System.EventHandler(this.txtInput_Enter);
            this.txtInput2.Leave += new System.EventHandler(this.txtInput_Leave);
            // 
            // lblInput2Placeholder
            // 
            this.lblInput2Placeholder.AutoSize = true;
            this.lblInput2Placeholder.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblInput2Placeholder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblInput2Placeholder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(160)))), ((int)(((byte)(175)))));
            this.lblInput2Placeholder.Location = new System.Drawing.Point(10, 13);
            this.lblInput2Placeholder.Name = "lblInput2Placeholder";
            this.lblInput2Placeholder.Size = new System.Drawing.Size(79, 19);
            this.lblInput2Placeholder.TabIndex = 1;
            this.lblInput2Placeholder.Text = "Contraseña";
            this.lblInput2Placeholder.Click += new System.EventHandler(this.lblPlaceholder_Click);
            // 
            // lblError
            // 
            this.lblError.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(83)))), ((int)(((byte)(80)))));
            this.lblError.Location = new System.Drawing.Point(60, 355);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(340, 20);
            this.lblError.TabIndex = 5;
            this.lblError.Text = "Error: Matrícula no encontrada.";
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblError.Visible = false;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(43)))), ((int)(((byte)(73)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(60, 385);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(340, 45);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "Ingresar al Sistema";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            this.btnLogin.Paint += new System.Windows.Forms.PaintEventHandler(this.btnLogin_Paint);
            // 
            // lblHelpText
            // 
            this.lblHelpText.Font = new System.Drawing.Font("Segoe UI Light", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHelpText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(165)))));
            this.lblHelpText.Location = new System.Drawing.Point(60, 440);
            this.lblHelpText.Name = "lblHelpText";
            this.lblHelpText.Size = new System.Drawing.Size(340, 20);
            this.lblHelpText.TabIndex = 7;
            this.lblHelpText.Text = "Para pruebas de Estudiante usa: 20230001 o 2026001";
            this.lblHelpText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHelpText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragForm_MouseDown);
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Identificación de Usuario";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlSelectorBg.ResumeLayout(false);
            this.pnlInput1.ResumeLayout(false);
            this.pnlInput1.PerformLayout();
            this.pnlInput2.ResumeLayout(false);
            this.pnlInput2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblLeftTitle;
        private System.Windows.Forms.Label lblLeftSub;
        private System.Windows.Forms.Label lblFeature1;
        private System.Windows.Forms.Label lblFeature2;
        private System.Windows.Forms.Label lblFeature3;
        private System.Windows.Forms.Label lblLeftFooter;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblRightTitle;
        private System.Windows.Forms.Label lblRightSub;
        private System.Windows.Forms.Panel pnlSelectorBg;
        private System.Windows.Forms.Button btnTabEstudiante;
        private System.Windows.Forms.Button btnTabAdmin;
        private System.Windows.Forms.Panel pnlInput1;
        private System.Windows.Forms.TextBox txtInput1;
        private System.Windows.Forms.Label lblInput1Placeholder;
        private System.Windows.Forms.Panel pnlInput2;
        private System.Windows.Forms.TextBox txtInput2;
        private System.Windows.Forms.Label lblInput2Placeholder;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblHelpText;
    }
}
