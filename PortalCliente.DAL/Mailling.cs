using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PortalCliente.DAL
{
    public class Mailling : Conexao
    {
        public List<DTO.Mailling> Select(int CredId, DateTime dataDe, DateTime dataAte)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@DataDe", System.Data.SqlDbType.Date) { Value = dataDe });
            parametros.Add(new SqlParameter("@DataAte", System.Data.SqlDbType.Date) { Value = dataAte });
            parametros.Add(new SqlParameter("@CredId", System.Data.SqlDbType.Int) { Value = CredId });

            return AuxConsultas<DTO.Mailling>.Lista("SPSMailling", strConn(DTO.Base.TipoConexao.Core), parametros.ToArray());
        }

        public DTO.Mailling Insert(string Nome, int CredId)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@NomeArquivo", System.Data.SqlDbType.VarChar, 250) { Value = Nome });
            parametros.Add(new SqlParameter("@CredId", System.Data.SqlDbType.Int) { Value = CredId });

            return AuxConsultas<DTO.Mailling>.Entidade("SPIMailing", strConn(DTO.Base.TipoConexao.Core), parametros.ToArray());
        }

        public List<DTO.Mailling> SelectAll()
        {
            return AuxConsultas<DTO.Mailling>.Lista("SPSMaillingAll", strConn(DTO.Base.TipoConexao.Core));
        }

        public DTO.Mailling SelectByMailingId(int MailingId)
        {
            return AuxConsultas<DTO.Mailling>.Entidade("SPSMaillingByMailingId", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@MailingId", System.Data.SqlDbType.Int) { Value = MailingId });
        }
    }
}
