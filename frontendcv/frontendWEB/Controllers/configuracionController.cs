using Newtonsoft.Json;
using frontendED;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace frontendWEB.Controllers
{
    public class configuracionController : Controller
    {
        public ActionResult listado()
        {
            return View();
        }

        public async Task<JsonResult> listarcategoria()
        {
            List<edEtapa> loenCategoria = new List<edEtapa>();
            var obj = new object();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Reslistarusu = await client.GetAsync("api/etapa/APIListarEtapa?widalumno=" + 1);
                if (Reslistarusu.IsSuccessStatusCode)
                {
                    var rwsapilu = Reslistarusu.Content.ReadAsAsync<string>().Result;
                    loenCategoria = JsonConvert.DeserializeObject<List<edEtapa>>(rwsapilu);
                    obj = new
                    {
                        rDatos = loenCategoria,
                        sresult = "correcto"
                    };
                }
                else
                {
                    obj = new
                    {
                        rDatos = loenCategoria,
                        sresult = "vacio"
                    };

                }
            }

            return Json(obj);
        }

        public async Task<JsonResult> listarconfiguracion(string wcorreo, string wnombre, int wcategoria)
        {
            List<edUsuario> loenUsuario = new List<edUsuario>();
            var obj = new object();
            if (wcorreo == "")
            {
                wcorreo = "vacio";
            }
            if (wnombre == "")
            {
                wnombre = "vacio";
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Reslistarusu = await client.GetAsync("api/usuario/APIListarUsuarioConfiguracion?wcorreoc="
                                                            + wcorreo + "&wnombrec=" + wnombre + "&wcategoriac=" + wcategoria);
                if (Reslistarusu.IsSuccessStatusCode)
                {
                    var rwsapilu = Reslistarusu.Content.ReadAsAsync<string>().Result;
                    loenUsuario = JsonConvert.DeserializeObject<List<edUsuario>>(rwsapilu);
                    obj = new
                    {
                        rDatos = loenUsuario,
                        sresult = "correcto"
                    };
                }
                else
                {
                    obj = new
                    {
                        rDatos = loenUsuario,
                        sresult = "vacio"
                    };
                }
            }
            return Json(obj);
        }

        public async Task<JsonResult> RegistrarSieteMeses(int widalumno, int widcategoria, int wtipopago, string wcorreo)
        {
            int iresultado = 0;
            var obj = new object();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Reslistarusu = await client.GetAsync("api/pago/APIRegistrarSietemeses?widlumnos="
                                        + widalumno + "&widcategorias=" + widcategoria + "&wtipopagos=" + wtipopago);
                if (Reslistarusu.IsSuccessStatusCode)
                {
                    var rwsapilu = Reslistarusu.Content.ReadAsAsync<string>().Result;
                    iresultado = int.Parse(rwsapilu);
                    obj = new
                    {
                        iresultado = 1,
                        iresultadoins = iresultado
                    };
                }
                else
                {
                    obj = new
                    {
                        iresultado = -1,
                        iresultadoins = iresultado
                    };
                }
            }

            //AQUI DEBE ENVIAR CORREO
            var fromAddress = new MailAddress("contacto@pizarra21.com", "Pizarra21");
            var toAddress2 = new MailAddress(wcorreo, "Pizarra21");
            const string fromPassword = "huancainomedeng1@";
            //ini datos listerup
            string subjectpizarra = "¡Gracias por confiar en nosotros!";
            string bodypizarra = "Te damos la bienvenida al CICLO DE PREPARACION PARA LOS COLEGIOS DE ALTO RENDIMIENTO (COAR)" +
                        "<br /> Aprenderás y desarrollarás las habilidades necesarias para ingresar al COAR" +
                        "<br /><br /><br /> Lo que verás en este curso:" +
                        "<br /><br /> HABILIDADES BLANDAS (6 módulos)" +
                        "<br /> RAZONAMIENTO MATEMÁTICO(6 módulos)" +
                        "<br /> RAZONAMIENTO VERBAL (6 módulos)" +
                        "<br /><br /> Adicionalmente, te adjunto la gúia de uso de la plataforma educativa." +
                        "<br /> https://drive.google.com/file/d/16lWf_ct8GPJ9Ha3BPzaGVu2LwPeh0ErN/view?usp=sharing" +
                        "<br /><br /><br /> RECUERDA:" +
                        "<br /> Toda actualización del curso se hará cada semana directamente en la página: http://www.pizarra21.com" +
                        "<br /><br /> Saludos, Pizarra 21";


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

            return Json(obj);
        }

        public async Task<JsonResult> RegistrarDosMeses(int widalumno, int widcategoria, int wtipopago, string wcorreo)
        {
            int iresultado = 0;
            var obj = new object();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Reslistarusu = await client.GetAsync("api/pago/APIRegistrarMesmeses?widlumnod="
                                        + widalumno + "&widcategoriad=" + widcategoria + "&wtipopagod=" + wtipopago);
                if (Reslistarusu.IsSuccessStatusCode)
                {
                    var rwsapilu = Reslistarusu.Content.ReadAsAsync<string>().Result;
                    iresultado = int.Parse(rwsapilu);
                    obj = new
                    {
                        iresultado = 1,
                        iresultadoins = iresultado
                    };
                }
                else
                {
                    obj = new
                    {
                        iresultado = -1,
                        iresultadoins = iresultado
                    };
                }
            }

            //AQUI DEBE ENVIAR CORREO
            var fromAddress = new MailAddress("contacto@pizarra21.com", "Pizarra21");
            var toAddress2 = new MailAddress(wcorreo, "Pizarra21");
            const string fromPassword = "huancainomedeng1@";
            //ini datos listerup
            string subjectpizarra = "¡Gracias por confiar en nosotros!";
            string bodypizarra = "Te damos la bienvenida al CICLO DE PREPARACION PARA LOS COLEGIOS DE ALTO RENDIMIENTO (COAR)" +
                        "<br /> Aprenderás y desarrollarás las habilidades necesarias para ingresar al COAR" +
                        "<br /><br /><br /> Lo que verás en este curso:" +
                        "<br /><br /> HABILIDADES BLANDAS (6 módulos)" +
                        "<br /> RAZONAMIENTO MATEMÁTICO(6 módulos)" +
                        "<br /> RAZONAMIENTO VERBAL (6 módulos)" +
                        "<br /><br /> Adicionalmente, te adjunto la gúia de uso de la plataforma educativa." +
                        "<br /> https://drive.google.com/file/d/16lWf_ct8GPJ9Ha3BPzaGVu2LwPeh0ErN/view?usp=sharing" +
                        "<br /><br /><br /> RECUERDA:" +
                        "<br /> Toda actualización del curso se hará cada semana directamente en la página: http://www.pizarra21.com" +
                        "<br /><br /> Saludos, Pizarra 21";


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

            return Json(obj);
        }

        public async Task<JsonResult> RegistrarMes(int widalumno, int widcategoria, int wtipopago, string wcorreo)
        {
            int iresultado = 0;
            var obj = new object();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Reslistarusu = await client.GetAsync("api/pago/APIRegistrarMes?widlumnom="
                                        + widalumno + "&widcategoriam=" + widcategoria + "&wtipopagom=" + wtipopago);
                if (Reslistarusu.IsSuccessStatusCode)
                {
                    var rwsapilu = Reslistarusu.Content.ReadAsAsync<string>().Result;
                    iresultado = int.Parse(rwsapilu);
                    obj = new
                    {
                        iresultado = 1,
                        iresultadoins = iresultado
                    };
                }
                else
                {
                    obj = new
                    {
                        iresultado = -1,
                        iresultadoins = iresultado
                    };
                }
            }

            //AQUI DEBE ENVIAR CORREO
            var fromAddress = new MailAddress("contacto@pizarra21.com", "Pizarra21");
            var toAddress2 = new MailAddress(wcorreo, "Pizarra21");
            const string fromPassword = "huancainomedeng1@";
            //ini datos listerup
            string subjectpizarra = "¡Gracias por confiar en nosotros!";
            string bodypizarra = "Te damos la bienvenida al CICLO DE PREPARACION PARA LOS COLEGIOS DE ALTO RENDIMIENTO (COAR)" +
                        "<br /> Aprenderás y desarrollarás las habilidades necesarias para ingresar al COAR" +
                        "<br /><br /><br /> Lo que verás en este curso:" +
                        "<br /><br /> HABILIDADES BLANDAS (6 módulos)" +
                        "<br /> RAZONAMIENTO MATEMÁTICO(6 módulos)" +
                        "<br /> RAZONAMIENTO VERBAL (6 módulos)" +
                        "<br /><br /> Adicionalmente, te adjunto la gúia de uso de la plataforma educativa." +
                        "<br /> https://drive.google.com/file/d/16lWf_ct8GPJ9Ha3BPzaGVu2LwPeh0ErN/view?usp=sharing" +
                        "<br /><br /><br /> RECUERDA:" +
                        "<br /> Toda actualización del curso se hará cada semana directamente en la página: http://www.pizarra21.com" +
                        "<br /><br /> Saludos, Pizarra 21";


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

            return Json(obj);
        }

        public string CrearPassword(int longitud)
        {
            string caracteres = "abcdefghjkmnopqrstuvwxyzABCDEFGHJKMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < longitud--)
            {
                res.Append(caracteres[rnd.Next(caracteres.Length)]);
            }
            return res.ToString();
        }

        public async Task<JsonResult> GenerarClave(int widalumno)
        {
            string clavegenerada = CrearPassword(8);
            int iresultado = 0;
            var obj = new object();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Resregrusu = await client.GetAsync("api/usuario/APIGenerarClave?widalumno="
                                                                + widalumno + "&wnuevaclave=" + clavegenerada);
                if (Resregrusu.IsSuccessStatusCode)
                {
                    var rwsapilu = Resregrusu.Content.ReadAsAsync<string>().Result;
                    iresultado = int.Parse(rwsapilu);
                    obj = new
                    {
                        iresultado = 1,
                        iresultadoins = clavegenerada
                    };
                }
                else
                {
                    obj = new
                    {
                        iresultado = -1,
                        iresultadoins = clavegenerada
                    };
                }
            }

            return Json(obj);
        }

        public async Task<JsonResult> GuardarClave(int widalumno, string wnuevaclave)
        {
            int iresultado = 0;
            var obj = new object();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Reslistarusu = await client.GetAsync("api/pago/APIGenerarClave?widalumno="
                                                                + widalumno + "&wnuevaclave=" + wnuevaclave);
                if (Reslistarusu.IsSuccessStatusCode)
                {
                    var rwsapilu = Reslistarusu.Content.ReadAsAsync<string>().Result;
                    iresultado = int.Parse(rwsapilu);
                    obj = new
                    {
                        iresultado = 1,
                        iresultadoins = iresultado
                    };
                }
                else
                {
                    obj = new
                    {
                        iresultado = -1,
                        iresultadoins = iresultado
                    };
                }
            }

            return Json(obj);
        }

    }
}