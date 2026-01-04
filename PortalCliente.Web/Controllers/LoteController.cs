using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace PortalCliente.Web.Controllers
{
    public class LoteController : Controller
    {
        // GET: Lote
        public ActionResult Index()
        {
            List<Models.Lote> lotesModels = retornaLotesModels();
            return View(lotesModels);
        }

        private static List<Models.Lote> retornaLotesModels()
        {
            List<Models.Lote> lotesModels = new List<Models.Lote>();

            foreach (var item in new BLL.Lote().SelectByNotAtivo())
            {
                var loteModel = item.GetModels<Models.Lote>();

                loteModel.Credor = new BLL.Credor().SelectById(item.CredId).Nome;

                lotesModels.Add(loteModel);
            }

            return lotesModels;
        }

        [HttpPost]
        public ActionResult Index(int LoteId)
        {

            var lote = new BLL.Lote().SelectById(LoteId);
            lote.Ativo = true;
            new BLL.Lote().Cadastro(lote);

            List<Models.Lote> lotesModels = retornaLotesModels();
            return View(lotesModels.ToPagedList(1,10));
        }

    }
}