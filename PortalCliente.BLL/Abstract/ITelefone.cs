using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.BLL.Abstract
{
    public interface ITelefone : IBase<DTO.Telefone>
    {
        DTO.Telefone SelectByIdCobNet(int TelId);
        List<DTO.Telefone> SelectByClienteId(int ClienteId);
        List<DTO.Telefone> SelectByTel_CPFCobNet(string CpfCnpj);
        List<DTO.Telefone> SelectByTelId(int TelId);
        void AtualizaCobNet(int TelId);

        DTO.Telefone SelectByIdCobNetBradesco(int TelId);
        List<DTO.Telefone> SelectByTel_CPFCobNetBradesco(string CpfCnpj);
        List<DTO.Telefone> SelectByTel_CPFSRC(string CpfCnpj);
        void AtualizaCobNetBradesco(int TelId);
        DTO.Telefone SelectByIdSRC(int TelId);
    }
}
