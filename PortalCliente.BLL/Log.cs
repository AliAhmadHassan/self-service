using PortalCliente.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.BLL
{
    public class Log:ILog
    {
        public List<DTO.Log> Select()
        {
            return new DAL.Log().Select();
        }

        public DTO.Log SelectById(int Id)
        {
            return new DAL.Log().SelectById(Id);
        }

        public void Remover(DTO.Log Entidade)
        {
            new DAL.Log().Remover(Entidade);
        }

        public void Cadastro(DTO.Log Entidade)
        {
            new DAL.Log().Cadastro(Entidade);
        }

        public List<DTO.Log> SelectByClienteId(int ClienteId)
        {
            return new DAL.Log().SelectByClienteId(ClienteId);
        }

        public List<DTO.Log> SelectByLogStatusId(int LogStatusId)
        {
            return new DAL.Log().SelectByLogStatusId(LogStatusId);
        }
    }
}
