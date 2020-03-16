using DataAcess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class ViajeManager : BaseManager
    {
        private ViajeCrudFactory crudViaje;

        public ViajeManager()
        {
            crudViaje = new ViajeCrudFactory();
        }

        public void Create(Viaje viaje)
        {
            try
            {
                crudViaje.Create(viaje);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }


        public List<Viaje> RetrieveAll()
        {
            return crudViaje.RetrieveAll<Viaje>();
        }

        public Viaje RetrieveById(Viaje viaje)
        {
            Viaje v = null;
            try
            {
                v = crudViaje.Retrieve<Viaje>(viaje);
                if (v == null)
                {
                    throw new BussinessException(24);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return v;
        }

        public void Update(Viaje viaje)
        {
            crudViaje.Update(viaje);
        }

        public void Delete(Viaje viaje)
        {
            crudViaje.Delete(viaje);
        }



    }
}