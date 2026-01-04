using PortalCliente.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.BLL
{
    public class Proposta:IProposta
    {
        public List<DTO.Proposta> Select()
        {
            return new DAL.Proposta().Select();
        }

        public DTO.Proposta SelectById(int Id)
        {
            return new DAL.Proposta().SelectById(Id);
        }

        public void Remover(DTO.Proposta Entidade)
        {
            new DAL.Proposta().Remover(Entidade);
        }

        public void Cadastro(DTO.Proposta Entidade)
        {
            new DAL.Proposta().Cadastro(Entidade);
        }

        public List<DTO.Proposta> SelectByClienteId(int ClienteId)
        {
            return new DAL.Proposta().SelectByClienteId(ClienteId);
        }

        public List<DTO.Proposta> SelectByLoteId(int LoteId)
        {
            return new DAL.Proposta().SelectByLoteId(LoteId);
        }

        public List<DTO.Proposta> SelectByDadosBoletoId(int DadosBoletoId)
        {
            return new DAL.Proposta().SelectByDadosBoletoId(DadosBoletoId);
        }

        public List<DTO.Proposta> SelectByLinkId(int ClienteId)
        {
            return new DAL.Proposta().SelectByLinkId(ClienteId);
        }
    }
}
