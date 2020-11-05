using System;
using System.Web.Http;
using backendED;
using backendTD;
using Newtonsoft.Json;

namespace globalws.Controllers
{
    public class docenteController : ApiController
    {
        tdDocente itdDocente;

        [HttpGet]
        public int APIValidarCorreo(string correo)
        {
            int iresultado = -1;
            try
            {
                itdDocente = new tdDocente();
                iresultado = itdDocente.tdValidarCorreo(correo);
                return iresultado;
            }
            catch (Exception)
            {
                return iresultado;

            }
        }

        [HttpGet]
        public int APIRegistrarDocente(string wnombrer, string wapellidor, string wemailr, string wclaver)
        {
            int iresultado = -1;
            try
            {
                itdDocente = new tdDocente();
                iresultado = itdDocente.tdRegistrarDocente(wnombrer, wapellidor, wemailr, wclaver);
                return iresultado;
            }
            catch (Exception ex)
            {
                return iresultado;

            }
        }

        [HttpGet]
        public string APIListarDocente(int widdocente)
        {
            edDocente wsenUsuario = new edDocente();
            try
            {
                itdDocente = new tdDocente();
                wsenUsuario = itdDocente.tdListarDocente(widdocente);
                return JsonConvert.SerializeObject(wsenUsuario);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex);
            }
        }

        [HttpGet]
        public int APILogeoDocente(string wcorreo, string wclave)
        {
            int iresultado = -1;
            try
            {
                itdDocente = new tdDocente();
                iresultado = itdDocente.tdLogeoDocente(wcorreo, wclave);
                return iresultado;
            }
            catch (Exception)
            {
                return iresultado;

            }
        }

        [HttpGet]
        public int APIRegistrarSesiones(int widdocente, string wdireccionip, string wdireccionmac, int wtipoconexion)
        {
            int iresultado = -1;
            try
            {
                itdDocente = new tdDocente();
                iresultado = itdDocente.tdRegistrarSesiones(widdocente, wdireccionip, wdireccionmac, wtipoconexion);
                return iresultado;
            }
            catch (Exception)
            {
                return iresultado;

            }
        }

    }
}