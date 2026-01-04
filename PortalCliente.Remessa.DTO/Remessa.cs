using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.Remessa.DTO
{
    public class Remessa
    {
        public PortalCliente.DTO.Cliente cliente { get; set; }
        public PortalCliente.DTO.Lote lote { get; set; }
        public PortalCliente.DTO.Proposta proposta { get; set; }
        public PortalCliente.DTO.DadosBoleto dadosBoleto { get; set; }
        public List<PortalCliente.DTO.Opcao> opcoes { get; set; }
        public List<PortalCliente.DTO.DetalhesDebito> detalhesDebito { get; set; }
    }
}
