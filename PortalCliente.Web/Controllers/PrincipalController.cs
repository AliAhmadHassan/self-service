using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using PortalCliente.DTO;
using System.Drawing;
using TheArtOfDev.HtmlRenderer.Core;
using TheArtOfDev.HtmlRenderer.Core.Entities;
using TheArtOfDev.HtmlRenderer.Core.Utils;
using TheArtOfDev.HtmlRenderer.WinForms.Adapters;
using TheArtOfDev.HtmlRenderer.WinForms.Utilities;
using Winnovative.WnvHtmlConvert;

namespace PortalCliente.Web.Controllers
{
    public class PrincipalController : Controller
    {
        // GET: Principal
        [HttpGet]
        public ActionResult Index()
        {
            Models.Cliente clienteModel = (Models.Cliente)Session["clienteModel"];
            Models.Link linkModel = (Models.Link)Session["linkModel"];

            return View(clienteModel);
        }

        [HttpGet]
        public ActionResult Menu(int MenuId)
        {
            Models.Cliente clienteModel = (Models.Cliente)Session["clienteModel"];
            Models.Link linkModel = (Models.Link)Session["linkModel"];

            return View("Index");
        }

        [HttpPost]
        public ActionResult Index(int opcaoId, int propostaId, string dtPgto, int opcaoArquivo, string DDD, string NumeroTelefone, string hora)
        {
            Models.Cliente clienteModel = new BLL.Cliente().SelectById(((Models.Cliente)Session["clienteModel"]).ClienteId).GetModels<Models.Cliente>();
            Models.Link linkModel = new BLL.Link().SelectById(((Models.Link)Session["linkModel"]).LinkId).GetModels<Models.Link>();
            if (opcaoId != -1)
            {
                DTO.Proposta proposta = new BLL.Proposta().SelectById(propostaId);
                DTO.Lote lote = new BLL.Lote().SelectById(proposta.LoteId);
                List<DTO.OpcaoLinhaDigitavel> opcaoLinhaDigitavel = new List<DTO.OpcaoLinhaDigitavel>();

                if (lote.CredId == 147 || lote.CredId == 996 || lote.CredId == 997 || lote.CredId == 998 || lote.CredId == 999)
                    opcaoLinhaDigitavel = new BLL.OpcaoLinhaDigitavel().SelectById(opcaoId);

                DateTime dataPagamento;

                if (!DateTime.TryParse(dtPgto, out dataPagamento))
                {
                    ViewBag.ErroData = "Data Invalida!";
                    return View();
                }
                else
                {
                    if (dataPagamento < DateTime.Today)
                    {
                        ViewBag.ErroData = "Data deve ser superior a hoje!";
                        return View();
                    }
                    else if (dataPagamento > DateTime.Today.AddDays(5))
                    {
                        if (dataPagamento > lote.Vencimento)
                            ViewBag.ErroData = "Data deve ser inferior ou igual a " + lote.Vencimento.ToString("dd/MM/yyyy") + "!";
                        else
                            ViewBag.ErroData = "Data deve ser inferior a " + DateTime.Today.AddDays(5).ToString("dd/MM/yyyy") + "!";

                        return View();
                    }
                    else if (dataPagamento > lote.Vencimento)
                    {
                        ViewBag.ErroData = "Data deve ser inferior ou igual a " + lote.Vencimento.ToString("dd/MM/yyyy") + "!";
                        return View();
                    }
                }

                DTO.Opcao opcao = new BLL.Opcao().SelectById(opcaoId);
                DTO.DadosBoleto dadosBoleto = new BLL.DadosBoleto().SelectById(proposta.DadosBoletoId);

                //Image image = TheArtOfDev.HtmlRenderer.WinForms.HtmlRender.RenderToImage(boleto);
                //image.Save(@"C:\Temp\Test.jpg");

                string boleto = "";
                if (opcaoLinhaDigitavel.Count > 0)
                    boleto = MontaBoleto(clienteModel, lote, opcao, dadosBoleto, proposta, dataPagamento, opcaoLinhaDigitavel[0]);
                else
                    boleto = MontaBoleto(clienteModel, lote, opcao, dadosBoleto, proposta, dataPagamento, null);

                string fileName = Guid.NewGuid().ToString();
                string diretorio = string.Format("{0}{1}\\{2}\\{3}", Server.MapPath("~/Images/"), DateTime.Today.Year.ToString("0000"), DateTime.Today.Month.ToString("00"), DateTime.Today.Day.ToString("00"));

                if (!Directory.Exists(diretorio))
                    Directory.CreateDirectory(diretorio);

                if (opcaoArquivo == 2)
                {
                    WebsitesScreenshot.WebsitesScreenshot _Obj = new WebsitesScreenshot.WebsitesScreenshot();
                    WebsitesScreenshot.WebsitesScreenshot.Result _Result;
                    _Result = _Obj.CaptureHTML(boleto);
                    if (_Result == WebsitesScreenshot.WebsitesScreenshot.Result.Captured)
                    {
                        _Obj.ImageWidth = 800;
                        _Obj.ImageHeight = 1120;
                        _Obj.ImageFormat = WebsitesScreenshot.WebsitesScreenshot.ImageFormats.JPG;

                        var path = Path.Combine(diretorio, fileName + ".jpg");
                        _Obj.SaveImage(path);

                        ViewBag.path = VirtualPathUtility.ToAbsolute(path.Replace(Server.MapPath("~"), "~/"));
                        ViewBag.extensao = "JPG";
                    }
                    _Obj.Dispose();
                }
                else if (opcaoArquivo == 1)
                {
                    PdfConverter pdfConverter = null;
                    pdfConverter = new PdfConverter();
                    pdfConverter.LicenseKey = "bEdeTF1MVF5VTFtCXExfXUJdXkJVVVVV";
                    pdfConverter.PageWidth = 815;
                    pdfConverter.PdfDocumentOptions.GenerateSelectablePdf = true;
                    pdfConverter.PdfDocumentOptions.PdfPageSize = PdfPageSize.A4;
                    pdfConverter.PdfDocumentOptions.PdfCompressionLevel = PdfCompressionLevel.Normal;
                    pdfConverter.PdfDocumentOptions.PdfPageOrientation = PDFPageOrientation.Portrait;
                    pdfConverter.PdfStandardSubset = PdfStandardSubset.Full;
                    pdfConverter.PdfDocumentOptions.LeftMargin = 6;
                    pdfConverter.PdfDocumentOptions.RightMargin = 6;
                    pdfConverter.PdfDocumentOptions.TopMargin = 4;
                    pdfConverter.PdfDocumentOptions.BottomMargin = 4;
                    pdfConverter.PdfDocumentOptions.FitWidth = true;
                    pdfConverter.PdfDocumentOptions.AutoSizePdfPage = true;
                    var path = Path.Combine(diretorio, fileName + ".pdf");
                    pdfConverter.SavePdfFromHtmlStringToFile(boleto, path);

                    ViewBag.path = VirtualPathUtility.ToAbsolute(path.Replace(Server.MapPath("~"), "~/"));

                    ViewBag.extensao = "PDF";
                }
                ViewBag.Nome = clienteModel.Nome;
                ViewBag.Vencimento = dataPagamento;
                ViewBag.Entrada = opcao.Entrada;
                ViewBag.Plano = opcao.Plano;
                ViewBag.Parcela = opcao.Parcela;

                linkModel.FezAcordo = DateTime.Now;
                //new BLL.Cliente().Cadastro(clienteModel);
                new BLL.Link().Alterar(linkModel);
                new BLL.Log().Cadastro(new DTO.Log()
                {
                    ClienteId = clienteModel.ClienteId,
                    Data = DateTime.Now,
                    LogStatusId = 7,
                    Descricao = opcao.Plano == 1 ? string.Format("À vista no valor de R$ {0}, vencimento {1}", opcao.Entrada.ToString("C2"), dataPagamento.ToString("dd/MM/yyyy")) : string.Format("Entrada {0} mais R$ {1} de R$ {2}, vencimento {3}", opcao.Entrada.ToString("C2"), opcao.Plano, opcao.Parcela.ToString("C2"), dataPagamento.ToString("dd/MM/yyyy"))
                });

                new BLL.Acordo().Cadastro(new DTO.Acordo()
                {
                    CaminhoArquivo = ViewBag.path,
                    DtPagamento = dataPagamento,
                    OpcaoId = opcao.OpcaoId
                });

                return View("AcordoRealizado");
            }
            else
            {
                DTO.SolicitacaoRetorno solicitaRetorno = new SolicitacaoRetorno();
                solicitaRetorno.ClienteId = clienteModel.ClienteId;
                solicitaRetorno.Data = DateTime.Now;
                solicitaRetorno.DDD = Convert.ToInt32(DDD);
                solicitaRetorno.NumeroTelefone = Convert.ToInt32(NumeroTelefone);
                solicitaRetorno.Horario = Convert.ToInt32(hora);
                solicitaRetorno.Retornado = false;

                new BLL.SolicitacaoRetorno().Cadastro(solicitaRetorno);

                linkModel.SolicitouRetorno = DateTime.Now;
                //new BLL.Cliente().Cadastro(clienteModel);
                new BLL.Link().Alterar(linkModel);
                new BLL.Log().Cadastro(new DTO.Log()
                {
                    ClienteId = clienteModel.ClienteId,
                    Data = DateTime.Now,
                    LogStatusId = 6
                });

                ViewBag.Nome = clienteModel.Nome;
                ViewBag.DDD = DDD;
                ViewBag.NumeroTelefone = NumeroTelefone;
                ViewBag.Hora = hora;

                return View("SolicitacaoRealizada");
            }
        }

        private string MontaBoleto(Models.Cliente clienteModel, DTO.Lote lote, DTO.Opcao opcao, DTO.DadosBoleto dadosBoleto, DTO.Proposta proposta, DateTime dataPagamento, DTO.OpcaoLinhaDigitavel opcaoLinhaDigitavel)
        {
            List<DTO.DetalhesDebito> detalhesDebito = new BLL.DetalhesDebito().SelectByPropostaId(proposta.PropostaId);
            StringBuilder SBBoleto = new StringBuilder();
            var dir = Server.MapPath("~/Content/Boletos/");

            string arquivo = string.Empty;

            if(dadosBoleto.DadosBoletoId == 43)
            {
                arquivo = string.Format(@"{0}/{1}.html", dir, 997);

            }
            else
            {
                arquivo = string.Format(@"{0}/{1}.html", dir, lote.CredId);
            }


            using (StreamReader reader = new StreamReader(arquivo))
            {
                string linha = string.Empty;
                if ((linha = reader.ReadToEnd()) != null)
                {
                    string linhaBoleto = linha;

                    if (opcao.Plano > 1)
                    {
                        if (linhaBoleto.Contains("@TxtValor@")) linhaBoleto = linhaBoleto.Replace("@TxtValor@", "Valor Entrada:");
                        if (linhaBoleto.Contains("@TxtParcelado@")) linhaBoleto = linhaBoleto.Replace("@TxtParcelado@", " + " + (opcao.Plano - 1) + " parcelas de " + opcao.Parcela.ToString("C2"));
                    }
                    else
                    {
                        if (linhaBoleto.Contains("@TxtValor@")) linhaBoleto = linhaBoleto.Replace("@TxtValor@", "Valor A Vista:");
                        if (linhaBoleto.Contains("@TxtParcelado@")) linhaBoleto = linhaBoleto.Replace("@TxtParcelado@", "");
                    }

                    if (linhaBoleto.Contains("@Cnpj@")) linhaBoleto = linhaBoleto.Replace("@Cnpj@", clienteModel.CpfCnpj.Substring(0, 1) + "**.***.***-" + clienteModel.CpfCnpj.Substring(clienteModel.CpfCnpj.Length - 2, 2));
                    if (linhaBoleto.Contains("@Nome@")) linhaBoleto = linhaBoleto.Replace("@Nome@", clienteModel.Nome);
                    if (linhaBoleto.Contains("@Contrato@")) linhaBoleto = linhaBoleto.Replace("@Contrato@", RetornaContrato(detalhesDebito));
                    if (linhaBoleto.Contains("@ParcelaPlano@")) linhaBoleto = linhaBoleto.Replace("@ParcelaPlano@", "1/" + opcao.Plano);
                    if (linhaBoleto.Contains("@Vencimento@")) linhaBoleto = linhaBoleto.Replace("@Vencimento@", dataPagamento.ToString("dd/MM/yyyy"));
                    if (linhaBoleto.Contains("@ValorParcela@")) linhaBoleto = linhaBoleto.Replace("@ValorParcela@", opcao.Entrada.ToString("C2"));
                    if (linhaBoleto.Contains("@DtProcessamento@")) linhaBoleto = linhaBoleto.Replace("@DtProcessamento@", DateTime.Today.ToString("dd/MM/yyyy"));
                    if (linhaBoleto.Contains("@DtDocumento@")) linhaBoleto = linhaBoleto.Replace("@DtDocumento@", DateTime.Today.ToString("dd/MM/yyyy"));
                    if (linhaBoleto.Contains("@NDocumento@")) linhaBoleto = linhaBoleto.Replace("@NDocumento@", proposta.NrDocumento);

                    if (linhaBoleto.Contains("@Agencia@")) linhaBoleto = linhaBoleto.Replace("@Agencia@", string.Format("{0}", dadosBoleto.Agencia));
                    if (linhaBoleto.Contains("@ContaCedente@")) linhaBoleto = linhaBoleto.Replace("@ContaCedente@", string.Format("{0}", dadosBoleto.ContaCedente));
                    if (linhaBoleto.Contains("@AgenciaConta@")) linhaBoleto = linhaBoleto.Replace("@AgenciaConta@", string.Format("{0}-{1}/{2}-{3}", dadosBoleto.Agencia, dadosBoleto.AgenciaDig, dadosBoleto.ContaCedente, dadosBoleto.ContaCedenteDig));

                    if (linhaBoleto.Contains("@Cedente@")) linhaBoleto = linhaBoleto.Replace("@Cedente@", string.Format("{0}", dadosBoleto.ContaCedente));
                    if (linhaBoleto.Contains("@NossoNumero@")) linhaBoleto = linhaBoleto.Replace("@NossoNumero@", string.Format("{0}/{1}-{2}", dadosBoleto.Carteira, proposta.NossoNumero, proposta.NossoNumeroDig));
                    if (linhaBoleto.Contains("@SoNossoNumero@")) linhaBoleto = linhaBoleto.Replace("@SoNossoNumero@", string.Format("{0}", proposta.NossoNumero));
                    string LinhaDigitavel = "";
                    string CodigoBarras = "";

                    if (lote.CredId == 147 || lote.CredId == 996 || lote.CredId == 997 || lote.CredId == 998 || lote.CredId == 999)
                    {
                        if (opcaoLinhaDigitavel != null && opcaoLinhaDigitavel.LinhaDigitavel != "")
                        {
                            LinhaDigitavel = MascaraLinhaDigitavel(opcaoLinhaDigitavel.LinhaDigitavel);
                            CodigoBarras = Cs_Boleto.GeraBarras(opcaoLinhaDigitavel.CodigoBarras);
                        }
                        else
                            return "";
                    }
                    else
                    {
                        LinhaDigitavel = Cs_Boleto.GeraDadosBoleto("Linha Digitavel", dadosBoleto.Banco.ToString("000"), dadosBoleto.Moeda.ToString(), dataPagamento.ToString("dd/MM/yyyy"), opcao.Entrada.ToString(), dadosBoleto.Agencia.ToString(), dadosBoleto.Carteira, proposta.NossoNumero.ToString(), dadosBoleto.ContaCedente.ToString());
                        CodigoBarras = Cs_Boleto.GeraDadosBoleto("CODIGO BARRA", dadosBoleto.Banco.ToString("000"), dadosBoleto.Moeda.ToString(), dataPagamento.ToString("dd/MM/yyyy"), opcao.Entrada.ToString(), dadosBoleto.Agencia.ToString(), dadosBoleto.Carteira, proposta.NossoNumero.ToString(), dadosBoleto.ContaCedente.ToString());
                    }

                    if (linhaBoleto.Contains("@LinhaDigitavel@")) linhaBoleto = linhaBoleto.Replace("@LinhaDigitavel@", LinhaDigitavel);
                    if (linhaBoleto.Contains("@CodigoBarras@")) linhaBoleto = linhaBoleto.Replace("@CodigoBarras@", CodigoBarras);

                    if (linhaBoleto.Contains("@ValorSaldo@")) linhaBoleto = linhaBoleto.Replace("@ValorSaldo@", detalhesDebito[0].Valor.ToString("C2"));

                    //Losango CDC
                    if (linhaBoleto.Contains("@NossoNumeroCDC@")) linhaBoleto = linhaBoleto.Replace("@NossoNumeroCDC@", string.Format("{0}/{1}", dadosBoleto.Carteira, proposta.NossoNumero));
                    if (linhaBoleto.Contains("@AgenciaContaCDC@")) linhaBoleto = linhaBoleto.Replace("@AgenciaContaCDC@", string.Format("{0}-8/{1}-{2}", dadosBoleto.Agencia, dadosBoleto.ContaCedente, dadosBoleto.ContaCedenteDig));

                    //Losango Cartões
                    if (linhaBoleto.Contains("@AgenciaContaCard@")) linhaBoleto = linhaBoleto.Replace("@AgenciaContaCard@", string.Format("{0}/{1}", dadosBoleto.Agencia, dadosBoleto.ContaCedente));
                    if (linhaBoleto.Contains("@NossoNumeroCard@")) linhaBoleto = linhaBoleto.Replace("@NossoNumeroCard@", string.Format("{0}/{1}", dadosBoleto.Carteira, proposta.NossoNumero));

                    //Alfa
                    if (linhaBoleto.Contains("@NossoNumeroAlfa@")) linhaBoleto = linhaBoleto.Replace("@NossoNumeroAlfa@", string.Format("{0}", proposta.NossoNumero));
                    if (linhaBoleto.Contains("@AgenciaContaAlfa@")) linhaBoleto = linhaBoleto.Replace("@AgenciaContaAlfa@", string.Format("{0}-8/{1}-8", dadosBoleto.Agencia, dadosBoleto.ContaCedente));

                    SBBoleto.Append(linhaBoleto);
                }
            }

            return SBBoleto.ToString();
        }

        private string MascaraLinhaDigitavel(string linhaDigitavel)
        {
            //03399167777805102003646377001022100000000000000
            string aux = linhaDigitavel.Replace(" ", "").Replace(".", "").Trim();

            return string.Format("{0}.{1} {2}.{3} {4}.{5} {6} {7}", 
                aux.Substring(0, 5),
                aux.Substring(5, 5),
                aux.Substring(10, 5),
                aux.Substring(15, 6),
                aux.Substring(21, 5),
                aux.Substring(26, 6),
                aux.Substring(32, 1),
                aux.Substring(33, 14));
        }

        private string RetornaContrato(List<DetalhesDebito> detalhesDebito)
        {
            StringBuilder SBRetorno = new StringBuilder();
            for (int i = 0; i < detalhesDebito.Count; i++)
            {
                DetalhesDebito Item = detalhesDebito[i];

                SBRetorno.Append(Item.Contrato);

                if (i < detalhesDebito.Count - 1)
                    SBRetorno.Append(", ");
            }
            return SBRetorno.ToString();
        }
    }
}