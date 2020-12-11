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

        public List<edActividad> tdListarActividad(int tdactividaid)
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
                        renArchivo = iadActividad.adListarActividad(tdactividaid);
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

        public int tdInsertarActividadAlumno(int tdactividad, string tdnombres
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
                        iRespuesta = iadActividad.adInsertarActividadAlumno(tdactividad, tdnombres
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

        public int tdInsertarActividadAlumnoDetalle(int tdidactividadAlumno, int tdidactividadDetalle
                , string tdrespuesta_A, string tdrespuesta_B, string tdrespuesta_C, string tdrespuesta_D
                , string tdrespuesta_E, string tdrespuesta_F, string tdrespuesta_G, string tdrespuesta_H
                , string tdrespuesta_I, int tdipuntaje, int tdifase, int tdpregunta, int tditipoPregunta
                , Int16 tdestado)
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
                        iRespuesta = iadActividad.adInsertarActividadAlumnoDetalle(tdidactividadAlumno, tdidactividadDetalle
                                    , tdrespuesta_A, tdrespuesta_B, tdrespuesta_C, tdrespuesta_D
                                    , tdrespuesta_E, tdrespuesta_F, tdrespuesta_G, tdrespuesta_H
                                    , tdrespuesta_I, tdipuntaje, tdifase, tdpregunta, tditipoPregunta
                                    , tdestado);
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

        public int tdActualizarClase(int tdidactividadAlumno, string tdcarrera1
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
                        iRespuesta = iadActividad.adActualizarClase(tdidactividadAlumno, tdcarrera1
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

        public List<edActividad> tdListarActividadAlumno(string tdcorreo)
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
                        renArchivo = iadActividad.adListarActividadAlumno(tdcorreo);
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

        public List<edActividad> tdListarActividadAlumnoDetalle(int tdidactividad)
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
                        renArchivo = iadActividad.adListarActividadAlumnoDetalle(tdidactividad);
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

        public edActividad tdListarActividadAlumnoAcceso(string tdcorreo, string tdclave)
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
                        renArchivo = iadActividad.adListarActividadAlumnoAcceso(tdcorreo, tdclave);
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

        public List<edActividad> tdListarFases(int tdidactividad)
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
                        renArchivo = iadActividad.adListarFases(tdidactividad);
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

        public List<edActividad> tdListarPreguntasxFase(int tdidalumno, int tdifase)
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
                        renArchivo = iadActividad.adListarPreguntasxFase(tdidalumno, tdifase);
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
