namespace Presentacion
{
    partial class BtnMenu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BtnMenu));
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblMenu = new System.Windows.Forms.Label();
            this.dgvListaBtn = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intIdUsuBtnMenu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intIdUsuMenu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.boton = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(79, 24);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(43, 13);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuario";
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSize = true;
            this.lblMenu.Location = new System.Drawing.Point(79, 51);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(34, 13);
            this.lblMenu.TabIndex = 0;
            this.lblMenu.Text = "Menu";
            // 
            // dgvListaBtn
            // 
            this.dgvListaBtn.AllowUserToAddRows = false;
            this.dgvListaBtn.AllowUserToDeleteRows = false;
            this.dgvListaBtn.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaBtn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaBtn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.intIdUsuBtnMenu,
            this.intIdUsuMenu,
            this.valor,
            this.boton});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListaBtn.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListaBtn.Location = new System.Drawing.Point(29, 89);
            this.dgvListaBtn.Name = "dgvListaBtn";
            this.dgvListaBtn.RowHeadersWidth = 20;
            this.dgvListaBtn.Size = new System.Drawing.Size(272, 438);
            this.dgvListaBtn.TabIndex = 1;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // intIdUsuBtnMenu
            // 
            this.intIdUsuBtnMenu.DataPropertyName = "intIdUsuBtnMenu";
            this.intIdUsuBtnMenu.HeaderText = "intIdUsuBtnMenu";
            this.intIdUsuBtnMenu.Name = "intIdUsuBtnMenu";
            this.intIdUsuBtnMenu.ReadOnly = true;
            this.intIdUsuBtnMenu.Visible = false;
            this.intIdUsuBtnMenu.Width = 40;
            // 
            // intIdUsuMenu
            // 
            this.intIdUsuMenu.DataPropertyName = "intIdUsuMenu";
            this.intIdUsuMenu.HeaderText = "ID";
            this.intIdUsuMenu.Name = "intIdUsuMenu";
            this.intIdUsuMenu.ReadOnly = true;
            this.intIdUsuMenu.Width = 40;
            // 
            // valor
            // 
            this.valor.DataPropertyName = "valor";
            this.valor.FalseValue = "0";
            this.valor.HeaderText = "valor";
            this.valor.Name = "valor";
            this.valor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.valor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.valor.TrueValue = "1";
            this.valor.Width = 60;
            // 
            // boton
            // 
            this.boton.DataPropertyName = "boton";
            this.boton.HeaderText = "boton";
            this.boton.Name = "boton";
            this.boton.ReadOnly = true;
            this.boton.Width = 159;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(226, 533);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 25);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(145, 533);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 25);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Menu:";
            // 
            // BtnMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 570);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dgvListaBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMenu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblUsuario);
            this.Name = "BtnMenu";
            this.Text = "BtnMenu";
            this.Load += new System.EventHandler(this.BtnMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.DataGridView dgvListaBtn;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn intIdUsuBtnMenu;
        private System.Windows.Forms.DataGridViewTextBoxColumn intIdUsuMenu;
        private System.Windows.Forms.DataGridViewCheckBoxColumn valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn boton;
    }
}