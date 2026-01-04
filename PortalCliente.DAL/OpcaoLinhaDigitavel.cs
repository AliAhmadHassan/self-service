using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.DAL
{
    public class OpcaoLinhaDigitavel : Base<DTO.OpcaoLinhaDigitavel>
    {
        public List<DTO.OpcaoLinhaDigitavel> SelectByOpcaoId(int OpcaoId)
        {
            return AuxConsultas<DTO.OpcaoLinhaDigitavel>.Lista("SPSOpcaoLinhaDigitavelByOpcaoId", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@OpcaoId", OpcaoId));
        }

        public void Inserir(DTO.OpcaoLinhaDigitavel Entidade)
        {
            AuxConsultas<DTO.OpcaoLinhaDigitavel>.Lista("SPIOpcaoLinhaDigitavelByOpcaoId", strConn(DTO.Base.TipoConexao.Core),
                new SqlParameter("@OpcaoId", Entidade.OpcaoId),
                new SqlParameter("@LinhaDigitavel", Entidade.LinhaDigitavel)
                );
        }
    }
}
