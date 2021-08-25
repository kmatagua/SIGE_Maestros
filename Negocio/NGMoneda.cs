using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidad;

namespace Negocio
{
    public class NGMoneda
    {
        private string _strConString = string.Empty;

        public NGMoneda(string p_pStrConString)
        {
            _strConString = p_pStrConString;
        }

        public DataTable Moneda(ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAMoneda obj = new Datos.DAMoneda(_strConString);
            tbl = obj.ListaMoneda(ref blnTodoOK);
            return tbl;
        }

        public DataTable FiltrarMoneda(string filtro, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAMoneda obj = new Datos.DAMoneda(_strConString);
            tbl = obj.ListaFiltrar(filtro, ref blnTodoOK);
            return tbl;
        }

        public DataTable BuscarMoneda(int intIdMoneda, ref bool blnTodoOK)
        {

            DataTable tbl = new DataTable();
            Datos.DAMoneda obj = new Datos.DAMoneda(_strConString);

            tbl = obj.BuscarMoneda(intIdMoneda, ref blnTodoOK);

            return tbl;
        }

        public void InsertarMoneda(ENMoneda objEnMoneda, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DAMoneda obj = new Datos.DAMoneda(_strConString);
            obj.InsertarMoneda(objEnMoneda, ref mensaje, ref blnTodoOK);

        }

        public void EditarMoneda(ENMoneda objEnMoneda, ref bool blnTodoOK)
        {
            Datos.DAMoneda obj = new Datos.DAMoneda(_strConString);
            obj.EditarMoneda(objEnMoneda, ref blnTodoOK);

        }

        public void EliminarMoneda(int idSeleccion, int idUsuario, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DAMoneda obj = new Datos.DAMoneda(_strConString);
            obj.EliminarMoneda(idSeleccion, idUsuario, ref mensaje, ref blnTodoOK);

        }
    }
}
