using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalCliente.Web.Models
{
    public class Acordo : DTO.Acordo, IModel<Acordo, DTO.Acordo>
    {
        public Acordo GetDTO(DTO.Acordo Entidade)
        {
            Acordo acordo = Auxiliar.RetornaDadosEntidade<DTO.Acordo, Acordo>(Entidade);

            return acordo;
        }

        public List<Acordo> GetDTO(List<DTO.Acordo> Entidades)
        {
            List<Acordo> listAcordo = new List<Acordo>();
            foreach (DTO.Acordo acordo in Entidades)
                listAcordo.Add(GetDTO(acordo));

            return listAcordo;
        }
    }
}
