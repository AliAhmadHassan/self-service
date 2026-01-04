using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace PortalCliente.Web.Models
{
    public static class Auxiliar
    {
        public static T RetornaDadosEntidade<Y, T>(Y Origem)
        {
            T _entidade = (T)Activator.CreateInstance(typeof(T));

            List<string> LColunas = new List<string>();
            foreach (PropertyInfo pi in Origem.GetType().GetProperties())
                LColunas.Add(pi.Name);

            foreach (PropertyInfo pi in _entidade.GetType().GetProperties())
            {
                if (!LColunas.Contains(pi.Name))
                    continue;

                PropertyInfo piOrigem  = Origem.GetType().GetProperty(pi.Name);

                if (pi.GetType() == piOrigem.GetType())
                    pi.SetValue(_entidade, pi.GetValue(Origem, null));
                else
                    pi.SetValue(_entidade, null, null);
            }

            return _entidade;
        }
    }
}