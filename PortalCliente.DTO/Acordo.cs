using System;
using System.Collections.Generic;

namespace PortalCliente.DTO
{
    public class Acordo:Base
    {
        public Acordo()
        {
            AcordoId = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUAcordo"
            , ProcedureInserir = "SPIAcordo"
            , ProcedureRemover = "SPDAcordo"
            , ProcedureListarTodos = "SPSAcordo"
            , ProcedureSelecionar = "SPSAcordoByAcordoId")]
		public int AcordoId { get; set; }
		public int OpcaoId { get; set; }
		public DateTime DtPagamento { get; set; }
		public string CaminhoArquivo { get; set; }
		public DateTime EnviadoD1 { get; set; }
		public DateTime EnviadoD0 { get; set; }
    }
}
