using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Configuracion
{
    public class SqlServer
    {
        private System.Data.SqlClient.SqlConnection oConnection;
        private System.Data.SqlClient.SqlTransaction oTransaction;

        private System.Data.IDbConnection Conexion
        {
            get
            {
                if (oConnection == null)
                {
                    oConnection = new System.Data.SqlClient.SqlConnection();
                }
                return oConnection;
            }
        }
        public string ConnectionString
        {
            get
            {
                return Conexion.ConnectionString;
            }
            set
            {
                CerrarConexion();
                Conexion.ConnectionString = value;
            }
        }
        private void AbrirConexion()
        {
            try
            {
                CerrarConexion();
                if (Conexion.State == ConnectionState.Closed)
                {
                    Conexion.Open();
                }
            }
            catch (System.Data.SqlClient.SqlException Ex)
            {
                throw Ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CerrarConexion()
        {
            try
            {
                if ((oTransaction == null) && (Conexion.State == ConnectionState.Open))
                {
                    Conexion.Close();
                }
            }
            catch (System.Data.SqlClient.SqlException Ex)
            {
                throw Ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ConexionCorrecta(string pStrCadenaConexion)
        {
            bool bDev = false;
            try
            {
                CerrarConexion();
                Conexion.ConnectionString = pStrCadenaConexion;
                AbrirConexion();
                bDev = true;
            }
            catch (System.Data.SqlClient.SqlException Ex)
            {
                throw Ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CerrarConexion();
            }
            return bDev;
        }
        public System.Data.DataTable Retornar_DataTable(string pConexion, string pQuery)
        {
            System.Data.DataTable dt = new DataTable();
            System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection(pConexion);
            System.Data.SqlClient.SqlCommand cm = new System.Data.SqlClient.SqlCommand(pQuery, cn);
            cn.Open();
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cm);
            System.Data.DataSet ds = new DataSet();
            da.Fill(ds);
            cn.Close();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
                else
                {
                    dt = null;
                }
            }
            else
            {
                dt = null;
            }
            return dt;
        }
    }
}
