using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    public class DAAlmacen
    {
        private string _pStrConString = string.Empty;

        public DAAlmacen(string p_pStrConString)
        {
            _pStrConString = p_pStrConString;
        }

        public DataTable ListaAlmacen(int idEmpresa, int idUsuario, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_ALMACEN_Q01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);
                da.SelectCommand.Parameters.AddWithValue("@intIdUsu", idUsuario);
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

        public DataTable ListaComboAlmacen(int idEmpresa, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_ALMACEN_Q04", cn);
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

        public DataTable ListaFiltrar(string filtro, int idEmpresa, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_ALMACEN_Q03", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@filtro", filtro);
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

        public DataTable BuscarAlmacen(int intIdAlm, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable rowTbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_ALMACEN_Q02", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdAlm", intIdAlm);
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
        
        public void InsertarAlmacen(ENAlmacen objEnAlm, ref string mensaje, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_ALMACEN_I01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@strCoAlm", SqlDbType.VarChar, 6).Value = objEnAlm.strCoAlm;
                cmd.Parameters.Add("@strNoAlm", SqlDbType.VarChar, 50).Value = objEnAlm.strNoAlm;
                cmd.Parameters.Add("@intEstado", SqlDbType.Int).Value = objEnAlm.intEstado;
                cmd.Parameters.Add("@intIdUsuCr", SqlDbType.Int).Value = objEnAlm.intIdUsuCr;
                cmd.Parameters.Add("@intIdSede", SqlDbType.Int).Value = objEnAlm.intIdSede;
                cmd.Parameters.Add("@intServicio", SqlDbType.Int).Value = objEnAlm.intServicio;
                cmd.Parameters.Add("@strMensaje", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                mensaje = cmd.Parameters["@strMensaje"].Value.ToString();
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
        }

        public void EditarAlmacen(ENAlmacen objEnAlm, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_ALMACEN_U01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdAlm", objEnAlm.intIdAlm);
                da.SelectCommand.Parameters.AddWithValue("@strCoAlm", objEnAlm.strCoAlm);
                da.SelectCommand.Parameters.AddWithValue("@strNoAlm", objEnAlm.strNoAlm);
                da.SelectCommand.Parameters.AddWithValue("@intServicio", objEnAlm.intServicio);
                da.SelectCommand.Parameters.AddWithValue("@intEstado", objEnAlm.intEstado);
                da.SelectCommand.Parameters.AddWithValue("@intIdUsuMf", objEnAlm.intIdUsuMf);
                da.SelectCommand.Parameters.AddWithValue("@intIdSede", objEnAlm.intIdSede);

                da.SelectCommand.ExecuteNonQuery();
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
        }

        public void EliminarAlmacen(int idSeleccion, int idUsuario, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_ALMACEN_UD01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdAlm", idSeleccion);
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

        public void InsertarOpeLogAlmacen(int idAlmacen, DataTable tabla, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter daD = new SqlDataAdapter("SP_OPELOG_ALM_D01", cn);
                daD.SelectCommand.CommandType = CommandType.StoredProcedure;
                daD.SelectCommand.Parameters.AddWithValue("@intIdAlm", idAlmacen);
                daD.SelectCommand.ExecuteNonQuery();
                // ----  id
                SqlDataAdapter da1 = new SqlDataAdapter("SP_OPELOG_ALM_I01", cn);
                da1.SelectCommand.CommandType = CommandType.StoredProcedure;
                foreach (DataRow row in tabla.Rows)
                {
                    da1.SelectCommand.Parameters.Clear();
                    //    id
                    da1.SelectCommand.Parameters.AddWithValue("@intIdAlm", idAlmacen);
                    da1.SelectCommand.Parameters.AddWithValue("@intIdOpeLog", Convert.ToInt32(row[0].ToString()));

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

        public void InsertarUsuAlmacen(int idAlmacen, DataTable tabla, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter daD = new SqlDataAdapter("SP_USU_ALM_D01", cn);
                daD.SelectCommand.CommandType = CommandType.StoredProcedure;
                daD.SelectCommand.Parameters.AddWithValue("@intIdAlm", idAlmacen);
                daD.SelectCommand.ExecuteNonQuery();
                // ----  id
                SqlDataAdapter da1 = new SqlDataAdapter("SP_USU_ALM_I01", cn);
                da1.SelectCommand.CommandType = CommandType.StoredProcedure;
                foreach (DataRow row in tabla.Rows)
                {
                    da1.SelectCommand.Parameters.Clear();
                    //    id
                    da1.SelectCommand.Parameters.AddWithValue("@intIdAlm", idAlmacen);
                    da1.SelectCommand.Parameters.AddWithValue("@intIdUsu", Convert.ToInt32(row[0].ToString()));

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

        public void InsertarMaqAlmacen(int idAlmacen, DataTable tabla, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter daD = new SqlDataAdapter("SP_MAQ_ALM_D01", cn);
                daD.SelectCommand.CommandType = CommandType.StoredProcedure;
                daD.SelectCommand.Parameters.AddWithValue("@intIdAlm", idAlmacen);
                daD.SelectCommand.ExecuteNonQuery();
                // ----  id
                SqlDataAdapter da1 = new SqlDataAdapter("SP_MAQ_ALM_I01", cn);
                da1.SelectCommand.CommandType = CommandType.StoredProcedure;
                foreach (DataRow row in tabla.Rows)
                {
                    da1.SelectCommand.Parameters.Clear();
                    //    id
                    da1.SelectCommand.Parameters.AddWithValue("@intIdAlm", idAlmacen);
                    da1.SelectCommand.Parameters.AddWithValue("@intIdMaq", Convert.ToInt32(row[0].ToString()));

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

        public void InsertarArtAlmacen(int idAlmacen, int idEmpresa, DataTable tabla, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                if (tabla.Rows.Count > 0)
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("SP_ART_ALM_I01", cn);
                    da1.SelectCommand.CommandType = CommandType.StoredProcedure;
                    foreach (DataRow row in tabla.Rows)
                    {
                        if (Convert.ToInt32(row["id"]) == 0)
                        {
                            da1.SelectCommand.Parameters.Clear();
                            //    id
                            da1.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);
                            da1.SelectCommand.Parameters.AddWithValue("@intIdArt", Convert.ToInt32(row["intIdArt"].ToString()));
                            da1.SelectCommand.Parameters.AddWithValue("@intIdAlm", idAlmacen);
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

        public DataTable ListaGridAlmacen(int idEmpresa, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_ALMACEN_EMP_Q01", cn);
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

        public DataTable ListaAlmacenAccUsu(int idUsuario, int idEmpresa, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_ALMACEN_USU_Q01", cn);
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

        public void Borrar(int idSeleccion, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_ART_BORRAR_D01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdArtAlm", idSeleccion);
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

        public DataTable BuscarConfigAlmacen(int intIdAlm, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable rowTbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_CONFIG_ALMACEN_Q02", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdAlm", intIdAlm);
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

        //public void InsertarConfigAlmacen(ENConfig_Alm objEnAlm, ref bool pBlnTodoOk)
        //{
        //    SqlConnection cn = new SqlConnection(_pStrConString);
        //    pBlnTodoOk = false;

        //    try
        //    {
        //        cn.Open();
        //        SqlDataAdapter da = new SqlDataAdapter("SP_CONFIG_ALMACEN_I01", cn);
        //        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        //        da.SelectCommand.Parameters.AddWithValue("@intIdAlm", objEnAlm.intIdAlm);
        //        da.SelectCommand.Parameters.AddWithValue("@strDescripcion", objEnAlm.strDescripcion);
        //        da.SelectCommand.Parameters.AddWithValue("@intIdEmp", objEnAlm.intIdEmp);
        //        da.SelectCommand.Parameters.AddWithValue("@intTab", objEnAlm.intTab);
        //        da.SelectCommand.Parameters.AddWithValue("@intValidaStock", objEnAlm.intValidaStock);
        //        da.SelectCommand.Parameters.AddWithValue("@intValidaCero", objEnAlm.intValidaCero);

        //        da.SelectCommand.ExecuteNonQuery();
        //        pBlnTodoOk = true;
        //        cn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        pBlnTodoOk = false;
        //    }
        //}

        public void EditarConfigAlmacen(ENConfig_Alm objEnAlm, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_CONFIG_ALMACEN_U01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdAlm", objEnAlm.intIdAlm);
                da.SelectCommand.Parameters.AddWithValue("@intIdEmp", objEnAlm.intIdEmp);
                da.SelectCommand.Parameters.AddWithValue("@strDescripcion", objEnAlm.strDescripcion);
                da.SelectCommand.Parameters.AddWithValue("@intTab", objEnAlm.intTab);
                da.SelectCommand.Parameters.AddWithValue("@intValidaStock", objEnAlm.intValidaStock);
                da.SelectCommand.Parameters.AddWithValue("@intValidaCero", objEnAlm.intValidaCero);
                da.SelectCommand.Parameters.AddWithValue("@intVenta", objEnAlm.intVenta);
                da.SelectCommand.Parameters.AddWithValue("@intAprobIng", objEnAlm.intAprobIng);
                da.SelectCommand.Parameters.AddWithValue("@intAprobSal", objEnAlm.intAprobSal);
                da.SelectCommand.Parameters.AddWithValue("@intAuditIng", objEnAlm.intAuditIng);
                da.SelectCommand.Parameters.AddWithValue("@intAuditSal", objEnAlm.intAuditSal);

                da.SelectCommand.ExecuteNonQuery();
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
        }

        public DataTable ListaConfigAlmacen(int idEmpresa, int idUsuario, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_CONFIG_ALMACEN_Q01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);
                da.SelectCommand.Parameters.AddWithValue("@intIdUsu", idUsuario);
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
