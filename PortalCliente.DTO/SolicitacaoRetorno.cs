using System;
using System.Collections.Generic;

namespace PortalCliente.DTO
{
    public class SolicitacaoRetorno:Base
    {
        public SolicitacaoRetorno()
        {
            SolicitacaoRetornoId = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUSolicitacaoRetorno"
            , ProcedureInserir = "SPISolicitacaoRetorno"
            , ProcedureRemover = "SPDSolicitacaoRetorno"
            , ProcedureListarTodos = "SPSSolicitacaoRetorno"
            , ProcedureSelecionar = "SPSSolicitacaoRetornoBySolicitacaoRetornoId")]
		public int SolicitacaoRetornoId { get; set; }
		public int ClienteId { get; set; }
		public DateTime Data { get; set; }
		public int DDD { get; set; }
		public Int64 NumeroTelefone { get; set; }
		public int Horario { get; set; }
		public bool Retornado { get; set; }
        public string Link { get; set; }
    }
}
