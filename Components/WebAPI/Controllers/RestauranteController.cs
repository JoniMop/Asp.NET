using CoreAPI;
using Entities_POJO;
using Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using WebAPI.Models;
using System.Net.Mail;
using System.Web.Http.Cors;


namespace WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    [ExceptionFilter]
    public class RestauranteController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        // GET api/documento
        // Retrieve
        public IHttpActionResult Get()
        {

            apiResp = new ApiResponse();
            var mng = new RestauranteManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        // GET api/documento/5
        // Retrieve by id
        public IHttpActionResult Get(string id)
        {
            try
            {
                var mng = new RestauranteManager();
                var restaurante = new Restaurante
                {
                    CedulaJuridica = id
                };

                restaurante = mng.RetrieveById(restaurante);
                apiResp = new ApiResponse();
                apiResp.Data = restaurante;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // POST 
        // CREATE
        public IHttpActionResult Post(Restaurante restaurante)
        {

            try
            {
                var mng = new RestauranteManager();
                mng.Create(restaurante);

                apiResp = new ApiResponse();
                apiResp.Message = "Proceso finalizado.";

                //obtener el usuario para enviar correo
                var us = new UsuarioManager();
                Usuario u = new Usuario();
                u.Cedula = restaurante.IdEncargado;
                Usuario us2 = us.RetrieveById(u);


                try
                {
                    //mail que se le envia al transportista
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
                    " <p> Le damos la bienvenida a nuestro sitio, su cuenta se encuentra pendiente de aprobación." + "<br>" +
                    "Le enviaremos un nuevo correo cuando esté activada.</p>" + "<br><br>" +
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



                    //mail que se le envia al admin.
                    MailMessage message2 = new MailMessage();
                    SmtpClient smtp2 = new SmtpClient();
                    message2.From = new MailAddress("masterfoodcr@gmail.com");
                    message2.To.Add(new MailAddress("admmasterfoodcr@gmail.com"));
                    message2.Subject = "Aprobación de registro pendiente";
                    message2.IsBodyHtml = true; //to make message body as html  
                    message2.Body =

                    "<div style = 'background-color:#F24B4B; min-height:200px; padding:50px;'>" +
                    "<div style = 'background-color:white; border-radius:10px; padding:20px; font-family:Arial; font-size:18px;'>" +
                    "<img src = 'https://res.cloudinary.com/veromorera/image/upload/v1573498967/masterFood/logo.png' style = 'margin-left: 43%; text-align: center; border-radius: 10px;'>" +
                    " <p> Estimado administrador: </ p > " +
                    " <p> Masterfood le informa que hay un nuevo registro de restaurante pendiente." + "<br>" +
                    "Puede realizar esta gestión en su perfil de la web.</p>" + "<br><br>" +
                    " <p> Gracias, el equipo de MasterFood</p>" +
                    "</div>" +
                    "</div>";
                    smtp2.Port = 587;
                    smtp2.Host = "smtp.gmail.com"; //for gmail host  
                    smtp2.EnableSsl = true;
                    smtp2.UseDefaultCredentials = false;
                    smtp2.Credentials = new NetworkCredential("masterfoodcr@gmail.com", "masterfood123");
                    smtp2.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp2.Send(message2);
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
        public IHttpActionResult Put(Restaurante restaurante)
        {
            try
            {
                var mng = new RestauranteManager();
                mng.Update(restaurante);

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
        public IHttpActionResult Delete(Restaurante restaurante)
        {
            try
            {
                var mng = new RestauranteManager();
                mng.Delete(restaurante);

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