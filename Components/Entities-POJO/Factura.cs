using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Factura : BaseEntity
    {
        //atributos y modificadores de acceso.
        public string FacturaPDF { get; set; }
        public string IdUsuario { get; set; }

        //constructores
        public Factura() { }

        public Factura(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 2)
            {
                FacturaPDF = infoArray[0];
                IdUsuario = infoArray[1];
            }
            else
            {
                throw new Exception("Los siguientes campos son requeridos[facturaPDF, cedula]");
            }
        }
    }
}


