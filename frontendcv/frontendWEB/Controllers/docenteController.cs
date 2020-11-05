using frontendWEB.Filters;
using frontendED;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Reflection;
using frontendUtil;

namespace frontendWEB.Controllers
{
    public class docenteController : Controller
    {
        [HttpGet]
        public ActionResult inicio()
        {
            return View();
        }

        [HttpGet]
        public ActionResult nuevo()
        {
            return View();
        }

        [HttpGet]
        [SeguridadSesion]
        public ActionResult archivo()
        {
            return View();
        }

        [HttpGet]
        [SeguridadSesion]
        public ActionResult listado()
        {
            return View();
        }

        [HttpGet]
        [SeguridadSesion]
        public ActionResult mainDocente()
        {
            int GIdusuario = UtlAuditoria.ObtenerIdUsuario();
            string GNombrecompleto = UtlAuditoria.ObtenerNombre();
            string GCorreo = UtlAuditoria.ObtenerCorreo();
            ViewBag.Gusuario = GIdusuario;
            ViewBag.Gnombre = GNombrecompleto;
            ViewBag.Gcorreo = GCorreo;
            return View();
        }

        // -1 es error de controlador general
        // -2 es error de cuenta deshabilitada
        // -3 es error de correo
        // -5 es error de backend
        [HttpPost]
        public async Task<JsonResult> registrarDocente(string wnombre, string wapellido, string wemail, string wclave)
        {
            try
            {
                var objResultado = new object();

                int iresultadoCuenta = -1;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Reswsvc = await client.GetAsync("api/docente/APIValidarDocente?correo=" + wemail);

                    if (Reswsvc.IsSuccessStatusCode)
                    {
                        var lpoVC = Reswsvc.Content.ReadAsAsync<string>().Result;
                        iresultadoCuenta = int.Parse(lpoVC);
                        if (iresultadoCuenta == 1)
                        {
                            objResultado = new
                            {
                                iResultado = -2,
                                iResultadoIns = "La cuenta ha sido deshabilitada, póngase en contacto con nosotros"
                            };
                            return Json(objResultado);
                        }

                        if (iresultadoCuenta == -1)
                        {
                            objResultado = new
                            {
                                iResultado = -5,
                                iResultadoIns = "Ha ocurrido un error, inténtelo nuevamente"
                            };
                            return Json(objResultado);
                        }
                    }
                }

                int iresultadoreg = -1;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Reswsru = await client.GetAsync("api/docente/APIRegistrarDocente?wnombrer=" + wnombre
                        + "&wapellidor=" + wapellido + "&wemailr=" + wemail + "&wclaver=" + wclave);
                    if (Reswsru.IsSuccessStatusCode)
                    {
                        var lpoEnUsuarioreg = Reswsru.Content.ReadAsAsync<string>().Result;
                        iresultadoreg = int.Parse(lpoEnUsuarioreg);

                        if (iresultadoreg == -1)
                        {
                            objResultado = new
                            {
                                iResultado = -5,
                                iResultadoIns = "Ha ocurrido un error, inténtelo nuevamente"
                            };
                        }
                    }
                }

                edDocente oEnUsuario = new edDocente();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Reslistarusu = await client.GetAsync("api/docente/APIListarDocente?widdocente=" + iresultadoreg);
                    if (Reslistarusu.IsSuccessStatusCode)
                    {
                        var rwsapilu = Reslistarusu.Content.ReadAsAsync<string>().Result;
                        oEnUsuario = JsonConvert.DeserializeObject<edDocente>(rwsapilu);
                    }
                    else
                    {
                        oEnUsuario.iRespuesta = -1;
                    }
                }

                Dictionary<string, string> DVariables = new Dictionary<string, string>();
                DVariables["IdAlumno"] = oEnUsuario.iddocente.ToString();
                DVariables["Snombre"] = oEnUsuario.snombre;
                DVariables["Semail"] = oEnUsuario.semail;
                DVariables["IEtapaEscolar"] = "0";
                DVariables["IGrado"] = "0";
                DVariables["ISeccion"] = "0";
                DVariables["ITipodoc"] = oEnUsuario.itipodoc.ToString();
                DVariables["Sdocumento"] = oEnUsuario.sdocumento;
                DVariables["Isuscripcionestado"] = "0";
                DVariables["Iactivo"] = oEnUsuario.iactivo.ToString();
                DVariables["Imatriculado"] = "0";
                UtlAuditoria.SetSessionValues(DVariables);

                string pdmac = UtlAuditoria.ObtenerDireccionMAC();
                string pdip = UtlAuditoria.ObtenerDireccionIP();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Resregsesion = await client.GetAsync("api/docente/APIRegistrarSesiones?widdocente=" + oEnUsuario.iddocente + "&wdireccionip=" + pdip + "&wdireccionmac=" + pdmac + "&wtipoconexion=" + 1);
                    if (Resregsesion.IsSuccessStatusCode)
                    {
                        var rwsrs = Resregsesion.Content.ReadAsAsync<string>().Result;
                    }
                }

                objResultado = new
                {
                    iResultado = 1,
                    iResultadoIns = "docente/mainDocente"
                };

                return Json(objResultado);
            }

            catch (Exception ex)
            {
                UtlLog.toWrite(UtlConstantes.PizarraWEB, UtlConstantes.LogNamespace_PizarraWEB, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        // -2 es cuenta deshabilitada
        // -3 usuario o clave incorrectos
        // -5 error en el backend
        [HttpPost]
        public async Task<JsonResult> loginDocente(string sUsuario, string sClave)
        {
            try
            {
                var objResultado = new object();

                int irespuesta = -1;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Reslogueo = await client.GetAsync("api/docente/APILogeoDocente?wcorreo=" + sUsuario + "&wclave=" + sClave);

                    if (Reslogueo.IsSuccessStatusCode)
                    {
                        var rwsapi = Reslogueo.Content.ReadAsAsync<string>().Result;
                        irespuesta = int.Parse(rwsapi);

                        if (irespuesta == -1 || irespuesta == 0)
                        {
                            //si la clave no es igual al correo
                            objResultado = new
                            {
                                iResultado = -3,
                                iResultadoIns = "El usuario o clave son incorrectos"
                            };
                            return Json(objResultado);
                        }

                    }
                }

                edDocente oEnUsuario = new edDocente();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Reslistarusu = await client.GetAsync("api/docente/APIListarDocente?widdocente=" + irespuesta);
                    if (Reslistarusu.IsSuccessStatusCode)
                    {
                        var rwsapilu = Reslistarusu.Content.ReadAsAsync<string>().Result;
                        oEnUsuario = JsonConvert.DeserializeObject<edDocente>(rwsapilu);
                    }
                    else
                    {
                        oEnUsuario.iRespuesta = -1;
                    }
                }

                Dictionary<string, string> DVariables = new Dictionary<string, string>();
                DVariables["IdAlumno"] = oEnUsuario.iddocente.ToString();
                DVariables["Snombre"] = oEnUsuario.snombre;
                DVariables["Semail"] = oEnUsuario.semail;
                DVariables["IEtapaEscolar"] = "0";
                DVariables["IGrado"] = "0";
                DVariables["ISeccion"] = "0";
                DVariables["ITipodoc"] = oEnUsuario.itipodoc.ToString();
                DVariables["Sdocumento"] = oEnUsuario.sdocumento;
                DVariables["Isuscripcionestado"] = "0";
                DVariables["Iactivo"] = oEnUsuario.iactivo.ToString();
                DVariables["Imatriculado"] = "0";
                UtlAuditoria.SetSessionValues(DVariables);

                string pdip = UtlAuditoria.ObtenerDireccionIP();
                string pdmac = UtlAuditoria.ObtenerDireccionMAC();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Resregsesion = await client.GetAsync("api/docente/APIRegistrarSesiones?widdocente=" + oEnUsuario.iddocente + "&wdireccionip=" + pdip + "&wdireccionmac=" + pdmac + "&wtipoconexion=" + 1);
                    if (Resregsesion.IsSuccessStatusCode)
                    {
                        var rwsrs = Resregsesion.Content.ReadAsAsync<string>().Result;
                    }
                }

                objResultado = new
                {
                    iResultado = 1,
                    iResultadoIns = "docente/mainDocente"
                };
                return Json(objResultado);
            }
            catch (Exception ex)
            {
                UtlLog.toWrite(UtlConstantes.PizarraWEB, UtlConstantes.LogNamespace_PizarraWEB, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                return Json(ex);
            }

        }

        [HttpPost]
        public async Task<ActionResult> ListarCurso(int wdidgrado, int wdidetapa, string wdnombre)
        {
            int GIdusuario = UtlAuditoria.ObtenerIdUsuario();
            var objResultado = new object();
            edCurso loenCurso = new edCurso();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Reslistarusu = await client.GetAsync("api/grado/APIListarDocente?wdidgrado=" + wdidgrado
                                                                            + "&wdidetapa=" + wdidetapa + "&wdnombre=" + wdnombre);
                if (Reslistarusu.IsSuccessStatusCode)
                {
                    var rwsapilu = Reslistarusu.Content.ReadAsAsync<string>().Result;
                    loenCurso = JsonConvert.DeserializeObject<edCurso>(rwsapilu);
                }
                else
                {
                    loenCurso = null;
                }
            }
            objResultado = new
            {
                rData = loenCurso
            };
            return Json(objResultado);
        }

        [HttpPost]
        public async Task<JsonResult> registrarCurso(int wdidcurso, string wdnombre, string wddescripcion, string wdrutavideo)
        {
            try
            {
                var objResultado = new object();

                int iresultadoreg = -1;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Reswsru = await client.GetAsync("api/grado/APIRegistrarCurso?wdidcurso=" + wdidcurso
                        + "&wdnombre=" + wdnombre + "&wddescripcion=" + wddescripcion + "&wdrutavideo=" + wdrutavideo);
                    if (Reswsru.IsSuccessStatusCode)
                    {
                        var lpoEnUsuarioreg = Reswsru.Content.ReadAsAsync<string>().Result;
                        iresultadoreg = int.Parse(lpoEnUsuarioreg);
                        if (iresultadoreg == 1)
                        {
                            objResultado = new
                            {
                                iResultado = 1,
                                iResultadoIns = "Ha ocurrido un error, inténtelo nuevamente"
                            };
                        }
                    }
                }

                objResultado = new
                {
                    iResultado = 1,
                    iResultadoIns = "docente/mainDocente"
                };

                return Json(objResultado);
            }

            catch (Exception ex)
            {
                UtlLog.toWrite(UtlConstantes.PizarraWEB, UtlConstantes.LogNamespace_PizarraWEB, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        [HttpPost]
        public async Task<JsonResult> cerrarSesion()
        {
            var objResultado = new object();
            try
            {
                int idUsuario = UtlAuditoria.ObtenerIdUsuario();
                string pdmac = UtlAuditoria.ObtenerDireccionMAC();
                string pdip = UtlAuditoria.ObtenerDireccionIP();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage Resregsesion = await client.GetAsync("api/docente/APIRegistrarSesiones?widdocente=" + idUsuario + "&wdireccionip=" + pdip + "&wdireccionmac=" + pdmac + "&wtipoconexion=" + 2);
                    if (Resregsesion.IsSuccessStatusCode)
                    {
                        var rwsrs = Resregsesion.Content.ReadAsAsync<string>().Result;
                    }

                }

                bool bResultado = UtlAuditoria.CerrarSession();
                if (bResultado)
                {
                    objResultado = new
                    {
                        iResultado = 1
                    };
                }
                else
                {
                    objResultado = new
                    {
                        iResultado = 2
                    };
                }
            }
            catch (Exception ex)
            {
                UtlLog.toWrite(UtlConstantes.PizarraWEB, UtlConstantes.LogNamespace_PizarraWEB, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
            return Json(objResultado);
        }

        public ActionResult accesoDenegado()
        {
            try
            {
                return View("inicio");
            }
            catch (Exception ex)
            {
                UtlLog.toWrite(UtlConstantes.PizarraWEB, UtlConstantes.LogNamespace_PizarraWEB, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                return View();
            }
        }

        [HttpPost]
        public async Task<JsonResult> ListarArchivo(int widvideo, int wtipoarchivo)
        {
            try
            {
                var objResultado = new object();

                List<edArchivo> loenCategoria = new List<edArchivo>();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Reslistarusu = await client.GetAsync("api/archivo/APIListarArchivo?wsidvideo=" + widvideo
                                                        + "&wstipoarchivo=" + wtipoarchivo);
                    if (Reslistarusu.IsSuccessStatusCode)
                    {
                        var rwsapilu = Reslistarusu.Content.ReadAsAsync<string>().Result;
                        loenCategoria = JsonConvert.DeserializeObject<List<edArchivo>>(rwsapilu);
                    }
                }

                objResultado = new
                {
                    PageStart = 1,
                    pageSize = 100,
                    SearchText = string.Empty,
                    ShowChildren = true,
                    iTotalRecords = loenCategoria.Count,
                    iTotalDisplayRecords = 1,
                    aaData = loenCategoria
                };
                return Json(objResultado);
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.PizarraWEB, UtlConstantes.LogNamespace_PizarraWEB, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                return Json(ex);
            }

        }

        [HttpPost]
        public async Task<JsonResult> registrarArchivo(int wvideoid, string wurl, int wtipoarchivo)
        {
            try
            {
                //tipo archivo 1 es drive pfd, el 2 es video en vivo
                var objResultado = new object();
                int idocenteId = UtlAuditoria.ObtenerIdUsuario();
                int iresultadoreg = -1;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Reswsru = await client.GetAsync("api/archivo/APIRegistrarArchivo?wsdocenteid=" + idocenteId
                        + "&wsvideoid=" + wvideoid + "&wstipoarchivo=" + wtipoarchivo + "&wsurl=" + wurl);
                    if (Reswsru.IsSuccessStatusCode)
                    {
                        var lpoEnCategoriaReg = Reswsru.Content.ReadAsAsync<string>().Result;
                        iresultadoreg = int.Parse(lpoEnCategoriaReg);

                        if (iresultadoreg == -1)
                        {
                            objResultado = new
                            {
                                iResultado = -5,
                                iResultadoIns = "Ha ocurrido un error, inténtelo nuevamente"
                            };
                        }
                    }
                }

                objResultado = new
                {
                    iResultado = 1,
                    iResultadoIns = "registrado"
                };

                return Json(objResultado);
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.PizarraWEB, UtlConstantes.LogNamespace_PizarraWEB, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        [HttpPost]
        public async Task<JsonResult> EliminarArchivo(int wvideoid)
        {
            try
            {
                var objResultado = new object();

                int iresultadoreg = -1;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Reswsru = await client.GetAsync("api/archivo/APIEliminarArchivo?tdidvideoel=" + wvideoid);
                    if (Reswsru.IsSuccessStatusCode)
                    {
                        var lpoEnCategoriaReg = Reswsru.Content.ReadAsAsync<string>().Result;
                        iresultadoreg = int.Parse(lpoEnCategoriaReg);

                        if (iresultadoreg == -1)
                        {
                            objResultado = new
                            {
                                iResultado = -5,
                                iResultadoIns = "Ha ocurrido un error, inténtelo nuevamente"
                            };
                        }
                    }
                }

                objResultado = new
                {
                    iResultado = 1,
                    iResultadoIns = "registrado"
                };

                return Json(objResultado);
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.PizarraWEB, UtlConstantes.LogNamespace_PizarraWEB, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult> BuscarVideo(int widcursol)
        {
            int GIdusuario = UtlAuditoria.ObtenerIdUsuario();
            var objResultado = new object();
            List<edCurso> loenCurso = new List<edCurso>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Reslistarusu = await client.GetAsync("api/grado/APIBuscarCurso?widmodulo=" + widcursol + "&widalumno=" + 1 + "&wfechabuscar=" + "regvideo");
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
                aaData = loenCurso
            };
            return Json(objResultado);
        }

        [HttpPost]
        public async Task<ActionResult> BuscarCurso(int GGrado, int GEtapa)
        {
            int GIdusuario = UtlAuditoria.ObtenerIdUsuario();
            var objResultado = new object();
            List<edCurso> loenCurso = new List<edCurso>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Reslistarusu = await client.GetAsync("api/grado/APIListarCurso?widcurso=" + GGrado + "&widetapa=" + GEtapa + "&widalumno=" + 1);
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
                aaData = loenCurso
            };
            return Json(objResultado);
        }

        //administrador
        [HttpPost]
        public async Task<ActionResult> ListadoVideo()
        {
            int GIdusuario = UtlAuditoria.ObtenerIdUsuario();
            var objResultado = new object();
            List<edCurso> loenCurso = new List<edCurso>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Reslistarusu = await client.GetAsync("api/grado/APIListadoCurso?wsvalor=" + 0);
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
                PageStart = 1,
                pageSize = 100,
                SearchText = string.Empty,
                ShowChildren = true,
                iTotalRecords = loenCurso.Count,
                iTotalDisplayRecords = 1,
                aaData = loenCurso
            };
            return Json(objResultado);
        }

        [HttpPost]
        public async Task<JsonResult> EliminarVideo(int wvideoid)
        {
            try
            {
                //tipo archivo 1 es drive pfd, el 2 es video en vivo
                var objResultado = new object();
                int idocenteId = UtlAuditoria.ObtenerIdUsuario();
                int iresultadoreg = -1;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Reswsru = await client.GetAsync("api/grado/APIEliminarCurso?wsidvideo=" + wvideoid);
                    if (Reswsru.IsSuccessStatusCode)
                    {
                        var lpoEnCategoriaReg = Reswsru.Content.ReadAsAsync<string>().Result;
                        iresultadoreg = int.Parse(lpoEnCategoriaReg);

                        if (iresultadoreg == -1)
                        {
                            objResultado = new
                            {
                                iResultado = -5,
                                iResultadoIns = "Ha ocurrido un error, inténtelo nuevamente"
                            };
                        }
                    }
                }

                objResultado = new
                {
                    iResultado = 1,
                    iResultadoIns = "registrado"
                };

                return Json(objResultado);
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.PizarraWEB, UtlConstantes.LogNamespace_PizarraWEB, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

    }
}