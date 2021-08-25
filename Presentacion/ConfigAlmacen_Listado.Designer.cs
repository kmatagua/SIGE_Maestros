namespace Presentacion
{
    partial class ConfigAlmacen_Listado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigAlmacen_Listado));
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
            this.bn1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.intId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intIdAlm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intIdEmp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strNoEmp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strNoAlm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intIdAlm1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intValidaStock = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.intValor = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.intValidaCero = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.intVenta = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.intAprobIng = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.intAprobSal = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.intAuditIng = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.intAuditSal = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.intTab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bn1)).BeginInit();
            this.bn1.SuspendLayout();
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
            this.toolStrip1.Size = new System.Drawing.Size(782, 43);
            this.toolStrip1.TabIndex = 0;
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
            // bn1
            // 
            this.bn1.AddNewItem = null;
            this.bn1.CountItem = this.bindingNavigatorCountItem;
            this.bn1.DeleteItem = null;
            this.bn1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bn1.Location = new System.Drawing.Point(0, 43);
            this.bn1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bn1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bn1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bn1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bn1.Name = "bn1";
            this.bn1.PositionItem = this.bindingNavigatorPositionItem;
            this.bn1.Size = new System.Drawing.Size(782, 25);
            this.bn1.TabIndex = 2;
            this.bn1.Text = "bindingNavigator1";
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
            // dgvLista
            // 
            this.dgvLista.AllowUserToAddRows = false;
            this.dgvLista.AllowUserToDeleteRows = false;
            this.dgvLista.AllowUserToResizeRows = false;
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
            this.intId,
            this.intIdAlm,
            this.strDescripcion,
            this.intIdEmp,
            this.strNoEmp,
            this.strNoAlm,
            this.intIdAlm1,
            this.intValidaStock,
            this.intValor,
            this.intValidaCero,
            this.intVenta,
            this.intAprobIng,
            this.intAprobSal,
            this.intAuditIng,
            this.intAuditSal,
            this.intTab});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLista.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLista.Location = new System.Drawing.Point(16, 78);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.ReadOnly = true;
            this.dgvLista.RowHeadersWidth = 20;
            this.dgvLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvLista.Size = new System.Drawing.Size(750, 373);
            this.dgvLista.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(16, 393);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(766, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(16, 393);
            this.panel2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(16, 68);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(750, 10);
            this.panel3.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(16, 451);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(750, 10);
            this.panel4.TabIndex = 7;
            // 
            // intId
            // 
            this.intId.DataPropertyName = "intId";
            this.intId.HeaderText = "ID";
            this.intId.Name = "intId";
            this.intId.ReadOnly = true;
            this.intId.Width = 30;
            // 
            // intIdAlm
            // 
            this.intIdAlm.DataPropertyName = "intIdAlm";
            this.intIdAlm.HeaderText = "ID";
            this.intIdAlm.Name = "intIdAlm";
            this.intIdAlm.ReadOnly = true;
            this.intIdAlm.Visible = false;
            // 
            // strDescripcion
            // 
            this.strDescripcion.DataPropertyName = "strDescripcion";
            this.strDescripcion.HeaderText = "Almacen";
            this.strDescripcion.Name = "strDescripcion";
            this.strDescripcion.ReadOnly = true;
            this.strDescripcion.Width = 200;
            // 
            // intIdEmp
            // 
            this.intIdEmp.DataPropertyName = "intIdEmp";
            this.intIdEmp.HeaderText = "idEmpresa";
            this.intIdEmp.Name = "intIdEmp";
            this.intIdEmp.ReadOnly = true;
            this.intIdEmp.Visible = false;
            // 
            // strNoEmp
            // 
            this.strNoEmp.DataPropertyName = "strNoEmp";
            this.strNoEmp.HeaderText = "Empresa";
            this.strNoEmp.Name = "strNoEmp";
            this.strNoEmp.ReadOnly = true;
            this.strNoEmp.Width = 200;
            // 
            // strNoAlm
            // 
            this.strNoAlm.DataPropertyName = "strNoAlm";
            this.strNoAlm.HeaderText = "Almacen";
            this.strNoAlm.Name = "strNoAlm";
            this.strNoAlm.ReadOnly = true;
            this.strNoAlm.Width = 200;
            // 
            // intIdAlm1
            // 
            this.intIdAlm1.DataPropertyName = "intIdAlm1";
            this.intIdAlm1.HeaderText = "idAlmacen";
            this.intIdAlm1.Name = "intIdAlm1";
            this.intIdAlm1.ReadOnly = true;
            this.intIdAlm1.Visible = false;
            // 
            // intValidaStock
            // 
            this.intValidaStock.DataPropertyName = "intValidaStock";
            this.intValidaStock.FalseValue = "0";
            this.intValidaStock.HeaderText = "Valida Stock";
            this.intValidaStock.Name = "intValidaStock";
            this.intValidaStock.ReadOnly = true;
            this.intValidaStock.TrueValue = "1";
            this.intValidaStock.Width = 80;
            // 
            // intValor
            // 
            this.intValor.DataPropertyName = "intValor";
            this.intValor.FalseValue = "0";
            this.intValor.HeaderText = "Valor";
            this.intValor.Name = "intValor";
            this.intValor.ReadOnly = true;
            this.intValor.TrueValue = "1";
            this.intValor.Visible = false;
            // 
            // intValidaCero
            // 
            this.intValidaCero.DataPropertyName = "intValidaCero";
            this.intValidaCero.FalseValue = "0";
            this.intValidaCero.HeaderText = "Valida Cero";
            this.intValidaCero.Name = "intValidaCero";
            this.intValidaCero.ReadOnly = true;
            this.intValidaCero.TrueValue = "1";
            this.intValidaCero.Width = 80;
            // 
            // intVenta
            // 
            this.intVenta.DataPropertyName = "intVenta";
            this.intVenta.FalseValue = "0";
            this.intVenta.HeaderText = "Permite Venta";
            this.intVenta.Name = "intVenta";
            this.intVenta.ReadOnly = true;
            this.intVenta.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.intVenta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.intVenta.TrueValue = "1";
            this.intVenta.Width = 96;
            // 
            // intAprobIng
            // 
            this.intAprobIng.DataPropertyName = "intAprobIng";
            this.intAprobIng.FalseValue = "0";
            this.intAprobIng.HeaderText = "Apr. Ingreso";
            this.intAprobIng.Name = "intAprobIng";
            this.intAprobIng.ReadOnly = true;
            this.intAprobIng.TrueValue = "1";
            // 
            // intAprobSal
            // 
            this.intAprobSal.DataPropertyName = "intAprobSal";
            this.intAprobSal.FalseValue = "0";
            this.intAprobSal.HeaderText = "Apr. Salida";
            this.intAprobSal.Name = "intAprobSal";
            this.intAprobSal.ReadOnly = true;
            this.intAprobSal.TrueValue = "1";
            // 
            // intAuditIng
            // 
            this.intAuditIng.DataPropertyName = "intAuditIng";
            this.intAuditIng.FalseValue = "0";
            this.intAuditIng.HeaderText = "Audit. Ingreso";
            this.intAuditIng.Name = "intAuditIng";
            this.intAuditIng.ReadOnly = true;
            this.intAuditIng.TrueValue = "1";
            // 
            // intAuditSal
            // 
            this.intAuditSal.DataPropertyName = "intAuditSal";
            this.intAuditSal.FalseValue = "0";
            this.intAuditSal.HeaderText = "Audit. Salida";
            this.intAuditSal.Name = "intAuditSal";
            this.intAuditSal.ReadOnly = true;
            this.intAuditSal.TrueValue = "1";
            // 
            // intTab
            // 
            this.intTab.DataPropertyName = "intTab";
            this.intTab.HeaderText = "Tabs";
            this.intTab.Name = "intTab";
            this.intTab.ReadOnly = true;
            this.intTab.Width = 40;
            // 
            // ConfigAlmacen_Listado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(782, 461);
            this.Controls.Add(this.dgvLista);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bn1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ConfigAlmacen_Listado";
            this.Tag = "";
            this.Text = "Almacen";
            this.Load += new System.EventHandler(this.ConfigAlmacen_Listado_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bn1)).EndInit();
            this.bn1.ResumeLayout(false);
            this.bn1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton tsSalir;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        public System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.BindingNavigator bn1;
        public System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.ToolStripButton tsNuevo;
        public System.Windows.Forms.ToolStripButton tsEditar;
        public System.Windows.Forms.ToolStripButton tsVer;
        public System.Windows.Forms.ToolStripButton tsEliminar;
        public System.Windows.Forms.ToolStripButton tsBuscar;
        public System.Windows.Forms.ToolStripButton tsActualizar;
        public System.Windows.Forms.ToolStripButton tsImprimir;
        public System.Windows.Forms.ToolStripButton tsExportar;
        private System.Windows.Forms.DataGridViewTextBoxColumn intId;
        private System.Windows.Forms.DataGridViewTextBoxColumn intIdAlm;
        private System.Windows.Forms.DataGridViewTextBoxColumn strDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn intIdEmp;
        private System.Windows.Forms.DataGridViewTextBoxColumn strNoEmp;
        private System.Windows.Forms.DataGridViewTextBoxColumn strNoAlm;
        private System.Windows.Forms.DataGridViewTextBoxColumn intIdAlm1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn intValidaStock;
        private System.Windows.Forms.DataGridViewCheckBoxColumn intValor;
        private System.Windows.Forms.DataGridViewCheckBoxColumn intValidaCero;
        private System.Windows.Forms.DataGridViewCheckBoxColumn intVenta;
        private System.Windows.Forms.DataGridViewCheckBoxColumn intAprobIng;
        private System.Windows.Forms.DataGridViewCheckBoxColumn intAprobSal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn intAuditIng;
        private System.Windows.Forms.DataGridViewCheckBoxColumn intAuditSal;
        private System.Windows.Forms.DataGridViewTextBoxColumn intTab;
    }
}