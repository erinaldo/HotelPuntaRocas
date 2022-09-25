using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatosExternos;
using CapaEntidadesExternos;

namespace CapaNegocioExternos
{
    public class PadronEmpresaApplication : DataAccess, IPadronEmpresas
    {
        public List<PadronEmpresas> ConsultaEmpresa(string RUC)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString_Padron))
            {
                List<PadronEmpresas> oListPadron = new List<PadronEmpresas>();
                SqlCommand cmd = new SqlCommand("USP_RE_PadronEmpresaByRUC", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@I_pRUC", SqlDbType.VarChar, 11).Value = RUC;

                cn.Open();
                IDataReader reader = ExecuteReader(cmd);
                while (reader.Read())
                {
                    PadronEmpresas oPadron = new PadronEmpresas
                    {
                        RUC = reader["RUC"].ToString(),
                        RAZON_SOCIAL = reader["RAZON_SOCIAL"].ToString(),
                        UBIGEO = reader["UBIGEO"].ToString(),
                        DIRECCION = reader["DIRECCION"].ToString(),
                        DESCRIPCION_UBIGEO = reader["DESCRIPCION_UBIGEO"].ToString(),
                        ESTADO_CONTRIBUYENTE = reader["ESTADO_CONTRIBUYENTE"].ToString(),
                        CONDICION_CONTRIBUYENTE = reader["CONDICION_CONTRIBUYENTE"].ToString()


                    };
                    oListPadron.Add(oPadron);
                }

                return oListPadron;
            }
        }
    }
}

