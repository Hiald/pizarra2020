using Newtonsoft.Json;
using backendED;
using backendTD;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace globalws.Controllers
{
    public class etapaController : ApiController
    {
        tdEtapa itdEtapa;

        // inicial, primaria, secundaria
        [HttpGet]
        public string APIListarEtapa(int widalumno)
        {
            List<edEtapa> wsenEtapa = new List<edEtapa>();
            try
            {
                itdEtapa = new tdEtapa();
                wsenEtapa = itdEtapa.tdListarEtapa(widalumno);
                return JsonConvert.SerializeObject(wsenEtapa);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex);
            }
        }

    }
}