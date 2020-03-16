using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Viaje : BaseEntity
    {
        //atributos y modificadores de acceso.
        public string IdTransportista { get; set; }
        public string NombreTransportista { get; set; } //read only

        public double TarifaBasica { get; set; }
        public double KilometrosRecorridos { get; set; }
        public double DescuentoEcologico { get; set; }
        public double PagoTotal { get; set; }
        public string Mapa { get; set; }
        public double PuntoPartidaLatitud { get; set; }
        public double PuntoPartidaLongitud { get; set; }
        public double PuntoLlegadaLatitud { get; set; }
        public double PuntoLlegadaLongitud { get; set; }

        //constructores
        public Viaje() { }

        public Viaje(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 10)
            {

                IdTransportista = infoArray[0];

                //comprobar formato 
                var tarifa = 0.0;
                if (Double.TryParse(infoArray[1], out tarifa))
                    TarifaBasica = tarifa;
                else
                    throw new Exception("La tarifa debe ser un numero decimal.");

                var kilometros = 0.0;
                if (Double.TryParse(infoArray[2], out kilometros))
                    KilometrosRecorridos = kilometros;
                else
                    throw new Exception("Los kilometros deben ser un numero decimal.");

                var descuento = 0.0;
                if (Double.TryParse(infoArray[3], out descuento))
                    DescuentoEcologico = descuento;
                else
                    throw new Exception("El descuento debe ser un numero decimal.");

                var total = 0.0;
                if (Double.TryParse(infoArray[4], out total))
                    PagoTotal = total;
                else
                    throw new Exception("El total debe ser un numero decimal.");

                Mapa = infoArray[5];


                var ppl = 0.0;
                if (Double.TryParse(infoArray[6], out ppl))
                    PuntoPartidaLatitud = ppl;
                else
                    throw new Exception("El PuntoPartidaLatitud debe ser un numero decimal.");

                var pplo = 0.0;
                if (Double.TryParse(infoArray[7], out pplo))
                    PuntoPartidaLongitud = pplo;
                else
                    throw new Exception("El PuntoPartidaLatitud debe ser un numero decimal.");

                var pll = 0.0;
                if (Double.TryParse(infoArray[8], out pll))
                    PuntoLlegadaLatitud = pll;
                else
                    throw new Exception("El PuntoPartidaLatitud debe ser un numero decimal.");

                var pllo = 0.0;
                if (Double.TryParse(infoArray[9], out pllo))
                    PuntoLlegadaLongitud = pllo;
                else
                    throw new Exception("El PuntoPartidaLatitud debe ser un numero decimal.");

            }
            else
            {
                throw new Exception("Los siguientes campos son requeridos[idTransportista, tarifaBasica, " +
                    "kilometros recorridos, pago total, punto de partida, punto de llegada (latitud y longitud)]");
            }

        }
    }
}