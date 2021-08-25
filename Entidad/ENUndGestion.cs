using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class ENUndGestion
    {
        public int intIdUndGestion { get; set; }
        public string strCoUndGestion { get; set; }
        public string strNoUndGestion { get; set; }
        public string strNivelUndGestion { get; set; }
        public int intElim { get; set; }
        public int intEstado { get; set; }
        public int intIdUsuCr { get; set; }
        public DateTime dttFeCr { get; set; }
        public int intIdUsuMf { get; set; }
        public DateTime dttFeMf { get; set; }
        
        
        public int intIdEmp { get; set; }
    }
}
