using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class ImagenRestaurante : BaseEntity
    {

        public string Logo { get; set; }
        public string IdRestaurante { get; set; }
        public string Perfil { get; set; }


        public ImagenRestaurante() { }

        public ImagenRestaurante(string[] infoArray)
        {

            if (infoArray != null && infoArray.Length >= 2)
            {
                Logo = infoArray[0];
                IdRestaurante = infoArray[1];
                Perfil = infoArray[2];
            }
            else
            {
                throw new Exception("El link de las imagenes y la cedula juridica es requerida.");
            }

        }


    }
}





