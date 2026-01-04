using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;
using System.Xml.Serialization;

namespace PortalCliente.ImportaParqueGrafico
{
    public class Program
    {
        static Timer time = new Timer();
        public static void Main(string[] args)
        {
            time.Interval = 20000;
            time.Elapsed += Time_Tick;
            time.Enabled = true;
            time.Start();

            while (true)
            {
                System.Threading.Thread.Sleep(10000);
            }
        }

        public static void Time_Tick(object sender, EventArgs e)
        {
            time.Stop();

            string[] arquivos = Directory.GetFiles(@"\\192.168.20.201\cobnetarquivos\PortalCliente\Remessa");

            //string[] arquivos = Directory.GetFiles(@"\\192.168.20.201\cobnetarquivos\PortalCliente\Carregado\2016\06\15");

            BLL.Cliente clienteService = new BLL.Cliente();
            BLL.Lote loteService = new BLL.Lote();
            BLL.Proposta propostaService = new BLL.Proposta();
            BLL.DadosBoleto dadosBoletoService = new BLL.DadosBoleto();
            BLL.Opcao opcaoService = new BLL.Opcao();
            BLL.OpcaoLinhaDigitavel OpcaoLinhaDigitavelService = new BLL.OpcaoLinhaDigitavel();
            BLL.DetalhesDebito detalhesDebitoService = new BLL.DetalhesDebito();
            BLL.Mailling DadosMailling = new BLL.Mailling();
            BLL.Link DadosLink = new BLL.Link();

            string Carregados = string.Format(@"\\192.168.20.201\cobnetarquivos\PortalCliente\Carregado\{0}\{1}\{2}", DateTime.Today.Year.ToString("0000"), DateTime.Today.Month.ToString("00"), DateTime.Today.Day.ToString("00"));

            for (int i = 0; i < arquivos.Length; i++)
            {
                DTO.ParqueGrafico.Remessa remessa = (DTO.ParqueGrafico.Remessa)new XmlSerializer(typeof(DTO.ParqueGrafico.Remessa)).Deserialize(new StringReader(File.ReadAllText(arquivos[i])));

                #region Cliente
                DTO.Cliente cliente = clienteService.SelectByCpfCnpj(remessa.cliente.CpfCnpj);
                if (cliente.ClienteId == 0 - 1)
                {
                    cliente = new DTO.Cliente();
                    cliente.Nome = remessa.cliente.Nome;
                    cliente.CpfCnpj = remessa.cliente.CpfCnpj;
                    cliente.Senha = remessa.cliente.CpfCnpj.Substring(remessa.cliente.CpfCnpj.Length - 4);
                    clienteService.Cadastro(cliente);
                }
                #endregion

                #region Lote
                DTO.Lote lote = loteService.SelectByAgendaId(remessa.lote.AgendaId);
                if (lote.LoteId == -1)
                {
                    lote = new DTO.Lote();
                    lote.AgendaId = remessa.lote.AgendaId;
                    lote.CredId = remessa.lote.CredId;
                    lote.Data = DateTime.Now;
                    lote.Vencimento = remessa.lote.Vencimento;
                    lote.Ativo = false;
                    loteService.Cadastro(lote);
                }
                #endregion

                #region DadosBoleto
                List<DTO.DadosBoleto> dadosBoletos = dadosBoletoService.Select();

                DTO.DadosBoleto dadosBoleto = dadosBoletos.Where(c => c.Banco.Equals(remessa.dadosBoleto.Banco) &&
                c.Agencia.Equals(remessa.dadosBoleto.Agencia) &&
                c.ContaCedente.Equals(remessa.dadosBoleto.ContaCedente)).FirstOrDefault();

                if (dadosBoleto == null || dadosBoleto.DadosBoletoId == 0 - 1)
                {
                    dadosBoleto = new DTO.DadosBoleto();
                    dadosBoleto.Aceite = remessa.dadosBoleto.Aceite;
                    dadosBoleto.Agencia = remessa.dadosBoleto.Agencia;
                    dadosBoleto.AgenciaDig = remessa.dadosBoleto.AgenciaDig;
                    dadosBoleto.Banco = remessa.dadosBoleto.Banco;
                    dadosBoleto.BancoDig = remessa.dadosBoleto.BancoDig;
                    dadosBoleto.Carteira = remessa.dadosBoleto.Carteira;
                    dadosBoleto.ContaCedente = remessa.dadosBoleto.ContaCedente;
                    dadosBoleto.ContaCedenteDig = remessa.dadosBoleto.ContaCedenteDig;
                    dadosBoleto.Moeda = remessa.dadosBoleto.Moeda;
                    dadosBoletoService.Cadastro(dadosBoleto);
                }
                #endregion

                #region Proposta
                DTO.Proposta proposta = new DTO.Proposta();
                proposta.ClienteId = cliente.ClienteId;
                proposta.DadosBoletoId = dadosBoleto.DadosBoletoId;
                proposta.LoteId = lote.LoteId;
                proposta.NossoNumero = remessa.proposta.NossoNumero;
                proposta.NossoNumeroDig = remessa.proposta.NossoNumeroDig;
                proposta.NrDocumento = remessa.proposta.NrDocumento;
                propostaService.Cadastro(proposta);
                #endregion

                #region DetalhesDebito
                foreach (var item in remessa.detalhesDebito)
                {
                    List<DTO.DetalhesDebito> detalhesDebitos = detalhesDebitoService.SelectByPropostaId(proposta.PropostaId);

                    if (detalhesDebitos.Count(c => c.Contrato.Equals(item.Contrato)) == 0)
                    {
                        DTO.DetalhesDebito detalhesDebito = new DTO.DetalhesDebito();
                        detalhesDebito.Contrato = item.Contrato;
                        detalhesDebito.Produto = item.Produto;
                        detalhesDebito.Valor = item.Valor;
                        detalhesDebito.Vencimento = item.Vencimento;
                        detalhesDebito.PropostaId = proposta.PropostaId;
                        detalhesDebitoService.Cadastro(detalhesDebito);
                    }
                }
                #endregion

                #region Opcoes
                foreach (var item in remessa.opcoes)
                {
                    List<DTO.Opcao> opcoes = opcaoService.SelectByPropostaId(proposta.PropostaId);

                    if (opcoes.Count(c => c.Plano.Equals(item.Plano)) == 0)
                    {
                        DTO.Opcao opcao = new DTO.Opcao();
                        DTO.OpcaoLinhaDigitavel OpcaoLinhaDigitavel = new DTO.OpcaoLinhaDigitavel();
                        opcao.PropostaId = proposta.PropostaId;
                        opcao.Parcela = item.Parcela;
                        opcao.Plano = item.Plano;
                        opcao.Entrada = item.Entrada;

                        OpcaoLinhaDigitavel.OpcaoId = opcaoService.Inserir(opcao).OpcaoId;
                        OpcaoLinhaDigitavel.LinhaDigitavel = item.LinhaDigitavel;
                        OpcaoLinhaDigitavel.CodigoBarras = item.CodigoBarras;

                        if (lote.CredId == 147 || lote.CredId == 996 || lote.CredId == 997 || lote.CredId == 998 || lote.CredId == 999)
                            if (OpcaoLinhaDigitavel.LinhaDigitavel != null)
                                OpcaoLinhaDigitavelService.Cadastro(OpcaoLinhaDigitavel);
                    }
                }
                #endregion

                #region Move Arquivo
                if (!Directory.Exists(Carregados))
                    Directory.CreateDirectory(Carregados);

                File.Move(arquivos[i], Carregados + arquivos[i].Substring(arquivos[0].LastIndexOf("\\")));
                #endregion

                Console.WriteLine(string.Format("{0} - Processado {1} de {2} => {3} %", DateTime.Now, i, arquivos.Length, Math.Round(((decimal)i) / arquivos.Length, 4) * 100));
            }
            time.Start();
        }
    }
}
