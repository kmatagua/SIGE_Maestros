using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace Presentacion.Reportes
{
    public partial class rptMantenimiento : Form
    {
        public string nombreRpt;
        public int idEmpresa;
        public int idUsuario;
        public int idFamilia;
        
           //esta variable asigna el parametro al reporte
        ParameterFields Parametros = new ParameterFields();
        //esta variable indica el nombre del parametro que se encuentra en el proc almacenado
        ParameterField PrimerParametro = new ParameterField();
        ParameterDiscreteValue myDiscreteValue = new ParameterDiscreteValue();

        ParameterField SegundoParametro = new ParameterField();
        ParameterDiscreteValue myDiscreteValue2 = new ParameterDiscreteValue();

        ParameterField TercerParametro = new ParameterField();
        ParameterDiscreteValue myDiscreteValue3 = new ParameterDiscreteValue();

        //esta variable toma el valor del parametro
      

        public rptMantenimiento()
        {
            InitializeComponent();
        }


        private void rptMantenimiento_Load(object sender, EventArgs e)
        {

            
            //
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;
            //Table CrTable;

            Clases.InicialCls.LeerXml();
            crConnectionInfo.ServerName = Configuracion.Sistema.ServidorSQL;
            crConnectionInfo.DatabaseName = Configuracion.Sistema.BaseDatosSQL;
            crConnectionInfo.UserID = Configuracion.Sistema.UsuarioSQL;
            crConnectionInfo.Password = Configuracion.Sistema.PasswordSQL;

            

            if (nombreRpt == "ALMACEN")
            {
                crAlmacen rptDatos = new crAlmacen();
                CrTables = rptDatos.Database.Tables;
                foreach (Table CrTable in CrTables)
                {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }

                //**************************
                PrimerParametro.ParameterValueType = ParameterValueKind.NumberParameter;
                PrimerParametro.ParameterFieldName = "@intIdEmp";
                myDiscreteValue.Value = Convert.ToInt32(idEmpresa);
                PrimerParametro.CurrentValues.Add(myDiscreteValue);
                Parametros.Add(PrimerParametro);
                crystalReportViewer1.ParameterFieldInfo = Parametros;
                //****************************
                crystalReportViewer1.ReportSource = rptDatos;
            }
            else if (nombreRpt == "ARTICULO")
            {
                crArticulo rptDatos = new crArticulo();
                CrTables = rptDatos.Database.Tables;
                foreach (Table CrTable in CrTables)
                {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }

                //**************************
                PrimerParametro.ParameterValueType = ParameterValueKind.NumberParameter;
                PrimerParametro.ParameterFieldName = "@intIdEmp";
                myDiscreteValue.Value = Convert.ToInt32(idEmpresa);
                PrimerParametro.CurrentValues.Add(myDiscreteValue);
                Parametros.Add(PrimerParametro);

                SegundoParametro.ParameterValueType = ParameterValueKind.NumberParameter;
                SegundoParametro.ParameterFieldName = "@intIdUsu";
                myDiscreteValue2.Value = Convert.ToInt32(idUsuario);
                SegundoParametro.CurrentValues.Add(myDiscreteValue2);
                Parametros.Add(SegundoParametro);

                TercerParametro.ParameterValueType = ParameterValueKind.NumberParameter;
                TercerParametro.ParameterFieldName = "@intIdFamilia";
                myDiscreteValue3.Value = Convert.ToInt32(idFamilia);
                TercerParametro.CurrentValues.Add(myDiscreteValue3);
                Parametros.Add(TercerParametro);

                crystalReportViewer1.ParameterFieldInfo = Parametros;
                //****************************

                crystalReportViewer1.ReportSource = rptDatos;
            }
            else if (nombreRpt == "EMPRESA")
            {
                crEmpresa rptDatos = new crEmpresa();
                CrTables = rptDatos.Database.Tables;
                foreach (Table CrTable in CrTables)
                {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }

                //**************************
                PrimerParametro.ParameterValueType = ParameterValueKind.NumberParameter;
                PrimerParametro.ParameterFieldName = "@intIdUsu";
                myDiscreteValue.Value = Convert.ToInt32(idUsuario);
                PrimerParametro.CurrentValues.Add(myDiscreteValue);
                Parametros.Add(PrimerParametro);
                crystalReportViewer1.ParameterFieldInfo = Parametros;
                //****************************

                crystalReportViewer1.ReportSource = rptDatos;
            }
            else if (nombreRpt == "CENTROCOSTO")
            {
                crCentroCosto rptDatos = new crCentroCosto();
                CrTables = rptDatos.Database.Tables;
                foreach (Table CrTable in CrTables)
                {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }

                //**************************
                //PrimerParametro.ParameterValueType = ParameterValueKind.NumberParameter;
                //PrimerParametro.ParameterFieldName = "@intIdUsu";
                //myDiscreteValue.Value = Convert.ToInt32(idUsuario);
                //PrimerParametro.CurrentValues.Add(myDiscreteValue);
                //Parametros.Add(PrimerParametro);
                //crystalReportViewer1.ParameterFieldInfo = Parametros;
                //****************************

                crystalReportViewer1.ReportSource = rptDatos;
            }
            else if (nombreRpt == "CLASIFICACION")
            {
                crClasificacion rptDatos = new crClasificacion();
                CrTables = rptDatos.Database.Tables;
                foreach (Table CrTable in CrTables)
                {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }

                //**************************
                //PrimerParametro.ParameterValueType = ParameterValueKind.NumberParameter;
                //PrimerParametro.ParameterFieldName = "@intIdUsu";
                //myDiscreteValue.Value = Convert.ToInt32(idUsuario);
                //PrimerParametro.CurrentValues.Add(myDiscreteValue);
                //Parametros.Add(PrimerParametro);
                //crystalReportViewer1.ParameterFieldInfo = Parametros;
                //****************************

                crystalReportViewer1.ReportSource = rptDatos;
            }
            else if (nombreRpt == "MOTIVO")
            {
                crClasificacion rptDatos = new crClasificacion();
                CrTables = rptDatos.Database.Tables;
                foreach (Table CrTable in CrTables)
                {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }

                //**************************
                //PrimerParametro.ParameterValueType = ParameterValueKind.NumberParameter;
                //PrimerParametro.ParameterFieldName = "@intIdUsu";
                //myDiscreteValue.Value = Convert.ToInt32(idUsuario);
                //PrimerParametro.CurrentValues.Add(myDiscreteValue);
                //Parametros.Add(PrimerParametro);
                //crystalReportViewer1.ParameterFieldInfo = Parametros;
                //****************************

                crystalReportViewer1.ReportSource = rptDatos;
            }
            else if (nombreRpt == "CONDICION")
            {
                crCondicion rptDatos = new crCondicion();
                CrTables = rptDatos.Database.Tables;
                foreach (Table CrTable in CrTables)
                {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }

                //**************************
                //PrimerParametro.ParameterValueType = ParameterValueKind.NumberParameter;
                //PrimerParametro.ParameterFieldName = "@intIdUsu";
                //myDiscreteValue.Value = Convert.ToInt32(idUsuario);
                //PrimerParametro.CurrentValues.Add(myDiscreteValue);
                //Parametros.Add(PrimerParametro);
                //crystalReportViewer1.ParameterFieldInfo = Parametros;
                //****************************

                crystalReportViewer1.ReportSource = rptDatos;
            }
            else if (nombreRpt == "EMPLEADO")
            {
                crEmpleado rptDatos = new crEmpleado();
                CrTables = rptDatos.Database.Tables;
                foreach (Table CrTable in CrTables)
                {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }

                //**************************
                //PrimerParametro.ParameterValueType = ParameterValueKind.NumberParameter;
                //PrimerParametro.ParameterFieldName = "@intIdUsu";
                //myDiscreteValue.Value = Convert.ToInt32(idUsuario);
                //PrimerParametro.CurrentValues.Add(myDiscreteValue);
                //Parametros.Add(PrimerParametro);
                //crystalReportViewer1.ParameterFieldInfo = Parametros;
                //****************************

                crystalReportViewer1.ReportSource = rptDatos;
            }
            else if (nombreRpt == "FAMILIA")
            {
                crFamilia rptDatos = new crFamilia();
                CrTables = rptDatos.Database.Tables;
                foreach (Table CrTable in CrTables)
                {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }

                //**************************
                //PrimerParametro.ParameterValueType = ParameterValueKind.NumberParameter;
                //PrimerParametro.ParameterFieldName = "@intIdUsu";
                //myDiscreteValue.Value = Convert.ToInt32(idUsuario);
                //PrimerParametro.CurrentValues.Add(myDiscreteValue);
                //Parametros.Add(PrimerParametro);
                //crystalReportViewer1.ParameterFieldInfo = Parametros;
                //****************************

                crystalReportViewer1.ReportSource = rptDatos;
            }
            else if (nombreRpt == "MARCA")
            {
                crMarca rptDatos = new crMarca();
                CrTables = rptDatos.Database.Tables;
                foreach (Table CrTable in CrTables)
                {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }

                //**************************
                //PrimerParametro.ParameterValueType = ParameterValueKind.NumberParameter;
                //PrimerParametro.ParameterFieldName = "@intIdUsu";
                //myDiscreteValue.Value = Convert.ToInt32(idUsuario);
                //PrimerParametro.CurrentValues.Add(myDiscreteValue);
                //Parametros.Add(PrimerParametro);
                //crystalReportViewer1.ParameterFieldInfo = Parametros;
                //****************************

                crystalReportViewer1.ReportSource = rptDatos;
            }
            else if (nombreRpt == "MENU")
            {
                crMenu rptDatos = new crMenu();
                CrTables = rptDatos.Database.Tables;
                foreach (Table CrTable in CrTables)
                {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }

                //**************************
                //PrimerParametro.ParameterValueType = ParameterValueKind.NumberParameter;
                //PrimerParametro.ParameterFieldName = "@intIdUsu";
                //myDiscreteValue.Value = Convert.ToInt32(idUsuario);
                //PrimerParametro.CurrentValues.Add(myDiscreteValue);
                //Parametros.Add(PrimerParametro);
                //crystalReportViewer1.ParameterFieldInfo = Parametros;
                //****************************

                crystalReportViewer1.ReportSource = rptDatos;
            }
            else if (nombreRpt == "OPERACION")
            {
                crOperacion rptDatos = new crOperacion();
                CrTables = rptDatos.Database.Tables;
                foreach (Table CrTable in CrTables)
                {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }

                //**************************
                //PrimerParametro.ParameterValueType = ParameterValueKind.NumberParameter;
                //PrimerParametro.ParameterFieldName = "@intIdUsu";
                //myDiscreteValue.Value = Convert.ToInt32(idUsuario);
                //PrimerParametro.CurrentValues.Add(myDiscreteValue);
                //Parametros.Add(PrimerParametro);
                //crystalReportViewer1.ParameterFieldInfo = Parametros;
                //****************************

                crystalReportViewer1.ReportSource = rptDatos;
            }
            else if (nombreRpt == "SEDE")
            {
                crSede rptDatos = new crSede();
                CrTables = rptDatos.Database.Tables;
                foreach (Table CrTable in CrTables)
                {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }

                //**************************
                PrimerParametro.ParameterValueType = ParameterValueKind.NumberParameter;
                PrimerParametro.ParameterFieldName = "@intIdEmp";
                myDiscreteValue.Value = Convert.ToInt32(idEmpresa);
                PrimerParametro.CurrentValues.Add(myDiscreteValue);
                Parametros.Add(PrimerParametro);
                crystalReportViewer1.ParameterFieldInfo = Parametros;
                //****************************

                crystalReportViewer1.ReportSource = rptDatos;
            }
            else if (nombreRpt == "SUBFAMILIA")
            {
                crSubFamilia rptDatos = new crSubFamilia();
                CrTables = rptDatos.Database.Tables;
                foreach (Table CrTable in CrTables)
                {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }

                //**************************
                //PrimerParametro.ParameterValueType = ParameterValueKind.NumberParameter;
                //PrimerParametro.ParameterFieldName = "@intIdUsu";
                //myDiscreteValue.Value = Convert.ToInt32(idUsuario);
                //PrimerParametro.CurrentValues.Add(myDiscreteValue);
                //Parametros.Add(PrimerParametro);
                //crystalReportViewer1.ParameterFieldInfo = Parametros;
                //****************************

                crystalReportViewer1.ReportSource = rptDatos;
            }
            else if (nombreRpt == "UBICACION")
            {
                crUbicacion rptDatos = new crUbicacion();
                CrTables = rptDatos.Database.Tables;
                foreach (Table CrTable in CrTables)
                {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }

                //**************************
                //PrimerParametro.ParameterValueType = ParameterValueKind.NumberParameter;
                //PrimerParametro.ParameterFieldName = "@intIdUsu";
                //myDiscreteValue.Value = Convert.ToInt32(idUsuario);
                //PrimerParametro.CurrentValues.Add(myDiscreteValue);
                //Parametros.Add(PrimerParametro);
                //crystalReportViewer1.ParameterFieldInfo = Parametros;
                //****************************

                crystalReportViewer1.ReportSource = rptDatos;
            }
            else if (nombreRpt == "UNIDAD")
            {
                crUnidad rptDatos = new crUnidad();
                CrTables = rptDatos.Database.Tables;
                foreach (Table CrTable in CrTables)
                {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }

                //**************************
                //PrimerParametro.ParameterValueType = ParameterValueKind.NumberParameter;
                //PrimerParametro.ParameterFieldName = "@intIdUsu";
                //myDiscreteValue.Value = Convert.ToInt32(idUsuario);
                //PrimerParametro.CurrentValues.Add(myDiscreteValue);
                //Parametros.Add(PrimerParametro);
                //crystalReportViewer1.ParameterFieldInfo = Parametros;
                //****************************

                crystalReportViewer1.ReportSource = rptDatos;
            }
            else if (nombreRpt == "USUARIO")
            {
                crUsuario rptDatos = new crUsuario();
                CrTables = rptDatos.Database.Tables;
                foreach (Table CrTable in CrTables)
                {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }

                //**************************
                PrimerParametro.ParameterValueType = ParameterValueKind.NumberParameter;
                PrimerParametro.ParameterFieldName = "@intIdUsu";
                myDiscreteValue.Value = Convert.ToInt32(idUsuario);
                PrimerParametro.CurrentValues.Add(myDiscreteValue);
                Parametros.Add(PrimerParametro);
                crystalReportViewer1.ParameterFieldInfo = Parametros;
                //****************************

                crystalReportViewer1.ReportSource = rptDatos;
            }

            crystalReportViewer1.Refresh();
        
        }
    }
}
