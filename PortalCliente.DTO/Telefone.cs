using System;
using System.Collections.Generic;

namespace PortalCliente.DTO
{
    public class Telefone:Base
    {
        public Telefone()
        {
            TelefoneId = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUTelefone"
            , ProcedureInserir = "SPITelefone"
            , ProcedureRemover = "SPDTelefone"
            , ProcedureListarTodos = "SPSTelefone"
            , ProcedureSelecionar = "SPSTelefoneByTelefoneId")]
		public int TelefoneId { get; set; }
		public int ClienteId { get; set; }
		public int TelId { get; set; }
		public string Numero { get; set; }
		public string DDD { get; set; }
        public DateTime SMSEnviadoEm { get; set; }
        public DateTime ClienteAcessouEm { get; set; }
        public bool Padrao { get; set; }
        public int Qualidade { get; set; }
    }
}
