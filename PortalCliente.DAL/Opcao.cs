using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.DAL
{
    public class Opcao : Base<DTO.Opcao>
    {
        public List<DTO.Opcao> SelectByPropostaId(int PropostaId)
        {
            return AuxConsultas<DTO.Opcao>.Lista("SPSOpcaoByPropostaId", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@PropostaId", PropostaId));
        }

        public DTO.Opcao Insert(DTO.Opcao Entidade)
        {
            return AuxConsultas<DTO.Opcao>.Entidade("SPIOpcao", strConn(DTO.Base.TipoConexao.Core),
                new SqlParameter("@OpcaoId", System.Data.SqlDbType.Int) { Value = Entidade.OpcaoId },
                new SqlParameter("@PropostaId", System.Data.SqlDbType.Int) { Value = Entidade.PropostaId },
                new SqlParameter("@Plano", System.Data.SqlDbType.Int) { Value = Entidade.Plano },
                new SqlParameter("@Entrada", System.Data.SqlDbType.Money) { Value = Entidade.Entrada },
                new SqlParameter("@Parcela", System.Data.SqlDbType.Money) { Value = Entidade.Parcela }
                );
        }
    }
}
