using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Presentacion.Clases
{
    public class InicialCls
    {
        public static void CrearXml()
        {
            string cc = Application.StartupPath.Trim() + "\\" + Configuracion.Sistema.ArchivoCfgXml;
            string Rpt = Application.StartupPath.Trim() + "\\";
            System.Data.DataSet ds = new System.Data.DataSet();
            System.Data.DataTable dt = new System.Data.DataTable();
            System.Data.DataRow dr;
            try
            {
                dt.Columns.Add("Impresora", Type.GetType("System.String"));
                dt.Columns.Add("RutaFormatos", Type.GetType("System.String"));
                dt.Columns.Add("CadenaConexion", Type.GetType("System.String"));
                dt.Columns.Add("ServidorSQL", Type.GetType("System.String"));
                dt.Columns.Add("BaseDatosSQL", Type.GetType("System.String"));
                dt.Columns.Add("UsuarioSQL", Type.GetType("System.String"));
                dt.Columns.Add("PasswordSQL", Type.GetType("System.String"));
                dt.Columns.Add("intIdActivo", Type.GetType("System.String"));
                dt.Columns.Add("GrillaColor", Type.GetType("System.String"));
                dr = dt.NewRow();
                dr["Impresora"] = string.Empty;
                dr["RutaFormatos"] = string.Empty;
                dr["CadenaConexion"] = "server=CJ2008R2X01; database=BDSIGE; user=SOPORTE; password=SOPORTE";
                dr["ServidorSQL"] = "CJ2008R2X01";
                dr["BaseDatosSQL"] = "BDSIGE";
                dr["UsuarioSQL"] = "SOPORTE";
                dr["PasswordSQL"] = "SOPORTE";
                dr["intIdActivo"] = "7";
                dr["GrillaColor"] = "#F2FFF2";
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);
                ds.WriteXml(cc);
            }
            catch
            {
                MessageBox.Show("No se pudo Crear el XML de Configuración", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                if (dt != null)
                {
                    dt.Dispose(); dt = null;
                }
                if (ds != null)
                {
                    ds.Dispose(); ds = null;
                }
            }
        }

        public static void LeerXml()
        {
            string cc = Application.StartupPath.Trim() + "\\" + Configuracion.Sistema.ArchivoCfgXml;
            System.Data.DataSet ds = new System.Data.DataSet();
            System.Data.DataTable dt = new System.Data.DataTable();
            try
            {
                ds.ReadXml(cc);
                dt = ds.Tables[0];
                Configuracion.Sistema.Impresora = dt.Rows[0]["Impresora"].ToString();
                Configuracion.Sistema.RutaFormatos = dt.Rows[0]["RutaFormatos"].ToString();
                Configuracion.Sistema.CadenaConexion = dt.Rows[0]["CadenaConexion"].ToString();
                Configuracion.Sistema.ServidorSQL = dt.Rows[0]["ServidorSQL"].ToString();
                Configuracion.Sistema.BaseDatosSQL = dt.Rows[0]["BaseDatosSQL"].ToString();
                Configuracion.Sistema.UsuarioSQL = dt.Rows[0]["UsuarioSQL"].ToString();
                Configuracion.Sistema.PasswordSQL = dt.Rows[0]["PasswordSQL"].ToString();
                Configuracion.Sistema.intIdActivo = dt.Rows[0]["intIdActivo"].ToString();
                Configuracion.Sistema.GrillaColor = dt.Rows[0]["GrillaColor"].ToString();
            }
            catch
            {
                MessageBox.Show("No se pudo Leer el XML de Configuración", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                if (dt != null)
                {
                    dt.Dispose(); dt = null;
                }
                if (ds != null)
                {
                    ds.Dispose(); ds = null;
                }
            }
        }

        public static void ActualizarXml()
        {
            string cc = Application.StartupPath.Trim() + "\\" + Configuracion.Sistema.ArchivoCfgXml;
            System.Data.DataSet ds = new System.Data.DataSet();
            try
            {
                ds.ReadXml(cc);
                ds.Tables[0].Rows[0]["Impresora"] = Configuracion.Sistema.Impresora;
                ds.Tables[0].Rows[0]["RutaFormatos"] = Configuracion.Sistema.RutaFormatos;
                ds.Tables[0].Rows[0]["CadenaConexion"] = Configuracion.Sistema.CadenaConexion;
                ds.Tables[0].Rows[0]["ServidorSQL"] = Configuracion.Sistema.ServidorSQL;
                ds.Tables[0].Rows[0]["BaseDatosSQL"] = Configuracion.Sistema.BaseDatosSQL;
                ds.Tables[0].Rows[0]["UsuarioSQL"] = Configuracion.Sistema.UsuarioSQL;
                ds.Tables[0].Rows[0]["PasswordSQL"] = Configuracion.Sistema.PasswordSQL;
                ds.Tables[0].Rows[0]["intIdActivo"] = Configuracion.Sistema.intIdActivo;
                ds.Tables[0].Rows[0]["GrillaColor"] = Configuracion.Sistema.GrillaColor;
                bool _boo;
                if (System.IO.File.Exists(cc) == true)
                {
                    try
                    {
                        System.IO.File.Delete(cc); _boo = true;
                    }
                    catch
                    {
                        _boo = false;
                    }
                }
                else
                {
                    _boo = true;
                }
                if (_boo == true)
                {
                    ds.WriteXml(cc);
                }
            }
            catch
            {
                MessageBox.Show("No se pudo Leer el XML de Configuración", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                if (ds != null)
                {
                    ds.Dispose(); ds = null;
                }
            }
        }
    }
}
