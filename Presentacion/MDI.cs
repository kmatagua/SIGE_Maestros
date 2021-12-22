using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;

namespace Presentacion
{
    public partial class MDI : Form
    {
        DataTable tb = new DataTable();
        public bool creado = false;

        public int idUsuario;
        public string usuarioConect;
        public int intIdEmpresa;
        public string strNoEmpresa;
        public string periodo;
        public string tagMenu;

        public MDI()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }

        }

        private void MDI_Load(object sender, EventArgs e)
        {
            Clases.InicialCls.LeerXml();
            tssBaseDatos.Text = "Base De Datos: " + Configuracion.Sistema.BaseDatosSQL;
            this.Width = 0;

            Login login = new Login();
            login.cambiarUsuario = 0;

            if (login.ShowDialog() == DialogResult.OK)
            {
                int xbuscar = login.intIdUsux;
                string xbuscarn = login.strNoUsux;
                idUsuario = xbuscar;
                usuarioConect = xbuscarn;

                for (int i = 0; i < this.MdiChildren.Length; i++)
                {
                    this.MdiChildren[i].Close();
                    i = i - 1;
                }

                this.WindowState = FormWindowState.Maximized;

                cargaEmpresa();

            }
            else
            {
                this.Width = 0;
            }
        }

        public void CambiarOpcionesMenu(ToolStripItemCollection colOpcionesMenu)
        {
            // recorrer el submenú
            foreach (ToolStripItem itmOpcion in colOpcionesMenu)
            {
                if (itmOpcion.Tag != null)
                {
                    string ss = itmOpcion.Tag.ToString();
                    DataRow foundRow1 = tb.Rows.Find(ss);
                    //MessageBox.Show(ss);
                    if (foundRow1 != null)
                    {
                        itmOpcion.Visible = true;
                    }
                    else
                    {
                        itmOpcion.Visible = false;
                    }
                }

                if (((ToolStripMenuItem)itmOpcion).DropDownItems.Count > 0)
                {
                    this.CambiarOpcionesMenu(((ToolStripMenuItem)itmOpcion).DropDownItems);
                }
            }
        }

        private void cargaEmpresa()
        {
            DataTable tabla = new DataTable();
            tabla = empresaActiva(idUsuario);

            try
            {
                intIdEmpresa = Convert.ToInt32(tabla.Rows[0]["intIdEmp"].ToString());
                ssUser.Text = usuarioConect;
                strNoEmpresa = tabla.Rows[0]["strNoEmp"].ToString();
                ActualizarSBar();//ssEmpresa
            }
            catch
            {
                return;
            }

        }

        private void MDI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public DataTable empresaActiva(int idUsu)
        {
            bool blnTodoOK = false;
            DataTable tbl = new DataTable();
            NGEmpresa obj = new NGEmpresa(Configuracion.Sistema.CadenaConexion);
            tbl = obj.EmpresaActiva(idUsu, ref blnTodoOK);
            return tbl;
        }

        private void almacenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void empresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable tblBotones = new DataTable();
            tblBotones = botones(idUsuario, empresaToolStripMenuItem.Tag.ToString(), intIdEmpresa);

            if (Application.OpenForms.OfType<Empresa_Listado>().Count() == 1)
                Application.OpenForms.OfType<Empresa_Listado>().First().Close();

            Empresa_Listado frm = new Empresa_Listado();
            frm.MdiParent = this;
            frm.idUsuario = idUsuario;
            frm.idEmpresa = intIdEmpresa;
            frm.tsNuevo.Visible = (tblBotones.Rows[0]["intNuevo"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intNuevo"]);
            frm.tsEditar.Visible = (tblBotones.Rows[0]["intEditar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEditar"]);
            frm.tsVer.Visible = (tblBotones.Rows[0]["intVer"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intVer"]);
            frm.tsBuscar.Visible = (tblBotones.Rows[0]["intBuscar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intBuscar"]);
            frm.tsActualizar.Visible = (tblBotones.Rows[0]["intActualizar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intActualizar"]);
            frm.tsEliminar.Visible = (tblBotones.Rows[0]["intEliminar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEliminar"]);
            frm.tsImprimir.Visible = (tblBotones.Rows[0]["intImp"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intImp"]);
            frm.tsExportar.Visible = (tblBotones.Rows[0]["intExportar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intExportar"]);
            frm.Show();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void creacionToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            DataTable tblBotones = new DataTable();
            tblBotones = botones(idUsuario, creacionToolStripMenuItem3.Tag.ToString(), intIdEmpresa);

            if (Application.OpenForms.OfType<Usuario_Listado>().Count() == 1)
                Application.OpenForms.OfType<Usuario_Listado>().First().Close();

            Usuario_Listado frm = new Usuario_Listado();
            frm.MdiParent = this;
            frm.idUsuario = idUsuario;
            frm.tsNuevo.Visible = (tblBotones.Rows[0]["intNuevo"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intNuevo"]);
            frm.tsEditar.Visible = (tblBotones.Rows[0]["intEditar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEditar"]);
            frm.tsVer.Visible = (tblBotones.Rows[0]["intVer"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intVer"]);
            frm.tsBuscar.Visible = (tblBotones.Rows[0]["intBuscar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intBuscar"]);
            frm.tsActualizar.Visible = (tblBotones.Rows[0]["intActualizar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intActualizar"]);
            frm.tsEliminar.Visible = (tblBotones.Rows[0]["intEliminar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEliminar"]);
            frm.tsImprimir.Visible = (tblBotones.Rows[0]["intImp"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intImp"]);
            frm.tsExportar.Visible = (tblBotones.Rows[0]["intExportar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intExportar"]);

            frm.Show();
        }

        private void asignarAlmacenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<AlmacenUsuario>().Count() == 1)
                Application.OpenForms.OfType<AlmacenUsuario>().First().Close();

            AlmacenUsuario frm = new AlmacenUsuario();
            frm.MdiParent = this;
            frm.idEmpresa = intIdEmpresa;
            frm.nombreEmpresa = strNoEmpresa;
            frm.Show();
        }

        private void unidadDeMedidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Unidad_Listado frm = new Unidad_Listado();
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void sedeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable tblBotones = new DataTable();
            tblBotones = botones(idUsuario, sedeToolStripMenuItem.Tag.ToString(), intIdEmpresa);

            if (Application.OpenForms.OfType<Sede_Listado>().Count() == 1)
                Application.OpenForms.OfType<Sede_Listado>().First().Close();

            Sede_Listado frm = new Sede_Listado();
            frm.MdiParent = this;
            frm.idUsuario = idUsuario;
            frm.idEmpresa = intIdEmpresa;
            frm.tsNuevo.Visible = (tblBotones.Rows[0]["intNuevo"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intNuevo"]);
            frm.tsEditar.Visible = (tblBotones.Rows[0]["intEditar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEditar"]);
            frm.tsVer.Visible = (tblBotones.Rows[0]["intVer"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intVer"]);
            frm.tsBuscar.Visible = (tblBotones.Rows[0]["intBuscar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intBuscar"]);
            frm.tsActualizar.Visible = (tblBotones.Rows[0]["intActualizar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intActualizar"]);
            frm.tsEliminar.Visible = (tblBotones.Rows[0]["intEliminar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEliminar"]);
            frm.tsImprimir.Visible = (tblBotones.Rows[0]["intImp"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intImp"]);
            frm.tsExportar.Visible = (tblBotones.Rows[0]["intExportar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intExportar"]);

            frm.Show();
        }
        
        private void cambiarEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Busqueda frm = new Busqueda();
            //frm.MdiParent = this;
            frm.nombre_maestro = "EMPRESA";
            frm.intIdUsu = idUsuario;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                int xbuscar = frm.idEncontrado;
                string xbuscarn = frm.nombreEncontrado;
                intIdEmpresa = xbuscar;
                strNoEmpresa = xbuscarn;

                for (int i = 0; i < this.MdiChildren.Length; i++)
                {
                    this.MdiChildren[i].Close();
                    i = i - 1;
                }

                ActualizarSBar();
            }


        }

        public void ActualizarSBar()
        {
            ssUser.Text = usuarioConect;
            ssEmpresa.Text = strNoEmpresa;
            //trae permisos menu
            Clases.InicialCls.LeerXml();
            //DataTable tb = new DataTable();
            bool pblntodoOk = false;
            Negocio.NGMenu obj = new NGMenu(Configuracion.Sistema.CadenaConexion);
            tb = obj.MenuAcceso(idUsuario, intIdEmpresa, ref pblntodoOk);


            //asignar llave
            DataColumn[] colPk1 = new DataColumn[1];
            colPk1[0] = tb.Columns["strCoMenu"];
            tb.PrimaryKey = colPk1;

            foreach (ToolStripMenuItem mnuitOpcion in this.menuStrip1.Items)
            {
                //MessageBox.Show(mnuitOpcion.Text);
                //MessageBox.Show(i.ToString());

                if (mnuitOpcion.Tag != null && mnuitOpcion.Tag.ToString() != string.Empty)
                {
                    string ss = mnuitOpcion.Tag.ToString();
                    DataRow foundRow1 = tb.Rows.Find(ss);
                    //MessageBox.Show(ss);
                    if (foundRow1 != null)
                    {
                        mnuitOpcion.Visible = true;
                    }
                    else
                    {
                        mnuitOpcion.Visible = false;
                    }
                }

                if (mnuitOpcion.DropDownItems.Count > 0)
                {
                    this.CambiarOpcionesMenu(mnuitOpcion.DropDownItems);
                }
                //m_i = m_i + 1;
            }
        }

        private void cambiarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.cambiarUsuario = 1;
            //frm.Show();
            login.btnIngresar.Visible = true;

            //frm.Show();
            if (login.ShowDialog() == DialogResult.OK)
            {
                int xbuscar = login.intIdUsux;
                string xbuscarn = login.strNoUsux;
                idUsuario = xbuscar;
                usuarioConect = xbuscarn;

                for (int i = 0; i < this.MdiChildren.Length; i++)
                {
                    this.MdiChildren[i].Close();
                    i = i - 1;
                }
                //this.Hide();

                cargaEmpresa();

                //ActualizarSBar();
            }
        }

        private void creacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable tblBotones = new DataTable();
            tblBotones = botones(idUsuario, creacionToolStripMenuItem.Tag.ToString(), intIdEmpresa);

            if (Application.OpenForms.OfType<Unidad_Listado>().Count() == 1)
                Application.OpenForms.OfType<Unidad_Listado>().First().Close();

            Unidad_Listado frm = new Unidad_Listado();
            frm.MdiParent = this;
            frm.idUsuario = idUsuario;
            frm.idEmpresa = intIdEmpresa;
            frm.tsNuevo.Visible = (tblBotones.Rows[0]["intNuevo"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intNuevo"]);
            frm.tsEditar.Visible = (tblBotones.Rows[0]["intEditar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEditar"]);
            frm.tsVer.Visible = (tblBotones.Rows[0]["intVer"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intVer"]);
            frm.tsBuscar.Visible = (tblBotones.Rows[0]["intBuscar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intBuscar"]);
            frm.tsActualizar.Visible = (tblBotones.Rows[0]["intActualizar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intActualizar"]);
            frm.tsEliminar.Visible = (tblBotones.Rows[0]["intEliminar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEliminar"]);
            frm.tsImprimir.Visible = (tblBotones.Rows[0]["intImp"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intImp"]);
            frm.tsExportar.Visible = (tblBotones.Rows[0]["intExportar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intExportar"]);

            frm.Show();
        }

        private void accesosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<UnidadEmpresa>().Count() == 1)
                Application.OpenForms.OfType<UnidadEmpresa>().First().Close();

            UnidadEmpresa frm = new UnidadEmpresa();
            frm.MdiParent = this;
            frm.idEmpresa = intIdEmpresa;
            frm.nombreEmpresa = strNoEmpresa;
            frm.Show();
        }

        private void subFamiliaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable tblBotones = new DataTable();
            tblBotones = botones(idUsuario, subFamiliaToolStripMenuItem.Tag.ToString(), intIdEmpresa);

            if (Application.OpenForms.OfType<SubFamilia_Listado>().Count() == 1)
                Application.OpenForms.OfType<SubFamilia_Listado>().First().Close();

            SubFamilia_Listado frm = new SubFamilia_Listado();
            frm.MdiParent = this;
            frm.idEmpresa = intIdEmpresa;
            frm.idUsuario = idUsuario;
            frm.tsNuevo.Visible = (tblBotones.Rows[0]["intNuevo"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intNuevo"]);
            frm.tsEditar.Visible = (tblBotones.Rows[0]["intEditar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEditar"]);
            frm.tsVer.Visible = (tblBotones.Rows[0]["intVer"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intVer"]);
            frm.tsBuscar.Visible = (tblBotones.Rows[0]["intBuscar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intBuscar"]);
            frm.tsActualizar.Visible = (tblBotones.Rows[0]["intActualizar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intActualizar"]);
            frm.tsEliminar.Visible = (tblBotones.Rows[0]["intEliminar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEliminar"]);
            frm.tsImprimir.Visible = (tblBotones.Rows[0]["intImp"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intImp"]);
            frm.tsExportar.Visible = (tblBotones.Rows[0]["intExportar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intExportar"]);

            frm.Show();
        }

        private void cargarSubFamiliaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Busqueda frm = new Busqueda();
            //frm.MdiParent = this;
            frm.tipoBusqueda = 9;
            frm.intIdUsu = idUsuario;
            frm.idEmpresa = intIdEmpresa;
            frm.Show();

        }

        private void familiaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void articuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void creacionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataTable tblBotones = new DataTable();
            tblBotones = botones(idUsuario, creacionToolStripMenuItem1.Tag.ToString(), intIdEmpresa);

            if (Application.OpenForms.OfType<OpeLog_Listado>().Count() == 1)
                Application.OpenForms.OfType<OpeLog_Listado>().First().Close();

            OpeLog_Listado frm = new OpeLog_Listado();
            frm.MdiParent = this;
            frm.idEmpresa = intIdEmpresa;
            frm.idUsuario = idUsuario;
            frm.tsNuevo.Visible = (tblBotones.Rows[0]["intNuevo"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intNuevo"]);
            frm.tsEditar.Visible = (tblBotones.Rows[0]["intEditar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEditar"]);
            frm.tsVer.Visible = (tblBotones.Rows[0]["intVer"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intVer"]);
            frm.tsBuscar.Visible = (tblBotones.Rows[0]["intBuscar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intBuscar"]);
            frm.tsActualizar.Visible = (tblBotones.Rows[0]["intActualizar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intActualizar"]);
            frm.tsEliminar.Visible = (tblBotones.Rows[0]["intEliminar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEliminar"]);
            frm.tsImprimir.Visible = (tblBotones.Rows[0]["intImp"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intImp"]);
            frm.tsExportar.Visible = (tblBotones.Rows[0]["intExportar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intExportar"]);

            frm.Show();
        }

        private void asignacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<OpeLogEmpresa>().Count() == 1)
                Application.OpenForms.OfType<OpeLogEmpresa>().First().Close();

            OpeLogEmpresa frm = new OpeLogEmpresa();
            frm.MdiParent = this;
            frm.idEmpresa = intIdEmpresa;
            frm.nombreEmpresa = strNoEmpresa;
            frm.Show();
        }

        private void clasificacionArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable tblBotones = new DataTable();
            tblBotones = botones(idUsuario, clasificacionArticulosToolStripMenuItem.Tag.ToString(), intIdEmpresa);

            if (Application.OpenForms.OfType<ClaArt_Listado>().Count() == 1)
                Application.OpenForms.OfType<ClaArt_Listado>().First().Close();

            ClaArt_Listado frm = new ClaArt_Listado();
            frm.MdiParent = this;
            frm.idEmpresa = intIdEmpresa;
            frm.idUsuario = idUsuario;
            frm.tsNuevo.Visible = (tblBotones.Rows[0]["intNuevo"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intNuevo"]);
            frm.tsEditar.Visible = (tblBotones.Rows[0]["intEditar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEditar"]);
            frm.tsVer.Visible = (tblBotones.Rows[0]["intVer"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intVer"]);
            frm.tsBuscar.Visible = (tblBotones.Rows[0]["intBuscar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intBuscar"]);
            frm.tsActualizar.Visible = (tblBotones.Rows[0]["intActualizar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intActualizar"]);
            frm.tsEliminar.Visible = (tblBotones.Rows[0]["intEliminar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEliminar"]);
            frm.tsImprimir.Visible = (tblBotones.Rows[0]["intImp"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intImp"]);
            frm.tsExportar.Visible = (tblBotones.Rows[0]["intExportar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intExportar"]);

            frm.Show();
        }

        private void creacionToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DataTable tblBotones = new DataTable();
            tblBotones = botones(idUsuario, creacionToolStripMenuItem2.Tag.ToString(), intIdEmpresa);

            if (Application.OpenForms.OfType<Almacen_Listado>().Count() == 1)
                Application.OpenForms.OfType<Almacen_Listado>().First().Close();

            Almacen_Listado frm = new Almacen_Listado();
            frm.MdiParent = this;
            frm.idEmpresa = intIdEmpresa;
            frm.nombreEmpresa = strNoEmpresa;
            frm.idUsuario = idUsuario;
            frm.tsNuevo.Visible = (tblBotones.Rows[0]["intNuevo"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intNuevo"]);
            frm.tsEditar.Visible = (tblBotones.Rows[0]["intEditar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEditar"]);
            frm.tsVer.Visible = (tblBotones.Rows[0]["intVer"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intVer"]);
            frm.tsBuscar.Visible = (tblBotones.Rows[0]["intBuscar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intBuscar"]);
            frm.tsActualizar.Visible = (tblBotones.Rows[0]["intActualizar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intActualizar"]);
            frm.tsEliminar.Visible = (tblBotones.Rows[0]["intEliminar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEliminar"]);
            frm.tsImprimir.Visible = (tblBotones.Rows[0]["intImp"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intImp"]);
            frm.tsExportar.Visible = (tblBotones.Rows[0]["intExportar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intExportar"]);

            frm.Show();
        }

        private void asignacionToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (Application.OpenForms.OfType<OpeLogAlmacen>().Count() == 1)
                Application.OpenForms.OfType<OpeLogAlmacen>().First().Close();

            OpeLogAlmacen frm = new OpeLogAlmacen();
            frm.MdiParent = this;
            frm.idEmpresa = intIdEmpresa;
            frm.nombreEmpresa = strNoEmpresa;
            frm.idUsuario = idUsuario;
            frm.Show();
        }

        private void creacionRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<MenuUsu>().Count() == 1)
                Application.OpenForms.OfType<MenuUsu>().First().Close();

            MenuUsu frm = new MenuUsu();
            frm.MdiParent = this;
            frm.idEmpresa = intIdEmpresa;
            frm.nombreEmpresa = strNoEmpresa;
            frm.Show();
        }

        private void menusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable tblBotones = new DataTable();
            tblBotones = botones(idUsuario, menusToolStripMenuItem.Tag.ToString(), intIdEmpresa);

            if (Application.OpenForms.OfType<Menu_Listado>().Count() == 1)
                Application.OpenForms.OfType<Menu_Listado>().First().Close();

            Menu_Listado frm = new Menu_Listado();
            frm.MdiParent = this;
            frm.idEmpresa = intIdEmpresa;
            frm.idUsuario = idUsuario;
            frm.tsNuevo.Visible = (tblBotones.Rows[0]["intNuevo"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intNuevo"]);
            frm.tsEditar.Visible = (tblBotones.Rows[0]["intEditar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEditar"]);
            frm.tsVer.Visible = (tblBotones.Rows[0]["intVer"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intVer"]);
            frm.tsBuscar.Visible = (tblBotones.Rows[0]["intBuscar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intBuscar"]);
            frm.tsActualizar.Visible = (tblBotones.Rows[0]["intActualizar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intActualizar"]);
            frm.tsEliminar.Visible = (tblBotones.Rows[0]["intEliminar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEliminar"]);
            frm.tsImprimir.Visible = (tblBotones.Rows[0]["intImp"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intImp"]);
            frm.tsExportar.Visible = (tblBotones.Rows[0]["intExportar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intExportar"]);

            frm.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Seguro desea salir de la Aplicación?";
            string caption = "Corfirmar Cierre";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Question);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void centroDeCostosToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void condicionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable tblBotones = new DataTable();
            tblBotones = botones(idUsuario, condicionToolStripMenuItem.Tag.ToString(), intIdEmpresa);

            if (Application.OpenForms.OfType<Condicion_Listado>().Count() == 1)
                Application.OpenForms.OfType<Condicion_Listado>().First().Close();

            Condicion_Listado frm = new Condicion_Listado();
            frm.MdiParent = this;
            frm.idUsuario = idUsuario;
            frm.idEmpresa = intIdEmpresa;
            frm.tsNuevo.Visible = (tblBotones.Rows[0]["intNuevo"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intNuevo"]);
            frm.tsEditar.Visible = (tblBotones.Rows[0]["intEditar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEditar"]);
            frm.tsVer.Visible = (tblBotones.Rows[0]["intVer"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intVer"]);
            frm.tsBuscar.Visible = (tblBotones.Rows[0]["intBuscar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intBuscar"]);
            frm.tsActualizar.Visible = (tblBotones.Rows[0]["intActualizar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intActualizar"]);
            frm.tsEliminar.Visible = (tblBotones.Rows[0]["intEliminar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEliminar"]);
            frm.tsImprimir.Visible = (tblBotones.Rows[0]["intImp"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intImp"]);
            frm.tsExportar.Visible = (tblBotones.Rows[0]["intExportar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intExportar"]);

            frm.Show();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void marcaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ubicacionFisicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable tblBotones = new DataTable();
            tblBotones = botones(idUsuario, ubicacionFisicaToolStripMenuItem.Tag.ToString(), intIdEmpresa);

            if (Application.OpenForms.OfType<UbicFisica_Listado>().Count() == 1)
                Application.OpenForms.OfType<UbicFisica_Listado>().First().Close();

            UbicFisica_Listado frm = new UbicFisica_Listado();
            frm.MdiParent = this;
            frm.idUsuario = idUsuario;
            frm.idEmpresa = intIdEmpresa;
            frm.tsNuevo.Visible = (tblBotones.Rows[0]["intNuevo"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intNuevo"]);
            frm.tsEditar.Visible = (tblBotones.Rows[0]["intEditar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEditar"]);
            frm.tsVer.Visible = (tblBotones.Rows[0]["intVer"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intVer"]);
            frm.tsBuscar.Visible = (tblBotones.Rows[0]["intBuscar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intBuscar"]);
            frm.tsActualizar.Visible = (tblBotones.Rows[0]["intActualizar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intActualizar"]);
            frm.tsEliminar.Visible = (tblBotones.Rows[0]["intEliminar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEliminar"]);
            frm.tsImprimir.Visible = (tblBotones.Rows[0]["intImp"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intImp"]);
            frm.tsExportar.Visible = (tblBotones.Rows[0]["intExportar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intExportar"]);

            frm.Show();
        }

        private void creacionToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            DataTable tblBotones = new DataTable();
            tblBotones = botones(idUsuario, creacionToolStripMenuItem4.Tag.ToString(), intIdEmpresa);

            if (Application.OpenForms.OfType<Empleado_Listado>().Count() == 1)
                Application.OpenForms.OfType<Empleado_Listado>().First().Close();

            Empleado_Listado frm = new Empleado_Listado();
            frm.MdiParent = this;
            frm.idUsuario = idUsuario;
            frm.idEmpresa = intIdEmpresa;

            frm.tsNuevo.Visible = (tblBotones.Rows[0]["intNuevo"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intNuevo"]);
            frm.tsEditar.Visible = (tblBotones.Rows[0]["intEditar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEditar"]);
            frm.tsVer.Visible = (tblBotones.Rows[0]["intVer"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intVer"]);
            frm.tsBuscar.Visible = (tblBotones.Rows[0]["intBuscar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intBuscar"]);
            frm.tsActualizar.Visible = (tblBotones.Rows[0]["intActualizar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intActualizar"]);
            frm.tsEliminar.Visible = (tblBotones.Rows[0]["intEliminar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEliminar"]);
            frm.tsImprimir.Visible = (tblBotones.Rows[0]["intImp"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intImp"]);
            frm.tsExportar.Visible = (tblBotones.Rows[0]["intExportar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intExportar"]);

            frm.Show();
        }

        private void asignarAEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<EmpleadoEmpresa>().Count() == 1)
                Application.OpenForms.OfType<EmpleadoEmpresa>().First().Close();

            EmpleadoEmpresa frm = new EmpleadoEmpresa();
            frm.MdiParent = this;
            //frm.idUsuario = idUsuario;
            frm.Show();
        }
       
        private void motivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void maestrosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void clasificacionDeEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable tblBotones = new DataTable();
            tblBotones = botones(idUsuario, clasificacionDeEmpleadosToolStripMenuItem.Tag.ToString(), intIdEmpresa);

            if (Application.OpenForms.OfType<ClaEmp_Listado>().Count() == 1)
                Application.OpenForms.OfType<ClaEmp_Listado>().First().Close();

            ClaEmp_Listado frm = new ClaEmp_Listado();
            frm.MdiParent = this;
            frm.idEmpresa = intIdEmpresa;
            frm.idUsuario = idUsuario;
            frm.tsNuevo.Visible = (tblBotones.Rows[0]["intNuevo"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intNuevo"]);
            frm.tsEditar.Visible = (tblBotones.Rows[0]["intEditar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEditar"]);
            frm.tsVer.Visible = (tblBotones.Rows[0]["intVer"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intVer"]);
            frm.tsBuscar.Visible = (tblBotones.Rows[0]["intBuscar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intBuscar"]);
            frm.tsActualizar.Visible = (tblBotones.Rows[0]["intActualizar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intActualizar"]);
            frm.tsEliminar.Visible = (tblBotones.Rows[0]["intEliminar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEliminar"]);
            frm.tsImprimir.Visible = (tblBotones.Rows[0]["intImp"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intImp"]);
            frm.tsExportar.Visible = (tblBotones.Rows[0]["intExportar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intExportar"]);

            frm.Show();
        }

        private void asignarClasificaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<EmpClaEmp>().Count() == 1)
                Application.OpenForms.OfType<EmpClaEmp>().First().Close();

            EmpClaEmp frm = new EmpClaEmp();
            frm.MdiParent = this;
            frm.idEmpresa = intIdEmpresa;
            frm.idUsuario = idUsuario;
            frm.Show();
        }

        private void tipoDeDocumentoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void creacionToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            DataTable tblBotones = new DataTable();
            tblBotones = botones(idUsuario, creacionToolStripMenuItem5.Tag.ToString(), intIdEmpresa);

            if (Application.OpenForms.OfType<TipoDoc_Listado>().Count() == 1)
                Application.OpenForms.OfType<TipoDoc_Listado>().First().Close();

            TipoDoc_Listado frm = new TipoDoc_Listado();
            frm.MdiParent = this;
            frm.idEmpresa = intIdEmpresa;
            frm.idUsuario = idUsuario;
            frm.tsNuevo.Visible = (tblBotones.Rows[0]["intNuevo"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intNuevo"]);
            frm.tsEditar.Visible = (tblBotones.Rows[0]["intEditar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEditar"]);
            frm.tsVer.Visible = (tblBotones.Rows[0]["intVer"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intVer"]);
            frm.tsBuscar.Visible = (tblBotones.Rows[0]["intBuscar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intBuscar"]);
            frm.tsActualizar.Visible = (tblBotones.Rows[0]["intActualizar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intActualizar"]);
            frm.tsEliminar.Visible = (tblBotones.Rows[0]["intEliminar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEliminar"]);
            frm.tsImprimir.Visible = (tblBotones.Rows[0]["intImp"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intImp"]);
            frm.tsExportar.Visible = (tblBotones.Rows[0]["intExportar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intExportar"]);

            frm.Show();
        }

        private void asignaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<TipoDocEmpresa>().Count() == 1)
                Application.OpenForms.OfType<TipoDocEmpresa>().First().Close();

            TipoDocEmpresa frm = new TipoDocEmpresa();
            frm.MdiParent = this;
            frm.idEmpresa = intIdEmpresa;
            frm.idUsuario = idUsuario;
            frm.nombreEmpresa = strNoEmpresa;
            frm.Show();
        }

        public DataTable botones(int idUsuario, string tagMenu, int idEmpresa)
        {
            bool blnTodoOK = false;
            Clases.InicialCls.LeerXml();

            NGComun obj = new NGComun(Configuracion.Sistema.CadenaConexion);
            return obj.Botones(idUsuario, tagMenu, idEmpresa, ref blnTodoOK);

        }

        private void asignarArticuloAAlmacenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<ArticuloAlmacen>().Count() == 1)
                Application.OpenForms.OfType<ArticuloAlmacen>().First().Close();


            ArticuloAlmacen frm = new ArticuloAlmacen();
            frm.MdiParent = this;
            frm.idEmpresa = intIdEmpresa;
            frm.idUsuario = idUsuario;
            frm.nombreEmpresa = strNoEmpresa;
            frm.Show();
        }

        private void asignarAUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<OpeLogUsuario>().Count() == 1)
                Application.OpenForms.OfType<OpeLogUsuario>().First().Close();

            OpeLogUsuario frm = new OpeLogUsuario();
            frm.MdiParent = this;
            frm.idUsuario = idUsuario;
            frm.idEmpresa = intIdEmpresa;
            frm.nombreEmpresa = strNoEmpresa;
            frm.Show();
        }

        private void creacionToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            DataTable tblBotones = new DataTable();
            tblBotones = botones(idUsuario, creacionToolStripMenuItem6.Tag.ToString(), intIdEmpresa);

            if (Application.OpenForms.OfType<Familia_Listado>().Count() == 1)
                Application.OpenForms.OfType<Familia_Listado>().First().Close();

            Familia_Listado frm = new Familia_Listado();
            frm.MdiParent = this;
            frm.idEmpresa = intIdEmpresa;
            frm.idUsuario = idUsuario;
            frm.tsNuevo.Visible = (tblBotones.Rows[0]["intNuevo"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intNuevo"]);
            frm.tsEditar.Visible = (tblBotones.Rows[0]["intEditar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEditar"]);
            frm.tsVer.Visible = (tblBotones.Rows[0]["intVer"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intVer"]);
            frm.tsBuscar.Visible = (tblBotones.Rows[0]["intBuscar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intBuscar"]);
            frm.tsActualizar.Visible = (tblBotones.Rows[0]["intActualizar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intActualizar"]);
            frm.tsEliminar.Visible = (tblBotones.Rows[0]["intEliminar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEliminar"]);
            frm.tsImprimir.Visible = (tblBotones.Rows[0]["intImp"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intImp"]);
            frm.tsExportar.Visible = (tblBotones.Rows[0]["intExportar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intExportar"]);

            frm.Show();
        }

        private void asignacionAEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<FamiliaEmpresa>().Count() == 1)
                Application.OpenForms.OfType<FamiliaEmpresa>().First().Close();

            FamiliaEmpresa frm = new FamiliaEmpresa();
            frm.MdiParent = this;
            frm.idEmpresa = intIdEmpresa;
            frm.nombreEmpresa = strNoEmpresa;
            frm.Show();
        }

        private void creacionMarcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable tblBotones = new DataTable();
            tblBotones = botones(idUsuario, creacionMarcaToolStripMenuItem.Tag.ToString(), intIdEmpresa);

            if (Application.OpenForms.OfType<Marca_Listado>().Count() == 1)
                Application.OpenForms.OfType<Marca_Listado>().First().Close();

            Marca_Listado frm = new Marca_Listado();
            frm.MdiParent = this;
            frm.idUsuario = idUsuario;
            frm.idEmpresa = intIdEmpresa;
            frm.tsNuevo.Visible = (tblBotones.Rows[0]["intNuevo"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intNuevo"]);
            frm.tsEditar.Visible = (tblBotones.Rows[0]["intEditar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEditar"]);
            frm.tsVer.Visible = (tblBotones.Rows[0]["intVer"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intVer"]);
            frm.tsBuscar.Visible = (tblBotones.Rows[0]["intBuscar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intBuscar"]);
            frm.tsActualizar.Visible = (tblBotones.Rows[0]["intActualizar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intActualizar"]);
            frm.tsEliminar.Visible = (tblBotones.Rows[0]["intEliminar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEliminar"]);
            frm.tsImprimir.Visible = (tblBotones.Rows[0]["intImp"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intImp"]);
            frm.tsExportar.Visible = (tblBotones.Rows[0]["intExportar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intExportar"]);

            frm.Show();
        }

        private void asignarAEmpresaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<MarcaEmpresa>().Count() == 1)
                Application.OpenForms.OfType<MarcaEmpresa>().First().Close();

            MarcaEmpresa frm = new MarcaEmpresa();
            frm.MdiParent = this;
            frm.idEmpresa = intIdEmpresa;
            frm.nombreEmpresa = strNoEmpresa;
            frm.Show();
        }

        private void creacionUnidadNegocioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable tblBotones = new DataTable();
            tblBotones = botones(idUsuario, creacionUnidadNegocioToolStripMenuItem.Tag.ToString(), intIdEmpresa);

            if (Application.OpenForms.OfType<UndNegocio_Listado>().Count() == 1)
                Application.OpenForms.OfType<UndNegocio_Listado>().First().Close();

            UndNegocio_Listado frm = new UndNegocio_Listado();
            frm.MdiParent = this;
            frm.idEmpresa = intIdEmpresa;
            frm.idUsuario = idUsuario;
            frm.tsNuevo.Visible = (tblBotones.Rows[0]["intNuevo"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intNuevo"]);
            frm.tsEditar.Visible = (tblBotones.Rows[0]["intEditar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEditar"]);
            frm.tsVer.Visible = (tblBotones.Rows[0]["intVer"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intVer"]);
            frm.tsBuscar.Visible = (tblBotones.Rows[0]["intBuscar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intBuscar"]);
            frm.tsActualizar.Visible = (tblBotones.Rows[0]["intActualizar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intActualizar"]);
            frm.tsEliminar.Visible = (tblBotones.Rows[0]["intEliminar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEliminar"]);
            frm.tsImprimir.Visible = (tblBotones.Rows[0]["intImp"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intImp"]);
            frm.tsExportar.Visible = (tblBotones.Rows[0]["intExportar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intExportar"]);

            //frm.tsNuevo.Enabled = false;

            frm.Show();
        }

        private void asignarAEmpresaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<UniNegEmpresa>().Count() == 1)
                Application.OpenForms.OfType<UniNegEmpresa>().First().Close();

            UniNegEmpresa frm = new UniNegEmpresa();
            frm.MdiParent = this;
            frm.idEmpresa = intIdEmpresa;
            frm.idUsuario = idUsuario;
            frm.nombreEmpresa = strNoEmpresa;
            frm.Show();
        }

        private void asignarAUsuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<UniNegUsuario>().Count() == 1)
                Application.OpenForms.OfType<UniNegUsuario>().First().Close();

            UniNegUsuario frm = new UniNegUsuario();
            frm.MdiParent = this;
            frm.idUsuario = idUsuario;
            frm.idEmpresa = intIdEmpresa;
            frm.nombreEmpresa = strNoEmpresa;
            frm.Show();
        }

        private void numeradoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<CambiarContrasena>().Count() == 1)
                Application.OpenForms.OfType<CambiarContrasena>().First().Close();

            CambiarContrasena frm = new CambiarContrasena();
            frm.MdiParent = this;
            frm.idUsuario = idUsuario;

            frm.Show();
        }

        private void baseDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<BaseDatos>().Count() == 1)
                Application.OpenForms.OfType<BaseDatos>().First().Close();

            BaseDatos frm = new BaseDatos();
            frm.ShowDialog();
            Clases.InicialCls.LeerXml();
            tssBaseDatos.Text = "Base De Datos: " + Configuracion.Sistema.BaseDatosSQL;
        }

        private void tipoDeCambioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable tblBotones = new DataTable();
            tblBotones = botones(idUsuario, tipoDeCambioToolStripMenuItem.Tag.ToString(), intIdEmpresa);

            if (Application.OpenForms.OfType<TipoCambio_Listado>().Count() == 1)
                Application.OpenForms.OfType<TipoCambio_Listado>().First().Close();

            TipoCambio_Listado frm = new TipoCambio_Listado();
            frm.MdiParent = this;
            frm.idUsuario = idUsuario;
            frm.idEmpresa = intIdEmpresa;

            frm.tsNuevo.Visible = (tblBotones.Rows[0]["intNuevo"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intNuevo"]);
            frm.tsEditar.Visible = (tblBotones.Rows[0]["intEditar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEditar"]);
            frm.tsVer.Visible = (tblBotones.Rows[0]["intVer"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intVer"]);
            frm.tsBuscar.Visible = (tblBotones.Rows[0]["intBuscar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intBuscar"]);
            frm.tsActualizar.Visible = (tblBotones.Rows[0]["intActualizar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intActualizar"]);
            frm.tsEliminar.Visible = (tblBotones.Rows[0]["intEliminar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEliminar"]);
            frm.tsImprimir.Visible = (tblBotones.Rows[0]["intImp"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intImp"]);
            frm.tsExportar.Visible = (tblBotones.Rows[0]["intExportar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intExportar"]);
            //frm.nombreEmpresa = strNoEmpresa;
            frm.Show();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void proveedoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<Proveedor_Listado>().Count() == 1)
                Application.OpenForms.OfType<Proveedor_Listado>().First().Close();

            Proveedor_Listado frm = new Proveedor_Listado();
            frm.MdiParent = this;
            frm.idUsuario = idUsuario;
            frm.idEmpresa = intIdEmpresa;
            //frm.nombreEmpresa = strNoEmpresa;
            frm.Show();
        }

        private void cuentasProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<CuentaProveedor_Listado>().Count() == 1)
                Application.OpenForms.OfType<CuentaProveedor_Listado>().First().Close();

            CuentaProveedor_Listado frm = new CuentaProveedor_Listado();
            frm.MdiParent = this;
            frm.idUsuario = idUsuario;
            frm.idEmpresa = intIdEmpresa;
            //frm.nombreEmpresa = strNoEmpresa;
            frm.Show();
        }

        private void bancosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable tblBotones = new DataTable();
            tblBotones = botones(idUsuario, bancosToolStripMenuItem.Tag.ToString(), intIdEmpresa);

            if (Application.OpenForms.OfType<Bancos_Listado>().Count() == 1)
                Application.OpenForms.OfType<Bancos_Listado>().First().Close();

            Bancos_Listado frm = new Bancos_Listado();
            frm.MdiParent = this;
            frm.idUsuario = idUsuario;
            frm.idEmpresa = intIdEmpresa;

            frm.tsNuevo.Visible = (tblBotones.Rows[0]["intNuevo"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intNuevo"]);
            frm.tsEditar.Visible = (tblBotones.Rows[0]["intEditar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEditar"]);
            frm.tsVer.Visible = (tblBotones.Rows[0]["intVer"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intVer"]);
            frm.tsBuscar.Visible = (tblBotones.Rows[0]["intBuscar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intBuscar"]);
            frm.tsActualizar.Visible = (tblBotones.Rows[0]["intActualizar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intActualizar"]);
            frm.tsEliminar.Visible = (tblBotones.Rows[0]["intEliminar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEliminar"]);
            frm.tsImprimir.Visible = (tblBotones.Rows[0]["intImp"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intImp"]);
            frm.tsExportar.Visible = (tblBotones.Rows[0]["intExportar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intExportar"]);
            //frm.nombreEmpresa = strNoEmpresa;
            frm.Show();
        }

        private void periodoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DataTable tblBotones = new DataTable();
            tblBotones = botones(idUsuario, periodoToolStripMenuItem.Tag.ToString(), intIdEmpresa);

            if (Application.OpenForms.OfType<Periodo_Listado>().Count() == 1)
                Application.OpenForms.OfType<Periodo_Listado>().First().Close();

            Periodo_Listado frm = new Periodo_Listado();
            frm.MdiParent = this;
            frm.idUsuario = idUsuario;
            frm.idEmpresa = intIdEmpresa;

            frm.tsNuevo.Visible = (tblBotones.Rows[0]["intNuevo"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intNuevo"]);
            frm.tsEditar.Visible = (tblBotones.Rows[0]["intEditar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEditar"]);
            frm.tsVer.Visible = (tblBotones.Rows[0]["intVer"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intVer"]);
            frm.tsBuscar.Visible = (tblBotones.Rows[0]["intBuscar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intBuscar"]);
            frm.tsActualizar.Visible = (tblBotones.Rows[0]["intActualizar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intActualizar"]);
            frm.tsEliminar.Visible = (tblBotones.Rows[0]["intEliminar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEliminar"]);
            frm.tsImprimir.Visible = (tblBotones.Rows[0]["intImp"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intImp"]);
            frm.tsExportar.Visible = (tblBotones.Rows[0]["intExportar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intExportar"]);
            //frm.nombreEmpresa = strNoEmpresa;
            //frm.nombreEmpresa = strNoEmpresa;
            frm.Show();
        }

        private void cierreAlmacenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable tblBotones = new DataTable();
            tblBotones = botones(idUsuario, cierreAlmacenToolStripMenuItem.Tag.ToString(), intIdEmpresa);

            if (Application.OpenForms.OfType<CierreAlmacen_Listado>().Count() == 1)
                Application.OpenForms.OfType<CierreAlmacen_Listado>().First().Close();

            CierreAlmacen_Listado frm = new CierreAlmacen_Listado();
            frm.MdiParent = this;
            frm.idUsuario = idUsuario;
            frm.idEmpresa = intIdEmpresa;

            frm.tsNuevo.Visible = (tblBotones.Rows[0]["intNuevo"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intNuevo"]);
            frm.tsEditar.Visible = (tblBotones.Rows[0]["intEditar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEditar"]);
            frm.tsVer.Visible = (tblBotones.Rows[0]["intVer"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intVer"]);
            frm.tsBuscar.Visible = (tblBotones.Rows[0]["intBuscar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intBuscar"]);
            frm.tsActualizar.Visible = (tblBotones.Rows[0]["intActualizar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intActualizar"]);
            frm.tsEliminar.Visible = (tblBotones.Rows[0]["intEliminar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEliminar"]);
            frm.tsImprimir.Visible = (tblBotones.Rows[0]["intImp"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intImp"]);
            frm.tsExportar.Visible = (tblBotones.Rows[0]["intExportar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intExportar"]);
            //frm.nombreEmpresa = strNoEmpresa;
            frm.Show();
        }

        private void configurarAlmacenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<ConfigAlmacen_Listado>().Count() == 1)
                Application.OpenForms.OfType<ConfigAlmacen_Listado>().First().Close();

            ConfigAlmacen_Listado frm = new ConfigAlmacen_Listado();
            frm.MdiParent = this;
            frm.idUsuario = idUsuario;
            frm.idEmpresa = intIdEmpresa;
            frm.nombreEmpresa = strNoEmpresa;
            frm.Show();
        }

        private void creacionToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            //DataTable tblBotones = new DataTable();
            //tblBotones = botones(idUsuario, creacionToolStripMenuItem4.Tag.ToString(), intIdEmpresa);

            //if (Application.OpenForms.OfType<Empleado_Listado>().Count() == 1)
            //    Application.OpenForms.OfType<Empleado_Listado>().First().Close();

            Maquina_Listado frm = new Maquina_Listado();
            frm.MdiParent = this;
            frm.idUsuario = idUsuario;
            frm.idEmpresa = intIdEmpresa;

            //frm.tsNuevo.Visible = (tblBotones.Rows[0]["intNuevo"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intNuevo"]);
            //frm.tsEditar.Visible = (tblBotones.Rows[0]["intEditar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEditar"]);
            //frm.tsVer.Visible = (tblBotones.Rows[0]["intVer"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intVer"]);
            //frm.tsBuscar.Visible = (tblBotones.Rows[0]["intBuscar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intBuscar"]);
            //frm.tsActualizar.Visible = (tblBotones.Rows[0]["intActualizar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intActualizar"]);
            //frm.tsEliminar.Visible = (tblBotones.Rows[0]["intEliminar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEliminar"]);
            //frm.tsImprimir.Visible = (tblBotones.Rows[0]["intImp"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intImp"]);
            //frm.tsExportar.Visible = (tblBotones.Rows[0]["intExportar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intExportar"]);

            frm.Show();
        }

        private void asignarAAlmacenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DataTable tblBotones = new DataTable();
            //tblBotones = botones(idUsuario, creacionToolStripMenuItem4.Tag.ToString(), intIdEmpresa);

            //if (Application.OpenForms.OfType<Empleado_Listado>().Count() == 1)
            //    Application.OpenForms.OfType<Empleado_Listado>().First().Close();

            MaquinaAlmacen frm = new MaquinaAlmacen();
            frm.MdiParent = this;
            //frm.idUsuario = idUsuario;
            frm.idEmpresa = intIdEmpresa;
            frm.nombreEmpresa = strNoEmpresa;

            //frm.tsNuevo.Visible = (tblBotones.Rows[0]["intNuevo"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intNuevo"]);
            //frm.tsEditar.Visible = (tblBotones.Rows[0]["intEditar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEditar"]);
            //frm.tsVer.Visible = (tblBotones.Rows[0]["intVer"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intVer"]);
            //frm.tsBuscar.Visible = (tblBotones.Rows[0]["intBuscar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intBuscar"]);
            //frm.tsActualizar.Visible = (tblBotones.Rows[0]["intActualizar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intActualizar"]);
            //frm.tsEliminar.Visible = (tblBotones.Rows[0]["intEliminar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEliminar"]);
            //frm.tsImprimir.Visible = (tblBotones.Rows[0]["intImp"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intImp"]);
            //frm.tsExportar.Visible = (tblBotones.Rows[0]["intExportar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intExportar"]);

            frm.Show();
        }

        private void maquinaArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArticuloMaquina frm = new ArticuloMaquina();
            frm.MdiParent = this;
            frm.idEmpresa = intIdEmpresa;
            frm.nombreEmpresa = strNoEmpresa;
            frm.Show();
        }

        private void crearNumeradorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable tblBotones = new DataTable();
            tblBotones = botones(idUsuario, numeradoresToolStripMenuItem.Tag.ToString(), intIdEmpresa);

            if (Application.OpenForms.OfType<Numerador_Listado>().Count() == 1)
                Application.OpenForms.OfType<Numerador_Listado>().First().Close();

            Numerador_Listado frm = new Numerador_Listado();
            frm.MdiParent = this;
            frm.idUsuario = idUsuario;
            frm.idEmpresa = intIdEmpresa;

            frm.tsNuevo.Visible = (tblBotones.Rows[0]["intNuevo"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intNuevo"]);
            frm.tsEditar.Visible = (tblBotones.Rows[0]["intEditar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEditar"]);
            frm.tsVer.Visible = (tblBotones.Rows[0]["intVer"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intVer"]);
            frm.tsBuscar.Visible = (tblBotones.Rows[0]["intBuscar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intBuscar"]);
            frm.tsActualizar.Visible = (tblBotones.Rows[0]["intActualizar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intActualizar"]);
            frm.tsEliminar.Visible = (tblBotones.Rows[0]["intEliminar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEliminar"]);
            frm.tsImprimir.Visible = (tblBotones.Rows[0]["intImp"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intImp"]);
            frm.tsExportar.Visible = (tblBotones.Rows[0]["intExportar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intExportar"]);
            //frm.nombreEmpresa = strNoEmpresa;
            frm.Show();
        }

        private void asignarNumeradorUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NumeradorUsuario frm = new NumeradorUsuario();
            frm.MdiParent = this;
            frm.idUsuario = idUsuario;
            frm.idEmpresa = intIdEmpresa;
            frm.nombreEmpresa = strNoEmpresa;
            frm.Show();
        }

        private void maquinaUnidadDeNegocioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MaquinaUniNeg frm = new MaquinaUniNeg();
            frm.MdiParent = this;
            frm.idUsuario = idUsuario;
            frm.idEmpresa = intIdEmpresa;
            frm.nombreEmpresa = strNoEmpresa;
            frm.Show();
        }

        private void articuloToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataTable tblBotones = new DataTable();
            tblBotones = botones(idUsuario, articuloToolStripMenuItem1.Tag.ToString(), intIdEmpresa);

            if (Application.OpenForms.OfType<Articulo_Listado>().Count() == 1)
                Application.OpenForms.OfType<Articulo_Listado>().First().Close();

            Articulo_Listado frm = new Articulo_Listado();
            frm.MdiParent = this;
            frm.idEmpresa = intIdEmpresa;
            frm.idUsuario = idUsuario;
            frm.tsNuevo.Visible = (tblBotones.Rows[0]["intNuevo"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intNuevo"]);
            frm.tsEditar.Visible = (tblBotones.Rows[0]["intEditar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEditar"]);
            frm.tsVer.Visible = (tblBotones.Rows[0]["intVer"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intVer"]);
            frm.tsBuscar.Visible = (tblBotones.Rows[0]["intBuscar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intBuscar"]);
            frm.tsActualizar.Visible = (tblBotones.Rows[0]["intActualizar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intActualizar"]);
            frm.tsEliminar.Visible = (tblBotones.Rows[0]["intEliminar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEliminar"]);
            frm.tsImprimir.Visible = (tblBotones.Rows[0]["intImp"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intImp"]);
            frm.tsExportar.Visible = (tblBotones.Rows[0]["intExportar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intExportar"]);

            frm.Show();
        }

        private void asignarAEmpresaToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ArticuloEmpresa frm = new ArticuloEmpresa();
            frm.MdiParent = this;
            frm.idUsuario = idUsuario;
            frm.idEmpresa = intIdEmpresa;
            frm.nombreEmpresa = strNoEmpresa;
            frm.Show();
        }

        private void clientesEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<ClienteEmpresa>().Count() == 1)
                Application.OpenForms.OfType<ClienteEmpresa>().First().Close();

            ClienteEmpresa frm = new ClienteEmpresa();
            frm.MdiParent = this;
            //frm.idUsuario = idUsuario;
            frm.Show();
        }

        private void vendedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable tblBotones = new DataTable();
            tblBotones = botones(idUsuario, vendedoresToolStripMenuItem.Tag.ToString(), intIdEmpresa);

            if (Application.OpenForms.OfType<Vendedores_Listado>().Count() == 1)
                Application.OpenForms.OfType<Vendedores_Listado>().First().Close();

            Vendedores_Listado frm = new Vendedores_Listado();
            frm.MdiParent = this;
            frm.idUsuario = idUsuario;
            frm.idEmpresa = intIdEmpresa;

            frm.tsNuevo.Visible = (tblBotones.Rows[0]["intNuevo"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intNuevo"]);
            frm.tsEditar.Visible = (tblBotones.Rows[0]["intEditar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEditar"]);
            frm.tsVer.Visible = (tblBotones.Rows[0]["intVer"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intVer"]);
            frm.tsBuscar.Visible = (tblBotones.Rows[0]["intBuscar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intBuscar"]);
            frm.tsActualizar.Visible = (tblBotones.Rows[0]["intActualizar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intActualizar"]);
            frm.tsEliminar.Visible = (tblBotones.Rows[0]["intEliminar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEliminar"]);
            frm.tsImprimir.Visible = (tblBotones.Rows[0]["intImp"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intImp"]);
            frm.tsExportar.Visible = (tblBotones.Rows[0]["intExportar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intExportar"]);

            frm.Show();
        }

        private void clientesListadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable tblBotones = new DataTable();
            tblBotones = botones(idUsuario, clientesListadoToolStripMenuItem.Tag.ToString(), intIdEmpresa);

            if (Application.OpenForms.OfType<Vendedores_Listado>().Count() == 1)
                Application.OpenForms.OfType<Vendedores_Listado>().First().Close();

            Clientes_Listado frm = new Clientes_Listado();
            frm.MdiParent = this;
            frm.idUsuario = idUsuario;
            frm.idEmpresa = intIdEmpresa;

            frm.tsNuevo.Visible = (tblBotones.Rows[0]["intNuevo"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intNuevo"]);
            frm.tsEditar.Visible = (tblBotones.Rows[0]["intEditar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEditar"]);
            frm.tsVer.Visible = (tblBotones.Rows[0]["intVer"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intVer"]);
            frm.tsBuscar.Visible = (tblBotones.Rows[0]["intBuscar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intBuscar"]);
            frm.tsActualizar.Visible = (tblBotones.Rows[0]["intActualizar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intActualizar"]);
            frm.tsEliminar.Visible = (tblBotones.Rows[0]["intEliminar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEliminar"]);
            frm.tsImprimir.Visible = (tblBotones.Rows[0]["intImp"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intImp"]);
            frm.tsExportar.Visible = (tblBotones.Rows[0]["intExportar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intExportar"]);

            frm.Show();
        }

        private void numeradorPorDefectoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<Asignar_Num_Default>().Count() == 1)
                Application.OpenForms.OfType<Asignar_Num_Default>().First().Close();

            Asignar_Num_Default frm = new Asignar_Num_Default();
            frm.MdiParent = this;
            frm.idUsuario = idUsuario;
            frm.idEmpresa = intIdEmpresa;
            frm.Show();
        }
        
        private void creacionUnidadGestionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable tblBotones = new DataTable();
            tblBotones = botones(idUsuario, creacionUnidadGestionToolStripMenuItem.Tag.ToString(), intIdEmpresa);

            if (Application.OpenForms.OfType<UndGestion_Listado>().Count() == 1)
                Application.OpenForms.OfType<UndGestion_Listado>().First().Close();

            UndGestion_Listado frm = new UndGestion_Listado();
            frm.MdiParent = this;
            frm.idEmpresa = intIdEmpresa;
            frm.idUsuario = idUsuario;
            frm.tsNuevo.Visible = (tblBotones.Rows[0]["intNuevo"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intNuevo"]);
            frm.tsEditar.Visible = (tblBotones.Rows[0]["intEditar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEditar"]);
            frm.tsVer.Visible = (tblBotones.Rows[0]["intVer"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intVer"]);
            frm.tsBuscar.Visible = (tblBotones.Rows[0]["intBuscar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intBuscar"]);
            frm.tsActualizar.Visible = (tblBotones.Rows[0]["intActualizar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intActualizar"]);
            frm.tsEliminar.Visible = (tblBotones.Rows[0]["intEliminar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEliminar"]);
            frm.tsImprimir.Visible = (tblBotones.Rows[0]["intImp"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intImp"]);
            frm.tsExportar.Visible = (tblBotones.Rows[0]["intExportar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intExportar"]);

            //frm.tsNuevo.Enabled = false;

            frm.Show();
        }

        private void asignarAUsuarioToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<AreaUsuario>().Count() == 1)
                Application.OpenForms.OfType<AreaUsuario>().First().Close();

            AreaUsuario frm = new AreaUsuario();
            frm.MdiParent = this;
            frm.idUsuario = idUsuario;
            frm.idEmpresa = intIdEmpresa;
            frm.nombreEmpresa = strNoEmpresa;
            frm.Show();
        }

        private void creacionDeAreaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable tblBotones = new DataTable();
            tblBotones = botones(idUsuario, creacionDeAreaToolStripMenuItem.Tag.ToString(), intIdEmpresa);

            if (Application.OpenForms.OfType<Area_Listado>().Count() == 1)
                Application.OpenForms.OfType<Area_Listado>().First().Close();

            Area_Listado frm = new Area_Listado();
            frm.MdiParent = this;
            frm.idEmpresa = intIdEmpresa;
            frm.idUsuario = idUsuario;
            frm.tsNuevo.Visible = (tblBotones.Rows[0]["intNuevo"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intNuevo"]);
            frm.tsEditar.Visible = (tblBotones.Rows[0]["intEditar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEditar"]);
            frm.tsVer.Visible = (tblBotones.Rows[0]["intVer"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intVer"]);
            frm.tsBuscar.Visible = (tblBotones.Rows[0]["intBuscar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intBuscar"]);
            frm.tsActualizar.Visible = (tblBotones.Rows[0]["intActualizar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intActualizar"]);
            frm.tsEliminar.Visible = (tblBotones.Rows[0]["intEliminar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEliminar"]);
            frm.tsImprimir.Visible = (tblBotones.Rows[0]["intImp"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intImp"]);
            frm.tsExportar.Visible = (tblBotones.Rows[0]["intExportar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intExportar"]);

            //frm.tsNuevo.Enabled = false;

            frm.Show();
        }

        private void asignarASedeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<UniNegSede>().Count() == 1)
                Application.OpenForms.OfType<UniNegSede>().First().Close();

            UniNegSede frm = new UniNegSede();
            frm.MdiParent = this;
            frm.idEmpresa = intIdEmpresa;
            frm.idUsuario = idUsuario;
            frm.nombreEmpresa = strNoEmpresa;
            frm.Show();
        }

        private void asignarAUsuarioToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<UniGesUsuario>().Count() == 1)
                Application.OpenForms.OfType<UniGesUsuario>().First().Close();

            UniGesUsuario frm = new UniGesUsuario();
            frm.MdiParent = this;
            frm.idEmpresa = intIdEmpresa;
            frm.idUsuario = idUsuario;
            frm.nombreEmpresa = strNoEmpresa;
            frm.Show();
        }

        private void asignarAEmpresaToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<UniGesEmpresa>().Count() == 1)
                Application.OpenForms.OfType<UniGesEmpresa>().First().Close();

            UniGesEmpresa frm = new UniGesEmpresa();
            frm.MdiParent = this;
            frm.idEmpresa = intIdEmpresa;
            frm.idUsuario = idUsuario;
            frm.nombreEmpresa = strNoEmpresa;
            frm.Show();
        }

        private void creacionDeMotivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable tblBotones = new DataTable();
            tblBotones = botones(idUsuario, motivoToolStripMenuItem.Tag.ToString(), intIdEmpresa);

            if (Application.OpenForms.OfType<Motivo_Listado>().Count() == 1)
                Application.OpenForms.OfType<Motivo_Listado>().First().Close();

            Motivo_Listado frm = new Motivo_Listado();
            frm.MdiParent = this;
            frm.idUsuario = idUsuario;
            frm.idEmpresa = intIdEmpresa;
            frm.tsNuevo.Visible = (tblBotones.Rows[0]["intNuevo"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intNuevo"]);
            frm.tsEditar.Visible = (tblBotones.Rows[0]["intEditar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEditar"]);
            frm.tsVer.Visible = (tblBotones.Rows[0]["intVer"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intVer"]);
            frm.tsBuscar.Visible = (tblBotones.Rows[0]["intBuscar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intBuscar"]);
            frm.tsActualizar.Visible = (tblBotones.Rows[0]["intActualizar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intActualizar"]);
            frm.tsEliminar.Visible = (tblBotones.Rows[0]["intEliminar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEliminar"]);
            frm.tsImprimir.Visible = (tblBotones.Rows[0]["intImp"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intImp"]);
            frm.tsExportar.Visible = (tblBotones.Rows[0]["intExportar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intExportar"]);

            frm.Show();
        }

        private void asignarAEmpresaToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<MotivoEmpresa>().Count() == 1)
                Application.OpenForms.OfType<MotivoEmpresa>().First().Close();

            MotivoEmpresa frm = new MotivoEmpresa();
            frm.MdiParent = this;
            frm.idEmpresa = intIdEmpresa;
            frm.idUsuario = idUsuario;
            frm.nombreEmpresa = strNoEmpresa;
            frm.Show();
        }

        private void asignarAUsuarioToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<MotivoUsuario>().Count() == 1)
                Application.OpenForms.OfType<MotivoUsuario>().First().Close();

            MotivoUsuario frm = new MotivoUsuario();
            frm.MdiParent = this;
            frm.idEmpresa = intIdEmpresa;
            frm.idUsuario = idUsuario;
            frm.nombreEmpresa = strNoEmpresa;
            frm.Show();
        }

        private void registrarPlacaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<Placa_Listado>().Count() == 1)
                Application.OpenForms.OfType<Placa_Listado>().First().Close();

            Placa_Listado frm = new Placa_Listado();
            frm.MdiParent = this;
            frm.idEmpresa = intIdEmpresa;
            frm.idUsuario = idUsuario;
            frm.nombreEmpresa = strNoEmpresa;
            frm.Show();
        }

        private void creacionToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            DataTable tblBotones = new DataTable();
            tblBotones = botones(idUsuario, centroDeCostosToolStripMenuItem.Tag.ToString(), intIdEmpresa);

            if (Application.OpenForms.OfType<CentroCosto_Listado>().Count() == 1)
                Application.OpenForms.OfType<CentroCosto_Listado>().First().Close();

            CentroCosto_Listado frm = new CentroCosto_Listado();
            frm.MdiParent = this;
            frm.idUsuario = idUsuario;
            frm.idEmpresa = intIdEmpresa;
            frm.tsNuevo.Visible = (tblBotones.Rows[0]["intNuevo"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intNuevo"]);
            frm.tsEditar.Visible = (tblBotones.Rows[0]["intEditar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEditar"]);
            frm.tsVer.Visible = (tblBotones.Rows[0]["intVer"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intVer"]);
            frm.tsBuscar.Visible = (tblBotones.Rows[0]["intBuscar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intBuscar"]);
            frm.tsActualizar.Visible = (tblBotones.Rows[0]["intActualizar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intActualizar"]);
            frm.tsEliminar.Visible = (tblBotones.Rows[0]["intEliminar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEliminar"]);
            frm.tsImprimir.Visible = (tblBotones.Rows[0]["intImp"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intImp"]);
            frm.tsExportar.Visible = (tblBotones.Rows[0]["intExportar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intExportar"]);

            frm.Show();
        }

        private void asignarCentroDeCostoAEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<CenCosEmpresa>().Count() == 1)
                Application.OpenForms.OfType<CenCosEmpresa>().First().Close();

            CenCosEmpresa frm = new CenCosEmpresa();
            frm.MdiParent = this;
            frm.idEmpresa = intIdEmpresa;
            frm.idUsuario = idUsuario;
            frm.nombreEmpresa = strNoEmpresa;
            frm.Show();
        }

        private void asignarCentroDeCostoAUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<CenCosUsuario>().Count() == 1)
                Application.OpenForms.OfType<CenCosUsuario>().First().Close();

            CenCosUsuario frm = new CenCosUsuario();
            frm.MdiParent = this;
            frm.idUsuario = idUsuario;
            frm.idEmpresa = intIdEmpresa;
            frm.nombreEmpresa = strNoEmpresa;
            frm.Show();
        }

        private void usuarioApruebaReqPorNumeadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuAprReq frm = new UsuAprReq();
            frm.MdiParent = this;
            frm.idUsuario = idUsuario;
            frm.idEmpresa = intIdEmpresa;
            frm.nombreEmpresa = strNoEmpresa;
            frm.Show();
        }

        private void seriesPorOrdenToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<SeriesPorOrden>().Count() == 1)
                Application.OpenForms.OfType<SeriesPorOrden>().First().Close();

            SeriesPorOrden frm = new SeriesPorOrden();
            frm.MdiParent = this;
            frm.idUsuario = idUsuario;
            frm.idEmpresa = intIdEmpresa;
            frm.nombreEmpresa = strNoEmpresa;
            //frm.tsNuevo.Visible = true;// (tblBotones.Rows[0]["intNuevo"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intNuevo"]);
            //frm.tsEditar.Visible = true;//(tblBotones.Rows[0]["intEditar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEditar"]);
            //frm.tsVer.Visible = true;//(tblBotones.Rows[0]["intVer"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intVer"]);
            //frm.tsBuscar.Visible = true;//(tblBotones.Rows[0]["intBuscar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intBuscar"]);
            //frm.tsActualizar.Visible = true;//(tblBotones.Rows[0]["intActualizar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intActualizar"]);
            //frm.tsEliminar.Visible = true;//(tblBotones.Rows[0]["intEliminar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intEliminar"]);
            //frm.tsImprimir.Visible = true;//(tblBotones.Rows[0]["intImp"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intImp"]);
            //frm.tsExportar.Visible = true;//(tblBotones.Rows[0]["intExportar"] is DBNull) ? false : Convert.ToBoolean(tblBotones.Rows[0]["intExportar"]);

            frm.Show();
        }
    }
}
