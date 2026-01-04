using PortalCliente.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.BLL
{
    public class Cliente:ICliente
    {
        public List<DTO.Cliente> Select()
        {
            return new DAL.Cliente().Select();
        }

        public DTO.Cliente SelectById(int Id)
        {
            return new DAL.Cliente().SelectById(Id);
        }

        public void Remover(DTO.Cliente Entidade)
        {
            new DAL.Cliente().Remover(Entidade);
        }

        public void Cadastro(DTO.Cliente Entidade)
        {
            new DAL.Cliente().Cadastro(Entidade);
        }

        public DTO.Cliente SelectByCpfCnpj(string cpfCnpj)
        {
            return new DAL.Cliente().SelectByCpfCnpj(cpfCnpj);
        }
    }
}
