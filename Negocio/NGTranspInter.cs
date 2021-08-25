using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidad;

namespace Negocio
{
    public class NGTranspInter
    {
        private string _strConString = string.Empty;

        public NGTranspInter(string p_pStrConString)
        {
            _strConString = p_pStrConString;
        }

        public DataTable TranspInter(int intIdTipoTransp, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DATranspInter obj = new Datos.DATranspInter(_strConString);
            tbl = obj.TranspInter(intIdTipoTransp, ref blnTodoOK);
            return tbl;
        }

        
    }
}
