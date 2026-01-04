using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.BLL.Abstract
{
    public interface ISolicitacaoRetorno:IBase<DTO.SolicitacaoRetorno>
    {
		List<DTO.SolicitacaoRetorno> SelectByClienteId(int ClienteId);
        List<DTO.SolicitacaoRetorno> SelectByNotRetorned();
    }
}