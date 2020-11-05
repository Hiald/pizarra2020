using MySql.Data.MySqlClient;
using backendAD;
using backendED;
using System;
using System.Collections.Generic;

namespace backendTD
{
    public class tdEtapa : td_ageneral
    {
        adEtapa iadEtapa;

        // inicial, primaria, secundaria, etc
        public List<edEtapa> tdListarEtapa(int tdidalumno)
        {
            try
            {
                List<edEtapa> loenEtapa = new List<edEtapa>();
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {
                        iadEtapa = new adEtapa(con);
                        loenEtapa = iadEtapa.adListarEtapa(tdidalumno);
                        scope.Commit();
                    }
                }
                return loenEtapa;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessRN, UtlConstantes.LogNamespace_TProcessRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }


    }
}
