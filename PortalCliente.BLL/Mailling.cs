using PortalCliente.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortalCliente.DTO;

namespace PortalCliente.BLL
{
    public class Mailling : IMailling
    {
        public List<DTO.Mailling> Select(int CredId, DateTime dataDe, DateTime dataAte)
        {
            return new DAL.Mailling().Select(CredId, dataDe, dataAte);
        }

        public DTO.Mailling Insert(string Nome, int CredId)
        {
            return new DAL.Mailling().Insert(Nome, CredId);
        }

        public List<DTO.Mailling> SelectAll()
        {
            return new DAL.Mailling().SelectAll();
        }

        public DTO.Mailling SelectByMailingId(int MailingId)
        {
            return new DAL.Mailling().SelectByMailingId(MailingId);
        }
    }
}
