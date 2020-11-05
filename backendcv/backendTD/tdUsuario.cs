using backendAD;
using backendED;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace backendTD
{
    public class tdUsuario : td_ageneral
    {
        adUsuario radUsuario;

        public int tdRegistrarUsuario(string tdnombre, string tdapellido, string tdemail, int tdetapa, int tdgrado, int tdseccion, string tdnombrepadre, string tdclave)
        {
            try
            {
                int iResultado = -1;
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {
                        radUsuario = new adUsuario(con);
                        iResultado = radUsuario.adRegistrarUsuario(tdnombre, tdapellido, tdemail, tdetapa, tdgrado, tdseccion, tdnombrepadre, tdclave);
                        scope.Commit();
                    }
                }
                return iResultado;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessRN, UtlConstantes.LogNamespace_TProcessRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public edUsuario tdListarUsuario(int tdidusuario)
        {

            edUsuario renUsuario = new edUsuario();
            try
            {
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {
                        radUsuario = new adUsuario(con);
                        renUsuario = radUsuario.adListarUsuario(tdidusuario);
                        scope.Commit();
                    }

                }

                return (renUsuario);
            }
            catch (MySqlException ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessRN, UtlConstantes.LogNamespace_TProcessRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }

        }

        public int tdValidarUsuario(string tdcorreo)
        {
            int iRespuesta = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {

                        radUsuario = new adUsuario(con);
                        iRespuesta = radUsuario.adValidarUsuario(tdcorreo);
                        scope.Commit();
                    }
                }

                return (iRespuesta);
            }
            catch (MySqlException ex)
            {
                // UtlLog.toWrite(UtlConstantes.TProcessRN, UtlConstantes.LogNamespace_TProcessRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }

        }

        public int tdValidarCorreo(string tdcorreo)
        {
            int iRespuesta = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {

                        radUsuario = new adUsuario(con);
                        iRespuesta = radUsuario.adValidarCorreo(tdcorreo);
                        scope.Commit();
                    }
                }

                return (iRespuesta);
            }
            catch (MySqlException ex)
            {
                // UtlLog.toWrite(UtlConstantes.TProcessRN, UtlConstantes.LogNamespace_TProcessRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }

        }

        public int tdLogeoUsuario(string tdcorreo, string tdclave)
        {
            int iRespuesta = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {
                        radUsuario = new adUsuario(con);
                        iRespuesta = radUsuario.adLogeoUsuario(tdcorreo, tdclave);
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

        public int tdRegistrarSesiones(int tdidalumno, string tddireccionip, string tddireccionmac, int tdtipoconexion)
        {
            int iRespuesta = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {
                        radUsuario = new adUsuario(con);
                        iRespuesta = radUsuario.adRegistrarSesiones(tdidalumno, tddireccionip, tddireccionmac, tdtipoconexion);
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

        /* CONFIGURACION */
        public List<edUsuario> tdListarUsuarioConfiguracion(string tdcorreo, string tdnombre, int tdcategoria)
        {
            List<edUsuario> renUsuario = new List<edUsuario>();
            try
            {
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {
                        radUsuario = new adUsuario(con);
                        renUsuario = radUsuario.adListarUsuarioConfiguracion(tdcorreo, tdnombre, tdcategoria);
                        scope.Commit();
                    }
                }

                return (renUsuario);
            }
            catch (MySqlException ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessRN, UtlConstantes.LogNamespace_TProcessRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }

        }

        public int tdGenerarClave(int tdidalumno, string tdnuevaclave)
        {
            try
            {
                int iResultado = -1;
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {
                        radUsuario = new adUsuario(con);
                        iResultado = radUsuario.adGenerarClave(tdidalumno, tdnuevaclave);
                        scope.Commit();
                    }

                }
                return iResultado;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessRN, UtlConstantes.LogNamespace_TProcessRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

    }
}
