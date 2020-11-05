using Newtonsoft.Json;
using backendED;
using backendTD;
using System;
using System.Web.Http;
using System.Collections.Generic;

namespace globalws.Controllers
{
    public class archivoController : ApiController
    {
        tdArchivo itdArchivo;

        [HttpGet]
        public int APIRegistrarArchivo(int wsdocenteid, int wsvideoid, int wstipoarchivo, string wsurl)
        {
            int iresultado = -1;
            try
            {
                itdArchivo = new tdArchivo();
                iresultado = itdArchivo.tdRegistrarArchivo(wsdocenteid, wsvideoid, wstipoarchivo, wsurl);
                return iresultado;
            }
            catch (Exception)
            {
                return iresultado;

            }
        }

        [HttpGet]
        public string APIListarArchivo(int wsidvideo, int wstipoarchivo)
        {
            List<edArchivo> renArchivo = new List<edArchivo>();
            try
            {
                itdArchivo = new tdArchivo();
                renArchivo = itdArchivo.tdListarArchivo(wsidvideo, wstipoarchivo);
                return JsonConvert.SerializeObject(renArchivo);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex);
            }
        }

        [HttpGet]
        public int APIEliminarArchivo(int tdidvideoel)
        {
            int iresultado = -1;
            try
            {
                itdArchivo = new tdArchivo();
                iresultado = itdArchivo.tdEliminarArchivo(tdidvideoel);
                return iresultado;
            }
            catch (Exception)
            {
                return iresultado;

            }
        }

    }
}