using CoreAPI;
using Entities_POJO;
using Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using System.Web.Http.Cors;


namespace WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    [ExceptionFilter]
    public class FacturaController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        // GET api/customer
        // Retrieve
        public IHttpActionResult Get()
        {

            apiResp = new ApiResponse();
            var mng = new FacturaManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        // GET api/customer/5
        // Retrieve by id
        public IHttpActionResult Get(string id)
        {
            try
            {
                var mng = new FacturaManager();
                var fac = new Factura
                {
                    IdUsuario = id
                };

                fac = mng.RetrieveById(fac);
                apiResp = new ApiResponse();
                apiResp.Data = fac;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // POST 
        // CREATE user
        public IHttpActionResult Post(Factura fac)
        {

            try
            {
                var mng = new FacturaManager();
                mng.Create(fac);

                apiResp = new ApiResponse();
                apiResp.Message = "Proceso finalizado.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.Message));
            }
        }




        // PUT
        // UPDATE
        public IHttpActionResult Put(Factura fac)
        {
            try
            {
                var mng = new FacturaManager();
                mng.Update(fac);

                apiResp = new ApiResponse();
                apiResp.Message = "Proceso finalizado.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // DELETE ==
        public IHttpActionResult Delete(Factura fac)
        {
            try
            {
                var mng = new FacturaManager();
                mng.Delete(fac);

                apiResp = new ApiResponse();
                apiResp.Message = "Proceso finalizado.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

    }
}