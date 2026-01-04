using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.BLL.Abstract
{
    public interface ILote:IBase<DTO.Lote>
    {
		List<DTO.Lote> SelectByCredId(int CredId);

        List<DTO.Lote> SelectByNotAtivo();

        DTO.Lote SelectByAgendaId(int agendaId);
    }
}