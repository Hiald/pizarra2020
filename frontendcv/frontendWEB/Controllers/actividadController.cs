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
            if (Session["SESSION_IDUSUARIO_OV"] != null)
            {
                int valorsession = int.Parse(Session["SESSION_IDUSUARIO_OV"].ToString());
                return RedirectToAction("fase", "actividad", new { idrespuesta = valorsession });
            }
            else
            {
                return View();
            }

        }

        public ActionResult fase(int idrespuesta)
        {
            if (Session["SESSION_IDUSUARIO_OV"] == null)
            {
                return View("registro");
            }

            ViewBag.VGidrespuesta = idrespuesta;
            return View();
        }

        public ActionResult faseUno(int idusuario)
        {
            ViewBag.VGidusuario = idusuario;
            return View();
        }
        public ActionResult faseDos(int idusuario)
        {
            ViewBag.VGidusuario = idusuario;
            return View();
        }

        public ActionResult faseTres(int idusuario)
        {
            ViewBag.VGidusuario = idusuario;
            return View();
        }

        public ActionResult faseCuatro(int idusuario)
        {
            ViewBag.VGidusuario = idusuario;
            return View();
        }

        public ActionResult faseCinco(int idusuario)
        {
            ViewBag.VGidusuario = idusuario;
            return View();
        }

        public ActionResult faseSeis(int idusuario)
        {
            ViewBag.VGidusuario = idusuario;
            return View();
        }

        public ActionResult faseSiete(int idusuario)
        {
            ViewBag.VGidusuario = idusuario;
            return View();
        }

        public ActionResult faseOcho(int idusuario)
        {
            ViewBag.VGidusuario = idusuario;
            return View();
        }

        public ActionResult faseNueve(int idusuario)
        {
            ViewBag.VGidusuario = idusuario;
            return View();
        }

        public ActionResult faseDiez(int idusuario)
        {
            ViewBag.VGidusuario = idusuario;
            return View();
        }

        public ActionResult faseOnce(int idusuario)
        {
            ViewBag.VGidusuario = idusuario;
            return View();
        }

        public ActionResult faseDoce(int idusuario)
        {
            ViewBag.VGidusuario = idusuario;
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
          , int wisexo, string wcelular, string wcorreo, string wclave, string wcolegio, string wdistrito, string wugel)
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
                    "&wsclave=" + wclave + "&wscolegio=" + wcolegio + "&wsdistrito=" + wdistrito + "&wsugel=" + wugel +
                    "&wsestado=" + 1 + "&wsfechareg=" + wfechareg);
                if (Resregrusu.IsSuccessStatusCode)
                {
                    var rwsapilu = Resregrusu.Content.ReadAsAsync<string>().Result;
                    iresultado = int.Parse(rwsapilu);
                    if (iresultado != -1 || iresultado != 0)
                    {
                        Session["SESSION_IDUSUARIO_OV"] = iresultado;
                        obj = new
                        {
                            resultado = iresultado,
                        };
                    }
                    else
                    {
                        Session["SESSION_IDUSUARIO_OV"] = 0;
                        obj = new
                        {
                            resultado = 0,
                        };
                    }

                }

            }

            return Json(obj);
        }

        public async Task<JsonResult> InsertarActividadAlumnoDetalle(int widactividadAlumno, int widactividadDetalle
                , string wrespuesta_A, string wrespuesta_B, string wrespuesta_C, string wrespuesta_D
                , string wrespuesta_E, string wrespuesta_F, string wrespuesta_G, string wrespuesta_H
                , string wrespuesta_I, int wipuntaje, int wifase, int wipregunta, int witipopregunta)
        {
            int iresultado = 0;
            var obj = new object();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Resregrusu = await client.GetAsync("api/actividad/APIInsertarActividadAlumnoDetalle?wsidactividadAlumno=" + widactividadAlumno +
                "&wsidactividadDetalle=" + widactividadDetalle + "&wsrespuesta_A=" + wrespuesta_A +
                "&wsrespuesta_B=" + wrespuesta_B + "&wsrespuesta_C=" + wrespuesta_C + "&wsrespuesta_D=" + wrespuesta_D +
                "&wsrespuesta_E=" + wrespuesta_E + "&wsrespuesta_F=" + wrespuesta_F + "&wsrespuesta_G=" + wrespuesta_G +
                "&wsrespuesta_H=" + wrespuesta_H + "&wsrespuesta_I=" + wrespuesta_I + "&wsipuntaje=" + wipuntaje +
                "&wsifase=" + wifase + "&wspregunta=" + wipregunta + "&wsitipoPregunta=" + witipopregunta + "&wsestado=" + 1);
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
        public async Task<ActionResult> ListarActividadAlumno(string wcorreo)
        {
            var objResultado = new object();
            List<edActividad> loenActividad = new List<edActividad>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Reslistarusu = await client.GetAsync("api/actividad/APIListarActividadAlumno?wsGeneralcorreo=" + wcorreo);
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

        //no se usa
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

        [HttpPost]
        public async Task<ActionResult> ListarActividadAlumnoAcceso(string wcorreoacs, string wclaveacs)
        {
            var objResultado = new object();
            edActividad loenActividad = new edActividad();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Reslistarusu = await
                    client.GetAsync("api/actividad/APIListarActividadAlumnoAcceso?wscorreoacs=" + wcorreoacs + "&wsclaveacs=" + wclaveacs);
                if (Reslistarusu.IsSuccessStatusCode)
                {
                    var rwsapilu = Reslistarusu.Content.ReadAsAsync<string>().Result;
                    loenActividad = JsonConvert.DeserializeObject<edActividad>(rwsapilu);
                }
                else
                {
                    loenActividad = null;
                }
            }

            if (loenActividad != null)
            {
                Session["SESSION_IDUSUARIO_OV"] = loenActividad.idactividad;
                Session["SESSION_NOMBRES_OV"] = loenActividad.snombres;
                Session["SESSION_APELLIDOS_OV"] = loenActividad.sapellidos;
                Session["SESSION_CORREO_OV"] = loenActividad.scorreo;
                Session["SESSION_COLEGIO_OV"] = loenActividad.scolegio;
                objResultado = new
                {
                    resultado = loenActividad
                };
            }
            else
            {
                Session["SESSION_IDUSUARIO_OV"] = null;
                Session["SESSION_NOMBRES_OV"] = null;
                Session["SESSION_APELLIDOS_OV"] = null;
                Session["SESSION_CORREO_OV"] = null;
                Session["SESSION_COLEGIO_OV"] = null;
                objResultado = new
                {
                    resultado = ""
                };
            }

            return Json(objResultado);
        }

        [HttpPost]
        public async Task<JsonResult> ListarFases(int widactividadFase)
        {
            var objResultado = new object();
            List<edActividad> loenActividad = new List<edActividad>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Reslistarusu = await
                    client.GetAsync("api/actividad/APIListarFases?wsidactividadFase=" + widactividadFase);
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
                aaData = loenActividad
            };
            return Json(objResultado);
        }

        [HttpPost]
        public async Task<ActionResult> ListarPreguntasxFase(int wifase)
        {
            var objResultado = new object();
            int Sessionwidalumno = int.Parse(Session["SESSION_IDUSUARIO_OV"].ToString());
            List<edActividad> loenActividad = new List<edActividad>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Reslistarusu = await
                    client.GetAsync("api/actividad/APIListarPreguntasxFase?wsidalumno=" + Sessionwidalumno + "&wsifase=" + wifase);
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
                aaData = loenActividad
            };
            return Json(objResultado);
        }

        public JsonResult CerrarOV()
        {
            Session["SESSION_IDUSUARIO_OV"] = null;
            Session["SESSION_NOMBRES_OV"] = null;
            Session["SESSION_APELLIDOS_OV"] = null;
            Session["SESSION_CORREO_OV"] = null;
            Session["SESSION_COLEGIO_OV"] = null;
            return Json("");
        }

    }
}