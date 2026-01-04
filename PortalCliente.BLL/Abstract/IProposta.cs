using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.BLL.Abstract
{
    public interface IProposta:IBase<DTO.Proposta>
    {
		List<DTO.Proposta> SelectByClienteId(int ClienteId);
		List<DTO.Proposta> SelectByLoteId(int LoteId);
		List<DTO.Proposta> SelectByDadosBoletoId(int DadosBoletoId);
    }
}