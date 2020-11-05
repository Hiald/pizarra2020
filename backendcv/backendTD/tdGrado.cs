using MySql.Data.MySqlClient;
using backendAD;
using backendED;
using System.Collections.Generic;

namespace backendTD
{
    public class tdGrado : td_ageneral
    {
        adGrado iadGrado;

        //primero, segundo, tercero, etc
        public List<edGrado> tdListarGrado(int tdidetapa, int tdidalumno)
        {

            List<edGrado> loenGrado = new List<edGrado>();
            try
            {
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {
                        iadGrado = new adGrado(con);
                        loenGrado = iadGrado.adListarGrado(tdidetapa, tdidalumno);
                        scope.Commit();
                    }
                }
                return (loenGrado);
            }
            catch (MySqlException ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessRN, UtlConstantes.LogNamespace_TProcessRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        //MATEMATICA, QUIMICA , ETC
        public List<edCurso> tdListarCurso(int tdidgrado, int tidetapa, int tdidalumno)
        {
            List<edCurso> loenGrado = new List<edCurso>();
            try
            {
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {
                        iadGrado = new adGrado(con);
                        loenGrado = iadGrado.adListarCurso(tdidgrado, tidetapa, tdidalumno);
                        scope.Commit();
                    }
                }
                return (loenGrado);
            }
            catch (MySqlException ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessRN, UtlConstantes.LogNamespace_TProcessRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        //VIDEO.mp4, etc
        public List<edCurso> tdListarVideo(int tdidcurso, int tdidalumno, string tdfechabuscar)
        {
            List<edCurso> loenGrado = new List<edCurso>();
            try
            {
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {
                        iadGrado = new adGrado(con);
                        loenGrado = iadGrado.adListarVideo(tdidcurso, tdidalumno, tdfechabuscar);
                        scope.Commit();
                    }
                }
                return (loenGrado);
            }
            catch (MySqlException ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessRN, UtlConstantes.LogNamespace_TProcessRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public edCurso tdBuscarCurso(int tdidgrado, int tdidetapa, string tdnombre)
        {
            edCurso renUsuario = new edCurso();
            try
            {
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {
                        iadGrado = new adGrado(con);
                        renUsuario = iadGrado.adBuscarCurso(tdidgrado, tdidetapa, tdnombre);
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

        public int tdRegistrarCurso(int tdidcurso, string tdnombre, string tddescripcion, string tdrutavideo)
        {
            try
            {
                int iResultado = -1;
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {
                        iadGrado = new adGrado(con);
                        iResultado = iadGrado.adRegistrarCurso(tdidcurso, tdnombre, tddescripcion, tdrutavideo);
                        scope.Commit();
                    }
                }
                return iResultado;
            }
            catch (MySqlException ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessRN, UtlConstantes.LogNamespace_TProcessRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        //ADMINISTRADOR
        public List<edCurso> tdListadoVideo()
        {
            List<edCurso> loenGrado = new List<edCurso>();
            try
            {
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {
                        iadGrado = new adGrado(con);
                        loenGrado = iadGrado.adListadoVideo();
                        scope.Commit();
                    }
                }
                return (loenGrado);
            }
            catch (MySqlException ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessRN, UtlConstantes.LogNamespace_TProcessRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public int tdEliminarCurso(int tadvideo)
        {
            try
            {
                int iResultado = -1;
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {
                        iadGrado = new adGrado(con);
                        iResultado = iadGrado.adEliminarCurso(tadvideo);
                        scope.Commit();
                    }
                }
                return iResultado;
            }
            catch (MySqlException ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessRN, UtlConstantes.LogNamespace_TProcessRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

    }
}
