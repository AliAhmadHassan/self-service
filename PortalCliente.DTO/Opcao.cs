using System;
using System.Collections.Generic;

namespace PortalCliente.DTO
{
    public class Opcao:Base
    {
        public Opcao()
        {
            OpcaoId = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUOpcao"
            , ProcedureInserir = "SPIOpcao"
            , ProcedureRemover = "SPDOpcao"
            , ProcedureListarTodos = "SPSOpcao"
            , ProcedureSelecionar = "SPSOpcaoByOpcaoId")]
		public int OpcaoId { get; set; }
		public int PropostaId { get; set; }
		public int Plano { get; set; }
		public decimal Entrada { get; set; }
		public decimal Parcela { get; set; }
        public string LinhaDigitavel { get; set; }
        public string CodigoBarras { get; set; }
    }
}
