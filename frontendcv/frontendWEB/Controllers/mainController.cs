using frontendWEB.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using frontendUtil;
using System.Threading.Tasks;
using frontendED;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace frontendWEB.Controllers
{
    public class mainController : Controller
    {
        [SeguridadSesion]
        public async Task<ActionResult> index()
        {
            int GIdusuario = UtlAuditoria.ObtenerIdUsuario();
            string GNombrecompleto = UtlAuditoria.ObtenerNombre();
            string GCorreo = UtlAuditoria.ObtenerCorreo();
            int GEtapa = UtlAuditoria.ObtenerEtapaEscolar();
            int GGrado = UtlAuditoria.ObtenerGrado();

            List<edCurso> loenCurso = new List<edCurso>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Reslistarusu = await client.GetAsync("api/grado/APIListarCurso?widcurso=" + GGrado + "&widetapa=" + GEtapa + "&widalumno=" + GIdusuario);
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

            ViewBag.loenGrado = loenCurso;
            ViewBag.loenGradoConteo = loenCurso.Count;
            ViewBag.Gusuario = GIdusuario;
            ViewBag.Gnombre = GNombrecompleto;
            ViewBag.Gcorreo = GCorreo;
            return View();
        }

        public ActionResult timeout()
        {
            return RedirectToAction("inicio", "login");
        }

        public ActionResult error()
        {
            return View();
        }
    }
}