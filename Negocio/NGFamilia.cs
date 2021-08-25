using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidad;

namespace Negocio
{
    public class NGFamilia
    {
        private string _strConString = string.Empty;

        public NGFamilia(string p_pStrConString)
        {
            _strConString = p_pStrConString;
        }

        public DataTable Familia (int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAFamilia obj = new Datos.DAFamilia(_strConString);
            tbl = obj.ListaFamilia(idEmpresa, ref blnTodoOK);
            return tbl;
        }

        public DataTable FamiliaTodo(ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAFamilia obj = new Datos.DAFamilia(_strConString);
            tbl = obj.ListaFamiliaTodo(ref blnTodoOK);
            return tbl;
        }

        public DataTable FamiliaAcceso(int intIdEmp, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAFamilia obj = new Datos.DAFamilia(_strConString);
            tbl = obj.ListaFamiliaAcc(intIdEmp, ref blnTodoOK);
            return tbl;
        }

        public DataTable FiltrarFamilia(string filtro, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAFamilia obj = new Datos.DAFamilia(_strConString);
            tbl = obj.ListaFiltrar(filtro, ref blnTodoOK);
            return tbl;
        }

        public DataTable BuscarFamilia(int intIdFamilia, ref bool blnTodoOK)
        {

            DataTable tbl = new DataTable();
            Datos.DAFamilia obj = new Datos.DAFamilia(_strConString);

            tbl = obj.BuscarFamilia(intIdFamilia, ref blnTodoOK);

            return tbl;
        }

        public void InsertarFamilia(ENFamilia objEnFamilia, int idEmpresa, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DAFamilia obj = new Datos.DAFamilia(_strConString);
            obj.InsertarFamilia(objEnFamilia, idEmpresa, ref mensaje, ref blnTodoOK);

        }

        public void EditarFamilia(ENFamilia objEnUni, ref bool blnTodoOK)
        {
            Datos.DAFamilia obj = new Datos.DAFamilia(_strConString);
            obj.EditarFamilia(objEnUni, ref blnTodoOK);

        }

        public void EliminarFamilia(int idSeleccion, int idUsuario, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DAFamilia obj = new Datos.DAFamilia(_strConString);
            obj.EliminarFamilia(idSeleccion, idUsuario, ref mensaje, ref blnTodoOK);

        }

        public DataTable FamiliaCombo(string maestro, ref bool blnTodoOK)
        {

            DataTable tbl = new DataTable();
            Datos.DAFamilia obj = new Datos.DAFamilia(_strConString);

            tbl = obj.FamiliaCombo(maestro, ref blnTodoOK);

            return tbl;
        }
    }
}
