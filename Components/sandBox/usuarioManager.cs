
using DataAcess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class UsuarioManager
    {
        private UsuarioCrudFactory crudCustomer;

        public UsuarioManager()
        {
            crudCustomer = new UsuarioCrudFactory();
        }

        public void Create(string cedula, string rol)
        {
            try
            {
                 crudCustomer.CreateUsuarioXrol(cedula, rol);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Usuario> RetrieveAll()
        {
            return crudCustomer.RetrieveAll<Usuario>();
        }

        public Usuario RetrieveById(Usuario customer)
        {
            return crudCustomer.Retrieve<Usuario>(customer);
        }

        internal void Update(Usuario customer)
        {
            crudCustomer.Update(customer);
        }

        internal void Delete(Usuario customer)
        {
            crudCustomer.Delete(customer);
        }
    }
}
