using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class ENEmpresa
    {
        public int intIdEmp { get; set; }
        public string strCoEmp { get; set; }
        public string strNoEmp { get; set; }
        public string strRuc { get; set; }
        public int intEstado { get; set; }
        public int intIdUsuCr { get; set; }
        public DateTime dttFeCr { get; set; }
        public int intIdUsuMf { get; set; }
        public DateTime dttFeMf { get; set; }
        public int intElim { get; set; }

    }
}
