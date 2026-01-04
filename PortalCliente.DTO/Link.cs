using System;
using System.Collections.Generic;

namespace PortalCliente.DTO
{
    public class Link:Base
    {
        public Link()
        {
            LinkId = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureInserir = "SPILink"
            , ProcedureSelecionarLinkId = "SPSLinkByLinkId"
            , ProcedureSelecionarClienteId = "SPSLinkByClienteIdTelId")]
        public int LinkId { get; set; }
        public int ClienteId { get; set; }
        public int TelId { get; set; }
        public int MailingId { get; set; }
        public DateTime AcessouLink { get; set; }
        public DateTime ConfirmouSenha { get; set; }
        public DateTime SolicitouRetorno { get; set; }
        public DateTime FezAcordo { get; set; }
    }
}
