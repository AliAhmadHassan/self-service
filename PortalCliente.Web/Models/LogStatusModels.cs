using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalCliente.Web.Models
{
    public class LogStatus : DTO.LogStatus, IModel<LogStatus, DTO.LogStatus>
    {
        public LogStatus GetDTO(DTO.LogStatus Entidade)
        {
            LogStatus logStatus = Auxiliar.RetornaDadosEntidade<DTO.LogStatus, LogStatus>(Entidade);

            return logStatus;
        }

        public List<LogStatus> GetDTO(List<DTO.LogStatus> Entidades)
        {
            List<LogStatus> listLogStatus = new List<LogStatus>();
            foreach (DTO.LogStatus logStatus in Entidades)
                listLogStatus.Add(GetDTO(logStatus));

            return listLogStatus;
        }
    }
}
