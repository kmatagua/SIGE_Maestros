using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    public class DANumerador
    {
        private string _pStrConString = string.Empty;

        public DANumerador(string p_pStrConString)
        {
            _pStrConString = p_pStrConString;
        }

        public DataTable ListaNumerador(int idEmpresa, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_NUMERADOR_Q01", cn);
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

        public DataTable ListaNumeradorOrdenes(int idEmpresa, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_NUMERADOR_ORDENES_Q01", cn);
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

        public DataTable ListaNumeradorRequerimiento(int idEmpresa, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_NUMERADOR_REQUERIMIENTO_Q01", cn);
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

        public DataTable ListaNumeradorAccUsu(int idUsuario, int idEmpresa, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_NUMERADOR_USU_Q01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdUsu", idUsuario);
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

        public DataTable ListaNumeradorAccSeriesOrdenes(int idUsuario, int idEmpresa, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_NUMERADOR_USU_ORDENES_Q01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdUsu", idUsuario);
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

        public DataTable ListaNumAccesoUsuAprReq(int idUsuario, int idEmpresa, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_NUMERADOR_USU_APRREQ_Q01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdUsu", idUsuario);
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

        public DataTable ListaComboNumerador(int intIdUsu, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_Numerador_Q05", cn);
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
                SqlDataAdapter da = new SqlDataAdapter("SP_Numerador_Q03", cn);
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

        public DataTable BuscarNumerador(int intIdNum, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable rowTbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_NUMERADOR_Q02", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdNum", intIdNum);
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

        public void InsertarNumerador(ENNumerador obj, ref string mensaje, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_NUMERADOR_I01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idEmpresa", obj.intIdEmp);
                da.SelectCommand.Parameters.AddWithValue("@idAlmacen", obj.intIdAlm);
                da.SelectCommand.Parameters.AddWithValue("@idSede", obj.intIdSede);
                
                da.SelectCommand.Parameters.AddWithValue("@idOperacion", obj.intIdOperacion);
                da.SelectCommand.Parameters.AddWithValue("@idSubTipoOpe", obj.intIdSubTipoOpe);
                da.SelectCommand.Parameters.AddWithValue("@idTipoOpe", obj.intIdTipoOpe);
                da.SelectCommand.Parameters.AddWithValue("@idTipoDocumento", obj.intIdTipDoc);
                da.SelectCommand.Parameters.AddWithValue("@strSerie", obj.strSerie);
                da.SelectCommand.Parameters.AddWithValue("@strNumero", obj.strNumero);
                da.SelectCommand.Parameters.AddWithValue("@strObservacion", obj.strObservacion);
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

        public void InsertarUniNumerador(int idNumerador, DataTable tabla, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter daD = new SqlDataAdapter("SP_UNI_EMP_D01", cn);
                daD.SelectCommand.CommandType = CommandType.StoredProcedure;
                daD.SelectCommand.Parameters.AddWithValue("@intIdEmp", idNumerador);
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
                        da1.SelectCommand.Parameters.AddWithValue("@intIdEmp", idNumerador);
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

        public void InsertarFamiliaNumerador(int idNumerador, DataTable tabla, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter daD = new SqlDataAdapter("SP_FAMILIA_EMP_D01", cn);
                daD.SelectCommand.CommandType = CommandType.StoredProcedure;
                daD.SelectCommand.Parameters.AddWithValue("@intIdEmp", idNumerador);
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
                        da1.SelectCommand.Parameters.AddWithValue("@intIdEmp", idNumerador);
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

        public void InsertarMarcaNumerador(int idNumerador, DataTable tabla, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter daD = new SqlDataAdapter("SP_MARCA_EMP_D01", cn);
                daD.SelectCommand.CommandType = CommandType.StoredProcedure;
                daD.SelectCommand.Parameters.AddWithValue("@intIdEmp", idNumerador);
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
                        da1.SelectCommand.Parameters.AddWithValue("@intIdEmp", idNumerador);
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

        public void InsertarOpeLogNumerador(int idNumerador, DataTable tabla, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter daD = new SqlDataAdapter("SP_OPELOG_EMP_D01", cn);
                daD.SelectCommand.CommandType = CommandType.StoredProcedure;
                daD.SelectCommand.Parameters.AddWithValue("@intIdEmp", idNumerador);
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
                        da1.SelectCommand.Parameters.AddWithValue("@intIdEmp", idNumerador);
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

        public void InsertarUniNegNumerador(int idNumerador, DataTable tabla, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter daD = new SqlDataAdapter("SP_UNINEG_EMP_D01", cn);
                daD.SelectCommand.CommandType = CommandType.StoredProcedure;
                daD.SelectCommand.Parameters.AddWithValue("@intIdEmp", idNumerador);
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
                        da1.SelectCommand.Parameters.AddWithValue("@intIdEmp", idNumerador);
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

        public void InsertarTipoDocNumerador(int idNumerador, DataTable tabla, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter daD = new SqlDataAdapter("SP_TIPODOC_EMP_D01", cn);
                daD.SelectCommand.CommandType = CommandType.StoredProcedure;
                daD.SelectCommand.Parameters.AddWithValue("@intIdEmp", idNumerador);
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
                        da1.SelectCommand.Parameters.AddWithValue("@intIdEmp", idNumerador);
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

        public void InsertarEmpleadoNumerador(int idNumerador, DataTable tabla, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter daD = new SqlDataAdapter("SP_EMP_EMP_D01", cn);
                daD.SelectCommand.CommandType = CommandType.StoredProcedure;
                daD.SelectCommand.Parameters.AddWithValue("@intIdEmp", idNumerador);
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
                        da1.SelectCommand.Parameters.AddWithValue("@intIdEmpr", idNumerador);
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

        public void EditarNumerador(ENNumerador objEN, ref string mensaje, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_NUMERADOR_U01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdNum", objEN.intIdNum);
                da.SelectCommand.Parameters.AddWithValue("@intIdOperacion", objEN.intIdOperacion);
                da.SelectCommand.Parameters.AddWithValue("@intIdSubTipoOpe", objEN.intIdSubTipoOpe);
                da.SelectCommand.Parameters.AddWithValue("@intIdTipDoc", objEN.intIdTipDoc);
                da.SelectCommand.Parameters.AddWithValue("@intIdTipoOpe", objEN.intIdTipoOpe);
                da.SelectCommand.Parameters.AddWithValue("@strSerie", objEN.strSerie);
                da.SelectCommand.Parameters.AddWithValue("@strNumero", objEN.strNumero);
                da.SelectCommand.Parameters.AddWithValue("@strObservacion", objEN.strObservacion);
                da.SelectCommand.Parameters.AddWithValue("@intIdEmp", objEN.intIdEmp);
                da.SelectCommand.Parameters.AddWithValue("@intIdAlm", objEN.intIdAlm);
                da.SelectCommand.Parameters.AddWithValue("@intIdSede", objEN.intIdSede);

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

        public void EliminarNumerador(int idSeleccion, int idUsuario, ref string mensaje, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_NUMERADOR_UD01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdNum", idSeleccion);
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

        public DataTable NumeradorActiva(int idUsu, ref bool pBlnTodoOk)
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

        public DataTable ComboNumerador(ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_Numerador_Q04", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //da.SelectCommand.Parameters.AddWithValue("@intIdEmp", idNumerador);
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
