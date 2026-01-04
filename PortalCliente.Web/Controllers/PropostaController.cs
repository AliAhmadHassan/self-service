using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalCliente.Web.Controllers
{
    public class PropostaController : Controller
    {
        // GET: Proposta
        public ActionResult Index()
        {
            Models.Cliente clienteModel = (Models.Cliente)Session["clienteModel"];
            Models.Link linkModel = (Models.Link)Session["linkModel"];

            int propostaId = new BLL.Proposta().SelectByClienteId(clienteModel.ClienteId).Max(c => c.PropostaId);

            List<Models.Opcao> opcoes = new List<Models.Opcao>();

            foreach (var item in new BLL.Opcao().SelectByPropostaId(propostaId))
            {
                opcoes.Add(item.GetModels<Models.Opcao>());
            }

            DTO.Telefone telefone = (DTO.Telefone)Session["telefone"];

            ViewBag.DDD = telefone.DDD;
            ViewBag.NumeroTelefone = telefone.Numero;

            return PartialView(opcoes);
        }
    }
}