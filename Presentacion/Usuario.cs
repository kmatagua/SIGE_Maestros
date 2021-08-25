using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidad;
using Negocio;
using System.Transactions;

namespace Presentacion
{
    public partial class Usuario : Form
    {
        public int idUsuario;
        public int tipo;
        public int idSeleccion;

        DataTable tabla = new DataTable();
        DataTable tabla_Emp = new DataTable();

        DataTable tblEmp = new DataTable();
        BindingSource src = new BindingSource();

        public Usuario()
        {
            InitializeComponent();
            tabla.Columns.Add("id");
            tabla.Columns.Add("nombre");
            tabla.Columns.Add("default");
            tabla.Columns.Add("compras");

            tabla_Emp.Columns.Add("id_Emp");
            tabla_Emp.Columns.Add("nombre_Emp");          
        }

        private void Usuario_Load(object sender, EventArgs e)
        {
            ListarEmpresa();
            ListarEmpAcc();
            if (tipo == 1)
            { //NUEVO
                chkEstado.Checked = true;
            }
            else if (tipo == 2) //Editar
            {
                DataTable tbl = new DataTable();
                NGUsuario objNg = new NGUsuario(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarUsuario(idSeleccion, ref blnTodoOK);
                txtIdUsu.Text = tbl.Rows[0]["intIdUsu"].ToString();
                txtCodigo.Text = tbl.Rows[0]["strCoUsu"].ToString();
                txtNombreCompleto.Text = tbl.Rows[0]["strNombreCompleto"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoUsu"].ToString();
                txtClave.Text = tbl.Rows[0]["strClave"].ToString();
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);

                //txtCodigo.Enabled = false;
                ListarEmpAcc();

            }
            else if (tipo == 3)
            {
                DataTable tbl = new DataTable();
                NGUsuario objNg = new NGUsuario(Configuracion.Sistema.CadenaConexion);
                bool blnTodoOK = false;
                tbl = objNg.BuscarUsuario(idSeleccion, ref blnTodoOK);

                txtIdUsu.Text = tbl.Rows[0]["intIdUsu"].ToString();
                txtCodigo.Text = tbl.Rows[0]["strCoUsu"].ToString();
                txtNombreCompleto.Text = tbl.Rows[0]["strNombreCompleto"].ToString();
                txtNombre.Text = tbl.Rows[0]["strNoUsu"].ToString();
                txtClave.Text = tbl.Rows[0]["strClave"].ToString();
                chkEstado.Checked = Convert.ToBoolean(tbl.Rows[0]["intEstado"]);
                bloquear();
                btnGuardar.Enabled = false;
                btnPasa.Enabled = false;
                btnSaca.Enabled = false;
                ListarEmpAcc();
            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Clases.InicialCls.LeerXml();

            if (idSeleccion == 0)
            { //NUEVO
                if (txtCodigo.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Código.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
                if (txtNombre.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese Nombre de la Usuario.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }
                if (txtClave.Text.Trim() == string.Empty)
                { MessageBox.Show("Ingrese RUC de la Usuario.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1); txtCodigo.Focus(); return; }

                Insertar();
            }
            else //Editar
            {
                Editar();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPasa_Click(object sender, EventArgs e)
        {
            int intIdEmp = Convert.ToInt32(dgvListaEmp.CurrentRow.Cells["id_Emp"].Value);
            string strNoEmp = dgvListaEmp.CurrentRow.Cells["nombre_Emp"].Value.ToString();

            foreach (DataRow row2 in tabla.Rows)
            {
                if (intIdEmp == Convert.ToInt32(row2[0].ToString()))
                    return;
            }


            tabla.Rows.Add(new object[] { intIdEmp, strNoEmp, 0, 0 });

            //int index = dgvListaEmp.CurrentRow.Index;
            //dgvListaEmp.Rows.RemoveAt(index);

            dgvListaEmpAcc.DataSource = tabla;
        }

        private void btnSaca_Click(object sender, EventArgs e)
        {
            //int intIdEmp = Convert.ToInt32(dgvListaEmpAcc.CurrentRow.Cells["id"].Value);
            //string strNoEmp = dgvListaEmpAcc.CurrentRow.Cells["nombre"].Value.ToString();

            //tabla_Emp.Rows.Add(new object[] { intIdEmp, strNoEmp });
            if (dgvListaEmpAcc.Rows.Count > 0)
            {
                int index = dgvListaEmpAcc.CurrentRow.Index;
                dgvListaEmpAcc.Rows.RemoveAt(index);
            }
        }


        public void Insertar()
        {
            try
            {
                using (TransactionScope tscTrans = new TransactionScope())
                {
                    string mensaje = string.Empty;
                    bool blnTodoOK = false;
                    ENUsuario obj = new ENUsuario();
                    obj.strNombreCompleto = txtNombreCompleto.Text.Trim();
                    obj.strCoUsu = txtCodigo.Text.Trim();
                    obj.strNoUsu = txtNombre.Text.Trim();
                    obj.strClave = txtClave.Text.Trim();
                    obj.intIdUsuCr = idUsuario;

                   
                    obj.intEstado = Convert.ToInt32(chkEstado.Checked);
                
                    NGUsuario objNgUsu = new NGUsuario(Configuracion.Sistema.CadenaConexion);

                    objNgUsu.InsertarUsuario(obj, tabla, ref mensaje, ref blnTodoOK);

                    if (!blnTodoOK)
                    {
                        MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (mensaje != "")
                    {
                        MessageBox.Show(mensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        tscTrans.Complete();
                        MessageBox.Show("Usuario creado con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                                      
                    this.Close();
                
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void Editar()
        {
            using (TransactionScope tscTrans = new TransactionScope())
            { 
                bool blnTodoOK = false;
                ENUsuario obj = new ENUsuario();
                obj.intIdUsu = idSeleccion;
                obj.strNombreCompleto = txtNombreCompleto.Text.Trim();
                obj.strCoUsu = txtCodigo.Text.Trim();
                obj.strNoUsu = txtNombre.Text.Trim();
                obj.strClave = txtClave.Text.Trim();
                obj.intIdUsuMf = idUsuario;
                obj.intEstado = Convert.ToInt32(chkEstado.Checked);
            
                Negocio.NGUsuario objNg = new Negocio.NGUsuario(Configuracion.Sistema.CadenaConexion);

                objNg.EditarUsuario(obj, tabla, ref blnTodoOK);

                if (blnTodoOK)
                {
                    tscTrans.Complete();
                    MessageBox.Show("Usuario Editado con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
        }

        public void ListarEmpresa()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();

            NGEmpresa obj = new NGEmpresa(Configuracion.Sistema.CadenaConexion);
            tblEmp = obj.Empresa(idUsuario, ref blnTodoOK);
            foreach (DataRow row1 in tblEmp.Rows)
            {
                //creas una nueva row
                DataRow row = tabla_Emp.NewRow();
                //asignas el dato a cada columna de la row
                row["id_Emp"] = row1[0].ToString();
                row["nombre_Emp"] = row1[2].ToString();
                tabla_Emp.Rows.Add(row);
            }
            dgvListaEmp.DataSource = tabla_Emp;
        }

        public void ListarEmpAcc()
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();
            DataTable tblEmpAcc = new DataTable();
            if (txtIdUsu.Text.Trim() != string.Empty)
            {
                NGEmpresa obj = new NGEmpresa(Configuracion.Sistema.CadenaConexion);
                tblEmpAcc = obj.EmpresaAcceso(Convert.ToInt32(txtIdUsu.Text), ref blnTodoOK);

                foreach (DataRow row1 in tblEmpAcc.Rows)
                {
                    //creas una nueva row
                    DataRow row = tabla.NewRow();
                    //asignas el dato a cada columna de la row
                    row["id"] = row1[0].ToString();
                    row["nombre"] = row1[1].ToString();
                    row["default"] = row1[2].ToString();
                    row["compras"] = row1[3].ToString();
                    tabla.Rows.Add(row);
                }

                dgvListaEmpAcc.DataSource = tabla;
            }
        }

        public void bloquear()
        {
            foreach(Control c in this.Controls)
            {
                if(c is TextBox)
                {
                    c.Enabled = false;

                }
                if (c is DataGridView)
                {
                    c.Enabled = false;

                }
            }
        }
        
        private void dgvListaEmpAcc_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (IsHandleCreated)
            {
                if (dgvListaEmpAcc.CurrentCell == dgvListaEmpAcc.Rows[e.RowIndex].Cells["intDefault"])
                {
                    if (Convert.ToInt32(dgvListaEmpAcc.CurrentCell.Value) == 1)
                    {
                        for (int i = 0; i < dgvListaEmpAcc.RowCount; i++)
                        {
                            if (dgvListaEmpAcc.Rows[i].Cells["intDefault"] != dgvListaEmpAcc.CurrentCell)
                            {
                                dgvListaEmpAcc.Rows[i].Cells["intDefault"].Value = 0;
                            }
                        }
                    }
                   
                }
                if (dgvListaEmpAcc.CurrentCell == dgvListaEmpAcc.Rows[e.RowIndex].Cells["intCompras"])
                {
                    if (Convert.ToInt32(dgvListaEmpAcc.CurrentCell.Value) == 1)
                    {
                        for (int i = 0; i < dgvListaEmpAcc.RowCount; i++)
                        {
                            if (dgvListaEmpAcc.Rows[i].Cells["intCompras"] != dgvListaEmpAcc.CurrentCell)
                            {
                                dgvListaEmpAcc.Rows[i].Cells["intCompras"].Value = 0;
                            }
                        }
                    }

                }

            }
        }

        private void dgvListaEmpAcc_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dgvListaEmpAcc.IsCurrentCellDirty)
            {
                dgvListaEmpAcc.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

    }
}
