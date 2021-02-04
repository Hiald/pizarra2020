using backendAD;
using backendED;
using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace backendTD
{
    public class tdActividad : td_ageneral
    {
        adActividad iadActividad;

        // registra a los alumnos en orientacion vocacional (USUARIO)
        public int tdRegistrarAlumnoOV(int tdactividad, string tdnombres
          , string tdapellidos, string tdlugarnacimiento, int tdigrado, int tdiedad
          , int tdisexo, string tdcelular, string tdcorreo, string tdclave, string tdcolegio, string tddistrito, string tdugel
          , Int16 tdestado, DateTime tdfecharegistro)
        {
            int iRespuesta = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {
                        iadActividad = new adActividad(con);
                        iRespuesta = iadActividad.adRegistrarAlumnoOV(tdactividad, tdnombres
                                              , tdapellidos, tdlugarnacimiento, tdigrado, tdiedad
                                              , tdisexo, tdcelular, tdcorreo, tdclave, tdcolegio, tddistrito, tdugel
                                              , tdestado, tdfecharegistro);
                        scope.Commit();
                    }
                }
                return (iRespuesta);
            }
            catch (MySqlException ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessRN, UtlConstantes.LogNamespace_TProcessRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }

        }

        // registra las preguntas por cada fase (USUARIO)
        public int tdInsertarFase(int id_actividad_alumno, int id_actividad_detalle,
                    int i_fase, string v_pregunta_1, string v_pregunta_2, string v_pregunta_3,
                    string v_pregunta_4, string v_pregunta_5, string v_pregunta_6, string v_pregunta_7,
                    string v_pregunta_8, string v_pregunta_9, string v_pregunta_10, string v_pregunta_11,
                    string v_pregunta_12, string v_pregunta_13, string v_pregunta_14, string v_pregunta_15,
                    string v_pregunta_16, string v_pregunta_17, string v_pregunta_18, string v_pregunta_19,
                    string v_pregunta_20, string v_pregunta_21, string v_pregunta_22, string v_pregunta_23,
                    string v_pregunta_24, string v_pregunta_25, string v_pregunta_26, string v_pregunta_27,
                    string v_pregunta_28, string v_pregunta_29, string v_pregunta_30, string v_pregunta_31,
                    string v_pregunta_32, string v_pregunta_33, string v_pregunta_34, string v_pregunta_35,
                    string v_pregunta_36, string v_pregunta_37, string v_pregunta_38, string v_pregunta_39,
                    string v_pregunta_40, string v_pregunta_41, string v_pregunta_42, string v_pregunta_43,
                    string v_pregunta_44, string v_pregunta_45, string v_pregunta_46, string v_pregunta_47,
                    string v_pregunta_48, string v_pregunta_49, string v_pregunta_50, string v_pregunta_51,
                    string v_pregunta_52, string v_pregunta_53, string v_pregunta_54, string v_pregunta_55,
                    string v_pregunta_56, string v_pregunta_57, string v_pregunta_58, string v_pregunta_59,
                    string v_pregunta_60, int i_puntaje, string v_descripcion, int i_tipo_pregunta,
                    int b_estado, string dt_fecharegistro)
        {
            int iRespuesta = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {
                        iadActividad = new adActividad(con);
                        iRespuesta = iadActividad.adInsertarFase(id_actividad_alumno, id_actividad_detalle,
                                    i_fase, v_pregunta_1, v_pregunta_2, v_pregunta_3, v_pregunta_4
                                    , v_pregunta_5, v_pregunta_6, v_pregunta_7, v_pregunta_8
                                    , v_pregunta_9, v_pregunta_10, v_pregunta_11, v_pregunta_12
                                    , v_pregunta_13, v_pregunta_14, v_pregunta_15, v_pregunta_16
                                    , v_pregunta_17, v_pregunta_18, v_pregunta_19,
                                    v_pregunta_20, v_pregunta_21, v_pregunta_22, v_pregunta_23,
                                    v_pregunta_24, v_pregunta_25, v_pregunta_26, v_pregunta_27,
                                    v_pregunta_28, v_pregunta_29, v_pregunta_30, v_pregunta_31,
                                    v_pregunta_32, v_pregunta_33, v_pregunta_34, v_pregunta_35,
                                    v_pregunta_36, v_pregunta_37, v_pregunta_38, v_pregunta_39,
                                    v_pregunta_40, v_pregunta_41, v_pregunta_42, v_pregunta_43,
                                    v_pregunta_44, v_pregunta_45, v_pregunta_46, v_pregunta_47,
                                    v_pregunta_48, v_pregunta_49, v_pregunta_50, v_pregunta_51,
                                    v_pregunta_52, v_pregunta_53, v_pregunta_54, v_pregunta_55,
                                    v_pregunta_56, v_pregunta_57, v_pregunta_58, v_pregunta_59,
                                    v_pregunta_60, i_puntaje, v_descripcion, i_tipo_pregunta,
                                    b_estado, dt_fecharegistro);
                        scope.Commit();
                    }
                }
                return (iRespuesta);
            }
            catch (MySqlException ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessRN, UtlConstantes.LogNamespace_TProcessRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }

        }

        // actualiza los datos de cada fase de los alumnos (ADMIN)
        public int tdActualizarFaseFinal(int tdidactividadAlumno, string tdcarrera1
                    , string tdcarrera2, string tdcarrera3, string tdcarrera4
                    , string tdcarrera5, int tdipuntaje, string tdcomentario)
        {
            int iRespuesta = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {
                        iadActividad = new adActividad(con);
                        iRespuesta = iadActividad.adActualizarFaseFinal(tdidactividadAlumno, tdcarrera1
                                    , tdcarrera2, tdcarrera3, tdcarrera4
                                    , tdcarrera5, tdipuntaje, tdcomentario);
                        scope.Commit();
                    }
                }
                return (iRespuesta);
            }
            catch (MySqlException ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessRN, UtlConstantes.LogNamespace_TProcessRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }

        }

        // actualiza los datos de cada fase de los alumnos (ADMIN)
        public int tdActualizarResultadoxFase(int tdidactividadalumno, int tdifase
                                , string tdsdescripcion, int tditipo_pregunta, int tdipuntaje)
        {
            int iRespuesta = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {
                        iadActividad = new adActividad(con);
                        iRespuesta = iadActividad.adActualizarResultadoxFase(tdidactividadalumno
                                            , tdifase, tdsdescripcion, tditipo_pregunta, tdipuntaje);
                        scope.Commit();
                    }
                }
                return (iRespuesta);
            }
            catch (MySqlException ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessRN, UtlConstantes.LogNamespace_TProcessRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }

        }

        // obtiene los datos del alumno dependiendo del correo (ADMIN)
        public List<edActividad> tdListarDatosAlumno(string tdcorreo)
        {
            List<edActividad> renArchivo = new List<edActividad>();
            try
            {
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {
                        iadActividad = new adActividad(con);
                        renArchivo = iadActividad.adListarDatosAlumno(tdcorreo);
                        scope.Commit();
                    }
                }
                return (renArchivo);
            }
            catch (MySqlException ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessRN, UtlConstantes.LogNamespace_TProcessRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }

        }

        // obtiene las respuestas marcadas por el alumno (ADMIN)
        public List<edActividad> tdListarRespuestasxFase(int tdidactividad, int tdifase)
        {
            List<edActividad> renArchivo = new List<edActividad>();
            try
            {
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {
                        iadActividad = new adActividad(con);
                        renArchivo = iadActividad.adListarRespuestasxFase(tdidactividad, tdifase);
                        scope.Commit();
                    }
                }
                return (renArchivo);
            }
            catch (MySqlException ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessRN, UtlConstantes.LogNamespace_TProcessRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }

        }

        // inicia sesion de cada usuario (ALUMNO)
        public edActividad tdListarLoginOV(string tdcorreo, string tdclave)
        {
            edActividad renArchivo = new edActividad();
            try
            {
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {
                        iadActividad = new adActividad(con);
                        renArchivo = iadActividad.adListarLoginOV(tdcorreo, tdclave);
                        scope.Commit();
                    }
                }
                return (renArchivo);
            }
            catch (MySqlException ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessRN, UtlConstantes.LogNamespace_TProcessRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }

        }

        // obtiene los numeros de las fases de los usuarios dependiendo del id del mismo (USUARIO)
        public List<edActividad> tdListarFasexUsuario(int tdidactividad)
        {
            List<edActividad> renArchivo = new List<edActividad>();
            try
            {
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {
                        iadActividad = new adActividad(con);
                        renArchivo = iadActividad.adListarFasexUsuario(tdidactividad);
                        scope.Commit();
                    }
                }
                return (renArchivo);
            }
            catch (MySqlException ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessRN, UtlConstantes.LogNamespace_TProcessRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }

        }

        // obtiene el listado de usuarios (ADMIN)
        public List<edActividad> tdListarUsuariosOrientacion(string tdsnombres, string tdsapellidos)
        {
            List<edActividad> renArchivo = new List<edActividad>();
            try
            {
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {
                        iadActividad = new adActividad(con);
                        renArchivo = iadActividad.adListarUsuariosOrientacion(tdsnombres, tdsapellidos);
                        scope.Commit();
                    }
                }
                return (renArchivo);
            }
            catch (MySqlException ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessRN, UtlConstantes.LogNamespace_TProcessRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }

        }

    }
}
