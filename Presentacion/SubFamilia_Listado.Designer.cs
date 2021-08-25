namespace Presentacion
{
    partial class SubFamilia_Listado
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubFamilia_Listado));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsEditar = new System.Windows.Forms.ToolStripButton();
            this.tsVer = new System.Windows.Forms.ToolStripButton();
            this.tsEliminar = new System.Windows.Forms.ToolStripButton();
            this.tsBuscar = new System.Windows.Forms.ToolStripButton();
            this.tsActualizar = new System.Windows.Forms.ToolStripButton();
            this.tsImprimir = new System.Windows.Forms.ToolStripButton();
            this.tsExportar = new System.Windows.Forms.ToolStripButton();
            this.tsSalir = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.intIdSubFamilia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strCoSubFamilia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strNoSubFamilia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strNoFamilia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intIdFamilia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intIdUsuCr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dttFeCr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intIdUsuMf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dttFeMf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intElim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFamilia = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsNuevo,
            this.tsEditar,
            this.tsVer,
            this.tsEliminar,
            this.tsBuscar,
            this.tsActualizar,
            this.tsImprimir,
            this.tsExportar,
            this.tsSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(655, 43);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsNuevo
            // 
            this.tsNuevo.AutoSize = false;
            this.tsNuevo.Image = ((System.Drawing.Image)(resources.GetObject("tsNuevo.Image")));
            this.tsNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsNuevo.Name = "tsNuevo";
            this.tsNuevo.Size = new System.Drawing.Size(40, 40);
            this.tsNuevo.ToolTipText = "Nuevo";
            this.tsNuevo.Click += new System.EventHandler(this.tsNuevo_Click);
            // 
            // tsEditar
            // 
            this.tsEditar.AutoSize = false;
            this.tsEditar.Image = ((System.Drawing.Image)(resources.GetObject("tsEditar.Image")));
            this.tsEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsEditar.Name = "tsEditar";
            this.tsEditar.Size = new System.Drawing.Size(40, 40);
            this.tsEditar.ToolTipText = "Editar";
            this.tsEditar.Click += new System.EventHandler(this.tsEditar_Click);
            // 
            // tsVer
            // 
            this.tsVer.AutoSize = false;
            this.tsVer.Image = ((System.Drawing.Image)(resources.GetObject("tsVer.Image")));
            this.tsVer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsVer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsVer.Name = "tsVer";
            this.tsVer.Size = new System.Drawing.Size(40, 40);
            this.tsVer.ToolTipText = "Ver";
            this.tsVer.Click += new System.EventHandler(this.tsVer_Click);
            // 
            // tsEliminar
            // 
            this.tsEliminar.AutoSize = false;
            this.tsEliminar.Image = ((System.Drawing.Image)(resources.GetObject("tsEliminar.Image")));
            this.tsEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsEliminar.Name = "tsEliminar";
            this.tsEliminar.Size = new System.Drawing.Size(40, 40);
            this.tsEliminar.ToolTipText = "Eliminar";
            this.tsEliminar.Click += new System.EventHandler(this.tsEliminar_Click);
            // 
            // tsBuscar
            // 
            this.tsBuscar.AutoSize = false;
            this.tsBuscar.Image = ((System.Drawing.Image)(resources.GetObject("tsBuscar.Image")));
            this.tsBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBuscar.Name = "tsBuscar";
            this.tsBuscar.Size = new System.Drawing.Size(40, 40);
            this.tsBuscar.ToolTipText = "Buscar";
            this.tsBuscar.Click += new System.EventHandler(this.tsBuscar_Click);
            // 
            // tsActualizar
            // 
            this.tsActualizar.AutoSize = false;
            this.tsActualizar.Image = ((System.Drawing.Image)(resources.GetObject("tsActualizar.Image")));
            this.tsActualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsActualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsActualizar.Name = "tsActualizar";
            this.tsActualizar.Size = new System.Drawing.Size(40, 40);
            this.tsActualizar.ToolTipText = "Actualizar";
            this.tsActualizar.Click += new System.EventHandler(this.tsActualizar_Click);
            // 
            // tsImprimir
            // 
            this.tsImprimir.AutoSize = false;
            this.tsImprimir.Image = ((System.Drawing.Image)(resources.GetObject("tsImprimir.Image")));
            this.tsImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsImprimir.Name = "tsImprimir";
            this.tsImprimir.Size = new System.Drawing.Size(40, 40);
            this.tsImprimir.ToolTipText = "Imprimir";
            this.tsImprimir.Click += new System.EventHandler(this.tsImprimir_Click);
            // 
            // tsExportar
            // 
            this.tsExportar.AutoSize = false;
            this.tsExportar.Image = ((System.Drawing.Image)(resources.GetObject("tsExportar.Image")));
            this.tsExportar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsExportar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsExportar.Name = "tsExportar";
            this.tsExportar.Size = new System.Drawing.Size(40, 40);
            this.tsExportar.ToolTipText = "Exportar XLS";
            this.tsExportar.Click += new System.EventHandler(this.tsExportar_Click);
            // 
            // tsSalir
            // 
            this.tsSalir.AutoSize = false;
            this.tsSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsSalir.Image")));
            this.tsSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSalir.Name = "tsSalir";
            this.tsSalir.Size = new System.Drawing.Size(40, 40);
            this.tsSalir.Text = "Salir";
            this.tsSalir.ToolTipText = "Salir";
            this.tsSalir.Click += new System.EventHandler(this.tsSalir_Click);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 43);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(655, 25);
            this.bindingNavigator1.TabIndex = 3;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Número total de elementos";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Mover primero";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Mover anterior";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Posición";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Posición actual";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Mover siguiente";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Mover último";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(16, 412);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(639, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(16, 412);
            this.panel2.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(16, 470);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(623, 10);
            this.panel4.TabIndex = 8;
            // 
            // dgvLista
            // 
            this.dgvLista.AllowUserToAddRows = false;
            this.dgvLista.AllowUserToDeleteRows = false;
            this.dgvLista.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.intIdSubFamilia,
            this.strCoSubFamilia,
            this.strNoSubFamilia,
            this.strNoFamilia,
            this.intEstado,
            this.intIdFamilia,
            this.intIdUsuCr,
            this.dttFeCr,
            this.intIdUsuMf,
            this.dttFeMf,
            this.intElim});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLista.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLista.Location = new System.Drawing.Point(16, 68);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.ReadOnly = true;
            this.dgvLista.RowHeadersWidth = 20;
            this.dgvLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvLista.Size = new System.Drawing.Size(623, 402);
            this.dgvLista.TabIndex = 9;
            // 
            // intIdSubFamilia
            // 
            this.intIdSubFamilia.DataPropertyName = "intIdSubFamilia";
            this.intIdSubFamilia.HeaderText = "ID";
            this.intIdSubFamilia.Name = "intIdSubFamilia";
            this.intIdSubFamilia.ReadOnly = true;
            this.intIdSubFamilia.Width = 40;
            // 
            // strCoSubFamilia
            // 
            this.strCoSubFamilia.DataPropertyName = "strCoSubFamilia";
            this.strCoSubFamilia.HeaderText = "Código";
            this.strCoSubFamilia.Name = "strCoSubFamilia";
            this.strCoSubFamilia.ReadOnly = true;
            this.strCoSubFamilia.Width = 70;
            // 
            // strNoSubFamilia
            // 
            this.strNoSubFamilia.DataPropertyName = "strNoSubFamilia";
            this.strNoSubFamilia.HeaderText = "Sub Familia";
            this.strNoSubFamilia.Name = "strNoSubFamilia";
            this.strNoSubFamilia.ReadOnly = true;
            this.strNoSubFamilia.Width = 250;
            // 
            // strNoFamilia
            // 
            this.strNoFamilia.DataPropertyName = "strNoFamilia";
            this.strNoFamilia.HeaderText = "Familia";
            this.strNoFamilia.Name = "strNoFamilia";
            this.strNoFamilia.ReadOnly = true;
            this.strNoFamilia.Width = 250;
            // 
            // intEstado
            // 
            this.intEstado.DataPropertyName = "intEstado";
            this.intEstado.HeaderText = "ESTADO";
            this.intEstado.Name = "intEstado";
            this.intEstado.ReadOnly = true;
            this.intEstado.Visible = false;
            // 
            // intIdFamilia
            // 
            this.intIdFamilia.DataPropertyName = "intIdFamilia";
            this.intIdFamilia.HeaderText = "idFamilia";
            this.intIdFamilia.Name = "intIdFamilia";
            this.intIdFamilia.ReadOnly = true;
            this.intIdFamilia.Visible = false;
            // 
            // intIdUsuCr
            // 
            this.intIdUsuCr.DataPropertyName = "intIdUsuCr";
            this.intIdUsuCr.HeaderText = "CREADOR";
            this.intIdUsuCr.Name = "intIdUsuCr";
            this.intIdUsuCr.ReadOnly = true;
            this.intIdUsuCr.Visible = false;
            // 
            // dttFeCr
            // 
            this.dttFeCr.DataPropertyName = "dttFeCr";
            this.dttFeCr.HeaderText = "FECHA DE CREACION";
            this.dttFeCr.Name = "dttFeCr";
            this.dttFeCr.ReadOnly = true;
            this.dttFeCr.Visible = false;
            // 
            // intIdUsuMf
            // 
            this.intIdUsuMf.DataPropertyName = "intIdUsuMf";
            this.intIdUsuMf.HeaderText = "MODIFICADOR";
            this.intIdUsuMf.Name = "intIdUsuMf";
            this.intIdUsuMf.ReadOnly = true;
            this.intIdUsuMf.Visible = false;
            // 
            // dttFeMf
            // 
            this.dttFeMf.DataPropertyName = "dttFeMf";
            this.dttFeMf.HeaderText = "FECHA MODIFICACION";
            this.dttFeMf.Name = "dttFeMf";
            this.dttFeMf.ReadOnly = true;
            this.dttFeMf.Visible = false;
            // 
            // intElim
            // 
            this.intElim.DataPropertyName = "intElim";
            this.intElim.HeaderText = "ELIMINADO";
            this.intElim.Name = "intElim";
            this.intElim.ReadOnly = true;
            this.intElim.Visible = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.Location = new System.Drawing.Point(564, 44);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(78, 23);
            this.btnLimpiar.TabIndex = 31;
            this.btnLimpiar.Text = "&Limpiar";
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltrar.Image")));
            this.btnFiltrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiltrar.Location = new System.Drawing.Point(478, 44);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(80, 23);
            this.btnFiltrar.TabIndex = 32;
            this.btnFiltrar.Text = "&Filtrar";
            this.btnFiltrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(272, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 30;
            this.label2.Text = "Familia";
            // 
            // txtFamilia
            // 
            this.txtFamilia.BackColor = System.Drawing.Color.SeaShell;
            this.txtFamilia.Location = new System.Drawing.Point(326, 46);
            this.txtFamilia.Name = "txtFamilia";
            this.txtFamilia.ReadOnly = true;
            this.txtFamilia.Size = new System.Drawing.Size(146, 20);
            this.txtFamilia.TabIndex = 29;
            this.txtFamilia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFamilia_KeyDown);
            // 
            // SubFamilia_Listado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(655, 480);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFamilia);
            this.Controls.Add(this.dgvLista);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "SubFamilia_Listado";
            this.Tag = "1080";
            this.Text = "SubFamilia_Listado";
            this.Load += new System.EventHandler(this.SubFamilia_Listado_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsSalir;
        public System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.DataGridViewTextBoxColumn intIdSubFamilia;
        private System.Windows.Forms.DataGridViewTextBoxColumn strCoSubFamilia;
        private System.Windows.Forms.DataGridViewTextBoxColumn strNoSubFamilia;
        private System.Windows.Forms.DataGridViewTextBoxColumn strNoFamilia;
        private System.Windows.Forms.DataGridViewTextBoxColumn intEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn intIdFamilia;
        private System.Windows.Forms.DataGridViewTextBoxColumn intIdUsuCr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dttFeCr;
        private System.Windows.Forms.DataGridViewTextBoxColumn intIdUsuMf;
        private System.Windows.Forms.DataGridViewTextBoxColumn dttFeMf;
        private System.Windows.Forms.DataGridViewTextBoxColumn intElim;
        public System.Windows.Forms.ToolStripButton tsNuevo;
        public System.Windows.Forms.ToolStripButton tsEditar;
        public System.Windows.Forms.ToolStripButton tsVer;
        public System.Windows.Forms.ToolStripButton tsEliminar;
        public System.Windows.Forms.ToolStripButton tsBuscar;
        public System.Windows.Forms.ToolStripButton tsActualizar;
        public System.Windows.Forms.ToolStripButton tsImprimir;
        public System.Windows.Forms.ToolStripButton tsExportar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFamilia;
    }
}