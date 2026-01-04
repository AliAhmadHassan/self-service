using System;
using System.Collections.Generic;
using System.Text;

namespace PortalCliente.DTO
{
    public class Mailling : Base
    {
        public Mailling()
        {
            MailingId = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureInserir = "SPIMailing"
            , ProcedureListarTodos = "SPSMailling")]
        public int MailingId { get; set; }
        public string NomeArquivo { get; set; }
        public DateTime Data { get; set; }

        public int ClienteId { get; set; }
        public int CredId { get; set; }
        public string CpfCnpj { get; set; }
        public string Nome { get; set; }
    }
}
