
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
    public class DocumentoManager : BaseManager
    {
        private DocumentoCrudFactory crudDocumento;

        public DocumentoManager()
        {
            crudDocumento = new DocumentoCrudFactory();
        }

        public void Create(Documento documento)
        {
            //crudDocumento.Create(documento);
            try
            {
                var d = crudDocumento.Retrieve<Documento>(documento);

                if (d != null)
                {
                    //Document already exist
                  throw new BussinessException(6);
                }
               else
                    crudDocumento.Create(documento);
                
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Documento> RetrieveAll()
        {
            return crudDocumento.RetrieveAll<Documento>();
        }

        public Documento RetrieveById(Documento documento)
        {
           Documento d = null;
           // d = crudDocumento.Retrieve<Documento>(documento);
            try
             {
                 d = crudDocumento.Retrieve<Documento>(documento);
                 if (d.IdUsuario == null)
                 {
                     throw new BussinessException(7);
                 }
             }
             catch (Exception ex)
             {
                 ExceptionManager.GetInstance().Process(ex);
             }

            return d;
        }

        public void Update(Documento documento)
        {
            crudDocumento.Update(documento);
        }

        public void Delete(Documento documento
            )
        {
            crudDocumento.Delete(documento);
        }
    }
}