namespace Presentacion
{
    partial class Config_Almacen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Config_Almacen));
            this.txtIdEmp = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxAlmacen = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkVentas = new System.Windows.Forms.CheckBox();
            this.cbxTab = new System.Windows.Forms.ComboBox();
            this.chkValidaCero = new System.Windows.Forms.CheckBox();
            this.chkValidaStock = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkAprobIng = new System.Windows.Forms.CheckBox();
            this.chkAprobSal = new System.Windows.Forms.CheckBox();
            this.chkAuditIng = new System.Windows.Forms.CheckBox();
            this.chkAuditSal = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtIdEmp
            // 
            this.txtIdEmp.Location = new System.Drawing.Point(12, 21);
            this.txtIdEmp.Name = "txtIdEmp";
            this.txtIdEmp.ReadOnly = true;
            this.txtIdEmp.Size = new System.Drawing.Size(27, 20);
            this.txtIdEmp.TabIndex = 100;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(209, 322);
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
            this.btnCancelar.Location = new System.Drawing.Point(290, 322);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 25);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.BackColor = System.Drawing.Color.Transparent;
            this.lblEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpresa.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblEmpresa.Location = new System.Drawing.Point(12, 19);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(336, 32);
            this.lblEmpresa.TabIndex = 102;
            this.lblEmpresa.Text = "Empresa";
            this.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Empresa:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Almacen:";
            // 
            // cbxAlmacen
            // 
            this.cbxAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAlmacen.FormattingEnabled = true;
            this.cbxAlmacen.Location = new System.Drawing.Point(71, 54);
            this.cbxAlmacen.Name = "cbxAlmacen";
            this.cbxAlmacen.Size = new System.Drawing.Size(256, 21);
            this.cbxAlmacen.TabIndex = 1;
            this.cbxAlmacen.SelectedIndexChanged += new System.EventHandler(this.cbxAlmacen_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAuditSal);
            this.groupBox1.Controls.Add(this.chkAuditIng);
            this.groupBox1.Controls.Add(this.chkAprobSal);
            this.groupBox1.Controls.Add(this.chkAprobIng);
            this.groupBox1.Controls.Add(this.chkVentas);
            this.groupBox1.Controls.Add(this.cbxTab);
            this.groupBox1.Controls.Add(this.chkValidaCero);
            this.groupBox1.Controls.Add(this.chkValidaStock);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(349, 212);
            this.groupBox1.TabIndex = 103;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuracion";
            // 
            // chkVentas
            // 
            this.chkVentas.AutoSize = true;
            this.chkVentas.Location = new System.Drawing.Point(156, 78);
            this.chkVentas.Name = "chkVentas";
            this.chkVentas.Size = new System.Drawing.Size(97, 17);
            this.chkVentas.TabIndex = 10;
            this.chkVentas.Text = "Permite Ventas";
            this.chkVentas.UseVisualStyleBackColor = true;
            // 
            // cbxTab
            // 
            this.cbxTab.FormattingEnabled = true;
            this.cbxTab.Location = new System.Drawing.Point(156, 30);
            this.cbxTab.Name = "cbxTab";
            this.cbxTab.Size = new System.Drawing.Size(176, 21);
            this.cbxTab.TabIndex = 1;
            // 
            // chkValidaCero
            // 
            this.chkValidaCero.AutoSize = true;
            this.chkValidaCero.Location = new System.Drawing.Point(17, 78);
            this.chkValidaCero.Name = "chkValidaCero";
            this.chkValidaCero.Size = new System.Drawing.Size(85, 17);
            this.chkValidaCero.TabIndex = 0;
            this.chkValidaCero.Text = "Valida Ceros";
            this.chkValidaCero.UseVisualStyleBackColor = true;
            // 
            // chkValidaStock
            // 
            this.chkValidaStock.AutoSize = true;
            this.chkValidaStock.Location = new System.Drawing.Point(17, 34);
            this.chkValidaStock.Name = "chkValidaStock";
            this.chkValidaStock.Size = new System.Drawing.Size(86, 17);
            this.chkValidaStock.TabIndex = 0;
            this.chkValidaStock.Text = "Valida Stock";
            this.chkValidaStock.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tabs:";
            // 
            // chkAprobIng
            // 
            this.chkAprobIng.AutoSize = true;
            this.chkAprobIng.Location = new System.Drawing.Point(17, 119);
            this.chkAprobIng.Name = "chkAprobIng";
            this.chkAprobIng.Size = new System.Drawing.Size(109, 17);
            this.chkAprobIng.TabIndex = 11;
            this.chkAprobIng.Text = "Aprueba Ingresos";
            this.chkAprobIng.UseVisualStyleBackColor = true;
            // 
            // chkAprobSal
            // 
            this.chkAprobSal.AutoSize = true;
            this.chkAprobSal.Location = new System.Drawing.Point(17, 164);
            this.chkAprobSal.Name = "chkAprobSal";
            this.chkAprobSal.Size = new System.Drawing.Size(103, 17);
            this.chkAprobSal.TabIndex = 11;
            this.chkAprobSal.Text = "Aprueba Salidas";
            this.chkAprobSal.UseVisualStyleBackColor = true;
            // 
            // chkAuditIng
            // 
            this.chkAuditIng.AutoSize = true;
            this.chkAuditIng.Location = new System.Drawing.Point(156, 119);
            this.chkAuditIng.Name = "chkAuditIng";
            this.chkAuditIng.Size = new System.Drawing.Size(99, 17);
            this.chkAuditIng.TabIndex = 11;
            this.chkAuditIng.Text = "Audita Ingresos";
            this.chkAuditIng.UseVisualStyleBackColor = true;
            // 
            // chkAuditSal
            // 
            this.chkAuditSal.AutoSize = true;
            this.chkAuditSal.Location = new System.Drawing.Point(156, 163);
            this.chkAuditSal.Name = "chkAuditSal";
            this.chkAuditSal.Size = new System.Drawing.Size(93, 17);
            this.chkAuditSal.TabIndex = 11;
            this.chkAuditSal.Text = "Audita Salidas";
            this.chkAuditSal.UseVisualStyleBackColor = true;
            // 
            // Config_Almacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(380, 357);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblEmpresa);
            this.Controls.Add(this.cbxAlmacen);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtIdEmp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Config_Almacen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "";
            this.Text = "Almacen";
            this.Load += new System.EventHandler(this.Config_Almacen_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIdEmp;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxAlmacen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkValidaCero;
        private System.Windows.Forms.CheckBox chkValidaStock;
        private System.Windows.Forms.ComboBox cbxTab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkVentas;
        private System.Windows.Forms.CheckBox chkAuditSal;
        private System.Windows.Forms.CheckBox chkAuditIng;
        private System.Windows.Forms.CheckBox chkAprobSal;
        private System.Windows.Forms.CheckBox chkAprobIng;
    }
}