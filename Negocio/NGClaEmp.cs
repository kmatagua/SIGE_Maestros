using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidad;

namespace Negocio
{
    public class NGClaEmp
    {
        private string _strConString = string.Empty;

        public NGClaEmp(string p_pStrConString)
        {
            _strConString = p_pStrConString;
        }

        public DataTable ClaEmp (ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAClaEmp obj = new Datos.DAClaEmp(_strConString);
            tbl = obj.ListaClaEmp(ref blnTodoOK);
            return tbl;
        }

        public DataTable ClaEmpAcceso(int intIdEmp, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAClaEmp obj = new Datos.DAClaEmp(_strConString);
            tbl = obj.ListaClaEmpAcc(intIdEmp, ref blnTodoOK);
            return tbl;
        }

        public DataTable FiltrarClaEmp(string filtro, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAClaEmp obj = new Datos.DAClaEmp(_strConString);
            tbl = obj.ListaFiltrar(filtro, ref blnTodoOK);
            return tbl;
        }

        public DataTable BuscarClaEmp(int intIdClaEmp, ref bool blnTodoOK)
        {

            DataTable tbl = new DataTable();
            Datos.DAClaEmp obj = new Datos.DAClaEmp(_strConString);

            tbl = obj.BuscarClaEmp(intIdClaEmp, ref blnTodoOK);

            return tbl;
        }

        public void InsertarClaEmp(ENClaEmp objEnClaEmp, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DAClaEmp obj = new Datos.DAClaEmp(_strConString);
            obj.InsertarClaEmp(objEnClaEmp, ref mensaje, ref blnTodoOK);

        }

        public void EditarClaEmp(ENClaEmp objEnClaEmp, ref bool blnTodoOK)
        {
            Datos.DAClaEmp obj = new Datos.DAClaEmp(_strConString);
            obj.EditarClaEmp(objEnClaEmp, ref blnTodoOK);

        }

        public void EliminarClaEmp(int idSeleccion, int idUsuario, ref bool blnTodoOK)
        {
            Datos.DAClaEmp obj = new Datos.DAClaEmp(_strConString);
            obj.EliminarClaEmp(idSeleccion, idUsuario, ref blnTodoOK);

        }

        public DataTable ComboClaEmp(ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAClaEmp obj = new Datos.DAClaEmp(_strConString);
            tbl = obj.ComboClaEmp(ref blnTodoOK);
            return tbl;
        }

        public void InsertarEmpleadoClaEmp(int idClaEmp, DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DAClaEmp obj = new Datos.DAClaEmp(_strConString);
            obj.InsertarEmpleadoClaEmp(idClaEmp, tabla, ref blnTodoOK);

        }
    }
}
