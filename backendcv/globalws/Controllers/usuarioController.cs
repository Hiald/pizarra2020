using System;
using System.Collections.Generic;
using System.Web.Http;
using backendED;
using backendTD;
using Newtonsoft.Json;
namespace globalws.Controllers
{
    public class usuarioController : ApiController
    {
        tdUsuario itdUsuario;

        [HttpGet]
        public int APIRegistrarUsuario(string wnombrer, string wapellido, string wemail, int wetapa, int wgrado, int wseccion, string wnombrepadre, string wclaver)
        {
            int iresultado = -1;
            try
            {
                itdUsuario = new tdUsuario();
                iresultado = itdUsuario.tdRegistrarUsuario(wnombrer, wapellido, wemail, wetapa, wgrado, wseccion, wnombrepadre, wclaver);
                return iresultado;
            }
            catch (Exception ex)
            {
                return iresultado;

            }
        }

        [HttpGet]
        public string APIListarUsuario(int widusuario)
        {
            edUsuario wsenUsuario = new edUsuario();
            try
            {
                itdUsuario = new tdUsuario();
                wsenUsuario = itdUsuario.tdListarUsuario(widusuario);
                return JsonConvert.SerializeObject(wsenUsuario);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex);
            }
        }

        [HttpGet]
        public int APIValidarUsuario(string wscorreo)
        {
            int iresultado = -1;
            try
            {
                itdUsuario = new tdUsuario();
                iresultado = itdUsuario.tdValidarUsuario(wscorreo);
                return iresultado;
            }
            catch (Exception ex)
            {
                return iresultado;

            }
        }

        [HttpGet]
        public int APIValidarCorreo(string correo)
        {
            int iresultado = -1;
            try
            {
                itdUsuario = new tdUsuario();
                iresultado = itdUsuario.tdValidarCorreo(correo);
                return iresultado;
            }
            catch (Exception)
            {
                return iresultado;

            }
        }

        [HttpGet]
        public int APILogeoUsuario(string wcorreo, string wclave)
        {
            int iresultado = -1;
            try
            {
                itdUsuario = new tdUsuario();
                iresultado = itdUsuario.tdLogeoUsuario(wcorreo, wclave);
                return iresultado;
            }
            catch (Exception)
            {
                return iresultado;

            }
        }

        [HttpGet]
        public int APIRegistrarSesiones(int widalumno, string wdireccionip, string wdireccionmac, int wtipoconexion)
        {
            int iresultado = -1;
            try
            {
                itdUsuario = new tdUsuario();
                iresultado = itdUsuario.tdRegistrarSesiones(widalumno, wdireccionip, wdireccionmac, wtipoconexion);
                return iresultado;
            }
            catch (Exception)
            {
                return iresultado;

            }
        }

        /* CONFIGURACION */
        [HttpGet]
        public string APIListarUsuarioConfiguracion(string wcorreoc, string wnombrec, int wcategoriac)
        {
            if (wcorreoc == "vacio")
            {
                wcorreoc = "";
            }
            if (wnombrec == "vacio")
            {
                wnombrec = "";
            }
            List<edUsuario> wsenUsuario = new List<edUsuario>();
            try
            {
                itdUsuario = new tdUsuario();
                wsenUsuario = itdUsuario.tdListarUsuarioConfiguracion(wcorreoc, wnombrec, wcategoriac);
                return JsonConvert.SerializeObject(wsenUsuario);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex);
            }
        }

        [HttpGet]
        public int APIGenerarClave(int widalumno, string wnuevaclave)
        {
            int iresultado = -1;
            try
            {
                itdUsuario = new tdUsuario();
                iresultado = itdUsuario.tdGenerarClave(widalumno, wnuevaclave);
                return iresultado;
            }
            catch (Exception)
            {
                return iresultado;

            }
        }

    }
}