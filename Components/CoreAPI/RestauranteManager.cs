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
    public class RestauranteManager : BaseManager
    {
        private RestauranteCrudFactory crudRestaurante;

        public RestauranteManager()
        {
            crudRestaurante = new RestauranteCrudFactory();
        }

        public void Create(Restaurante restaurante)
        {
            //crudRestaurante.Create(restaurante);
            try
            {
                var r = crudRestaurante.Retrieve<Restaurante>(restaurante);
                
                if (r != null)
                {
                    //Document already exist
                    throw new BussinessException(2);
                }
                else
                {
                    crudRestaurante.Create(restaurante);
                }
                   

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Restaurante> RetrieveAll()
        {
            return crudRestaurante.RetrieveAll<Restaurante>();
        }

        public Restaurante RetrieveById(Restaurante restaurante)
        {
            Restaurante r = null;
            
            try
            {
                r = crudRestaurante.Retrieve<Restaurante>(restaurante);
                if (r.CedulaJuridica == null)
                {
                    throw new BussinessException(3);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return r;
        }

        public void Update(Restaurante restaurante)
        {
            crudRestaurante.Update(restaurante);
        }

        public void Delete(Restaurante restaurante)
        {
            crudRestaurante.Delete(restaurante);
        }
    }
}