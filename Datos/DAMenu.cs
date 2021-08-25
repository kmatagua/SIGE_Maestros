using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    public class DAMenu
    {
        private string _pStrConString = string.Empty;

        public DAMenu(string p_pStrConString)
        {
            _pStrConString = p_pStrConString;
        }

        public DataTable ListaMenu(ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_MENU_Q01", cn);
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

        public DataTable ListaGridMenu(ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_USUMENU_Q01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //da.SelectCommand.Parameters.AddWithValue("@intIdUsu", idUsuario);
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

        //public DataTable ListaMenuAcc(int intIdEmp, ref bool pBlnTodoOk)
        //{
        //    SqlConnection cn = new SqlConnection(_pStrConString);
        //    pBlnTodoOk = false;
        //    DataTable tbl = new DataTable();
        //    try
        //    {
        //        cn.Open();
        //        SqlDataAdapter da = new SqlDataAdapter("SP_Menu_EMP_Q01", cn);
        //        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        //        da.SelectCommand.Parameters.AddWithValue("@intIdEmp", intIdEmp);
        //        da.Fill(tbl);
        //        pBlnTodoOk = true;
        //        cn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        pBlnTodoOk = false;
        //    }
        //    return tbl;
        //}

        public DataTable ListaMenuAccUsu(int idUsuario, int idEmpresa, ref DataTable p_tbl, ref bool pBlnTodoOk)
        {
            p_tbl = new DataTable();
            p_tbl.Columns.Add("id");
            p_tbl.Columns.Add("intIdUsuBtnMenu");
            p_tbl.Columns.Add("intIdUsuMenu");
            p_tbl.Columns.Add("valor");
            p_tbl.Columns.Add("boton");

            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_MENU_USU_Q01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdUsu", idUsuario);
                da.SelectCommand.Parameters.AddWithValue("@intIdEmp", idEmpresa);
                da.Fill(tbl);
                //************************
                foreach (DataRow row in tbl.Rows)
                {
                    DataTable tbl1 = new DataTable();
                    SqlDataAdapter da1 = new SqlDataAdapter("SP_BOTONES_Q01", cn);
                    da1.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da1.SelectCommand.Parameters.AddWithValue("@intIdUsuMenu", row["intIdUsuMenu"]);
                    da1.Fill(tbl1);

                    foreach (DataRow row1 in tbl1.Rows)
                    {
                        DataRow row2 = p_tbl.NewRow();
                        row2["id"] = row1["id"].ToString();
                        row2["intIdUsuBtnMenu"] = row1["intIdUsuBtnMenu"].ToString();
                        row2["intIdUsuMenu"] = row1["intIdUsuMenu"].ToString();
                        row2["valor"] = row1["valor"].ToString();
                        row2["boton"] = row1["boton"].ToString();
                        p_tbl.Rows.Add(row2);
                    }
                }
                //************************
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
            return tbl;
        }

        public DataTable ListaBtnAccMenu(int idMenu, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_BOTONES_Q01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdUsuMenu", idMenu);
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
                SqlDataAdapter da = new SqlDataAdapter("SP_MENU_Q03", cn);
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

        public DataTable BuscarMenu(int intIdMenu, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable rowTbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_MENU_Q02", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdMenu", intIdMenu);
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

        public void InsertarMenu(ENMenu objEnMenu, ref string mensaje, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_MENU_I01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@strCoMenu", objEnMenu.strCoMenu);
                da.SelectCommand.Parameters.AddWithValue("@strNoMenu", objEnMenu.strNoMenu);
                da.SelectCommand.Parameters.AddWithValue("@intEstado", objEnMenu.intEstado);
                da.SelectCommand.Parameters.AddWithValue("@intIdUsuCr", objEnMenu.intIdUsuCr);
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

        public void InsertarBtnMenu(int idUsuario, DataTable tabla_Btn, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_BOTONES_I01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                foreach (DataRow row2 in tabla_Btn.Rows)
                {
                    da.SelectCommand.Parameters.Clear();
                    da.SelectCommand.Parameters.AddWithValue("@idValor", Convert.ToInt32(row2["id"].ToString()));
                    da.SelectCommand.Parameters.AddWithValue("@valor", Convert.ToInt32(row2["valor"].ToString()));
                    da.SelectCommand.Parameters.AddWithValue("@intIdUsuMenu", Convert.ToInt32(row2["intIdUsuMenu"].ToString()));
                    da.SelectCommand.ExecuteNonQuery();
                }


               
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
        }

        public void EditarMenu(ENMenu objEnMenu, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_MENU_U01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdMenu", objEnMenu.intIdMenu);
                da.SelectCommand.Parameters.AddWithValue("@strCoMenu", objEnMenu.strCoMenu);
                da.SelectCommand.Parameters.AddWithValue("@strNoMenu", objEnMenu.strNoMenu);
                da.SelectCommand.Parameters.AddWithValue("@intEstado", objEnMenu.intEstado);
                da.SelectCommand.Parameters.AddWithValue("@intIdUsuMf", objEnMenu.intIdUsuMf);
                
                da.SelectCommand.ExecuteNonQuery();
                pBlnTodoOk = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                pBlnTodoOk = false;
            }
        }

        public void EliminarMenu(int idSeleccion, int idUsuario, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_MENU_UD01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdMenu", idSeleccion);
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


        public void Borrar(int idSeleccion, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_MENU_BORRAR_D01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdMenu", idSeleccion);
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


        public DataTable MenuAcceso(int idUsuario, int idEmpresa, ref bool pBlnTodoOk)
        {
            SqlConnection cn = new SqlConnection(_pStrConString);
            pBlnTodoOk = false;
            DataTable tbl = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_USUMENU_ACCESO_Q01", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@intIdUsu", idUsuario);
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
    }
}
