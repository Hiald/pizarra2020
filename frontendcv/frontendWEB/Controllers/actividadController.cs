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
    public class actividadController : Controller
    {
        public ActionResult registro()
        {
            return View();
        }

        public ActionResult fase(int idrespuesta)
        {
            ViewBag.VGidrespuesta = idrespuesta;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ListarActividad(int wactividaid)
        {
            var objResultado = new object();
            List<edCurso> loenCurso = new List<edCurso>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Reslistarusu = await client.GetAsync("api/actividad/APIListarActividad?wsactividaid=1");
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

        public async Task<JsonResult> InsertarActividadAlumno(int wactividad, string wnombres
          , string wapellidos, string wlugarnacimiento, int wigrado, int wiedad
          , int wisexo, string wcelular, string wcorreo, string wcolegio, string wdistrito, string wugel)
        {
            int iresultado = 0;
            string wfechareg = DateTime.Now.ToString();
            var obj = new object();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Resregrusu = await client.GetAsync("api/actividad/APIInsertarActividadAlumno?wsactividad=" + wactividad +
                    "&wsnombres=" + wnombres + "&wsapellidos=" + wapellidos +
                    "&wslugarnacimiento=" + wlugarnacimiento + "&wsigrado=" + wigrado +
                    "&wsiedad=" + wiedad + "&wsisexo=" + wisexo + "&wscelular=" + wcelular + "&wscorreo=" + wcorreo +
                    "&wscolegio=" + wcolegio + "&wsdistrito=" + wdistrito + "&wsugel=" + wugel +
                    "&wsestado=" + 1 + "&wsfechareg=" + wfechareg);
                if (Resregrusu.IsSuccessStatusCode)
                {
                    var rwsapilu = Resregrusu.Content.ReadAsAsync<string>().Result;
                    iresultado = int.Parse(rwsapilu);
                    obj = new
                    {
                        iresultado = 1,
                    };
                }
                else
                {
                    obj = new
                    {
                        iresultado = -1,
                    };
                }
            }

            return Json(obj);
        }

        public async Task<JsonResult> InsertarActividadAlumnoDetalle(int widactividadAlumno
                , int widactividadDetalle, Int16 wrespuesta_A
                , Int16 wrespuesta_B, Int16 wrespuesta_C, Int16 wrespuesta_D
                , Int16 wrespuesta_E, int wipuntaje, int witipoPregunta
                , Int16 westado)
        {
            int iresultado = 0;
            var obj = new object();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Resregrusu = await client.GetAsync("api/actividad/APIInsertarActividadAlumnoDetalle?wsidactividadAlumno=" + widactividadAlumno +
                    "&widactividadDetalle=" + widactividadDetalle + "&wrespuesta_A=" + wrespuesta_A +
                    "&wrespuesta_B=" + wrespuesta_B + "&wrespuesta_C=" + wrespuesta_C +
                    "&wrespuesta_D=" + wrespuesta_D + "&wrespuesta_E=" + wrespuesta_E + "&wipuntaje=" + wipuntaje +
                    "&witipoPregunta=" + witipoPregunta + "&westado=" + westado);
                if (Resregrusu.IsSuccessStatusCode)
                {
                    var rwsapilu = Resregrusu.Content.ReadAsAsync<string>().Result;
                    iresultado = int.Parse(rwsapilu);
                    obj = new
                    {
                        iresultado = 1,
                    };
                }
                else
                {
                    obj = new
                    {
                        iresultado = -1,
                    };
                }
            }

            return Json(obj);
        }

        public async Task<JsonResult> ActualizarClase(int widactividadAlumno, string wcarrera1
                    , string wcarrera2, string wcarrera3, string wcarrera4
                    , string wcarrera5, int wipuntaje, string wcomentario)
        {
            int iresultado = 0;
            var obj = new object();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Resregrusu = await client.GetAsync("api/actividad/APIActualizarClase?wsidactividadAlumno=" + widactividadAlumno +
                    "&wscarrera1=" + wcarrera1 + "&wscarrera2=" + wcarrera2 +
                    "&wscarrera3=" + wcarrera3 + "&wscarrera4=" + wcarrera4 +
                    "&wscarrera5=" + wcarrera5 + "&wsipuntaje=" + wipuntaje + "&wscomentario=" + wcomentario);
                if (Resregrusu.IsSuccessStatusCode)
                {
                    var rwsapilu = Resregrusu.Content.ReadAsAsync<string>().Result;
                    iresultado = int.Parse(rwsapilu);
                    obj = new
                    {
                        iresultado = 1,
                    };
                }
                else
                {
                    obj = new
                    {
                        iresultado = -1,
                    };
                }
            }

            return Json(obj);
        }

        [HttpPost]
        public async Task<ActionResult> ListarActividadAlumno()
        {
            var objResultado = new object();
            List<edActividad> loenActividad = new List<edActividad>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Reslistarusu = await client.GetAsync("api/actividad/APIListarActividadAlumno?wsvalor=0");
                if (Reslistarusu.IsSuccessStatusCode)
                {
                    var rwsapilu = Reslistarusu.Content.ReadAsAsync<string>().Result;
                    loenActividad = JsonConvert.DeserializeObject<List<edActividad>>(rwsapilu);
                }
                else
                {
                    loenActividad = null;
                }
            }
            objResultado = new
            {
                PageStart = 1,
                pageSize = 100,
                SearchText = string.Empty,
                ShowChildren = true,
                iTotalRecords = loenActividad.Count,
                iTotalDisplayRecords = 1,
                aaData = loenActividad
            };
            return Json(objResultado);
        }

        [HttpPost]
        public async Task<ActionResult> ListarActividadAlumnoDetalle(int widactividad)
        {
            var objResultado = new object();
            List<edActividad> loenActividad = new List<edActividad>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Reslistarusu = await client.GetAsync("api/actividad/APIListarActividadAlumnoDetalle?wsidactividad=" + widactividad);
                if (Reslistarusu.IsSuccessStatusCode)
                {
                    var rwsapilu = Reslistarusu.Content.ReadAsAsync<string>().Result;
                    loenActividad = JsonConvert.DeserializeObject<List<edActividad>>(rwsapilu);
                }
                else
                {
                    loenActividad = null;
                }
            }
            objResultado = new
            {
                PageStart = 1,
                pageSize = 100,
                SearchText = string.Empty,
                ShowChildren = true,
                iTotalRecords = loenActividad.Count,
                iTotalDisplayRecords = 1,
                aaData = loenActividad
            };
            return Json(objResultado);
        }

    }
}