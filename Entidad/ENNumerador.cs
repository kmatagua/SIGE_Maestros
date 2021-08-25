using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class ENNumerador
    {
        public int intIdNum { get; set; }
        public int intIdOperacion { get; set; }
        public int intIdTipDoc { get; set; }
        public int intIdTipoOpe { get; set; }
        public int intIdSubTipoOpe { get; set; }
        public string strSerie { get; set; }
        public string strNumero { get; set; }
        public string strObservacion { get; set; }
        public int intIdEmp { get; set; }
        public int intIdAlm { get; set; }
        public int intIdSede { get; set; }
        public int intElim { get; set; }
        public int intEstado { get; set; }
        public int intIdUsuCr { get; set; }
        public DateTime dttFeCr { get; set; }
        public int intIdUsuMf { get; set; }
        public DateTime dttFeMf { get; set; }
    }
}
