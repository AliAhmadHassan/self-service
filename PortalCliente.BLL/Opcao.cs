using PortalCliente.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.BLL
{
    public class Opcao:IOpcao
    {
        public List<DTO.Opcao> Select()
        {
            return new DAL.Opcao().Select();
        }

        public DTO.Opcao SelectById(int Id)
        {
            return new DAL.Opcao().SelectById(Id);
        }

        public void Remover(DTO.Opcao Entidade)
        {
            new DAL.Opcao().Remover(Entidade);
        }

        public void Cadastro(DTO.Opcao Entidade)
        {
            new DAL.Opcao().Cadastro(Entidade);
        }

        public DTO.Opcao Inserir(DTO.Opcao Entidade)
        {
            return new DAL.Opcao().Insert(Entidade);
        }

        public List<DTO.Opcao> SelectByPropostaId(int PropostaId)
        {
            return new DAL.Opcao().SelectByPropostaId(PropostaId);
        }
    }
}
