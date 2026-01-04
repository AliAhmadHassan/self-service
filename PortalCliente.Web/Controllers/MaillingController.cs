using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalCliente.Web.Controllers
{
    public class MaillingController : Controller
    {
        // GET: Mailling
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(int credId, DateTime dataDe, DateTime dataAte)
        {
            List<DTO.Mailling> lista = new List<DTO.Mailling>();
            BLL.Telefone telefoneServico = new BLL.Telefone();
            List<DTO.Credor> credores = new BLL.Credor().Select();

            var aux = new BLL.Mailling().Select(credId, dataDe, dataAte);

            string Caminho = string.Format("\\\\192.168.20.201\\CobNetArquivos\\PortalCliente\\{0}\\{1}\\{2}", DateTime.Today.Year.ToString("0000"), DateTime.Today.Month.ToString("00"), DateTime.Today.Day.ToString("00"));

            if (!Directory.Exists(Caminho))
                Directory.CreateDirectory(Caminho);


            string strCredor = credores.Where(c => c.CredId.Equals(credId)).FirstOrDefault().Nome;
            using (StreamWriter writer = new StreamWriter(string.Format("{0}\\{1}_PortalClientes{2}.SMS", Caminho, strCredor, DateTime.Now.ToString("ddmmss"))))
            {
                DTO.Mailling Mailling = new BLL.Mailling().Insert(strCredor + "_PortalClientes" + DateTime.Now.ToString("ddmmss") + ".SMS", credId);
                for (int i = 0; i < aux.Count; i++)
                {

                    var cliente = aux[i];
                    //DTO.Credor credor = credores.Where(c => c.CredId.Equals(cliente.CredId)).FirstOrDefault();

                    List<DTO.Telefone> telefones = null;

                    if (credId == 62 || credId == 146)
                        telefones = telefoneServico.SelectByTel_CPFCobNetBradesco(cliente.CpfCnpj);
                    else if(credId == 996 || credId == 997 || credId == 998 || credId == 999)
                        telefones = telefoneServico.SelectByTel_CPFSRC(Convert.ToInt64(cliente.CpfCnpj).ToString());
                    else
                        telefones = telefoneServico.SelectByTel_CPFCobNet(cliente.CpfCnpj);

                    for (int t = 0; (t < 2) && (t < telefones.Count); t++)
                    {
                        if (credId == 62 || credId == 146)
                            telefoneServico.AtualizaCobNetBradesco(telefones[t].TelId);
                        else if (credId == 996 || credId == 997 || credId == 998 || credId == 999)
                        {

                        }
                        else
                            telefoneServico.AtualizaCobNet(telefones[t].TelId);

                        DTO.Link Link = new DTO.Link();
                        
                        if (Link.LinkId == -1)
                            Link = new BLL.Link().Insert(cliente.ClienteId, telefones[t].TelId, Mailling.MailingId);

                        int myInt = Link.LinkId;
                        string myHex = myInt.ToString("X");  // Gives you hexadecimal
                        int myNewInt = Convert.ToInt32(myHex, 16);  // Back to int again.

                        string mensagem = string.Format(System.Configuration.ConfigurationManager.AppSettings["CaminhoSite"].Replace("|", "&"), myHex);
                        //string mensagem = string.Format(System.Configuration.ConfigurationManager.AppSettings["CaminhoSite"].Replace("|", "&"), cliente.ClienteId, telefones[t].TelId);
                        writer.WriteLine(string.Format("{0}{1};{2};{3}", telefones[t].DDD, telefones[t].Numero, cliente.Nome, mensagem));
                    }
                }
            }

            return View();
        }
    }
}