using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidad;

namespace Negocio
{
    public class NGCanalDist
    {
        private string _strConString = string.Empty;

        public NGCanalDist(string p_pStrConString)
        {
            _strConString = p_pStrConString;
        }

        

        public DataTable GridCanalDist(int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DACanalDist obj = new Datos.DACanalDist(_strConString);
            tbl = obj.ListaGridCanalDist(idEmpresa, ref blnTodoOK);
            return tbl;
        }

        public DataTable CanalDistAccesoUsu(int idUsuario, int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DACanalDist obj = new Datos.DACanalDist(_strConString);
            tbl = obj.ListaCanalDistAccUsu(idUsuario, idEmpresa, ref blnTodoOK);
            return tbl;
        }

        public DataTable UniNegAcceso(int intIdEmp, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAUndNegocio obj = new Datos.DAUndNegocio(_strConString);
            tbl = obj.ListaUniNegAcc(intIdEmp, ref blnTodoOK);
            return tbl;
        }

        
    }
}
