using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalCliente.Web.Models
{
    public class Log : DTO.Log, IModel<Log, DTO.Log>
    {
        public string LogStatus { get; set; }
        public string Nome { get; set; }
        public string CPF_CNPJ { get; set; }
        public int id { get; set; }

        public Log GetDTO(DTO.Log Entidade)
        {
            Log log = Auxiliar.RetornaDadosEntidade<DTO.Log, Log>(Entidade);

            return log;
        }

        public List<Log> GetDTO(List<DTO.Log> Entidades)
        {
            List<Log> listLog = new List<Log>();
            foreach (DTO.Log log in Entidades)
                listLog.Add(GetDTO(log));

            return listLog;
        }
    }
}
