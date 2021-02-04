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

        // registra a los alumnos en orientacion vocacional (USUARIO)
        public int adRegistrarAlumnoOV(int adactividad, string adnombres
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

        // registra las preguntas por cada fase (USUARIO)
        public int adInsertarFase(int id_actividad_alumno, int id_actividad_detalle,
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
            try
            {
                int result = -1;
                MySqlCommand cmd = new MySqlCommand("sp_insertar_actividadAlumnoDetalle", cnMysql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("_id_actividad_alumno", MySqlDbType.Int32).Value = id_actividad_alumno;
                cmd.Parameters.Add("_id_actividad_detalle", MySqlDbType.Int32).Value = id_actividad_detalle;
                cmd.Parameters.Add("_i_fase", MySqlDbType.Int32).Value = i_fase;
                cmd.Parameters.Add("_v_pregunta_1", MySqlDbType.VarChar, 50).Value = v_pregunta_1;
                cmd.Parameters.Add("_v_pregunta_2", MySqlDbType.VarChar, 50).Value = v_pregunta_2;
                cmd.Parameters.Add("_v_pregunta_3", MySqlDbType.VarChar, 50).Value = v_pregunta_3;
                cmd.Parameters.Add("_v_pregunta_4", MySqlDbType.VarChar, 50).Value = v_pregunta_4;
                cmd.Parameters.Add("_v_pregunta_5", MySqlDbType.VarChar, 50).Value = v_pregunta_5;
                cmd.Parameters.Add("_v_pregunta_6", MySqlDbType.VarChar, 50).Value = v_pregunta_6;
                cmd.Parameters.Add("_v_pregunta_7", MySqlDbType.VarChar, 50).Value = v_pregunta_7;
                cmd.Parameters.Add("_v_pregunta_8", MySqlDbType.VarChar, 50).Value = v_pregunta_8;
                cmd.Parameters.Add("_v_pregunta_9", MySqlDbType.VarChar, 50).Value = v_pregunta_9;
                cmd.Parameters.Add("_v_pregunta_10", MySqlDbType.VarChar, 50).Value = v_pregunta_10;
                cmd.Parameters.Add("_v_pregunta_11", MySqlDbType.VarChar, 50).Value = v_pregunta_11;
                cmd.Parameters.Add("_v_pregunta_12", MySqlDbType.VarChar, 50).Value = v_pregunta_12;
                cmd.Parameters.Add("_v_pregunta_13", MySqlDbType.VarChar, 50).Value = v_pregunta_13;
                cmd.Parameters.Add("_v_pregunta_14", MySqlDbType.VarChar, 50).Value = v_pregunta_14;
                cmd.Parameters.Add("_v_pregunta_15", MySqlDbType.VarChar, 50).Value = v_pregunta_15;
                cmd.Parameters.Add("_v_pregunta_16", MySqlDbType.VarChar, 50).Value = v_pregunta_16;
                cmd.Parameters.Add("_v_pregunta_17", MySqlDbType.VarChar, 50).Value = v_pregunta_17;
                cmd.Parameters.Add("_v_pregunta_18", MySqlDbType.VarChar, 50).Value = v_pregunta_18;
                cmd.Parameters.Add("_v_pregunta_19", MySqlDbType.VarChar, 50).Value = v_pregunta_19;
                cmd.Parameters.Add("_v_pregunta_20", MySqlDbType.VarChar, 50).Value = v_pregunta_20;
                cmd.Parameters.Add("_v_pregunta_21", MySqlDbType.VarChar, 50).Value = v_pregunta_21;
                cmd.Parameters.Add("_v_pregunta_22", MySqlDbType.VarChar, 50).Value = v_pregunta_22;
                cmd.Parameters.Add("_v_pregunta_23", MySqlDbType.VarChar, 50).Value = v_pregunta_23;
                cmd.Parameters.Add("_v_pregunta_24", MySqlDbType.VarChar, 50).Value = v_pregunta_24;
                cmd.Parameters.Add("_v_pregunta_25", MySqlDbType.VarChar, 50).Value = v_pregunta_25;
                cmd.Parameters.Add("_v_pregunta_26", MySqlDbType.VarChar, 50).Value = v_pregunta_26;
                cmd.Parameters.Add("_v_pregunta_27", MySqlDbType.VarChar, 50).Value = v_pregunta_27;
                cmd.Parameters.Add("_v_pregunta_28", MySqlDbType.VarChar, 50).Value = v_pregunta_28;
                cmd.Parameters.Add("_v_pregunta_29", MySqlDbType.VarChar, 50).Value = v_pregunta_29;
                cmd.Parameters.Add("_v_pregunta_30", MySqlDbType.VarChar, 50).Value = v_pregunta_30;
                cmd.Parameters.Add("_v_pregunta_31", MySqlDbType.VarChar, 50).Value = v_pregunta_31;
                cmd.Parameters.Add("_v_pregunta_32", MySqlDbType.VarChar, 50).Value = v_pregunta_32;
                cmd.Parameters.Add("_v_pregunta_33", MySqlDbType.VarChar, 50).Value = v_pregunta_33;
                cmd.Parameters.Add("_v_pregunta_34", MySqlDbType.VarChar, 50).Value = v_pregunta_34;
                cmd.Parameters.Add("_v_pregunta_35", MySqlDbType.VarChar, 50).Value = v_pregunta_35;
                cmd.Parameters.Add("_v_pregunta_36", MySqlDbType.VarChar, 50).Value = v_pregunta_36;
                cmd.Parameters.Add("_v_pregunta_37", MySqlDbType.VarChar, 50).Value = v_pregunta_37;
                cmd.Parameters.Add("_v_pregunta_38", MySqlDbType.VarChar, 50).Value = v_pregunta_38;
                cmd.Parameters.Add("_v_pregunta_39", MySqlDbType.VarChar, 50).Value = v_pregunta_39;
                cmd.Parameters.Add("_v_pregunta_40", MySqlDbType.VarChar, 50).Value = v_pregunta_40;
                cmd.Parameters.Add("_v_pregunta_41", MySqlDbType.VarChar, 50).Value = v_pregunta_41;
                cmd.Parameters.Add("_v_pregunta_42", MySqlDbType.VarChar, 50).Value = v_pregunta_42;
                cmd.Parameters.Add("_v_pregunta_43", MySqlDbType.VarChar, 50).Value = v_pregunta_43;
                cmd.Parameters.Add("_v_pregunta_44", MySqlDbType.VarChar, 50).Value = v_pregunta_44;
                cmd.Parameters.Add("_v_pregunta_45", MySqlDbType.VarChar, 50).Value = v_pregunta_45;
                cmd.Parameters.Add("_v_pregunta_46", MySqlDbType.VarChar, 50).Value = v_pregunta_46;
                cmd.Parameters.Add("_v_pregunta_47", MySqlDbType.VarChar, 50).Value = v_pregunta_47;
                cmd.Parameters.Add("_v_pregunta_48", MySqlDbType.VarChar, 50).Value = v_pregunta_48;
                cmd.Parameters.Add("_v_pregunta_49", MySqlDbType.VarChar, 50).Value = v_pregunta_49;
                cmd.Parameters.Add("_v_pregunta_50", MySqlDbType.VarChar, 50).Value = v_pregunta_50;
                cmd.Parameters.Add("_v_pregunta_51", MySqlDbType.VarChar, 50).Value = v_pregunta_51;
                cmd.Parameters.Add("_v_pregunta_52", MySqlDbType.VarChar, 50).Value = v_pregunta_52;
                cmd.Parameters.Add("_v_pregunta_53", MySqlDbType.VarChar, 50).Value = v_pregunta_53;
                cmd.Parameters.Add("_v_pregunta_54", MySqlDbType.VarChar, 50).Value = v_pregunta_54;
                cmd.Parameters.Add("_v_pregunta_55", MySqlDbType.VarChar, 50).Value = v_pregunta_55;
                cmd.Parameters.Add("_v_pregunta_56", MySqlDbType.VarChar, 50).Value = v_pregunta_56;
                cmd.Parameters.Add("_v_pregunta_57", MySqlDbType.VarChar, 50).Value = v_pregunta_57;
                cmd.Parameters.Add("_v_pregunta_58", MySqlDbType.VarChar, 50).Value = v_pregunta_58;
                cmd.Parameters.Add("_v_pregunta_59", MySqlDbType.VarChar, 50).Value = v_pregunta_59;
                cmd.Parameters.Add("_v_pregunta_60", MySqlDbType.VarChar, 50).Value = v_pregunta_60;
                cmd.Parameters.Add("_i_puntaje", MySqlDbType.Int32).Value = i_puntaje;
                cmd.Parameters.Add("_v_descripcion", MySqlDbType.VarChar, 50).Value = v_descripcion;
                cmd.Parameters.Add("_i_tipo_pregunta", MySqlDbType.Int32).Value = i_tipo_pregunta;
                cmd.Parameters.Add("_b_estado", MySqlDbType.Bit).Value = b_estado;
                cmd.Parameters.Add("_dt_fecharegistro", MySqlDbType.VarChar, 25).Value = dt_fecharegistro;

                result = Convert.ToInt32(cmd.ExecuteScalar());
                return result;
            }
            catch (Exception ex)
            {
                //utllog.towrite(utlconstantes.tprocessad, utlconstantes.lognamespace_tprocessad, this.gettype().name.tostring(), methodbase.getcurrentmethod().name, utlconstantes.logtipoerror, "", ex.stacktrace.tostring(), ex.message.tostring());
                throw ex;
            }
        }

        // actualiza los datos de cada fase de los alumnos (ADMIN)
        public int adActualizarFaseFinal(int adidactividadAlumno, string adcarrera1
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

        // actualiza los datos de cada fase de los alumnos (ADMIN)
        public int adActualizarResultadoxFase(int adidactividadalumno, int adifase, string adsdescripcion
                                            , int aditipo_pregunta, int adipuntaje)
        {
            try
            {
                int result = -1;
                MySqlCommand cmd = new MySqlCommand("sp_actualizar_actividadAlumnoDetalle", cnMysql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("_id_actividad_alumno", MySqlDbType.Int32).Value = adidactividadalumno;
                cmd.Parameters.Add("_ifase", MySqlDbType.Int32).Value = adifase;
                cmd.Parameters.Add("_v_descripcion", MySqlDbType.VarChar, 500).Value = adsdescripcion;
                cmd.Parameters.Add("_i_tipo_pregunta", MySqlDbType.Int32).Value = aditipo_pregunta;
                cmd.Parameters.Add("_i_puntaje", MySqlDbType.Int32).Value = adipuntaje;

                result = Convert.ToInt32(cmd.ExecuteScalar());
                return result;
            }
            catch (Exception ex)
            {
                //utllog.towrite(utlconstantes.tprocessad, utlconstantes.lognamespace_tprocessad, this.gettype().name.tostring(), methodbase.getcurrentmethod().name, utlconstantes.logtipoerror, "", ex.stacktrace.tostring(), ex.message.tostring());
                throw ex;
            }
        }

        // obtiene los datos del alumno dependiendo del correo (ADMIN)
        public List<edActividad> adListarDatosAlumno(string adcorreo)
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

        // obtiene las respuestas marcadas por el alumno (ADMIN)
        public List<edActividad> adListarRespuestasxFase(int adidactividad, int adifase)
        {
            try
            {
                List<edActividad> lstArchivo = new List<edActividad>();
                using (MySqlCommand cmd = new MySqlCommand("sp_obtener_actividadA_det", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_idactividad", MySqlDbType.Int32).Value = adidactividad;
                    cmd.Parameters.Add("_ifase", MySqlDbType.Int32).Value = adifase;

                    using (MySqlDataReader mdrd = cmd.ExecuteReader())
                    {
                        if (mdrd != null)
                        {
                            edActividad senArchivo = null;
                            int pos_id_actividad_alumno_detalle = mdrd.GetOrdinal("id_actividad_alumno_detalle");
                            int pos_id_actividad_alumno = mdrd.GetOrdinal("id_actividad_alumno");
                            int pos_id_actividad_detalle = mdrd.GetOrdinal("id_actividad_detalle");
                            int pos_i_fase = mdrd.GetOrdinal("i_fase");
                            int pos_v_pregunta_1 = mdrd.GetOrdinal("v_pregunta_1");
                            int pos_v_pregunta_2 = mdrd.GetOrdinal("v_pregunta_2");
                            int pos_v_pregunta_3 = mdrd.GetOrdinal("v_pregunta_3");
                            int pos_v_pregunta_4 = mdrd.GetOrdinal("v_pregunta_4");
                            int pos_v_pregunta_5 = mdrd.GetOrdinal("v_pregunta_5");
                            int pos_v_pregunta_6 = mdrd.GetOrdinal("v_pregunta_6");
                            int pos_v_pregunta_7 = mdrd.GetOrdinal("v_pregunta_7");
                            int pos_v_pregunta_8 = mdrd.GetOrdinal("v_pregunta_8");
                            int pos_v_pregunta_9 = mdrd.GetOrdinal("v_pregunta_9");
                            int pos_v_pregunta_10 = mdrd.GetOrdinal("v_pregunta_10");
                            int pos_v_pregunta_11 = mdrd.GetOrdinal("v_pregunta_11");
                            int pos_v_pregunta_12 = mdrd.GetOrdinal("v_pregunta_12");
                            int pos_v_pregunta_13 = mdrd.GetOrdinal("v_pregunta_13");
                            int pos_v_pregunta_14 = mdrd.GetOrdinal("v_pregunta_14");
                            int pos_v_pregunta_15 = mdrd.GetOrdinal("v_pregunta_15");
                            int pos_v_pregunta_16 = mdrd.GetOrdinal("v_pregunta_16");
                            int pos_v_pregunta_17 = mdrd.GetOrdinal("v_pregunta_17");
                            int pos_v_pregunta_18 = mdrd.GetOrdinal("v_pregunta_18");
                            int pos_v_pregunta_19 = mdrd.GetOrdinal("v_pregunta_19");
                            int pos_v_pregunta_20 = mdrd.GetOrdinal("v_pregunta_20");
                            int pos_v_pregunta_21 = mdrd.GetOrdinal("v_pregunta_21");
                            int pos_v_pregunta_22 = mdrd.GetOrdinal("v_pregunta_22");
                            int pos_v_pregunta_23 = mdrd.GetOrdinal("v_pregunta_23");
                            int pos_v_pregunta_24 = mdrd.GetOrdinal("v_pregunta_24");
                            int pos_v_pregunta_25 = mdrd.GetOrdinal("v_pregunta_25");
                            int pos_v_pregunta_26 = mdrd.GetOrdinal("v_pregunta_26");
                            int pos_v_pregunta_27 = mdrd.GetOrdinal("v_pregunta_27");
                            int pos_v_pregunta_28 = mdrd.GetOrdinal("v_pregunta_28");
                            int pos_v_pregunta_29 = mdrd.GetOrdinal("v_pregunta_29");
                            int pos_v_pregunta_30 = mdrd.GetOrdinal("v_pregunta_30");
                            int pos_v_pregunta_31 = mdrd.GetOrdinal("v_pregunta_31");
                            int pos_v_pregunta_32 = mdrd.GetOrdinal("v_pregunta_32");
                            int pos_v_pregunta_33 = mdrd.GetOrdinal("v_pregunta_33");
                            int pos_v_pregunta_34 = mdrd.GetOrdinal("v_pregunta_34");
                            int pos_v_pregunta_35 = mdrd.GetOrdinal("v_pregunta_35");
                            int pos_v_pregunta_36 = mdrd.GetOrdinal("v_pregunta_36");
                            int pos_v_pregunta_37 = mdrd.GetOrdinal("v_pregunta_37");
                            int pos_v_pregunta_38 = mdrd.GetOrdinal("v_pregunta_38");
                            int pos_v_pregunta_39 = mdrd.GetOrdinal("v_pregunta_39");
                            int pos_v_pregunta_40 = mdrd.GetOrdinal("v_pregunta_40");
                            int pos_v_pregunta_41 = mdrd.GetOrdinal("v_pregunta_41");
                            int pos_v_pregunta_42 = mdrd.GetOrdinal("v_pregunta_42");
                            int pos_v_pregunta_43 = mdrd.GetOrdinal("v_pregunta_43");
                            int pos_v_pregunta_44 = mdrd.GetOrdinal("v_pregunta_44");
                            int pos_v_pregunta_45 = mdrd.GetOrdinal("v_pregunta_45");
                            int pos_v_pregunta_46 = mdrd.GetOrdinal("v_pregunta_46");
                            int pos_v_pregunta_47 = mdrd.GetOrdinal("v_pregunta_47");
                            int pos_v_pregunta_48 = mdrd.GetOrdinal("v_pregunta_48");
                            int pos_v_pregunta_49 = mdrd.GetOrdinal("v_pregunta_49");
                            int pos_v_pregunta_50 = mdrd.GetOrdinal("v_pregunta_50");
                            int pos_v_pregunta_51 = mdrd.GetOrdinal("v_pregunta_51");
                            int pos_v_pregunta_52 = mdrd.GetOrdinal("v_pregunta_52");
                            int pos_v_pregunta_53 = mdrd.GetOrdinal("v_pregunta_53");
                            int pos_v_pregunta_54 = mdrd.GetOrdinal("v_pregunta_54");
                            int pos_v_pregunta_55 = mdrd.GetOrdinal("v_pregunta_55");
                            int pos_v_pregunta_56 = mdrd.GetOrdinal("v_pregunta_56");
                            int pos_v_pregunta_57 = mdrd.GetOrdinal("v_pregunta_57");
                            int pos_v_pregunta_58 = mdrd.GetOrdinal("v_pregunta_58");
                            int pos_v_pregunta_59 = mdrd.GetOrdinal("v_pregunta_59");
                            int pos_v_pregunta_60 = mdrd.GetOrdinal("v_pregunta_60");
                            int pos_i_puntaje = mdrd.GetOrdinal("i_puntaje");
                            int pos_v_descripcion = mdrd.GetOrdinal("v_descripcion");
                            int pos_i_tipo_pregunta = mdrd.GetOrdinal("i_tipo_pregunta");
                            int pos_b_estado = mdrd.GetOrdinal("b_estado");

                            while (mdrd.Read())
                            {
                                senArchivo = new edActividad();

                                senArchivo.id_actividad_alumno_detalle = (mdrd.IsDBNull(pos_id_actividad_alumno_detalle) ? 0 : mdrd.GetInt32(pos_id_actividad_alumno_detalle));
                                senArchivo.id_actividad_alumno = (mdrd.IsDBNull(pos_id_actividad_alumno) ? 0 : mdrd.GetInt32(pos_id_actividad_alumno));
                                senArchivo.id_actividad_detalle = (mdrd.IsDBNull(pos_id_actividad_detalle) ? 0 : mdrd.GetInt32(pos_id_actividad_detalle));
                                senArchivo.i_fase = (mdrd.IsDBNull(pos_i_fase) ? 0 : mdrd.GetInt32(pos_i_fase));
                                senArchivo.v_pregunta_1 = (mdrd.IsDBNull(pos_v_pregunta_1) ? "-" : mdrd.GetString(pos_v_pregunta_1));
                                senArchivo.v_pregunta_2 = (mdrd.IsDBNull(pos_v_pregunta_2) ? "-" : mdrd.GetString(pos_v_pregunta_2));
                                senArchivo.v_pregunta_3 = (mdrd.IsDBNull(pos_v_pregunta_3) ? "-" : mdrd.GetString(pos_v_pregunta_3));
                                senArchivo.v_pregunta_4 = (mdrd.IsDBNull(pos_v_pregunta_4) ? "-" : mdrd.GetString(pos_v_pregunta_4));
                                senArchivo.v_pregunta_5 = (mdrd.IsDBNull(pos_v_pregunta_5) ? "-" : mdrd.GetString(pos_v_pregunta_5));
                                senArchivo.v_pregunta_6 = (mdrd.IsDBNull(pos_v_pregunta_6) ? "-" : mdrd.GetString(pos_v_pregunta_6));
                                senArchivo.v_pregunta_7 = (mdrd.IsDBNull(pos_v_pregunta_7) ? "-" : mdrd.GetString(pos_v_pregunta_7));
                                senArchivo.v_pregunta_8 = (mdrd.IsDBNull(pos_v_pregunta_8) ? "-" : mdrd.GetString(pos_v_pregunta_8));
                                senArchivo.v_pregunta_9 = (mdrd.IsDBNull(pos_v_pregunta_9) ? "-" : mdrd.GetString(pos_v_pregunta_9));
                                senArchivo.v_pregunta_10 = (mdrd.IsDBNull(pos_v_pregunta_10) ? "-" : mdrd.GetString(pos_v_pregunta_10));
                                senArchivo.v_pregunta_11 = (mdrd.IsDBNull(pos_v_pregunta_11) ? "-" : mdrd.GetString(pos_v_pregunta_11));
                                senArchivo.v_pregunta_12 = (mdrd.IsDBNull(pos_v_pregunta_12) ? "-" : mdrd.GetString(pos_v_pregunta_12));
                                senArchivo.v_pregunta_13 = (mdrd.IsDBNull(pos_v_pregunta_13) ? "-" : mdrd.GetString(pos_v_pregunta_13));
                                senArchivo.v_pregunta_14 = (mdrd.IsDBNull(pos_v_pregunta_14) ? "-" : mdrd.GetString(pos_v_pregunta_14));
                                senArchivo.v_pregunta_15 = (mdrd.IsDBNull(pos_v_pregunta_15) ? "-" : mdrd.GetString(pos_v_pregunta_15));
                                senArchivo.v_pregunta_16 = (mdrd.IsDBNull(pos_v_pregunta_16) ? "-" : mdrd.GetString(pos_v_pregunta_16));
                                senArchivo.v_pregunta_17 = (mdrd.IsDBNull(pos_v_pregunta_17) ? "-" : mdrd.GetString(pos_v_pregunta_17));
                                senArchivo.v_pregunta_18 = (mdrd.IsDBNull(pos_v_pregunta_18) ? "-" : mdrd.GetString(pos_v_pregunta_18));
                                senArchivo.v_pregunta_19 = (mdrd.IsDBNull(pos_v_pregunta_19) ? "-" : mdrd.GetString(pos_v_pregunta_19));
                                senArchivo.v_pregunta_20 = (mdrd.IsDBNull(pos_v_pregunta_20) ? "-" : mdrd.GetString(pos_v_pregunta_20));
                                senArchivo.v_pregunta_21 = (mdrd.IsDBNull(pos_v_pregunta_21) ? "-" : mdrd.GetString(pos_v_pregunta_21));
                                senArchivo.v_pregunta_22 = (mdrd.IsDBNull(pos_v_pregunta_22) ? "-" : mdrd.GetString(pos_v_pregunta_22));
                                senArchivo.v_pregunta_23 = (mdrd.IsDBNull(pos_v_pregunta_23) ? "-" : mdrd.GetString(pos_v_pregunta_23));
                                senArchivo.v_pregunta_24 = (mdrd.IsDBNull(pos_v_pregunta_24) ? "-" : mdrd.GetString(pos_v_pregunta_24));
                                senArchivo.v_pregunta_25 = (mdrd.IsDBNull(pos_v_pregunta_25) ? "-" : mdrd.GetString(pos_v_pregunta_25));
                                senArchivo.v_pregunta_26 = (mdrd.IsDBNull(pos_v_pregunta_26) ? "-" : mdrd.GetString(pos_v_pregunta_26));
                                senArchivo.v_pregunta_27 = (mdrd.IsDBNull(pos_v_pregunta_27) ? "-" : mdrd.GetString(pos_v_pregunta_27));
                                senArchivo.v_pregunta_28 = (mdrd.IsDBNull(pos_v_pregunta_28) ? "-" : mdrd.GetString(pos_v_pregunta_28));
                                senArchivo.v_pregunta_29 = (mdrd.IsDBNull(pos_v_pregunta_29) ? "-" : mdrd.GetString(pos_v_pregunta_29));
                                senArchivo.v_pregunta_30 = (mdrd.IsDBNull(pos_v_pregunta_30) ? "-" : mdrd.GetString(pos_v_pregunta_30));
                                senArchivo.v_pregunta_31 = (mdrd.IsDBNull(pos_v_pregunta_31) ? "-" : mdrd.GetString(pos_v_pregunta_31));
                                senArchivo.v_pregunta_32 = (mdrd.IsDBNull(pos_v_pregunta_32) ? "-" : mdrd.GetString(pos_v_pregunta_32));
                                senArchivo.v_pregunta_33 = (mdrd.IsDBNull(pos_v_pregunta_33) ? "-" : mdrd.GetString(pos_v_pregunta_33));
                                senArchivo.v_pregunta_34 = (mdrd.IsDBNull(pos_v_pregunta_34) ? "-" : mdrd.GetString(pos_v_pregunta_34));
                                senArchivo.v_pregunta_35 = (mdrd.IsDBNull(pos_v_pregunta_35) ? "-" : mdrd.GetString(pos_v_pregunta_35));
                                senArchivo.v_pregunta_36 = (mdrd.IsDBNull(pos_v_pregunta_36) ? "-" : mdrd.GetString(pos_v_pregunta_36));
                                senArchivo.v_pregunta_37 = (mdrd.IsDBNull(pos_v_pregunta_37) ? "-" : mdrd.GetString(pos_v_pregunta_37));
                                senArchivo.v_pregunta_38 = (mdrd.IsDBNull(pos_v_pregunta_38) ? "-" : mdrd.GetString(pos_v_pregunta_38));
                                senArchivo.v_pregunta_39 = (mdrd.IsDBNull(pos_v_pregunta_39) ? "-" : mdrd.GetString(pos_v_pregunta_39));
                                senArchivo.v_pregunta_40 = (mdrd.IsDBNull(pos_v_pregunta_40) ? "-" : mdrd.GetString(pos_v_pregunta_40));
                                senArchivo.v_pregunta_41 = (mdrd.IsDBNull(pos_v_pregunta_41) ? "-" : mdrd.GetString(pos_v_pregunta_41));
                                senArchivo.v_pregunta_42 = (mdrd.IsDBNull(pos_v_pregunta_42) ? "-" : mdrd.GetString(pos_v_pregunta_42));
                                senArchivo.v_pregunta_43 = (mdrd.IsDBNull(pos_v_pregunta_43) ? "-" : mdrd.GetString(pos_v_pregunta_43));
                                senArchivo.v_pregunta_44 = (mdrd.IsDBNull(pos_v_pregunta_44) ? "-" : mdrd.GetString(pos_v_pregunta_44));
                                senArchivo.v_pregunta_45 = (mdrd.IsDBNull(pos_v_pregunta_45) ? "-" : mdrd.GetString(pos_v_pregunta_45));
                                senArchivo.v_pregunta_46 = (mdrd.IsDBNull(pos_v_pregunta_46) ? "-" : mdrd.GetString(pos_v_pregunta_46));
                                senArchivo.v_pregunta_47 = (mdrd.IsDBNull(pos_v_pregunta_47) ? "-" : mdrd.GetString(pos_v_pregunta_47));
                                senArchivo.v_pregunta_48 = (mdrd.IsDBNull(pos_v_pregunta_48) ? "-" : mdrd.GetString(pos_v_pregunta_48));
                                senArchivo.v_pregunta_49 = (mdrd.IsDBNull(pos_v_pregunta_49) ? "-" : mdrd.GetString(pos_v_pregunta_49));
                                senArchivo.v_pregunta_50 = (mdrd.IsDBNull(pos_v_pregunta_50) ? "-" : mdrd.GetString(pos_v_pregunta_50));
                                senArchivo.v_pregunta_51 = (mdrd.IsDBNull(pos_v_pregunta_51) ? "-" : mdrd.GetString(pos_v_pregunta_51));
                                senArchivo.v_pregunta_52 = (mdrd.IsDBNull(pos_v_pregunta_52) ? "-" : mdrd.GetString(pos_v_pregunta_52));
                                senArchivo.v_pregunta_53 = (mdrd.IsDBNull(pos_v_pregunta_53) ? "-" : mdrd.GetString(pos_v_pregunta_53));
                                senArchivo.v_pregunta_54 = (mdrd.IsDBNull(pos_v_pregunta_54) ? "-" : mdrd.GetString(pos_v_pregunta_54));
                                senArchivo.v_pregunta_55 = (mdrd.IsDBNull(pos_v_pregunta_55) ? "-" : mdrd.GetString(pos_v_pregunta_55));
                                senArchivo.v_pregunta_56 = (mdrd.IsDBNull(pos_v_pregunta_56) ? "-" : mdrd.GetString(pos_v_pregunta_56));
                                senArchivo.v_pregunta_57 = (mdrd.IsDBNull(pos_v_pregunta_57) ? "-" : mdrd.GetString(pos_v_pregunta_57));
                                senArchivo.v_pregunta_58 = (mdrd.IsDBNull(pos_v_pregunta_58) ? "-" : mdrd.GetString(pos_v_pregunta_58));
                                senArchivo.v_pregunta_59 = (mdrd.IsDBNull(pos_v_pregunta_59) ? "-" : mdrd.GetString(pos_v_pregunta_59));
                                senArchivo.v_pregunta_60 = (mdrd.IsDBNull(pos_v_pregunta_60) ? "-" : mdrd.GetString(pos_v_pregunta_60));
                                senArchivo.i_puntaje = (mdrd.IsDBNull(pos_i_puntaje) ? 0 : mdrd.GetInt32(pos_i_puntaje));
                                senArchivo.v_descripcion = (mdrd.IsDBNull(pos_v_descripcion) ? "-" : mdrd.GetString(pos_v_descripcion));
                                senArchivo.i_tipo_pregunta = (mdrd.IsDBNull(pos_i_tipo_pregunta) ? 0 : mdrd.GetInt32(pos_i_tipo_pregunta));
                                senArchivo.b_estado = (mdrd.IsDBNull(pos_b_estado) ? 0 : mdrd.GetInt16(pos_b_estado));
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

        // inicia sesion de cada usuario (ALUMNO)
        public edActividad adListarLoginOV(string adcorreo, string adclave)
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

        // obtiene los numeros de las fases de los usuarios dependiendo del id del mismo (USUARIO)
        public List<edActividad> adListarFasexUsuario(int adidactividad)
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

        // obtiene el listado de usuarios (ADMIN)
        public List<edActividad> adListarUsuariosOrientacion(string adsnombres, string adsapellidos)
        {
            try
            {
                List<edActividad> lstArchivo = new List<edActividad>();
                using (MySqlCommand cmd = new MySqlCommand("sp_listar_alumnosActividad", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_nombres", MySqlDbType.VarChar, 50).Value = adsnombres;
                    cmd.Parameters.Add("_apellidos", MySqlDbType.VarChar, 50).Value = adsapellidos;

                    using (MySqlDataReader mdrd = cmd.ExecuteReader())
                    {
                        if (mdrd != null)
                        {
                            edActividad senArchivo = null;
                            int pos_id_actividad_alumno = mdrd.GetOrdinal("id_actividad_alumno");
                            int pos_id_actividad = mdrd.GetOrdinal("id_actividad");
                            int pos_v_nombres = mdrd.GetOrdinal("v_nombres");
                            int pos_v_apellidos = mdrd.GetOrdinal("v_apellidos");
                            int pos_i_grado = mdrd.GetOrdinal("i_grado");
                            int pos_i_edad = mdrd.GetOrdinal("i_edad");
                            int pos_i_sexo = mdrd.GetOrdinal("i_sexo");
                            int pos_v_colegio = mdrd.GetOrdinal("v_colegio");
                            int pos_v_celular = mdrd.GetOrdinal("v_celular");
                            int pos_v_correo = mdrd.GetOrdinal("v_correo");
                            int pos_v_clave = mdrd.GetOrdinal("v_clave");
                            int pos_i_carrera1 = mdrd.GetOrdinal("i_carrera1");
                            int pos_i_carrera2 = mdrd.GetOrdinal("i_carrera2");
                            int pos_i_carrera3 = mdrd.GetOrdinal("i_carrera3");
                            int pos_i_carrera4 = mdrd.GetOrdinal("i_carrera4");
                            int pos_i_carrera5 = mdrd.GetOrdinal("i_carrera5");
                            int pos_i_puntaje = mdrd.GetOrdinal("i_puntaje");
                            int pos_v_comentario = mdrd.GetOrdinal("v_comentario");

                            while (mdrd.Read())
                            {
                                senArchivo = new edActividad();
                                senArchivo.id_actividad_alumno = (mdrd.IsDBNull(pos_id_actividad_alumno) ? 0 : mdrd.GetInt32(pos_id_actividad_alumno));
                                senArchivo.idactividad = (mdrd.IsDBNull(pos_id_actividad) ? 0 : mdrd.GetInt32(pos_id_actividad));
                                senArchivo.snombres = (mdrd.IsDBNull(pos_v_nombres) ? "-" : mdrd.GetString(pos_v_nombres));
                                senArchivo.sapellidos = (mdrd.IsDBNull(pos_v_apellidos) ? "-" : mdrd.GetString(pos_v_apellidos));
                                senArchivo.igrado = (mdrd.IsDBNull(pos_i_grado) ? 0 : mdrd.GetInt32(pos_i_grado));
                                senArchivo.iedad = (mdrd.IsDBNull(pos_i_edad) ? 0 : mdrd.GetInt32(pos_i_edad));
                                senArchivo.isexo = (mdrd.IsDBNull(pos_i_sexo) ? 0 : mdrd.GetInt32(pos_i_sexo));
                                senArchivo.scolegio = (mdrd.IsDBNull(pos_v_colegio) ? "-" : mdrd.GetString(pos_v_colegio));
                                senArchivo.scelular = (mdrd.IsDBNull(pos_v_celular) ? "-" : mdrd.GetString(pos_v_celular));
                                senArchivo.scorreo = (mdrd.IsDBNull(pos_v_correo) ? "-" : mdrd.GetString(pos_v_correo));
                                senArchivo.sclave = (mdrd.IsDBNull(pos_v_clave) ? "-" : mdrd.GetString(pos_v_clave));
                                senArchivo.scarrera1 = (mdrd.IsDBNull(pos_i_carrera1) ? "-" : mdrd.GetString(pos_i_carrera1));
                                senArchivo.scarrera2 = (mdrd.IsDBNull(pos_i_carrera2) ? "-" : mdrd.GetString(pos_i_carrera2));
                                senArchivo.scarrera3 = (mdrd.IsDBNull(pos_i_carrera3) ? "-" : mdrd.GetString(pos_i_carrera3));
                                senArchivo.scarrera4 = (mdrd.IsDBNull(pos_i_carrera4) ? "-" : mdrd.GetString(pos_i_carrera4));
                                senArchivo.scarrera5 = (mdrd.IsDBNull(pos_i_carrera5) ? "-" : mdrd.GetString(pos_i_carrera5));
                                senArchivo.i_puntaje = (mdrd.IsDBNull(pos_i_puntaje) ? 0 : mdrd.GetInt32(pos_i_puntaje));
                                senArchivo.scomentario = (mdrd.IsDBNull(pos_v_comentario) ? "-" : mdrd.GetString(pos_v_comentario));
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
