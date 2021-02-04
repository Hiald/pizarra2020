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

        // registra a los alumnos en orientacion vocacional (USUARIO)
        [HttpGet]
        public int APIRegistrarAlumnoOV(int wsactividad, string wsnombres
          , string wsapellidos, string wslugarnacimiento, int wsigrado, int wsiedad
          , int wsisexo, string wscelular, string wscorreo, string wsclave, string wscolegio, string wsdistrito
          , string wsugel, Int16 wsestado, string wsfechareg)
        {
            int iresultado = -1;
            try
            {
                DateTime wsfecharegistro = DateTime.Parse(wsfechareg);
                itdActividad = new tdActividad();
                iresultado = itdActividad.tdRegistrarAlumnoOV(wsactividad, wsnombres
                                                    , wsapellidos, wslugarnacimiento, wsigrado, wsiedad
                                                    , wsisexo, wscelular, wscorreo, wsclave, wscolegio, wsdistrito
                                                    , wsugel, wsestado, wsfecharegistro);
                return iresultado;
            }
            catch (Exception)
            {
                return iresultado;

            }
        }

        // registra las preguntas por cada fase (USUARIO)
        [HttpGet]
        public int APIInsertarFase(int idaa, int idad, int i_fase, string v1, string v2
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
            int iresultado = -1;
            try
            {
                itdActividad = new tdActividad();
                iresultado = itdActividad.tdInsertarFase(idaa, idad, i_fase, v1, v2
                    , v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15
                    , v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27
                    , v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39
                    , v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51
                    , v52, v53, v54, v55, v56, v57, v58, v59, v60, i_puntaje, vdes
                    , itipopreg, best, dtfr);
                return iresultado;
            }
            catch (Exception)
            {
                return iresultado;

            }
        }

        // actualiza los datos de cada fase de los alumnos (ADMIN)
        [HttpGet]
        public int APIActualizarFaseFinal(int wsidactividadAlumno, string wscarrera1
                    , string wscarrera2, string wscarrera3, string wscarrera4
                    , string wscarrera5, int wsipuntaje, string wscomentario)
        {
            int iresultado = -1;
            try
            {
                itdActividad = new tdActividad();
                iresultado = itdActividad.tdActualizarFaseFinal(wsidactividadAlumno, wscarrera1
                                    , wscarrera2, wscarrera3, wscarrera4, wscarrera5
                                    , wsipuntaje, wscomentario);
                return iresultado;
            }
            catch (Exception)
            {
                return iresultado;

            }
        }

        // actualiza los datos de cada fase de los alumnos (ADMIN)
        [HttpGet]
        public int APIActualizarResultadoxFase(int wsidactividadalumno, int wsifase
                                , string wssdescripcion, int wsitipo_pregunta, int wsipuntaje)
        {
            int iresultado = -1;
            try
            {
                itdActividad = new tdActividad();
                iresultado = itdActividad.tdActualizarResultadoxFase(wsidactividadalumno, wsifase
                                                , wssdescripcion, wsitipo_pregunta, wsipuntaje);
                return iresultado;
            }
            catch (Exception)
            {
                return iresultado;

            }
        }

        // obtiene los datos del alumno dependiendo del correo (ADMIN)
        [HttpGet]
        public string APIListarDatosAlumno(string wsGeneralcorreo)
        {
            List<edActividad> renArchivo = new List<edActividad>();
            try
            {
                itdActividad = new tdActividad();
                renArchivo = itdActividad.tdListarDatosAlumno(wsGeneralcorreo);
                return JsonConvert.SerializeObject(renArchivo);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex);
            }
        }

        // obtiene las respuestas marcadas por el alumno (ADMIN)
        [HttpGet]
        public string APIListarRespuestasxFase(int wsidactividad, int wsifase)
        {
            List<edActividad> renArchivo = new List<edActividad>();
            try
            {
                itdActividad = new tdActividad();
                renArchivo = itdActividad.tdListarRespuestasxFase(wsidactividad, wsifase);
                return JsonConvert.SerializeObject(renArchivo);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex);
            }
        }

        // inicia sesion de cada usuario (ALUMNO)
        [HttpGet]
        public string APIListarLoginOV(string wscorreoacs, string wsclaveacs)
        {
            edActividad renArchivo = new edActividad();
            try
            {
                itdActividad = new tdActividad();
                renArchivo = itdActividad.tdListarLoginOV(wscorreoacs, wsclaveacs);
                return JsonConvert.SerializeObject(renArchivo);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex);
            }
        }

        // obtiene los numeros de las fases de los usuarios dependiendo del id del mismo (USUARIO)
        [HttpGet]
        public string APIListarFasexUsuario(int wsidactividadFase)
        {
            List<edActividad> renArchivo = new List<edActividad>();
            try
            {
                itdActividad = new tdActividad();
                renArchivo = itdActividad.tdListarFasexUsuario(wsidactividadFase);
                return JsonConvert.SerializeObject(renArchivo);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex);
            }
        }

        // obtiene el listado de usuarios (ADMIN)
        [HttpGet]
        public string APIListarUsuariosOrientacion(string wsnombres, string wsapellidos)
        {
            List<edActividad> renArchivo = new List<edActividad>();
            try
            {
                itdActividad = new tdActividad();
                renArchivo = itdActividad.tdListarUsuariosOrientacion(wsnombres, wsapellidos);
                return JsonConvert.SerializeObject(renArchivo);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex);
            }
        }

    }
}