using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalCliente.Web.Models
{
    public class Telefone : DTO.Telefone, IModel<Telefone, DTO.Telefone>
    {
        public Telefone GetDTO(DTO.Telefone Entidade)
        {
            Telefone telefone = Auxiliar.RetornaDadosEntidade<DTO.Telefone, Telefone>(Entidade);

            return telefone;
        }

        public List<Telefone> GetDTO(List<DTO.Telefone> Entidades)
        {
            List<Telefone> listCredor = new List<Telefone>();
            foreach (DTO.Telefone telefone in Entidades)
                listCredor.Add(GetDTO(telefone));

            return listCredor;
        }
    }
}
