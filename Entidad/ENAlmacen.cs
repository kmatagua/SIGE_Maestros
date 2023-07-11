using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class ENAlmacen
    {
        public int intIdAlm { get; set; }
        public string strCoAlm { get; set; }
        public string strNoAlm { get; set; }
        public int intEstado { get; set; }
        public int intIdUsuCr { get; set; }
        public DateTime dttFeCr { get; set; }
        public int intIdUsuMf { get; set; }
        public DateTime dttFeMf { get; set; }
        public int intElim { get; set; }
        public int intIdSede { get; set; }

        public int intServicio { get; set; }

        public string prueba { get; set; }

    }
}
