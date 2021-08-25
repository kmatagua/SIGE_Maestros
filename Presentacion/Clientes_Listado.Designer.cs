namespace Presentacion
{
    partial class Clientes_Listado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Clientes_Listado));
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
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.intIdCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strCoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strNoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strRazSoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strApePat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strApeMat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strNom1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strNom2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strRuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strDni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strMail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strTlfFijo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strTlfMovil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
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
            this.toolStrip1.Size = new System.Drawing.Size(783, 43);
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
            this.bindingNavigator1.Size = new System.Drawing.Size(783, 25);
            this.bindingNavigator1.TabIndex = 2;
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
            // dgvLista
            // 
            this.dgvLista.AllowUserToAddRows = false;
            this.dgvLista.AllowUserToDeleteRows = false;
            this.dgvLista.BackgroundColor = System.Drawing.Color.White;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.intIdCliente,
            this.strCoCliente,
            this.strNoCliente,
            this.strRazSoc,
            this.strApePat,
            this.strApeMat,
            this.strNom1,
            this.strNom2,
            this.strRuc,
            this.strDni,
            this.strDireccion,
            this.strMail,
            this.strTlfFijo,
            this.strTlfMovil});
            this.dgvLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLista.Location = new System.Drawing.Point(16, 78);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.ReadOnly = true;
            this.dgvLista.RowHeadersWidth = 20;
            this.dgvLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLista.Size = new System.Drawing.Size(751, 373);
            this.dgvLista.TabIndex = 3;
            // 
            // intIdCliente
            // 
            this.intIdCliente.DataPropertyName = "intIdCliente";
            this.intIdCliente.HeaderText = "ID";
            this.intIdCliente.Name = "intIdCliente";
            this.intIdCliente.ReadOnly = true;
            this.intIdCliente.Width = 30;
            // 
            // strCoCliente
            // 
            this.strCoCliente.DataPropertyName = "strCoCliente";
            this.strCoCliente.HeaderText = "Codigo";
            this.strCoCliente.Name = "strCoCliente";
            this.strCoCliente.ReadOnly = true;
            this.strCoCliente.Width = 80;
            // 
            // strNoCliente
            // 
            this.strNoCliente.DataPropertyName = "strNoCliente";
            this.strNoCliente.HeaderText = "Nombre Comercial";
            this.strNoCliente.Name = "strNoCliente";
            this.strNoCliente.ReadOnly = true;
            this.strNoCliente.Width = 150;
            // 
            // strRazSoc
            // 
            this.strRazSoc.DataPropertyName = "strRazSoc";
            this.strRazSoc.HeaderText = "Razon Social";
            this.strRazSoc.Name = "strRazSoc";
            this.strRazSoc.ReadOnly = true;
            this.strRazSoc.Width = 150;
            // 
            // strApePat
            // 
            this.strApePat.DataPropertyName = "strApePat";
            this.strApePat.HeaderText = "Apellido Paterno";
            this.strApePat.Name = "strApePat";
            this.strApePat.ReadOnly = true;
            // 
            // strApeMat
            // 
            this.strApeMat.DataPropertyName = "strApeMat";
            this.strApeMat.HeaderText = "Apellido Materno";
            this.strApeMat.Name = "strApeMat";
            this.strApeMat.ReadOnly = true;
            // 
            // strNom1
            // 
            this.strNom1.DataPropertyName = "strNom1";
            this.strNom1.HeaderText = "Primer Nombre";
            this.strNom1.Name = "strNom1";
            this.strNom1.ReadOnly = true;
            // 
            // strNom2
            // 
            this.strNom2.DataPropertyName = "strNom2";
            this.strNom2.HeaderText = "Segundo Nombre";
            this.strNom2.Name = "strNom2";
            this.strNom2.ReadOnly = true;
            // 
            // strRuc
            // 
            this.strRuc.DataPropertyName = "strRuc";
            this.strRuc.HeaderText = "RUC";
            this.strRuc.Name = "strRuc";
            this.strRuc.ReadOnly = true;
            // 
            // strDni
            // 
            this.strDni.DataPropertyName = "strDni";
            this.strDni.HeaderText = "DNI";
            this.strDni.Name = "strDni";
            this.strDni.ReadOnly = true;
            // 
            // strDireccion
            // 
            this.strDireccion.DataPropertyName = "strDireccion";
            this.strDireccion.HeaderText = "Dirección";
            this.strDireccion.Name = "strDireccion";
            this.strDireccion.ReadOnly = true;
            // 
            // strMail
            // 
            this.strMail.DataPropertyName = "strMail";
            this.strMail.HeaderText = "Correo";
            this.strMail.Name = "strMail";
            this.strMail.ReadOnly = true;
            // 
            // strTlfFijo
            // 
            this.strTlfFijo.DataPropertyName = "strTlfFijo";
            this.strTlfFijo.HeaderText = "Tlf Fijo";
            this.strTlfFijo.Name = "strTlfFijo";
            this.strTlfFijo.ReadOnly = true;
            // 
            // strTlfMovil
            // 
            this.strTlfMovil.DataPropertyName = "strTlfMovil";
            this.strTlfMovil.HeaderText = "Tlf Movil";
            this.strTlfMovil.Name = "strTlfMovil";
            this.strTlfMovil.ReadOnly = true;
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
            this.panel2.Location = new System.Drawing.Point(767, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(16, 393);
            this.panel2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(16, 68);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(751, 10);
            this.panel3.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(16, 451);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(751, 10);
            this.panel4.TabIndex = 7;
            // 
            // Clientes_Listado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(783, 461);
            this.Controls.Add(this.dgvLista);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Clientes_Listado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "1040";
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.Clientes_Listado_Load);
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
        public System.Windows.Forms.BindingNavigator bindingNavigator1;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn intIdCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn strCoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn strNoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn strRazSoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn strApePat;
        private System.Windows.Forms.DataGridViewTextBoxColumn strApeMat;
        private System.Windows.Forms.DataGridViewTextBoxColumn strNom1;
        private System.Windows.Forms.DataGridViewTextBoxColumn strNom2;
        private System.Windows.Forms.DataGridViewTextBoxColumn strRuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn strDni;
        private System.Windows.Forms.DataGridViewTextBoxColumn strDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn strMail;
        private System.Windows.Forms.DataGridViewTextBoxColumn strTlfFijo;
        private System.Windows.Forms.DataGridViewTextBoxColumn strTlfMovil;
    }
}