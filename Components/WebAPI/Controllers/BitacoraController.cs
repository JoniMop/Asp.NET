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
    public class BitacoraController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        // GET api/customer
        // Retrieve
        public IHttpActionResult Get()
        {

            apiResp = new ApiResponse();
            var mng = new BitacoraManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        // GET api/customer/5
        // Retrieve by id
        public IHttpActionResult Get(string id)
        {
            try
            {
                var mng = new BitacoraManager();
                var bit = new Bitacora
                {
                    IdUsuario = id
                };

                bit = mng.RetrieveById(bit);
                apiResp = new ApiResponse();
                apiResp.Data = bit;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // POST 
        // CREATE user
        public IHttpActionResult Post(Bitacora bit)
        {
            try
            {
                var mng = new BitacoraManager();
                mng.Create(bit);

                return Ok();
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.Message));
            }
        }



    }
}