using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.DAL
{
    public class Acordo:Base<DTO.Acordo>
    {
        public List<DTO.Acordo> SelectByOpcaoId(int OpcaoId)
        {
            return AuxConsultas<DTO.Acordo>.Lista("SPSAcordoByOpcaoId", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@OpcaoId", OpcaoId));
        }
    }
}
