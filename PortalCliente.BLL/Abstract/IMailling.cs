using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.BLL.Abstract
{
    public interface IMailling
    {
        List<DTO.Mailling> Select(int CredId, DateTime dataDe, DateTime dataAte);

        DTO.Mailling Insert(string Nome, int CredId);

        DTO.Mailling SelectByMailingId(int MailingId);
        
    }
}
