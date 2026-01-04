using PortalCliente.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.BLL
{
    public class DetalhesDebito:IDetalhesDebito
    {
        public List<DTO.DetalhesDebito> Select()
        {
            return new DAL.DetalhesDebito().Select();
        }

        public DTO.DetalhesDebito SelectById(int Id)
        {
            return new DAL.DetalhesDebito().SelectById(Id);
        }

        public void Remover(DTO.DetalhesDebito Entidade)
        {
            new DAL.DetalhesDebito().Remover(Entidade);
        }

        public void Cadastro(DTO.DetalhesDebito Entidade)
        {
            new DAL.DetalhesDebito().Cadastro(Entidade);
        }

        public List<DTO.DetalhesDebito> SelectByPropostaId(int PropostaId)
        {
            return new DAL.DetalhesDebito().SelectByPropostaId(PropostaId);
        }
    }
}
