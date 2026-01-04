using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalCliente.Web.Models
{
    public class Lote : DTO.Lote, IModel<Lote, DTO.Lote>
    {
        public string Credor { get; set; }
        public Lote GetDTO(DTO.Lote Entidade)
        {
            Lote lote = Auxiliar.RetornaDadosEntidade<DTO.Lote, Lote>(Entidade);

            return lote;
        }

        public List<Lote> GetDTO(List<DTO.Lote> Entidades)
        {
            List<Lote> listLote = new List<Lote>();
            foreach (DTO.Lote lote in Entidades)
                listLote.Add(GetDTO(lote));

            return listLote;
        }
    }
}
