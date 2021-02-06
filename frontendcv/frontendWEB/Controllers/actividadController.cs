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

            ViewBag.VGidusuario = int.Parse(Session["SESSION_IDUSUARIO_OV"].ToString());
            ViewBag.VGidrespuesta = idrespuesta;
            return View();
        }

        public ActionResult faseUno(int idusuario, int itipoCompleto)
        {
            ViewBag.VGidusuario = idusuario;
            ViewBag.VGitipoCompleto = itipoCompleto;
            return View();
        }

        public ActionResult faseDos(int idusuario, int itipoCompleto)
        {
            ViewBag.VGidusuario = idusuario;
            ViewBag.VGitipoCompleto = itipoCompleto;
            return View();
        }

        public ActionResult faseTres(int idusuario, int itipoCompleto)
        {
            ViewBag.VGidusuario = idusuario;
            ViewBag.VGitipoCompleto = itipoCompleto;
            return View();
        }

        public ActionResult faseCuatro(int idusuario, int itipoCompleto)
        {
            ViewBag.VGidusuario = idusuario;
            ViewBag.VGitipoCompleto = itipoCompleto;
            return View();
        }

        public ActionResult faseCinco(int idusuario, int itipoCompleto)
        {
            ViewBag.VGidusuario = idusuario;
            ViewBag.VGitipoCompleto = itipoCompleto;
            return View();
        }

        public ActionResult faseSeis(int idusuario, int itipoCompleto)
        {
            ViewBag.VGidusuario = idusuario;
            ViewBag.VGitipoCompleto = itipoCompleto;
            return View();
        }

        public ActionResult faseSiete(int idusuario, int itipoCompleto)
        {
            ViewBag.VGidusuario = idusuario;
            ViewBag.VGitipoCompleto = itipoCompleto;
            return View();
        }

        public ActionResult faseOcho(int idusuario, int itipoCompleto)
        {
            ViewBag.VGidusuario = idusuario;
            ViewBag.VGitipoCompleto = itipoCompleto;
            return View();
        }

        public ActionResult faseNueve(int idusuario, int itipoCompleto)
        {
            ViewBag.VGidusuario = idusuario;
            ViewBag.VGitipoCompleto = itipoCompleto;
            return View();
        }

        public ActionResult faseDiez(int idusuario, int itipoCompleto)
        {
            ViewBag.VGidusuario = idusuario;
            ViewBag.VGitipoCompleto = itipoCompleto;
            return View();
        }

        public ActionResult faseOnce(int idusuario, int itipoCompleto)
        {
            ViewBag.VGidusuario = idusuario;
            ViewBag.VGitipoCompleto = itipoCompleto;
            return View();
        }

        public ActionResult faseDoce(int idusuario, int itipoCompleto)
        {
            ViewBag.VGidusuario = idusuario;
            ViewBag.VGitipoCompleto = itipoCompleto;
            return View();
        }

        // registra a los alumnos en orientacion vocacional (USUARIO)
        public async Task<JsonResult> RegistrarAlumnoOV(int wactividad, string wnombres
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
                HttpResponseMessage Resregrusu = await client.GetAsync("api/actividad/APIRegistrarAlumnoOV?wsactividad=" + wactividad +
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

        // registra las preguntas por cada fase (USUARIO)
        public async Task<JsonResult> InsertarFase(int idaa, int idad, int i_fase, string v1, string v2
                    , string v3, string v4, string v5, string v6, string v7, string v8, string v9
                    , string v10, string v11, string v12, string v13, string v14, string v15
                    , string v16, string v17, string v18, string v19, string v20, string v21
                    , string v22, string v23, string v24, string v25, string v26, string v27
                    , string v28, string v29, string v30, string v31, string v32, string v33
                    , string v34, string v35, string v36, string v37, string v38, string v39
                    , string v40, string v41, string v42, string v43, string v44, string v45
                    , string v46, string v47, string v48, string v49, string v50, string v51
                    , string v52, string v53, string v54, string v55, string v56, string v57
                    , string v58, string v59, string v60, int i_puntaje, string vdes
                    , int itipopreg, int best, string dtfr)
        {
            int iresultado = 0;
            var obj = new object();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Resregrusu = await client.GetAsync("api/actividad/APIInsertarFase?idaa=" + idaa +
                    "&idad=" + idad + "&i_fase=" + i_fase + "&v1=" + v1 + "&v2=" + v2 + "&v3=" + v3
                    + "&v4=" + v4 + "&v5=" + v5 + "&v6=" + v6 + "&v7=" + v7 + "&v8=" + v8 + "&v9=" + v9
                    + "&v10=" + v10 + "&v11=" + v11 + "&v12=" + v12 + "&v13=" + v13 + "&v14=" + v14
                    + "&v15=" + v15 + "&v16=" + v16 + "&v17=" + v17 + "&v18=" + v18 + "&v19=" + v19
                    + "&v20=" + v20 + "&v21=" + v21 + "&v22=" + v22 + "&v23=" + v23 + "&v24=" + v24
                    + "&v25=" + v25 + "&v26=" + v26 + "&v27=" + v27 + "&v28=" + v28 + "&v29=" + v29
                    + "&v30=" + v30 + "&v31=" + v31 + "&v32=" + v32 + "&v33=" + v33 + "&v34=" + v34
                    + "&v35=" + v35 + "&v36=" + v36 + "&v37=" + v37 + "&v38=" + v38 + "&v39=" + v39
                    + "&v40=" + v40 + "&v41=" + v41 + "&v42=" + v42 + "&v43=" + v43 + "&v44=" + v44
                    + "&v45=" + v45 + "&v46=" + v46 + "&v47=" + v47 + "&v48=" + v48 + "&v49=" + v49
                    + "&v50=" + v50 + "&v51=" + v51 + "&v52=" + v52 + "&v53=" + v53 + "&v54=" + v54
                    + "&v55=" + v55 + "&v56=" + v56 + "&v57=" + v57 + "&v58=" + v58 + "&v59=" + v59
                    + "&v60=" + v60 + "&i_puntaje=" + i_puntaje + "&vdes=" + vdes + "&itipopreg=" + itipopreg
                    + "&best=" + best + "&dtfr=" + dtfr);
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

        // actualiza los datos de cada fase de los alumnos (ADMIN)
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
                HttpResponseMessage Resregrusu = await client.GetAsync("api/actividad/APIActualizarFaseFinal?wsidactividadAlumno=" + widactividadAlumno +
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

        // actualiza los datos de cada fase de los alumnos (ADMIN)
        public async Task<JsonResult> ActualizarClase(int wsidactividadalumno, int wsifase
                                , string wssdescripcion, int wsitipo_pregunta, int wsipuntaje)
        {
            int iresultado = 0;
            var obj = new object();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Resregrusu = await client.
                    GetAsync("api/actividad/APIActualizarResultadoxFase?wsidactividadalumno=" + wsidactividadalumno
                    + "&wsifase=" + wsifase + "&wssdescripcion=" + wssdescripcion
                    + "&wsitipo_pregunta=" + wsitipo_pregunta + "&wsipuntaje=" + wsipuntaje);
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

        // obtiene los datos del alumno dependiendo del correo (ADMIN)
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
                HttpResponseMessage Reslistarusu = await client.GetAsync("api/actividad/APIListarDatosAlumno?wsGeneralcorreo=" + wcorreo);
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

        // obtiene las respuestas marcadas por el alumno (ADMIN)
        [HttpPost]
        public async Task<JsonResult> ListarActividadAlumnoDetalle(int widactividad, int wifase)
        {
            var objResultado = new object();
            List<edActividad> loenActividad = new List<edActividad>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Reslistarusu = await client
                    .GetAsync("api/actividad/APIListarRespuestasxFase?wsidactividad="
                                + widactividad + "&wsifase=" + wifase);
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

        // inicia sesion de cada usuario (ALUMNO)
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
                    client.GetAsync("api/actividad/APIListarLoginOV?wscorreoacs=" + wcorreoacs + "&wsclaveacs=" + wclaveacs);
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

        // obtiene los numeros de las fases de los usuarios dependiendo del id del mismo (USUARIO)
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
                    client.GetAsync("api/actividad/APIListarFasexUsuario?wsidactividadFase=" + widactividadFase);
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

        // obtiene el listado de usuarios (ADMIN)
        [HttpPost]
        public async Task<ActionResult> ListarUsuariosOrientacion(string wsnombres, string wsapellidos)
        {
            var objResultado = new object();
            //int Sessionwidalumno = int.Parse(Session["SESSION_IDUSUARIO_OV"].ToString());
            List<edActividad> loenActividad = new List<edActividad>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Reslistarusu = await
                    client.GetAsync("api/actividad/APIListarUsuariosOrientacion?wsnombres=" + wsnombres + "&wsapellidos=" + wsapellidos);
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