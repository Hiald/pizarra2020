using MySql.Data.MySqlClient;
using backendED;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backendAD
{
    public class adPago : ad_aglobal
    {
        public adPago(MySqlConnection cn)
        {
            cnMysql = cn;
        }

        public edPago adNotificarPago(int adidusuario, int adidcategoria)
        {
            try
            {
                edPago senUsuario = null;
                using (MySqlCommand cmd = new MySqlCommand("sppago_notificar", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@_idalumno", MySqlDbType.Int32).Value = adidusuario;
                    cmd.Parameters.Add("@_idcategoria", MySqlDbType.Int32).Value = adidcategoria;
                    using (MySqlDataReader mdrd = cmd.ExecuteReader())
                    {
                        if (mdrd != null)
                        {
                            int pos_fecha = mdrd.GetOrdinal("fecha");
                            while (mdrd.Read())
                            {
                                senUsuario = new edPago();
                                senUsuario.idpago = (mdrd.IsDBNull(pos_fecha) ? 0 : mdrd.GetInt32(pos_fecha));

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

        public int adRegistrarSietemeses(string adidlumno, string adidetapa, int adtipopago)
        {
            try
            {
                int result = -1;
                MySqlCommand cmd = new MySqlCommand("spalumno_crearsietemeses", cnMysql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@_idalumno", MySqlDbType.Int32).Value = adidlumno;
                cmd.Parameters.Add("@_idetapa", MySqlDbType.Int32).Value = adidetapa;
                cmd.Parameters.Add("@_tipopago", MySqlDbType.Int32).Value = adtipopago;

                result = Convert.ToInt32(cmd.ExecuteScalar());
                return result;
            }
            catch (Exception ex)
            {
                //utllog.towrite(utlconstantes.tprocessad, utlconstantes.lognamespace_tprocessad, this.gettype().name.tostring(), methodbase.getcurrentmethod().name, utlconstantes.logtipoerror, "", ex.stacktrace.tostring(), ex.message.tostring());
                throw ex;
            }
        }

        public int adRegistrarDosmeses(string adidlumno, string adidetapa, int adtipopago)
        {
            try
            {
                int result = -1;
                MySqlCommand cmd = new MySqlCommand("spalumno_creardomeses", cnMysql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@_idalumno", MySqlDbType.Int32).Value = adidlumno;
                cmd.Parameters.Add("@_idetapa", MySqlDbType.Int32).Value = adidetapa;
                cmd.Parameters.Add("@_tipopago", MySqlDbType.Int32).Value = adtipopago;

                result = Convert.ToInt32(cmd.ExecuteScalar());
                return result;
            }
            catch (Exception ex)
            {
                //utllog.towrite(utlconstantes.tprocessad, utlconstantes.lognamespace_tprocessad, this.gettype().name.tostring(), methodbase.getcurrentmethod().name, utlconstantes.logtipoerror, "", ex.stacktrace.tostring(), ex.message.tostring());
                throw ex;
            }
        }

        public int adRegistrarMes(string adidlumno, string adidetapa, int adtipopago)
        {
            try
            {
                int result = -1;
                MySqlCommand cmd = new MySqlCommand("spalumno_crearMes", cnMysql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@_idalumno", MySqlDbType.Int32).Value = adidlumno;
                cmd.Parameters.Add("@_idetapa", MySqlDbType.Int32).Value = adidetapa;
                cmd.Parameters.Add("@_tipopago", MySqlDbType.Int32).Value = adtipopago;

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
