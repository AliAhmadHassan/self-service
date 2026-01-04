using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.DAL
{
    public class Lote:Base<DTO.Lote>
    {
        public List<DTO.Lote> SelectByCredId(int CredId)
        {
            return AuxConsultas<DTO.Lote>.Lista("SPSLoteByCredId", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@CredId", CredId));
        }

        public List<DTO.Lote> SelectByNotAtivo()
        {
            return AuxConsultas<DTO.Lote>.Lista("SPSLoteByNotAtivo", strConn(DTO.Base.TipoConexao.Core), null);
        }

        public DTO.Lote SelectByAgendaId(int agendaId)
        {
            return AuxConsultas<DTO.Lote>.Entidade("SPSLoteByAgendaId", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@AgendaId", System.Data.SqlDbType.Int) { Value = agendaId });
        }
    }
}
