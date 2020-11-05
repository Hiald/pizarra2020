using backendAD;
using backendED;
using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace backendTD
{
    public class tdArchivo : td_ageneral
    {
        adArchivo iadArchivo;

        public int tdRegistrarArchivo(int tddocenteid, int tdvideoid, int tdtipoarchivo, string tdurl)
        {
            try
            {
                int iResultado = -1;
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {
                        iadArchivo = new adArchivo(con);
                        iResultado = iadArchivo.adRegistrarArchivo(tddocenteid, tdvideoid, tdtipoarchivo, tdurl);
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

        public List<edArchivo> tdListarArchivo(int tdidvideo, int tdtipoarchivo)
        {
            List<edArchivo> renArchivo = new List<edArchivo>();
            try
            {
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {
                        iadArchivo = new adArchivo(con);
                        renArchivo = iadArchivo.adListarArchivo(tdidvideo, tdtipoarchivo);
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

        public int tdEliminarArchivo(int tdidvideoel)
        {
            int iRespuesta = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {
                        iadArchivo = new adArchivo(con);
                        iRespuesta = iadArchivo.adEliminarArchivo(tdidvideoel);
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
