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
    public class ProductoManager : BaseManager
    {
        private ProductoCrudFactory crudProducto;

        public ProductoManager()
        {
            crudProducto = new ProductoCrudFactory();
        }

        public void Create(Producto prod)
        {
            try
            {
                var p = crudProducto.Retrieve<Producto>(prod);

                if (p != null)
                {
                    // already exist
                    throw new BussinessException(19);
                }

                else
                    crudProducto.Create(prod);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }


        public List<Producto> RetrieveAll()
        {
            return crudProducto.RetrieveAll<Producto>();
        }

        public Producto RetrieveById(Producto prod)
        {
            Producto p = null;
            try
            {
                p = crudProducto.Retrieve<Producto>(prod);
                if (p == null)
                {
                    throw new BussinessException(20);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return p;
        }

        public void Update(Producto prod)
        {
            crudProducto.Update(prod);
        }

        public void Delete(Producto prod)
        {
            crudProducto.Delete(prod);
        }



    }
}