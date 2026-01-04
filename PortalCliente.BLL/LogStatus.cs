using PortalCliente.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.BLL
{
    public class LogStatus:ILogStatus
    {
        public List<DTO.LogStatus> Select()
        {
            return new DAL.LogStatus().Select();
        }

        public DTO.LogStatus SelectById(int Id)
        {
            return new DAL.LogStatus().SelectById(Id);
        }

        public void Remover(DTO.LogStatus Entidade)
        {
            new DAL.LogStatus().Remover(Entidade);
        }

        public void Cadastro(DTO.LogStatus Entidade)
        {
            new DAL.LogStatus().Cadastro(Entidade);
        }
    }
}
