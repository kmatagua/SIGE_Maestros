namespace Presentacion
{
    partial class BaseDatos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseDatos));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsmiProbar = new System.Windows.Forms.ToolStripButton();
            this.tsmiGrabar = new System.Windows.Forms.ToolStripButton();
            this.tsmiCerrar = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBaseDatos = new System.Windows.Forms.TextBox();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtContrasenia = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.rbtnSQL = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.rbtnWindows = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiProbar,
            this.tsmiGrabar,
            this.tsmiCerrar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(406, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsmiProbar
            // 
            this.tsmiProbar.Image = ((System.Drawing.Image)(resources.GetObject("tsmiProbar.Image")));
            this.tsmiProbar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiProbar.Name = "tsmiProbar";
            this.tsmiProbar.Size = new System.Drawing.Size(62, 22);
            this.tsmiProbar.Text = "Probar";
            this.tsmiProbar.Click += new System.EventHandler(this.tsmiProbar_Click);
            // 
            // tsmiGrabar
            // 
            this.tsmiGrabar.Image = ((System.Drawing.Image)(resources.GetObject("tsmiGrabar.Image")));
            this.tsmiGrabar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiGrabar.Name = "tsmiGrabar";
            this.tsmiGrabar.Size = new System.Drawing.Size(62, 22);
            this.tsmiGrabar.Text = "Grabar";
            this.tsmiGrabar.Click += new System.EventHandler(this.tsmiGrabar_Click);
            // 
            // tsmiCerrar
            // 
            this.tsmiCerrar.Image = ((System.Drawing.Image)(resources.GetObject("tsmiCerrar.Image")));
            this.tsmiCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiCerrar.Name = "tsmiCerrar";
            this.tsmiCerrar.Size = new System.Drawing.Size(59, 22);
            this.tsmiCerrar.Text = "Cerrar";
            this.tsmiCerrar.Click += new System.EventHandler(this.tsmiCerrar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBaseDatos);
            this.groupBox1.Controls.Add(this.txtServidor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 97);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de Conexión";
            // 
            // txtBaseDatos
            // 
            this.txtBaseDatos.Location = new System.Drawing.Point(118, 57);
            this.txtBaseDatos.Name = "txtBaseDatos";
            this.txtBaseDatos.Size = new System.Drawing.Size(241, 20);
            this.txtBaseDatos.TabIndex = 4;
            // 
            // txtServidor
            // 
            this.txtServidor.Location = new System.Drawing.Point(118, 29);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(241, 20);
            this.txtServidor.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Base de Datos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Servidor";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtContrasenia);
            this.groupBox2.Controls.Add(this.txtUsuario);
            this.groupBox2.Controls.Add(this.rbtnSQL);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.rbtnWindows);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(382, 166);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // txtContrasenia
            // 
            this.txtContrasenia.Location = new System.Drawing.Point(176, 125);
            this.txtContrasenia.Name = "txtContrasenia";
            this.txtContrasenia.PasswordChar = '*';
            this.txtContrasenia.Size = new System.Drawing.Size(183, 20);
            this.txtContrasenia.TabIndex = 15;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(176, 97);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(183, 20);
            this.txtUsuario.TabIndex = 13;
            // 
            // rbtnSQL
            // 
            this.rbtnSQL.AutoSize = true;
            this.rbtnSQL.Location = new System.Drawing.Point(52, 63);
            this.rbtnSQL.Name = "rbtnSQL";
            this.rbtnSQL.Size = new System.Drawing.Size(129, 17);
            this.rbtnSQL.TabIndex = 10;
            this.rbtnSQL.TabStop = true;
            this.rbtnSQL.Text = "Autenticación de SQL";
            this.rbtnSQL.UseVisualStyleBackColor = true;
            this.rbtnSQL.CheckedChanged += new System.EventHandler(this.rbtnSQL_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Contraseña";
            // 
            // rbtnWindows
            // 
            this.rbtnWindows.AutoSize = true;
            this.rbtnWindows.Location = new System.Drawing.Point(52, 31);
            this.rbtnWindows.Name = "rbtnWindows";
            this.rbtnWindows.Size = new System.Drawing.Size(152, 17);
            this.rbtnWindows.TabIndex = 8;
            this.rbtnWindows.TabStop = true;
            this.rbtnWindows.Text = "Autenticación de Windows";
            this.rbtnWindows.UseVisualStyleBackColor = true;
            this.rbtnWindows.CheckedChanged += new System.EventHandler(this.rbtnWindows_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(111, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Usuario";
            // 
            // BaseDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 309);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "BaseDatos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BaseDatos";
            this.Load += new System.EventHandler(this.BaseDatos_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsmiProbar;
        private System.Windows.Forms.ToolStripButton tsmiGrabar;
        private System.Windows.Forms.ToolStripButton tsmiCerrar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBaseDatos;
        private System.Windows.Forms.TextBox txtServidor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtContrasenia;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.RadioButton rbtnSQL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbtnWindows;
        private System.Windows.Forms.Label label3;
    }
}