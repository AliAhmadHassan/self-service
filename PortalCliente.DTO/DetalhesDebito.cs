using System;
using System.Collections.Generic;

namespace PortalCliente.DTO
{
    public class DetalhesDebito:Base
    {
        public DetalhesDebito()
        {
            DetalhesDebitoId = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUDetalhesDebito"
            , ProcedureInserir = "SPIDetalhesDebito"
            , ProcedureRemover = "SPDDetalhesDebito"
            , ProcedureListarTodos = "SPSDetalhesDebito"
            , ProcedureSelecionar = "SPSDetalhesDebitoByDetalhesDebitoId")]
		public int DetalhesDebitoId { get; set; }
		public int PropostaId { get; set; }
		public string Contrato { get; set; }
		public string Produto { get; set; }
		public DateTime Vencimento { get; set; }
		public decimal Valor { get; set; }
    }
}
