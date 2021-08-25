using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidad;

namespace Negocio
{
    public class NGMarca
    {
        private string _strConString = string.Empty;

        public NGMarca(string p_pStrConString)
        {
            _strConString = p_pStrConString;
        }

        public DataTable Marca (ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAMarca obj = new Datos.DAMarca(_strConString);
            tbl = obj.ListaMarca(ref blnTodoOK);
            return tbl;
        }

        public DataTable MarcaTodo(ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAMarca obj = new Datos.DAMarca(_strConString);
            tbl = obj.ListaMarcaTodo(ref blnTodoOK);
            return tbl;
        }

        public DataTable MarcaAcceso(int intIdMarca, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAMarca obj = new Datos.DAMarca(_strConString);
            tbl = obj.ListaMarcaAcc(intIdMarca, ref blnTodoOK);
            return tbl;
        }

        public DataTable FiltrarMarca(string filtro, ref bool blnTodoOK)
        {
            DataTable tbl = new DataTable();
            Datos.DAMarca obj = new Datos.DAMarca(_strConString);
            tbl = obj.ListaFiltrar(filtro, ref blnTodoOK);
            return tbl;
        }

        public DataTable BuscarMarca(int intIdMarca, ref bool blnTodoOK)
        {

            DataTable tbl = new DataTable();
            Datos.DAMarca obj = new Datos.DAMarca(_strConString);

            tbl = obj.BuscarMarca(intIdMarca, ref blnTodoOK);

            return tbl;
        }

        public void InsertarMarca(ENMarca objEnMarca, int idEmpresa, ref string mensaje, ref bool blnTodoOK)
        {
            Datos.DAMarca obj = new Datos.DAMarca(_strConString);
            obj.InsertarMarca(objEnMarca, idEmpresa, ref mensaje, ref blnTodoOK);

        }

        public void EditarMarca(ENMarca objEnMarca, ref bool blnTodoOK)
        {
            Datos.DAMarca obj = new Datos.DAMarca(_strConString);
            obj.EditarMarca(objEnMarca, ref blnTodoOK);

        }

        public void EliminarMarca(int idSeleccion, int idUsuario, ref bool blnTodoOK)
        {
            Datos.DAMarca obj = new Datos.DAMarca(_strConString);
            obj.EliminarMarca(idSeleccion, idUsuario, ref blnTodoOK);

        }
    }
}
