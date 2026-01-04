using System;
using System.Collections.Generic;
using System.Text;

namespace PortalCliente.DTO
{
    public class Relatorio : Base
    {
        public Relatorio()
        {
            MailingId = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureListarTodos = "SPSRelatorioMailling")]
        public int MailingId { get; set; }
        public string NomeArquivo { get; set; }
        public DateTime Data { get; set; }

        public int QntClientes { get; set; }
        public int QntAcessou { get; set; }
        public int QntLogou { get; set; }
        public int QntRetorno { get; set; }
        public int QntGerouBoleto { get; set; }
        public DateTime Vencimento { get; set; }
        
        public int TotalClientes { get; set; }
        public int TotalAcessou { get; set; }
        public int TotalLogou { get; set; }
        public int TotalRetorno { get; set; }
        public int TotalGerouBoleto { get; set; }
    }
}
