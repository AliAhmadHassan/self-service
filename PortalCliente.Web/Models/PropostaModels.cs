using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalCliente.Web.Models
{
    public class Proposta : DTO.Proposta, IModel<Proposta, DTO.Proposta>
    {
        public Proposta GetDTO(DTO.Proposta Entidade)
        {
            Proposta proposta = Auxiliar.RetornaDadosEntidade<DTO.Proposta, Proposta>(Entidade);

            return proposta;
        }

        public List<Proposta> GetDTO(List<DTO.Proposta> Entidades)
        {
            List<Proposta> listProposta = new List<Proposta>();
            foreach (DTO.Proposta proposta in Entidades)
                listProposta.Add(GetDTO(proposta));

            return listProposta;
        }
    }
}
