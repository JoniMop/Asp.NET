
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
    public class OrdenCompraManager : BaseManager
    {
        private OrdenCompraCrudFactory crudOrden;

        public OrdenCompraManager()
        {
            crudOrden = new OrdenCompraCrudFactory();
        }

        public void Create(OrdenCompra oc)
        {
            try
            {
                var f = crudOrden.Retrieve<OrdenCompra>(oc);

                if (f != null)
                {
                    // already exist
                    throw new BussinessException(17);
                }

                else
                    crudOrden.Create(oc);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }


        public List<OrdenCompra> RetrieveAll()
        {
            return crudOrden.RetrieveAll<OrdenCompra>();
        }

        public OrdenCompra RetrieveById(OrdenCompra oc)
        {
            OrdenCompra f = null;
            try
            {
                f = crudOrden.Retrieve<OrdenCompra>(oc);
                if (f == null)
                {
                    throw new BussinessException(18);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return f;
        }

        public void Update(OrdenCompra oc)
        {
            crudOrden.Update(oc);
        }

        public void Delete(OrdenCompra oc)
        {
            crudOrden.Delete(oc);
        }



    }
}