using backendAD;
using backendED;
using System;
using MySql.Data.MySqlClient;

namespace backendTD
{
    public class tdDocente : td_ageneral
    {
        adDocente radDocente;

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

                        radDocente = new adDocente(con);
                        iRespuesta = radDocente.adValidarCorreo(tdcorreo);
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

        public int tdRegistrarDocente(string tdnombre, string tdapellido, string tdemail, string tdclave)
        {
            try
            {
                int iResultado = -1;
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {
                        radDocente = new adDocente(con);
                        iResultado = radDocente.adRegistrarDocente(tdnombre, tdapellido, tdemail, tdclave);
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

        public edDocente tdListarDocente(int tdiddocente)
        {
            edDocente renUsuario = new edDocente();
            try
            {
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {
                        radDocente = new adDocente(con);
                        renUsuario = radDocente.adListarDocente(tdiddocente);
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

        public int tdLogeoDocente(string tdcorreo, string tdclave)
        {
            int iRespuesta = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {
                        radDocente = new adDocente(con);
                        iRespuesta = radDocente.adLogeoDocente(tdcorreo, tdclave);
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

        public int tdRegistrarSesiones(int tdiddocente, string tddireccionip, string tddireccionmac, int tdtipoconexion)
        {
            int iRespuesta = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {
                        radDocente = new adDocente(con);
                        iRespuesta = radDocente.adRegistrarSesiones(tdiddocente, tddireccionip, tddireccionmac, tdtipoconexion);
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

    }
}
