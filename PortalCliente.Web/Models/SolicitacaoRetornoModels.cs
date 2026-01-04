using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalCliente.Web.Models
{
    public class SolicitacaoRetorno : DTO.SolicitacaoRetorno, IModel<SolicitacaoRetorno, DTO.SolicitacaoRetorno>
    {
        public string Nome { get; set; }
        public string CPF_CNPJ { get; set; }
        public SolicitacaoRetorno GetDTO(DTO.SolicitacaoRetorno Entidade)
        {
            SolicitacaoRetorno solicitacaoRetorno = Auxiliar.RetornaDadosEntidade<DTO.SolicitacaoRetorno, SolicitacaoRetorno>(Entidade);

            return solicitacaoRetorno;
        }

        public List<SolicitacaoRetorno> GetDTO(List<DTO.SolicitacaoRetorno> Entidades)
        {
            List<SolicitacaoRetorno> listSolicitacaoRetorno = new List<SolicitacaoRetorno>();
            foreach (DTO.SolicitacaoRetorno solicitacaoRetorno in Entidades)
                listSolicitacaoRetorno.Add(GetDTO(solicitacaoRetorno));

            return listSolicitacaoRetorno;
        }
    }
}
