using PortalCliente.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.BLL
{
    public class Credor:ICredor
    {
        public List<DTO.Credor> Select()
        {
            return new DAL.Credor().Select();
        }

        public DTO.Credor SelectById(int Id)
        {
            return new DAL.Credor().SelectById(Id);
        }

        public void Remover(DTO.Credor Entidade)
        {
            new DAL.Credor().Remover(Entidade);
        }

        public void Cadastro(DTO.Credor Entidade)
        {
            new DAL.Credor().Cadastro(Entidade);
        }
    }
}
