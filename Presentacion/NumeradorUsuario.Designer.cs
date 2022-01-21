namespace Presentacion
{
    partial class NumeradorUsuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NumeradorUsuario));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtIdAlm = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dgvListaNumerador = new System.Windows.Forms.DataGridView();
            this.id_Numerador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serie_Numerador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero_Numerador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observacion_Numerador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.almacen_Numerador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoOpe_Numerador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intIdOperacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strNoOperacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvListaNumeradorAcc = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intAprOrden = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.intGenOrden = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.intValSerieOrden = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.intValEditOrden = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.intValAnulOrden = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.serie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.almacen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoOpe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPasa = new System.Windows.Forms.Button();
            this.btnSaca = new System.Windows.Forms.Button();
            this.cbxUsuario = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPasaTodo = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxOperacion = new System.Windows.Forms.ComboBox();
            this.cbxTA = new System.Windows.Forms.ComboBox();
            this.cbxCO = new System.Windows.Forms.ComboBox();
            this.cbxSede = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaNumerador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaNumeradorAcc)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtIdAlm
            // 
            this.txtIdAlm.Location = new System.Drawing.Point(87, 15);
            this.txtIdAlm.Name = "txtIdAlm";
            this.txtIdAlm.ReadOnly = true;
            this.txtIdAlm.Size = new System.Drawing.Size(27, 20);
            this.txtIdAlm.TabIndex = 100;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(680, 6);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 25);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(761, 6);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 25);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dgvListaNumerador
            // 
            this.dgvListaNumerador.AllowUserToAddRows = false;
            this.dgvListaNumerador.AllowUserToDeleteRows = false;
            this.dgvListaNumerador.AllowUserToResizeRows = false;
            this.dgvListaNumerador.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaNumerador.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaNumerador.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListaNumerador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaNumerador.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_Numerador,
            this.serie_Numerador,
            this.numero_Numerador,
            this.observacion_Numerador,
            this.almacen_Numerador,
            this.tipoOpe_Numerador,
            this.intIdOperacion,
            this.strNoOperacion});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListaNumerador.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListaNumerador.Location = new System.Drawing.Point(10, 136);
            this.dgvListaNumerador.Name = "dgvListaNumerador";
            this.dgvListaNumerador.ReadOnly = true;
            this.dgvListaNumerador.RowHeadersWidth = 20;
            this.dgvListaNumerador.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvListaNumerador.Size = new System.Drawing.Size(828, 217);
            this.dgvListaNumerador.TabIndex = 2;
            // 
            // id_Numerador
            // 
            this.id_Numerador.DataPropertyName = "id_Numerador";
            this.id_Numerador.HeaderText = "Id";
            this.id_Numerador.Name = "id_Numerador";
            this.id_Numerador.ReadOnly = true;
            this.id_Numerador.Visible = false;
            // 
            // serie_Numerador
            // 
            this.serie_Numerador.DataPropertyName = "serie_Numerador";
            this.serie_Numerador.HeaderText = "Serie";
            this.serie_Numerador.Name = "serie_Numerador";
            this.serie_Numerador.ReadOnly = true;
            this.serie_Numerador.Width = 50;
            // 
            // numero_Numerador
            // 
            this.numero_Numerador.DataPropertyName = "numero_Numerador";
            this.numero_Numerador.HeaderText = "Número";
            this.numero_Numerador.MaxInputLength = 100;
            this.numero_Numerador.Name = "numero_Numerador";
            this.numero_Numerador.ReadOnly = true;
            this.numero_Numerador.Width = 60;
            // 
            // observacion_Numerador
            // 
            this.observacion_Numerador.DataPropertyName = "observacion_Numerador";
            this.observacion_Numerador.HeaderText = "Descripcion";
            this.observacion_Numerador.Name = "observacion_Numerador";
            this.observacion_Numerador.ReadOnly = true;
            this.observacion_Numerador.Width = 200;
            // 
            // almacen_Numerador
            // 
            this.almacen_Numerador.DataPropertyName = "almacen_Numerador";
            this.almacen_Numerador.HeaderText = "Almacen";
            this.almacen_Numerador.Name = "almacen_Numerador";
            this.almacen_Numerador.ReadOnly = true;
            this.almacen_Numerador.Width = 200;
            // 
            // tipoOpe_Numerador
            // 
            this.tipoOpe_Numerador.DataPropertyName = "tipoOpe_Numerador";
            this.tipoOpe_Numerador.HeaderText = "Tipo Operacion";
            this.tipoOpe_Numerador.Name = "tipoOpe_Numerador";
            this.tipoOpe_Numerador.ReadOnly = true;
            this.tipoOpe_Numerador.Width = 120;
            // 
            // intIdOperacion
            // 
            this.intIdOperacion.DataPropertyName = "intIdOperacion";
            this.intIdOperacion.HeaderText = "intIdOperacion";
            this.intIdOperacion.Name = "intIdOperacion";
            this.intIdOperacion.ReadOnly = true;
            this.intIdOperacion.Visible = false;
            // 
            // strNoOperacion
            // 
            this.strNoOperacion.DataPropertyName = "strNoOperacion";
            this.strNoOperacion.HeaderText = "Operacion";
            this.strNoOperacion.Name = "strNoOperacion";
            this.strNoOperacion.ReadOnly = true;
            this.strNoOperacion.Width = 200;
            // 
            // dgvListaNumeradorAcc
            // 
            this.dgvListaNumeradorAcc.AllowUserToAddRows = false;
            this.dgvListaNumeradorAcc.AllowUserToDeleteRows = false;
            this.dgvListaNumeradorAcc.AllowUserToResizeRows = false;
            this.dgvListaNumeradorAcc.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaNumeradorAcc.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaNumeradorAcc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvListaNumeradorAcc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaNumeradorAcc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.intAprOrden,
            this.intGenOrden,
            this.intValSerieOrden,
            this.intValEditOrden,
            this.intValAnulOrden,
            this.serie,
            this.numero,
            this.observacion,
            this.almacen,
            this.tipoOpe});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListaNumeradorAcc.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvListaNumeradorAcc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListaNumeradorAcc.Location = new System.Drawing.Point(10, 397);
            this.dgvListaNumeradorAcc.Name = "dgvListaNumeradorAcc";
            this.dgvListaNumeradorAcc.RowHeadersWidth = 20;
            this.dgvListaNumeradorAcc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvListaNumeradorAcc.Size = new System.Drawing.Size(828, 214);
            this.dgvListaNumeradorAcc.TabIndex = 4;
            this.dgvListaNumeradorAcc.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaNumeradorAcc_CellContentClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // intAprOrden
            // 
            this.intAprOrden.DataPropertyName = "intAprOrden";
            this.intAprOrden.FalseValue = "0";
            this.intAprOrden.HeaderText = "Apr. OC";
            this.intAprOrden.Name = "intAprOrden";
            this.intAprOrden.TrueValue = "1";
            this.intAprOrden.Width = 50;
            // 
            // intGenOrden
            // 
            this.intGenOrden.DataPropertyName = "intGenOrden";
            this.intGenOrden.FalseValue = "0";
            this.intGenOrden.HeaderText = "Gen. OC";
            this.intGenOrden.Name = "intGenOrden";
            this.intGenOrden.TrueValue = "1";
            this.intGenOrden.Width = 60;
            // 
            // intValSerieOrden
            // 
            this.intValSerieOrden.DataPropertyName = "intValSerieOrden";
            this.intValSerieOrden.FalseValue = "0";
            this.intValSerieOrden.HeaderText = "Val. Serie OC.";
            this.intValSerieOrden.Name = "intValSerieOrden";
            this.intValSerieOrden.TrueValue = "1";
            // 
            // intValEditOrden
            // 
            this.intValEditOrden.DataPropertyName = "intValEditOrden";
            this.intValEditOrden.FalseValue = "0";
            this.intValEditOrden.HeaderText = "Val. Edit.Orden";
            this.intValEditOrden.Name = "intValEditOrden";
            this.intValEditOrden.TrueValue = "1";
            // 
            // intValAnulOrden
            // 
            this.intValAnulOrden.DataPropertyName = "intValAnulOrden";
            this.intValAnulOrden.FalseValue = "0";
            this.intValAnulOrden.HeaderText = "Val. Anul. Orden";
            this.intValAnulOrden.Name = "intValAnulOrden";
            this.intValAnulOrden.TrueValue = "1";
            // 
            // serie
            // 
            this.serie.DataPropertyName = "serie";
            this.serie.HeaderText = "Serie";
            this.serie.Name = "serie";
            this.serie.ReadOnly = true;
            this.serie.Width = 50;
            // 
            // numero
            // 
            this.numero.DataPropertyName = "numero";
            this.numero.HeaderText = "Numero";
            this.numero.Name = "numero";
            this.numero.ReadOnly = true;
            this.numero.Width = 60;
            // 
            // observacion
            // 
            this.observacion.DataPropertyName = "observacion";
            this.observacion.HeaderText = "Descripcion";
            this.observacion.Name = "observacion";
            this.observacion.ReadOnly = true;
            this.observacion.Width = 200;
            // 
            // almacen
            // 
            this.almacen.DataPropertyName = "almacen";
            this.almacen.HeaderText = "almacen";
            this.almacen.Name = "almacen";
            this.almacen.ReadOnly = true;
            this.almacen.Width = 200;
            // 
            // tipoOpe
            // 
            this.tipoOpe.DataPropertyName = "tipoOpe";
            this.tipoOpe.HeaderText = "Tipo Operacion";
            this.tipoOpe.Name = "tipoOpe";
            this.tipoOpe.ReadOnly = true;
            this.tipoOpe.Width = 120;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 13);
            this.label3.TabIndex = 106;
            this.label3.Text = "Numeradores Disponibles:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 13);
            this.label4.TabIndex = 106;
            this.label4.Text = "Numeradores con Acceso:";
            // 
            // btnPasa
            // 
            this.btnPasa.Location = new System.Drawing.Point(637, 6);
            this.btnPasa.Name = "btnPasa";
            this.btnPasa.Size = new System.Drawing.Size(50, 30);
            this.btnPasa.TabIndex = 3;
            this.btnPasa.Text = "Añadir";
            this.btnPasa.UseVisualStyleBackColor = true;
            this.btnPasa.Click += new System.EventHandler(this.btnPasa_Click);
            // 
            // btnSaca
            // 
            this.btnSaca.Location = new System.Drawing.Point(693, 6);
            this.btnSaca.Name = "btnSaca";
            this.btnSaca.Size = new System.Drawing.Size(50, 30);
            this.btnSaca.TabIndex = 5;
            this.btnSaca.Text = "Quitar";
            this.btnSaca.UseVisualStyleBackColor = true;
            this.btnSaca.Click += new System.EventHandler(this.btnSaca_Click);
            // 
            // cbxUsuario
            // 
            this.cbxUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUsuario.FormattingEnabled = true;
            this.cbxUsuario.Location = new System.Drawing.Point(580, 18);
            this.cbxUsuario.Name = "cbxUsuario";
            this.cbxUsuario.Size = new System.Drawing.Size(239, 21);
            this.cbxUsuario.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(529, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 106;
            this.label1.Text = "Usuario:";
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.BackColor = System.Drawing.Color.Transparent;
            this.lblEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpresa.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblEmpresa.Location = new System.Drawing.Point(81, 7);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(350, 32);
            this.lblEmpresa.TabIndex = 109;
            this.lblEmpresa.Text = "Empresa";
            this.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 106;
            this.label2.Text = "Empresa:";
            // 
            // btnPasaTodo
            // 
            this.btnPasaTodo.Location = new System.Drawing.Point(749, 6);
            this.btnPasaTodo.Name = "btnPasaTodo";
            this.btnPasaTodo.Size = new System.Drawing.Size(70, 30);
            this.btnPasaTodo.TabIndex = 113;
            this.btnPasaTodo.Text = "Agg. Todo";
            this.btnPasaTodo.UseVisualStyleBackColor = true;
            this.btnPasaTodo.Click += new System.EventHandler(this.btnPasaTodo_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbxUsuario);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dgvListaNumerador);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(848, 353);
            this.panel1.TabIndex = 114;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbxOperacion);
            this.groupBox1.Controls.Add(this.cbxTA);
            this.groupBox1.Controls.Add(this.cbxCO);
            this.groupBox1.Controls.Add(this.cbxSede);
            this.groupBox1.Location = new System.Drawing.Point(3, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(835, 76);
            this.groupBox1.TabIndex = 108;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(564, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 13);
            this.label9.TabIndex = 108;
            this.label9.Text = "Tipo Adquisicion";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(368, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 13);
            this.label8.TabIndex = 108;
            this.label8.Text = "Centro Operaciones";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(172, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 108;
            this.label7.Text = "Sede";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 108;
            this.label5.Text = "Operacion";
            // 
            // cbxOperacion
            // 
            this.cbxOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOperacion.FormattingEnabled = true;
            this.cbxOperacion.Location = new System.Drawing.Point(18, 37);
            this.cbxOperacion.Name = "cbxOperacion";
            this.cbxOperacion.Size = new System.Drawing.Size(151, 21);
            this.cbxOperacion.TabIndex = 107;
            this.cbxOperacion.SelectedIndexChanged += new System.EventHandler(this.cbxOperacion_SelectedIndexChanged);
            // 
            // cbxTA
            // 
            this.cbxTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTA.FormattingEnabled = true;
            this.cbxTA.Location = new System.Drawing.Point(567, 37);
            this.cbxTA.Name = "cbxTA";
            this.cbxTA.Size = new System.Drawing.Size(190, 21);
            this.cbxTA.TabIndex = 109;
            this.cbxTA.SelectedIndexChanged += new System.EventHandler(this.cbxTA_SelectedIndexChanged);
            this.cbxTA.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cbxTA_Format);
            // 
            // cbxCO
            // 
            this.cbxCO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCO.FormattingEnabled = true;
            this.cbxCO.Location = new System.Drawing.Point(371, 37);
            this.cbxCO.Name = "cbxCO";
            this.cbxCO.Size = new System.Drawing.Size(190, 21);
            this.cbxCO.TabIndex = 109;
            this.cbxCO.SelectedIndexChanged += new System.EventHandler(this.cbxCO_SelectedIndexChanged);
            this.cbxCO.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cbxCO_Format);
            // 
            // cbxSede
            // 
            this.cbxSede.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSede.FormattingEnabled = true;
            this.cbxSede.Location = new System.Drawing.Point(175, 37);
            this.cbxSede.Name = "cbxSede";
            this.cbxSede.Size = new System.Drawing.Size(190, 21);
            this.cbxSede.TabIndex = 109;
            this.cbxSede.SelectedIndexChanged += new System.EventHandler(this.cbxSede_SelectedIndexChanged);
            this.cbxSede.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cbxSede_Format);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 397);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 214);
            this.panel2.TabIndex = 115;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(838, 397);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 214);
            this.panel3.TabIndex = 116;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.btnPasaTodo);
            this.panel4.Controls.Add(this.btnPasa);
            this.panel4.Controls.Add(this.btnSaca);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 353);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(848, 44);
            this.panel4.TabIndex = 117;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.btnCancelar);
            this.panel5.Controls.Add(this.btnGuardar);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 611);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(848, 37);
            this.panel5.TabIndex = 118;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(284, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "En Caja Chica: Apr. OC = Apr. Sup. y Gen. OC = Apr. Cont.";
            // 
            // NumeradorUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(848, 648);
            this.Controls.Add(this.dgvListaNumeradorAcc);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblEmpresa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIdAlm);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Name = "NumeradorUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "101020";
            this.Text = "Numerador - Usuario";
            this.Load += new System.EventHandler(this.NumeradorUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaNumerador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaNumeradorAcc)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIdAlm;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridView dgvListaNumerador;
        private System.Windows.Forms.DataGridView dgvListaNumeradorAcc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPasa;
        private System.Windows.Forms.Button btnSaca;
        private System.Windows.Forms.ComboBox cbxUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPasaTodo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn intAprOrden;
        private System.Windows.Forms.DataGridViewCheckBoxColumn intGenOrden;
        private System.Windows.Forms.DataGridViewCheckBoxColumn intValSerieOrden;
        private System.Windows.Forms.DataGridViewCheckBoxColumn intValEditOrden;
        private System.Windows.Forms.DataGridViewCheckBoxColumn intValAnulOrden;
        private System.Windows.Forms.DataGridViewTextBoxColumn serie;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn almacen;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoOpe;
        private System.Windows.Forms.ComboBox cbxOperacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_Numerador;
        private System.Windows.Forms.DataGridViewTextBoxColumn serie_Numerador;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero_Numerador;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacion_Numerador;
        private System.Windows.Forms.DataGridViewTextBoxColumn almacen_Numerador;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoOpe_Numerador;
        private System.Windows.Forms.DataGridViewTextBoxColumn intIdOperacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn strNoOperacion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxSede;
        private System.Windows.Forms.ComboBox cbxCO;
        private System.Windows.Forms.ComboBox cbxTA;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}