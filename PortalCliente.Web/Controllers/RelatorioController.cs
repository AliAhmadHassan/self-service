using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortalCliente.Web.Models;
using System.IO;

namespace PortalCliente.Web.Controllers
{
    public class RelatorioController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            List<SelectListItem> listItem = new List<SelectListItem>();
            Relatorio rel = new Relatorio();

            var mailings = new BLL.Mailling().SelectAll();

            rel.id = 0;
            rel.value = "Selecione...";

            listItem.Add(new SelectListItem() { Value = rel.value, Text = rel.id.ToString() });

            for (int i = 0; i < mailings.Count; i++)
            {
                rel.id = mailings[i].MailingId;
                rel.value = mailings[i].MailingId + " - " + mailings[i].NomeArquivo;

                listItem.Add(new SelectListItem() { Value = rel.value, Text = rel.id.ToString() });
            }

            ViewBag.DropDownValues = new SelectList(listItem, "text", "Value");


            return View();
        }

        public ActionResult Filtrar(int MaillingId, int status)
        {
            List<DTO.RelatorioExterno> RelExt = new List<DTO.RelatorioExterno>();
            List<SelectListItem> listItem = new List<SelectListItem>();
            Relatorio rel = new Relatorio();

            if (status > 0)
            {
                RelExt = new BLL.RelatorioExterno().SelectRelatorio(MaillingId, status);

                string Link = string.Format("\\\\192.168.20.201\\cobnetarquivos\\PortalCliente\\Relatorio\\Relatorio_{0}.txt", DateTime.Now.ToString("ddMMyyyy_hhmmss"));

                using (StreamWriter Wr = new StreamWriter(Link))
                {
                    for (int i = 0; i < RelExt.Count; i++)
                    {
                        if (i == 0)
                            Wr.WriteLine("CPF/CNPJ;NOME;CREDOR;DDD;TELEFONE");//+Credor+DDD+Telefone

                        Wr.WriteLine(RelExt[i].CpfCnpj.PadLeft(15, '0') + ";" + RelExt[i].Nome + ";" + RelExt[i].CredId + ";" + RelExt[i].DDD + ";" + RelExt[i].Numero);//+Credor+DDD+Telefone
                    }
                }

                ViewBag.Link = Link;
            }

            #region DropDownList
            var mailings = new BLL.Mailling().SelectAll();

            rel.id = 0;
            rel.value = "Selecione...";

            listItem.Add(new SelectListItem() { Value = rel.value, Text = rel.id.ToString() });

            for (int i = 0; i < mailings.Count; i++)
            {
                rel.id = mailings[i].MailingId;
                rel.value = mailings[i].MailingId + " - " + mailings[i].NomeArquivo;

                listItem.Add(new SelectListItem() { Value = rel.value, Text = rel.id.ToString() });
            }

            ViewBag.DropDownValues = new SelectList(listItem, "text", "Value");
            #endregion

            List<Models.Relatorio> relatoriosModels = retornaLotesModels(MaillingId);

            if (relatoriosModels.Count > 0)
            {
                ViewBag.TotalClientes = relatoriosModels[relatoriosModels.Count - 1].TotalClientes;
                ViewBag.TotalAcessou = relatoriosModels[relatoriosModels.Count - 1].TotalAcessou;
                ViewBag.TotalLogou = relatoriosModels[relatoriosModels.Count - 1].TotalLogou;
                ViewBag.TotalRetorno = relatoriosModels[relatoriosModels.Count - 1].TotalRetorno;
                ViewBag.TotalGerouBoleto = relatoriosModels[relatoriosModels.Count - 1].TotalGerouBoleto;
            }
            ViewBag.MaillingId = MaillingId;

            return View("index", relatoriosModels);
        }

        private static List<Models.Relatorio> retornaLotesModels(int MaillingId)
        {
            List<Models.Relatorio> relatorioModels = new List<Models.Relatorio>();
            int Total = new BLL.Relatorio().Select(MaillingId).Count;
            int i = 0;
            int TotalClientes = 0;
            int TotalAcessou = 0;
            int TotalLogou = 0;
            int TotalRetorno = 0;
            int TotalGerouBoleto = 0;

            foreach (var item in new BLL.Relatorio().Select(MaillingId))
            {
                var relatorioModel = item.GetModels<Models.Relatorio>();

                relatorioModel.MailingId = item.MailingId;
                relatorioModel.Data = item.Data;
                relatorioModel.NomeArquivo = item.NomeArquivo;
                relatorioModel.QntClientes = item.QntClientes;
                relatorioModel.QntAcessou = item.QntAcessou;
                relatorioModel.QntLogou = item.QntLogou;
                relatorioModel.QntRetorno = item.QntRetorno;
                relatorioModel.QntGerouBoleto = item.QntGerouBoleto;
                relatorioModel.Vencimento = item.Vencimento;

                TotalClientes = TotalClientes + item.QntClientes;
                TotalAcessou = TotalAcessou + item.QntAcessou;
                TotalLogou = TotalLogou + item.QntLogou;
                TotalRetorno = TotalRetorno + item.QntRetorno;
                TotalGerouBoleto = TotalGerouBoleto + item.QntGerouBoleto;

                if (i == Total - 1)
                {
                    relatorioModel.TotalClientes = TotalClientes;
                    relatorioModel.TotalAcessou = TotalAcessou;
                    relatorioModel.TotalLogou = TotalLogou;
                    relatorioModel.TotalRetorno = TotalRetorno;
                    relatorioModel.TotalGerouBoleto = TotalGerouBoleto;
                }

                relatorioModels.Add(relatorioModel);
                i++;
            }

            return relatorioModels;
        }
    }
}