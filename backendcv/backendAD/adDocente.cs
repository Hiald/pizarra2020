using MySql.Data.MySqlClient;
using backendED;
using System;
using System.Collections.Generic;
using System.Data;

namespace backendAD
{
    public class adDocente : ad_aglobal
    {

        public adDocente(MySqlConnection cn)
        {
            cnMysql = cn;
        }

        public int adValidarCorreo(string adcorreo)
        {
            try
            {
                int result = -1;
                using (MySqlCommand cmd = new MySqlCommand("spdocente_validarcorreo", cnMysql))
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

        public int adRegistrarDocente(string adnombre, string adapellido, string ademail, string adclave)
        {
            try
            {
                int result = -1;
                MySqlCommand cmd = new MySqlCommand("spdocente_crear", cnMysql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@_nombre", MySqlDbType.VarChar, 150).Value = adnombre;
                cmd.Parameters.Add("@_apellido", MySqlDbType.VarChar, 150).Value = adapellido;
                cmd.Parameters.Add("@_email", MySqlDbType.VarChar, 100).Value = ademail;
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

        public edDocente adListarDocente(int adiddocente)
        {
            try
            {
                edDocente senDocente = null;
                using (MySqlCommand cmd = new MySqlCommand("spdocente_listar", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@_iddocente", MySqlDbType.Int32).Value = adiddocente;

                    using (MySqlDataReader mdrd = cmd.ExecuteReader())
                    {
                        if (mdrd != null)
                        {
                            int pos_iddocente = mdrd.GetOrdinal("iddocente");
                            int pos_distrito = mdrd.GetOrdinal("distrito");
                            int pos_ciudad = mdrd.GetOrdinal("ciudad");
                            int pos_provincia = mdrd.GetOrdinal("provincia");
                            int pos_nombre = mdrd.GetOrdinal("nombre");
                            int pos_email = mdrd.GetOrdinal("email");
                            int pos_tipodoc = mdrd.GetOrdinal("tipodoc");
                            int pos_documento = mdrd.GetOrdinal("documento");
                            int pos_activo = mdrd.GetOrdinal("activo");

                            while (mdrd.Read())
                            {
                                senDocente = new edDocente();
                                senDocente.iddocente = (mdrd.IsDBNull(pos_iddocente) ? 0 : mdrd.GetInt32(pos_iddocente));
                                senDocente.idistrito = (mdrd.IsDBNull(pos_distrito) ? 0 : mdrd.GetInt32(pos_distrito));
                                senDocente.iciudad = (mdrd.IsDBNull(pos_ciudad) ? 0 : mdrd.GetInt32(pos_ciudad));
                                senDocente.iprovincia = (mdrd.IsDBNull(pos_provincia) ? 0 : mdrd.GetInt32(pos_provincia));
                                senDocente.snombre = (mdrd.IsDBNull(pos_nombre) ? "-" : mdrd.GetString(pos_nombre));
                                senDocente.semail = (mdrd.IsDBNull(pos_email) ? "-" : mdrd.GetString(pos_email));
                                senDocente.itipodoc = (mdrd.IsDBNull(pos_tipodoc) ? 0 : mdrd.GetInt32(pos_tipodoc));
                                senDocente.sdocumento = (mdrd.IsDBNull(pos_documento) ? "-" : mdrd.GetString(pos_documento));
                                senDocente.iactivo = (mdrd.IsDBNull(pos_activo) ? 0 : mdrd.GetInt32(pos_activo));

                            }
                        }
                    }
                    return senDocente;
                }
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessAD, UtlConstantes.LogNamespace_TProcessAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public int adLogeoDocente(string adcorreo, string adclave)
        {
            try
            {
                int result = -1;
                using (MySqlCommand cmd = new MySqlCommand("spdocente_login", cnMysql))
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

        public int adRegistrarSesiones(int adiddocente, string addireccionip, string addireccionmac, int adtipoconexion)
        {
            try
            {
                int result = -1;
                MySqlCommand cmd = new MySqlCommand("spdocente_registro", cnMysql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@_iddocente", MySqlDbType.Int32).Value = adiddocente;
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

    }
}
