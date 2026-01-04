using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalCliente.Web.Models
{
    public class Link : DTO.Link, IModel<Link, DTO.Link>
    {
        public Link GetDTO(DTO.Link Entidade)
        {
            Link link = Auxiliar.RetornaDadosEntidade<DTO.Link, Link>(Entidade);

            return link;
        }

        public List<Link> GetDTO(List<DTO.Link> Entidades)
        {
            List<Link> listLink = new List<Link>();
            foreach (DTO.Link link in Entidades)
                listLink.Add(GetDTO(link));

            return listLink;
        }
    }
}