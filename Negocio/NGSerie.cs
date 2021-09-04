using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidad;

namespace Negocio
{
    public class NGSerie
    {
        private string _strConString = string.Empty;

        public NGSerie(string p_pStrConString)
        {
            _strConString = p_pStrConString;
        }

        public DataTable SeriePorOrden (int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DASerie obj = new Datos.DASerie(_strConString);
            tbl = obj.ListaSeriePorOrden(idEmpresa, ref blnTodoOK);
            return tbl;
        }

        
    }
}
