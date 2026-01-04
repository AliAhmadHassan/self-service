using System;
using System.Collections.Generic;

namespace PortalCliente.DTO
{
    public class DadosBoleto:Base
    {
        public DadosBoleto()
        {
            DadosBoletoId = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUDadosBoleto"
            , ProcedureInserir = "SPIDadosBoleto"
            , ProcedureRemover = "SPDDadosBoleto"
            , ProcedureListarTodos = "SPSDadosBoleto"
            , ProcedureSelecionar = "SPSDadosBoletoByDadosBoletoId")]
		public int DadosBoletoId { get; set; }
		public int Agencia { get; set; }
		public int AgenciaDig { get; set; }
		public int ContaCedente { get; set; }
		public int ContaCedenteDig { get; set; }
		public string Carteira { get; set; }
		public string Aceite { get; set; }
		public int Banco { get; set; }
		public int BancoDig { get; set; }
		public int Moeda { get; set; }
    }
}
