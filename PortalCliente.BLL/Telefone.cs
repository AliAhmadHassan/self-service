using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortalCliente.DTO;

namespace PortalCliente.BLL
{
    public class Telefone : Abstract.ITelefone
    {
        public DTO.Telefone SelectByIdCobNet(int TelId)
        {
            return new DAL.Telefone().SelectByIdCobNet(TelId);
        }
        public List<DTO.Telefone> Select()
        {
            return new DAL.Telefone().Select();
        }

        public DTO.Telefone SelectById(int Id)
        {
            return new DAL.Telefone().SelectById(Id);
        }

        public void Remover(DTO.Telefone Entidade)
        {
            new DAL.Telefone().Remover(Entidade);
        }

        public void Cadastro(DTO.Telefone Entidade)
        {
            new DAL.Telefone().Cadastro(Entidade);
        }

        public List<DTO.Telefone> SelectByClienteId(int ClienteId)
        {
            return new DAL.Telefone().SelectByClienteId(ClienteId);
        }

        public List<DTO.Telefone> SelectByTel_CPFCobNet(string CpfCnpj)
        {
            return new DAL.Telefone().SelectByTel_CPFCobNet(CpfCnpj);
        }

        public List<DTO.Telefone> SelectByTelId(int TelId)
        {
            return new DAL.Telefone().SelectByTelId(TelId);
        }

        public void AtualizaCobNet(int TelId)
        {
            new DAL.Telefone().AtualizaCobNet(TelId);
        }

        public DTO.Telefone SelectByIdCobNetBradesco(int TelId)
        {
            return new DAL.Telefone().SelectByIdCobNetBradesco(TelId);
        }

        public List<DTO.Telefone> SelectByTel_CPFCobNetBradesco(string CpfCnpj)
        {
            return new DAL.Telefone().SelectByTel_CPFCobNetBradesco(CpfCnpj);
        }

        public List<DTO.Telefone> SelectByTel_CPFSRC(string CpfCnpj)
        {
            return new DAL.Telefone().SelectByTel_CPFSRC(CpfCnpj);
        }

        public void AtualizaCobNetBradesco(int TelId)
        {
            new DAL.Telefone().AtualizaCobNetBradesco(TelId);
        }

        public DTO.Telefone SelectByIdSRC(int TelId)
        {
            return new DAL.Telefone().SelectByIdSRC(TelId);
        }


        public void ValidaTelefoneCobNet(int TelId)
        {
            new DAL.Telefone().ValidaTelefoneCobNet(TelId);
        }
        public void ValidaTelefoneCobNetBradesco(int TelId)
        {
            new DAL.Telefone().ValidaTelefoneCobNetBradesco(TelId);
        }
        public void ValidaTelefoneSRC(int TelId)
        {
            new DAL.Telefone().ValidaTelefoneSRC(TelId);
        }
    }
}
