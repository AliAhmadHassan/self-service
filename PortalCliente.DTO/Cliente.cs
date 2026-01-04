using System;
using System.Collections.Generic;

namespace PortalCliente.DTO
{
    public class Cliente:Base
    {
        public Cliente()
        {
            ClienteId = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUCliente"
            , ProcedureInserir = "SPICliente"
            , ProcedureRemover = "SPDCliente"
            , ProcedureListarTodos = "SPSCliente"
            , ProcedureSelecionar = "SPSClienteByClienteId")]
		public int ClienteId { get; set; }
		public string Nome { get; set; }
		public string CpfCnpj { get; set; }
		public string Senha { get; set; }
		public bool Ativo { get; set; }
		public DateTime AcessouLink { get; set; }
		public DateTime ConfirmouSenha { get; set; }
		public DateTime SolicitouRetorno { get; set; }
		public DateTime FezAcordo { get; set; }
    }
}
