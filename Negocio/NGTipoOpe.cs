using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidad;
using Datos;

namespace Negocio
{
    public class NGTipoOpe
    {
        private string _strConString = string.Empty;

        public NGTipoOpe(string p_pStrConString)
        {
            _strConString = p_pStrConString;
        }

        public DataTable TipoOpeCombo(ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DATipoOpe obj = new Datos.DATipoOpe(_strConString);
            tbl = obj.ListaTipoOpe(ref blnTodoOK);
            return tbl;
        }

    }
}
