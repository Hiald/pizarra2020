using MySql.Data.MySqlClient;
using backendED;
using System;
using System.Collections.Generic;
using System.Data;

namespace backendAD
{
    public class adGrado : ad_aglobal
    {
        public adGrado(MySqlConnection cn)
        {
            cnMysql = cn;
        }

        //primero, segundo, tercero ,etc
        public List<edGrado> adListarGrado(int adidetapa, int adidalumno)
        {
            try
            {
                List<edGrado> loenGrado = new List<edGrado>();

                using (MySqlCommand cmd = new MySqlCommand("spgrado_listar", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@_idetapa", MySqlDbType.Int32).Value = adidetapa;
                    cmd.Parameters.Add("@_idalumno", MySqlDbType.Int32).Value = adidalumno;

                    using (MySqlDataReader mdrd = cmd.ExecuteReader())
                    {
                        if (mdrd != null)
                        {
                            edGrado oengrado = null;
                            int pos_idgrado = mdrd.GetOrdinal("idgrado");
                            int pos_idetapa = mdrd.GetOrdinal("idetapa");
                            int pos_nombre = mdrd.GetOrdinal("nombre");
                            int pos_descripcion = mdrd.GetOrdinal("descripcion");
                            int pos_monto = mdrd.GetOrdinal("monto");
                            int pos_promocionfechainicio = mdrd.GetOrdinal("promocionfechainicio");
                            int pos_promocionfechafin = mdrd.GetOrdinal("promocionfechafin");
                            int pos_rutaimagen = mdrd.GetOrdinal("rutaimagen");
                            int pos_videoenlace = mdrd.GetOrdinal("videoenlace");
                            int pos_valoracion = mdrd.GetOrdinal("valoracion");
                            int pos_result = mdrd.GetOrdinal("_result");

                            while (mdrd.Read())
                            {
                                oengrado = new edGrado();
                                oengrado.idgrado = (mdrd.IsDBNull(pos_idgrado) ? 0 : mdrd.GetInt32(pos_idgrado));
                                oengrado.idetapa = (mdrd.IsDBNull(pos_idetapa) ? 0 : mdrd.GetInt32(pos_idetapa));
                                oengrado.snombre = (mdrd.IsDBNull(pos_nombre) ? "-" : mdrd.GetString(pos_nombre));
                                oengrado.sdescripcion = (mdrd.IsDBNull(pos_descripcion) ? "-" : mdrd.GetString(pos_descripcion));
                                oengrado.imonto = (mdrd.IsDBNull(pos_monto) ? 0 : mdrd.GetInt32(pos_monto));
                                oengrado.spromofecinicio = (mdrd.IsDBNull(pos_promocionfechainicio) ? "-" : mdrd.GetString(pos_promocionfechainicio));
                                oengrado.spromofecfin = (mdrd.IsDBNull(pos_promocionfechafin) ? "-" : mdrd.GetString(pos_promocionfechafin));
                                oengrado.sRutaimagen = (mdrd.IsDBNull(pos_rutaimagen) ? "-" : mdrd.GetString(pos_rutaimagen));
                                oengrado.svideoenlace = (mdrd.IsDBNull(pos_videoenlace) ? "-" : mdrd.GetString(pos_videoenlace));
                                oengrado.ivaloracion = (mdrd.IsDBNull(pos_valoracion) ? 0 : mdrd.GetInt32(pos_valoracion));
                                oengrado.sRespuesta = (mdrd.IsDBNull(pos_result) ? "-" : mdrd.GetString(pos_result));

                                loenGrado.Add(oengrado);
                            }
                        }
                    }
                    return loenGrado;
                }
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessAD, UtlConstantes.LogNamespace_TProcessAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        //MATEMATICA, QUIMICA , ETC
        public List<edCurso> adListarCurso(int adidgrado, int adidetapa, int adidalumno)
        {
            try
            {
                List<edCurso> loenCurso = new List<edCurso>();
                using (MySqlCommand cmd = new MySqlCommand("spcurso_listar", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@_idgrado", MySqlDbType.Int32).Value = adidgrado;
                    cmd.Parameters.Add("@_idetapa", MySqlDbType.Int32).Value = adidetapa;
                    cmd.Parameters.Add("@_idalumno", MySqlDbType.Int32).Value = adidalumno;
                    using (MySqlDataReader mdrd = cmd.ExecuteReader())
                    {
                        if (mdrd != null)
                        {
                            edCurso oencurso = null;
                            int pos_idcurso = mdrd.GetOrdinal("idcurso");
                            int pos_idgrado = mdrd.GetOrdinal("idgrado");
                            int pos_idetapa = mdrd.GetOrdinal("idetapa");
                            int pos_nombre = mdrd.GetOrdinal("nombre");
                            int pos_descripcion = mdrd.GetOrdinal("descripcion");
                            int pos_rutaimagen = mdrd.GetOrdinal("rutaimagen");
                            int pos_videoenlace = mdrd.GetOrdinal("videoenlace");
                            int pos_valoracion = mdrd.GetOrdinal("valoracion");
                            int pos_result = mdrd.GetOrdinal("_result");

                            while (mdrd.Read())
                            {
                                oencurso = new edCurso();
                                oencurso.idcurso = (mdrd.IsDBNull(pos_idcurso) ? 0 : mdrd.GetInt32(pos_idcurso));
                                oencurso.idgrado = (mdrd.IsDBNull(pos_idgrado) ? 0 : mdrd.GetInt32(pos_idgrado));
                                oencurso.idetapa = (mdrd.IsDBNull(pos_idetapa) ? 0 : mdrd.GetInt32(pos_idetapa));
                                oencurso.snombre = (mdrd.IsDBNull(pos_nombre) ? "-" : mdrd.GetString(pos_nombre));
                                oencurso.sdescripcion = (mdrd.IsDBNull(pos_descripcion) ? "-" : mdrd.GetString(pos_descripcion));
                                oencurso.srutaimagen = (mdrd.IsDBNull(pos_rutaimagen) ? "-" : mdrd.GetString(pos_rutaimagen));
                                oencurso.svideoenlace = (mdrd.IsDBNull(pos_videoenlace) ? "-" : mdrd.GetString(pos_videoenlace));
                                oencurso.ivaloracion = (mdrd.IsDBNull(pos_valoracion) ? 0 : mdrd.GetInt32(pos_valoracion));
                                oencurso.Srespuesta = (mdrd.IsDBNull(pos_result) ? "-" : mdrd.GetString(pos_result));

                                loenCurso.Add(oencurso);
                            }
                        }
                    }
                    return loenCurso;
                }
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessAD, UtlConstantes.LogNamespace_TProcessAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        //VIDEO.mp4, etc
        public List<edCurso> adListarVideo(int adidcurso, int adidalumno, string adfechabuscar)
        {
            try
            {
                List<edCurso> loenvideo = new List<edCurso>();
                using (MySqlCommand cmd = new MySqlCommand("spvideo_listar", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@_idcurso", MySqlDbType.Int32).Value = adidcurso;
                    cmd.Parameters.Add("@_idalumno", MySqlDbType.Int32).Value = adidalumno;
                    cmd.Parameters.Add("@_fechabuscar", MySqlDbType.VarChar, 25).Value = adfechabuscar;

                    using (MySqlDataReader mdrd = cmd.ExecuteReader())
                    {
                        if (mdrd != null)
                        {
                            edCurso oenvideo = null;
                            int pos_idvideo = mdrd.GetOrdinal("idvideo");
                            int pos_idcurso = mdrd.GetOrdinal("idcurso");
                            int pos_nombre = mdrd.GetOrdinal("nombre");
                            int pos_descripcion = mdrd.GetOrdinal("descripcion");
                            int pos_orden = mdrd.GetOrdinal("orden");
                            int pos_rutavideo = mdrd.GetOrdinal("rutavideo");
                            int pos_rutaenlace = mdrd.GetOrdinal("rutaenlace");
                            int pos_result = mdrd.GetOrdinal("_result");

                            while (mdrd.Read())
                            {
                                oenvideo = new edCurso();
                                oenvideo.idvideo = (mdrd.IsDBNull(pos_idvideo) ? 0 : mdrd.GetInt32(pos_idvideo));
                                oenvideo.idcurso = (mdrd.IsDBNull(pos_idcurso) ? 0 : mdrd.GetInt32(pos_idcurso));
                                oenvideo.snombre = (mdrd.IsDBNull(pos_nombre) ? "-" : mdrd.GetString(pos_nombre));
                                oenvideo.sdescripcion = (mdrd.IsDBNull(pos_descripcion) ? "-" : mdrd.GetString(pos_descripcion));
                                oenvideo.iorden = (mdrd.IsDBNull(pos_orden) ? 0 : mdrd.GetInt32(pos_orden));
                                oenvideo.srutavideo = (mdrd.IsDBNull(pos_rutavideo) ? "-" : mdrd.GetString(pos_rutavideo));
                                oenvideo.srutaenlace = (mdrd.IsDBNull(pos_rutaenlace) ? "-" : mdrd.GetString(pos_rutaenlace));
                                oenvideo.Srespuesta = (mdrd.IsDBNull(pos_result) ? "-" : mdrd.GetString(pos_result));

                                loenvideo.Add(oenvideo);
                            }
                        }
                    }
                    return loenvideo;
                }
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessAD, UtlConstantes.LogNamespace_TProcessAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public edCurso adBuscarCurso(int adidgrado, int adidetapa, string adnombre)
        {
            try
            {
                edCurso oencurso = null;
                using (MySqlCommand cmd = new MySqlCommand("spcurso_buscar", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@_idgrado", MySqlDbType.Int32).Value = adidgrado;
                    cmd.Parameters.Add("@_idetapa", MySqlDbType.Int32).Value = adidetapa;
                    cmd.Parameters.Add("@_nombre", MySqlDbType.VarChar, 50).Value = adnombre;
                    using (MySqlDataReader mdrd = cmd.ExecuteReader())
                    {
                        if (mdrd != null)
                        {
                            int pos_idcurso = mdrd.GetOrdinal("idcurso");
                            int pos_idgrado = mdrd.GetOrdinal("idgrado");
                            int pos_idetapa = mdrd.GetOrdinal("idetapa");
                            int pos_nombre = mdrd.GetOrdinal("nombre");

                            while (mdrd.Read())
                            {
                                oencurso = new edCurso();
                                oencurso.idcurso = (mdrd.IsDBNull(pos_idcurso) ? 0 : mdrd.GetInt32(pos_idcurso));
                                oencurso.idgrado = (mdrd.IsDBNull(pos_idgrado) ? 0 : mdrd.GetInt32(pos_idgrado));
                                oencurso.idetapa = (mdrd.IsDBNull(pos_idetapa) ? 0 : mdrd.GetInt32(pos_idetapa));
                                oencurso.snombre = (mdrd.IsDBNull(pos_nombre) ? "-" : mdrd.GetString(pos_nombre));
                            }
                        }
                    }
                    return oencurso;
                }
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessAD, UtlConstantes.LogNamespace_TProcessAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public int adRegistrarCurso(int adidcurso, string adnombre, string addescripcion, string adrutavideo)
        {
            try
            {
                int result = -1;
                MySqlCommand cmd = new MySqlCommand("spcurso_crear", cnMysql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@_idcurso", MySqlDbType.Int32).Value = adidcurso;
                cmd.Parameters.Add("@_nombre", MySqlDbType.VarChar, 50).Value = adnombre;
                cmd.Parameters.Add("@_descripcion", MySqlDbType.VarChar, 150).Value = addescripcion;
                cmd.Parameters.Add("@_rutavideo", MySqlDbType.VarChar, 250).Value = adrutavideo;

                result = Convert.ToInt32(cmd.ExecuteScalar());
                return result;
            }
            catch (Exception ex)
            {
                //utllog.towrite(utlconstantes.tprocessad, utlconstantes.lognamespace_tprocessad, this.gettype().name.tostring(), methodbase.getcurrentmethod().name, utlconstantes.logtipoerror, "", ex.stacktrace.tostring(), ex.message.tostring());
                throw ex;
            }
        }

        // ADMINISTRADOR
        public List<edCurso> adListadoVideo()
        {
            try
            {
                List<edCurso> loenvideo = new List<edCurso>();
                using (MySqlCommand cmd = new MySqlCommand("spvideo_listado", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (MySqlDataReader mdrd = cmd.ExecuteReader())
                    {
                        if (mdrd != null)
                        {
                            edCurso oenvideo = null;
                            int pos_idvideo = mdrd.GetOrdinal("idvideo");
                            int pos_idcurso = mdrd.GetOrdinal("idcurso");
                            int pos_nombre = mdrd.GetOrdinal("nombre");
                            int pos_descripcion = mdrd.GetOrdinal("descripcion");
                            int pos_orden = mdrd.GetOrdinal("orden");
                            int pos_rutavideo = mdrd.GetOrdinal("rutavideo");
                            int pos_rutaenlace = mdrd.GetOrdinal("rutaenlace");

                            while (mdrd.Read())
                            {
                                oenvideo = new edCurso();
                                oenvideo.idvideo = (mdrd.IsDBNull(pos_idvideo) ? 0 : mdrd.GetInt32(pos_idvideo));
                                oenvideo.idcurso = (mdrd.IsDBNull(pos_idcurso) ? 0 : mdrd.GetInt32(pos_idcurso));
                                oenvideo.snombre = (mdrd.IsDBNull(pos_nombre) ? "-" : mdrd.GetString(pos_nombre));
                                oenvideo.sdescripcion = (mdrd.IsDBNull(pos_descripcion) ? "-" : mdrd.GetString(pos_descripcion));
                                oenvideo.iorden = (mdrd.IsDBNull(pos_orden) ? 0 : mdrd.GetInt32(pos_orden));
                                oenvideo.srutavideo = (mdrd.IsDBNull(pos_rutavideo) ? "-" : mdrd.GetString(pos_rutavideo));
                                oenvideo.srutaenlace = (mdrd.IsDBNull(pos_rutaenlace) ? "-" : mdrd.GetString(pos_rutaenlace));
                                loenvideo.Add(oenvideo);
                            }
                        }
                    }
                    return loenvideo;
                }
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessAD, UtlConstantes.LogNamespace_TProcessAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public int adEliminarCurso(int idvideo)
        {
            try
            {
                int result = -1;
                MySqlCommand cmd = new MySqlCommand("spvideo_eliminar", cnMysql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@_idvideo", MySqlDbType.Int32).Value = idvideo;

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
