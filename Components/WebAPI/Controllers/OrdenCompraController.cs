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
    public class OrdenCompraController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        // GET api/customer
        // Retrieve
        public IHttpActionResult Get()
        {

            apiResp = new ApiResponse();
            var mng = new OrdenCompraManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        // GET api/customer/5
        // Retrieve by id
        public IHttpActionResult Get(int id)
        {
            try
            {
                var mng = new OrdenCompraManager();
                var oc = new OrdenCompra
                {
                    IdViaje = id
                };

                oc = mng.RetrieveById(oc);
                apiResp = new ApiResponse();
                apiResp.Data = oc;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // POST 
        // CREATE user
        public IHttpActionResult Post(OrdenCompra rest)
        {

            try
            {
                var mng = new OrdenCompraManager();
                mng.Create(rest);

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
        public IHttpActionResult Put(OrdenCompra oc)
        {
            try
            {
                var mng = new OrdenCompraManager();
                mng.Update(oc);

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
        public IHttpActionResult Delete(OrdenCompra oc)
        {
            try
            {
                var mng = new OrdenCompraManager();
                mng.Delete(oc);

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