using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class ENEmpleado
    {
        public int intIdEmp { get; set; }
        public string strCoEmp { get; set; }
        public string strNoEmp { get; set; }
        public string strDni { get; set; }
        public DateTime dttFecReg { get; set; }
        public string strDireccion { get; set; }
        public string strTlf { get; set; }
        public string strTlfMovil { get; set; }
        public string strCorreo { get; set; }
        public int intIdCanalDist { get; set; }

        public int intElim { get; set; }
        public int intEstado { get; set; }
        public int intIdUsuCr { get; set; }
        public DateTime dttFeCr { get; set; }
        public int intIdUsuMf { get; set; }
        public DateTime dttFeMf { get; set; }

    }
}
