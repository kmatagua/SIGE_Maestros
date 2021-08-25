using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidad;
using Datos;

namespace Negocio
{
    public class NGTipoDoc
    {
        private string _strConString = string.Empty;

        public NGTipoDoc(string p_pStrConString)
        {
            _strConString = p_pStrConString;
        }
        
        public DataTable ListaTipoDoc(int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DATipoDoc obj = new Datos.DATipoDoc(_strConString);
            tbl = obj.ListaTipoDoc(idEmpresa, ref blnTodoOK);
            return tbl;
        }

        public DataTable BuscarTipoDoc(int intIdTipoDoc, ref bool blnTodoOK)
        {

            DataTable tbl = new DataTable();
            Datos.DATipoDoc obj = new Datos.DATipoDoc(_strConString);

            tbl = obj.BuscarTipoDoc(intIdTipoDoc, ref blnTodoOK);

            return tbl;
        }

        public void InsertarTipoDoc(int idEmpresa, ENTipoDoc objEN, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DATipoDoc obj = new Datos.DATipoDoc(_strConString);
            obj.InsertarTipoDoc(idEmpresa, objEN, ref mensaje, ref blnTodoOK);

        }

        public void EditarTipoDoc(ENTipoDoc objEn, ref bool blnTodoOK)
        {
            Datos.DATipoDoc obj = new Datos.DATipoDoc(_strConString);
            obj.EditarTipoDoc(objEn, ref blnTodoOK);

        }

        public void EliminarTipoDoc(int idSeleccion, int idUsuario, ref bool blnTodoOK)
        {
            Datos.DATipoDoc obj = new Datos.DATipoDoc(_strConString);
            obj.EliminarTipoDoc(idSeleccion, idUsuario, ref blnTodoOK);

        }

        public DataTable TipoDoc(ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DATipoDoc obj = new Datos.DATipoDoc(_strConString);
            tbl = obj.TipoDoc(ref blnTodoOK);
            return tbl;
        }

        public DataTable TipoDocAcceso(int intIdEmp, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DATipoDoc obj = new Datos.DATipoDoc(_strConString);
            tbl = obj.ListaTipoDocAcc(intIdEmp, ref blnTodoOK);
            return tbl;
        }
    }
}
