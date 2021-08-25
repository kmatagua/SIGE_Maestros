using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidad;

namespace Negocio
{
    public class NGClaArt
    {
        private string _strConString = string.Empty;

        public NGClaArt(string p_pStrConString)
        {
            _strConString = p_pStrConString;
        }

        public DataTable ClaArt (ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAClaArt obj = new Datos.DAClaArt(_strConString);
            tbl = obj.ListaClaArt(ref blnTodoOK);
            return tbl;
        }

        public DataTable ClaArtAcceso(int intIdEmp, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAClaArt obj = new Datos.DAClaArt(_strConString);
            tbl = obj.ListaClaArtAcc(intIdEmp, ref blnTodoOK);
            return tbl;
        }

        public DataTable FiltrarClaArt(string filtro, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAClaArt obj = new Datos.DAClaArt(_strConString);
            tbl = obj.ListaFiltrar(filtro, ref blnTodoOK);
            return tbl;
        }

        public DataTable BuscarClaArt(int intIdClaArt, ref bool blnTodoOK)
        {

            DataTable tbl = new DataTable();
            Datos.DAClaArt obj = new Datos.DAClaArt(_strConString);

            tbl = obj.BuscarClaArt(intIdClaArt, ref blnTodoOK);

            return tbl;
        }

        public void InsertarClaArt(ENClaArt objEnClaArt, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DAClaArt obj = new Datos.DAClaArt(_strConString);
            obj.InsertarClaArt(objEnClaArt, ref mensaje, ref blnTodoOK);

        }

        public void EditarClaArt(ENClaArt objEnClaArt, ref bool blnTodoOK)
        {
            Datos.DAClaArt obj = new Datos.DAClaArt(_strConString);
            obj.EditarClaArt(objEnClaArt, ref blnTodoOK);

        }

        public void EliminarClaArt(int idSeleccion, int idUsuario, ref bool blnTodoOK)
        {
            Datos.DAClaArt obj = new Datos.DAClaArt(_strConString);
            obj.EliminarClaArt(idSeleccion, idUsuario, ref blnTodoOK);

        }

        public DataTable ClasificacionCombo(ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAClaArt obj = new Datos.DAClaArt(_strConString);
            tbl = obj.ListaClaArt(ref blnTodoOK);
            return tbl;
        }
    }
}
