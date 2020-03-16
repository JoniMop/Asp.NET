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
using System.Web.Http.Cors;
using System.Net.Mail;
using WebAPI.Models;

namespace WebAPI.Controllers
{
   [EnableCors(origins: "*", headers: "*", methods: "*")]

    [ExceptionFilter]
    public class UsuarioController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        // GET api/customer
        // Retrieve
        public IHttpActionResult Get()
        {

            apiResp = new ApiResponse();
            var mng = new UsuarioManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        /*
        [HttpGet]
        public IHttpActionResult Login(string type)
        {

            apiResp = new ApiResponse();
            var mng = new UsuarioManager();

            return Ok(apiResp);
        }
        */
     

        [HttpGet]
        [ActionName("GetByRol")]

        public IHttpActionResult GetByRol(string rol)
        {
            try
            {
                var mng = new UsuarioManager();
                var usuario = new Usuario
                {
                    Rol = rol
                };

                usuario = mng.RetrieveByRol(usuario);
                apiResp = new ApiResponse();
                apiResp.Data = usuario;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }



// GET api/customer/5
// Retrieve by id
public IHttpActionResult Get(string id)
        {
            try
            {
                var mng = new UsuarioManager();
                var usuario = new Usuario
                {
                    Cedula = id,
                };

                usuario = mng.RetrieveById(usuario);
                apiResp = new ApiResponse();
                apiResp.Data = usuario;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // POST 
        // CREATE
        public IHttpActionResult Post(Usuario usuario)
        {

            try
            {
                var mng = new UsuarioManager();
                mng.Create(usuario);

                apiResp = new ApiResponse();
                apiResp.Message = "Proceso finalizado.";


                //obtener el usuario para enviar correo
                var us = new UsuarioManager();
                Usuario u = new Usuario();
                u.Cedula = usuario.Cedula;
                Usuario us2 = us.RetrieveById(u);

                try
                {
                    //mail que se le envia al usuario con codigo de verificacion
                    MailMessage message = new MailMessage();
                    SmtpClient smtp = new SmtpClient();
                    message.From = new MailAddress("masterfoodcr@gmail.com");
                    message.To.Add(new MailAddress(us2.Email));
                    message.Subject = "Confirmación de registro";
                    message.IsBodyHtml = true; //to make message body as html  
                    message.Body =
                         "<div style = 'background-color:#F24B4B; min-height:200px; padding:50px;'>" +
                    "<div style = 'background-color:white; border-radius:10px; padding:20px; font-family:Arial; font-size:18px;'>" +
                    "<img src = 'https://res.cloudinary.com/veromorera/image/upload/v1573498967/masterFood/logo.png' style = 'margin-left: 43%; text-align: center; border-radius: 10px;'>" +
                    " <p> Estimado usuario: </ p > " +
                    " <p> Le damos la bienvenida a nuestro sitio, su código de activación es: " + "<br>" + us2.CodigoAsignado + "<br><br>" +
                    " <p> Gracias, el equipo de MasterFood</p>" +
                    "</div>" +
                    "</div>";
                    smtp.Port = 587;
                    smtp.Host = "smtp.gmail.com"; //for gmail host  
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("masterfoodcr@gmail.com", "masterfood123");
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Send(message);

                }
                catch (Exception) { }

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
        public IHttpActionResult Put(Usuario usuario)
        {
            try
            {
                var mng = new UsuarioManager();
                mng.Update(usuario);

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
        public IHttpActionResult Delete(Usuario usuario)
        {
            try
            {
                var mng = new UsuarioManager();
                mng.Delete(usuario);

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
