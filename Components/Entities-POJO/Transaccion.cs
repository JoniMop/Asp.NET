using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Transaccion : BaseEntity
    {
        //atributos y modificadores de acceso.
        public string IdUsuario { get; set; }
        public double Debito { get; set; }
        public double Credito { get; set; }
        public string Detalle { get; set; }
        public DateTime Fecha { get; set; }
      

        //constructores
        public Transaccion() { }

        public Transaccion(string[] infoArray)
        {

            if (infoArray != null && infoArray.Length >= 4)
            {
                IdUsuario = infoArray[0];
                
                //comprobar formato 
                var deb = 0.0;
                if (Double.TryParse(infoArray[1], out deb))
                    Debito = deb;
                else
                    throw new Exception("El debito debe ser decimal");

                var cred = 0.0;
                if (Double.TryParse(infoArray[2], out cred))
                    Credito = cred;
                else
                    throw new Exception("El debito debe ser decimal");

                //comprobar formato fecha
                string pattern = "MM-dd-yyyy";
                DateTime parsedDate;

                if (DateTime.TryParseExact(infoArray[0], pattern, null, DateTimeStyles.None, out parsedDate))
                    Fecha = parsedDate;
                else
                    Console.WriteLine("No se puede convertir '{0}' a fecha.", infoArray[3]);
            }
            else
            {
                throw new Exception("Los siguientes campos son requeridos[id usuario, debito, credito, fecha]");
            }

        }
    }
}


