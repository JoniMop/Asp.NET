using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Security;

namespace WebApp.Controllers
{
    [SecurityFilter]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TodosLosRestaurantes()
        {
            return View();
        }


        public ActionResult RestaurantesXCategoria()
        {
            return View();
        }

        public ActionResult FormTransportistaParte1()
        {
            return View();
        }
        public ActionResult FormTransportistaParte2()
        {
            return View();
        }

        public ActionResult FormComercioParte1()
        {
            return View();
        }

        public ActionResult FormComercioParte2()
        {
            return View();
        }

        public ActionResult FormComercioParte3()
        {
            return View();
        }

        public ActionResult FormCliente()
        {
            return View();
        }

        public ActionResult Bitacora()
        {
            return View();
        }

        public ActionResult dashboardCliente(string id)
        {
            return View();
        }
        public ActionResult dashboardComercio(string id)
        {
            return View();
        }
        public ActionResult dashboardTransportista(string id)
        {
            return View();
        }

        public ActionResult dashboardAdmin(string id)
        {
            return View();
        }

        public ActionResult reclamos()
        {
            return View();
        }

        // [Route("users/{id}")]
        public ActionResult restauranteEdit(string id)
        {
            return View();
        }
        public ActionResult restauranteCliente(string id)
        {
            return View();
        }
        public ActionResult pagosPaypal()
        {
            return View();
        }
        public ActionResult pagosWallet()
        {
            return View();
        }

        public ActionResult pagosMembresia()
        {
            return View();
        }

        public ActionResult RegistroWallet()
        {
            return View();
        }

        public ActionResult AbonarWallet()
        {
            return View();
        }
        public ActionResult lemonCode()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(email model)
        {
            try
            {
                //enviar correo
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("masterfoodcr@gmail.com");
                message.To.Add(new MailAddress(model.To));
                message.Subject = "Contraseña temporal";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body =
                      "<div style = 'background-color:#F24B4B; min-height:200px; padding:50px;'>" +
                    "<div style = 'background-color:white; border-radius:10px; padding:20px; font-family:Arial; font-size:20px;'>" +
                    "<img src = 'https://res.cloudinary.com/veromorera/image/upload/v1573498967/masterFood/logo.png' style = 'margin-left: 43%; text-align: center; border-radius: 10px;'>" +
                    " <p> Estimado usuario: </ p > " +
                    " <p> Le enviamos este correo por su solicitud de recuperación de contraseña, su contraseña temporal es: </p>" + model.TempPass + "<br><br>" +
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

                return new HttpStatusCodeResult(204);
            }
            catch
            {
                return new HttpStatusCodeResult(204);
            }
        }
    } 
}