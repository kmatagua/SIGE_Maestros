using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class ENCliente
    {
        public int intIdCliente { get; set; }
        public string strCoCliente { get; set; }
        public string strNoCliente { get; set; }
        public string strRazSoc { get; set; }
        public string strApePat { get; set; }
        public string strApeMat { get; set; }
        public string strNom1 { get; set; }
        public string strNom2 { get; set; }
        public int intIdTipoPer { get; set; }
        public int intIdTipoDocPer { get; set; }
        public string strRuc { get; set; }
        public string strDni { get; set; }
        //public string strDireccion { get; set; }
        public string strContacto { get; set; }
        public string strMail { get; set; }
        public string strTlfFijo { get; set; }
        public string strTlfMovil { get; set; }
        public DateTime dttFeReg { get; set; }
        public int intIdTipoCliente { get; set; }
        public int intIdGiroCliente { get; set; }
        public int intIdTipoListaPrecio { get; set; }
        public int intIdCaliCliente { get; set; }
        public int intIdEstadoAprobacion { get; set; }
        public int intIdArea { get; set; }
        public string strZona { get; set; }
        public string strRuta { get; set; }
        public string strInterrelacion { get; set; }

        public int intIdFormaPago { get; set; }
        public decimal decLimCre { get; set; }
        public int intTransportista { get; set; }

        public int intElim { get; set; }

        public int intEstado { get; set; }
        public int intIdUsuCr { get; set; }
        public DateTime dttFeCr { get; set; }
        public int intIdUsuMf { get; set; }
        public DateTime dttFeMf { get; set; }

    }
}
