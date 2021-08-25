namespace Presentacion
{
    partial class CambioEmpresa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CambioEmpresa));
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.intIdEmp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strCoEmp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strNoEmp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dttFeCr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.intIdEmp,
            this.strCoEmp,
            this.strNoEmp,
            this.intEstado,
            this.dttFeCr});
            this.dgvItems.Location = new System.Drawing.Point(13, 12);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersWidth = 20;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(344, 384);
            this.dgvItems.TabIndex = 1000;
            this.dgvItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvItems_KeyDown);
            // 
            // intIdEmp
            // 
            this.intIdEmp.DataPropertyName = "intIdEmp";
            this.intIdEmp.HeaderText = "ID";
            this.intIdEmp.Name = "intIdEmp";
            this.intIdEmp.ReadOnly = true;
            // 
            // strCoEmp
            // 
            this.strCoEmp.DataPropertyName = "strCoEmp";
            this.strCoEmp.HeaderText = "Código";
            this.strCoEmp.Name = "strCoEmp";
            this.strCoEmp.ReadOnly = true;
            // 
            // strNoEmp
            // 
            this.strNoEmp.DataPropertyName = "strNoEmp";
            this.strNoEmp.HeaderText = "Empresa";
            this.strNoEmp.Name = "strNoEmp";
            this.strNoEmp.ReadOnly = true;
            // 
            // intEstado
            // 
            this.intEstado.DataPropertyName = "intEstado";
            this.intEstado.HeaderText = "Estado";
            this.intEstado.Name = "intEstado";
            this.intEstado.ReadOnly = true;
            this.intEstado.Visible = false;
            // 
            // dttFeCr
            // 
            this.dttFeCr.DataPropertyName = "dttFeCr";
            this.dttFeCr.HeaderText = "Fecha";
            this.dttFeCr.Name = "dttFeCr";
            this.dttFeCr.ReadOnly = true;
            this.dttFeCr.Visible = false;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(200, 403);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 25);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(282, 403);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 25);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // CambioEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 436);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dgvItems);
            this.Name = "CambioEmpresa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cambiar Empresa";
            this.Load += new System.EventHandler(this.CambioEmpresa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn intIdEmp;
        private System.Windows.Forms.DataGridViewTextBoxColumn strCoEmp;
        private System.Windows.Forms.DataGridViewTextBoxColumn strNoEmp;
        private System.Windows.Forms.DataGridViewTextBoxColumn intEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn dttFeCr;
    }
}