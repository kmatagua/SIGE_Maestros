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

namespace Presentacion
{
    public partial class Config_Almacen : Form
    {
        public int intIdAlm;
        public int idUsuario;
        public int tipo;
        public int idEmpresa;
        public string nombreEmpresa;

        public Config_Almacen()
        {
            InitializeComponent();
        }

        private void Config_Almacen_Load(object sender, EventArgs e)
        {
            lblEmpresa.Text = nombreEmpresa;
            Listar_Almacen(); 
            Listar_Tab();
            if (tipo == 1)
            { //NUEVO

            }
            else if (tipo == 2) //Editar
            {
                try
                {
                    cbxAlmacen.Enabled = false;
                    cbxAlmacen.SelectedValue = intIdAlm;
                    BuscarConfig();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
            }
            else if (tipo == 3) //VER
            {
                cbxAlmacen.Enabled = false;
                cbxAlmacen.SelectedValue = intIdAlm;
                BuscarConfig();
                chkValidaCero.Enabled = false;
                chkValidaStock.Enabled = false;
                cbxTab.Enabled = false;
            }
            
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Clases.InicialCls.LeerXml();

            Guardar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //public void Insertar()
        //{
        //    try
        //    {
        //        string mensaje = string.Empty;
        //        bool blnTodoOK = false;
        //        ENConfig_Alm obj = new ENConfig_Alm();
        //        obj.intIdAlm = Convert.ToInt32(cbxAlmacen.SelectedValue);
        //        obj.strDescripcion = cbxAlmacen.Text;
        //        obj.intIdEmp = idEmpresa;
        //        obj.intTab = Convert.ToInt32(cbxTab.SelectedValue);
        //        obj.intValidaStock = Convert.ToInt32(chkValidaStock.Checked);
        //        obj.intValidaCero = Convert.ToInt32(chkValidaCero.Checked);
                

        //        Negocio.NGAlmacen objNg = new Negocio.NGAlmacen(Configuracion.Sistema.CadenaConexion);

        //        objNg.InsertarConfigAlmacen(obj, ref blnTodoOK);

                
        //        if (!blnTodoOK)
        //        {
        //            MessageBox.Show("Error.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }
        //        if (mensaje != "")
        //        {
        //            MessageBox.Show(mensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Configuración guardada con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
                
        //        //this.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        public void Guardar()
        {
            try
            {
                string mensaje = string.Empty;
                bool blnTodoOK = false;
                ENConfig_Alm obj = new ENConfig_Alm();
                obj.intIdAlm = Convert.ToInt32(cbxAlmacen.SelectedValue);
                obj.strDescripcion = cbxAlmacen.Text;
                obj.intIdEmp = idEmpresa;
                obj.intTab = Convert.ToInt32(cbxTab.SelectedValue);
                obj.intValidaStock = Convert.ToInt32(chkValidaStock.Checked);
                obj.intValidaCero = Convert.ToInt32(chkValidaCero.Checked);
                obj.intVenta = Convert.ToInt32(chkVentas.Checked);
                obj.intAprobIng = Convert.ToInt32(chkAprobIng.Checked);
                obj.intAprobSal = Convert.ToInt32(chkAprobSal.Checked);
                obj.intAuditIng = Convert.ToInt32(chkAuditIng.Checked);
                obj.intAuditSal = Convert.ToInt32(chkAuditSal.Checked);

                Negocio.NGAlmacen objNg = new Negocio.NGAlmacen(Configuracion.Sistema.CadenaConexion);

                objNg.EditarConfigAlmacen(obj, ref blnTodoOK);

                
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
                    MessageBox.Show("Configuración guardada con éxito.!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //public void ListarComboSede(int idEmpresa)
        //{
        //    bool blnTodoOK = false;
        //    Clases.InicialCls.LeerXml();
        //    DataTable tbl = new DataTable();
        //    NGSede obj = new NGSede(Configuracion.Sistema.CadenaConexion);
        //    tbl = obj.Sede(idEmpresa, ref blnTodoOK);

        //    cbxSede.DataSource = tbl;
        //    cbxSede.DisplayMember = "strNoSede";
        //    cbxSede.ValueMember = "intIdSede";

        //}

        //public void Listar_Almacen_Filtro()
        //{
        //    Clases.InicialCls.LeerXml();
        //    DataTable tbl = new DataTable();
        //    bool pBlnTodoOk = false;
        //    Negocio.NGComun objNg = new Negocio.NGComun(Configuracion.Sistema.CadenaConexion);

        //    tbl = objNg.Listar_Combo2("ALMACEN_SEDE", 0, 0, idUsuario, 0, Convert.ToInt32(cbxSede.SelectedValue), ref pBlnTodoOk);

        //    cbxAlmacen.DisplayMember = "strNoAlm";
        //    cbxAlmacen.ValueMember = "intIdAlm";
        //    cbxAlmacen.DataSource = tbl;
        //    foreach (DataRow row in tbl.Rows)
        //    {
        //        if (row["intDefault"].ToString() == "1")
        //        {
        //            cbxAlmacen.SelectedValue = Convert.ToInt32(row["intIdAlm"].ToString());
        //            //cbxSede.SelectedValue = Convert.ToInt32(row["intIdSede"].ToString());
        //        }
        //    }

        //}

        public DataTable Listar_Almacen()
        {
            Clases.InicialCls.LeerXml();
            DataTable tbl = new DataTable();
            bool pBlnTodoOk = false;
            Negocio.NGComun objNg = new Negocio.NGComun(Configuracion.Sistema.CadenaConexion);

            tbl = objNg.Listar_Combo2("ALMACEN", 0, idEmpresa, idUsuario, 0, 0, ref pBlnTodoOk);

            cbxAlmacen.DisplayMember = "strNoAlm";
            cbxAlmacen.ValueMember = "intIdAlm";
            cbxAlmacen.DataSource = tbl;

            //foreach (DataRow row in tbl.Rows)
            //{
            //    if (row["intDefault"].ToString() == "1")
            //    {
            //        cbxAlmacen.SelectedValue = Convert.ToInt32(row["intIdAlm"].ToString());
            //        //cbxSede.SelectedValue = Convert.ToInt32(row["intIdSede"].ToString());
            //    }
            //}
            return tbl;
        }

        public void Listar_Sede()
        {
            //Clases.InicialCls.LeerXml();
            //DataTable tbl = new DataTable();
            //bool pBlnTodoOk = false;
            //Negocio.NGComun objNg = new Negocio.NGComun(Configuracion.Sistema.CadenaConexion);

            //tbl = objNg.Listar_Combo2("SEDE", 0, idEmpresa, idUsuario, 0, 0, ref pBlnTodoOk);

            //cbxSede.DisplayMember = "strNoSede";
            //cbxSede.ValueMember = "intIdSede";
            //cbxSede.DataSource = tbl;

            ////return tbl;
        }

        public void Listar_Tab()
        {
            Clases.InicialCls.LeerXml();
            DataTable tbl = new DataTable();
            bool pBlnTodoOk = false;
            Negocio.NGComun objNg = new Negocio.NGComun(Configuracion.Sistema.CadenaConexion);

            tbl = objNg.Listar_Combo("CONFIG_ALMACEN_TAB", 0, ref pBlnTodoOk);

            cbxTab.DisplayMember = "strTab";
            cbxTab.ValueMember = "intId";
            cbxTab.DataSource = tbl;

            
        }

        public void BuscarConfig()
        {
            DataTable tbl = new DataTable();
            NGAlmacen objNg = new NGAlmacen(Configuracion.Sistema.CadenaConexion);
            bool blnTodoOK = false;
            int intIdAlm = Convert.ToInt32(cbxAlmacen.SelectedValue);
            tbl = objNg.BuscarConfigAlmacen(intIdAlm, ref blnTodoOK);

            chkValidaStock.Checked = tbl.Rows[0]["intValidaStock"] is DBNull ? false : Convert.ToBoolean(tbl.Rows[0]["intValidaStock"]);
            chkValidaCero.Checked = tbl.Rows[0]["intValidaCero"] is DBNull ? false : Convert.ToBoolean(tbl.Rows[0]["intValidaCero"]);
            cbxTab.SelectedValue = Convert.ToInt32(tbl.Rows[0]["intTab"]);
            chkVentas.Checked = tbl.Rows[0]["intVenta"] is DBNull ? false : Convert.ToBoolean(tbl.Rows[0]["intVenta"]);
            chkAprobIng.Checked = tbl.Rows[0]["intAprobIng"] is DBNull ? false : Convert.ToBoolean(tbl.Rows[0]["intAprobIng"]);
            chkAprobSal.Checked = tbl.Rows[0]["intAprobSal"] is DBNull ? false : Convert.ToBoolean(tbl.Rows[0]["intAprobSal"]);
            chkAuditIng.Checked = tbl.Rows[0]["intAuditIng"] is DBNull ? false : Convert.ToBoolean(tbl.Rows[0]["intAuditIng"]);
            chkAuditSal.Checked = tbl.Rows[0]["intAuditSal"] is DBNull ? false : Convert.ToBoolean(tbl.Rows[0]["intAuditSal"]);
        }

        private void cbxAlmacen_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable tbl = new DataTable();
            NGAlmacen objNg = new NGAlmacen(Configuracion.Sistema.CadenaConexion);
            bool blnTodoOK = false;
            int intIdAlm = Convert.ToInt32(cbxAlmacen.SelectedValue);
            tbl = objNg.BuscarConfigAlmacen(intIdAlm, ref blnTodoOK);

            if (tbl.Rows.Count > 0)
            {
                chkValidaStock.Checked = Convert.ToBoolean(tbl.Rows[0]["intValidaStock"]);
                chkValidaCero.Checked = Convert.ToBoolean(tbl.Rows[0]["intValidaCero"]);
                chkVentas.Checked = Convert.ToBoolean(tbl.Rows[0]["intVenta"]);
                chkAprobIng.Checked = Convert.ToBoolean(tbl.Rows[0]["intAprobIng"]);
                chkAprobSal.Checked = Convert.ToBoolean(tbl.Rows[0]["intAprobSal"]);
                chkAuditIng.Checked = Convert.ToBoolean(tbl.Rows[0]["intAuditIng"]);
                chkAuditSal.Checked = Convert.ToBoolean(tbl.Rows[0]["intAuditSal"]);
                cbxTab.SelectedValue = Convert.ToInt32(tbl.Rows[0]["intTab"]);
            }
            else
            {
                chkValidaStock.Checked = false;
                chkValidaCero.Checked = false;
                chkVentas.Checked = false;
                chkAprobIng.Checked = false;
                chkAprobSal.Checked = false;
                chkAuditIng.Checked = false;
                chkAuditSal.Checked = false;
                cbxTab.SelectedValue = 0;
            }
        }

    }
}
