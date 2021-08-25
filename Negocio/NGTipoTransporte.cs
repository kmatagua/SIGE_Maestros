using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidad;

namespace Negocio
{
    public class NGTipoTransporte
    {
        private string _strConString = string.Empty;

        public NGTipoTransporte(string p_pStrConString)
        {
            _strConString = p_pStrConString;
        }

        public DataTable TipoTransp(ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DATipoTransporte obj = new Datos.DATipoTransporte(_strConString);
            tbl = obj.TipoTransp(ref blnTodoOK);
            return tbl;
        }

        
    }
}
