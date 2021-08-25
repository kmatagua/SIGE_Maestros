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
using Entidad;

namespace Presentacion
{
    public partial class Asignar_Num_Default : Form
    {
        public int idUsuario;
        public int idEmpresa;

        DataTable tabla = new DataTable();
        BindingSource src = new BindingSource();

        public Asignar_Num_Default()
        {
            InitializeComponent();
        }


        private void Asignar_Num_Default_Load(object sender, EventArgs e)
        {
            Listar_Combo_TipoDoc();
        }

        public void Listar_Combo_TipoDoc()
        {
            Clases.InicialCls.LeerXml();
            DataTable tbl = new DataTable();
            bool pBlnTodoOk = false;
            Negocio.NGComun objNg = new Negocio.NGComun(Configuracion.Sistema.CadenaConexion);

            tbl = objNg.Listar_Combo2("TIPODOC_SERIE", 0, idEmpresa, idUsuario, 0, 0, ref pBlnTodoOk);

            cbxTipoDoc.DisplayMember = "strNoTipDoc";
            cbxTipoDoc.ValueMember = "intIdTipDoc";
            cbxTipoDoc.DataSource = tbl;
        }

        private void cbxTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (cbxTipoDoc.SelectedValue.ToString() != null)
            {
                string p_mensaje = string.Empty;
                bool pBlnTodoOk = false;

                Negocio.NGComun objNegocio = new Negocio.NGComun(Configuracion.Sistema.CadenaConexion);

                objNegocio.EditarSerieDefault(lstENSerieDefault(), ref p_mensaje, ref pBlnTodoOk); // EDITAR ******************

                if (p_mensaje != string.Empty)
                { MessageBox.Show(p_mensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                if (!pBlnTodoOk)
                { MessageBox.Show("Hubo un Error en la Base de Datos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                tabla.Clear();
                int id_TipoDoc = Convert.ToInt32(cbxTipoDoc.SelectedValue.ToString());
                ListarSeries(id_TipoDoc);
            }
        }

        private void ListarSeries(int id_TipoDoc)
        {
            bool pBlnTodoOk = false;
            Clases.InicialCls.LeerXml();
           
            NGComun obj = new NGComun(Configuracion.Sistema.CadenaConexion);
            tabla = obj.ListarSerieDefault(id_TipoDoc, idEmpresa, idUsuario, ref pBlnTodoOk);
            if (!pBlnTodoOk)
            { MessageBox.Show("Hubo un Error al consultar la Base de Datos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            src.DataSource = tabla;
            dgvNum.DataSource = src;
            
        }

        private void dgvNum_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (IsHandleCreated)
            {
                if (dgvNum.CurrentCell == dgvNum.Rows[e.RowIndex].Cells["intDefault"])
                {
                    if (Convert.ToInt32(dgvNum.CurrentCell.Value) == 1)
                    {
                        for (int i = 0; i < dgvNum.RowCount; i++)
                        {
                            if (dgvNum.Rows[i].Cells["intDefault"] != dgvNum.CurrentCell)
                            {
                                dgvNum.Rows[i].Cells["intDefault"].Value = 0;
                            }
                        }
                    }
                }
            }
        }

        private void dgvNum_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dgvNum.IsCurrentCellDirty)
            {
                dgvNum.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea actualizar numerador por defecto?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            try
            {
                using (TransactionScope tscTrans = new TransactionScope())
                {
                    string p_mensaje = string.Empty;
                    bool pBlnTodoOk = false;

                    Negocio.NGComun objNegocio = new Negocio.NGComun(Configuracion.Sistema.CadenaConexion);

                    objNegocio.EditarSerieDefault(lstENSerieDefault(), ref p_mensaje, ref pBlnTodoOk); // EDITAR ******************

                    if (p_mensaje != string.Empty)
                    { MessageBox.Show(p_mensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                    if (!pBlnTodoOk)
                    { MessageBox.Show("Hubo un Error en la Base de Datos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                    tscTrans.Complete();
                    MessageBox.Show("Se guardó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Configuracion.Libreria.Error_Grabar(ex);
            }

        }

        public List<ENSerieDefault> lstENSerieDefault()
        {
            List<ENSerieDefault> lstSerieDefault = new List<ENSerieDefault>();
            foreach (DataRow item in Dgv_DataTable().Rows)
            {
                ENSerieDefault ENSerDef = new ENSerieDefault();
                ENSerDef.intIdUsuNum = Convert.ToInt32(item["intIdUsuNum"]);
                ENSerDef.intDefault = Convert.ToInt32(item["intDefault"]);

                lstSerieDefault.Add(ENSerDef);
            }

            return lstSerieDefault;
        }

        public DataTable Dgv_DataTable()
        {
            //Pasando de datagridview a datatable
            DataTable dt = new DataTable();
            dt.Columns.Add("intIdUsuNum", typeof(System.String));
            dt.Columns.Add("intIdUsu", typeof(System.String));
            dt.Columns.Add("intIdNum", typeof(System.String));
            dt.Columns.Add("intDefault", typeof(System.String));
            dt.Columns.Add("intIdEmp", typeof(System.String));
            dt.Columns.Add("strSerie", typeof(System.String));
            dt.Columns.Add("strNumero", typeof(System.String));
            dt.Columns.Add("intIdTipDoc", typeof(System.String));
           

            foreach (DataGridViewRow rowGrid in dgvNum.Rows)
            {
                DataRow row = dt.NewRow();
                row["intIdUsuNum"] = rowGrid.Cells["intIdUsuNum"].Value.ToString();
                row["intIdUsu"] = rowGrid.Cells["intIdUsu"].Value.ToString();
                row["intIdNum"] = rowGrid.Cells["intIdNum"].Value.ToString();
                row["intDefault"] = rowGrid.Cells["intDefault"].Value.ToString();
                row["intIdEmp"] = rowGrid.Cells["intIdEmp"].Value.ToString();
                row["strSerie"] = rowGrid.Cells["strSerie"].Value.ToString();
                row["strNumero"] = rowGrid.Cells["strNumero"].Value.ToString();
                row["intIdTipDoc"] = rowGrid.Cells["intIdTipDoc"].Value.ToString();
                
                dt.Rows.Add(row);
            }
            return dt;
        }
        
    }
}
