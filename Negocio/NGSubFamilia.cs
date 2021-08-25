using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidad;

namespace Negocio
{
    public class NGSubFamilia
    {
        private string _strConString = string.Empty;

        public NGSubFamilia(string p_pStrConString)
        {
            _strConString = p_pStrConString;
        }

        public DataTable SubFamilia(ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DASubFamilia obj = new Datos.DASubFamilia(_strConString);
            tbl = obj.ListaSubFamilia(ref blnTodoOK);
            return tbl;
        }

        public DataTable comboSubFamilia(int idFamilia, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DASubFamilia obj = new Datos.DASubFamilia(_strConString);
            tbl = obj.comboSubFamilia(idFamilia, ref blnTodoOK);
            return tbl;
        }

        public DataTable FiltrarSubFamilia(string filtro, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DASubFamilia obj = new Datos.DASubFamilia(_strConString);
            tbl = obj.ListaFiltrar(filtro, ref blnTodoOK);
            return tbl;
        }

        public DataTable BuscarSubFamilia(int intIdSubFamilia, ref bool blnTodoOK)
        {

            DataTable tbl = new DataTable();
            Datos.DASubFamilia obj = new Datos.DASubFamilia(_strConString);

            tbl = obj.BuscarSubFamilia(intIdSubFamilia, ref blnTodoOK);

            return tbl;
        }

        public void InsertarSubFamiliaFamilia(int idFamilia, DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DAEmpresa obj = new Datos.DAEmpresa(_strConString);
            obj.InsertarUniEmpresa(idFamilia, tabla, ref blnTodoOK);

        }

        public DataTable SubFamiliaAcceso(int idFamilia, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAFamilia obj = new Datos.DAFamilia(_strConString);
            tbl = obj.ListaSubFamiliaAcc(idFamilia, ref blnTodoOK);
            return tbl;
        }

        public void InsertarSubFamilia(ENSubFamilia objEnSubFamilia, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DASubFamilia obj = new Datos.DASubFamilia(_strConString);
            obj.InsertarSubFamilia(objEnSubFamilia, ref mensaje, ref blnTodoOK);

        }

        public void EditarSubFamilia(ENSubFamilia objEnSubFamilia, ref bool blnTodoOK)
        {
            Datos.DASubFamilia obj = new Datos.DASubFamilia(_strConString);
            obj.EditarSubFamilia(objEnSubFamilia, ref blnTodoOK);

        }

        public void EliminarSubFamilia(int idSeleccion, int idUsuario, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DASubFamilia obj = new Datos.DASubFamilia(_strConString);
            obj.EliminarSubFamilia(idSeleccion, idUsuario, ref mensaje, ref blnTodoOK);

        }
    }
}
