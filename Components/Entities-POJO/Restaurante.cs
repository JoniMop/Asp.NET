using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Restaurante : BaseEntity
    {
        public string CedulaJuridica { get; set; }
        public string NombreComercial { get; set; }
        public string IdEncargado { get; set; }
        public string HorarioOpen { get; set; }
        public string HorarioClose { get; set; }
        public string Categoria { get; set; }


        public Restaurante() { }

        public Restaurante(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 5)
            {

                CedulaJuridica = infoArray[0];
                NombreComercial = infoArray[1];
                IdEncargado = infoArray[2];
                Categoria = infoArray[3];
                HorarioOpen = infoArray[4];
                HorarioClose = infoArray[5];
               
            }
            else
            {
                throw new Exception("Datos son requeridos.");
            }

        }


    }
}
