using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalCliente.Web.Models
{
    public class DadosBoleto : DTO.DadosBoleto, IModel<DadosBoleto, DTO.DadosBoleto>
    {
        public DadosBoleto GetDTO(DTO.DadosBoleto Entidade)
        {
            DadosBoleto dadosBoleto = Auxiliar.RetornaDadosEntidade<DTO.DadosBoleto, DadosBoleto>(Entidade);

            return dadosBoleto;
        }

        public List<DadosBoleto> GetDTO(List<DTO.DadosBoleto> Entidades)
        {
            List<DadosBoleto> listDadosBoleto = new List<DadosBoleto>();
            foreach (DTO.DadosBoleto dadosBoleto in Entidades)
                listDadosBoleto.Add(GetDTO(dadosBoleto));

            return listDadosBoleto;
        }
    }
}
