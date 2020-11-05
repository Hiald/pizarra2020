using frontendUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace frontendWEB.Controllers
{
    public class indexController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //tipo de conexion 3 es parte de lead (personas que envian más información)
        [HttpPost]
        public async Task<JsonResult> ContactarCorreo(string wemail, string wnombre, string wcelular, string wmensaje)
        {
            var objResultado = new object();
            try
            {
                string pdmac = UtlAuditoria.ObtenerDireccionMAC();
                string pdip = UtlAuditoria.ObtenerDireccionIP();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage Resregsesion = await client.GetAsync("api/usuario/APIRegistrarSesiones?wsidalumno=" + 1 + "&wsdireccionip=" + pdip + "&wsdireccionmac=" + pdmac + "&wstipoconexion=" + 3);
                    if (Resregsesion.IsSuccessStatusCode)
                    {
                        var rwsrs = Resregsesion.Content.ReadAsAsync<string>().Result;
                    }
                    else
                    {
                        objResultado = new
                        {
                            iresultado = -5,
                            iresultadoins = "Error, por favor inténtelo en unos momentos."
                        };

                    }
                }

                //AQUI DEBE ENVIAR CORREO
                var fromAddress = new MailAddress("contacto@pizarra21.com", "Pizarra21");
                var toAddress = new MailAddress(wemail, "Pizarra 21");
                var toAddress2 = new MailAddress("contacto@pizarra21.com", "Pizarra21");
                var toAddress3 = new MailAddress("juvesmme20@gmail.com", "Pizarra21");
                const string fromPassword = "@contacto123";
                const string subject = "Bienvenido a Pizarra21 - Tu camino empieza ahora";
                string body = "<br /> ¡Hola! " + wnombre
                            + "<br /><br /> Somos Pizarra21, ¡Muchas gracias por registrarte con nosotros!"
                            + "<br /><br /> Para acceder a nuestros cursos, nosotros nos comunicaremos contigo, te enviaremos el método de pago y seguidamente una vez creada la cuenta, te daremos acceso a los cursos que has solicitado, así de facil. "
                            + "<br /> Siga nuestra página de Facebook y nuestra página de Instagram (compartimos un montón de consejos y trucos y lanzamos nuevos productos allí) encuéntranos como pizarra21 en Instagram y Pizarra21 en Facebook."
                            + "<br /><br /> Estamos en constante mejora de la plataforma es por ello que trabajamos arduamente para poder brindarte la mejor experiencia."
                            + "<br /><br /><br /> ¡Esperamos que sea de tu agrado!"
                            + "<br /><br /> Gracias"
                            + "<br /><br /> Pizarra 21";
                //ini datos listerup
                string subjectpizarra = "Nuevo registro de " + wnombre + " en pizarra21";
                string bodypizarra = "Nuevo registro de: " +
                            "<br /> (nombre: " + wnombre + " )." +
                            "<br /> (celular: " + wcelular + " )." +
                            "<br /> (correo: " + wemail + " )." +
                            "<br /> (mensaje: " + wmensaje + " ).";

                //fin datos listerup
                var smtp = new SmtpClient
                {
                    Host = "mail.pizarra21.com",
                    Port = 25,
                    EnableSsl = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)

                };
                //para el cliente
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                })
                {
                    smtp.Send(message);
                }

                //pedido para el equipo pizarra21
                using (var message = new MailMessage(fromAddress, toAddress2)
                {
                    Subject = subjectpizarra,
                    Body = bodypizarra,
                    IsBodyHtml = true
                })
                {
                    smtp.Send(message);
                }

                //pedido para correo jose
                using (var message = new MailMessage(fromAddress, toAddress3)
                {
                    Subject = subjectpizarra,
                    Body = bodypizarra,
                    IsBodyHtml = true
                })
                {
                    smtp.Send(message);
                }

                objResultado = new
                {
                    iresultado = 1,
                    iresultadoins = "Correcto."
                };

            }
            catch (Exception ex)
            {
                UtlLog.toWrite(UtlConstantes.PizarraWEB, UtlConstantes.LogNamespace_PizarraWEB, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
            return Json(objResultado);
        }

        //tipo de conexion 4 es enviar nombre y celular
        [HttpPost]
        public async Task<JsonResult> ContactarNumero(string wnombre, string wcelular)
        {
            var objResultado = new object();
            try
            {
                string pdmac = UtlAuditoria.ObtenerDireccionMAC();
                string pdip = UtlAuditoria.ObtenerDireccionIP();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage Resregsesion = await client.GetAsync("api/usuario/APIRegistrarSesiones?wsidalumno=" + 1 + "&wsdireccionip=" + pdip + "&wsdireccionmac=" + pdmac + "&wstipoconexion=" + 4);
                    if (Resregsesion.IsSuccessStatusCode)
                    {
                        var rwsrs = Resregsesion.Content.ReadAsAsync<string>().Result;
                    }
                    else
                    {
                        objResultado = new
                        {
                            iresultado = -5,
                            iresultadoins = "Error, por favor inténtelo en unos momentos."
                        };

                    }
                }

                //AQUI DEBE ENVIAR CORREO
                var fromAddress = new MailAddress("contacto@pizarra21.com", "Pizarra21");
                var toAddress2 = new MailAddress("contacto@pizarra21.com", "Pizarra21");
                var toAddress3 = new MailAddress("juvesmme20@gmail.com", "Pizarra21");
                const string fromPassword = "@contacto123";
                //ini datos listerup
                string subjectpizarra = "Información de " + wnombre + " en pizarra21";
                string bodypizarra = wnombre + " ha solicitado más información con los siguientes datos: " +
                            "<br /> (nombre: " + wnombre + " )." +
                            "<br /> (celular: " + wcelular + " ).";

                //fin datos listerup
                var smtp = new SmtpClient
                {
                    Host = "mail.pizarra21.com",
                    Port = 25,
                    EnableSsl = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)

                };
                //pedido para el equipo pizarra21
                using (var message = new MailMessage(fromAddress, toAddress2)
                {
                    Subject = subjectpizarra,
                    Body = bodypizarra,
                    IsBodyHtml = true
                })
                {
                    smtp.Send(message);
                }

                //pedido para correo jose
                using (var message = new MailMessage(fromAddress, toAddress3)
                {
                    Subject = subjectpizarra,
                    Body = bodypizarra,
                    IsBodyHtml = true
                })
                {
                    smtp.Send(message);
                }

                objResultado = new
                {
                    iresultado = 1,
                    iresultadoins = "Correcto."
                };

            }
            catch (Exception ex)
            {
                UtlLog.toWrite(UtlConstantes.PizarraWEB, UtlConstantes.LogNamespace_PizarraWEB, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
            return Json(objResultado);
        }

    }
}