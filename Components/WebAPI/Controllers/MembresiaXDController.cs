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
using System.Net.Mail;
using System.Web.Http.Cors;


namespace WebAPI.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]

    [ExceptionFilter]
    public class MembresiaXDController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        // GET api/customer
        // Retrieve
        public IHttpActionResult Get()
        {

            apiResp = new ApiResponse();
            var mng = new MembresiaManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        // GET api/customer/5
        // Retrieve by id
        public IHttpActionResult Get(string id)
        {
            try
            {
                var mng = new MembresiaManager();
                var membresia = new Membresia
                {
                    IdUsuario = id
                };

                membresia = mng.RetrieveById(membresia);
                apiResp = new ApiResponse();
                apiResp.Data = membresia;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // POST 
        // CREATE user
        public IHttpActionResult Post()
        {

            try
            {
                ////obtener el usuario para enviar correo
                //var us = new UsuarioManager();
                //Usuario u = new Usuario();
                //u.Cedula = ;
                //Usuario us2 = us.RetrieveById(u);


                //enviar correo

                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("masterfoodcr@gmail.com");
                message.To.Add(new MailAddress("jonatangurari@gmail.com"));
                message.Subject = "Su membresía ha sido rechazada";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body =
                      "<div style = 'background-color:#F24B4B; min-height:200px; padding:50px;'>" +
                    "<div style = 'background-color:white; border-radius:10px; padding:20px; font-family:Arial; font-size:20px;'>" +
                    "<img src = 'https://res.cloudinary.com/veromorera/image/upload/v1573498967/masterFood/logo.png' style = 'margin-left: 43%; text-align: center; border-radius: 10px;'>" +
                    " <p> Estimado usuario: </ p > " +
                    " <p> Su solicitud fue rechazada, asegúrese de haber entregado toda la documentación necesaria para el registro y en forma correcta según lo establece el formulario en la página web, verifique que los documentos estén al día y no vencidos. </p>" +

                " <p> Gracias, el equipo de MasterFood.</p>" +

                    "</div>" +
                    "</div>";
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("masterfoodcr@gmail.com", "masterfood123");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);


                var mng = new MembresiaManager();


                apiResp = new ApiResponse();
                apiResp.Message = "Proceso finalizado.";

                return Ok();

            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.Message));
            }
        }


        // PUT
        // UPDATE
        public IHttpActionResult Put()
        {
            try
            {
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
        public IHttpActionResult Delete()
        {
            try
            { //enviar correo



                return Ok();
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

    }
}