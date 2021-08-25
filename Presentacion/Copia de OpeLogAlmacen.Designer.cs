namespace Presentacion
{
    partial class OpeLogAlmacen
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
            this.txtIdAlm = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dgvListaOpeLog = new System.Windows.Forms.DataGridView();
            this.id_OpeLog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_OpeLog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvListaOpeLogAcc = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPasa = new System.Windows.Forms.Button();
            this.btnSaca = new System.Windows.Forms.Button();
            this.cbxAlmacen = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEmpresa = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaOpeLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaOpeLogAcc)).BeginInit();
            this.SuspendLayout();
            // 
            // txtIdAlm
            // 
            this.txtIdAlm.Location = new System.Drawing.Point(13, 12);
            this.txtIdAlm.Name = "txtIdAlm";
            this.txtIdAlm.ReadOnly = true;
            this.txtIdAlm.Size = new System.Drawing.Size(27, 20);
            this.txtIdAlm.TabIndex = 100;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(400, 454);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(481, 454);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dgvListaOpeLog
            // 
            this.dgvListaOpeLog.AllowUserToAddRows = false;
            this.dgvListaOpeLog.AllowUserToDeleteRows = false;
            this.dgvListaOpeLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaOpeLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_OpeLog,
            this.nombre_OpeLog});
            this.dgvListaOpeLog.Location = new System.Drawing.Point(12, 104);
            this.dgvListaOpeLog.Name = "dgvListaOpeLog";
            this.dgvListaOpeLog.ReadOnly = true;
            this.dgvListaOpeLog.Size = new System.Drawing.Size(240, 333);
            this.dgvListaOpeLog.TabIndex = 101;
            // 
            // id_OpeLog
            // 
            this.id_OpeLog.DataPropertyName = "id_OpeLog";
            this.id_OpeLog.HeaderText = "ID";
            this.id_OpeLog.Name = "id_OpeLog";
            this.id_OpeLog.ReadOnly = true;
            this.id_OpeLog.Visible = false;
            // 
            // nombre_OpeLog
            // 
            this.nombre_OpeLog.DataPropertyName = "nombre_OpeLog";
            this.nombre_OpeLog.HeaderText = "OPERACION";
            this.nombre_OpeLog.Name = "nombre_OpeLog";
            this.nombre_OpeLog.ReadOnly = true;
            this.nombre_OpeLog.Width = 197;
            // 
            // dgvListaOpeLogAcc
            // 
            this.dgvListaOpeLogAcc.AllowUserToAddRows = false;
            this.dgvListaOpeLogAcc.AllowUserToDeleteRows = false;
            this.dgvListaOpeLogAcc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaOpeLogAcc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nombre});
            this.dgvListaOpeLogAcc.Location = new System.Drawing.Point(315, 104);
            this.dgvListaOpeLogAcc.Name = "dgvListaOpeLogAcc";
            this.dgvListaOpeLogAcc.Size = new System.Drawing.Size(240, 333);
            this.dgvListaOpeLogAcc.TabIndex = 102;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "OPERACION";
            this.nombre.Name = "nombre";
            this.nombre.Width = 197;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 106;
            this.label3.Text = "Operaciones Disponibles";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(312, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 13);
            this.label4.TabIndex = 106;
            this.label4.Text = "Operaciones con Acceso";
            // 
            // btnPasa
            // 
            this.btnPasa.Location = new System.Drawing.Point(259, 254);
            this.btnPasa.Name = "btnPasa";
            this.btnPasa.Size = new System.Drawing.Size(50, 40);
            this.btnPasa.TabIndex = 107;
            this.btnPasa.Text = ">";
            this.btnPasa.UseVisualStyleBackColor = true;
            this.btnPasa.Click += new System.EventHandler(this.btnPasa_Click);
            // 
            // btnSaca
            // 
            this.btnSaca.Location = new System.Drawing.Point(259, 323);
            this.btnSaca.Name = "btnSaca";
            this.btnSaca.Size = new System.Drawing.Size(50, 40);
            this.btnSaca.TabIndex = 108;
            this.btnSaca.Text = "<";
            this.btnSaca.UseVisualStyleBackColor = true;
            this.btnSaca.Click += new System.EventHandler(this.btnSaca_Click);
            // 
            // cbxAlmacen
            // 
            this.cbxAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAlmacen.FormattingEnabled = true;
            this.cbxAlmacen.Location = new System.Drawing.Point(131, 52);
            this.cbxAlmacen.Name = "cbxAlmacen";
            this.cbxAlmacen.Size = new System.Drawing.Size(308, 21);
            this.cbxAlmacen.TabIndex = 1;
            this.cbxAlmacen.SelectedIndexChanged += new System.EventHandler(this.cbxAlmacen_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 106;
            this.label1.Text = "Almacen";
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblEmpresa.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpresa.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblEmpresa.Location = new System.Drawing.Point(0, 0);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(568, 32);
            this.lblEmpresa.TabIndex = 109;
            this.lblEmpresa.Text = "Empresa";
            this.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OpeLogAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 506);
            this.Controls.Add(this.lblEmpresa);
            this.Controls.Add(this.cbxAlmacen);
            this.Controls.Add(this.btnSaca);
            this.Controls.Add(this.btnPasa);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvListaOpeLogAcc);
            this.Controls.Add(this.dgvListaOpeLog);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtIdAlm);
            this.Name = "OpeLogAlmacen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "101020";
            this.Text = "Operacion Logistica - Almacen";
            this.Load += new System.EventHandler(this.OpeLogAlmacen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaOpeLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaOpeLogAcc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIdAlm;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridView dgvListaOpeLog;
        private System.Windows.Forms.DataGridView dgvListaOpeLogAcc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPasa;
        private System.Windows.Forms.Button btnSaca;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_OpeLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_OpeLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.ComboBox cbxAlmacen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEmpresa;
    }
}