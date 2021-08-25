using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class ENCierreAlmacen
    {
        public int intIdCierreAlmacen { get; set; }
        public int intIdEmp { get; set; }
        public int intIdSede { get; set; }
        public int intIdAlm { get; set; }
        public int intIdPeriodo { get; set; }
        public int intCierre { get; set; }  

        public int intElim { get; set; }
        public int intEstado { get; set; }
        public int intIdUsuCr { get; set; }
        public DateTime dttFeCr { get; set; }
        public int intIdUsuMf { get; set; }
        public DateTime dttFeMf { get; set; }

    }
}
