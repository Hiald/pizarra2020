using MySql.Data.MySqlClient;
using backendED;
using System;
using System.Collections.Generic;
using System.Data;

namespace backendAD
{
    public class adArchivo : ad_aglobal
    {
        public adArchivo(MySqlConnection cn)
        {
            cnMysql = cn;
        }

        public int adRegistrarArchivo(int addocenteid, int advideoid, int adtipoarchivo, string adurl)
        {
            try
            {
                int result = -1;
                MySqlCommand cmd = new MySqlCommand("sparchivo_registro", cnMysql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@_iddocente", MySqlDbType.Int32).Value = addocenteid;
                cmd.Parameters.Add("@_idvideo", MySqlDbType.Int32).Value = advideoid;
                cmd.Parameters.Add("@_tipodearchivo", MySqlDbType.Int32).Value = adtipoarchivo;
                cmd.Parameters.Add("@_url", MySqlDbType.VarChar, 500).Value = adurl;

                result = Convert.ToInt32(cmd.ExecuteScalar());
                return result;
            }
            catch (Exception ex)
            {
                //utllog.towrite(utlconstantes.tprocessad, utlconstantes.lognamespace_tprocessad, this.gettype().name.tostring(), methodbase.getcurrentmethod().name, utlconstantes.logtipoerror, "", ex.stacktrace.tostring(), ex.message.tostring());
                throw ex;
            }
        }

        public List<edArchivo> adListarArchivo(int adidvideo, int adtipoarchivo)
        {
            try
            {
                List<edArchivo> lstArchivo = new List<edArchivo>();
                using (MySqlCommand cmd = new MySqlCommand("sparchivo_buscar", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@_idvideo", MySqlDbType.Int32).Value = adidvideo;
                    cmd.Parameters.Add("@_tipodearchivo", MySqlDbType.Int32).Value = adtipoarchivo;

                    using (MySqlDataReader mdrd = cmd.ExecuteReader())
                    {
                        if (mdrd != null)
                        {
                            edArchivo senArchivo = null;
                            int pos_idarchivo = mdrd.GetOrdinal("idarchivo");
                            int pos_iddocente = mdrd.GetOrdinal("iddocente");
                            int pos_idvideo = mdrd.GetOrdinal("idvideo");
                            int pos_tipodearchivo = mdrd.GetOrdinal("tipodearchivo");
                            int pos_url = mdrd.GetOrdinal("url");

                            while (mdrd.Read())
                            {
                                senArchivo = new edArchivo();
                                senArchivo.archivoid = (mdrd.IsDBNull(pos_idarchivo) ? 0 : mdrd.GetInt32(pos_idarchivo));
                                senArchivo.docenteid = (mdrd.IsDBNull(pos_iddocente) ? 0 : mdrd.GetInt32(pos_iddocente));
                                senArchivo.videoid = (mdrd.IsDBNull(pos_idvideo) ? 0 : mdrd.GetInt32(pos_idvideo));
                                senArchivo.tipodearchivo = (mdrd.IsDBNull(pos_tipodearchivo) ? 0 : mdrd.GetInt32(pos_tipodearchivo));
                                senArchivo.surl = (mdrd.IsDBNull(pos_url) ? "-" : mdrd.GetString(pos_url));
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

        public int adEliminarArchivo(int adidvideoel)
        {
            try
            {
                int result = -1;
                MySqlCommand cmd = new MySqlCommand("sparchivo_eliminar", cnMysql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@_idarchivo", MySqlDbType.Int32).Value = adidvideoel;

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
