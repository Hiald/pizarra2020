using Newtonsoft.Json;
using backendED;
using backendTD;
using System;
using System.Web.Http;
using System.Collections.Generic;

namespace globalws.Controllers
{
    public class actividadController : ApiController
    {
        tdActividad itdActividad;

        [HttpGet]
        public string APIListarActividad(int wsactividaid)
        {
            List<edActividad> renArchivo = new List<edActividad>();
            try
            {
                itdActividad = new tdActividad();
                renArchivo = itdActividad.tdListarActividad(wsactividaid);
                return JsonConvert.SerializeObject(renArchivo);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex);
            }
        }

        [HttpGet]
        public int APIInsertarActividadAlumno(int wsactividad, string wsnombres
          , string wsapellidos, string wslugarnacimiento, int wsigrado, int wsiedad
          , int wsisexo, string wscelular, string wscorreo, string wscolegio, string wsdistrito, string wsugel
          , Int16 wsestado, string wsfechareg)
        {
            int iresultado = -1;
            try
            {
                DateTime wsfecharegistro = DateTime.Parse(wsfechareg);
                itdActividad = new tdActividad();
                iresultado = itdActividad.tdInsertarActividadAlumno(wsactividad, wsnombres
                                      , wsapellidos, wslugarnacimiento, wsigrado, wsiedad
                                      , wsisexo, wscelular, wscorreo, wscolegio, wsdistrito, wsugel
                                      , wsestado, wsfecharegistro);
                return iresultado;
            }
            catch (Exception)
            {
                return iresultado;

            }
        }

        [HttpGet]
        public int APIInsertarActividadAlumnoDetalle(int wsidactividadAlumno
                , int wsidactividadDetalle, Int16 wsrespuesta_A
                , Int16 wsrespuesta_B, Int16 wsrespuesta_C, Int16 wsrespuesta_D
                , Int16 wsrespuesta_E, int wsipuntaje, int wsitipoPregunta
                , Int16 wsestado)
        {
            int iresultado = -1;
            try
            {
                itdActividad = new tdActividad();
                iresultado = itdActividad.tdInsertarActividadAlumnoDetalle(wsidactividadAlumno
                                    , wsidactividadDetalle, wsrespuesta_A, wsrespuesta_B
                                    , wsrespuesta_C, wsrespuesta_D, wsrespuesta_E
                                    , wsipuntaje, wsitipoPregunta, wsestado);
                return iresultado;
            }
            catch (Exception)
            {
                return iresultado;

            }
        }

        [HttpGet]
        public int APIActualizarClase(int wsidactividadAlumno, string wscarrera1
                    , string wscarrera2, string wscarrera3, string wscarrera4
                    , string wscarrera5, int wsipuntaje, string wscomentario)
        {
            int iresultado = -1;
            try
            {
                itdActividad = new tdActividad();
                iresultado = itdActividad.tdActualizarClase(wsidactividadAlumno, wscarrera1
                                    , wscarrera2, wscarrera3, wscarrera4, wscarrera5
                                    , wsipuntaje, wscomentario);
                return iresultado;
            }
            catch (Exception)
            {
                return iresultado;

            }
        }

        [HttpGet]
        public string APIListarActividadAlumno(int wsvalor)
        {
            List<edActividad> renArchivo = new List<edActividad>();
            try
            {
                itdActividad = new tdActividad();
                renArchivo = itdActividad.tdListarActividadAlumno();
                return JsonConvert.SerializeObject(renArchivo);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex);
            }
        }

        [HttpGet]
        public string APIListarActividadAlumnoDetalle(int wsidactividad)
        {
            List<edActividad> renArchivo = new List<edActividad>();
            try
            {
                itdActividad = new tdActividad();
                renArchivo = itdActividad.tdListarActividadAlumnoDetalle(wsidactividad);
                return JsonConvert.SerializeObject(renArchivo);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex);
            }
        }

    }
}