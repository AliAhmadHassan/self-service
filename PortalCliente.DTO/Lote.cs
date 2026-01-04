using System;
using System.Collections.Generic;

namespace PortalCliente.DTO
{
    public class Lote:Base
    {
        public Lote()
        {
            LoteId = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPULote"
            , ProcedureInserir = "SPILote"
            , ProcedureRemover = "SPDLote"
            , ProcedureListarTodos = "SPSLote"
            , ProcedureSelecionar = "SPSLoteByLoteId")]
		public int LoteId { get; set; }
		public int AgendaId { get; set; }
		public DateTime Data { get; set; }
		public DateTime Vencimento { get; set; }
		public bool Ativo { get; set; }
		public int CredId { get; set; }
    }
}
