using Newtonsoft.Json;
using backendED;
using backendTD;
using System;
using System.Web.Http;

namespace globalws.Controllers
{
    public class pagoController : ApiController
    {
        tdPago itdPago;

        [HttpGet]
        public string APINotificarPago(int widusuario, int widcategoria)
        {
            edPago wsenPago = new edPago();
            try
            {
                itdPago = new tdPago();
                wsenPago = itdPago.tdNotificarPago(widusuario, widcategoria);
                return JsonConvert.SerializeObject(wsenPago);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex);
            }
        }

        [HttpGet]
        public int APIRegistrarSietemeses(string widlumnos, string widcategorias, int wtipopagos)
        {
            int iresultado = -1;
            try
            {
                itdPago = new tdPago();
                iresultado = itdPago.tdRegistrarSietemeses(widlumnos, widcategorias, wtipopagos);
                return iresultado;
            }
            catch (Exception)
            {
                return iresultado;

            }
        }

        [HttpGet]
        public int APIRegistrarMesmeses(string widlumnod, string widcategoriad, int wtipopagod)
        {
            int iresultado = -1;
            try
            {
                itdPago = new tdPago();
                iresultado = itdPago.tdRegistrarDosmeses(widlumnod, widcategoriad, wtipopagod);
                return iresultado;
            }
            catch (Exception)
            {
                return iresultado;

            }
        }

        [HttpGet]
        public int APIRegistrarMes(string widlumnom, string widcategoriam, int wtipopagom)
        {
            int iresultado = -1;
            try
            {
                itdPago = new tdPago();
                iresultado = itdPago.tdRegistrarMes(widlumnom, widcategoriam, wtipopagom);
                return iresultado;
            }
            catch (Exception)
            {
                return iresultado;

            }
        }

    }
}