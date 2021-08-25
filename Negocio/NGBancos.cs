using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidad;
namespace Negocio
{
    public class NGBancos
    {
        private string _strConString = string.Empty;

        public NGBancos(string p_pStrConString)
        {
            _strConString = p_pStrConString;
        }

        public DataTable Bancos (ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DABancos obj = new Datos.DABancos(_strConString);
            tbl = obj.ListaBancos(ref blnTodoOK);
            return tbl;
        }

        public DataTable BancosTodo(ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DABancos obj = new Datos.DABancos(_strConString);
            tbl = obj.ListaBancosTodo(ref blnTodoOK);
            return tbl;
        }

        public DataTable BancosAcceso(int intIdEmp, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DABancos obj = new Datos.DABancos(_strConString);
            tbl = obj.ListaBancosAcc(intIdEmp, ref blnTodoOK);
            return tbl;
        }

        public DataTable FiltrarBancos(string filtro, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DABancos obj = new Datos.DABancos(_strConString);
            tbl = obj.ListaFiltrar(filtro, ref blnTodoOK);
            return tbl;
        }

        public DataTable BuscarBancos(int intIdBancos, ref bool blnTodoOK)
        {

            DataTable tbl = new DataTable();
            Datos.DABancos obj = new Datos.DABancos(_strConString);

            tbl = obj.BuscarBancos(intIdBancos, ref blnTodoOK);

            return tbl;
        }

        public void InsertarBancos(ENBancos objEnBancos, int idEmpresa, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DABancos obj = new Datos.DABancos(_strConString);
            obj.InsertarBancos(objEnBancos, idEmpresa, ref mensaje, ref blnTodoOK);

        }

        public void EditarBancos(ENBancos objEnUni, ref bool blnTodoOK)
        {
            Datos.DABancos obj = new Datos.DABancos(_strConString);
            obj.EditarBancos(objEnUni, ref blnTodoOK);

        }

        public void EliminarBancos(int idSeleccion, int idUsuario, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DABancos obj = new Datos.DABancos(_strConString);
            obj.EliminarBancos(idSeleccion, idUsuario, ref mensaje, ref blnTodoOK);

        }
    }
}
