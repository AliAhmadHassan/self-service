using System;
using System.Collections.Generic;
namespace PortalCliente.DTO
{
    public abstract class Base : BaseRetorno
    {
        public sealed class AtributoBind : System.Attribute
        {
            public bool ChavePrimaria { get; set; }

            public string ProcedureInserir { get; set; }

            public string ProcedureAlterar { get; set; }

            public string ProcedureRemover { get; set; }

            public string ProcedureListarTodos { get; set; }

            public string ProcedureSelecionar { get; set; }

            public string ProcedureSelecionarLinkId { get; set; }

            public string ProcedureSelecionarClienteId { get; set; }

            public TipoConexao tipoConexao { get; set; }
        }

        public enum TipoConexao
        {
            Core,
            CobNet,
            CobNetBradesco,
            SRC
        }
    }
}
