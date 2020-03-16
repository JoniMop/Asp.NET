
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
    public class ImagenRestauranteManager : BaseManager
    {
        private ImagenRestauranteCrudFactory crudImagen;

        public ImagenRestauranteManager()
        {
            crudImagen = new ImagenRestauranteCrudFactory();
        }

        public void Create(ImagenRestaurante img)
        {
            try
            {
                var i = crudImagen.Retrieve<ImagenRestaurante>(img);

                if (i != null)
                {
                    // already exist
                    throw new BussinessException(11);
                }

                else
                    crudImagen.Create(img);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }


        public List<ImagenRestaurante> RetrieveAll()
        {
            return crudImagen.RetrieveAll<ImagenRestaurante>();
        }

        public ImagenRestaurante RetrieveById(ImagenRestaurante img)
        {
            ImagenRestaurante i = null;
            try
            {
                i = crudImagen.Retrieve<ImagenRestaurante>(img);
                if (i == null)
                {
                    throw new BussinessException(12);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return i;
        }

        public void Update(ImagenRestaurante img)
        {
            crudImagen.Update(img);
        }

        public void Delete(ImagenRestaurante img)
        {
            crudImagen.Delete(img);
        }



    }
}