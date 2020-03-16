using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entities_POJO
{
    public class Membresia : BaseEntity
    {
        //atributos y modificadores de acceso.
        public string IdUsuario { get; set; }
        public double MontoMembresiaAnual { get; set; }
        public string Estado { get; set; } //activo inactivo


        //constructores
        public Membresia() { }

        public Membresia(string[] infoArray)
        {

            if (infoArray != null && infoArray.Length >= 3)
            {
                IdUsuario = infoArray[0];

                var membresia = 0.0;
                if (Double.TryParse(infoArray[1], out membresia))
                    MontoMembresiaAnual = membresia;
                else
                    throw new Exception("El monto de la membresía debe ser un decimal");

                Estado = infoArray[2];
            }
            else
            {
                throw new Exception("Los siguientes campos son requeridos[IdUsuario, Monto membresía, Estado]");
            }

        }
    }
}




