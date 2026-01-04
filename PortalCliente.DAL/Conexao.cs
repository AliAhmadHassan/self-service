using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.DAL
{
    public class Conexao
    {
        private string ConnectionStringCore = "Data Source=192.168.21.94;Initial Catalog=PortalClienteDB;Persist Security Info=True;User ID=sa;Password=Admin357/";
        private string ConnectionStringCobNet = "Data Source=192.168.20.168;Initial Catalog=CobnetDB;Persist Security Info=True;User ID=CobnetID;Password=CobID357*";
        private string ConnectionStringCobNetBradesco = "Data Source=192.168.20.166;Initial Catalog=CobnetBradescoDB;Persist Security Info=True;User ID=sa;Password=Admin357/";
        private string ConnectionStringSRC = "Data Source=192.168.20.115;Initial Catalog=SRC;Persist Security Info=True;User ID=ti;Password=123123";
        protected string strConn(DTO.Base.TipoConexao tipoConexao)
        {
            string ConnectionString = string.Empty;

            switch (tipoConexao)
            {
                case DTO.Base.TipoConexao.Core:
                    ConnectionString = ConnectionStringCore;
                    break;
                case DTO.Base.TipoConexao.CobNet:
                    ConnectionString = ConnectionStringCobNet;
                    break;
                case DTO.Base.TipoConexao.CobNetBradesco:
                    ConnectionString = ConnectionStringCobNetBradesco;
                    break;
                case DTO.Base.TipoConexao.SRC:
                    ConnectionString = ConnectionStringSRC;
                    break;
            }
            return ConnectionString;
        }
        
    }
}
