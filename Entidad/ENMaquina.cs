using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class ENMaquina
    {
        public int intIdMaq { get; set; }
        public string strCoMaq  { get; set; }
        public string strNoMaq { get; set; }
        public int intElim { get; set; }
        public int intEstado { get; set; }
        public int intIdUsuCr { get; set; }
        public DateTime dttFeCr { get; set; }
        public int intIdUsuMf { get; set; }
        public DateTime dttFeMf { get; set; }

    }
}
