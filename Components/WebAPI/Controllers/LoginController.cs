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

namespace WebAPI.Controllers
{
    [ExceptionFilter]
    public class LoginController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();


         public IHttpActionResult Get( string email)
         {
             try
             {
                 var mng = new LoginManager();
                 var usuario = new Usuario
                 {
                     Email = email
                 };

                 usuario = mng.RetrieveLoginInfo(usuario);
                 apiResp = new ApiResponse();
                 apiResp.Data = usuario;
                 return Ok(apiResp);
             }
             catch (BussinessException bex)
             {
                 return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
             }
         }



    }
}