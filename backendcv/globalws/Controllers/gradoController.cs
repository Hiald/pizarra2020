using Newtonsoft.Json;
using backendED;
using backendTD;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace globalws.Controllers
{
    public class gradoController : ApiController
    {
        tdGrado itdGrado;

        //primero, segundo,tercero,  ETC
        [HttpGet]
        public string APIListarGrado(int widcategoria, int widalumno)
        {
            List<edGrado> wsenGrado = new List<edGrado>();
            try
            {
                itdGrado = new tdGrado();
                wsenGrado = itdGrado.tdListarGrado(widcategoria, widalumno);
                return JsonConvert.SerializeObject(wsenGrado);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex);
            }
        }

        //matematica, quimica, fisica, etc
        [HttpGet]
        public string APIListarCurso(int widcurso, int widetapa, int widalumno)
        {
            List<edCurso> wsenCurso = new List<edCurso>();
            try
            {
                itdGrado = new tdGrado();
                wsenCurso = itdGrado.tdListarCurso(widcurso, widetapa, widalumno);
                return JsonConvert.SerializeObject(wsenCurso);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex);
            }
        }

        //VIDEO.mp4, etc
        [HttpGet]
        public string APIBuscarCurso(int widmodulo, int widalumno, int widsemana)
        {
            List<edCurso> wsenVideo = new List<edCurso>();
            try
            {
                itdGrado = new tdGrado();
                wsenVideo = itdGrado.tdListarVideo(widmodulo, widalumno, widsemana);
                return JsonConvert.SerializeObject(wsenVideo);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex);
            }
        }

        [HttpGet]
        public string APIListarDocente(int wdidgrado, int wdidetapa, string wdnombre)
        {
            edCurso wsenUsuario = new edCurso();
            try
            {
                itdGrado = new tdGrado();
                wsenUsuario = itdGrado.tdBuscarCurso(wdidgrado, wdidetapa, wdnombre);
                return JsonConvert.SerializeObject(wsenUsuario);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex);
            }
        }

        [HttpGet]
        public int APIRegistrarCurso(int wdidcurso, string wdnombre, string wddescripcion, string wdrutavideo, int widsemana)
        {
            int iresultado = -1;
            try
            {
                itdGrado = new tdGrado();
                iresultado = itdGrado.tdRegistrarCurso(wdidcurso, wdnombre, wddescripcion, wdrutavideo, widsemana);
                return iresultado;
            }
            catch (Exception ex)
            {
                return iresultado;

            }
        }

        // ADMINISTRADOR
        [HttpGet]
        public string APIListadoCurso(int wsvalor)
        {
            List<edCurso> wsenVideo = new List<edCurso>();
            try
            {
                itdGrado = new tdGrado();
                wsenVideo = itdGrado.tdListadoVideo();
                return JsonConvert.SerializeObject(wsenVideo);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex);
            }
        }

        [HttpGet]
        public int APIEliminarCurso(int wsidvideo)
        {
            int iresultado = -1;
            try
            {
                itdGrado = new tdGrado();
                iresultado = itdGrado.tdEliminarCurso(wsidvideo);
                return iresultado;
            }
            catch (Exception ex)
            {
                return iresultado;

            }
        }

    }
}