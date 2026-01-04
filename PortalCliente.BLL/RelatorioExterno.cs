using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.BLL
{
    public class RelatorioExterno
    {
        public List<DTO.RelatorioExterno> SelectRelatorio(int MailingId, int Status)
        {
            return new DAL.RelatorioExterno().SelectRelatorio(MailingId, Status);
        }
    }
}
