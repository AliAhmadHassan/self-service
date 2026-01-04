using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.DAL
{
    public class SolicitacaoRetorno:Base<DTO.SolicitacaoRetorno>
    {
        public List<DTO.SolicitacaoRetorno> SelectByClienteId(int ClienteId)
        {
            return AuxConsultas<DTO.SolicitacaoRetorno>.Lista("SPSSolicitacaoRetornoByClienteId", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@ClienteId", ClienteId));
        }

        public List<DTO.SolicitacaoRetorno> SelectByNotRetorned()
        {
            return AuxConsultas<DTO.SolicitacaoRetorno>.Lista("SPSSolicitacaoRetornoByNotRetorned", strConn(DTO.Base.TipoConexao.Core), null);
        }
    }
}
