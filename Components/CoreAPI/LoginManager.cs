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
    public class LoginManager : BaseManager
    {
        private UsuarioCrudFactory crudUsuario;

        public LoginManager()
        {
            crudUsuario = new UsuarioCrudFactory();
        }

        public Usuario RetrieveLoginInfo(Usuario usuario)
        {
            Usuario u = null;
            try
            {
                u = crudUsuario.RetrieveLogin<Usuario>(usuario);
                if (u == null)
                {
                    throw new BussinessException(13);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return u;

        }
    }
    }
