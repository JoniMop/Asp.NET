
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
    public class TransaccionManager : BaseManager
    {
        private TransaccionCrudFactory crudTransaccion;

        public TransaccionManager()
        {
            crudTransaccion = new TransaccionCrudFactory();
        }

        public void Create(Transaccion trans)
        {
            try
            {
                var t = crudTransaccion.Retrieve<Transaccion>(trans);

                if (t != null)
                {
                    // already exist
                    throw new BussinessException(21);
                }

                else
                    crudTransaccion.Create(trans);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }


        public List<Transaccion> RetrieveAll()
        {
            return crudTransaccion.RetrieveAll<Transaccion>();
        }

        public Transaccion RetrieveById(Transaccion trans)
        {
            Transaccion t = null;
            try
            {
                t = crudTransaccion.Retrieve<Transaccion>(trans);
                if (t == null)
                {
                    throw new BussinessException(22);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return t;
        }

        public void Update(Transaccion trans)
        {
            crudTransaccion.Update(trans);
        }

        public void Delete(Transaccion trans)
        {
            crudTransaccion.Delete(trans);
        }



    }
}