using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Documento : BaseEntity
    {
        public string IdUsuario{ get; set; }
        public string VehiculoEcologico{ get; set; }
        public string TipoVehiculo{ get; set; }
        public string LicenciaConducir{ get; set; }
        public string PermisoMinSalud{ get; set; }
        

        public Documento() { }

        public Documento(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 5)
            {
                
                IdUsuario = infoArray[0];
                VehiculoEcologico = infoArray[1];
                TipoVehiculo = infoArray[2];
                LicenciaConducir = infoArray[3];
                PermisoMinSalud = infoArray[4];               
            }
            else
            {
                throw new Exception("El idUsuario es requerido.");
            }

        }


    }
}
