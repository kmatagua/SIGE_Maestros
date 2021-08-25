﻿namespace Presentacion
{
    partial class FamiliaEmpresa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FamiliaEmpresa));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtIdEmp = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dgvListaFamilia = new System.Windows.Forms.DataGridView();
            this.id_Familia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_Familia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvListaFamiliaAcc = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPasa = new System.Windows.Forms.Button();
            this.btnSaca = new System.Windows.Forms.Button();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPasaTodo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaFamilia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaFamiliaAcc)).BeginInit();
            this.SuspendLayout();
            // 
            // txtIdEmp
            // 
            this.txtIdEmp.Location = new System.Drawing.Point(421, 38);
            this.txtIdEmp.Name = "txtIdEmp";
            this.txtIdEmp.ReadOnly = true;
            this.txtIdEmp.Size = new System.Drawing.Size(27, 20);
            this.txtIdEmp.TabIndex = 100;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(611, 524);
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
            this.btnCancelar.Location = new System.Drawing.Point(692, 524);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 25);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dgvListaFamilia
            // 
            this.dgvListaFamilia.AllowUserToAddRows = false;
            this.dgvListaFamilia.AllowUserToDeleteRows = false;
            this.dgvListaFamilia.AllowUserToResizeColumns = false;
            this.dgvListaFamilia.AllowUserToResizeRows = false;
            this.dgvListaFamilia.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaFamilia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListaFamilia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaFamilia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_Familia,
            this.nombre_Familia});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListaFamilia.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListaFamilia.Location = new System.Drawing.Point(15, 104);
            this.dgvListaFamilia.Name = "dgvListaFamilia";
            this.dgvListaFamilia.ReadOnly = true;
            this.dgvListaFamilia.RowHeadersWidth = 20;
            this.dgvListaFamilia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaFamilia.Size = new System.Drawing.Size(350, 400);
            this.dgvListaFamilia.TabIndex = 101;
            // 
            // id_Familia
            // 
            this.id_Familia.DataPropertyName = "id_Familia";
            this.id_Familia.HeaderText = "ID";
            this.id_Familia.Name = "id_Familia";
            this.id_Familia.ReadOnly = true;
            this.id_Familia.Width = 40;
            // 
            // nombre_Familia
            // 
            this.nombre_Familia.DataPropertyName = "nombre_Familia";
            this.nombre_Familia.HeaderText = "Familia";
            this.nombre_Familia.Name = "nombre_Familia";
            this.nombre_Familia.ReadOnly = true;
            this.nombre_Familia.Width = 307;
            // 
            // dgvListaFamiliaAcc
            // 
            this.dgvListaFamiliaAcc.AllowUserToAddRows = false;
            this.dgvListaFamiliaAcc.AllowUserToDeleteRows = false;
            this.dgvListaFamiliaAcc.AllowUserToResizeColumns = false;
            this.dgvListaFamiliaAcc.AllowUserToResizeRows = false;
            this.dgvListaFamiliaAcc.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaFamiliaAcc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvListaFamiliaAcc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaFamiliaAcc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nombre});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListaFamiliaAcc.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvListaFamiliaAcc.Location = new System.Drawing.Point(417, 104);
            this.dgvListaFamiliaAcc.Name = "dgvListaFamiliaAcc";
            this.dgvListaFamiliaAcc.RowHeadersWidth = 20;
            this.dgvListaFamiliaAcc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaFamiliaAcc.Size = new System.Drawing.Size(350, 400);
            this.dgvListaFamiliaAcc.TabIndex = 102;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.Width = 40;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "Familia";
            this.nombre.Name = "nombre";
            this.nombre.Width = 307;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 106;
            this.label3.Text = "Familias Disponibles";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(414, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 106;
            this.label4.Text = "Familias con Acceso";
            // 
            // btnPasa
            // 
            this.btnPasa.Location = new System.Drawing.Point(371, 260);
            this.btnPasa.Name = "btnPasa";
            this.btnPasa.Size = new System.Drawing.Size(40, 30);
            this.btnPasa.TabIndex = 107;
            this.btnPasa.Text = "==>";
            this.btnPasa.UseVisualStyleBackColor = true;
            this.btnPasa.Click += new System.EventHandler(this.btnPasa_Click);
            // 
            // btnSaca
            // 
            this.btnSaca.Location = new System.Drawing.Point(371, 310);
            this.btnSaca.Name = "btnSaca";
            this.btnSaca.Size = new System.Drawing.Size(40, 30);
            this.btnSaca.TabIndex = 108;
            this.btnSaca.Text = "<==";
            this.btnSaca.UseVisualStyleBackColor = true;
            this.btnSaca.Click += new System.EventHandler(this.btnSaca_Click);
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.BackColor = System.Drawing.Color.Transparent;
            this.lblEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpresa.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblEmpresa.Location = new System.Drawing.Point(414, 34);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(350, 32);
            this.lblEmpresa.TabIndex = 109;
            this.lblEmpresa.Text = "label1";
            this.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(414, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 106;
            this.label1.Text = "Empresa:";
            // 
            // btnPasaTodo
            // 
            this.btnPasaTodo.Location = new System.Drawing.Point(371, 371);
            this.btnPasaTodo.Name = "btnPasaTodo";
            this.btnPasaTodo.Size = new System.Drawing.Size(40, 30);
            this.btnPasaTodo.TabIndex = 114;
            this.btnPasaTodo.Text = "==>>";
            this.btnPasaTodo.UseVisualStyleBackColor = true;
            this.btnPasaTodo.Click += new System.EventHandler(this.btnPasaTodo_Click);
            // 
            // FamiliaEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnPasaTodo);
            this.Controls.Add(this.lblEmpresa);
            this.Controls.Add(this.btnSaca);
            this.Controls.Add(this.btnPasa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvListaFamiliaAcc);
            this.Controls.Add(this.dgvListaFamilia);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtIdEmp);
            this.Name = "FamiliaEmpresa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "106020";
            this.Text = "Familias Empresas";
            this.Load += new System.EventHandler(this.FamiliaEmpresa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaFamilia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaFamiliaAcc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIdEmp;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridView dgvListaFamilia;
        private System.Windows.Forms.DataGridView dgvListaFamiliaAcc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPasa;
        private System.Windows.Forms.Button btnSaca;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_Familia;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_Familia;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.Button btnPasaTodo;
    }
}