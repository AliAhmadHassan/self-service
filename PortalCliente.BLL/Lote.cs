using PortalCliente.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.BLL
{
    public class Lote:ILote
    {
        public List<DTO.Lote> Select()
        {
            return new DAL.Lote().Select();
        }

        public DTO.Lote SelectById(int Id)
        {
            return new DAL.Lote().SelectById(Id);
        }

        public void Remover(DTO.Lote Entidade)
        {
            new DAL.Lote().Remover(Entidade);
        }

        public void Cadastro(DTO.Lote Entidade)
        {
            new DAL.Lote().Cadastro(Entidade);
        }

        public List<DTO.Lote> SelectByCredId(int CredId)
        {
            return new DAL.Lote().SelectByCredId(CredId);
        }

        public List<DTO.Lote> SelectByNotAtivo()
        {
            return new DAL.Lote().SelectByNotAtivo();
        }

        public DTO.Lote SelectByAgendaId(int agendaId)
        {
            return new DAL.Lote().SelectByAgendaId(agendaId);
        }
    }
}
