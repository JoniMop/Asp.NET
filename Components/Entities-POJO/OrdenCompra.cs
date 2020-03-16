using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class OrdenCompra : BaseEntity
    {
        public string IdOrdenCompra { get; set; }
        public string IdRestaurante { get; set; }
        public string NombreComercial { get; set; }// este es un inner join del "retrieveAllOrdenCompra"
        public string IdCliente { get; set; }
        public string NombreCliente { get; set; }// este es un inner join del "retrieveAllOrdenCompra"
        public int IdViaje { get; set; }
        public double Subtotal { get; set; }
        public double IVA { get; set; }
        public double Total { get; set; }
        public string CodigoQR { get; set; }
        public int CalificacionRestaurante { get; set; }
        public int CalificacionTransporte { get; set; }
        public string EstadoOrden { get; set; }
        public List<string> ProductosXOrden { get; set; } //ojoooo
        public string Reclamo { get; set; }
        public string RespuestaReclamo { get; set; }


        public OrdenCompra() { }

        public OrdenCompra (string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 13)
            {
                IdOrdenCompra = infoArray[0];

                IdRestaurante = infoArray[1];
                IdCliente = infoArray[2];

                //comprobar formato 
                var idViaje = 0;
                if (Int32.TryParse(infoArray[3], out idViaje))
                    IdViaje = idViaje;
                else
                    throw new Exception("El id del viaje debe ser un numero entero.");

                //comprobar formato 
                var sub = 0.0;
                if (Double.TryParse(infoArray[4], out sub))
                    Subtotal = sub;
                else
                    throw new Exception("El subtotal debe ser un numero decimal.");

                var iva = 0.0;
                if (Double.TryParse(infoArray[5], out iva))
                    IVA = iva;
                else
                    throw new Exception("El IVA debe ser un numero decimal.");

                var total = 0.0;
                if (Double.TryParse(infoArray[6], out total))
                    Total = total;
                else
                    throw new Exception("El id del viaje debe ser un numero decimal.");

                CodigoQR = infoArray[7];

                var califRest = 0;
                if (Int32.TryParse(infoArray[8], out califRest))
                    CalificacionRestaurante = califRest;
                else
                    throw new Exception("La calificacion debe ser un numero entero del 1 al 5.");

                var califTrans = 0;
                if (Int32.TryParse(infoArray[9], out califTrans))
                    CalificacionRestaurante = califTrans;
                else
                    throw new Exception("La calificacion debe ser un numero entero del 1 al 5.");


                EstadoOrden = infoArray[10];

                Reclamo = infoArray[11];
                RespuestaReclamo = infoArray[12];
            }
            else
            {
                throw new Exception("Los sigiuentes datos son requeridos: [idordenCompra, idRestaurante, idCliente," +
                    " idViaje, subtotal, iva, total, estadoOrden].");
            }

        }


    }
}
