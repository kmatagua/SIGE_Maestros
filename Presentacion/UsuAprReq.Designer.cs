namespace Presentacion
{
    partial class UsuAprReq
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsuAprReq));
            this.cbxUsuario = new System.Windows.Forms.ComboBox();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.dgvListaNumeradorAcc = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idNumerador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intNumeroApr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intTipoReq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtIdAlm = new System.Windows.Forms.TextBox();
            this.dgvListaNumerador = new System.Windows.Forms.DataGridView();
            this.id_Numerador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serie_Numerador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero_Numerador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observacion_Numerador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.almacen_Numerador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operacion_Numerador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPasa = new System.Windows.Forms.Button();
            this.cbxNumeroApr = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSaca = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.cbxTipoReq = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaNumeradorAcc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaNumerador)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxUsuario
            // 
            this.cbxUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUsuario.FormattingEnabled = true;
            this.cbxUsuario.Location = new System.Drawing.Point(476, 13);
            this.cbxUsuario.Name = "cbxUsuario";
            this.cbxUsuario.Size = new System.Drawing.Size(294, 21);
            this.cbxUsuario.TabIndex = 0;
            this.cbxUsuario.SelectedIndexChanged += new System.EventHandler(this.cbxUsuario_SelectedIndexChanged);
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpresa.Location = new System.Drawing.Point(15, 29);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(47, 15);
            this.lblEmpresa.TabIndex = 1;
            this.lblEmpresa.Text = "label1";
            // 
            // dgvListaNumeradorAcc
            // 
            this.dgvListaNumeradorAcc.AllowUserToAddRows = false;
            this.dgvListaNumeradorAcc.AllowUserToDeleteRows = false;
            this.dgvListaNumeradorAcc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaNumeradorAcc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaNumeradorAcc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.idNumerador,
            this.serie,
            this.numero,
            this.observacion,
            this.operacion,
            this.intNumeroApr,
            this.intTipoReq});
            this.dgvListaNumeradorAcc.Location = new System.Drawing.Point(17, 312);
            this.dgvListaNumeradorAcc.Name = "dgvListaNumeradorAcc";
            this.dgvListaNumeradorAcc.ReadOnly = true;
            this.dgvListaNumeradorAcc.Size = new System.Drawing.Size(747, 154);
            this.dgvListaNumeradorAcc.TabIndex = 2;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 30;
            // 
            // idNumerador
            // 
            this.idNumerador.DataPropertyName = "idNumerador";
            this.idNumerador.HeaderText = "Id_N";
            this.idNumerador.Name = "idNumerador";
            this.idNumerador.ReadOnly = true;
            this.idNumerador.Visible = false;
            this.idNumerador.Width = 30;
            // 
            // serie
            // 
            this.serie.DataPropertyName = "serie";
            this.serie.HeaderText = "Serie";
            this.serie.Name = "serie";
            this.serie.ReadOnly = true;
            this.serie.Width = 50;
            // 
            // numero
            // 
            this.numero.DataPropertyName = "numero";
            this.numero.HeaderText = "Numero";
            this.numero.Name = "numero";
            this.numero.ReadOnly = true;
            this.numero.Width = 80;
            // 
            // observacion
            // 
            this.observacion.DataPropertyName = "observacion";
            this.observacion.HeaderText = "Descripcion";
            this.observacion.Name = "observacion";
            this.observacion.ReadOnly = true;
            this.observacion.Width = 250;
            // 
            // operacion
            // 
            this.operacion.DataPropertyName = "operacion";
            this.operacion.HeaderText = "Tipo Requerimiento";
            this.operacion.Name = "operacion";
            this.operacion.ReadOnly = true;
            this.operacion.Width = 130;
            // 
            // intNumeroApr
            // 
            this.intNumeroApr.DataPropertyName = "intNumeroApr";
            this.intNumeroApr.HeaderText = "Aprobacion";
            this.intNumeroApr.Name = "intNumeroApr";
            this.intNumeroApr.ReadOnly = true;
            // 
            // intTipoReq
            // 
            this.intTipoReq.DataPropertyName = "intTipoReq";
            this.intTipoReq.HeaderText = "intTipoReq";
            this.intTipoReq.Name = "intTipoReq";
            this.intTipoReq.ReadOnly = true;
            this.intTipoReq.Visible = false;
            // 
            // txtIdAlm
            // 
            this.txtIdAlm.Location = new System.Drawing.Point(713, 13);
            this.txtIdAlm.Name = "txtIdAlm";
            this.txtIdAlm.Size = new System.Drawing.Size(57, 20);
            this.txtIdAlm.TabIndex = 3;
            // 
            // dgvListaNumerador
            // 
            this.dgvListaNumerador.AllowUserToAddRows = false;
            this.dgvListaNumerador.AllowUserToDeleteRows = false;
            this.dgvListaNumerador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaNumerador.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_Numerador,
            this.serie_Numerador,
            this.numero_Numerador,
            this.observacion_Numerador,
            this.almacen_Numerador,
            this.operacion_Numerador});
            this.dgvListaNumerador.Location = new System.Drawing.Point(17, 67);
            this.dgvListaNumerador.Name = "dgvListaNumerador";
            this.dgvListaNumerador.ReadOnly = true;
            this.dgvListaNumerador.Size = new System.Drawing.Size(747, 170);
            this.dgvListaNumerador.TabIndex = 4;
            // 
            // id_Numerador
            // 
            this.id_Numerador.DataPropertyName = "id_Numerador";
            this.id_Numerador.HeaderText = "Id";
            this.id_Numerador.Name = "id_Numerador";
            this.id_Numerador.ReadOnly = true;
            this.id_Numerador.Width = 30;
            // 
            // serie_Numerador
            // 
            this.serie_Numerador.DataPropertyName = "serie_Numerador";
            this.serie_Numerador.HeaderText = "Serie";
            this.serie_Numerador.Name = "serie_Numerador";
            this.serie_Numerador.ReadOnly = true;
            this.serie_Numerador.Width = 50;
            // 
            // numero_Numerador
            // 
            this.numero_Numerador.DataPropertyName = "numero_Numerador";
            this.numero_Numerador.HeaderText = "Numero";
            this.numero_Numerador.Name = "numero_Numerador";
            this.numero_Numerador.ReadOnly = true;
            this.numero_Numerador.Width = 70;
            // 
            // observacion_Numerador
            // 
            this.observacion_Numerador.DataPropertyName = "observacion_Numerador";
            this.observacion_Numerador.HeaderText = "Numerador";
            this.observacion_Numerador.Name = "observacion_Numerador";
            this.observacion_Numerador.ReadOnly = true;
            this.observacion_Numerador.Width = 230;
            // 
            // almacen_Numerador
            // 
            this.almacen_Numerador.DataPropertyName = "almacen_Numerador";
            this.almacen_Numerador.HeaderText = "Almacen";
            this.almacen_Numerador.Name = "almacen_Numerador";
            this.almacen_Numerador.ReadOnly = true;
            this.almacen_Numerador.Width = 200;
            // 
            // operacion_Numerador
            // 
            this.operacion_Numerador.DataPropertyName = "operacion_Numerador";
            this.operacion_Numerador.HeaderText = "Operacion";
            this.operacion_Numerador.Name = "operacion_Numerador";
            this.operacion_Numerador.ReadOnly = true;
            this.operacion_Numerador.Width = 110;
            // 
            // btnPasa
            // 
            this.btnPasa.Image = ((System.Drawing.Image)(resources.GetObject("btnPasa.Image")));
            this.btnPasa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPasa.Location = new System.Drawing.Point(597, 191);
            this.btnPasa.Name = "btnPasa";
            this.btnPasa.Size = new System.Drawing.Size(75, 37);
            this.btnPasa.TabIndex = 5;
            this.btnPasa.Text = "Agregar";
            this.btnPasa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPasa.UseVisualStyleBackColor = true;
            this.btnPasa.Click += new System.EventHandler(this.btnPasa_Click);
            // 
            // cbxNumeroApr
            // 
            this.cbxNumeroApr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNumeroApr.FormattingEnabled = true;
            this.cbxNumeroApr.Location = new System.Drawing.Point(7, 207);
            this.cbxNumeroApr.Name = "cbxNumeroApr";
            this.cbxNumeroApr.Size = new System.Drawing.Size(180, 21);
            this.cbxNumeroApr.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Empresa:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(424, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Usuario:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Número de Aprobación:";
            // 
            // btnSaca
            // 
            this.btnSaca.Image = ((System.Drawing.Image)(resources.GetObject("btnSaca.Image")));
            this.btnSaca.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaca.Location = new System.Drawing.Point(678, 191);
            this.btnSaca.Name = "btnSaca";
            this.btnSaca.Size = new System.Drawing.Size(75, 37);
            this.btnSaca.TabIndex = 5;
            this.btnSaca.Text = "Quitar";
            this.btnSaca.UseVisualStyleBackColor = true;
            this.btnSaca.Click += new System.EventHandler(this.btnSaca_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(695, 478);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 25);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(614, 478);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 25);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // cbxTipoReq
            // 
            this.cbxTipoReq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipoReq.FormattingEnabled = true;
            this.cbxTipoReq.Location = new System.Drawing.Point(196, 206);
            this.cbxTipoReq.Name = "cbxTipoReq";
            this.cbxTipoReq.Size = new System.Drawing.Size(214, 21);
            this.cbxTipoReq.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(204, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tipo de Requerimiento:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbxNumeroApr);
            this.groupBox1.Controls.Add(this.cbxTipoReq);
            this.groupBox1.Controls.Add(this.btnPasa);
            this.groupBox1.Controls.Add(this.btnSaca);
            this.groupBox1.Location = new System.Drawing.Point(11, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(759, 234);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Numeradores";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Location = new System.Drawing.Point(11, 293);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(759, 179);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Permisos Asignados";
            // 
            // UsuAprReq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 515);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvListaNumerador);
            this.Controls.Add(this.dgvListaNumeradorAcc);
            this.Controls.Add(this.lblEmpresa);
            this.Controls.Add(this.cbxUsuario);
            this.Controls.Add(this.txtIdAlm);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "UsuAprReq";
            this.Text = "Asignar permisos de aprobación por Requerimientos";
            this.Load += new System.EventHandler(this.UsuAprReq_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaNumeradorAcc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaNumerador)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxUsuario;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.DataGridView dgvListaNumeradorAcc;
        private System.Windows.Forms.TextBox txtIdAlm;
        private System.Windows.Forms.DataGridView dgvListaNumerador;
        private System.Windows.Forms.Button btnPasa;
        private System.Windows.Forms.ComboBox cbxNumeroApr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSaca;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ComboBox cbxTipoReq;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_Numerador;
        private System.Windows.Forms.DataGridViewTextBoxColumn serie_Numerador;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero_Numerador;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacion_Numerador;
        private System.Windows.Forms.DataGridViewTextBoxColumn almacen_Numerador;
        private System.Windows.Forms.DataGridViewTextBoxColumn operacion_Numerador;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn idNumerador;
        private System.Windows.Forms.DataGridViewTextBoxColumn serie;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn operacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn intNumeroApr;
        private System.Windows.Forms.DataGridViewTextBoxColumn intTipoReq;
    }
}