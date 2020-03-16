using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Producto : BaseEntity
    {
        //atributos y modificadores de acceso.
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public double PrecioProducto { get; set; }
        public double Descuento { get; set; }
        public string IdRestaurante { get; set; }
        public string Imagen { get; set; }

        //constructores
        public Producto() { }

        public Producto(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 7)
            {
                CodigoProducto = infoArray[0];

                NombreProducto = infoArray[1];
                DescripcionProducto = infoArray[2];

                var precio = 0.0;
                if (Double.TryParse(infoArray[3], out precio))
                    PrecioProducto = precio;
                else
                    throw new Exception("El precio debe ser un numero decimal.");

                var descuento = 0.0;
                if (Double.TryParse(infoArray[4], out descuento))
                    Descuento = descuento;
                else
                    throw new Exception("El descuento debe ser un numero decimal.");

                IdRestaurante = infoArray[5];
                Imagen = infoArray[6];
            }
            else
                throw new Exception("Los siguientes campos son requeridos[nombre, descripcion, " +
                                      "precio, descuento, cedula juridica]");
        }
    }
}

