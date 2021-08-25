namespace Presentacion
{
    partial class Proveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Proveedor));
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtApePat = new System.Windows.Forms.TextBox();
            this.dtpFecIng = new System.Windows.Forms.DateTimePicker();
            this.txtApeMat = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombProv = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtContacto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRazSoc = new System.Windows.Forms.TextBox();
            this.txtRUC = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtQuitar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtEditar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvDireccion = new System.Windows.Forms.DataGridView();
            this.intIdDireccionProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intDefault = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.strDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intIdCalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strCoCalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strNoCalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strNro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strPabellon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strMz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strLote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strCoTipoDep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strNoTipoDep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intIdTipoDep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intIdUrbanismo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strCoUrbanismo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strNoUrb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intIdSector = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strCoSector = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strNoSector = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intIdUbigeo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strCoUbigeo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strNoUbigeo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDireccion)).BeginInit();
            this.SuspendLayout();
            // 
            // chkEstado
            // 
            this.chkEstado.AutoSize = true;
            this.chkEstado.Location = new System.Drawing.Point(10, 433);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(59, 17);
            this.chkEstado.TabIndex = 13;
            this.chkEstado.Text = "Estado";
            this.chkEstado.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(521, 420);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 30);
            this.btnGuardar.TabIndex = 14;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(602, 420);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 30);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtApePat
            // 
            this.txtApePat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApePat.Location = new System.Drawing.Point(16, 50);
            this.txtApePat.Name = "txtApePat";
            this.txtApePat.Size = new System.Drawing.Size(148, 20);
            this.txtApePat.TabIndex = 1;
            this.txtApePat.Leave += new System.EventHandler(this.txtApePat_Leave);
            // 
            // dtpFecIng
            // 
            this.dtpFecIng.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecIng.Location = new System.Drawing.Point(502, 50);
            this.dtpFecIng.Name = "dtpFecIng";
            this.dtpFecIng.Size = new System.Drawing.Size(150, 20);
            this.dtpFecIng.TabIndex = 4;
            // 
            // txtApeMat
            // 
            this.txtApeMat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApeMat.Location = new System.Drawing.Point(170, 50);
            this.txtApeMat.Name = "txtApeMat";
            this.txtApeMat.Size = new System.Drawing.Size(160, 20);
            this.txtApeMat.TabIndex = 2;
            this.txtApeMat.Leave += new System.EventHandler(this.txtApeMat_Leave);
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Location = new System.Drawing.Point(336, 50);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(160, 20);
            this.txtNombre.TabIndex = 3;
            this.txtNombre.Leave += new System.EventHandler(this.txtNombre_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Apellido Paterno";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(167, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Apellido Materno";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(333, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Nombre";
            // 
            // txtNombProv
            // 
            this.txtNombProv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombProv.Enabled = false;
            this.txtNombProv.Location = new System.Drawing.Point(16, 95);
            this.txtNombProv.Name = "txtNombProv";
            this.txtNombProv.Size = new System.Drawing.Size(237, 20);
            this.txtNombProv.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Nombre Proveedor";
            // 
            // txtDNI
            // 
            this.txtDNI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDNI.Location = new System.Drawing.Point(259, 95);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(100, 20);
            this.txtDNI.TabIndex = 6;
            // 
            // txtTel
            // 
            this.txtTel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTel.Location = new System.Drawing.Point(365, 95);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(100, 20);
            this.txtTel.TabIndex = 7;
            // 
            // txtContacto
            // 
            this.txtContacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContacto.Location = new System.Drawing.Point(471, 95);
            this.txtContacto.Name = "txtContacto";
            this.txtContacto.Size = new System.Drawing.Size(181, 20);
            this.txtContacto.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(256, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "DNI";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(362, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Telefono";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(468, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Contacto";
            // 
            // txtRazSoc
            // 
            this.txtRazSoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRazSoc.Location = new System.Drawing.Point(16, 138);
            this.txtRazSoc.Name = "txtRazSoc";
            this.txtRazSoc.Size = new System.Drawing.Size(343, 20);
            this.txtRazSoc.TabIndex = 9;
            this.txtRazSoc.Leave += new System.EventHandler(this.txtRazSoc_Leave);
            // 
            // txtRUC
            // 
            this.txtRUC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRUC.Location = new System.Drawing.Point(365, 138);
            this.txtRUC.Name = "txtRUC";
            this.txtRUC.Size = new System.Drawing.Size(100, 20);
            this.txtRUC.TabIndex = 10;
            // 
            // txtCorreo
            // 
            this.txtCorreo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCorreo.Location = new System.Drawing.Point(471, 138);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(181, 20);
            this.txtCorreo.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Razon Social";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(362, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "RUC";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(468, 122);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Correo";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(667, 151);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            // 
            // txtQuitar
            // 
            this.txtQuitar.Image = ((System.Drawing.Image)(resources.GetObject("txtQuitar.Image")));
            this.txtQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtQuitar.Location = new System.Drawing.Point(217, 20);
            this.txtQuitar.Name = "txtQuitar";
            this.txtQuitar.Size = new System.Drawing.Size(98, 25);
            this.txtQuitar.TabIndex = 2;
            this.txtQuitar.Text = "QUITAR";
            this.txtQuitar.UseVisualStyleBackColor = true;
            this.txtQuitar.Click += new System.EventHandler(this.txtQuitar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtQuitar);
            this.groupBox2.Controls.Add(this.txtEditar);
            this.groupBox2.Controls.Add(this.btnAgregar);
            this.groupBox2.Location = new System.Drawing.Point(10, 171);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(667, 49);
            this.groupBox2.TabIndex = 118;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ingreso Direcciones";
            // 
            // txtEditar
            // 
            this.txtEditar.Image = ((System.Drawing.Image)(resources.GetObject("txtEditar.Image")));
            this.txtEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtEditar.Location = new System.Drawing.Point(112, 20);
            this.txtEditar.Name = "txtEditar";
            this.txtEditar.Size = new System.Drawing.Size(98, 25);
            this.txtEditar.TabIndex = 1;
            this.txtEditar.Text = "EDITAR";
            this.txtEditar.UseVisualStyleBackColor = true;
            this.txtEditar.Click += new System.EventHandler(this.txtEditar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(7, 20);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(98, 25);
            this.btnAgregar.TabIndex = 0;
            this.btnAgregar.Text = "AGREGAR";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dgvDireccion
            // 
            this.dgvDireccion.AllowUserToAddRows = false;
            this.dgvDireccion.AllowUserToDeleteRows = false;
            this.dgvDireccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDireccion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.intIdDireccionProveedor,
            this.id,
            this.intDefault,
            this.strDireccion,
            this.intIdCalle,
            this.strCoCalle,
            this.strNoCalle,
            this.strNro,
            this.strPabellon,
            this.strMz,
            this.strLote,
            this.strCoTipoDep,
            this.strNoTipoDep,
            this.intIdTipoDep,
            this.intIdUrbanismo,
            this.strCoUrbanismo,
            this.strNoUrb,
            this.intIdSector,
            this.strCoSector,
            this.strNoSector,
            this.intIdUbigeo,
            this.strCoUbigeo,
            this.strNoUbigeo});
            this.dgvDireccion.Location = new System.Drawing.Point(10, 223);
            this.dgvDireccion.Name = "dgvDireccion";
            this.dgvDireccion.RowHeadersWidth = 20;
            this.dgvDireccion.Size = new System.Drawing.Size(667, 171);
            this.dgvDireccion.TabIndex = 119;
            this.dgvDireccion.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDireccion_CellValueChanged);
            this.dgvDireccion.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvDireccion_CurrentCellDirtyStateChanged);
            // 
            // intIdDireccionProveedor
            // 
            this.intIdDireccionProveedor.HeaderText = "idDirEmp";
            this.intIdDireccionProveedor.Name = "intIdDireccionProveedor";
            this.intIdDireccionProveedor.ReadOnly = true;
            this.intIdDireccionProveedor.Visible = false;
            // 
            // id
            // 
            this.id.DataPropertyName = "intIdProveedor";
            this.id.HeaderText = "idProveedor";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // intDefault
            // 
            this.intDefault.FalseValue = "0";
            this.intDefault.HeaderText = "Act.";
            this.intDefault.Name = "intDefault";
            this.intDefault.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.intDefault.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.intDefault.TrueValue = "1";
            this.intDefault.Width = 40;
            // 
            // strDireccion
            // 
            this.strDireccion.HeaderText = "strDireccion";
            this.strDireccion.Name = "strDireccion";
            this.strDireccion.ReadOnly = true;
            this.strDireccion.Width = 450;
            // 
            // intIdCalle
            // 
            this.intIdCalle.HeaderText = "idCalle";
            this.intIdCalle.Name = "intIdCalle";
            this.intIdCalle.ReadOnly = true;
            this.intIdCalle.Visible = false;
            // 
            // strCoCalle
            // 
            this.strCoCalle.HeaderText = "strCoCalle";
            this.strCoCalle.Name = "strCoCalle";
            this.strCoCalle.ReadOnly = true;
            this.strCoCalle.Width = 40;
            // 
            // strNoCalle
            // 
            this.strNoCalle.HeaderText = "Calle";
            this.strNoCalle.Name = "strNoCalle";
            this.strNoCalle.ReadOnly = true;
            // 
            // strNro
            // 
            this.strNro.HeaderText = "Nro";
            this.strNro.Name = "strNro";
            this.strNro.ReadOnly = true;
            this.strNro.Width = 60;
            // 
            // strPabellon
            // 
            this.strPabellon.HeaderText = "Pabellon";
            this.strPabellon.Name = "strPabellon";
            this.strPabellon.ReadOnly = true;
            this.strPabellon.Width = 60;
            // 
            // strMz
            // 
            this.strMz.HeaderText = "Mz";
            this.strMz.Name = "strMz";
            this.strMz.ReadOnly = true;
            this.strMz.Width = 60;
            // 
            // strLote
            // 
            this.strLote.HeaderText = "Lote";
            this.strLote.Name = "strLote";
            this.strLote.ReadOnly = true;
            this.strLote.Width = 60;
            // 
            // strCoTipoDep
            // 
            this.strCoTipoDep.HeaderText = "strCoTipoDep";
            this.strCoTipoDep.Name = "strCoTipoDep";
            this.strCoTipoDep.ReadOnly = true;
            // 
            // strNoTipoDep
            // 
            this.strNoTipoDep.HeaderText = "Tipo Dpto";
            this.strNoTipoDep.Name = "strNoTipoDep";
            this.strNoTipoDep.ReadOnly = true;
            // 
            // intIdTipoDep
            // 
            this.intIdTipoDep.HeaderText = "idTipoDep";
            this.intIdTipoDep.Name = "intIdTipoDep";
            this.intIdTipoDep.ReadOnly = true;
            this.intIdTipoDep.Visible = false;
            // 
            // intIdUrbanismo
            // 
            this.intIdUrbanismo.HeaderText = "intIdUrbanismo";
            this.intIdUrbanismo.Name = "intIdUrbanismo";
            this.intIdUrbanismo.ReadOnly = true;
            this.intIdUrbanismo.Visible = false;
            // 
            // strCoUrbanismo
            // 
            this.strCoUrbanismo.HeaderText = "strCoUrbanismo";
            this.strCoUrbanismo.Name = "strCoUrbanismo";
            this.strCoUrbanismo.ReadOnly = true;
            // 
            // strNoUrb
            // 
            this.strNoUrb.HeaderText = "Urb";
            this.strNoUrb.Name = "strNoUrb";
            this.strNoUrb.ReadOnly = true;
            // 
            // intIdSector
            // 
            this.intIdSector.HeaderText = "intIdSector";
            this.intIdSector.Name = "intIdSector";
            this.intIdSector.ReadOnly = true;
            this.intIdSector.Visible = false;
            // 
            // strCoSector
            // 
            this.strCoSector.HeaderText = "strCoSector";
            this.strCoSector.Name = "strCoSector";
            this.strCoSector.ReadOnly = true;
            // 
            // strNoSector
            // 
            this.strNoSector.HeaderText = "strNoSector";
            this.strNoSector.Name = "strNoSector";
            this.strNoSector.ReadOnly = true;
            // 
            // intIdUbigeo
            // 
            this.intIdUbigeo.HeaderText = "intIdUbigeo";
            this.intIdUbigeo.Name = "intIdUbigeo";
            this.intIdUbigeo.ReadOnly = true;
            // 
            // strCoUbigeo
            // 
            this.strCoUbigeo.HeaderText = "strCoUbigeo";
            this.strCoUbigeo.Name = "strCoUbigeo";
            this.strCoUbigeo.ReadOnly = true;
            // 
            // strNoUbigeo
            // 
            this.strNoUbigeo.HeaderText = "strNoUbigeo";
            this.strNoUbigeo.Name = "strNoUbigeo";
            this.strNoUbigeo.ReadOnly = true;
            // 
            // Proveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 462);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.txtRUC);
            this.Controls.Add(this.dgvDireccion);
            this.Controls.Add(this.txtRazSoc);
            this.Controls.Add(this.txtContacto);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.txtDNI);
            this.Controls.Add(this.txtNombProv);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtApeMat);
            this.Controls.Add(this.dtpFecIng);
            this.Controls.Add(this.txtApePat);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.chkEstado);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Proveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "104010";
            this.Text = "Proveedor";
            this.Load += new System.EventHandler(this.Proveedor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDireccion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtApePat;
        private System.Windows.Forms.DateTimePicker dtpFecIng;
        private System.Windows.Forms.TextBox txtApeMat;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombProv;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtContacto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRazSoc;
        private System.Windows.Forms.TextBox txtRUC;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button txtQuitar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button txtEditar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dgvDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn intIdDireccionProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn intDefault;
        private System.Windows.Forms.DataGridViewTextBoxColumn strDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn intIdCalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn strCoCalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn strNoCalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn strNro;
        private System.Windows.Forms.DataGridViewTextBoxColumn strPabellon;
        private System.Windows.Forms.DataGridViewTextBoxColumn strMz;
        private System.Windows.Forms.DataGridViewTextBoxColumn strLote;
        private System.Windows.Forms.DataGridViewTextBoxColumn strCoTipoDep;
        private System.Windows.Forms.DataGridViewTextBoxColumn strNoTipoDep;
        private System.Windows.Forms.DataGridViewTextBoxColumn intIdTipoDep;
        private System.Windows.Forms.DataGridViewTextBoxColumn intIdUrbanismo;
        private System.Windows.Forms.DataGridViewTextBoxColumn strCoUrbanismo;
        private System.Windows.Forms.DataGridViewTextBoxColumn strNoUrb;
        private System.Windows.Forms.DataGridViewTextBoxColumn intIdSector;
        private System.Windows.Forms.DataGridViewTextBoxColumn strCoSector;
        private System.Windows.Forms.DataGridViewTextBoxColumn strNoSector;
        private System.Windows.Forms.DataGridViewTextBoxColumn intIdUbigeo;
        private System.Windows.Forms.DataGridViewTextBoxColumn strCoUbigeo;
        private System.Windows.Forms.DataGridViewTextBoxColumn strNoUbigeo;
    }
}