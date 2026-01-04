using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalCliente.Web.Controllers
{
    public class HomeController : Controller
    {
        //http://localhost:14497/Home/Index?id=118&id2=103224079
        [HttpGet]
        //public ActionResult Index(int id, int id2)
        public ActionResult Index(string id)
        {

            //int myInt = int.Parse(id);
            //string myHex = myInt.ToString("X");  // Gives you hexadecimal
            int myNewInt = Convert.ToInt32(id, 16);
            DTO.Link Link = new BLL.Link().SelectById(myNewInt);

            Models.Cliente clienteModel = new BLL.Cliente().SelectById(Link.ClienteId).GetModels<Models.Cliente>();
            Models.Link LinkModel = new BLL.Link().SelectById(Link.LinkId).GetModels<Models.Link>();

            ViewBag.TelId = Link.TelId;
            LinkModel.AcessouLink = DateTime.Now;

            //new BLL.Cliente().Cadastro(clienteModel);
            new BLL.Link().Alterar(LinkModel);

            new BLL.Log().Cadastro(new DTO.Log()
            {
                ClienteId = clienteModel.ClienteId,
                Data = DateTime.Now,
                LogStatusId = 1
            });

            return View(clienteModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string id, int dig1, int dig2, int dig3, int dig4, int TelId)
        {
            DTO.Link Link = new BLL.Link().SelectById(Convert.ToInt32(id, 16));
            DTO.Mailling mailing = new BLL.Mailling().SelectByMailingId(Link.MailingId);

            Models.Cliente clienteModel = new BLL.Cliente().SelectById(Link.ClienteId).GetModels<Models.Cliente>();
            Models.Link linkModel = new BLL.Link().SelectById(Link.LinkId).GetModels<Models.Link>();
            if (clienteModel.CpfCnpj.Substring(clienteModel.CpfCnpj.Length - 4, 4).ToString() == dig1.ToString() + dig2.ToString() + dig3.ToString() + dig4.ToString())
            {
                DTO.Telefone telefone = null;

                if (mailing.CredId == 62 || mailing.CredId == 146)
                {
                    telefone = new BLL.Telefone().SelectByIdCobNetBradesco(TelId);
                    new BLL.Telefone().ValidaTelefoneCobNetBradesco(TelId);
                }
                else if (mailing.CredId == 996 || mailing.CredId == 997 || mailing.CredId == 998 || mailing.CredId == 999)
                {
                    telefone = new BLL.Telefone().SelectByIdSRC(TelId);
                    new BLL.Telefone().ValidaTelefoneSRC(TelId);
                }
                else
                {
                    telefone = new BLL.Telefone().SelectByIdCobNet(TelId);
                    new BLL.Telefone().ValidaTelefoneCobNet(TelId);
                }

                Session.Add("clienteModel", clienteModel);
                Session.Add("telefone", telefone);
                Session.Add("LinkModel", linkModel);

                linkModel.ConfirmouSenha = DateTime.Now;
                //new BLL.Cliente().Cadastro(clienteModel);

                linkModel.TelId = TelId;
                new BLL.Link().Alterar(linkModel);

                new BLL.Log().Cadastro(new DTO.Log()
                {
                    ClienteId = clienteModel.ClienteId,
                    Data = DateTime.Now,
                    LogStatusId = 5
                });

                new BLL.Telefone().Cadastro(new DTO.Telefone()
                {
                    ClienteId = clienteModel.ClienteId,
                    DDD = telefone.DDD,
                    Numero = telefone.Numero,
                    TelId = TelId
                });

                return RedirectToAction("Index", "Principal");
            }
            else
            {
                new BLL.Log().Cadastro(new DTO.Log()
                {
                    ClienteId = clienteModel.ClienteId,
                    Data = DateTime.Now,
                    LogStatusId = 2,
                    Descricao = string.Format(dig1.ToString() + dig2.ToString() + dig3.ToString() + dig4.ToString())
                });

                ViewBag.Erro = "Dados Invalidos";
            }

            return View(clienteModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}