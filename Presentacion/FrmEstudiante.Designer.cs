namespace Proyecto_POE.Presentacion
{
    partial class FrmEstudiante
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
            this.tabControlPrincipal = new System.Windows.Forms.TabControl();
            this.tabTutorias = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstGrupos = new System.Windows.Forms.ListBox();
            this.lblTituloGrupos = new System.Windows.Forms.Label();
            this.txtDescripcionGrupo = new System.Windows.Forms.TextBox();
            this.lblNombreMateria = new System.Windows.Forms.Label();
            this.groupBoxRecursos = new System.Windows.Forms.GroupBox();
            this.lstRecursos = new System.Windows.Forms.ListBox();
            this.groupBoxHorarios = new System.Windows.Forms.GroupBox();
            this.lstHorarios = new System.Windows.Forms.ListBox();
            this.groupBoxTutores = new System.Windows.Forms.GroupBox();
            this.lstTutores = new System.Windows.Forms.ListBox();
            this.tabCalendario = new System.Windows.Forms.TabPage();
            this.dgvCalendario = new System.Windows.Forms.DataGridView();
            this.panelFiltro = new System.Windows.Forms.Panel();
            this.cmbFacultadFiltro = new System.Windows.Forms.ComboBox();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.tabGaleria = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.flowGaleria = new System.Windows.Forms.FlowLayoutPanel();
            this.lblGaleriaMensaje = new System.Windows.Forms.Label();
            this.lblDescripcionFoto = new System.Windows.Forms.Label();
            this.picVistaPrevia = new System.Windows.Forms.PictureBox();
            this.tabFeedback = new System.Windows.Forms.TabPage();
            this.groupBoxVotacion = new System.Windows.Forms.GroupBox();
            this.lblTutorDelMesPromedio = new System.Windows.Forms.Label();
            this.lblTutorDelMesEspecialidad = new System.Windows.Forms.Label();
            this.lblTutorDelMesNombre = new System.Windows.Forms.Label();
            this.lblTituloTutorDelMes = new System.Windows.Forms.Label();
            this.btnVotar = new System.Windows.Forms.Button();
            this.rb5Estrellas = new System.Windows.Forms.RadioButton();
            this.rb4Estrellas = new System.Windows.Forms.RadioButton();
            this.rb3Estrellas = new System.Windows.Forms.RadioButton();
            this.rb2Estrellas = new System.Windows.Forms.RadioButton();
            this.rb1Estrella = new System.Windows.Forms.RadioButton();
            this.cmbTutoresVoto = new System.Windows.Forms.ComboBox();
            this.lblVotarTutor = new System.Windows.Forms.Label();
            this.groupBoxComentario = new System.Windows.Forms.GroupBox();
            this.btnEnviarComentario = new System.Windows.Forms.Button();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.lblComentario = new System.Windows.Forms.Label();
            this.cmbGrupoComentario = new System.Windows.Forms.ComboBox();
            this.lblGrupoComentario = new System.Windows.Forms.Label();
            this.txtNombreEstudiante = new System.Windows.Forms.TextBox();
            this.lblNombreEstudiante = new System.Windows.Forms.Label();
            this.tabControlPrincipal.SuspendLayout();
            this.tabTutorias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBoxRecursos.SuspendLayout();
            this.groupBoxHorarios.SuspendLayout();
            this.groupBoxTutores.SuspendLayout();
            this.tabCalendario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalendario)).BeginInit();
            this.panelFiltro.SuspendLayout();
            this.tabGaleria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVistaPrevia)).BeginInit();
            this.tabFeedback.SuspendLayout();
            this.groupBoxVotacion.SuspendLayout();
            this.groupBoxComentario.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlPrincipal
            // 
            this.tabControlPrincipal.Controls.Add(this.tabTutorias);
            this.tabControlPrincipal.Controls.Add(this.tabCalendario);
            this.tabControlPrincipal.Controls.Add(this.tabGaleria);
            this.tabControlPrincipal.Controls.Add(this.tabFeedback);
            this.tabControlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPrincipal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControlPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tabControlPrincipal.Name = "tabControlPrincipal";
            this.tabControlPrincipal.SelectedIndex = 0;
            this.tabControlPrincipal.Size = new System.Drawing.Size(984, 561);
            this.tabControlPrincipal.TabIndex = 0;
            // 
            // tabTutorias
            // 
            this.tabTutorias.Controls.Add(this.splitContainer1);
            this.tabTutorias.Location = new System.Drawing.Point(4, 26);
            this.tabTutorias.Name = "tabTutorias";
            this.tabTutorias.Padding = new System.Windows.Forms.Padding(3);
            this.tabTutorias.Size = new System.Drawing.Size(976, 531);
            this.tabTutorias.TabIndex = 0;
            this.tabTutorias.Text = "Consulta de Tutorias";
            this.tabTutorias.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lstGrupos);
            this.splitContainer1.Panel1.Controls.Add(this.lblTituloGrupos);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.txtDescripcionGrupo);
            this.splitContainer1.Panel2.Controls.Add(this.lblNombreMateria);
            this.splitContainer1.Panel2.Controls.Add(this.groupBoxRecursos);
            this.splitContainer1.Panel2.Controls.Add(this.groupBoxHorarios);
            this.splitContainer1.Panel2.Controls.Add(this.groupBoxTutores);
            this.splitContainer1.Size = new System.Drawing.Size(970, 525);
            this.splitContainer1.SplitterDistance = 323;
            this.splitContainer1.TabIndex = 0;
            // 
            // lstGrupos
            // 
            this.lstGrupos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstGrupos.FormattingEnabled = true;
            this.lstGrupos.ItemHeight = 17;
            this.lstGrupos.Location = new System.Drawing.Point(0, 30);
            this.lstGrupos.Name = "lstGrupos";
            this.lstGrupos.Size = new System.Drawing.Size(323, 495);
            this.lstGrupos.TabIndex = 1;
            this.lstGrupos.SelectedIndexChanged += new System.EventHandler(this.lstGrupos_SelectedIndexChanged);
            // 
            // lblTituloGrupos
            // 
            this.lblTituloGrupos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloGrupos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTituloGrupos.Location = new System.Drawing.Point(0, 0);
            this.lblTituloGrupos.Name = "lblTituloGrupos";
            this.lblTituloGrupos.Size = new System.Drawing.Size(323, 30);
            this.lblTituloGrupos.TabIndex = 0;
            this.lblTituloGrupos.Text = "Materias y Grupos Disponibles";
            this.lblTituloGrupos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDescripcionGrupo
            // 
            this.txtDescripcionGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescripcionGrupo.BackColor = System.Drawing.SystemColors.Window;
            this.txtDescripcionGrupo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescripcionGrupo.Location = new System.Drawing.Point(18, 55);
            this.txtDescripcionGrupo.Multiline = true;
            this.txtDescripcionGrupo.Name = "txtDescripcionGrupo";
            this.txtDescripcionGrupo.ReadOnly = true;
            this.txtDescripcionGrupo.Size = new System.Drawing.Size(608, 48);
            this.txtDescripcionGrupo.TabIndex = 4;
            // 
            // lblNombreMateria
            // 
            this.lblNombreMateria.AutoSize = true;
            this.lblNombreMateria.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNombreMateria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.lblNombreMateria.Location = new System.Drawing.Point(13, 13);
            this.lblNombreMateria.Name = "lblNombreMateria";
            this.lblNombreMateria.Size = new System.Drawing.Size(370, 30);
            this.lblNombreMateria.TabIndex = 3;
            this.lblNombreMateria.Text = "Seleccione un grupo a la izquierda";
            // 
            // groupBoxRecursos
            // 
            this.groupBoxRecursos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxRecursos.Controls.Add(this.lstRecursos);
            this.groupBoxRecursos.Location = new System.Drawing.Point(18, 350);
            this.groupBoxRecursos.Name = "groupBoxRecursos";
            this.groupBoxRecursos.Size = new System.Drawing.Size(608, 120);
            this.groupBoxRecursos.TabIndex = 2;
            this.groupBoxRecursos.TabStop = false;
            this.groupBoxRecursos.Text = "Recursos (Doble clic para abrir)";
            // 
            // lstRecursos
            // 
            this.lstRecursos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRecursos.FormattingEnabled = true;
            this.lstRecursos.ItemHeight = 17;
            this.lstRecursos.Location = new System.Drawing.Point(3, 21);
            this.lstRecursos.Name = "lstRecursos";
            this.lstRecursos.Size = new System.Drawing.Size(602, 96);
            this.lstRecursos.TabIndex = 0;
            this.lstRecursos.DoubleClick += new System.EventHandler(this.lstRecursos_DoubleClick);
            // 
            // groupBoxHorarios
            // 
            this.groupBoxHorarios.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxHorarios.Controls.Add(this.lstHorarios);
            this.groupBoxHorarios.Location = new System.Drawing.Point(18, 224);
            this.groupBoxHorarios.Name = "groupBoxHorarios";
            this.groupBoxHorarios.Size = new System.Drawing.Size(608, 120);
            this.groupBoxHorarios.TabIndex = 1;
            this.groupBoxHorarios.TabStop = false;
            this.groupBoxHorarios.Text = "Horarios y Sesiones Programadas";
            // 
            // lstHorarios
            // 
            this.lstHorarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstHorarios.FormattingEnabled = true;
            this.lstHorarios.ItemHeight = 17;
            this.lstHorarios.Location = new System.Drawing.Point(3, 21);
            this.lstHorarios.Name = "lstHorarios";
            this.lstHorarios.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstHorarios.Size = new System.Drawing.Size(602, 96);
            this.lstHorarios.TabIndex = 0;
            // 
            // groupBoxTutores
            // 
            this.groupBoxTutores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTutores.Controls.Add(this.lstTutores);
            this.groupBoxTutores.Location = new System.Drawing.Point(18, 109);
            this.groupBoxTutores.Name = "groupBoxTutores";
            this.groupBoxTutores.Size = new System.Drawing.Size(608, 109);
            this.groupBoxTutores.TabIndex = 0;
            this.groupBoxTutores.TabStop = false;
            this.groupBoxTutores.Text = "Tutores Asignados";
            // 
            // lstTutores
            // 
            this.lstTutores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTutores.FormattingEnabled = true;
            this.lstTutores.ItemHeight = 17;
            this.lstTutores.Location = new System.Drawing.Point(3, 21);
            this.lstTutores.Name = "lstTutores";
            this.lstTutores.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstTutores.Size = new System.Drawing.Size(602, 85);
            this.lstTutores.TabIndex = 0;
            // 
            // tabCalendario
            // 
            this.tabCalendario.Controls.Add(this.dgvCalendario);
            this.tabCalendario.Controls.Add(this.panelFiltro);
            this.tabCalendario.Location = new System.Drawing.Point(4, 26);
            this.tabCalendario.Name = "tabCalendario";
            this.tabCalendario.Padding = new System.Windows.Forms.Padding(3);
            this.tabCalendario.Size = new System.Drawing.Size(976, 531);
            this.tabCalendario.TabIndex = 1;
            this.tabCalendario.Text = "Calendario de Actividades";
            this.tabCalendario.UseVisualStyleBackColor = true;
            // 
            // dgvCalendario
            // 
            this.dgvCalendario.AllowUserToAddRows = false;
            this.dgvCalendario.AllowUserToDeleteRows = false;
            this.dgvCalendario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCalendario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCalendario.Location = new System.Drawing.Point(3, 53);
            this.dgvCalendario.Name = "dgvCalendario";
            this.dgvCalendario.ReadOnly = true;
            this.dgvCalendario.RowTemplate.Height = 25;
            this.dgvCalendario.Size = new System.Drawing.Size(970, 475);
            this.dgvCalendario.TabIndex = 1;
            // 
            // panelFiltro
            // 
            this.panelFiltro.Controls.Add(this.cmbFacultadFiltro);
            this.panelFiltro.Controls.Add(this.lblFiltro);
            this.panelFiltro.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltro.Location = new System.Drawing.Point(3, 3);
            this.panelFiltro.Name = "panelFiltro";
            this.panelFiltro.Size = new System.Drawing.Size(970, 50);
            this.panelFiltro.TabIndex = 0;
            // 
            // cmbFacultadFiltro
            // 
            this.cmbFacultadFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFacultadFiltro.FormattingEnabled = true;
            this.cmbFacultadFiltro.Location = new System.Drawing.Point(145, 12);
            this.cmbFacultadFiltro.Name = "cmbFacultadFiltro";
            this.cmbFacultadFiltro.Size = new System.Drawing.Size(300, 25);
            this.cmbFacultadFiltro.TabIndex = 1;
            this.cmbFacultadFiltro.SelectedIndexChanged += new System.EventHandler(this.cmbFacultadFiltro_SelectedIndexChanged);
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Location = new System.Drawing.Point(15, 15);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(124, 19);
            this.lblFiltro.TabIndex = 0;
            this.lblFiltro.Text = "Filtrar por Facultad:";
            // 
            // tabGaleria
            // 
            this.tabGaleria.Controls.Add(this.splitContainer2);
            this.tabGaleria.Location = new System.Drawing.Point(4, 26);
            this.tabGaleria.Name = "tabGaleria";
            this.tabGaleria.Size = new System.Drawing.Size(976, 531);
            this.tabGaleria.TabIndex = 2;
            this.tabGaleria.Text = "Galeria de Sesiones";
            this.tabGaleria.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.flowGaleria);
            this.splitContainer2.Panel1.Controls.Add(this.lblGaleriaMensaje);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lblDescripcionFoto);
            this.splitContainer2.Panel2.Controls.Add(this.picVistaPrevia);
            this.splitContainer2.Size = new System.Drawing.Size(976, 531);
            this.splitContainer2.SplitterDistance = 325;
            this.splitContainer2.TabIndex = 0;
            // 
            // flowGaleria
            // 
            this.flowGaleria.AutoScroll = true;
            this.flowGaleria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowGaleria.Location = new System.Drawing.Point(0, 0);
            this.flowGaleria.Name = "flowGaleria";
            this.flowGaleria.Size = new System.Drawing.Size(325, 531);
            this.flowGaleria.TabIndex = 1;
            // 
            // lblGaleriaMensaje
            // 
            this.lblGaleriaMensaje.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGaleriaMensaje.Location = new System.Drawing.Point(0, 0);
            this.lblGaleriaMensaje.Name = "lblGaleriaMensaje";
            this.lblGaleriaMensaje.Size = new System.Drawing.Size(325, 30);
            this.lblGaleriaMensaje.TabIndex = 0;
            this.lblGaleriaMensaje.Text = "Cargando galeria...";
            this.lblGaleriaMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDescripcionFoto
            // 
            this.lblDescripcionFoto.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblDescripcionFoto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDescripcionFoto.Location = new System.Drawing.Point(0, 481);
            this.lblDescripcionFoto.Name = "lblDescripcionFoto";
            this.lblDescripcionFoto.Size = new System.Drawing.Size(647, 50);
            this.lblDescripcionFoto.TabIndex = 1;
            this.lblDescripcionFoto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picVistaPrevia
            // 
            this.picVistaPrevia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picVistaPrevia.Location = new System.Drawing.Point(0, 0);
            this.picVistaPrevia.Name = "picVistaPrevia";
            this.picVistaPrevia.Size = new System.Drawing.Size(647, 531);
            this.picVistaPrevia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picVistaPrevia.TabIndex = 0;
            this.picVistaPrevia.TabStop = false;
            // 
            // tabFeedback
            // 
            this.tabFeedback.Controls.Add(this.groupBoxVotacion);
            this.tabFeedback.Controls.Add(this.groupBoxComentario);
            this.tabFeedback.Location = new System.Drawing.Point(4, 26);
            this.tabFeedback.Name = "tabFeedback";
            this.tabFeedback.Size = new System.Drawing.Size(976, 531);
            this.tabFeedback.TabIndex = 3;
            this.tabFeedback.Text = "Interaccion y Feedback";
            this.tabFeedback.UseVisualStyleBackColor = true;
            // 
            // groupBoxVotacion
            // 
            this.groupBoxVotacion.Controls.Add(this.lblTutorDelMesPromedio);
            this.groupBoxVotacion.Controls.Add(this.lblTutorDelMesEspecialidad);
            this.groupBoxVotacion.Controls.Add(this.lblTutorDelMesNombre);
            this.groupBoxVotacion.Controls.Add(this.lblTituloTutorDelMes);
            this.groupBoxVotacion.Controls.Add(this.btnVotar);
            this.groupBoxVotacion.Controls.Add(this.rb5Estrellas);
            this.groupBoxVotacion.Controls.Add(this.rb4Estrellas);
            this.groupBoxVotacion.Controls.Add(this.rb3Estrellas);
            this.groupBoxVotacion.Controls.Add(this.rb2Estrellas);
            this.groupBoxVotacion.Controls.Add(this.rb1Estrella);
            this.groupBoxVotacion.Controls.Add(this.cmbTutoresVoto);
            this.groupBoxVotacion.Controls.Add(this.lblVotarTutor);
            this.groupBoxVotacion.Location = new System.Drawing.Point(487, 26);
            this.groupBoxVotacion.Name = "groupBoxVotacion";
            this.groupBoxVotacion.Size = new System.Drawing.Size(465, 477);
            this.groupBoxVotacion.TabIndex = 1;
            this.groupBoxVotacion.TabStop = false;
            this.groupBoxVotacion.Text = "Valoracion al Tutor";
            // 
            // lblTutorDelMesPromedio
            // 
            this.lblTutorDelMesPromedio.AutoSize = true;
            this.lblTutorDelMesPromedio.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTutorDelMesPromedio.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblTutorDelMesPromedio.Location = new System.Drawing.Point(34, 381);
            this.lblTutorDelMesPromedio.Name = "lblTutorDelMesPromedio";
            this.lblTutorDelMesPromedio.Size = new System.Drawing.Size(65, 25);
            this.lblTutorDelMesPromedio.TabIndex = 11;
            this.lblTutorDelMesPromedio.Text = "⭐ 0.0";
            // 
            // lblTutorDelMesEspecialidad
            // 
            this.lblTutorDelMesEspecialidad.AutoSize = true;
            this.lblTutorDelMesEspecialidad.Location = new System.Drawing.Point(34, 349);
            this.lblTutorDelMesEspecialidad.Name = "lblTutorDelMesEspecialidad";
            this.lblTutorDelMesEspecialidad.Size = new System.Drawing.Size(83, 19);
            this.lblTutorDelMesEspecialidad.TabIndex = 10;
            this.lblTutorDelMesEspecialidad.Text = "Especialidad";
            // 
            // lblTutorDelMesNombre
            // 
            this.lblTutorDelMesNombre.AutoSize = true;
            this.lblTutorDelMesNombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTutorDelMesNombre.Location = new System.Drawing.Point(34, 321);
            this.lblTutorDelMesNombre.Name = "lblTutorDelMesNombre";
            this.lblTutorDelMesNombre.Size = new System.Drawing.Size(148, 21);
            this.lblTutorDelMesNombre.TabIndex = 9;
            this.lblTutorDelMesNombre.Text = "Nombre del Tutor";
            // 
            // lblTituloTutorDelMes
            // 
            this.lblTituloTutorDelMes.AutoSize = true;
            this.lblTituloTutorDelMes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTituloTutorDelMes.Location = new System.Drawing.Point(23, 281);
            this.lblTituloTutorDelMes.Name = "lblTituloTutorDelMes";
            this.lblTituloTutorDelMes.Size = new System.Drawing.Size(209, 21);
            this.lblTituloTutorDelMes.TabIndex = 8;
            this.lblTituloTutorDelMes.Text = "🏆 Tutor del Mes (Destacado)";
            // 
            // btnVotar
            // 
            this.btnVotar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnVotar.ForeColor = System.Drawing.Color.White;
            this.btnVotar.Location = new System.Drawing.Point(34, 185);
            this.btnVotar.Name = "btnVotar";
            this.btnVotar.Size = new System.Drawing.Size(120, 35);
            this.btnVotar.TabIndex = 7;
            this.btnVotar.Text = "Enviar Voto";
            this.btnVotar.UseVisualStyleBackColor = false;
            this.btnVotar.Click += new System.EventHandler(this.btnVotar_Click);
            // 
            // rb5Estrellas
            // 
            this.rb5Estrellas.AutoSize = true;
            this.rb5Estrellas.Location = new System.Drawing.Point(34, 137);
            this.rb5Estrellas.Name = "rb5Estrellas";
            this.rb5Estrellas.Size = new System.Drawing.Size(89, 23);
            this.rb5Estrellas.TabIndex = 6;
            this.rb5Estrellas.TabStop = true;
            this.rb5Estrellas.Text = "5 Estrellas";
            this.rb5Estrellas.UseVisualStyleBackColor = true;
            // 
            // rb4Estrellas
            // 
            this.rb4Estrellas.AutoSize = true;
            this.rb4Estrellas.Location = new System.Drawing.Point(135, 108);
            this.rb4Estrellas.Name = "rb4Estrellas";
            this.rb4Estrellas.Size = new System.Drawing.Size(89, 23);
            this.rb4Estrellas.TabIndex = 5;
            this.rb4Estrellas.TabStop = true;
            this.rb4Estrellas.Text = "4 Estrellas";
            this.rb4Estrellas.UseVisualStyleBackColor = true;
            // 
            // rb3Estrellas
            // 
            this.rb3Estrellas.AutoSize = true;
            this.rb3Estrellas.Location = new System.Drawing.Point(34, 108);
            this.rb3Estrellas.Name = "rb3Estrellas";
            this.rb3Estrellas.Size = new System.Drawing.Size(89, 23);
            this.rb3Estrellas.TabIndex = 4;
            this.rb3Estrellas.TabStop = true;
            this.rb3Estrellas.Text = "3 Estrellas";
            this.rb3Estrellas.UseVisualStyleBackColor = true;
            // 
            // rb2Estrellas
            // 
            this.rb2Estrellas.AutoSize = true;
            this.rb2Estrellas.Location = new System.Drawing.Point(135, 79);
            this.rb2Estrellas.Name = "rb2Estrellas";
            this.rb2Estrellas.Size = new System.Drawing.Size(89, 23);
            this.rb2Estrellas.TabIndex = 3;
            this.rb2Estrellas.TabStop = true;
            this.rb2Estrellas.Text = "2 Estrellas";
            this.rb2Estrellas.UseVisualStyleBackColor = true;
            // 
            // rb1Estrella
            // 
            this.rb1Estrella.AutoSize = true;
            this.rb1Estrella.Location = new System.Drawing.Point(34, 79);
            this.rb1Estrella.Name = "rb1Estrella";
            this.rb1Estrella.Size = new System.Drawing.Size(82, 23);
            this.rb1Estrella.TabIndex = 2;
            this.rb1Estrella.TabStop = true;
            this.rb1Estrella.Text = "1 Estrella";
            this.rb1Estrella.UseVisualStyleBackColor = true;
            // 
            // cmbTutoresVoto
            // 
            this.cmbTutoresVoto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTutoresVoto.FormattingEnabled = true;
            this.cmbTutoresVoto.Location = new System.Drawing.Point(125, 33);
            this.cmbTutoresVoto.Name = "cmbTutoresVoto";
            this.cmbTutoresVoto.Size = new System.Drawing.Size(300, 25);
            this.cmbTutoresVoto.TabIndex = 1;
            // 
            // lblVotarTutor
            // 
            this.lblVotarTutor.AutoSize = true;
            this.lblVotarTutor.Location = new System.Drawing.Point(23, 36);
            this.lblVotarTutor.Name = "lblVotarTutor";
            this.lblVotarTutor.Size = new System.Drawing.Size(96, 19);
            this.lblVotarTutor.TabIndex = 0;
            this.lblVotarTutor.Text = "Votar al Tutor:";
            // 
            // groupBoxComentario
            // 
            this.groupBoxComentario.Controls.Add(this.btnEnviarComentario);
            this.groupBoxComentario.Controls.Add(this.txtComentario);
            this.groupBoxComentario.Controls.Add(this.lblComentario);
            this.groupBoxComentario.Controls.Add(this.cmbGrupoComentario);
            this.groupBoxComentario.Controls.Add(this.lblGrupoComentario);
            this.groupBoxComentario.Controls.Add(this.txtNombreEstudiante);
            this.groupBoxComentario.Controls.Add(this.lblNombreEstudiante);
            this.groupBoxComentario.Location = new System.Drawing.Point(21, 26);
            this.groupBoxComentario.Name = "groupBoxComentario";
            this.groupBoxComentario.Size = new System.Drawing.Size(437, 477);
            this.groupBoxComentario.TabIndex = 0;
            this.groupBoxComentario.TabStop = false;
            this.groupBoxComentario.Text = "Dejar un Comentario o Sugerencia";
            // 
            // btnEnviarComentario
            // 
            this.btnEnviarComentario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnEnviarComentario.ForeColor = System.Drawing.Color.White;
            this.btnEnviarComentario.Location = new System.Drawing.Point(24, 381);
            this.btnEnviarComentario.Name = "btnEnviarComentario";
            this.btnEnviarComentario.Size = new System.Drawing.Size(150, 40);
            this.btnEnviarComentario.TabIndex = 6;
            this.btnEnviarComentario.Text = "Enviar Comentario";
            this.btnEnviarComentario.UseVisualStyleBackColor = false;
            this.btnEnviarComentario.Click += new System.EventHandler(this.btnEnviarComentario_Click);
            // 
            // txtComentario
            // 
            this.txtComentario.Location = new System.Drawing.Point(24, 155);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(390, 207);
            this.txtComentario.TabIndex = 5;
            // 
            // lblComentario
            // 
            this.lblComentario.AutoSize = true;
            this.lblComentario.Location = new System.Drawing.Point(24, 133);
            this.lblComentario.Name = "lblComentario";
            this.lblComentario.Size = new System.Drawing.Size(83, 19);
            this.lblComentario.TabIndex = 4;
            this.lblComentario.Text = "Comentario:";
            // 
            // cmbGrupoComentario
            // 
            this.cmbGrupoComentario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrupoComentario.FormattingEnabled = true;
            this.cmbGrupoComentario.Location = new System.Drawing.Point(94, 85);
            this.cmbGrupoComentario.Name = "cmbGrupoComentario";
            this.cmbGrupoComentario.Size = new System.Drawing.Size(320, 25);
            this.cmbGrupoComentario.TabIndex = 3;
            // 
            // lblGrupoComentario
            // 
            this.lblGrupoComentario.AutoSize = true;
            this.lblGrupoComentario.Location = new System.Drawing.Point(24, 88);
            this.lblGrupoComentario.Name = "lblGrupoComentario";
            this.lblGrupoComentario.Size = new System.Drawing.Size(51, 19);
            this.lblGrupoComentario.TabIndex = 2;
            this.lblGrupoComentario.Text = "Grupo:";
            // 
            // txtNombreEstudiante
            // 
            this.txtNombreEstudiante.Location = new System.Drawing.Point(94, 40);
            this.txtNombreEstudiante.Name = "txtNombreEstudiante";
            this.txtNombreEstudiante.Size = new System.Drawing.Size(320, 25);
            this.txtNombreEstudiante.TabIndex = 1;
            // 
            // lblNombreEstudiante
            // 
            this.lblNombreEstudiante.AutoSize = true;
            this.lblNombreEstudiante.Location = new System.Drawing.Point(24, 43);
            this.lblNombreEstudiante.Name = "lblNombreEstudiante";
            this.lblNombreEstudiante.Size = new System.Drawing.Size(62, 19);
            this.lblNombreEstudiante.TabIndex = 0;
            this.lblNombreEstudiante.Text = "Nombre:";
            // 
            // FrmEstudiante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.tabControlPrincipal);
            this.Name = "FrmEstudiante";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modulo de Estudiante - Sistema de Tutorias";
            this.Load += new System.EventHandler(this.FrmEstudiante_Load);
            this.tabControlPrincipal.ResumeLayout(false);
            this.tabTutorias.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBoxRecursos.ResumeLayout(false);
            this.groupBoxHorarios.ResumeLayout(false);
            this.groupBoxTutores.ResumeLayout(false);
            this.tabCalendario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalendario)).EndInit();
            this.panelFiltro.ResumeLayout(false);
            this.panelFiltro.PerformLayout();
            this.tabGaleria.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picVistaPrevia)).EndInit();
            this.tabFeedback.ResumeLayout(false);
            this.groupBoxVotacion.ResumeLayout(false);
            this.groupBoxVotacion.PerformLayout();
            this.groupBoxComentario.ResumeLayout(false);
            this.groupBoxComentario.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlPrincipal;
        private System.Windows.Forms.TabPage tabTutorias;
        private System.Windows.Forms.TabPage tabCalendario;
        private System.Windows.Forms.TabPage tabGaleria;
        private System.Windows.Forms.TabPage tabFeedback;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox lstGrupos;
        private System.Windows.Forms.Label lblTituloGrupos;
        private System.Windows.Forms.GroupBox groupBoxRecursos;
        private System.Windows.Forms.ListBox lstRecursos;
        private System.Windows.Forms.GroupBox groupBoxHorarios;
        private System.Windows.Forms.ListBox lstHorarios;
        private System.Windows.Forms.GroupBox groupBoxTutores;
        private System.Windows.Forms.ListBox lstTutores;
        private System.Windows.Forms.Label lblNombreMateria;
        private System.Windows.Forms.TextBox txtDescripcionGrupo;
        private System.Windows.Forms.Panel panelFiltro;
        private System.Windows.Forms.ComboBox cmbFacultadFiltro;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.DataGridView dgvCalendario;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.FlowLayoutPanel flowGaleria;
        private System.Windows.Forms.PictureBox picVistaPrevia;
        private System.Windows.Forms.Label lblDescripcionFoto;
        private System.Windows.Forms.Label lblGaleriaMensaje;
        private System.Windows.Forms.GroupBox groupBoxComentario;
        private System.Windows.Forms.Button btnEnviarComentario;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.Label lblComentario;
        private System.Windows.Forms.ComboBox cmbGrupoComentario;
        private System.Windows.Forms.Label lblGrupoComentario;
        private System.Windows.Forms.TextBox txtNombreEstudiante;
        private System.Windows.Forms.Label lblNombreEstudiante;
        private System.Windows.Forms.GroupBox groupBoxVotacion;
        private System.Windows.Forms.Label lblTutorDelMesPromedio;
        private System.Windows.Forms.Label lblTutorDelMesEspecialidad;
        private System.Windows.Forms.Label lblTutorDelMesNombre;
        private System.Windows.Forms.Label lblTituloTutorDelMes;
        private System.Windows.Forms.Button btnVotar;
        private System.Windows.Forms.RadioButton rb5Estrellas;
        private System.Windows.Forms.RadioButton rb4Estrellas;
        private System.Windows.Forms.RadioButton rb3Estrellas;
        private System.Windows.Forms.RadioButton rb2Estrellas;
        private System.Windows.Forms.RadioButton rb1Estrella;
        private System.Windows.Forms.ComboBox cmbTutoresVoto;
        private System.Windows.Forms.Label lblVotarTutor;
    }
}
