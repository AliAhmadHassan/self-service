using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.Web.Models
{
    public interface IModel<T, Y>
    {
        T GetDTO(Y Entidade);

        List<T> GetDTO(List<Y> Entidades);
    }
}
