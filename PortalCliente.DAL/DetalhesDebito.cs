using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.DAL
{
    public class DetalhesDebito:Base<DTO.DetalhesDebito>
    {
        public List<DTO.DetalhesDebito> SelectByPropostaId(int PropostaId)
        {
            return AuxConsultas<DTO.DetalhesDebito>.Lista("SPSDetalhesDebitoByPropostaId", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@PropostaId", PropostaId));
        }
    }
}
