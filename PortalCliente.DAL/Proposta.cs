using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.DAL
{
    public class Proposta:Base<DTO.Proposta>
    {
        public List<DTO.Proposta> SelectByClienteId(int ClienteId)
        {
            return AuxConsultas<DTO.Proposta>.Lista("SPSPropostaByClienteId", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@ClienteId", ClienteId));
        }
        public List<DTO.Proposta> SelectByLoteId(int LoteId)
        {
            return AuxConsultas<DTO.Proposta>.Lista("SPSPropostaByLoteId", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@LoteId", LoteId));
        }
        public List<DTO.Proposta> SelectByDadosBoletoId(int DadosBoletoId)
        {
            return AuxConsultas<DTO.Proposta>.Lista("SPSPropostaByDadosBoletoId", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@DadosBoletoId", DadosBoletoId));
        }

        public List<DTO.Proposta> SelectByLinkId(int ClienteId)
        {
            return AuxConsultas<DTO.Proposta>.Lista("SPSPropostaByLinkId", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@ClienteId", ClienteId));
        }
    }
}
