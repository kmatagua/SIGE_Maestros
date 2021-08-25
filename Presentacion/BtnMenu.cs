using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using System.Transactions;

namespace Presentacion
{
    public partial class BtnMenu : Form
    {
        public int idUsuario;
        public int idEmpresa;
        public int idUsuBtn;
        public string nombreMenu;
        public string nombreUsuario;

        DataTable tabla_Btn = new DataTable();


        public BtnMenu()
        {
            InitializeComponent();
            tabla_Btn.Columns.Add("id");
            tabla_Btn.Columns.Add("intIdUsuBtnMenu");
            tabla_Btn.Columns.Add("intIdUsuMenu");
            tabla_Btn.Columns.Add("valor");
            tabla_Btn.Columns.Add("boton");
        }

        private void BtnMenu_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = nombreUsuario.ToString();
            lblMenu.Text = nombreMenu.ToString();
            ListarBtn();
            Clases.Reglas.alternarColor(dgvListaBtn);

        }

        public void ListarBtn()
        {

            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tblBtn = new DataTable();


            NGMenu obj = new NGMenu(Configuracion.Sistema.CadenaConexion);
            tblBtn = obj.BtnAccesoMenu(idUsuBtn, ref blnTodoOK);
            //tabla_Btn.Clear();
            foreach (DataRow row1 in tblBtn.Rows)
            {

                //creas una nueva row
                DataRow rowBtn = tabla_Btn.NewRow();
                //asignas el dato a cada columna de la row
                rowBtn["id"] = row1[0].ToString();
                rowBtn["intIdUsuBtnMenu"] = row1[1].ToString();
                rowBtn["intIdUsuMenu"] = idUsuBtn;
                rowBtn["valor"] = row1[3].ToString();
                rowBtn["boton"] = row1[4].ToString();

                tabla_Btn.Rows.Add(rowBtn);
            }

            dgvListaBtn.DataSource = tabla_Btn;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Insertar();
            this.Close();
        }

        public void Insertar()
        {
            try
            {
                using (TransactionScope tscTrans = new TransactionScope())
                {
                    bool blnTodoOK = false;
                    Clases.InicialCls.LeerXml();

                    NGMenu objNgUsu = new NGMenu(Configuracion.Sistema.CadenaConexion);
                    
                    objNgUsu.InsertarBtnMenu(idUsuario, tabla_Btn, ref blnTodoOK);

                    if (blnTodoOK)
                    {
                        tscTrans.Complete();
                        MessageBox.Show("Botones agregados con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
