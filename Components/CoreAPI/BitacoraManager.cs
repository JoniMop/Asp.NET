
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
    public class BitacoraManager : BaseManager
    {
        private BitacoraCrudFactory crudBitacora;

        public BitacoraManager()
        {
            crudBitacora = new BitacoraCrudFactory();
        }

        public void Create(Bitacora bit)
        {
            try
            {
                crudBitacora.Create(bit);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }


        public List<Bitacora> RetrieveAll()
        {
            return crudBitacora.RetrieveAll<Bitacora>();
        }

        public Bitacora RetrieveById(Bitacora bit)
        {
            Bitacora b = null;
            try
            {
                b = crudBitacora.Retrieve<Bitacora>(bit);
                if (b == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return b;
        }

        public void Update(Bitacora bit)
        {
            crudBitacora.Update(bit);
        }

        public void Delete(Bitacora bit)
        {
            crudBitacora.Delete(bit);
        }



    }
}
