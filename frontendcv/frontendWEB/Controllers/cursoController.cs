using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using frontendWEB.Filters;
using frontendED;
using frontendUtil;

namespace frontendWEB.Controllers
{
    public class cursoController : Controller
    {
        [HttpPost]
        [SeguridadSesion]
        public async Task<ActionResult> curso(int widcurso, int widsemana)
        {
            //wfechabuscar formato = 25/04/2020
            int GIdusuario = UtlAuditoria.ObtenerIdUsuario();
            string GNombrecompleto = UtlAuditoria.ObtenerNombre();
            string GCorreo = UtlAuditoria.ObtenerCorreo();

            List<edCurso> loenCurso = new List<edCurso>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Reslistarusu = await client.GetAsync("api/grado/APIBuscarCurso?widmodulo=" + widcurso + "&widalumno=" + GIdusuario + "&widsemana=" + widsemana);
                if (Reslistarusu.IsSuccessStatusCode)
                {
                    var rwsapilu = Reslistarusu.Content.ReadAsAsync<string>().Result;
                    if (rwsapilu == null)
                    {
                        ViewBag.iresultado = 0;
                    }
                    else
                    {
                        loenCurso = JsonConvert.DeserializeObject<List<edCurso>>(rwsapilu);
                        ViewBag.iresultado = 1;
                    }
                    if (loenCurso.Count == 1)
                    {
                        ViewBag.iresultado = 0;
                    }
                    else
                    {
                        ViewBag.iresultado = 1;
                    }
                }
                else
                {
                    loenCurso = null;
                }
            }
            ViewBag.Gwidcurso = widcurso;
            ViewBag.Gfechabuscar = widsemana;
            ViewBag.loenCursoConteo = loenCurso.Count;
            ViewBag.loenCurso = loenCurso;
            ViewBag.Gusuario = GIdusuario;
            ViewBag.Gnombre = GNombrecompleto;
            ViewBag.Gcorreo = GCorreo;
            return View();
        }

        [HttpPost]
        [SeguridadSesion]
        public ActionResult video(string wenlace, string wtitulo, int widvideo, int widcurso, int widsemana)
        {
            int GIdusuario = UtlAuditoria.ObtenerIdUsuario();
            string GNombrecompleto = UtlAuditoria.ObtenerNombre();
            string GCorreo = UtlAuditoria.ObtenerCorreo();

            var Senlace = "http://jurado-001-site3.gtempurl.com/" + wenlace;

            ViewBag.Gwidcurso = widcurso;
            ViewBag.Gfechabuscar = widsemana;
            ViewBag.Enlace = wenlace;
            ViewBag.idvideo = widvideo;
            ViewBag.titulo = wtitulo;
            ViewBag.Gusuario = GIdusuario;
            ViewBag.Gnombre = GNombrecompleto;
            ViewBag.Gcorreo = GCorreo;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ListarVideo(int widcursol, int wfechabuscarl)
        {
            int GIdusuario = UtlAuditoria.ObtenerIdUsuario();
            var objResultado = new object();
            List<edCurso> loenCurso = new List<edCurso>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Reslistarusu = await client.GetAsync("api/grado/APIBuscarCurso?widmodulo=" + widcursol + "&widalumno=" + GIdusuario + "&widsemana=" + wfechabuscarl);
                if (Reslistarusu.IsSuccessStatusCode)
                {
                    var rwsapilu = Reslistarusu.Content.ReadAsAsync<string>().Result;
                    loenCurso = JsonConvert.DeserializeObject<List<edCurso>>(rwsapilu);
                }
                else
                {
                    loenCurso = null;
                }
            }
            objResultado = new
            {
                rDatos = loenCurso,
            };
            return Json(objResultado);
        }


        public ActionResult DescargarPDF()
        {
            using (WebClient client = new WebClient())
            {
                //byte[] fileBytes = System.IO.File.ReadAllBytes("");
                byte[] fileBytes = client.DownloadData("https://es.unesco.org/creativity/sites/creativity/files/digital-library/cdis/Educacion.pdf");
                return File(fileBytes, "application/pdf", "educacion_" + DateTime.Now + ".pdf");
            }
        }

        public FileResult DescargarPDF2()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(@"c:\esd\Educacion.pdf");
            string fileName = "myfile.ext";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

    }
}