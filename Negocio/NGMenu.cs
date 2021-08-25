using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidad;

namespace Negocio
{
    public class NGMenu
    {
        private string _strConString = string.Empty;

        public NGMenu(string p_pStrConString)
        {
            _strConString = p_pStrConString;
        }

        public DataTable Menu (ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAMenu obj = new Datos.DAMenu(_strConString);
            tbl = obj.ListaMenu(ref blnTodoOK);
            return tbl;
        }

        public DataTable GridMenu(ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAMenu obj = new Datos.DAMenu(_strConString);
            tbl = obj.ListaGridMenu(ref blnTodoOK);
            return tbl;
        }

        //public DataTable MenuAcceso(int intIdEmp, ref bool blnTodoOK)
        //{
        //    DataTable tbl = new DataTable();
        //    Datos.DAMenu obj = new Datos.DAMenu(_strConString);
        //    tbl = obj.ListaMenuAcc(intIdEmp, ref blnTodoOK);
        //    return tbl;
        //}

        public DataTable MenuAccesoUsu(int idUsuario, int idEmpresa, ref DataTable p_tbl, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAMenu obj = new Datos.DAMenu(_strConString);
            tbl = obj.ListaMenuAccUsu(idUsuario, idEmpresa, ref p_tbl, ref blnTodoOK);
            return tbl;
        }

        public DataTable BtnAccesoMenu(int idMenu, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAMenu obj = new Datos.DAMenu(_strConString);
            tbl = obj.ListaBtnAccMenu(idMenu, ref blnTodoOK);
            return tbl;
        }


        public DataTable FiltrarMenu(string filtro, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAMenu obj = new Datos.DAMenu(_strConString);
            tbl = obj.ListaFiltrar(filtro, ref blnTodoOK);
            return tbl;
        }

        public DataTable BuscarMenu(int intIdMenu, ref bool blnTodoOK)
        {

            DataTable tbl = new DataTable();
            Datos.DAMenu obj = new Datos.DAMenu(_strConString);

            tbl = obj.BuscarMenu(intIdMenu, ref blnTodoOK);

            return tbl;
        }

        public void InsertarMenu(ENMenu objEnUni, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DAMenu obj = new Datos.DAMenu(_strConString);
            obj.InsertarMenu(objEnUni, ref mensaje, ref blnTodoOK);

        }

        public void InsertarBtnMenu(int idUsuario, DataTable tabla_Btn, ref bool blnTodoOK)
        {
            Datos.DAMenu obj = new Datos.DAMenu(_strConString);
            obj.InsertarBtnMenu(idUsuario, tabla_Btn, ref blnTodoOK);

        }

        public void EditarMenu(ENMenu objEnUni, ref bool blnTodoOK)
        {
            Datos.DAMenu obj = new Datos.DAMenu(_strConString);
            obj.EditarMenu(objEnUni, ref blnTodoOK);

        }

        public void EliminarMenu(int idSeleccion, int idUsuario, ref bool blnTodoOK)
        {
            Datos.DAMenu obj = new Datos.DAMenu(_strConString);
            obj.EliminarMenu(idSeleccion, idUsuario, ref blnTodoOK);

        }

        public void Borrar(int idSeleccion,ref bool blnTodoOK)
        {
            Datos.DAMenu obj = new Datos.DAMenu(_strConString);
            obj.Borrar(idSeleccion,ref blnTodoOK);

        }

        public DataTable MenuAcceso(int idUsuario, int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAMenu obj = new Datos.DAMenu(_strConString);
            tbl = obj.MenuAcceso(idUsuario, idEmpresa, ref blnTodoOK);
            return tbl;
        }
    }
}
