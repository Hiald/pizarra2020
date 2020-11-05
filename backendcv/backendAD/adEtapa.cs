using MySql.Data.MySqlClient;
using backendED;
using System;
using System.Collections.Generic;
using System.Data;

namespace backendAD
{
    public class adEtapa : ad_aglobal
    {
        public adEtapa(MySqlConnection cn)
        {
            cnMysql = cn;
        }

        //INICIAL, PRIMARIA, SECUNDARIA
        public List<edEtapa> adListarEtapa(int adidalumno)
        {
            try
            {
                List<edEtapa> loenetapa = new List<edEtapa>();
                using (MySqlCommand cmd = new MySqlCommand("spetapa_listar", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@_idalumno", MySqlDbType.Int32).Value = adidalumno;
                    using (MySqlDataReader mdrd = cmd.ExecuteReader())
                    {
                        if (mdrd != null)
                        {
                            edEtapa oenetapa = null;

                            int pos_idetapa = mdrd.GetOrdinal("idetapa");
                            int pos_nombre = mdrd.GetOrdinal("nombre");
                            int pos_descripcion = mdrd.GetOrdinal("descripcion");
                            int pos_activo = mdrd.GetOrdinal("activo");
                            int pos_monto = mdrd.GetOrdinal("monto");
                            int pos_rutaimagen = mdrd.GetOrdinal("rutaimagen");
                            int pos_resultado = mdrd.GetOrdinal("resultado");
                            int pos_pasarelapago = mdrd.GetOrdinal("pasarela_pago_nombre");

                            while (mdrd.Read())
                            {
                                oenetapa = new edEtapa();
                                oenetapa.idetapa = (mdrd.IsDBNull(pos_idetapa) ? 0 : mdrd.GetInt32(pos_idetapa));
                                oenetapa.snombre = (mdrd.IsDBNull(pos_nombre) ? "-" : mdrd.GetString(pos_nombre));
                                oenetapa.sdescripcion = (mdrd.IsDBNull(pos_descripcion) ? "-" : mdrd.GetString(pos_descripcion));
                                oenetapa.iactivo = (mdrd.IsDBNull(pos_activo) ? 0 : mdrd.GetInt32(pos_activo));
                                oenetapa.imonto = (mdrd.IsDBNull(pos_monto) ? 0 : mdrd.GetInt32(pos_monto));
                                oenetapa.sRutaimagen = (mdrd.IsDBNull(pos_rutaimagen) ? "-" : mdrd.GetString(pos_rutaimagen));
                                oenetapa.sRespuesta = (mdrd.IsDBNull(pos_resultado) ? "-" : mdrd.GetString(pos_resultado));
                                oenetapa.spasarelapago = (mdrd.IsDBNull(pos_pasarelapago) ? "-" : mdrd.GetString(pos_pasarelapago));

                                loenetapa.Add(oenetapa);
                            }
                        }

                    }
                }
                return loenetapa;
            }

            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessAD, UtlConstantes.LogNamespace_TProcessAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }
    }
}
