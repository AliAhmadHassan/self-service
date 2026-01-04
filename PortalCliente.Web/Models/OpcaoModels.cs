using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalCliente.Web.Models
{
    public class Opcao : DTO.Opcao, IModel<Opcao, DTO.Opcao>
    {
        public Opcao GetDTO(DTO.Opcao Entidade)
        {
            Opcao opcao = Auxiliar.RetornaDadosEntidade<DTO.Opcao, Opcao>(Entidade);

            return opcao;
        }

        public List<Opcao> GetDTO(List<DTO.Opcao> Entidades)
        {
            List<Opcao> listOpcao = new List<Opcao>();
            foreach (DTO.Opcao opcao in Entidades)
                listOpcao.Add(GetDTO(opcao));

            return listOpcao;
        }
    }
}
