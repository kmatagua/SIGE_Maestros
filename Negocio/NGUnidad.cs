using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidad;

namespace Negocio
{
    public class NGUnidad
    {
        private string _strConString = string.Empty;

        public NGUnidad(string p_pStrConString)
        {
            _strConString = p_pStrConString;
        }

        public DataTable Unidad (int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAUnidad obj = new Datos.DAUnidad(_strConString);
            tbl = obj.ListaUnidad(idEmpresa, ref blnTodoOK);
            return tbl;
        }

        public DataTable UnidadTodo(ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAUnidad obj = new Datos.DAUnidad(_strConString);
            tbl = obj.ListaUnidadTodo(ref blnTodoOK);
            return tbl;
        }

        public DataTable UnidadAcceso(int intIdEmp, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAUnidad obj = new Datos.DAUnidad(_strConString);
            tbl = obj.ListaUniAcc(intIdEmp, ref blnTodoOK);
            return tbl;
        }

        public DataTable FiltrarUnidad(string filtro, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAUnidad obj = new Datos.DAUnidad(_strConString);
            tbl = obj.ListaFiltrar(filtro, ref blnTodoOK);
            return tbl;
        }

        public DataTable BuscarUnidad(int intIdUni, ref bool blnTodoOK)
        {

            DataTable tbl = new DataTable();
            Datos.DAUnidad obj = new Datos.DAUnidad(_strConString);

            tbl = obj.BuscarUnidad(intIdUni, ref blnTodoOK);

            return tbl;
        }

        public void InsertarUnidad(ENUnidad objEnUni, int idEmpresa, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DAUnidad obj = new Datos.DAUnidad(_strConString);
            obj.InsertarUnidad(objEnUni, idEmpresa, ref mensaje, ref blnTodoOK);

        }

        public void EditarUnidad(ENUnidad objEnUni, ref bool blnTodoOK)
        {
            Datos.DAUnidad obj = new Datos.DAUnidad(_strConString);
            obj.EditarUnidad(objEnUni, ref blnTodoOK);

        }

        public void EliminarUnidad(int idSeleccion, int idUsuario, ref bool blnTodoOK)
        {
            Datos.DAUnidad obj = new Datos.DAUnidad(_strConString);
            obj.EliminarUnidad(idSeleccion, idUsuario, ref blnTodoOK);

        }

        public DataTable ComboUnidad(int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAUnidad obj = new Datos.DAUnidad(_strConString);
            tbl = obj.ListaComboUnidad(idEmpresa, ref blnTodoOK);
            return tbl;
        }
    }
}
