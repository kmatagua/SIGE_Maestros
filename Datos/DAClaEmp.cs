using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    public class DAClaEmp
    {
        private string _pStrConString = string.Empty;

        public DAClaEmp(string p_pStrConString)
        {
            _pStrConString = p_pStrConString;
        }

        public DataTable ListaClaEmp(ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_CLAEMP_Q01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //da.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);
                da.Fill(tbl);
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
            return tbl;
        }

        public DataTable ListaClaEmpAcc(int intIdEmp, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_CLAEMP_EMP_Q01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdEmp", intIdEmp);
                da.Fill(tbl);
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
            return tbl;
        }

        public DataTable ListaFiltrar(string filtro, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_CLAEMP_Q03", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@filtro", filtro);
                da.Fill(tbl);
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
            return tbl;
        }

        public DataTable BuscarClaEmp(int intIdClaEmp, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable rowTbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_CLAEMP_Q02", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdClaEmp", intIdClaEmp);
                da.Fill(rowTbl);
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
            return rowTbl;
        }

        public void InsertarClaEmp(ENClaEmp objEnClaEmp, ref string mensaje, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_CLAEMP_I01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@strCoClaEmp", objEnClaEmp.strCoClaEmp);
                da.SelectCommand.Parameters.AddWithValue("@strNoClaEmp", objEnClaEmp.strNoClaEmp);
                da.SelectCommand.Parameters.AddWithValue("@strDisplay", objEnClaEmp.strDisplay);
                da.SelectCommand.Parameters.AddWithValue("@intEstado", objEnClaEmp.intEstado);
                da.SelectCommand.Parameters.AddWithValue("@intIdUsuCr", objEnClaEmp.intIdUsuCr);
                da.SelectCommand.Parameters.Add("@strMensaje", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                da.SelectCommand.ExecuteNonQuery();
                mensaje = da.SelectCommand.Parameters["@strMensaje"].Value.ToString();
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
        }

        public void EditarClaEmp(ENClaEmp objEnClaEmp, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_CLAEMP_U01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdClaEmp", objEnClaEmp.intIdClaEmp);
                da.SelectCommand.Parameters.AddWithValue("@strCoClaEmp", objEnClaEmp.strCoClaEmp);
                da.SelectCommand.Parameters.AddWithValue("@strNoClaEmp", objEnClaEmp.strNoClaEmp);
                da.SelectCommand.Parameters.AddWithValue("@strDisplay", objEnClaEmp.strDisplay);
                da.SelectCommand.Parameters.AddWithValue("@intEstado", objEnClaEmp.intEstado);
                da.SelectCommand.Parameters.AddWithValue("@intIdUsuMf", objEnClaEmp.intIdUsuMf);

                da.SelectCommand.ExecuteNonQuery();
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
        }

        public void EliminarClaEmp(int idSeleccion, int idUsuario, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_CLAEMP_UD01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdClaEmp", idSeleccion);
                da.SelectCommand.Parameters.AddWithValue("@intIdUsuMf", idUsuario);
                da.SelectCommand.ExecuteNonQuery();
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
        }

        public DataTable ComboClaEmp(ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_CLAEMP_Q04", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //da.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);
                da.Fill(tbl);
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
            return tbl;
        }

        public void InsertarEmpleadoClaEmp(int idClaEmp, DataTable tabla, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter daD = new SqlDataAdapter("SP_EMP_CLAEMP_D01", cn);
                daD.SelectCommand.CommandType = CommandType.StoredProcedure;
                daD.SelectCommand.Parameters.AddWithValue("@intIdClaEmp", idClaEmp);
                daD.SelectCommand.ExecuteNonQuery();
                // ----  id
                SqlDataAdapter da1 = new SqlDataAdapter("SP_EMP_CLAEMP_I01", cn);
                da1.SelectCommand.CommandType = CommandType.StoredProcedure;
                foreach (DataRow row in tabla.Rows)
                {
                    da1.SelectCommand.Parameters.Clear();
                    //    id
                    da1.SelectCommand.Parameters.AddWithValue("@intIdClaEmp", idClaEmp);
                    da1.SelectCommand.Parameters.AddWithValue("@intIdEmp", Convert.ToInt32(row[0].ToString()));

                    da1.SelectCommand.ExecuteNonQuery();

                }

                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
        }
    }
}
