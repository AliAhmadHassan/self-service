using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.BLL
{
    public class Link
    {
        public DTO.Link Select(int ClienteId, int TelId,int MailingId)
        {
            return new DAL.Link().SelectClienteId(ClienteId, TelId, MailingId);
        }

        public DTO.Link SelectById(int Id)
        {
            return new DAL.Link().SelecionarLinkId(Id);
        }

        public DTO.Link Insert(int ClienteId, int TelId, int MailingId)
        {
            return new DAL.Link().Insert(ClienteId, TelId, MailingId);
        }

        public void Alterar(DTO.Link Entidade)
        {
            new DAL.Link().Alterar(Entidade);
        }
    }
}
