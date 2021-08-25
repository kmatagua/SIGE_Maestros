namespace Presentacion
{
    partial class Articulo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Articulo));
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxClaArt = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCodAlt = new System.Windows.Forms.TextBox();
            this.txtTag = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.chkFav = new System.Windows.Forms.CheckBox();
            this.txtFamilia = new System.Windows.Forms.TextBox();
            this.txtSubFamilia = new System.Windows.Forms.TextBox();
            this.txtUnidad = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkReceta = new System.Windows.Forms.CheckBox();
            this.txtUnidadComp = new System.Windows.Forms.TextBox();
            this.chkKit = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtComposicion = new System.Windows.Forms.TextBox();
            this.dgvKit = new System.Windows.Forms.DataGridView();
            this.decCant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intIdArtKit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intIdArt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intIdKit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strNoArt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strCoUni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.decPonderado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.decPU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gb2 = new System.Windows.Forms.GroupBox();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.panelDatos = new System.Windows.Forms.Panel();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.panelGrid2 = new System.Windows.Forms.Panel();
            this.gb3 = new System.Windows.Forms.GroupBox();
            this.btnEditarReceta = new System.Windows.Forms.Button();
            this.btnQuitarReceta = new System.Windows.Forms.Button();
            this.btnAgregarReceta = new System.Windows.Forms.Button();
            this.dgvReceta = new System.Windows.Forms.DataGridView();
            this.decCantRec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intIdArtRec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intIdArtReceta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intIdReceta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strNoArtRec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strCoUniRec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKit)).BeginInit();
            this.gb2.SuspendLayout();
            this.panelDatos.SuspendLayout();
            this.panelGrid.SuspendLayout();
            this.panelBotones.SuspendLayout();
            this.panelGrid2.SuspendLayout();
            this.gb3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceta)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCodigo
            // 
            this.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigo.Location = new System.Drawing.Point(6, 84);
            this.txtCodigo.MaxLength = 25;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(103, 20);
            this.txtCodigo.TabIndex = 3;
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Location = new System.Drawing.Point(115, 84);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(324, 20);
            this.txtNombre.TabIndex = 4;
            // 
            // chkEstado
            // 
            this.chkEstado.AutoSize = true;
            this.chkEstado.Location = new System.Drawing.Point(250, 171);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(59, 17);
            this.chkEstado.TabIndex = 7;
            this.chkEstado.Text = "Estado";
            this.chkEstado.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(444, 10);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 25);
            this.btnGuardar.TabIndex = 11;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(525, 10);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 25);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Codigo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Articulo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(294, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Sub Familia:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Familia:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(442, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Unidad de Medida:";
            // 
            // cbxClaArt
            // 
            this.cbxClaArt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxClaArt.FormattingEnabled = true;
            this.cbxClaArt.Location = new System.Drawing.Point(6, 127);
            this.cbxClaArt.Name = "cbxClaArt";
            this.cbxClaArt.Size = new System.Drawing.Size(238, 21);
            this.cbxClaArt.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Clasificación:";
            // 
            // txtCodAlt
            // 
            this.txtCodAlt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodAlt.Location = new System.Drawing.Point(250, 127);
            this.txtCodAlt.Name = "txtCodAlt";
            this.txtCodAlt.Size = new System.Drawing.Size(189, 20);
            this.txtCodAlt.TabIndex = 9;
            // 
            // txtTag
            // 
            this.txtTag.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTag.Location = new System.Drawing.Point(445, 127);
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(137, 20);
            this.txtTag.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(247, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Código Alterno:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(442, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Tag:";
            // 
            // chkFav
            // 
            this.chkFav.AutoSize = true;
            this.chkFav.Location = new System.Drawing.Point(340, 171);
            this.chkFav.Name = "chkFav";
            this.chkFav.Size = new System.Drawing.Size(64, 17);
            this.chkFav.TabIndex = 8;
            this.chkFav.Text = "Favorito";
            this.chkFav.UseVisualStyleBackColor = true;
            // 
            // txtFamilia
            // 
            this.txtFamilia.BackColor = System.Drawing.Color.SeaShell;
            this.txtFamilia.Location = new System.Drawing.Point(6, 39);
            this.txtFamilia.Name = "txtFamilia";
            this.txtFamilia.ReadOnly = true;
            this.txtFamilia.Size = new System.Drawing.Size(285, 20);
            this.txtFamilia.TabIndex = 1;
            this.txtFamilia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFamilia_KeyDown);
            // 
            // txtSubFamilia
            // 
            this.txtSubFamilia.BackColor = System.Drawing.Color.SeaShell;
            this.txtSubFamilia.Location = new System.Drawing.Point(297, 39);
            this.txtSubFamilia.Name = "txtSubFamilia";
            this.txtSubFamilia.ReadOnly = true;
            this.txtSubFamilia.Size = new System.Drawing.Size(285, 20);
            this.txtSubFamilia.TabIndex = 2;
            this.txtSubFamilia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSubFamilia_KeyDown);
            // 
            // txtUnidad
            // 
            this.txtUnidad.BackColor = System.Drawing.Color.SeaShell;
            this.txtUnidad.Location = new System.Drawing.Point(445, 84);
            this.txtUnidad.Name = "txtUnidad";
            this.txtUnidad.ReadOnly = true;
            this.txtUnidad.Size = new System.Drawing.Size(137, 20);
            this.txtUnidad.TabIndex = 13;
            this.txtUnidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUnidad_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkReceta);
            this.groupBox1.Controls.Add(this.txtUnidadComp);
            this.groupBox1.Controls.Add(this.chkKit);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtComposicion);
            this.groupBox1.Controls.Add(this.txtTag);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtSubFamilia);
            this.groupBox1.Controls.Add(this.txtCodAlt);
            this.groupBox1.Controls.Add(this.txtUnidad);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbxClaArt);
            this.groupBox1.Controls.Add(this.txtFamilia);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.chkFav);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkEstado);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(588, 204);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de Articulo";
            // 
            // chkReceta
            // 
            this.chkReceta.AutoSize = true;
            this.chkReceta.Location = new System.Drawing.Point(520, 171);
            this.chkReceta.Name = "chkReceta";
            this.chkReceta.Size = new System.Drawing.Size(61, 17);
            this.chkReceta.TabIndex = 18;
            this.chkReceta.Text = "Receta";
            this.chkReceta.UseVisualStyleBackColor = true;
            this.chkReceta.CheckedChanged += new System.EventHandler(this.chkReceta_CheckedChanged);
            // 
            // txtUnidadComp
            // 
            this.txtUnidadComp.BackColor = System.Drawing.Color.SeaShell;
            this.txtUnidadComp.Location = new System.Drawing.Point(79, 171);
            this.txtUnidadComp.Name = "txtUnidadComp";
            this.txtUnidadComp.ReadOnly = true;
            this.txtUnidadComp.Size = new System.Drawing.Size(100, 20);
            this.txtUnidadComp.TabIndex = 17;
            this.txtUnidadComp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUnidadComp_KeyDown);
            // 
            // chkKit
            // 
            this.chkKit.AutoSize = true;
            this.chkKit.Location = new System.Drawing.Point(430, 171);
            this.chkKit.Name = "chkKit";
            this.chkKit.Size = new System.Drawing.Size(37, 17);
            this.chkKit.TabIndex = 16;
            this.chkKit.Text = "kit";
            this.chkKit.UseVisualStyleBackColor = true;
            this.chkKit.CheckedChanged += new System.EventHandler(this.chkKit_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(76, 155);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Unidad";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 155);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Composición";
            // 
            // txtComposicion
            // 
            this.txtComposicion.Location = new System.Drawing.Point(6, 171);
            this.txtComposicion.Name = "txtComposicion";
            this.txtComposicion.Size = new System.Drawing.Size(66, 20);
            this.txtComposicion.TabIndex = 14;
            this.txtComposicion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloNumerosDecimal);
            // 
            // dgvKit
            // 
            this.dgvKit.AllowUserToAddRows = false;
            this.dgvKit.AllowUserToDeleteRows = false;
            this.dgvKit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.decCant,
            this.intIdArtKit,
            this.intIdArt,
            this.intIdKit,
            this.strNoArt,
            this.strCoUni,
            this.decPonderado,
            this.decPU});
            this.dgvKit.Location = new System.Drawing.Point(12, 56);
            this.dgvKit.Name = "dgvKit";
            this.dgvKit.ReadOnly = true;
            this.dgvKit.RowHeadersWidth = 20;
            this.dgvKit.Size = new System.Drawing.Size(588, 172);
            this.dgvKit.TabIndex = 15;
            // 
            // decCant
            // 
            this.decCant.HeaderText = "Cant.";
            this.decCant.Name = "decCant";
            this.decCant.ReadOnly = true;
            this.decCant.Width = 60;
            // 
            // intIdArtKit
            // 
            this.intIdArtKit.HeaderText = "ID";
            this.intIdArtKit.Name = "intIdArtKit";
            this.intIdArtKit.ReadOnly = true;
            this.intIdArtKit.Visible = false;
            // 
            // intIdArt
            // 
            this.intIdArt.HeaderText = "ID";
            this.intIdArt.Name = "intIdArt";
            this.intIdArt.ReadOnly = true;
            this.intIdArt.Visible = false;
            this.intIdArt.Width = 30;
            // 
            // intIdKit
            // 
            this.intIdKit.HeaderText = "idKit";
            this.intIdKit.Name = "intIdKit";
            this.intIdKit.ReadOnly = true;
            this.intIdKit.Visible = false;
            // 
            // strNoArt
            // 
            this.strNoArt.HeaderText = "Articulo";
            this.strNoArt.Name = "strNoArt";
            this.strNoArt.ReadOnly = true;
            this.strNoArt.Width = 220;
            // 
            // strCoUni
            // 
            this.strCoUni.HeaderText = "Unidad";
            this.strCoUni.Name = "strCoUni";
            this.strCoUni.ReadOnly = true;
            this.strCoUni.Width = 80;
            // 
            // decPonderado
            // 
            this.decPonderado.HeaderText = "Ponderado";
            this.decPonderado.Name = "decPonderado";
            this.decPonderado.ReadOnly = true;
            this.decPonderado.Width = 80;
            // 
            // decPU
            // 
            this.decPU.HeaderText = "P.U";
            this.decPU.Name = "decPU";
            this.decPU.ReadOnly = true;
            // 
            // gb2
            // 
            this.gb2.Controls.Add(this.btnEditar);
            this.gb2.Controls.Add(this.btnQuitar);
            this.gb2.Controls.Add(this.btnAgregar);
            this.gb2.Location = new System.Drawing.Point(12, 6);
            this.gb2.Name = "gb2";
            this.gb2.Size = new System.Drawing.Size(589, 50);
            this.gb2.TabIndex = 16;
            this.gb2.TabStop = false;
            this.gb2.Text = "Ingreso de Detalles Kit";
            // 
            // btnEditar
            // 
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.Location = new System.Drawing.Point(117, 19);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(98, 25);
            this.btnEditar.TabIndex = 17;
            this.btnEditar.Text = "EDITAR";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Image = ((System.Drawing.Image)(resources.GetObject("btnQuitar.Image")));
            this.btnQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuitar.Location = new System.Drawing.Point(221, 19);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(98, 25);
            this.btnQuitar.TabIndex = 19;
            this.btnQuitar.Text = "QUITAR";
            this.btnQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(12, 19);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(98, 25);
            this.btnAgregar.TabIndex = 16;
            this.btnAgregar.Text = "AGREGAR";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // panelDatos
            // 
            this.panelDatos.Controls.Add(this.groupBox1);
            this.panelDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDatos.Location = new System.Drawing.Point(0, 0);
            this.panelDatos.Name = "panelDatos";
            this.panelDatos.Size = new System.Drawing.Size(607, 222);
            this.panelDatos.TabIndex = 17;
            // 
            // panelGrid
            // 
            this.panelGrid.Controls.Add(this.gb2);
            this.panelGrid.Controls.Add(this.dgvKit);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGrid.Location = new System.Drawing.Point(0, 222);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(607, 234);
            this.panelGrid.TabIndex = 18;
            // 
            // panelBotones
            // 
            this.panelBotones.Controls.Add(this.btnCancelar);
            this.panelBotones.Controls.Add(this.btnGuardar);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBotones.Location = new System.Drawing.Point(0, 690);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(607, 45);
            this.panelBotones.TabIndex = 19;
            // 
            // panelGrid2
            // 
            this.panelGrid2.Controls.Add(this.gb3);
            this.panelGrid2.Controls.Add(this.dgvReceta);
            this.panelGrid2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGrid2.Location = new System.Drawing.Point(0, 456);
            this.panelGrid2.Name = "panelGrid2";
            this.panelGrid2.Size = new System.Drawing.Size(607, 234);
            this.panelGrid2.TabIndex = 20;
            // 
            // gb3
            // 
            this.gb3.Controls.Add(this.btnEditarReceta);
            this.gb3.Controls.Add(this.btnQuitarReceta);
            this.gb3.Controls.Add(this.btnAgregarReceta);
            this.gb3.Location = new System.Drawing.Point(11, 10);
            this.gb3.Name = "gb3";
            this.gb3.Size = new System.Drawing.Size(589, 50);
            this.gb3.TabIndex = 17;
            this.gb3.TabStop = false;
            this.gb3.Text = "Ingreso de Detalles Receta";
            // 
            // btnEditarReceta
            // 
            this.btnEditarReceta.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarReceta.Image")));
            this.btnEditarReceta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarReceta.Location = new System.Drawing.Point(117, 19);
            this.btnEditarReceta.Name = "btnEditarReceta";
            this.btnEditarReceta.Size = new System.Drawing.Size(98, 25);
            this.btnEditarReceta.TabIndex = 17;
            this.btnEditarReceta.Text = "EDITAR";
            this.btnEditarReceta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditarReceta.UseVisualStyleBackColor = true;
            this.btnEditarReceta.Click += new System.EventHandler(this.btnEditarReceta_Click);
            // 
            // btnQuitarReceta
            // 
            this.btnQuitarReceta.Image = ((System.Drawing.Image)(resources.GetObject("btnQuitarReceta.Image")));
            this.btnQuitarReceta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuitarReceta.Location = new System.Drawing.Point(221, 19);
            this.btnQuitarReceta.Name = "btnQuitarReceta";
            this.btnQuitarReceta.Size = new System.Drawing.Size(98, 25);
            this.btnQuitarReceta.TabIndex = 19;
            this.btnQuitarReceta.Text = "QUITAR";
            this.btnQuitarReceta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuitarReceta.UseVisualStyleBackColor = true;
            this.btnQuitarReceta.Click += new System.EventHandler(this.btnQuitarReceta_Click);
            // 
            // btnAgregarReceta
            // 
            this.btnAgregarReceta.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarReceta.Image")));
            this.btnAgregarReceta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarReceta.Location = new System.Drawing.Point(12, 19);
            this.btnAgregarReceta.Name = "btnAgregarReceta";
            this.btnAgregarReceta.Size = new System.Drawing.Size(98, 25);
            this.btnAgregarReceta.TabIndex = 16;
            this.btnAgregarReceta.Text = "AGREGAR";
            this.btnAgregarReceta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarReceta.UseVisualStyleBackColor = true;
            this.btnAgregarReceta.Click += new System.EventHandler(this.btnAgregarReceta_Click);
            // 
            // dgvReceta
            // 
            this.dgvReceta.AllowUserToAddRows = false;
            this.dgvReceta.AllowUserToDeleteRows = false;
            this.dgvReceta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.decCantRec,
            this.intIdArtRec,
            this.intIdArtReceta,
            this.intIdReceta,
            this.strNoArtRec,
            this.strCoUniRec});
            this.dgvReceta.Location = new System.Drawing.Point(11, 59);
            this.dgvReceta.Name = "dgvReceta";
            this.dgvReceta.ReadOnly = true;
            this.dgvReceta.RowHeadersWidth = 20;
            this.dgvReceta.Size = new System.Drawing.Size(588, 172);
            this.dgvReceta.TabIndex = 18;
            // 
            // decCantRec
            // 
            this.decCantRec.HeaderText = "Cant.";
            this.decCantRec.Name = "decCantRec";
            this.decCantRec.ReadOnly = true;
            this.decCantRec.Width = 60;
            // 
            // intIdArtRec
            // 
            this.intIdArtRec.HeaderText = "ID";
            this.intIdArtRec.Name = "intIdArtRec";
            this.intIdArtRec.ReadOnly = true;
            this.intIdArtRec.Visible = false;
            // 
            // intIdArtReceta
            // 
            this.intIdArtReceta.HeaderText = "ID";
            this.intIdArtReceta.Name = "intIdArtReceta";
            this.intIdArtReceta.ReadOnly = true;
            this.intIdArtReceta.Visible = false;
            // 
            // intIdReceta
            // 
            this.intIdReceta.HeaderText = "idReceta";
            this.intIdReceta.Name = "intIdReceta";
            this.intIdReceta.ReadOnly = true;
            this.intIdReceta.Visible = false;
            // 
            // strNoArtRec
            // 
            this.strNoArtRec.HeaderText = "Articulo";
            this.strNoArtRec.Name = "strNoArtRec";
            this.strNoArtRec.ReadOnly = true;
            this.strNoArtRec.Width = 320;
            // 
            // strCoUniRec
            // 
            this.strCoUniRec.HeaderText = "Unidad";
            this.strCoUniRec.Name = "strCoUniRec";
            this.strCoUniRec.ReadOnly = true;
            this.strCoUniRec.Width = 80;
            // 
            // Articulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(607, 715);
            this.ControlBox = false;
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.panelGrid2);
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.panelDatos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Articulo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "102010";
            this.Text = "Articulo";
            this.Load += new System.EventHandler(this.Articulo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKit)).EndInit();
            this.gb2.ResumeLayout(false);
            this.panelDatos.ResumeLayout(false);
            this.panelGrid.ResumeLayout(false);
            this.panelBotones.ResumeLayout(false);
            this.panelGrid2.ResumeLayout(false);
            this.gb3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxClaArt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCodAlt;
        private System.Windows.Forms.TextBox txtTag;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkFav;
        private System.Windows.Forms.TextBox txtFamilia;
        private System.Windows.Forms.TextBox txtSubFamilia;
        private System.Windows.Forms.TextBox txtUnidad;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkKit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtComposicion;
        private System.Windows.Forms.DataGridView dgvKit;
        private System.Windows.Forms.GroupBox gb2;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Panel panelDatos;
        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.DataGridViewTextBoxColumn decCant;
        private System.Windows.Forms.DataGridViewTextBoxColumn intIdArtKit;
        private System.Windows.Forms.DataGridViewTextBoxColumn intIdArt;
        private System.Windows.Forms.DataGridViewTextBoxColumn intIdKit;
        private System.Windows.Forms.DataGridViewTextBoxColumn strNoArt;
        private System.Windows.Forms.DataGridViewTextBoxColumn strCoUni;
        private System.Windows.Forms.DataGridViewTextBoxColumn decPonderado;
        private System.Windows.Forms.DataGridViewTextBoxColumn decPU;
        private System.Windows.Forms.TextBox txtUnidadComp;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkReceta;
        private System.Windows.Forms.Panel panelGrid2;
        private System.Windows.Forms.DataGridView dgvReceta;
        private System.Windows.Forms.GroupBox gb3;
        private System.Windows.Forms.Button btnEditarReceta;
        private System.Windows.Forms.Button btnQuitarReceta;
        private System.Windows.Forms.Button btnAgregarReceta;
        private System.Windows.Forms.DataGridViewTextBoxColumn decCantRec;
        private System.Windows.Forms.DataGridViewTextBoxColumn intIdArtRec;
        private System.Windows.Forms.DataGridViewTextBoxColumn intIdArtReceta;
        private System.Windows.Forms.DataGridViewTextBoxColumn intIdReceta;
        private System.Windows.Forms.DataGridViewTextBoxColumn strNoArtRec;
        private System.Windows.Forms.DataGridViewTextBoxColumn strCoUniRec;
    }
}