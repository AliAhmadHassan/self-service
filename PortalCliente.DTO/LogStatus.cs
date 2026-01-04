using System;
using System.Collections.Generic;

namespace PortalCliente.DTO
{
    public class LogStatus:Base
    {
        public LogStatus()
        {
            LogStatusId = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPULogStatus"
            , ProcedureInserir = "SPILogStatus"
            , ProcedureRemover = "SPDLogStatus"
            , ProcedureListarTodos = "SPSLogStatus"
            , ProcedureSelecionar = "SPSLogStatusByLogStatusId")]
		public int LogStatusId { get; set; }
		public string Descricao { get; set; }
    }
}
