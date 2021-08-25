namespace Presentacion
{
    partial class Asignar_Num_Default
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Asignar_Num_Default));
            this.cbxTipoDoc = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvNum = new System.Windows.Forms.DataGridView();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.intIdUsuNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intIdUsu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intIdNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intDefault = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.intIdEmp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strSerie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strObservacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intIdTipDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNum)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxTipoDoc
            // 
            this.cbxTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipoDoc.FormattingEnabled = true;
            this.cbxTipoDoc.Location = new System.Drawing.Point(73, 24);
            this.cbxTipoDoc.Name = "cbxTipoDoc";
            this.cbxTipoDoc.Size = new System.Drawing.Size(215, 21);
            this.cbxTipoDoc.TabIndex = 0;
            this.cbxTipoDoc.SelectedIndexChanged += new System.EventHandler(this.cbxTipoDoc_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tipo Doc.";
            // 
            // dgvNum
            // 
            this.dgvNum.AllowUserToAddRows = false;
            this.dgvNum.AllowUserToDeleteRows = false;
            this.dgvNum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNum.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.intIdUsuNum,
            this.intIdUsu,
            this.intIdNum,
            this.intDefault,
            this.intIdEmp,
            this.strSerie,
            this.strNumero,
            this.strObservacion,
            this.intIdTipDoc});
            this.dgvNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNum.Location = new System.Drawing.Point(10, 61);
            this.dgvNum.Name = "dgvNum";
            this.dgvNum.Size = new System.Drawing.Size(526, 230);
            this.dgvNum.TabIndex = 2;
            this.dgvNum.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNum_CellValueChanged);
            this.dgvNum.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvNum_CurrentCellDirtyStateChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(459, 14);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 31);
            this.btnCancelar.TabIndex = 33;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(377, 14);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 31);
            this.btnGuardar.TabIndex = 32;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbxTipoDoc);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(546, 61);
            this.panel1.TabIndex = 34;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCancelar);
            this.panel2.Controls.Add(this.btnGuardar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 291);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(546, 51);
            this.panel2.TabIndex = 35;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 61);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 230);
            this.panel3.TabIndex = 36;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(536, 61);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 230);
            this.panel4.TabIndex = 37;
            // 
            // intIdUsuNum
            // 
            this.intIdUsuNum.DataPropertyName = "intIdUsuNum";
            this.intIdUsuNum.HeaderText = "idUsuNum";
            this.intIdUsuNum.Name = "intIdUsuNum";
            this.intIdUsuNum.Visible = false;
            // 
            // intIdUsu
            // 
            this.intIdUsu.DataPropertyName = "intIdUsu";
            this.intIdUsu.HeaderText = "idUsu";
            this.intIdUsu.Name = "intIdUsu";
            this.intIdUsu.Visible = false;
            // 
            // intIdNum
            // 
            this.intIdNum.DataPropertyName = "intIdNum";
            this.intIdNum.HeaderText = "idNum";
            this.intIdNum.Name = "intIdNum";
            this.intIdNum.Visible = false;
            // 
            // intDefault
            // 
            this.intDefault.DataPropertyName = "intDefault";
            this.intDefault.FalseValue = "0";
            this.intDefault.HeaderText = "Act.";
            this.intDefault.Name = "intDefault";
            this.intDefault.TrueValue = "1";
            this.intDefault.Width = 30;
            // 
            // intIdEmp
            // 
            this.intIdEmp.DataPropertyName = "intIdEmp";
            this.intIdEmp.HeaderText = "idEmp";
            this.intIdEmp.Name = "intIdEmp";
            this.intIdEmp.Visible = false;
            // 
            // strSerie
            // 
            this.strSerie.DataPropertyName = "strSerie";
            this.strSerie.HeaderText = "Serie";
            this.strSerie.Name = "strSerie";
            // 
            // strNumero
            // 
            this.strNumero.DataPropertyName = "strNumero";
            this.strNumero.HeaderText = "Nro";
            this.strNumero.Name = "strNumero";
            // 
            // strObservacion
            // 
            this.strObservacion.DataPropertyName = "strObservacion";
            this.strObservacion.HeaderText = "Observación";
            this.strObservacion.Name = "strObservacion";
            this.strObservacion.Width = 250;
            // 
            // intIdTipDoc
            // 
            this.intIdTipDoc.DataPropertyName = "intIdTipDoc";
            this.intIdTipDoc.HeaderText = "idTipoDoc";
            this.intIdTipDoc.Name = "intIdTipDoc";
            this.intIdTipDoc.Visible = false;
            // 
            // Asignar_Num_Default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 342);
            this.Controls.Add(this.dgvNum);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "Asignar_Num_Default";
            this.Text = "Numerador por Defecto";
            this.Load += new System.EventHandler(this.Asignar_Num_Default_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNum)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxTipoDoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvNum;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridViewTextBoxColumn intIdUsuNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn intIdUsu;
        private System.Windows.Forms.DataGridViewTextBoxColumn intIdNum;
        private System.Windows.Forms.DataGridViewCheckBoxColumn intDefault;
        private System.Windows.Forms.DataGridViewTextBoxColumn intIdEmp;
        private System.Windows.Forms.DataGridViewTextBoxColumn strSerie;
        private System.Windows.Forms.DataGridViewTextBoxColumn strNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn strObservacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn intIdTipDoc;
    }
}