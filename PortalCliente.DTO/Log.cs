using System;
using System.Collections.Generic;

namespace PortalCliente.DTO
{
    public class Log:Base
    {
        public Log()
        {
            LogId = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPULog"
            , ProcedureInserir = "SPILog"
            , ProcedureRemover = "SPDLog"
            , ProcedureListarTodos = "SPSLog"
            , ProcedureSelecionar = "SPSLogByLogId")]
		public int LogId { get; set; }
		public int ClienteId { get; set; }
		public DateTime Data { get; set; }
		public int LogStatusId { get; set; }
		public string Descricao { get; set; }
    }
}
