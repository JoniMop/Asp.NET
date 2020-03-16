using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Bitacora : BaseEntity
    {
        //atributos y modificadores de acceso.
        public DateTime FechaHora { get; set; }
        public string DescripcionCRUD { get; set; }
        public string IdUsuario { get; set; }

        //constructores
        public Bitacora() { }

        public Bitacora(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 3)
            {
                //comprobar formato fecha
                string pattern = "MM-dd-yyyy";
                DateTime parsedDate;

                if (DateTime.TryParseExact(infoArray[0], pattern, null, DateTimeStyles.None, out parsedDate))
                    FechaHora = parsedDate;
                else
                    Console.WriteLine("No se puede convertir '{0}' a fecha.", infoArray[0]);

                DescripcionCRUD = infoArray[1];
                IdUsuario = infoArray[2];
            }
            else
            {
                throw new Exception("Los siguientes campos son requeridos[fecha, descripcion, cedula]");
            }

        }
    }
}


