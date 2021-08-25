using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidad;
using Datos;

namespace Negocio
{
    public class NGOperacion
    {
        private string _strConString = string.Empty;

        public NGOperacion(string p_pStrConString)
        {
            _strConString = p_pStrConString;
        }

        public DataTable OperacionCombo(ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAOperacion obj = new Datos.DAOperacion(_strConString);
            tbl = obj.ListaOperacion(ref blnTodoOK);
            return tbl;
        }

    }
}
