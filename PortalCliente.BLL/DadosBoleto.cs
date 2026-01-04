using PortalCliente.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.BLL
{
    public class DadosBoleto:IDadosBoleto
    {
        public List<DTO.DadosBoleto> Select()
        {
            return new DAL.DadosBoleto().Select();
        }

        public DTO.DadosBoleto SelectById(int Id)
        {
            return new DAL.DadosBoleto().SelectById(Id);
        }

        public void Remover(DTO.DadosBoleto Entidade)
        {
            new DAL.DadosBoleto().Remover(Entidade);
        }

        public void Cadastro(DTO.DadosBoleto Entidade)
        {
            new DAL.DadosBoleto().Cadastro(Entidade);
        }
    }
}
