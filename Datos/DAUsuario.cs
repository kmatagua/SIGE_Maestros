using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    public class DAUsuario
    {
        private string _pStrConString = string.Empty;

        public DAUsuario(string p_pStrConString)
        {
            _pStrConString = p_pStrConString;
        }

        public void Usuario_V01(ENUsuario objENUsu, ref int p_intIdUsu, ref string p_strMensaje, ref bool pBlnTodoOk)
        {
            pBlnTodoOk = false;
            SqlConnection cn = new SqlConnection(_pStrConString);
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_USUARIO_V01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@strNoUsu", SqlDbType.NVarChar, 50).Value = objENUsu.strNoUsu;
                cmd.Parameters.Add("@strClave", SqlDbType.NVarChar, 50).Value = objENUsu.strClave;
                cmd.Parameters.Add("@intIdUsu", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@mensaje", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                p_strMensaje = cmd.Parameters["@mensaje"].Value.ToString();
                p_intIdUsu = (cmd.Parameters["@intIdUsu"].Value is DBNull) ? 0 : Convert.ToInt32(cmd.Parameters["@intIdUsu"].Value);
                pBlnTodoOk = true;
            }
            catch (Exception ex)
            {

            }
            cn.Close();
        }

        public DataTable ListaUsuario(int intIdUsu, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_USUARIO_Q01", cn);
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

        public DataTable ComboUsuario(int idEmpresa, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_USUARIO_Q04", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idEmpresa", idEmpresa);
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
                SqlDataAdapter da = new SqlDataAdapter("SP_USUARIO_Q03", cn);
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

        public DataTable BuscarUsuario(int intIdUsu, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable rowTbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_USUARIO_Q02", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdUsu", intIdUsu);
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

        public void InsertarUsuario(ENUsuario objEnUsu, DataTable tabla, ref string mensaje, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_USUARIO_I01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@intIdUsu", SqlDbType.Int).Direction = ParameterDirection.Output;
                da.SelectCommand.Parameters.AddWithValue("@strNombreCompleto", objEnUsu.strNombreCompleto);
                da.SelectCommand.Parameters.AddWithValue("@strCoUsu", objEnUsu.strCoUsu);
                da.SelectCommand.Parameters.AddWithValue("@strNoUsu", objEnUsu.strNoUsu);
                da.SelectCommand.Parameters.AddWithValue("@strClave", objEnUsu.strClave);
                da.SelectCommand.Parameters.AddWithValue("@intEstado", objEnUsu.intEstado);
                da.SelectCommand.Parameters.AddWithValue("@intIdUsuCr",objEnUsu.intIdUsuCr);
                da.SelectCommand.Parameters.Add("@strMensaje", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                da.SelectCommand.ExecuteNonQuery();
                mensaje = da.SelectCommand.Parameters["@strMensaje"].Value.ToString();
                int p_intIdUsu = (da.SelectCommand.Parameters["@intIdUsu"].Value is DBNull) ? 0 : Convert.ToInt32(da.SelectCommand.Parameters["@intIdUsu"].Value);
                pBlnTodoOk = true;
                
                
                // ----  id
                SqlDataAdapter da1 = new SqlDataAdapter("SP_USU_EMP_I01", cn);
                da1.SelectCommand.CommandType = CommandType.StoredProcedure;
                foreach (DataRow row in tabla.Rows)
                {
                    da1.SelectCommand.Parameters.Clear();
                    //    id
                    da1.SelectCommand.Parameters.AddWithValue("@intIdUsu", p_intIdUsu);
                    da1.SelectCommand.Parameters.AddWithValue("@intIdEmp", Convert.ToInt32(row["id"].ToString()));
                    da1.SelectCommand.Parameters.AddWithValue("@intDefault", Convert.ToInt32(row["default"].ToString()));
                    da1.SelectCommand.Parameters.AddWithValue("@intCompras", Convert.ToInt32(row["compras"].ToString()));
                    da1.SelectCommand.ExecuteNonQuery();
                }

                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
        }

        public void EditarUsuario(ENUsuario objEnUsu,DataTable tabla, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_USUARIO_U01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdUsu", objEnUsu.intIdUsu);
                da.SelectCommand.Parameters.AddWithValue("@strNombreCompleto", objEnUsu.strNombreCompleto);
                da.SelectCommand.Parameters.AddWithValue("@strCoUsu", objEnUsu.strCoUsu);
                da.SelectCommand.Parameters.AddWithValue("@strNoUsu", objEnUsu.strNoUsu);
                da.SelectCommand.Parameters.AddWithValue("@strClave", objEnUsu.strClave);
                da.SelectCommand.Parameters.AddWithValue("@intEstado", objEnUsu.intEstado);
                da.SelectCommand.Parameters.AddWithValue("@intIdUsuMf", objEnUsu.intIdUsuMf);
                
                da.SelectCommand.ExecuteNonQuery();

                SqlDataAdapter daD = new SqlDataAdapter("SP_USU_EMP_D01", cn);
                daD.SelectCommand.CommandType = CommandType.StoredProcedure;
                daD.SelectCommand.Parameters.AddWithValue("@intIdUsu", objEnUsu.intIdUsu);
                daD.SelectCommand.ExecuteNonQuery();

                SqlDataAdapter daU = new SqlDataAdapter("SP_USU_EMP_I01",cn);
                daU.SelectCommand.CommandType = CommandType.StoredProcedure;
                foreach (DataRow row in tabla.Rows)
                {
                    daU.SelectCommand.Parameters.Clear();
                    //    id
                    daU.SelectCommand.Parameters.AddWithValue("@intIdUsu", objEnUsu.intIdUsu);
                    daU.SelectCommand.Parameters.AddWithValue("@intIdEmp", Convert.ToInt32(row[0].ToString()));
                    daU.SelectCommand.Parameters.AddWithValue("@intDefault", Convert.ToInt32(row["default"].ToString()));
                    daU.SelectCommand.Parameters.AddWithValue("@intCompras", Convert.ToInt32(row["compras"].ToString()));
                    daU.SelectCommand.ExecuteNonQuery();
                }

                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
        }

        public void EditarContrasena(ENUsuario objEnUsu, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_USUARIO_U02", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdUsu", objEnUsu.intIdUsu);
                da.SelectCommand.Parameters.AddWithValue("@strClave", objEnUsu.strClave);
                da.SelectCommand.Parameters.AddWithValue("@intIdUsuMf", objEnUsu.intIdUsuMf);

                da.SelectCommand.ExecuteNonQuery();

                

                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
        }
        
        public void EliminarUsuario(int idSeleccion, int idUsuario, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_USUARIO_UD01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdUsu", idSeleccion);
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

        public DataTable ListaGridUsu(int idEmpresa, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_USU_ALM_EMP_Q01", cn);
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

        public DataTable ListaUsuAccAlm(int idAlmacen, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_USU_ALM_Q01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdAlm", idAlmacen);
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

        public void InsertarMenuUsuario(int idUsuario, DataTable tabla, int idEmpresa, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                // SqlDataAdapter daD = new SqlDataAdapter("SP_MENU_USU_D01", cn);
                //daD.SelectCommand.CommandType = CommandType.StoredProcedure;
                //daD.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);
                //daD.SelectCommand.Parameters.AddWithValue("@intIdUsu", idUsuario);
                //daD.SelectCommand.ExecuteNonQuery();
                //// ----  id
                if (tabla.Rows.Count > 0)
                {

                    SqlDataAdapter da1 = new SqlDataAdapter("SP_MENU_USU_I01", cn);
                    da1.SelectCommand.CommandType = CommandType.StoredProcedure;

                    foreach (DataRow row in tabla.Rows)
                    {
                        if (Convert.ToInt32(row["id"]) == 0)
                        {
                            da1.SelectCommand.Parameters.Clear();
                            da1.SelectCommand.Parameters.AddWithValue("@intIdUsuMenu", Convert.ToInt32(row["id"].ToString()));
                            da1.SelectCommand.Parameters.AddWithValue("@intIdUsu", Convert.ToInt32(row["idUsuario"].ToString()));
                            da1.SelectCommand.Parameters.AddWithValue("@intIdMenu", Convert.ToInt32(row["intIdMenu"].ToString()));
                            da1.SelectCommand.Parameters.AddWithValue("@idEmpresa", idEmpresa);
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

        public void InsertarOpeLogUsuario(int idUsuario, DataTable tabla, int idEmpresa, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter daD = new SqlDataAdapter("SP_OPELOG_USU_D01", cn);
                daD.SelectCommand.CommandType = CommandType.StoredProcedure;
                daD.SelectCommand.Parameters.AddWithValue("@intIdUsu", idUsuario);
                daD.SelectCommand.ExecuteNonQuery();

                SqlDataAdapter da1 = new SqlDataAdapter("SP_OPELOG_USU_I01", cn);
                da1.SelectCommand.CommandType = CommandType.StoredProcedure;

                foreach (DataRow row in tabla.Rows)
                {
                    da1.SelectCommand.Parameters.Clear();
                    //    id

                    da1.SelectCommand.Parameters.AddWithValue("@intIdOpeLog", Convert.ToInt32(row["id"].ToString()));
                    da1.SelectCommand.Parameters.AddWithValue("@intIdUsu", idUsuario);


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

        public void InsertarUniNegUsuario(int idUsuario, DataTable tabla, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                //SqlDataAdapter daD = new SqlDataAdapter("SP_UNINEG_USU_D01", cn);
                //daD.SelectCommand.CommandType = CommandType.StoredProcedure;
                //daD.SelectCommand.Parameters.AddWithValue("@intIdUsu", idUsuario);
                //daD.SelectCommand.ExecuteNonQuery();
                if (tabla.Rows.Count > 0)
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("SP_UNINEG_USU_I01", cn);
                    da1.SelectCommand.CommandType = CommandType.StoredProcedure;

                    foreach (DataRow row in tabla.Rows)
                    {
                        //if (Convert.ToInt32(row["id"]) == 0)
                        //{
                            da1.SelectCommand.Parameters.Clear();
                            //    id

                            da1.SelectCommand.Parameters.AddWithValue("@intIdUniNeg", Convert.ToInt32(row["idUniNeg"].ToString()));
                            da1.SelectCommand.Parameters.AddWithValue("@intIdUsu", idUsuario);
                            da1.SelectCommand.Parameters.AddWithValue("@intApruebaOC", Convert.ToInt32(row["intApruebaOC"].ToString()));

                            da1.SelectCommand.ExecuteNonQuery();
                        //}
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

        public void InsertarAlmacenUsuario(int idUsuario, DataTable tabla, int idEmpresa, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter daD = new SqlDataAdapter("SP_ALMACEN_USU_D01", cn);
                daD.SelectCommand.CommandType = CommandType.StoredProcedure;
                daD.SelectCommand.Parameters.AddWithValue("@intIdUsu", idUsuario);
                daD.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);
                daD.SelectCommand.ExecuteNonQuery();

                SqlDataAdapter da1 = new SqlDataAdapter("SP_ALMACEN_USU_I01", cn);
                da1.SelectCommand.CommandType = CommandType.StoredProcedure;

                foreach (DataRow row in tabla.Rows)
                {
                    da1.SelectCommand.Parameters.Clear();
                    //    id

                    da1.SelectCommand.Parameters.AddWithValue("@intIdAlm", Convert.ToInt32(row["id"].ToString()));
                    da1.SelectCommand.Parameters.AddWithValue("@intIdUsu", idUsuario);
                    da1.SelectCommand.Parameters.AddWithValue("@intDefault", Convert.ToInt32(row["default"].ToString()));


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

        public void InsertarNumeradorUsuario(int idUsuario, DataTable tabla, int idEmpresa, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                //SqlDataAdapter daD = new SqlDataAdapter("SP_NUMERADOR_USU_D01", cn);
                //daD.SelectCommand.CommandType = CommandType.StoredProcedure;
                //daD.SelectCommand.Parameters.AddWithValue("@intIdUsu", idUsuario);
                //daD.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);
                //daD.SelectCommand.ExecuteNonQuery();
                if (tabla.Rows.Count > 0)
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("SP_NUMERADOR_USU_I01_TEMP", cn);
                    da1.SelectCommand.CommandType = CommandType.StoredProcedure;

                    foreach (DataRow row in tabla.Rows)
                    {
                        da1.SelectCommand.Parameters.Clear();
                        //    id

                        da1.SelectCommand.Parameters.AddWithValue("@intIdNum", Convert.ToInt32(row["id"].ToString()));
                        da1.SelectCommand.Parameters.AddWithValue("@intIdUsu", idUsuario);
                        da1.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);
                        da1.SelectCommand.Parameters.AddWithValue("@intAprOrden", Convert.ToInt32(row["intAprOrden"].ToString()));
                        da1.SelectCommand.Parameters.AddWithValue("@intGenOrden", Convert.ToInt32(row["intGenOrden"].ToString()));
                        da1.SelectCommand.Parameters.AddWithValue("@intValSerieOrden", Convert.ToInt32(row["intValSerieOrden"].ToString()));
                        da1.SelectCommand.Parameters.AddWithValue("@intValEditOrden", Convert.ToInt32(row["intValEditOrden"].ToString()));
                        da1.SelectCommand.Parameters.AddWithValue("@intValAnulOrden", Convert.ToInt32(row["intValAnulOrden"].ToString()));

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

        public void InsertarNumeradorUsuarioOrdenes(int idUsuario, DataTable tabla, int idEmpresa, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                //SqlDataAdapter daD = new SqlDataAdapter("SP_NUMERADOR_USU_D01", cn);
                //daD.SelectCommand.CommandType = CommandType.StoredProcedure;
                //daD.SelectCommand.Parameters.AddWithValue("@intIdUsu", idUsuario);
                //daD.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);
                //daD.SelectCommand.ExecuteNonQuery();
                if (tabla.Rows.Count > 0)
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("SP_NUMERADOR_USU_ORDENES_I01_TEMP", cn);
                    da1.SelectCommand.CommandType = CommandType.StoredProcedure;

                    foreach (DataRow row in tabla.Rows)
                    {
                        da1.SelectCommand.Parameters.Clear();
                        //    id

                        da1.SelectCommand.Parameters.AddWithValue("@intIdNum", Convert.ToInt32(row["id"].ToString()));
                        da1.SelectCommand.Parameters.AddWithValue("@intIdUsu", idUsuario);
                        da1.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);

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

        public void BorrarUniNeg(int idSeleccion, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_UNINEG_USU_BORRAR_D01", cn);
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

        public void BorrarNumerador(int idSeleccion, int idUsuario, int idEmpresa, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_NUM_USU_BORRAR_D01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdNum", idSeleccion);
                da.SelectCommand.Parameters.AddWithValue("@intIdUsu", idUsuario);
                da.SelectCommand.Parameters.AddWithValue("@intIdEmpresa", idEmpresa);
                da.SelectCommand.ExecuteNonQuery();
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
        }

        public void BorrarNumeradorOrdenes(int idSeleccion, int idUsuario, int idEmpresa, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_NUM_USU_BORRAR_ORDENES_D01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdNum", idSeleccion);
                da.SelectCommand.Parameters.AddWithValue("@intIdUsu", idUsuario);
                da.SelectCommand.Parameters.AddWithValue("@intIdEmpresa", idEmpresa);
                da.SelectCommand.ExecuteNonQuery();
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
        }

        public void InsertarAreaUsuario(int idUsuario, DataTable tabla, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                //SqlDataAdapter daD = new SqlDataAdapter("SP_UNINEG_USU_D01", cn);
                //daD.SelectCommand.CommandType = CommandType.StoredProcedure;
                //daD.SelectCommand.Parameters.AddWithValue("@intIdUsu", idUsuario);
                //daD.SelectCommand.ExecuteNonQuery();
                if (tabla.Rows.Count > 0)
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("SP_AREA_USU_I01", cn);
                    da1.SelectCommand.CommandType = CommandType.StoredProcedure;

                    foreach (DataRow row in tabla.Rows)
                    {
                        if (Convert.ToInt32(row["id"]) == 0)
                        {
                            da1.SelectCommand.Parameters.Clear();
                            //    id

                            da1.SelectCommand.Parameters.AddWithValue("@intIdArea", Convert.ToInt32(row["idArea"].ToString()));
                            da1.SelectCommand.Parameters.AddWithValue("@intIdUsu", idUsuario);
                            da1.SelectCommand.Parameters.AddWithValue("@strMensaje", 0);

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

        public void BorrarArea(int idSeleccion, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_AREA_USU_BORRAR_D01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdArea", idSeleccion);
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

        public void InsertarUniGesUsuario(int idUsuario, DataTable tabla, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                //SqlDataAdapter daD = new SqlDataAdapter("SP_UNINEG_USU_D01", cn);
                //daD.SelectCommand.CommandType = CommandType.StoredProcedure;
                //daD.SelectCommand.Parameters.AddWithValue("@intIdUsu", idUsuario);
                //daD.SelectCommand.ExecuteNonQuery();
                if (tabla.Rows.Count > 0)
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("SP_UNIGES_USU_I01", cn);
                    da1.SelectCommand.CommandType = CommandType.StoredProcedure;

                    foreach (DataRow row in tabla.Rows)
                    {
                        if (Convert.ToInt32(row["id"]) == 0)
                        {
                            da1.SelectCommand.Parameters.Clear();
                            //    id

                            da1.SelectCommand.Parameters.AddWithValue("@intIdUniGes", Convert.ToInt32(row["idUniGes"].ToString()));
                            da1.SelectCommand.Parameters.AddWithValue("@intIdUsu", idUsuario);


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

        public void InsertarMotivoUsuario(int idUsuario, DataTable tabla, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                //SqlDataAdapter daD = new SqlDataAdapter("SP_UNINEG_USU_D01", cn);
                //daD.SelectCommand.CommandType = CommandType.StoredProcedure;
                //daD.SelectCommand.Parameters.AddWithValue("@intIdUsu", idUsuario);
                //daD.SelectCommand.ExecuteNonQuery();
                if (tabla.Rows.Count > 0)
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("SP_MOTIVO_USU_I01", cn);
                    da1.SelectCommand.CommandType = CommandType.StoredProcedure;

                    foreach (DataRow row in tabla.Rows)
                    {
                        if (Convert.ToInt32(row["id"]) == 0)
                        {
                            da1.SelectCommand.Parameters.Clear();
                            //    id

                            da1.SelectCommand.Parameters.AddWithValue("@intIdMot", Convert.ToInt32(row["idMotivo"].ToString()));
                            da1.SelectCommand.Parameters.AddWithValue("@intIdUsu", idUsuario);


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
                SqlDataAdapter da = new SqlDataAdapter("SP_MOTIVO_USU_BORRAR_D01", cn);
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

        public void BorrarCenCos(int idSeleccion, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_CENCOS_USU_BORRAR_D01", cn);
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

        public void InsertarCenCosUsuario(int idUsuario, DataTable tabla, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                //SqlDataAdapter daD = new SqlDataAdapter("SP_UNINEG_USU_D01", cn);
                //daD.SelectCommand.CommandType = CommandType.StoredProcedure;
                //daD.SelectCommand.Parameters.AddWithValue("@intIdUsu", idUsuario);
                //daD.SelectCommand.ExecuteNonQuery();
                if (tabla.Rows.Count > 0)
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("SP_CENCOS_USU_I01", cn);
                    da1.SelectCommand.CommandType = CommandType.StoredProcedure;

                    foreach (DataRow row in tabla.Rows)
                    {
                        if (Convert.ToInt32(row["id"]) == 0)
                        {
                            da1.SelectCommand.Parameters.Clear();
                            //    id

                            da1.SelectCommand.Parameters.AddWithValue("@intIdCenCos", Convert.ToInt32(row["idCenCos"].ToString()));
                            da1.SelectCommand.Parameters.AddWithValue("@intIdUsu", idUsuario);


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

        public void BorrarUniGes(int idSeleccion, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_UNIGES_USU_BORRAR_D01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intId", idSeleccion);
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
