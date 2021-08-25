using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidad;

namespace Negocio
{
    public class NGMaquina
    {
        private string _strConString = string.Empty;

        public NGMaquina(string p_pStrConString)
        {
            _strConString = p_pStrConString;
        }

        public DataTable Maquina (int idEmpresa,ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAMaquina obj = new Datos.DAMaquina(_strConString);
            tbl = obj.ListaMaquina(idEmpresa, ref blnTodoOK);
            return tbl;
        }

        //public DataTable MaquinaAcceso(int intIdEmp, ref bool blnTodoOK)
        //{
        //    DataTable tbl = new DataTable();
        //    Datos.DAMaquina obj = new Datos.DAMaquina(_strConString);
        //    tbl = obj.ListaUniAcc(intIdEmp, ref blnTodoOK);
        //    return tbl;
        //}

        public DataTable FiltrarMaquina(string filtro, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAMaquina obj = new Datos.DAMaquina(_strConString);
            tbl = obj.ListaFiltrar(filtro, ref blnTodoOK);
            return tbl;
        }

        public DataTable BuscarMaquina(int intIdMaq, ref bool blnTodoOK)
        {

            DataTable tbl = new DataTable();
            Datos.DAMaquina obj = new Datos.DAMaquina(_strConString);

            tbl = obj.BuscarMaquina(intIdMaq, ref blnTodoOK);

            return tbl;
        }

        public void InsertarMaquina(ENMaquina objEnMaquina, int idEmpresa, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DAMaquina obj = new Datos.DAMaquina(_strConString);
            obj.InsertarMaquina(objEnMaquina, idEmpresa, ref mensaje, ref blnTodoOK);
        }

        public void EditarMaquina(ENMaquina objEnEmp, ref bool blnTodoOK)
        {
            Datos.DAMaquina obj = new Datos.DAMaquina(_strConString);
            obj.EditarMaquina(objEnEmp, ref blnTodoOK);

        }

        public void EliminarMaquina(int idSeleccion, int idUsuario, ref bool blnTodoOK)
        {
            Datos.DAMaquina obj = new Datos.DAMaquina(_strConString);
            obj.EliminarMaquina(idSeleccion, idUsuario, ref blnTodoOK);

        }

        public DataTable GridMaquina(ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAMaquina obj = new Datos.DAMaquina(_strConString);
            tbl = obj.ListaGridMaquina(ref blnTodoOK);
            return tbl;
        }

        public DataTable MaquinaAccesoEmp(int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAMaquina obj = new Datos.DAMaquina(_strConString);
            tbl = obj.ListaMaquinaAccEmp(idEmpresa, ref blnTodoOK);
            return tbl;
        }

        public DataTable MaqAccesoAlm(int idAlmacen, int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAMaquina obj = new Datos.DAMaquina(_strConString);
            tbl = obj.ListaMaqAccAlm(idAlmacen, idEmpresa, ref blnTodoOK);
            return tbl;
        }

        public DataTable GridMaq(int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAMaquina obj = new Datos.DAMaquina(_strConString);
            tbl = obj.ListaGridMaq(idEmpresa, ref blnTodoOK);
            return tbl;
        }

        public void InsertarArtMaquina(int idMaquina, int idEmpresa, DataTable tabla, ref bool blnTodoOK)
        {
            Datos.DAMaquina obj = new Datos.DAMaquina(_strConString);
            obj.InsertarArtMaquina(idMaquina, idEmpresa, tabla, ref blnTodoOK);

        }

        public DataTable ComboMaquina(int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAMaquina obj = new Datos.DAMaquina(_strConString);
            tbl = obj.ListaComboMaquina(idEmpresa, ref blnTodoOK);
            return tbl;
        }

        public void Borrar(int idSeleccion, ref bool blnTodoOK)
        {
            Datos.DAMaquina obj = new Datos.DAMaquina(_strConString);
            obj.Borrar(idSeleccion, ref blnTodoOK);

        }

        public DataTable MaqAccesoUniNeg(int idUniNeg, int idEmpresa, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAMaquina obj = new Datos.DAMaquina(_strConString);
            tbl = obj.ListaMaqAccUniNeg(idUniNeg, idEmpresa, ref blnTodoOK);
            return tbl;
        }
    }
}
