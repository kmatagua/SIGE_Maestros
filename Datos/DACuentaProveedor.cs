using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    public class DACuentaProveedor
    {
        private string _pStrConString = string.Empty;

        public DACuentaProveedor(string p_pStrConString)
        {
            _pStrConString = p_pStrConString;
        }

        public DataTable ListaCuentaProveedor(int idEmpresa, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_CUENTAPROVEEDOR_Q01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);
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

        public DataTable ListaComboCuentaProveedor(int intIdUsu, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_CuentaProveedor_Q05", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idUsuario", intIdUsu);
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

        public DataTable ListaEmpAcc(int intIdUsu, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_USU_EMP_Q01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdUsu", intIdUsu);
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
                SqlDataAdapter da = new SqlDataAdapter("SP_CuentaProveedor_Q03", cn);
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

        public DataTable BuscarCuentaProveedor(int intIdCuenta, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable rowTbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_CUENTAPROVEEDOR_Q02", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdCuenta", intIdCuenta);
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

        public void InsertarCuentaProveedor(ENCuentaProveedor obj, ref string mensaje, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_CUENTAPROVEEDOR_I01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idProveedor", obj.intIdProveedor);
                da.SelectCommand.Parameters.AddWithValue("@idBanco", obj.intIdBanco);
                da.SelectCommand.Parameters.AddWithValue("@idMoneda", obj.intIdMoneda);
                da.SelectCommand.Parameters.AddWithValue("@strNumero", obj.strNroCuenta);

                da.SelectCommand.Parameters.AddWithValue("@intEstado", obj.intEstado);

                da.SelectCommand.Parameters.AddWithValue("@intIdUsuCr", obj.intIdUsuCr);
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

        public void InsertarUniCuentaProveedor(int idCuentaProveedor, DataTable tabla, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter daD = new SqlDataAdapter("SP_UNI_EMP_D01", cn);
                daD.SelectCommand.CommandType = CommandType.StoredProcedure;
                daD.SelectCommand.Parameters.AddWithValue("@intIdEmp", idCuentaProveedor);
                daD.SelectCommand.ExecuteNonQuery();
                // ----  id
                if (tabla.Rows.Count > 0)
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("SP_UNI_EMP_I01", cn);
                    da1.SelectCommand.CommandType = CommandType.StoredProcedure;
                    foreach (DataRow row in tabla.Rows)
                    {
                        da1.SelectCommand.Parameters.Clear();
                        //    id
                        da1.SelectCommand.Parameters.AddWithValue("@intIdEmp", idCuentaProveedor);
                        da1.SelectCommand.Parameters.AddWithValue("@intIdUni", Convert.ToInt32(row[0].ToString()));

                        da1.SelectCommand.ExecuteNonQuery();
                       
                    }
                }
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
        }

        public void InsertarFamiliaCuentaProveedor(int idCuentaProveedor, DataTable tabla, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter daD = new SqlDataAdapter("SP_FAMILIA_EMP_D01", cn);
                daD.SelectCommand.CommandType = CommandType.StoredProcedure;
                daD.SelectCommand.Parameters.AddWithValue("@intIdEmp", idCuentaProveedor);
                daD.SelectCommand.ExecuteNonQuery();
                // ----  id
                if (tabla.Rows.Count > 0)
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("SP_FAMILIA_EMP_I01", cn);
                    da1.SelectCommand.CommandType = CommandType.StoredProcedure;
                    foreach (DataRow row in tabla.Rows)
                    {
                        da1.SelectCommand.Parameters.Clear();
                        //    id
                        da1.SelectCommand.Parameters.AddWithValue("@intIdEmp", idCuentaProveedor);
                        da1.SelectCommand.Parameters.AddWithValue("@intIdFamilia", Convert.ToInt32(row[0].ToString()));

                        da1.SelectCommand.ExecuteNonQuery();
                        
                    }
                }
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
        }

        public void InsertarMarcaCuentaProveedor(int idCuentaProveedor, DataTable tabla, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter daD = new SqlDataAdapter("SP_MARCA_EMP_D01", cn);
                daD.SelectCommand.CommandType = CommandType.StoredProcedure;
                daD.SelectCommand.Parameters.AddWithValue("@intIdEmp", idCuentaProveedor);
                daD.SelectCommand.ExecuteNonQuery();
                // ----  id
                if(tabla.Rows.Count > 0)
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("SP_MARCA_EMP_I01", cn);
                    da1.SelectCommand.CommandType = CommandType.StoredProcedure;
                    foreach (DataRow row in tabla.Rows)
                    {
                        da1.SelectCommand.Parameters.Clear();
                        //    id
                        da1.SelectCommand.Parameters.AddWithValue("@intIdEmp", idCuentaProveedor);
                        da1.SelectCommand.Parameters.AddWithValue("@intIdMarca", Convert.ToInt32(row[0].ToString()));

                        da1.SelectCommand.ExecuteNonQuery();
                        
                    }
                }
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
        }

        public void InsertarOpeLogCuentaProveedor(int idCuentaProveedor, DataTable tabla, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter daD = new SqlDataAdapter("SP_OPELOG_EMP_D01", cn);
                daD.SelectCommand.CommandType = CommandType.StoredProcedure;
                daD.SelectCommand.Parameters.AddWithValue("@intIdEmp", idCuentaProveedor);
                daD.SelectCommand.ExecuteNonQuery();
                // ----  id
                if (tabla.Rows.Count > 0)
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("SP_OPELOG_EMP_I01", cn);
                    da1.SelectCommand.CommandType = CommandType.StoredProcedure;
                    foreach (DataRow row in tabla.Rows)
                    {
                        da1.SelectCommand.Parameters.Clear();
                        //    id
                        da1.SelectCommand.Parameters.AddWithValue("@intIdEmp", idCuentaProveedor);
                        da1.SelectCommand.Parameters.AddWithValue("@intIdOpeLog", Convert.ToInt32(row[0].ToString()));

                        da1.SelectCommand.ExecuteNonQuery();

                    }
                }
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
        }

        public void InsertarUniNegCuentaProveedor(int idCuentaProveedor, DataTable tabla, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter daD = new SqlDataAdapter("SP_UNINEG_EMP_D01", cn);
                daD.SelectCommand.CommandType = CommandType.StoredProcedure;
                daD.SelectCommand.Parameters.AddWithValue("@intIdEmp", idCuentaProveedor);
                daD.SelectCommand.ExecuteNonQuery();
                // ----  id
                if (tabla.Rows.Count > 0)
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("SP_UNINEG_EMP_I01", cn);
                    da1.SelectCommand.CommandType = CommandType.StoredProcedure;
                    foreach (DataRow row in tabla.Rows)
                    {
                        da1.SelectCommand.Parameters.Clear();
                        //    id
                        da1.SelectCommand.Parameters.AddWithValue("@intIdEmp", idCuentaProveedor);
                        da1.SelectCommand.Parameters.AddWithValue("@intIdUniNeg", Convert.ToInt32(row[0].ToString()));

                        da1.SelectCommand.ExecuteNonQuery();

                    }
                }
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
        }

        public void InsertarTipoDocCuentaProveedor(int idCuentaProveedor, DataTable tabla, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter daD = new SqlDataAdapter("SP_TIPODOC_EMP_D01", cn);
                daD.SelectCommand.CommandType = CommandType.StoredProcedure;
                daD.SelectCommand.Parameters.AddWithValue("@intIdEmp", idCuentaProveedor);
                daD.SelectCommand.ExecuteNonQuery();
                // ----  id
                if (tabla.Rows.Count > 0)
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("SP_TIPODOC_EMP_I01", cn);
                    da1.SelectCommand.CommandType = CommandType.StoredProcedure;
                    foreach (DataRow row in tabla.Rows)
                    {
                        da1.SelectCommand.Parameters.Clear();
                        //    id
                        da1.SelectCommand.Parameters.AddWithValue("@intIdEmp", idCuentaProveedor);
                        da1.SelectCommand.Parameters.AddWithValue("@intIdTipDoc", Convert.ToInt32(row[0].ToString()));

                        da1.SelectCommand.ExecuteNonQuery();

                    }
                }
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
        }

        public void InsertarEmpleadoCuentaProveedor(int idCuentaProveedor, DataTable tabla, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter daD = new SqlDataAdapter("SP_EMP_EMP_D01", cn);
                daD.SelectCommand.CommandType = CommandType.StoredProcedure;
                daD.SelectCommand.Parameters.AddWithValue("@intIdEmp", idCuentaProveedor);
                daD.SelectCommand.ExecuteNonQuery();
                // ----  id
                if (tabla.Rows.Count > 0)
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("SP_EMP_EMP_I01", cn);
                    da1.SelectCommand.CommandType = CommandType.StoredProcedure;
                    foreach (DataRow row in tabla.Rows)
                    {
                        da1.SelectCommand.Parameters.Clear();
                        //    id
                        da1.SelectCommand.Parameters.AddWithValue("@intIdEmpr", idCuentaProveedor);
                        da1.SelectCommand.Parameters.AddWithValue("@intIdEmpl", Convert.ToInt32(row[0].ToString()));

                        da1.SelectCommand.ExecuteNonQuery();

                    }
                }
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
        }

        public void EditarCuentaProveedor(ENCuentaProveedor objEN, ref string mensaje, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_CUENTAPROVEEDOR_U01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idCuenta", objEN.intIdCuentas);
                da.SelectCommand.Parameters.AddWithValue("@idProveedor", objEN.intIdProveedor);
                da.SelectCommand.Parameters.AddWithValue("@idBanco", objEN.intIdBanco);
                da.SelectCommand.Parameters.AddWithValue("@idMoneda", objEN.intIdMoneda);
                da.SelectCommand.Parameters.AddWithValue("@strNumero", objEN.strNroCuenta);
                
                da.SelectCommand.Parameters.AddWithValue("@intEstado", objEN.intEstado);
                da.SelectCommand.Parameters.AddWithValue("@intIdUsuMf", objEN.intIdUsuMf);
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

        public void EliminarCuentaProveedor(int idSeleccion, int idUsuario, ref string mensaje, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_CUENTAPROVEEDOR_UD01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdCuenta", idSeleccion);
                da.SelectCommand.Parameters.AddWithValue("@intIdUsuMf", idUsuario);
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

        public DataTable CuentaProveedorActiva(int idUsu, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_USU_EMP_Q02", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdUsu", idUsu);
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

        public DataTable ComboCuentaProveedor(ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_CuentaProveedor_Q04", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //da.SelectCommand.Parameters.AddWithValue("@intIdEmp", idCuentaProveedor);
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
    }
}
