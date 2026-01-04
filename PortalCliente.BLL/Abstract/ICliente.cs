using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.BLL.Abstract
{
    public interface ICliente:IBase<DTO.Cliente>
    {
        DTO.Cliente SelectByCpfCnpj(string cpfCnpj);
    }
}