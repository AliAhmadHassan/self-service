using PortalCliente.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.BLL
{
    public class SolicitacaoRetorno:ISolicitacaoRetorno
    {
        public List<DTO.SolicitacaoRetorno> Select()
        {
            return new DAL.SolicitacaoRetorno().Select();
        }

        public DTO.SolicitacaoRetorno SelectById(int Id)
        {
            return new DAL.SolicitacaoRetorno().SelectById(Id);
        }

        public void Remover(DTO.SolicitacaoRetorno Entidade)
        {
            new DAL.SolicitacaoRetorno().Remover(Entidade);
        }

        public void Cadastro(DTO.SolicitacaoRetorno Entidade)
        {
            new DAL.SolicitacaoRetorno().Cadastro(Entidade);
        }

        public List<DTO.SolicitacaoRetorno> SelectByClienteId(int ClienteId)
        {
            return new DAL.SolicitacaoRetorno().SelectByClienteId(ClienteId);
        }

        public List<DTO.SolicitacaoRetorno> SelectByNotRetorned()
        {
            return new DAL.SolicitacaoRetorno().SelectByNotRetorned();
        }
    }
}
