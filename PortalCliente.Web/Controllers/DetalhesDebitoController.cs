using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalCliente.Web.Controllers
{
    public class DetalhesDebitoController : Controller
    {
        // GET: DetalhesDebito
        public ActionResult Index()
        {
            Models.Cliente clienteModel = (Models.Cliente)Session["clienteModel"];
            Models.Link linkModel = (Models.Link)Session["linkModel"];

            int propostaId = new BLL.Proposta().SelectByClienteId(clienteModel.ClienteId).Max(c=>c.PropostaId);
            //List<DTO.Proposta> propostaId = new BLL.Proposta().SelectByLinkId(clienteModel.ClienteId);

            List<Models.DetalhesDebito> detalhes = new List<Models.DetalhesDebito>();

            //List<List<Models.DetalhesDebito>> ArrayDetalhes = new List<List<Models.DetalhesDebito>>();
            foreach (var item in new BLL.DetalhesDebito().SelectByPropostaId(propostaId))
            {
                detalhes.Add(item.GetModels<Models.DetalhesDebito>());
            }

            //for (int i = 0; i < propostaId.Count; i++)
            //{
            //    detalhes = new List<Models.DetalhesDebito>();

            //    foreach (var item in new BLL.DetalhesDebito().SelectByPropostaId(propostaId[i].PropostaId))
            //    {
            //        detalhes.Add(item.GetModels<Models.DetalhesDebito>());
            //    }

            //        ArrayDetalhes.Add(detalhes);

            //}
            return PartialView(detalhes);
            //return PartialView(ArrayDetalhes);
        }
    }
}