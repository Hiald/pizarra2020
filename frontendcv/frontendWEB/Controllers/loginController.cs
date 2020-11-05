using frontendED;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Reflection;
using frontendUtil;

namespace frontendWEB.Controllers
{
    public class loginController : Controller
    {
        [HttpGet]
        public ActionResult inicio()
        {
            return View();
        }

        [HttpGet]
        public ActionResult registro()
        {
            return View();
        }

        // -1 es error de controlador general
        // -2 es error de cuenta deshabilitada
        // -3 es error de correo
        // -5 es error de backend
        [HttpPost]
        public async Task<JsonResult> registrarusuario(string wnombre, string wapellido, string wemail, int wetapa, int wgrado,
                                                        int wseccion, string wnombrepadre, string wclave)
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
                    HttpResponseMessage Reswsvc = await client.GetAsync("api/usuario/APIValidarUsuario?wscorreo=" + wemail);

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

                int iresultadoCorreo = -1;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Reswsvc = await client.GetAsync("api/usuario/APIValidarCorreo?correo=" + wemail);

                    if (Reswsvc.IsSuccessStatusCode)
                    {
                        var lpoVC = Reswsvc.Content.ReadAsAsync<string>().Result;
                        iresultadoCorreo = int.Parse(lpoVC);
                        if (iresultadoCorreo == 1)
                        {
                            objResultado = new
                            {
                                iResultado = -3,
                                iResultadoIns = "El correo ya existe"
                            };
                            return Json(objResultado);
                        }

                        if (iresultadoCorreo == -1)
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
                    HttpResponseMessage Reswsru = await client.GetAsync("api/usuario/APIRegistrarUsuario?wnombrer=" + wnombre
                        + "&wapellido=" + wapellido + "&wemail=" + wemail + "&wetapa=" + wetapa + "&wgrado=" + wgrado + "&wseccion=" + wseccion
                        + "&wnombrepadre=" + wnombrepadre + "&wclaver=" + wclave);
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

                edUsuario oEnUsuario = new edUsuario();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Reslistarusu = await client.GetAsync("api/usuario/APIListarUsuario?widusuario=" + iresultadoreg);
                    if (Reslistarusu.IsSuccessStatusCode)
                    {
                        var rwsapilu = Reslistarusu.Content.ReadAsAsync<string>().Result;
                        oEnUsuario = JsonConvert.DeserializeObject<edUsuario>(rwsapilu);
                    }
                    else
                    {
                        oEnUsuario.iRespuesta = -1;
                    }
                }

                Dictionary<string, string> DVariables = new Dictionary<string, string>();
                DVariables["IdAlumno"] = oEnUsuario.idalumno.ToString();
                DVariables["Snombre"] = oEnUsuario.snombre;
                DVariables["Semail"] = oEnUsuario.semail;
                DVariables["IEtapaEscolar"] = oEnUsuario.ietapaescolar.ToString();
                DVariables["IGrado"] = oEnUsuario.igrado.ToString();
                DVariables["ISeccion"] = oEnUsuario.iseccion.ToString();
                DVariables["ITipodoc"] = oEnUsuario.itipodoc.ToString();
                DVariables["Sdocumento"] = oEnUsuario.sdocumento;
                DVariables["Isuscripcionestado"] = oEnUsuario.isuscripcionestado.ToString();
                DVariables["Iactivo"] = oEnUsuario.iactivo.ToString();
                DVariables["Imatriculado"] = oEnUsuario.imatriculado.ToString();
                UtlAuditoria.SetSessionValues(DVariables);

                string pdmac = UtlAuditoria.ObtenerDireccionMAC();
                string pdip = UtlAuditoria.ObtenerDireccionIP();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage Resregsesion = await client.GetAsync("api/usuario/APIRegistrarSesiones?widalumno=" + oEnUsuario.idalumno + "&wdireccionip=" + pdip + "&wdireccionmac=" + pdmac + "&wtipoconexion=" + 1);
                    if (Resregsesion.IsSuccessStatusCode)
                    {
                        var rwsrs = Resregsesion.Content.ReadAsAsync<string>().Result;
                    }

                }

                objResultado = new
                {
                    iResultado = 1,
                    iResultadoIns = "main/index"
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
        public async Task<JsonResult> loginusuario(string sUsuario, string sClave)
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
                    HttpResponseMessage Reswsvc = await client.GetAsync("api/usuario/APIValidarUsuario?wscorreo=" + sUsuario);

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

                int irespuesta = -1;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Reslogueo = await client.GetAsync("api/usuario/APILogeoUsuario?wcorreo=" + sUsuario + "&wclave=" + sClave);

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

                edUsuario oEnUsuario = new edUsuario();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Reslistarusu = await client.GetAsync("api/usuario/APIListarUsuario?widusuario=" + irespuesta);
                    if (Reslistarusu.IsSuccessStatusCode)
                    {
                        var rwsapilu = Reslistarusu.Content.ReadAsAsync<string>().Result;
                        oEnUsuario = JsonConvert.DeserializeObject<edUsuario>(rwsapilu);
                    }
                    else
                    {
                        oEnUsuario.iRespuesta = -1;
                    }
                }

                Dictionary<string, string> DVariables = new Dictionary<string, string>();
                DVariables["IdAlumno"] = oEnUsuario.idalumno.ToString();
                DVariables["Snombre"] = oEnUsuario.snombre;
                DVariables["Semail"] = oEnUsuario.semail;
                DVariables["IEtapaEscolar"] = oEnUsuario.ietapaescolar.ToString();
                DVariables["IGrado"] = oEnUsuario.igrado.ToString();
                DVariables["ISeccion"] = oEnUsuario.iseccion.ToString();
                DVariables["ITipodoc"] = oEnUsuario.itipodoc.ToString();
                DVariables["Sdocumento"] = oEnUsuario.sdocumento;
                DVariables["Isuscripcionestado"] = oEnUsuario.isuscripcionestado.ToString();
                DVariables["Iactivo"] = oEnUsuario.iactivo.ToString();
                DVariables["Imatriculado"] = oEnUsuario.imatriculado.ToString();
                UtlAuditoria.SetSessionValues(DVariables);

                string pdip = UtlAuditoria.ObtenerDireccionIP();
                string pdmac = UtlAuditoria.ObtenerDireccionMAC();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Resregsesion = await client.GetAsync("api/usuario/APIRegistrarSesiones?widalumno=" + oEnUsuario.idalumno + "&wdireccionip=" + pdip + "&wdireccionmac=" + pdmac + "&wtipoconexion=" + 1);
                    if (Resregsesion.IsSuccessStatusCode)
                    {
                        var rwsrs = Resregsesion.Content.ReadAsAsync<string>().Result;
                    }
                }

                objResultado = new
                {
                    iResultado = 1,
                    iResultadoIns = "main/index"
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

                    HttpResponseMessage Resregsesion = await client.GetAsync("api/usuario/APIRegistrarSesiones?widalumno=" + idUsuario + "&wdireccionip=" + pdip + "&wdireccionmac=" + pdmac + "&wtipoconexion=" + 2);
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

    }
}