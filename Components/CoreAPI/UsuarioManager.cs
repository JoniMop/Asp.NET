
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
    public class UsuarioManager : BaseManager
    {
        private UsuarioCrudFactory crudUsuario;

        public UsuarioManager()
        {
            crudUsuario = new UsuarioCrudFactory();
        }

        public void Create(Usuario usuario)
        {
            try
            {
                var c = crudUsuario.Retrieve<Usuario>(usuario);

                if (c != null)
                {
                    //usuario already exist
                    throw new BussinessException(1);
                }

                else
                    crudUsuario.Create(usuario);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }






        public List<Usuario> RetrieveAll()
        {
            return crudUsuario.RetrieveAll<Usuario>();
        }

        public Usuario RetrieveById(Usuario usuario)
        {
            Usuario u = null;
            try
            {
                u = crudUsuario.Retrieve<Usuario>(usuario);
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

        public void Update(Usuario usuario)
        {
            crudUsuario.Update(usuario);
        }

        public void Delete(Usuario usuario)
        {
            crudUsuario.Delete(usuario);
        }


        public String CodVerificacion()
        {
            Random randomCod = new Random();
            int num = randomCod.Next(00000001, 99999999);
            string hexValue = num.ToString("X");
            String cod = System.Convert.ToString(hexValue);


            return cod;
        }

        //---------------------------------------------------//
        public Usuario RetrieveByRol(Usuario usuario)
        {
            Usuario u = null;
            try
            {
                u = crudUsuario.Retrieve<Usuario>(usuario);
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

