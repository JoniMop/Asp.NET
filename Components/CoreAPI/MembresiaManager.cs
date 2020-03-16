
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
    public class MembresiaManager : BaseManager
    {
        private MembresiaCrudFactory crudMembresia;

        public MembresiaManager()
        {
            crudMembresia = new MembresiaCrudFactory();
        }

        public void Create(Membresia membresia)
        {
            try
            {
                var m = crudMembresia.Retrieve<Membresia>(membresia);

                if (m != null)
                {
                    // already exist
                    throw new BussinessException(14);
                }

                else
                    crudMembresia.Create(membresia);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }


        public List<Membresia> RetrieveAll()
        {
            return crudMembresia.RetrieveAll<Membresia>();
        }

        public Membresia RetrieveById(Membresia membresia)
        {
            Membresia m = null;
            try
            {
                m = crudMembresia.Retrieve<Membresia>(membresia);
                if (m == null)
                {
                    throw new BussinessException(15);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return m;
        }

        public void Update(Membresia membresia)
        {
            crudMembresia.Update(membresia);
        }

        public void Delete(Membresia membresia)
        {
            crudMembresia.Delete(membresia);
        }



    }
}