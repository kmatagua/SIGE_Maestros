using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidad;

namespace Negocio
{
    public class NGTipoCambio
    {
        private string _strConString = string.Empty;

        public NGTipoCambio(string p_pStrConString)
        {
            _strConString = p_pStrConString;
        }

        public DataTable TipoCambio(ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DATipoCambio obj = new Datos.DATipoCambio(_strConString);
            tbl = obj.ListaTipoCambio(ref blnTodoOK);
            return tbl;
        }


        public DataTable FiltrarTipoCambio(string filtro, int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DATipoCambio obj = new Datos.DATipoCambio(_strConString);
            tbl = obj.ListaFiltrar(filtro, idEmpresa, ref blnTodoOK);
            return tbl;
        }


        public DataTable BuscarTipoCambio(int intIdTipoCambio, ref bool blnTodoOK)
        {

            DataTable tbl = new DataTable();
            Datos.DATipoCambio obj = new Datos.DATipoCambio(_strConString);

            tbl = obj.BuscarTipoCambio(intIdTipoCambio, ref blnTodoOK);

            return tbl;
        }

        public void InsertarTipoCambio(ENTipoCambio objEnAlm, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DATipoCambio obj = new Datos.DATipoCambio(_strConString);
            obj.InsertarTipoCambio(objEnAlm, ref mensaje, ref blnTodoOK);

        }

        public void EditarTipoCambio(ENTipoCambio objEnAlm, ref bool blnTodoOK)
        {
            Datos.DATipoCambio obj = new Datos.DATipoCambio(_strConString);
            obj.EditarTipoCambio(objEnAlm, ref blnTodoOK);

        }

        public void EliminarTipoCambio(int idSeleccion, int idUsuario, ref bool blnTodoOK)
        {
            Datos.DATipoCambio obj = new Datos.DATipoCambio(_strConString);
                obj.EliminarTipoCambio(idSeleccion, idUsuario, ref blnTodoOK);

        }
    }
}
