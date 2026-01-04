using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.BLL.Abstract
{
    public interface IAcordo:IBase<DTO.Acordo>
    {
		List<DTO.Acordo> SelectByOpcaoId(int OpcaoId);
    }
}