namespace Presentacion
{
    partial class Usuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Usuario));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtIdUsu = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblClave = new System.Windows.Forms.Label();
            this.dgvListaEmp = new System.Windows.Forms.DataGridView();
            this.id_Emp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_Emp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvListaEmpAcc = new System.Windows.Forms.DataGridView();
            this.intDefault = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.intCompras = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.intIdEmp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPasa = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSaca = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombreCompleto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaEmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaEmpAcc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtIdUsu
            // 
            this.txtIdUsu.Location = new System.Drawing.Point(13, 12);
            this.txtIdUsu.Name = "txtIdUsu";
            this.txtIdUsu.ReadOnly = true;
            this.txtIdUsu.Size = new System.Drawing.Size(27, 20);
            this.txtIdUsu.TabIndex = 100;
            this.txtIdUsu.Visible = false;
            // 
            // txtCodigo
            // 
            this.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigo.Location = new System.Drawing.Point(342, 15);
            this.txtCodigo.MaxLength = 10;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(240, 20);
            this.txtCodigo.TabIndex = 1;
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Location = new System.Drawing.Point(342, 89);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(240, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // txtClave
            // 
            this.txtClave.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClave.Location = new System.Drawing.Point(342, 127);
            this.txtClave.MaxLength = 50;
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '*';
            this.txtClave.Size = new System.Drawing.Size(240, 20);
            this.txtClave.TabIndex = 3;
            // 
            // chkEstado
            // 
            this.chkEstado.AutoSize = true;
            this.chkEstado.Location = new System.Drawing.Point(342, 167);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(59, 17);
            this.chkEstado.TabIndex = 4;
            this.chkEstado.Text = "Estado";
            this.chkEstado.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(426, 457);
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
            this.btnCancelar.Location = new System.Drawing.Point(507, 457);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 25);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(293, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Código:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(254, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Usuario (sesion):";
            // 
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.Location = new System.Drawing.Point(302, 130);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(37, 13);
            this.lblClave.TabIndex = 9;
            this.lblClave.Text = "Clave:";
            // 
            // dgvListaEmp
            // 
            this.dgvListaEmp.AllowUserToAddRows = false;
            this.dgvListaEmp.AllowUserToDeleteRows = false;
            this.dgvListaEmp.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaEmp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListaEmp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaEmp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_Emp,
            this.nombre_Emp});
            this.dgvListaEmp.GridColor = System.Drawing.Color.White;
            this.dgvListaEmp.Location = new System.Drawing.Point(12, 215);
            this.dgvListaEmp.Name = "dgvListaEmp";
            this.dgvListaEmp.ReadOnly = true;
            this.dgvListaEmp.RowHeadersWidth = 20;
            this.dgvListaEmp.Size = new System.Drawing.Size(250, 232);
            this.dgvListaEmp.TabIndex = 101;
            // 
            // id_Emp
            // 
            this.id_Emp.DataPropertyName = "id_Emp";
            this.id_Emp.HeaderText = "ID";
            this.id_Emp.Name = "id_Emp";
            this.id_Emp.ReadOnly = true;
            this.id_Emp.Visible = false;
            // 
            // nombre_Emp
            // 
            this.nombre_Emp.DataPropertyName = "nombre_Emp";
            this.nombre_Emp.HeaderText = "Nombre Empresa";
            this.nombre_Emp.Name = "nombre_Emp";
            this.nombre_Emp.ReadOnly = true;
            this.nombre_Emp.Width = 247;
            // 
            // dgvListaEmpAcc
            // 
            this.dgvListaEmpAcc.AllowUserToAddRows = false;
            this.dgvListaEmpAcc.AllowUserToDeleteRows = false;
            this.dgvListaEmpAcc.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaEmpAcc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListaEmpAcc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaEmpAcc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.intDefault,
            this.intCompras,
            this.intIdEmp,
            this.nombre,
            this.id});
            this.dgvListaEmpAcc.Location = new System.Drawing.Point(332, 215);
            this.dgvListaEmpAcc.Name = "dgvListaEmpAcc";
            this.dgvListaEmpAcc.RowHeadersWidth = 20;
            this.dgvListaEmpAcc.Size = new System.Drawing.Size(250, 232);
            this.dgvListaEmpAcc.TabIndex = 102;
            this.dgvListaEmpAcc.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaEmpAcc_CellValueChanged);
            this.dgvListaEmpAcc.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvListaEmpAcc_CurrentCellDirtyStateChanged);
            // 
            // intDefault
            // 
            this.intDefault.DataPropertyName = "default";
            this.intDefault.FalseValue = "0";
            this.intDefault.HeaderText = "Activo";
            this.intDefault.Name = "intDefault";
            this.intDefault.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.intDefault.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.intDefault.TrueValue = "1";
            this.intDefault.Width = 40;
            // 
            // intCompras
            // 
            this.intCompras.DataPropertyName = "compras";
            this.intCompras.FalseValue = "0";
            this.intCompras.HeaderText = "AC";
            this.intCompras.Name = "intCompras";
            this.intCompras.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.intCompras.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.intCompras.TrueValue = "1";
            this.intCompras.Width = 40;
            // 
            // intIdEmp
            // 
            this.intIdEmp.DataPropertyName = "intIdEmp";
            this.intIdEmp.HeaderText = "IdEmp";
            this.intIdEmp.Name = "intIdEmp";
            this.intIdEmp.Visible = false;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "Nombre Empresa";
            this.nombre.Name = "nombre";
            this.nombre.Width = 207;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // btnPasa
            // 
            this.btnPasa.Location = new System.Drawing.Point(277, 279);
            this.btnPasa.Name = "btnPasa";
            this.btnPasa.Size = new System.Drawing.Size(40, 30);
            this.btnPasa.TabIndex = 103;
            this.btnPasa.Text = "==>";
            this.btnPasa.UseVisualStyleBackColor = true;
            this.btnPasa.Click += new System.EventHandler(this.btnPasa_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(63, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(101, 116);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 104;
            this.pictureBox1.TabStop = false;
            // 
            // btnSaca
            // 
            this.btnSaca.Location = new System.Drawing.Point(277, 338);
            this.btnSaca.Name = "btnSaca";
            this.btnSaca.Size = new System.Drawing.Size(40, 30);
            this.btnSaca.TabIndex = 105;
            this.btnSaca.Text = "<==";
            this.btnSaca.UseVisualStyleBackColor = true;
            this.btnSaca.Click += new System.EventHandler(this.btnSaca_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 106;
            this.label3.Text = "Empresas Disponibles";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(329, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 13);
            this.label4.TabIndex = 106;
            this.label4.Text = "Empresas con Acceso";
            // 
            // txtNombreCompleto
            // 
            this.txtNombreCompleto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombreCompleto.Location = new System.Drawing.Point(342, 54);
            this.txtNombreCompleto.Name = "txtNombreCompleto";
            this.txtNombreCompleto.Size = new System.Drawing.Size(240, 20);
            this.txtNombreCompleto.TabIndex = 107;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(250, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Nombre Usuario:";
            // 
            // Usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 496);
            this.Controls.Add(this.txtNombreCompleto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSaca);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnPasa);
            this.Controls.Add(this.dgvListaEmpAcc);
            this.Controls.Add(this.dgvListaEmp);
            this.Controls.Add(this.lblClave);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.chkEstado);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.txtIdUsu);
            this.Name = "Usuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Usuario";
            this.Load += new System.EventHandler(this.Usuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaEmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaEmpAcc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIdUsu;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.DataGridView dgvListaEmp;
        private System.Windows.Forms.DataGridView dgvListaEmpAcc;
        private System.Windows.Forms.Button btnPasa;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSaca;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_Emp;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_Emp;
        private System.Windows.Forms.DataGridViewCheckBoxColumn intDefault;
        private System.Windows.Forms.DataGridViewCheckBoxColumn intCompras;
        private System.Windows.Forms.DataGridViewTextBoxColumn intIdEmp;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.TextBox txtNombreCompleto;
        private System.Windows.Forms.Label label5;
    }
}