using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalCliente.Web.Models
{
    public class DetalhesDebito : DTO.DetalhesDebito, IModel<DetalhesDebito, DTO.DetalhesDebito>
    {
        public DetalhesDebito GetDTO(DTO.DetalhesDebito Entidade)
        {
            DetalhesDebito detalhesDebito = Auxiliar.RetornaDadosEntidade<DTO.DetalhesDebito, DetalhesDebito>(Entidade);

            return detalhesDebito;
        }

        public List<DetalhesDebito> GetDTO(List<DTO.DetalhesDebito> Entidades)
        {
            List<DetalhesDebito> listDetalhesDebito = new List<DetalhesDebito>();
            foreach (DTO.DetalhesDebito detalhesDebito in Entidades)
                listDetalhesDebito.Add(GetDTO(detalhesDebito));

            return listDetalhesDebito;
        }
    }
}
