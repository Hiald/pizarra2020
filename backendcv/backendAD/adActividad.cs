using MySql.Data.MySqlClient;
using backendED;
using System;
using System.Collections.Generic;
using System.Data;

namespace backendAD
{
    public class adActividad : ad_aglobal
    {
        public adActividad(MySqlConnection cn)
        {
            cnMysql = cn;
        }

        public List<edActividad> adListarActividad(int adactividaid)
        {
            try
            {
                List<edActividad> lstArchivo = new List<edActividad>();
                using (MySqlCommand cmd = new MySqlCommand("sp_obtener_preguntas", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_idactividad", MySqlDbType.Int32).Value = adactividaid;

                    using (MySqlDataReader mdrd = cmd.ExecuteReader())
                    {
                        if (mdrd != null)
                        {
                            edActividad senArchivo = null;
                            int pos_idactividaddetalle = mdrd.GetOrdinal("id_actividad_detalle");
                            int pos_idactividad = mdrd.GetOrdinal("id_actividad");
                            int pos_vpregunta = mdrd.GetOrdinal("v_pregunta");
                            int pos_valternativaA = mdrd.GetOrdinal("v_alternativa_A");
                            int pos_valternativaB = mdrd.GetOrdinal("v_alternativa_B");
                            int pos_valternativaC = mdrd.GetOrdinal("v_alternativa_C");
                            int pos_valternativaD = mdrd.GetOrdinal("v_alternativa_D");
                            int pos_valternativaE = mdrd.GetOrdinal("v_alternativa_E");
                            int pos_tipopregunta = mdrd.GetOrdinal("i_tipo_pregunta");
                            int pos_puntajepregunta = mdrd.GetOrdinal("i_puntaje_pregunta");

                            while (mdrd.Read())
                            {
                                senArchivo = new edActividad();
                                senArchivo.idactividaddetalle = (mdrd.IsDBNull(pos_idactividaddetalle) ? 0 : mdrd.GetInt32(pos_idactividaddetalle));
                                senArchivo.idactividad = (mdrd.IsDBNull(pos_idactividad) ? 0 : mdrd.GetInt32(pos_idactividad));
                                senArchivo.v_pregunta = (mdrd.IsDBNull(pos_vpregunta) ? "-" : mdrd.GetString(pos_vpregunta));
                                senArchivo.alternativa_A = (mdrd.IsDBNull(pos_valternativaA) ? "-" : mdrd.GetString(pos_valternativaA));
                                senArchivo.alternativa_B = (mdrd.IsDBNull(pos_valternativaB) ? "-" : mdrd.GetString(pos_valternativaB));
                                senArchivo.alternativa_C = (mdrd.IsDBNull(pos_valternativaC) ? "-" : mdrd.GetString(pos_valternativaC));
                                senArchivo.alternativa_D = (mdrd.IsDBNull(pos_valternativaD) ? "-" : mdrd.GetString(pos_valternativaD));
                                senArchivo.alternativa_E = (mdrd.IsDBNull(pos_valternativaE) ? "-" : mdrd.GetString(pos_valternativaE));
                                senArchivo.tipo_pregunta = (mdrd.IsDBNull(pos_tipopregunta) ? 0 : mdrd.GetInt32(pos_tipopregunta));
                                senArchivo.puntaje_pregunta = (mdrd.IsDBNull(pos_puntajepregunta) ? 0 : mdrd.GetInt32(pos_puntajepregunta));

                                lstArchivo.Add(senArchivo);
                            }
                        }
                    }
                    return lstArchivo;
                }
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessAD, UtlConstantes.LogNamespace_TProcessAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public int adInsertarActividadAlumno(int adactividad, string adnombres
          , string adapellidos, string adlugarnacimiento, int adigrado, int adiedad
          , int adisexo, string adcelular, string adcorreo, string adclave, string adcolegio, string addistrito, string adugel
          , Int16 adestado, DateTime adfecharegistro)
        {
            try
            {
                int result = -1;
                MySqlCommand cmd = new MySqlCommand("sp_insertar_actividadAlumno", cnMysql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("_id_actividad", MySqlDbType.Int32).Value = adactividad;
                cmd.Parameters.Add("_v_nombres", MySqlDbType.VarChar, 150).Value = adnombres;
                cmd.Parameters.Add("_v_apellidos", MySqlDbType.VarChar, 150).Value = adapellidos;
                cmd.Parameters.Add("_v_lugarnacimiento", MySqlDbType.VarChar, 150).Value = adlugarnacimiento;
                cmd.Parameters.Add("_i_grado", MySqlDbType.Int32).Value = adigrado;
                cmd.Parameters.Add("_i_edad", MySqlDbType.Int32).Value = adiedad;
                cmd.Parameters.Add("_i_sexo", MySqlDbType.Int32).Value = adisexo;
                cmd.Parameters.Add("_v_celular", MySqlDbType.VarChar, 100).Value = adcelular;
                cmd.Parameters.Add("_v_correo", MySqlDbType.VarChar, 100).Value = adcorreo;
                cmd.Parameters.Add("_v_clave", MySqlDbType.VarChar, 100).Value = adclave;
                cmd.Parameters.Add("_v_colegio", MySqlDbType.VarChar, 100).Value = adcolegio;
                cmd.Parameters.Add("_v_distrito", MySqlDbType.VarChar, 100).Value = addistrito;
                cmd.Parameters.Add("_v_ugel", MySqlDbType.VarChar, 100).Value = adugel;
                cmd.Parameters.Add("_b_estado", MySqlDbType.Bit).Value = adestado;
                cmd.Parameters.Add("_dt_fecharegistro", MySqlDbType.DateTime).Value = adfecharegistro;

                result = Convert.ToInt32(cmd.ExecuteScalar());
                return result;
            }
            catch (Exception ex)
            {
                //utllog.towrite(utlconstantes.tprocessad, utlconstantes.lognamespace_tprocessad, this.gettype().name.tostring(), methodbase.getcurrentmethod().name, utlconstantes.logtipoerror, "", ex.stacktrace.tostring(), ex.message.tostring());
                throw ex;
            }
        }

        public int adInsertarActividadAlumnoDetalle(int adidactividadAlumno, int adidactividadDetalle
                , string adrespuesta_A, string adrespuesta_B, string adrespuesta_C, string adrespuesta_D
                , string adrespuesta_E, string adrespuesta_F, string adrespuesta_G, string adrespuesta_H
                , string adrespuesta_I, int adipuntaje, int adifase, int adpregunta, int aditipoPregunta
                , Int16 adestado)
        {
            try
            {
                int result = -1;
                MySqlCommand cmd = new MySqlCommand("sp_insertar_actividadAlumnoDetalle", cnMysql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("_id_actividad_alumno", MySqlDbType.Int32).Value = adidactividadAlumno;
                cmd.Parameters.Add("_id_actividad_detalle", MySqlDbType.Int32).Value = adidactividadDetalle;
                cmd.Parameters.Add("_b_respuesta_A", MySqlDbType.VarChar, 50).Value = adrespuesta_A;
                cmd.Parameters.Add("_b_respuesta_B", MySqlDbType.VarChar, 50).Value = "";
                cmd.Parameters.Add("_b_respuesta_C", MySqlDbType.VarChar, 50).Value = "";
                cmd.Parameters.Add("_b_respuesta_D", MySqlDbType.VarChar, 50).Value = "";
                cmd.Parameters.Add("_b_respuesta_E", MySqlDbType.VarChar, 50).Value = "";
                cmd.Parameters.Add("_b_respuesta_F", MySqlDbType.VarChar, 50).Value = "";
                cmd.Parameters.Add("_b_respuesta_G", MySqlDbType.VarChar, 50).Value = "";
                cmd.Parameters.Add("_b_respuesta_H", MySqlDbType.VarChar, 50).Value = "";
                cmd.Parameters.Add("_b_respuesta_I", MySqlDbType.VarChar, 50).Value = "";
                cmd.Parameters.Add("_i_pregunta", MySqlDbType.Int32).Value = adpregunta;
                cmd.Parameters.Add("_i_fase", MySqlDbType.Int32).Value = adifase;
                cmd.Parameters.Add("_i_puntaje", MySqlDbType.Int32).Value = adipuntaje;
                cmd.Parameters.Add("_i_tipo_pregunta", MySqlDbType.Int32).Value = aditipoPregunta;
                cmd.Parameters.Add("_b_estado", MySqlDbType.Bit).Value = adestado;

                result = Convert.ToInt32(cmd.ExecuteScalar());
                return result;
            }
            catch (Exception ex)
            {
                //utllog.towrite(utlconstantes.tprocessad, utlconstantes.lognamespace_tprocessad, this.gettype().name.tostring(), methodbase.getcurrentmethod().name, utlconstantes.logtipoerror, "", ex.stacktrace.tostring(), ex.message.tostring());
                throw ex;
            }
        }

        public int adActualizarClase(int adidactividadAlumno, string adcarrera1
                    , string adcarrera2, string adcarrera3, string adcarrera4
                    , string adcarrera5, int adipuntaje, string adcomentario)
        {
            try
            {
                int result = -1;
                MySqlCommand cmd = new MySqlCommand("sp_actualizar_actividadAlumno", cnMysql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("id_actividad_alumno", MySqlDbType.Int32).Value = adidactividadAlumno;
                cmd.Parameters.Add("_i_carrera1", MySqlDbType.VarChar, 50).Value = adcarrera1;
                cmd.Parameters.Add("_i_carrera2", MySqlDbType.VarChar, 50).Value = adcarrera2;
                cmd.Parameters.Add("_i_carrera3", MySqlDbType.VarChar, 50).Value = adcarrera3;
                cmd.Parameters.Add("_i_carrera4", MySqlDbType.VarChar, 50).Value = adcarrera4;
                cmd.Parameters.Add("_i_carrera5", MySqlDbType.VarChar, 50).Value = adcarrera5;
                cmd.Parameters.Add("_i_puntaje", MySqlDbType.Int32).Value = adipuntaje;
                cmd.Parameters.Add("_v_comentario", MySqlDbType.VarChar, 500).Value = adcomentario;

                result = Convert.ToInt32(cmd.ExecuteScalar());
                return result;
            }
            catch (Exception ex)
            {
                //utllog.towrite(utlconstantes.tprocessad, utlconstantes.lognamespace_tprocessad, this.gettype().name.tostring(), methodbase.getcurrentmethod().name, utlconstantes.logtipoerror, "", ex.stacktrace.tostring(), ex.message.tostring());
                throw ex;
            }
        }

        public List<edActividad> adListarActividadAlumno(string adcorreo)
        {
            try
            {
                List<edActividad> lstArchivo = new List<edActividad>();
                using (MySqlCommand cmd = new MySqlCommand("sp_obtener_actividadA", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_v_correo", MySqlDbType.VarChar, 100).Value = adcorreo;

                    using (MySqlDataReader mdrd = cmd.ExecuteReader())
                    {
                        if (mdrd != null)
                        {
                            edActividad senArchivo = null;
                            int pos_idactividadalumno = mdrd.GetOrdinal("id_actividad_alumno");
                            int pos_idactividad = mdrd.GetOrdinal("id_actividad");
                            int pos_vnombres = mdrd.GetOrdinal("v_nombres");
                            int pos_vapellidos = mdrd.GetOrdinal("v_apellidos");
                            int pos_lugarnacimiento = mdrd.GetOrdinal("v_lugarnacimiento");
                            int pos_iedad = mdrd.GetOrdinal("i_edad");
                            int pos_vcelular = mdrd.GetOrdinal("v_celular");
                            int pos_vcorreo = mdrd.GetOrdinal("v_correo");
                            int pos_vcolegio = mdrd.GetOrdinal("v_colegio");
                            int pos_vdistrito = mdrd.GetOrdinal("v_distrito");
                            int pos_vugel = mdrd.GetOrdinal("v_ugel");
                            int pos_icarrera1 = mdrd.GetOrdinal("i_carrera1");
                            int pos_icarrera2 = mdrd.GetOrdinal("i_carrera2");
                            int pos_icarrera3 = mdrd.GetOrdinal("i_carrera3");
                            int pos_icarrera4 = mdrd.GetOrdinal("i_carrera4");
                            int pos_icarrera5 = mdrd.GetOrdinal("i_carrera5");
                            int pos_vcomentario = mdrd.GetOrdinal("v_comentario");
                            int pos_fecharegistro = mdrd.GetOrdinal("dt_fecharegistro");
                            int pos_fechafin = mdrd.GetOrdinal("dt_fechafin");

                            while (mdrd.Read())
                            {
                                senArchivo = new edActividad();
                                senArchivo.idactividad_alumno = (mdrd.IsDBNull(pos_idactividadalumno) ? 0 : mdrd.GetInt32(pos_idactividadalumno));
                                senArchivo.idactividad = (mdrd.IsDBNull(pos_idactividad) ? 0 : mdrd.GetInt32(pos_idactividad));
                                senArchivo.snombres = (mdrd.IsDBNull(pos_vnombres) ? "-" : mdrd.GetString(pos_vnombres));
                                senArchivo.sapellidos = (mdrd.IsDBNull(pos_vapellidos) ? "-" : mdrd.GetString(pos_vapellidos));
                                senArchivo.slugarnacimiento = (mdrd.IsDBNull(pos_lugarnacimiento) ? "-" : mdrd.GetString(pos_lugarnacimiento));
                                senArchivo.iedad = (mdrd.IsDBNull(pos_iedad) ? 0 : mdrd.GetInt32(pos_iedad));
                                senArchivo.scelular = (mdrd.IsDBNull(pos_vcelular) ? "-" : mdrd.GetString(pos_vcelular));
                                senArchivo.scorreo = (mdrd.IsDBNull(pos_vcorreo) ? "-" : mdrd.GetString(pos_vcorreo));
                                senArchivo.scolegio = (mdrd.IsDBNull(pos_vcolegio) ? "-" : mdrd.GetString(pos_vcolegio));
                                senArchivo.sdistrito = (mdrd.IsDBNull(pos_vdistrito) ? "-" : mdrd.GetString(pos_vdistrito));
                                senArchivo.sugel = (mdrd.IsDBNull(pos_vugel) ? "-" : mdrd.GetString(pos_vugel));
                                senArchivo.scarrera1 = (mdrd.IsDBNull(pos_icarrera1) ? "-" : mdrd.GetString(pos_icarrera1));
                                senArchivo.scarrera2 = (mdrd.IsDBNull(pos_icarrera2) ? "-" : mdrd.GetString(pos_icarrera2));
                                senArchivo.scarrera3 = (mdrd.IsDBNull(pos_icarrera3) ? "-" : mdrd.GetString(pos_icarrera3));
                                senArchivo.scarrera4 = (mdrd.IsDBNull(pos_icarrera4) ? "-" : mdrd.GetString(pos_icarrera4));
                                senArchivo.scarrera5 = (mdrd.IsDBNull(pos_icarrera5) ? "-" : mdrd.GetString(pos_icarrera5));
                                senArchivo.scomentario = (mdrd.IsDBNull(pos_vcomentario) ? "-" : mdrd.GetString(pos_vcomentario));
                                senArchivo.dtfecharegistro = (mdrd.IsDBNull(pos_fecharegistro) ? "-" : mdrd.GetString(pos_fecharegistro));
                                senArchivo.dtfechafin = (mdrd.IsDBNull(pos_fechafin) ? "-" : mdrd.GetString(pos_fechafin));

                                lstArchivo.Add(senArchivo);
                            }
                        }
                    }
                    return lstArchivo;
                }
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessAD, UtlConstantes.LogNamespace_TProcessAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public List<edActividad> adListarActividadAlumnoDetalle(int adidactividad)
        {
            try
            {
                List<edActividad> lstArchivo = new List<edActividad>();
                using (MySqlCommand cmd = new MySqlCommand("sp_obtener_actividadA_det", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_idactividad", MySqlDbType.Int32).Value = adidactividad;

                    using (MySqlDataReader mdrd = cmd.ExecuteReader())
                    {
                        if (mdrd != null)
                        {
                            edActividad senArchivo = null;
                            int pos_idactividadalumnodetalle = mdrd.GetOrdinal("id_actividad_alumno_detalle");
                            int pos_idactividadalumno = mdrd.GetOrdinal("id_actividad_alumno");
                            int pos_idactividaddetalle = mdrd.GetOrdinal("id_actividad_detalle");
                            int pos_brespuestaA = mdrd.GetOrdinal("b_respuesta_A");
                            int pos_brespuestaB = mdrd.GetOrdinal("b_respuesta_B");
                            int pos_brespuestaC = mdrd.GetOrdinal("b_respuesta_C");
                            int pos_brespuestaD = mdrd.GetOrdinal("b_respuesta_D");
                            int pos_brespuestaE = mdrd.GetOrdinal("b_respuesta_E");
                            int pos_ipuntaje = mdrd.GetOrdinal("i_puntaje");
                            int pos_itipopregunta = mdrd.GetOrdinal("i_tipo_pregunta");

                            while (mdrd.Read())
                            {
                                senArchivo = new edActividad();
                                senArchivo.idactividadAlumnodetalle = (mdrd.IsDBNull(pos_idactividadalumnodetalle) ? 0 : mdrd.GetInt32(pos_idactividadalumnodetalle));
                                senArchivo.idactividad_alumno = (mdrd.IsDBNull(pos_idactividadalumno) ? 0 : mdrd.GetInt32(pos_idactividadalumno));
                                senArchivo.idactividaddetalle = (mdrd.IsDBNull(pos_idactividaddetalle) ? 0 : mdrd.GetInt32(pos_idactividaddetalle));
                                senArchivo.respuestaA = (mdrd.IsDBNull(pos_brespuestaA) ? "-" : mdrd.GetString(pos_brespuestaA));
                                senArchivo.respuestaB = (mdrd.IsDBNull(pos_brespuestaB) ? "-" : mdrd.GetString(pos_brespuestaB));
                                senArchivo.respuestaC = (mdrd.IsDBNull(pos_brespuestaC) ? "-" : mdrd.GetString(pos_brespuestaC));
                                senArchivo.respuestaD = (mdrd.IsDBNull(pos_brespuestaD) ? "-" : mdrd.GetString(pos_brespuestaD));
                                senArchivo.respuestaE = (mdrd.IsDBNull(pos_brespuestaE) ? "-" : mdrd.GetString(pos_brespuestaE));
                                senArchivo.puntaje_pregunta = (mdrd.IsDBNull(pos_ipuntaje) ? 0 : mdrd.GetInt32(pos_brespuestaE));
                                senArchivo.tipo_pregunta = (mdrd.IsDBNull(pos_itipopregunta) ? 0 : mdrd.GetInt32(pos_itipopregunta));

                                lstArchivo.Add(senArchivo);
                            }
                        }
                    }
                    return lstArchivo;
                }
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessAD, UtlConstantes.LogNamespace_TProcessAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public edActividad adListarActividadAlumnoAcceso(string adcorreo, string adclave)
        {
            try
            {
                edActividad senArchivo = null;
                using (MySqlCommand cmd = new MySqlCommand("sp_listar_actividadAlumno", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_v_correo", MySqlDbType.VarChar, 100).Value = adcorreo;
                    cmd.Parameters.Add("_v_clave", MySqlDbType.VarChar, 100).Value = adclave;

                    using (MySqlDataReader mdrd = cmd.ExecuteReader())
                    {
                        if (mdrd != null)
                        {
                            int pos_idactividad = mdrd.GetOrdinal("id_actividad");
                            int pos_vnombres = mdrd.GetOrdinal("v_nombres");
                            int pos_vapellidos = mdrd.GetOrdinal("v_apellidos");
                            int pos_lugarnacimiento = mdrd.GetOrdinal("v_lugarnacimiento");
                            int pos_vcorreo = mdrd.GetOrdinal("v_correo");
                            int pos_vclave = mdrd.GetOrdinal("v_clave");
                            int pos_vcolegio = mdrd.GetOrdinal("v_colegio");

                            while (mdrd.Read())
                            {
                                senArchivo = new edActividad();
                                senArchivo.idactividad = (mdrd.IsDBNull(pos_idactividad) ? 0 : mdrd.GetInt32(pos_idactividad));
                                senArchivo.snombres = (mdrd.IsDBNull(pos_vnombres) ? "-" : mdrd.GetString(pos_vnombres));
                                senArchivo.sapellidos = (mdrd.IsDBNull(pos_vapellidos) ? "-" : mdrd.GetString(pos_vapellidos));
                                senArchivo.slugarnacimiento = (mdrd.IsDBNull(pos_lugarnacimiento) ? "-" : mdrd.GetString(pos_lugarnacimiento));
                                senArchivo.scorreo = (mdrd.IsDBNull(pos_vcorreo) ? "-" : mdrd.GetString(pos_vcorreo));
                                senArchivo.sclave = (mdrd.IsDBNull(pos_vclave) ? "-" : mdrd.GetString(pos_vclave));
                                senArchivo.scolegio = (mdrd.IsDBNull(pos_vcolegio) ? "-" : mdrd.GetString(pos_vcolegio));
                            }
                        }
                    }
                    return senArchivo;
                }
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessAD, UtlConstantes.LogNamespace_TProcessAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public List<edActividad> adListarFases(int adidactividad)
        {
            try
            {
                List<edActividad> lstArchivo = new List<edActividad>();
                using (MySqlCommand cmd = new MySqlCommand("sp_listar_actividadFases", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_id_actividad", MySqlDbType.Int32).Value = adidactividad;

                    using (MySqlDataReader mdrd = cmd.ExecuteReader())
                    {
                        if (mdrd != null)
                        {
                            edActividad senArchivo = null;
                            int pos_fase = mdrd.GetOrdinal("i_fase");

                            while (mdrd.Read())
                            {
                                senArchivo = new edActividad();
                                senArchivo.idactividad_alumno = (mdrd.IsDBNull(pos_fase) ? 0 : mdrd.GetInt32(pos_fase));
                                lstArchivo.Add(senArchivo);
                            }
                        }
                    }
                    return lstArchivo;
                }
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessAD, UtlConstantes.LogNamespace_TProcessAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public List<edActividad> adListarPreguntasxFase(int adidalumno, int adifase)
        {
            try
            {
                List<edActividad> lstArchivo = new List<edActividad>();
                using (MySqlCommand cmd = new MySqlCommand("sp_listar_actividadAlumnoDetalle", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_id_actividad", MySqlDbType.Int32).Value = adidalumno;
                    cmd.Parameters.Add("_i_fase", MySqlDbType.Int32).Value = adifase;

                    using (MySqlDataReader mdrd = cmd.ExecuteReader())
                    {
                        if (mdrd != null)
                        {
                            edActividad senArchivo = null;
                            int pos_idactividadalumnodetalle = mdrd.GetOrdinal("id_actividad_alumno_detalle");
                            int pos_idactividadalumno = mdrd.GetOrdinal("id_actividad_alumno");
                            int pos_idactividaddetalle = mdrd.GetOrdinal("id_actividad_detalle");
                            int pos_ipregunta = mdrd.GetOrdinal("i_pregunta");
                            int pos_ifase = mdrd.GetOrdinal("i_fase");
                            int pos_brespuestaA = mdrd.GetOrdinal("b_respuesta_A");
                            int pos_brespuestaB = mdrd.GetOrdinal("b_respuesta_B");
                            int pos_brespuestaC = mdrd.GetOrdinal("b_respuesta_C");
                            int pos_brespuestaD = mdrd.GetOrdinal("b_respuesta_D");
                            int pos_brespuestaE = mdrd.GetOrdinal("b_respuesta_E");
                            int pos_brespuestaF = mdrd.GetOrdinal("b_respuesta_F");
                            int pos_brespuestaG = mdrd.GetOrdinal("b_respuesta_G");
                            int pos_brespuestaH = mdrd.GetOrdinal("b_respuesta_H");
                            int pos_brespuestaI = mdrd.GetOrdinal("b_respuesta_I");
                            int pos_itipopregunta = mdrd.GetOrdinal("i_tipo_pregunta");

                            while (mdrd.Read())
                            {
                                senArchivo = new edActividad();
                                senArchivo.idactividadAlumnodetalle = (mdrd.IsDBNull(pos_idactividadalumnodetalle) ? 0 : mdrd.GetInt32(pos_idactividadalumnodetalle));
                                senArchivo.idactividad_alumno = (mdrd.IsDBNull(pos_idactividadalumno) ? 0 : mdrd.GetInt32(pos_idactividadalumno));
                                senArchivo.idactividaddetalle = (mdrd.IsDBNull(pos_idactividaddetalle) ? 0 : mdrd.GetInt32(pos_idactividaddetalle));
                                senArchivo.ipregunta = (mdrd.IsDBNull(pos_ipregunta) ? 0 : mdrd.GetInt32(pos_ipregunta));
                                senArchivo.ifase = (mdrd.IsDBNull(pos_ifase) ? 0 : mdrd.GetInt32(pos_ifase));
                                senArchivo.respuestaA = (mdrd.IsDBNull(pos_brespuestaA) ? "-" : mdrd.GetString(pos_brespuestaA));
                                senArchivo.respuestaB = (mdrd.IsDBNull(pos_brespuestaB) ? "-" : mdrd.GetString(pos_brespuestaB));
                                senArchivo.respuestaC = (mdrd.IsDBNull(pos_brespuestaC) ? "-" : mdrd.GetString(pos_brespuestaC));
                                senArchivo.respuestaD = (mdrd.IsDBNull(pos_brespuestaD) ? "-" : mdrd.GetString(pos_brespuestaD));
                                senArchivo.respuestaE = (mdrd.IsDBNull(pos_brespuestaE) ? "-" : mdrd.GetString(pos_brespuestaE));
                                senArchivo.respuestaF = (mdrd.IsDBNull(pos_brespuestaF) ? "-" : mdrd.GetString(pos_brespuestaF));
                                senArchivo.respuestaG = (mdrd.IsDBNull(pos_brespuestaG) ? "-" : mdrd.GetString(pos_brespuestaG));
                                senArchivo.respuestaH = (mdrd.IsDBNull(pos_brespuestaH) ? "-" : mdrd.GetString(pos_brespuestaH));
                                senArchivo.respuestaI = (mdrd.IsDBNull(pos_brespuestaI) ? "-" : mdrd.GetString(pos_brespuestaI));
                                senArchivo.tipo_pregunta = (mdrd.IsDBNull(pos_itipopregunta) ? 0 : mdrd.GetInt32(pos_itipopregunta));

                                lstArchivo.Add(senArchivo);
                            }
                        }
                    }
                    return lstArchivo;
                }
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessAD, UtlConstantes.LogNamespace_TProcessAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

    }
}
