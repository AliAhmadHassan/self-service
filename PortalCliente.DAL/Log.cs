using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.DAL
{
    public class Log:Base<DTO.Log>
    {
        public List<DTO.Log> SelectByClienteId(int ClienteId)
        {
            return AuxConsultas<DTO.Log>.Lista("SPSLogByClienteId", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@ClienteId", ClienteId));
        }
        public List<DTO.Log> SelectByLogStatusId(int LogStatusId)
        {
            return AuxConsultas<DTO.Log>.Lista("SPSLogByLogStatusId", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@LogStatusId", LogStatusId));
        }
    }
}
