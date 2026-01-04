using PortalCliente.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.BLL
{
    public class Relatorio
    {
        public List<DTO.Relatorio> Select(int MailingId)
        {
            return new DAL.Relatorio().Select(MailingId);
        }
    }
}
