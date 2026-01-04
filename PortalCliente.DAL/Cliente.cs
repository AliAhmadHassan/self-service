using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.DAL
{
    public class Cliente:Base<DTO.Cliente>
    {
        public DTO.Cliente SelectByCpfCnpj(string cpfCnpj)
        {
            return AuxConsultas<DTO.Cliente>.Entidade("SPSClienteByCpfCnpj", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@CpfCnpj", System.Data.SqlDbType.VarChar, 15) { Value = cpfCnpj });
        }
    }
}
