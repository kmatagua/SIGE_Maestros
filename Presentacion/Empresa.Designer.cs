namespace Presentacion
{
    partial class Empresa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Empresa));
            this.txtIdEmp = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtRuc = new System.Windows.Forms.TextBox();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtQuitar = new System.Windows.Forms.Button();
            this.txtEditar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvDireccion = new System.Windows.Forms.DataGridView();
            this.intIdDireccionEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            // txtIdEmp
            // 
            this.txtIdEmp.Location = new System.Drawing.Point(390, 321);
            this.txtIdEmp.Name = "txtIdEmp";
            this.txtIdEmp.ReadOnly = true;
            this.txtIdEmp.Size = new System.Drawing.Size(27, 20);
            this.txtIdEmp.TabIndex = 100;
            // 
            // txtCodigo
            // 
            this.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigo.Location = new System.Drawing.Point(8, 34);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(95, 20);
            this.txtCodigo.TabIndex = 1;
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Location = new System.Drawing.Point(109, 34);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(276, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // txtRuc
            // 
            this.txtRuc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRuc.Location = new System.Drawing.Point(391, 34);
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(128, 20);
            this.txtRuc.TabIndex = 3;
            // 
            // chkEstado
            // 
            this.chkEstado.AutoSize = true;
            this.chkEstado.Location = new System.Drawing.Point(12, 324);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(59, 17);
            this.chkEstado.TabIndex = 4;
            this.chkEstado.Text = "Estado";
            this.chkEstado.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(382, 316);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 31);
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
            this.btnCancelar.Location = new System.Drawing.Point(463, 316);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 31);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Código:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Nombre Empresa:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(388, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "RUC:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtRuc);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(526, 67);
            this.groupBox1.TabIndex = 101;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de Empresa";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtQuitar);
            this.groupBox2.Controls.Add(this.txtEditar);
            this.groupBox2.Controls.Add(this.btnAgregar);
            this.groupBox2.Location = new System.Drawing.Point(12, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(526, 49);
            this.groupBox2.TabIndex = 103;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ingreso Direcciones";
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
            this.intIdDireccionEmpresa,
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
            this.dgvDireccion.Location = new System.Drawing.Point(12, 139);
            this.dgvDireccion.Name = "dgvDireccion";
            this.dgvDireccion.RowHeadersWidth = 20;
            this.dgvDireccion.Size = new System.Drawing.Size(526, 171);
            this.dgvDireccion.TabIndex = 117;
            this.dgvDireccion.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDireccion_CellValueChanged);
            this.dgvDireccion.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvDireccion_CurrentCellDirtyStateChanged);
            // 
            // intIdDireccionEmpresa
            // 
            this.intIdDireccionEmpresa.HeaderText = "idDirEmp";
            this.intIdDireccionEmpresa.Name = "intIdDireccionEmpresa";
            this.intIdDireccionEmpresa.ReadOnly = true;
            this.intIdDireccionEmpresa.Visible = false;
            // 
            // id
            // 
            this.id.DataPropertyName = "intIdEmpresa";
            this.id.HeaderText = "idEmpresa";
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
            // Empresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 358);
            this.ControlBox = false;
            this.Controls.Add(this.dgvDireccion);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.chkEstado);
            this.Controls.Add(this.txtIdEmp);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Empresa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Empresa";
            this.Load += new System.EventHandler(this.Empresa_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDireccion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIdEmp;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtRuc;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button txtQuitar;
        private System.Windows.Forms.Button txtEditar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dgvDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn intIdDireccionEmpresa;
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