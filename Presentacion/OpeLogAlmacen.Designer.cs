﻿namespace Presentacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpeLogAlmacen));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtIdAlm = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dgvListaOpeLog = new System.Windows.Forms.DataGridView();
            this.id_OpeLog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_OpeLog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_OpeLog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvListaOpeLogAcc = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strNoTipoOpe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPasa = new System.Windows.Forms.Button();
            this.btnSaca = new System.Windows.Forms.Button();
            this.cbxAlmacen = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPasaTodo = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxSede = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxFiltro = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxFiltro2 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaOpeLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaOpeLogAcc)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtIdAlm
            // 
            this.txtIdAlm.Location = new System.Drawing.Point(20, 38);
            this.txtIdAlm.Name = "txtIdAlm";
            this.txtIdAlm.ReadOnly = true;
            this.txtIdAlm.Size = new System.Drawing.Size(27, 20);
            this.txtIdAlm.TabIndex = 100;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(611, 555);
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
            this.btnCancelar.Location = new System.Drawing.Point(692, 555);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 25);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dgvListaOpeLog
            // 
            this.dgvListaOpeLog.AllowUserToAddRows = false;
            this.dgvListaOpeLog.AllowUserToDeleteRows = false;
            this.dgvListaOpeLog.AllowUserToResizeColumns = false;
            this.dgvListaOpeLog.AllowUserToResizeRows = false;
            this.dgvListaOpeLog.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaOpeLog.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaOpeLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListaOpeLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaOpeLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_OpeLog,
            this.tipo_OpeLog,
            this.nombre_OpeLog});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListaOpeLog.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListaOpeLog.Location = new System.Drawing.Point(15, 135);
            this.dgvListaOpeLog.Name = "dgvListaOpeLog";
            this.dgvListaOpeLog.ReadOnly = true;
            this.dgvListaOpeLog.RowHeadersWidth = 20;
            this.dgvListaOpeLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvListaOpeLog.Size = new System.Drawing.Size(350, 400);
            this.dgvListaOpeLog.TabIndex = 2;
            // 
            // id_OpeLog
            // 
            this.id_OpeLog.DataPropertyName = "id_OpeLog";
            this.id_OpeLog.HeaderText = "Id";
            this.id_OpeLog.Name = "id_OpeLog";
            this.id_OpeLog.ReadOnly = true;
            this.id_OpeLog.Visible = false;
            // 
            // tipo_OpeLog
            // 
            this.tipo_OpeLog.DataPropertyName = "tipo_OpeLog";
            this.tipo_OpeLog.HeaderText = "Tipo";
            this.tipo_OpeLog.Name = "tipo_OpeLog";
            this.tipo_OpeLog.ReadOnly = true;
            // 
            // nombre_OpeLog
            // 
            this.nombre_OpeLog.DataPropertyName = "nombre_OpeLog";
            this.nombre_OpeLog.HeaderText = "Operación";
            this.nombre_OpeLog.MaxInputLength = 100;
            this.nombre_OpeLog.Name = "nombre_OpeLog";
            this.nombre_OpeLog.ReadOnly = true;
            this.nombre_OpeLog.Width = 250;
            // 
            // dgvListaOpeLogAcc
            // 
            this.dgvListaOpeLogAcc.AllowUserToAddRows = false;
            this.dgvListaOpeLogAcc.AllowUserToDeleteRows = false;
            this.dgvListaOpeLogAcc.AllowUserToResizeColumns = false;
            this.dgvListaOpeLogAcc.AllowUserToResizeRows = false;
            this.dgvListaOpeLogAcc.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaOpeLogAcc.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaOpeLogAcc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvListaOpeLogAcc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaOpeLogAcc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.strNoTipoOpe,
            this.nombre});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListaOpeLogAcc.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvListaOpeLogAcc.Location = new System.Drawing.Point(417, 135);
            this.dgvListaOpeLogAcc.Name = "dgvListaOpeLogAcc";
            this.dgvListaOpeLogAcc.RowHeadersWidth = 20;
            this.dgvListaOpeLogAcc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvListaOpeLogAcc.Size = new System.Drawing.Size(350, 400);
            this.dgvListaOpeLogAcc.TabIndex = 4;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // strNoTipoOpe
            // 
            this.strNoTipoOpe.DataPropertyName = "tipo";
            this.strNoTipoOpe.HeaderText = "Tipo";
            this.strNoTipoOpe.Name = "strNoTipoOpe";
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "Operación";
            this.nombre.Name = "nombre";
            this.nombre.Width = 250;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 13);
            this.label3.TabIndex = 106;
            this.label3.Text = "Operaciones Disponibles:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(415, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 13);
            this.label4.TabIndex = 106;
            this.label4.Text = "Operaciones con Acceso:";
            // 
            // btnPasa
            // 
            this.btnPasa.Location = new System.Drawing.Point(371, 291);
            this.btnPasa.Name = "btnPasa";
            this.btnPasa.Size = new System.Drawing.Size(40, 30);
            this.btnPasa.TabIndex = 3;
            this.btnPasa.Text = "==>";
            this.btnPasa.UseVisualStyleBackColor = true;
            this.btnPasa.Click += new System.EventHandler(this.btnPasa_Click);
            // 
            // btnSaca
            // 
            this.btnSaca.Location = new System.Drawing.Point(371, 341);
            this.btnSaca.Name = "btnSaca";
            this.btnSaca.Size = new System.Drawing.Size(40, 30);
            this.btnSaca.TabIndex = 5;
            this.btnSaca.Text = "<==";
            this.btnSaca.UseVisualStyleBackColor = true;
            this.btnSaca.Click += new System.EventHandler(this.btnSaca_Click);
            // 
            // cbxAlmacen
            // 
            this.cbxAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAlmacen.FormattingEnabled = true;
            this.cbxAlmacen.Location = new System.Drawing.Point(467, 53);
            this.cbxAlmacen.Name = "cbxAlmacen";
            this.cbxAlmacen.Size = new System.Drawing.Size(300, 21);
            this.cbxAlmacen.TabIndex = 1;
            this.cbxAlmacen.SelectedIndexChanged += new System.EventHandler(this.cbxAlmacen_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(414, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 106;
            this.label1.Text = "Almacen:";
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.BackColor = System.Drawing.Color.Transparent;
            this.lblEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpresa.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblEmpresa.Location = new System.Drawing.Point(12, 30);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(350, 32);
            this.lblEmpresa.TabIndex = 109;
            this.lblEmpresa.Text = "Empresa";
            this.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEmpresa.Click += new System.EventHandler(this.lblEmpresa_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 106;
            this.label2.Text = "Empresa:";
            // 
            // btnPasaTodo
            // 
            this.btnPasaTodo.Location = new System.Drawing.Point(371, 400);
            this.btnPasaTodo.Name = "btnPasaTodo";
            this.btnPasaTodo.Size = new System.Drawing.Size(40, 30);
            this.btnPasaTodo.TabIndex = 6;
            this.btnPasaTodo.Text = "==>>";
            this.btnPasaTodo.UseVisualStyleBackColor = true;
            this.btnPasaTodo.Click += new System.EventHandler(this.btnPasaTodo_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(430, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 110;
            this.label5.Text = "Sede:";
            // 
            // cbxSede
            // 
            this.cbxSede.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSede.FormattingEnabled = true;
            this.cbxSede.Location = new System.Drawing.Point(467, 17);
            this.cbxSede.Name = "cbxSede";
            this.cbxSede.Size = new System.Drawing.Size(300, 21);
            this.cbxSede.TabIndex = 111;
            this.cbxSede.SelectedIndexChanged += new System.EventHandler(this.cbxSede_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbxFiltro);
            this.groupBox1.Location = new System.Drawing.Point(15, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 52);
            this.groupBox1.TabIndex = 112;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(185, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Filtro:";
            // 
            // cbxFiltro
            // 
            this.cbxFiltro.FormattingEnabled = true;
            this.cbxFiltro.Location = new System.Drawing.Point(223, 19);
            this.cbxFiltro.Name = "cbxFiltro";
            this.cbxFiltro.Size = new System.Drawing.Size(121, 21);
            this.cbxFiltro.TabIndex = 10;
            this.cbxFiltro.SelectedIndexChanged += new System.EventHandler(this.cbxFiltro_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cbxFiltro2);
            this.groupBox2.Location = new System.Drawing.Point(418, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(349, 52);
            this.groupBox2.TabIndex = 112;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtro";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(184, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Filtro:";
            // 
            // cbxFiltro2
            // 
            this.cbxFiltro2.FormattingEnabled = true;
            this.cbxFiltro2.Location = new System.Drawing.Point(222, 19);
            this.cbxFiltro2.Name = "cbxFiltro2";
            this.cbxFiltro2.Size = new System.Drawing.Size(121, 21);
            this.cbxFiltro2.TabIndex = 10;
            this.cbxFiltro2.SelectedIndexChanged += new System.EventHandler(this.cbxFiltro2_SelectedIndexChanged);
            // 
            // OpeLogAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(784, 592);
            this.ControlBox = false;
            this.Controls.Add(this.cbxSede);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnPasaTodo);
            this.Controls.Add(this.lblEmpresa);
            this.Controls.Add(this.cbxAlmacen);
            this.Controls.Add(this.btnSaca);
            this.Controls.Add(this.btnPasa);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvListaOpeLogAcc);
            this.Controls.Add(this.dgvListaOpeLog);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtIdAlm);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "OpeLogAlmacen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "101020";
            this.Text = "Operacion Logistica - Almacen";
            this.Load += new System.EventHandler(this.OpeLogAlmacen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaOpeLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaOpeLogAcc)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.ComboBox cbxAlmacen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_OpeLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_OpeLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_OpeLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn strNoTipoOpe;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.Button btnPasaTodo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxSede;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxFiltro;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxFiltro2;
    }
}