using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalCliente.Web.Models
{
    public class Relatorio : DTO.Relatorio, IModel<Relatorio, DTO.Relatorio>
    {
        public int id { get; set; }
        public string value { get; set; }

        public Relatorio GetDTO(DTO.Relatorio Entidade)
        {
            Relatorio relatorio = Auxiliar.RetornaDadosEntidade<DTO.Relatorio, Relatorio>(Entidade);

            return relatorio;
        }

        public List<Relatorio> GetDTO(List<DTO.Relatorio> Entidades)
        {
            List<Relatorio> listRelatorio = new List<Relatorio>();
            foreach (DTO.Relatorio relatorio in Entidades)
                listRelatorio.Add(GetDTO(relatorio));

            return listRelatorio;
        }
    }
}