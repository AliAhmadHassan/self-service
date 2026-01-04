using System;
using System.Collections.Generic;
using System.Text;

namespace PortalCliente.DTO.ParqueGrafico
{
    public class Remessa
    {
        public Cliente cliente { get; set; }
        public Lote lote { get; set; }
        public Proposta proposta { get; set; }
        public DadosBoleto dadosBoleto { get; set; }
        public Link dadosLink { get; set; }
        public Mailling dadosMailling { get; set; }
        public List<Opcao> opcoes { get; set; }
        public List<DetalhesDebito> detalhesDebito { get; set; }
    }
}
