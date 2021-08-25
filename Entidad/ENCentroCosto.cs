using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class ENCentroCosto
    {
        public int intIdCenCos { get; set; }
        public string strCoCenCos { get; set; }
        public string strNoCenCos { get; set; }
        public string strNivelCenCos { get; set; }
        public int intIdUnidadNegocio { get; set; }
        public int intElim { get; set; }
        public int intEstado { get; set; }
        public int intIdUsuCr { get; set; }
        public DateTime dttFeCr { get; set; }
        public int intIdUsuMf { get; set; }
        public DateTime dttFeMf { get; set; }

    }
}
