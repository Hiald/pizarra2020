using MySql.Data.MySqlClient;
using backendED;
using System;
using System.Collections.Generic;
using System.Data;

namespace backendAD
{
    public class adUsuario : ad_aglobal
    {
        public adUsuario(MySqlConnection cn)
        {
            cnMysql = cn;
        }

        public int adRegistrarUsuario(string adnombre, string adapellido, string ademail, int adetapa, int adgrado, int adseccion, string adnombrepadre, string adclave)
        {
            try
            {
                int result = -1;
                MySqlCommand cmd = new MySqlCommand("spalumno_crear", cnMysql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@_nombre", MySqlDbType.VarChar, 150).Value = adnombre;
                cmd.Parameters.Add("@_apellido", MySqlDbType.VarChar, 150).Value = adapellido;
                cmd.Parameters.Add("@_email", MySqlDbType.VarChar, 100).Value = ademail;
                cmd.Parameters.Add("@_etapa", MySqlDbType.Int32).Value = adetapa;
                cmd.Parameters.Add("@_grado", MySqlDbType.Int32).Value = adgrado;
                cmd.Parameters.Add("@_seccion", MySqlDbType.Int32).Value = adseccion;
                cmd.Parameters.Add("@_nombrepadre", MySqlDbType.VarChar, 50).Value = adnombrepadre;
                cmd.Parameters.Add("@_clave", MySqlDbType.VarChar, 500).Value = adclave;

                result = Convert.ToInt32(cmd.ExecuteScalar());

                return result;
            }
            catch (Exception ex)
            {
                //utllog.towrite(utlconstantes.tprocessad, utlconstantes.lognamespace_tprocessad, this.gettype().name.tostring(), methodbase.getcurrentmethod().name, utlconstantes.logtipoerror, "", ex.stacktrace.tostring(), ex.message.tostring());
                throw ex;
            }
        }

        public edUsuario adListarUsuario(int adidusuario)
        {
            try
            {
                edUsuario senUsuario = null;
                using (MySqlCommand cmd = new MySqlCommand("spalumno_listar", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@_idalumno", MySqlDbType.Int32).Value = adidusuario;

                    using (MySqlDataReader mdrd = cmd.ExecuteReader())
                    {
                        if (mdrd != null)
                        {
                            int pos_idalumno = mdrd.GetOrdinal("idalumno");
                            int pos_distrito = mdrd.GetOrdinal("distrito");
                            int pos_ciudad = mdrd.GetOrdinal("ciudad");
                            int pos_provincia = mdrd.GetOrdinal("provincia");
                            int pos_nombre = mdrd.GetOrdinal("nombre");
                            int pos_fechanac = mdrd.GetOrdinal("fechanac");
                            int pos_email = mdrd.GetOrdinal("email");
                            int pos_etapaescolar = mdrd.GetOrdinal("etapa_escolar");
                            int pos_grado = mdrd.GetOrdinal("grado");
                            int pos_seccion = mdrd.GetOrdinal("seccion");
                            int pos_tipodoc = mdrd.GetOrdinal("tipodoc");
                            int pos_documento = mdrd.GetOrdinal("documento");
                            int pos_suscripcionestado = mdrd.GetOrdinal("suscripcion_estado");
                            int pos_activo = mdrd.GetOrdinal("activo");
                            int pos_ultimaconexionfecha = mdrd.GetOrdinal("ultima_conexion_fecha");
                            int pos_matriculado = mdrd.GetOrdinal("matriculado");

                            while (mdrd.Read())
                            {
                                senUsuario = new edUsuario();
                                senUsuario.idalumno = (mdrd.IsDBNull(pos_idalumno) ? 0 : mdrd.GetInt32(pos_idalumno));
                                senUsuario.idistrito = (mdrd.IsDBNull(pos_distrito) ? 0 : mdrd.GetInt32(pos_distrito));
                                senUsuario.iciudad = (mdrd.IsDBNull(pos_ciudad) ? 0 : mdrd.GetInt32(pos_ciudad));
                                senUsuario.iprovincia = (mdrd.IsDBNull(pos_provincia) ? 0 : mdrd.GetInt32(pos_provincia));
                                senUsuario.snombre = (mdrd.IsDBNull(pos_nombre) ? "-" : mdrd.GetString(pos_nombre));
                                senUsuario.sfechanac = (mdrd.IsDBNull(pos_fechanac) ? "-" : mdrd.GetString(pos_fechanac));
                                senUsuario.semail = (mdrd.IsDBNull(pos_email) ? "-" : mdrd.GetString(pos_email));
                                senUsuario.ietapaescolar = (mdrd.IsDBNull(pos_etapaescolar) ? 0 : mdrd.GetInt32(pos_etapaescolar));
                                senUsuario.igrado = (mdrd.IsDBNull(pos_grado) ? 0 : mdrd.GetInt32(pos_grado));
                                senUsuario.iseccion = (mdrd.IsDBNull(pos_seccion) ? 0 : mdrd.GetInt32(pos_seccion));
                                senUsuario.itipodoc = (mdrd.IsDBNull(pos_tipodoc) ? 0 : mdrd.GetInt32(pos_tipodoc));
                                senUsuario.sdocumento = (mdrd.IsDBNull(pos_documento) ? "-" : mdrd.GetString(pos_documento));
                                senUsuario.isuscripcionestado = (mdrd.IsDBNull(pos_suscripcionestado) ? 0 : mdrd.GetInt32(pos_suscripcionestado));
                                senUsuario.iactivo = (mdrd.IsDBNull(pos_activo) ? 0 : mdrd.GetInt32(pos_activo));
                                senUsuario.sultimaconexionfecha = (mdrd.IsDBNull(pos_ultimaconexionfecha) ? "-" : mdrd.GetString(pos_ultimaconexionfecha));
                                senUsuario.imatriculado = (mdrd.IsDBNull(pos_matriculado) ? 0 : mdrd.GetInt32(pos_matriculado));

                            }
                        }
                    }
                    return senUsuario;
                }
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessAD, UtlConstantes.LogNamespace_TProcessAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public int adValidarUsuario(string adcorreo)
        {
            try
            {
                int result = -1;
                using (MySqlCommand cmd = new MySqlCommand("spalumno_validarcuenta", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@_correo", MySqlDbType.VarChar, 100).Value = adcorreo;

                    using (MySqlDataReader mdrd = cmd.ExecuteReader())
                    {
                        if (mdrd != null)
                        {
                            int pos_result = mdrd.GetOrdinal("_result");


                            while (mdrd.Read())
                            {
                                result = (mdrd.IsDBNull(pos_result) ? 0 : mdrd.GetInt16(pos_result));

                            }
                        }
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessAD, UtlConstantes.LogNamespace_TProcessAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public int adValidarCorreo(string adcorreo)
        {
            try
            {
                int result = -1;
                using (MySqlCommand cmd = new MySqlCommand("spalumno_validarcorreo", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@_correo", MySqlDbType.VarChar, 100).Value = adcorreo;

                    using (MySqlDataReader mdrd = cmd.ExecuteReader())
                    {
                        if (mdrd != null)
                        {
                            int pos_result = mdrd.GetOrdinal("_result");
                            while (mdrd.Read())
                            {
                                result = (mdrd.IsDBNull(pos_result) ? 0 : mdrd.GetInt16(pos_result));

                            }
                        }
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessAD, UtlConstantes.LogNamespace_TProcessAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public int adLogeoUsuario(string adcorreo, string adclave)
        {
            try
            {
                int result = -1;
                using (MySqlCommand cmd = new MySqlCommand("spalumno_login", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@_correo", MySqlDbType.VarChar, 100).Value = adcorreo;
                    cmd.Parameters.Add("@_clave", MySqlDbType.VarChar, 500).Value = adclave;

                    using (MySqlDataReader mdrd = cmd.ExecuteReader())
                    {
                        if (mdrd != null)
                        {
                            int pos_result = mdrd.GetOrdinal("_result");


                            while (mdrd.Read())
                            {
                                result = (mdrd.IsDBNull(pos_result) ? 0 : mdrd.GetInt16(pos_result));

                            }
                        }
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessAD, UtlConstantes.LogNamespace_TProcessAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public int adRegistrarSesiones(int adidalumno, string addireccionip, string addireccionmac, int adtipoconexion)
        {
            try
            {
                int result = -1;
                MySqlCommand cmd = new MySqlCommand("spalumno_registro", cnMysql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@_idalumno", MySqlDbType.Int32).Value = adidalumno;
                cmd.Parameters.Add("@_direccionip", MySqlDbType.VarChar, 150).Value = addireccionip;
                cmd.Parameters.Add("@_direccionmac", MySqlDbType.VarChar, 150).Value = addireccionmac;
                cmd.Parameters.Add("@_tipoconexion", MySqlDbType.Int32).Value = adtipoconexion;

                result = Convert.ToInt32(cmd.ExecuteScalar());

                return result;
            }
            catch (Exception ex)
            {
                //utllog.towrite(utlconstantes.tprocessad, utlconstantes.lognamespace_tprocessad, this.gettype().name.tostring(), methodbase.getcurrentmethod().name, utlconstantes.logtipoerror, "", ex.stacktrace.tostring(), ex.message.tostring());
                throw ex;
            }
        }

        /* CONFIGURACION */
        public List<edUsuario> adListarUsuarioConfiguracion(string adcorreo, string adnombre, int adidetapa)
        {
            try
            {
                List<edUsuario> loenusuario = new List<edUsuario>();
                using (MySqlCommand cmd = new MySqlCommand("spalumno_configuracion", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@_correo", MySqlDbType.VarChar, 150).Value = adcorreo;
                    cmd.Parameters.Add("@_idetapa", MySqlDbType.Int32).Value = adidetapa;
                    cmd.Parameters.Add("@_nombre", MySqlDbType.VarChar, 50).Value = adnombre;

                    using (MySqlDataReader mdrd = cmd.ExecuteReader())
                    {
                        if (mdrd != null)
                        {
                            edUsuario senUsuario = null;
                            int pos_idalumno = mdrd.GetOrdinal("idalumno");
                            int pos_idpago = mdrd.GetOrdinal("idpago");
                            int pos_idetapa = mdrd.GetOrdinal("idetapa");
                            int pos_nombrealumno = mdrd.GetOrdinal("nombrealumno");
                            int pos_email = mdrd.GetOrdinal("email");
                            int pos_categoria = mdrd.GetOrdinal("etapa_escolar");
                            int pos_fechareg = mdrd.GetOrdinal("fechareg");
                            int pos_fechafin = mdrd.GetOrdinal("fechafin");
                            int pos_diasrestantes = mdrd.GetOrdinal("diasrestantes");

                            while (mdrd.Read())
                            {
                                senUsuario = new edUsuario();
                                senUsuario.idalumno = (mdrd.IsDBNull(pos_idalumno) ? 0 : mdrd.GetInt32(pos_idalumno));
                                senUsuario.idpago = (mdrd.IsDBNull(pos_idpago) ? 0 : mdrd.GetInt32(pos_idpago));
                                senUsuario.idetapa = (mdrd.IsDBNull(pos_idetapa) ? 0 : mdrd.GetInt32(pos_idetapa));
                                senUsuario.snombre = (mdrd.IsDBNull(pos_nombrealumno) ? "-" : mdrd.GetString(pos_nombrealumno));
                                senUsuario.semail = (mdrd.IsDBNull(pos_email) ? "-" : mdrd.GetString(pos_email));
                                senUsuario.scategoria = (mdrd.IsDBNull(pos_categoria) ? "-" : mdrd.GetString(pos_categoria));
                                senUsuario.sfechareg = (mdrd.IsDBNull(pos_fechareg) ? "-" : mdrd.GetString(pos_fechareg));
                                senUsuario.sfechafin = (mdrd.IsDBNull(pos_fechafin) ? "-" : mdrd.GetString(pos_fechafin));
                                senUsuario.idiasrestantes = (mdrd.IsDBNull(pos_diasrestantes) ? 0 : mdrd.GetInt32(pos_diasrestantes));

                                loenusuario.Add(senUsuario);
                            }
                        }
                    }
                    return loenusuario;
                }
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessAD, UtlConstantes.LogNamespace_TProcessAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public int adGenerarClave(int adidalumno, string adnuevaclave)
        {
            try
            {
                int result = -1;
                using (MySqlCommand cmd = new MySqlCommand("spalumno_generarclave", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@_idalumno", MySqlDbType.VarChar, 150).Value = adidalumno;
                    cmd.Parameters.Add("@_nuevaclave", MySqlDbType.VarChar, 50).Value = adnuevaclave;
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                    return result;
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
