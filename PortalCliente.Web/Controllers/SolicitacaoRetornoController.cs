using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalCliente.Web.Controllers
{
    public class SolicitacaoRetornoController : Controller
    {
        // GET: SolicitacaoRetorno
        public ActionResult Index()
        {
            List<Models.SolicitacaoRetorno> solitacoesRetornoModels = retornaSolicitacoes();

            return View(solitacoesRetornoModels);
        }

        private static List<Models.SolicitacaoRetorno> retornaSolicitacoes()
        {
            List<Models.SolicitacaoRetorno> solitacoesRetornoModels = new List<Models.SolicitacaoRetorno>();

            foreach (var item in new BLL.SolicitacaoRetorno().SelectByNotRetorned())
            {
                var solicitacaoModel = item.GetModels<Models.SolicitacaoRetorno>();
                DTO.Cliente cliente = new BLL.Cliente().SelectById(solicitacaoModel.ClienteId);
                solicitacaoModel.Nome = cliente.Nome;
                solicitacaoModel.CPF_CNPJ = cliente.CpfCnpj;
                solicitacaoModel.Link = "http://sql/Logados/Acionamento/Atendimento/Detalhes_do_Devedor.aspx?CPFCNPJ=" + cliente.CpfCnpj;
                solitacoesRetornoModels.Add(solicitacaoModel);
            }

            return solitacoesRetornoModels;
        }

        [HttpPost]
        public ActionResult Index(int Id)
        {
            var solicitacao = new BLL.SolicitacaoRetorno().SelectById(Id);
            solicitacao.Retornado = true;
            new BLL.SolicitacaoRetorno().Cadastro(solicitacao);
            List<Models.SolicitacaoRetorno> solitacoesRetornoModels = retornaSolicitacoes();
            return View(solitacoesRetornoModels);
        }
    }
}