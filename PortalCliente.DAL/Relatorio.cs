using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PortalCliente.DAL
{
    public class Relatorio:Conexao
    {
        public List<DTO.Relatorio> Select(int MaillingId)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@MailingId", System.Data.SqlDbType.Int) { Value = MaillingId });

            return AuxConsultas<DTO.Relatorio>.Lista("SPSRelatorioMailling", strConn(DTO.Base.TipoConexao.Core), parametros.ToArray());
        }
    }
}
