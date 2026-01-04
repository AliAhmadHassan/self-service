using System;
using System.Collections.Generic;

namespace PortalCliente.DTO
{
    public class Credor:Base
    {
        public Credor()
        {
            CredId = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUCredor"
            , ProcedureInserir = "SPICredor"
            , ProcedureRemover = "SPDCredor"
            , ProcedureListarTodos = "SPSCredor"
            , ProcedureSelecionar = "SPSCredorByCredId")]
		public int CredId { get; set; }
		public string Nome { get; set; }
		public string Logo { get; set; }
    }
}
