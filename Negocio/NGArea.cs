using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidad;

namespace Negocio
{
    public class NGArea
    {
        private string _strConString = string.Empty;

        public NGArea(string p_pStrConString)
        {
            _strConString = p_pStrConString;
        }

        public DataTable Area(ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAArea obj = new Datos.DAArea(_strConString);
            tbl = obj.ListaArea(ref blnTodoOK);
            return tbl;
        }

        public DataTable UndNegocioEmp(int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAUndNegocio obj = new Datos.DAUndNegocio(_strConString);
            tbl = obj.ListaUndNegocioEmp(idEmpresa, ref blnTodoOK);
            return tbl;
        }

        public DataTable UndNegocioTodo(ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAUndNegocio obj = new Datos.DAUndNegocio(_strConString);
            tbl = obj.ListaUndNegocioTodo(ref blnTodoOK);
            return tbl;
        }

        public DataTable GridArea(ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAArea obj = new Datos.DAArea(_strConString);
            tbl = obj.ListaGridArea(ref blnTodoOK);
            return tbl;
        }

        public DataTable AreaAccesoUsu(int idUsuario, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAArea obj = new Datos.DAArea(_strConString);
            tbl = obj.ListaAreaAccUsu(idUsuario, ref blnTodoOK);
            return tbl;
        }

        public DataTable UniNegAcceso(int intIdEmp, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAUndNegocio obj = new Datos.DAUndNegocio(_strConString);
            tbl = obj.ListaUniNegAcc(intIdEmp, ref blnTodoOK);
            return tbl;
        }

        public DataTable FiltrarUndNegocio(string filtro, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAUndNegocio obj = new Datos.DAUndNegocio(_strConString);
            tbl = obj.ListaFiltrar(filtro, ref blnTodoOK);
            return tbl;
        }

        public DataTable BuscarArea(int intIdArea, ref bool blnTodoOK)
        {

            DataTable tbl = new DataTable();
            Datos.DAArea obj = new Datos.DAArea(_strConString);

            tbl = obj.BuscarArea(intIdArea, ref blnTodoOK);

            return tbl;
        }

        public void InsertarArea(ENArea objEnArea, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DAArea obj = new Datos.DAArea(_strConString);
            obj.InsertarArea(objEnArea, ref mensaje, ref blnTodoOK);

        }

        public void EditarArea(ENArea objEnArea, ref bool blnTodoOK)
        {
            Datos.DAArea obj = new Datos.DAArea(_strConString);
            obj.EditarArea(objEnArea, ref blnTodoOK);

        }

        public void EliminarArea(int idSeleccion, int idUsuario, ref bool blnTodoOK)
        {
            Datos.DAArea obj = new Datos.DAArea(_strConString);
            obj.EliminarArea(idSeleccion, idUsuario, ref blnTodoOK);

        }

    }
}
