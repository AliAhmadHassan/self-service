using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.BLL.Abstract
{
    public interface ILog:IBase<DTO.Log>
    {
		List<DTO.Log> SelectByClienteId(int ClienteId);
		List<DTO.Log> SelectByLogStatusId(int LogStatusId);
    }
}