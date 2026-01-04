using PortalCliente.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.BLL
{
    public class Acordo:IAcordo
    {
        public List<DTO.Acordo> Select()
        {
            return new DAL.Acordo().Select();
        }

        public DTO.Acordo SelectById(int Id)
        {
            return new DAL.Acordo().SelectById(Id);
        }

        public void Remover(DTO.Acordo Entidade)
        {
            new DAL.Acordo().Remover(Entidade);
        }

        public void Cadastro(DTO.Acordo Entidade)
        {
            new DAL.Acordo().Cadastro(Entidade);
        }

        public List<DTO.Acordo> SelectByOpcaoId(int OpcaoId)
        {
            return new DAL.Acordo().SelectByOpcaoId(OpcaoId);
        }
    }
}
