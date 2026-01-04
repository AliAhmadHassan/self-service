using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalCliente.Web.Models
{
    public class Credor : DTO.Credor, IModel<Credor, DTO.Credor>
    {
        public Credor GetDTO(DTO.Credor Entidade)
        {
            Credor credor = Auxiliar.RetornaDadosEntidade<DTO.Credor, Credor>(Entidade);

            return credor;
        }

        public List<Credor> GetDTO(List<DTO.Credor> Entidades)
        {
            List<Credor> listCredor = new List<Credor>();
            foreach (DTO.Credor credor in Entidades)
                listCredor.Add(GetDTO(credor));

            return listCredor;
        }
    }
}
