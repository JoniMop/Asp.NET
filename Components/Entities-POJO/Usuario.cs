using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Usuario: BaseEntity
    {
        //atributos y modificadores de acceso.
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string Mapa { get; set; } //soporta null
        public int Telefono { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public string Rol { get; set; }
        public string IdPaypal { get; set; } 
        public string CodigoAsignado { get; set; }
        public string CodigoVerificacion { get; set; } //soporta null



        //constructores
        public Usuario() { }

        public Usuario(string[] infoArray)
        {

            if (infoArray != null && infoArray.Length >= 13)
            {
                Cedula = infoArray[0];
                Nombre = infoArray[1];
                Apellidos = infoArray[2];
                Provincia = infoArray[3];
                Canton = infoArray[4];
                Distrito = infoArray[5];

                // si el rol es comercio, usuario requiere este dato
                Rol = infoArray[10];
                if (Rol == "comercio" || Rol == "cliente")
                {
                    Mapa = infoArray[6];
                }
                else //quedan vacios
                    Mapa = "";

                //comprobar formato telefono
                var tel = 0;
                if (Int32.TryParse(infoArray[7], out tel))
                    Telefono = tel;
                else
                    throw new Exception("El teléfono debe contener solo números");

                Email = infoArray[8];
                Contrasena = infoArray[9];
                IdPaypal = infoArray[11];
                CodigoAsignado = infoArray[12];

                //este por defecto es null, se hace un update cuando se activa la cuenta.
                CodigoVerificacion = infoArray[13];
            }
            else
            {
                throw new Exception("Los siguientes campos son requeridos[Nombre, Apellidos, Provincia, " +
                                    "Canton, Distrito, Telefono, Email, Contrasena, cuenta de Paypal]");
            }

        }
    }
}


