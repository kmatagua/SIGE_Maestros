using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entidad;
using Configuracion;

namespace Datos
{
    public class DAEmpresa
    {
        private string _pStrConString = string.Empty;

        public DAEmpresa(string p_pStrConString)
        {
            _pStrConString = p_pStrConString;
        }

        public DataTable ListaEmpresa(int intIdUsu, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_EMPRESA_Q01", cn);
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

        public DataTable ListaComboEmpresa(int intIdUsu, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_EMPRESA_Q05", cn);
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
                SqlDataAdapter da = new SqlDataAdapter("SP_EMPRESA_Q03", cn);
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

        public DataTable BuscarEmpresa(int intIdEmp, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable rowTbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_EMPRESA_Q02", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdEmp", intIdEmp);
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

        public void InsertarEmpresa(ENEmpresa objEnEmp, List<ENDireccionEmpresa> lista, int idEmpresa, ref string mensaje, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_EMPRESA_I01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@strCoEmp", objEnEmp.strCoEmp);
                da.SelectCommand.Parameters.AddWithValue("@strNoEmp", objEnEmp.strNoEmp);
                da.SelectCommand.Parameters.AddWithValue("@strRuc", objEnEmp.strRuc);
                da.SelectCommand.Parameters.AddWithValue("@intEstado", objEnEmp.intEstado);

                da.SelectCommand.Parameters.AddWithValue("@intIdUsuCr", objEnEmp.intIdUsuCr);

                da.SelectCommand.Parameters.Add("@idEmpresa", SqlDbType.Int).Direction = ParameterDirection.Output;
                da.SelectCommand.Parameters.Add("@strMensaje", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                da.SelectCommand.ExecuteNonQuery();
                mensaje = da.SelectCommand.Parameters["@strMensaje"].Value.ToString();
                if (mensaje != string.Empty)
                { cn.Close(); return; }
                int p_intIdEmpresa = Convert.ToInt32(da.SelectCommand.Parameters["@idEmpresa"].Value);



                mensaje = string.Empty;
                foreach (ENDireccionEmpresa item in lista)
                {
                    SqlDataAdapter dad = new SqlDataAdapter("SP_DIRECCION_EMPRESA_I01", cn);
                    dad.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dad.SelectCommand.Parameters.AddWithValue("@intIdEmpresa", p_intIdEmpresa);
                    dad.SelectCommand.Parameters.AddWithValue("@intIdCalle", item.intIdCalle);
                    dad.SelectCommand.Parameters.AddWithValue("@strNoCalle", item.strNoCalle);
                    dad.SelectCommand.Parameters.AddWithValue("@strNro", item.strNro);
                    dad.SelectCommand.Parameters.AddWithValue("@strPabellon", item.strPabellon);
                    dad.SelectCommand.Parameters.AddWithValue("@strMz", item.strMz);
                    dad.SelectCommand.Parameters.AddWithValue("@strLote", item.strLote);
                    dad.SelectCommand.Parameters.AddWithValue("@intIdTipoDep", item.intIdTipoDep);
                    dad.SelectCommand.Parameters.AddWithValue("@strNoTipoDep", item.strNoTipoDep);
                    dad.SelectCommand.Parameters.AddWithValue("@intIdUrbanismo", item.intIdUrbanismo);
                    dad.SelectCommand.Parameters.AddWithValue("@strNoUrb", item.strNoUrb);
                    dad.SelectCommand.Parameters.AddWithValue("@intIdSector", item.intIdSector);
                    dad.SelectCommand.Parameters.AddWithValue("@strNoSector", item.strNoSector);
                    dad.SelectCommand.Parameters.AddWithValue("@intIdUbigeo", item.intIdUbigeo);
                    dad.SelectCommand.Parameters.AddWithValue("@strDireccion", item.strDireccion);
                    dad.SelectCommand.Parameters.AddWithValue("@intDefault", item.intDefault);

                    dad.SelectCommand.Parameters.AddWithValue("@intIdUsuCr", item.intIdUsuCr);

                    dad.SelectCommand.ExecuteNonQuery();

                    mensaje = da.SelectCommand.Parameters["@strMensaje"].Value.ToString();

                }
                pBlnTodoOk = true;
                cn.Close();

            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
        }

        public void InsertarUniEmpresa(int idEmpresa, DataTable tabla, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter daD = new SqlDataAdapter("SP_UNI_EMP_D01", cn);
                daD.SelectCommand.CommandType = CommandType.StoredProcedure;
                daD.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);
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
                        da1.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);
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

        public void InsertarFamiliaEmpresa(int idEmpresa, DataTable tabla, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter daD = new SqlDataAdapter("SP_FAMILIA_EMP_D01", cn);
                daD.SelectCommand.CommandType = CommandType.StoredProcedure;
                daD.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);
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
                        da1.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);
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

        public void InsertarMarcaEmpresa(int idEmpresa, DataTable tabla, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter daD = new SqlDataAdapter("SP_MARCA_EMP_D01", cn);
                daD.SelectCommand.CommandType = CommandType.StoredProcedure;
                daD.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);
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
                        da1.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);
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

        public void InsertarOpeLogEmpresa(int idEmpresa, DataTable tabla, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter daD = new SqlDataAdapter("SP_OPELOG_EMP_D01", cn);
                daD.SelectCommand.CommandType = CommandType.StoredProcedure;
                daD.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);
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
                        da1.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);
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

        public void InsertarUniNegEmpresa(int idEmpresa, DataTable tabla, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                //SqlDataAdapter daD = new SqlDataAdapter("SP_UNINEG_EMP_D01", cn);
                //daD.SelectCommand.CommandType = CommandType.StoredProcedure;
                //daD.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);
                //daD.SelectCommand.ExecuteNonQuery();
                // ----  id
                if (tabla.Rows.Count > 0)
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("SP_UNINEG_EMP_I01", cn);
                    da1.SelectCommand.CommandType = CommandType.StoredProcedure;
                    foreach (DataRow row in tabla.Rows)
                    {
                        if (Convert.ToInt32(row["id"]) == 0)
                        {
                            da1.SelectCommand.Parameters.Clear();
                            //    id
                            da1.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);
                            da1.SelectCommand.Parameters.AddWithValue("@intIdUniNeg", Convert.ToInt32(row["idUniNeg"].ToString()));

                            da1.SelectCommand.ExecuteNonQuery();
                        }
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

        public void InsertarTipoDocEmpresa(int idEmpresa, DataTable tabla, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter daD = new SqlDataAdapter("SP_TIPODOC_EMP_D01", cn);
                daD.SelectCommand.CommandType = CommandType.StoredProcedure;
                daD.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);
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
                        da1.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);
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

        public void InsertarEmpleadoEmpresa(int idEmpresa, DataTable tabla, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                //SqlDataAdapter daD = new SqlDataAdapter("SP_EMP_EMP_D01", cn);
                //daD.SelectCommand.CommandType = CommandType.StoredProcedure;
                //daD.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);
                //daD.SelectCommand.ExecuteNonQuery();
                // ----  id
                if (tabla.Rows.Count > 0)
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("SP_EMP_EMP_I01", cn);
                    da1.SelectCommand.CommandType = CommandType.StoredProcedure;
                    foreach (DataRow row in tabla.Rows)
                    {
                        da1.SelectCommand.Parameters.Clear();
                        //    id
                        da1.SelectCommand.Parameters.AddWithValue("@intIdEmpr", idEmpresa);
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

        public void InsertarClienteEmpresa(int idEmpresa, DataTable tabla, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter daD = new SqlDataAdapter("SP_CLIENTE_EMP_D01", cn);
                daD.SelectCommand.CommandType = CommandType.StoredProcedure;
                daD.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);
                daD.SelectCommand.ExecuteNonQuery();
                // ----  id
                if (tabla.Rows.Count > 0)
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("SP_CLIENTE_EMP_I01", cn);
                    da1.SelectCommand.CommandType = CommandType.StoredProcedure;
                    foreach (DataRow row in tabla.Rows)
                    {
                        da1.SelectCommand.Parameters.Clear();
                        //    id
                        da1.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);
                        da1.SelectCommand.Parameters.AddWithValue("@intIdCliente", Convert.ToInt32(row[0].ToString()));

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

        public void EditarEmpresa(ENEmpresa objEnEmp, List<ENDireccionEmpresa> lista, ref string mensaje, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                Edit_Elim_Empresa(objEnEmp.intIdEmp, objEnEmp.intIdUsuMf, ref pBlnTodoOk);
                if (!pBlnTodoOk)
                    return;
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_EMPRESA_U01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdEmp", objEnEmp.intIdEmp);
                da.SelectCommand.Parameters.AddWithValue("@strCoEmp", objEnEmp.strCoEmp);
                da.SelectCommand.Parameters.AddWithValue("@strNoEmp", objEnEmp.strNoEmp);
                da.SelectCommand.Parameters.AddWithValue("@strRuc", objEnEmp.strRuc);
                da.SelectCommand.Parameters.AddWithValue("@intEstado", objEnEmp.intEstado);
                da.SelectCommand.Parameters.AddWithValue("@intIdUsuMf", objEnEmp.intIdUsuMf);
                da.SelectCommand.Parameters.Add("@strMensaje", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                da.SelectCommand.ExecuteNonQuery();

                mensaje = da.SelectCommand.Parameters["@strMensaje"].Value.ToString();
                if (mensaje != string.Empty)
                { cn.Close(); return; }
                int p_intIdEmp = Convert.ToInt32(da.SelectCommand.Parameters["@intIdEmp"].Value);



                mensaje = string.Empty;
                foreach (ENDireccionEmpresa item in lista)
                {
                    SqlDataAdapter dad = new SqlDataAdapter("SP_DIRECCION_EMPRESA_U01", cn);
                    dad.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dad.SelectCommand.Parameters.AddWithValue("@intIdDireccionEmpresa", item.intIdDireccionEmpresa);
                    dad.SelectCommand.Parameters.AddWithValue("@intIdEmpresa", p_intIdEmp);
                    dad.SelectCommand.Parameters.AddWithValue("@intIdCalle", item.intIdCalle);
                    dad.SelectCommand.Parameters.AddWithValue("@strDireccion", item.strDireccion);
                    dad.SelectCommand.Parameters.AddWithValue("@strNoCalle", item.strNoCalle);
                    dad.SelectCommand.Parameters.AddWithValue("@strNro", item.strNro);
                    dad.SelectCommand.Parameters.AddWithValue("@strPabellon", item.strPabellon);
                    dad.SelectCommand.Parameters.AddWithValue("@strMz", item.strMz);
                    dad.SelectCommand.Parameters.AddWithValue("@strLote", item.strLote);
                    dad.SelectCommand.Parameters.AddWithValue("@intIdTipoDep", item.intIdTipoDep);
                    dad.SelectCommand.Parameters.AddWithValue("@strNoTipoDep", item.strNoTipoDep);
                    dad.SelectCommand.Parameters.AddWithValue("@intIdUrbanismo", item.intIdUrbanismo);
                    dad.SelectCommand.Parameters.AddWithValue("@strNoUrb", item.strNoUrb);
                    dad.SelectCommand.Parameters.AddWithValue("@intIdSector", item.intIdSector);
                    dad.SelectCommand.Parameters.AddWithValue("@intIdUbigeo", item.intIdUbigeo);
                    dad.SelectCommand.Parameters.AddWithValue("@intDefault", item.intDefault);

                    dad.SelectCommand.Parameters.AddWithValue("@intIdUsuMf", item.intIdUsuMf);
                    dad.SelectCommand.Parameters.Add("@strMensaje", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                    dad.SelectCommand.ExecuteNonQuery();

                    mensaje = da.SelectCommand.Parameters["@strMensaje"].Value.ToString();

                }
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
        }

        public void Edit_Elim_Empresa(int intIdEmpresa, int idUsuario, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_DIRECCION_EMPRESA_U02", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdEmpresa", intIdEmpresa);
                da.SelectCommand.Parameters.AddWithValue("@intIdUsuMf", idUsuario);
                da.SelectCommand.ExecuteNonQuery();
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                Libreria.Error_Grabar(ex);
                pBlnTodoOk = false;
            }
        }

        public void EliminarEmpresa(int idSeleccion, int idUsuario, ref string mensaje, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_EMPRESA_UD01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdEmp", idSeleccion);
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

        public DataTable EmpresaActiva(int idUsu, ref bool pBlnTodoOk)
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

        public DataTable ComboEmpresa(ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_EMPRESA_Q04", cn);
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

        public DataTable ListarDireccion(int idEmpresa, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            SqlCommand cmd = new SqlCommand();
            DataTable tbl = new DataTable();
            pBlnTodoOk = false;
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_DIRECCION_EMPRESA_Q01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);
                da.Fill(tbl);
                pBlnTodoOk = true;
            }
            catch (Exception ex)
            {
                Libreria.Error_Grabar(ex);
                pBlnTodoOk = false;
            }
            cn.Close();
            return tbl;
        }

        public void InsertarArtEmpresa(int idEmpresa, DataTable tabla, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                if (tabla.Rows.Count > 0)
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("SP_ART_EMP_I01", cn);
                    da1.SelectCommand.CommandType = CommandType.StoredProcedure;
                    foreach (DataRow row in tabla.Rows)
                    {
                        if (Convert.ToInt32(row["id"]) == 0)
                        {
                            da1.SelectCommand.Parameters.Clear();
                            //    id
                            da1.SelectCommand.Parameters.AddWithValue("@intIdArtEmp", Convert.ToInt32(row["id"].ToString()));
                            da1.SelectCommand.Parameters.AddWithValue("@intIdArt", Convert.ToInt32(row["intIdArt"].ToString()));
                            da1.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);
                            da1.SelectCommand.ExecuteNonQuery();
                        }
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

        public void Borrar(int idSeleccion, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_ART_EMP_BORRAR_D01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdArtEmp", idSeleccion);
                //da.SelectCommand.Parameters.AddWithValue("@intIdUsuMf", idUsuario);
                da.SelectCommand.ExecuteNonQuery();
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
        }

        public void BorrarUniNeg(int idSeleccion, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_UNINEG_EMP_BORRAR_D01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdUniNeg", idSeleccion);
                //da.SelectCommand.Parameters.AddWithValue("@intIdUsuMf", idUsuario);
                da.SelectCommand.ExecuteNonQuery();
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
        }

        public void BorrarUniGes(int idSeleccion, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_UNIGES_EMP_BORRAR_D01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdUniGes", idSeleccion);
                //da.SelectCommand.Parameters.AddWithValue("@intIdUsuMf", idUsuario);
                da.SelectCommand.ExecuteNonQuery();
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
        }

        public void InsertarUniGesEmpresa(int idEmpresa, DataTable tabla, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                //SqlDataAdapter daD = new SqlDataAdapter("SP_UNINEG_EMP_D01", cn);
                //daD.SelectCommand.CommandType = CommandType.StoredProcedure;
                //daD.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);
                //daD.SelectCommand.ExecuteNonQuery();
                // ----  id
                if (tabla.Rows.Count > 0)
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("SP_UNIGES_EMP_I01", cn);
                    da1.SelectCommand.CommandType = CommandType.StoredProcedure;
                    foreach (DataRow row in tabla.Rows)
                    {
                        if (Convert.ToInt32(row["id"]) == 0)
                        {
                            da1.SelectCommand.Parameters.Clear();
                            //    id
                            da1.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);
                            da1.SelectCommand.Parameters.AddWithValue("@intIdUniGes", Convert.ToInt32(row["idUniGes"].ToString()));

                            da1.SelectCommand.ExecuteNonQuery();
                        }
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

        public void InsertarMotivosEmpresa(int idEmpresa, DataTable tabla, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                //SqlDataAdapter daD = new SqlDataAdapter("SP_UNINEG_EMP_D01", cn);
                //daD.SelectCommand.CommandType = CommandType.StoredProcedure;
                //daD.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);
                //daD.SelectCommand.ExecuteNonQuery();
                // ----  id
                if (tabla.Rows.Count > 0)
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("SP_MOTIVOS_EMP_I01", cn);
                    da1.SelectCommand.CommandType = CommandType.StoredProcedure;
                    foreach (DataRow row in tabla.Rows)
                    {
                        if (Convert.ToInt32(row["id"]) == 0)
                        {
                            da1.SelectCommand.Parameters.Clear();
                            //    id
                            da1.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);
                            da1.SelectCommand.Parameters.AddWithValue("@intIdMot", Convert.ToInt32(row["idMotivo"].ToString()));

                            da1.SelectCommand.ExecuteNonQuery();
                        }
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

        public void BorrarMotivo(int idSeleccion, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_MOTIVO_EMP_BORRAR_D01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdMot", idSeleccion);
                //da.SelectCommand.Parameters.AddWithValue("@intIdUsuMf", idUsuario);
                da.SelectCommand.ExecuteNonQuery();
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
        }

        public void InsertarCenCosEmpresa(int idEmpresa, DataTable tabla, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                //SqlDataAdapter daD = new SqlDataAdapter("SP_UNINEG_EMP_D01", cn);
                //daD.SelectCommand.CommandType = CommandType.StoredProcedure;
                //daD.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);
                //daD.SelectCommand.ExecuteNonQuery();
                // ----  id
                if (tabla.Rows.Count > 0)
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("SP_CENCOS_EMP_I01", cn);
                    da1.SelectCommand.CommandType = CommandType.StoredProcedure;
                    foreach (DataRow row in tabla.Rows)
                    {
                        if (Convert.ToInt32(row["id"]) == 0)
                        {
                            da1.SelectCommand.Parameters.Clear();
                            //    id
                            da1.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);
                            da1.SelectCommand.Parameters.AddWithValue("@intIdCenCos", Convert.ToInt32(row["idCenCos"].ToString()));

                            da1.SelectCommand.ExecuteNonQuery();
                        }
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

        public void BorrarCenCos(int idSeleccion, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_CENCOS_EMP_BORRAR_D01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdCenCos", idSeleccion);
                //da.SelectCommand.Parameters.AddWithValue("@intIdUsuMf", idUsuario);
                da.SelectCommand.ExecuteNonQuery();
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
