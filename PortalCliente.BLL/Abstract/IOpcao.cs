using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.BLL.Abstract
{
    public interface IOpcao:IBase<DTO.Opcao>
    {
		List<DTO.Opcao> SelectByPropostaId(int PropostaId);
    }
}