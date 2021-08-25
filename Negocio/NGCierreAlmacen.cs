using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidad;

namespace Negocio
{
    public class NGCierreAlmacen
    {
        private string _strConString = string.Empty;

        public NGCierreAlmacen(string p_pStrConString)
        {
            _strConString = p_pStrConString;
        }

        public DataTable CierreAlmacen(ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DACierreAlmacen obj = new Datos.DACierreAlmacen(_strConString);
            tbl = obj.ListaCierreAlmacen(ref blnTodoOK);
            return tbl;
        }

        public DataTable FiltrarSede(string filtro, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DASede obj = new Datos.DASede(_strConString);
            tbl = obj.ListaFiltrar(filtro, ref blnTodoOK);
            return tbl;
        }

        public DataTable BuscarCierreAlmacen(int intIdCierreAlmacen, ref bool blnTodoOK)
        {

            DataTable tbl = new DataTable();
            Datos.DACierreAlmacen obj = new Datos.DACierreAlmacen(_strConString);

            tbl = obj.BuscarCierreAlmacen(intIdCierreAlmacen, ref blnTodoOK);

            return tbl;
        }


        public void InsertarCierreAlmacen(ENCierreAlmacen objEn, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DACierreAlmacen obj = new Datos.DACierreAlmacen(_strConString);
            obj.InsertarCierreAlmacen(objEn, ref mensaje, ref blnTodoOK);

        }

        public void EditarCierreAlmacen(ENCierreAlmacen objEn, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DACierreAlmacen obj = new Datos.DACierreAlmacen(_strConString);
            obj.EditarCierreAlmacen(objEn, ref mensaje, ref blnTodoOK);

        }

        public void EliminarCierreAlmacen(int idSeleccion, int idUsuario, ref bool blnTodoOK)
        {
            Datos.DACierreAlmacen obj = new Datos.DACierreAlmacen(_strConString);
            obj.EliminarCierreAlmacen(idSeleccion, idUsuario, ref blnTodoOK);

        }
    }
}
