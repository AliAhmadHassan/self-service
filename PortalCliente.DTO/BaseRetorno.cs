using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PortalCliente.DTO
{
    public abstract class BaseRetorno
    {
        public virtual T GetModels<T>()
        {
            T _entidade = (T)Activator.CreateInstance(typeof(T));


            foreach (PropertyInfo pi in this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (!pi.DeclaringType.Namespace.Contains(".DTO"))
                    continue;

                foreach (PropertyInfo piModel in _entidade.GetType().GetProperties())
                {
                    if (pi.Name != piModel.Name)
                        continue;

                    else if (pi.GetValue(this, null) == DBNull.Value)
                        pi.SetValue(_entidade, null, null);
                    else
                        pi.SetValue(_entidade, pi.GetValue(this, null), null);
                }
            }
            return _entidade;
        }
        /*
        public virtual List<T> GetModels<T, Y>(List<Y> DadosDTO)
        {
            List<T> _entidade = (List<T>)Activator.CreateInstance(typeof(List<T>));

            foreach (Y item in DadosDTO)
                _entidade.Add(GetModels<T, Y>(item));

            return _entidade;
        }*/
    }
}
