using System;
using System.Collections.Generic;

namespace PortalCliente.DTO
{
    public class Proposta:Base
    {
        public Proposta()
        {
            PropostaId = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUProposta"
            , ProcedureInserir = "SPIProposta"
            , ProcedureRemover = "SPDProposta"
            , ProcedureListarTodos = "SPSProposta"
            , ProcedureSelecionar = "SPSPropostaByPropostaId")]
		public int PropostaId { get; set; }
		public int ClienteId { get; set; }
		public int LoteId { get; set; }
		public int DadosBoletoId { get; set; }
		public string NrDocumento { get; set; }
		public Int64 NossoNumero { get; set; }
		public string NossoNumeroDig { get; set; }
    }
}
