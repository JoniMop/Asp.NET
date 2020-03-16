
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
    public class FacturaManager : BaseManager
    {
        private FacturaCrudFactory crudFactura;

        public FacturaManager()
        {
            crudFactura = new FacturaCrudFactory();
        }

        public void Create(Factura factura)
        {
            try
            {
                var f = crudFactura.Retrieve<Factura>(factura);

                if (f != null)
                {
                    // already exist
                    throw new BussinessException(8);
                }

                else
                    crudFactura.Create(factura);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }


        public List<Factura> RetrieveAll()
        {
            return crudFactura.RetrieveAll<Factura>();
        }

        public Factura RetrieveById(Factura factura)
        {
            Factura f = null;
            try
            {
                f = crudFactura.Retrieve<Factura>(factura);
                if (f == null)
                {
                    throw new BussinessException(10);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return f;
        }

        public void Update(Factura factura)
        {
            crudFactura.Update(factura);
        }

        public void Delete(Factura factura)
        {
            crudFactura.Delete(factura);
        }



    }
}