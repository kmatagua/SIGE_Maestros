using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidad;

namespace Negocio
{
    public class NGCondicion
    {
        private string _strConString = string.Empty;

        public NGCondicion(string p_pStrConString)
        {
            _strConString = p_pStrConString;
        }

        public DataTable Condicion (ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DACondicion obj = new Datos.DACondicion(_strConString);
            tbl = obj.ListaCondicion(ref blnTodoOK);
            return tbl;
        }

        //public DataTable CondicionAcceso(int intIdEmp, ref bool blnTodoOK)
        //{
        //    DataTable tbl = new DataTable();
        //    Datos.DACondicion obj = new Datos.DACondicion(_strConString);
        //    tbl = obj.ListaUniAcc(intIdEmp, ref blnTodoOK);
        //    return tbl;
        //}

        public DataTable FiltrarCondicion(string filtro, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DACondicion obj = new Datos.DACondicion(_strConString);
            tbl = obj.ListaFiltrar(filtro, ref blnTodoOK);
            return tbl;
        }

        public DataTable BuscarCondicion(int intIdCondicion, ref bool blnTodoOK)
        {

            DataTable tbl = new DataTable();
            Datos.DACondicion obj = new Datos.DACondicion(_strConString);

            tbl = obj.BuscarCondicion(intIdCondicion, ref blnTodoOK);

            return tbl;
        }

        public void InsertarCondicion(ENCondicion objEnCondicion, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DACondicion obj = new Datos.DACondicion(_strConString);
            obj.InsertarCondicion(objEnCondicion, ref mensaje, ref blnTodoOK);

        }

        public void EditarCondicion(ENCondicion objEnUni, ref bool blnTodoOK)
        {
            Datos.DACondicion obj = new Datos.DACondicion(_strConString);
            obj.EditarCondicion(objEnUni, ref blnTodoOK);

        }

        public void EliminarCondicion(int idSeleccion, int idUsuario, ref bool blnTodoOK)
        {
            Datos.DACondicion obj = new Datos.DACondicion(_strConString);
            obj.EliminarCondicion(idSeleccion, idUsuario, ref blnTodoOK);

        }
    }
}
