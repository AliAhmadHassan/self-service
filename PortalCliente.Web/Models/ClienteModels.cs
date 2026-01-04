using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalCliente.Web.Models
{
    public class Cliente : DTO.Cliente, IModel<Cliente, DTO.Cliente>
    {
        public Cliente GetDTO(DTO.Cliente Entidade)
        {
            Cliente cliente = Auxiliar.RetornaDadosEntidade<DTO.Cliente, Cliente>(Entidade);

            return cliente;
        }

        public List<Cliente> GetDTO(List<DTO.Cliente> Entidades)
        {
            List<Cliente> listCliente = new List<Cliente>();
            foreach (DTO.Cliente cliente in Entidades)
                listCliente.Add(GetDTO(cliente));

            return listCliente;
        }

        public string GetMask()
        {
            if(Int64.Parse(this.CpfCnpj).ToString().Length > 11)
            {
                return "CNPJ: " + this.CpfCnpj.Substring(0, 3) + "." + this.CpfCnpj.Substring(3, 3) + "." + this.CpfCnpj.Substring(6, 3) + "/" + this.CpfCnpj.Substring(9, 4) + "-" + this.CpfCnpj.Substring(13, 2);
            }
            else
            {
                return "CPF: " + this.CpfCnpj.Substring(4, 3) + "." + this.CpfCnpj.Substring(7, 3) + "." + this.CpfCnpj.Substring(10, 3) + "-" + this.CpfCnpj.Substring(13, 2);
            }
        }

        public string GetFirstName()
        {
            string auxNome = this.Nome;
            auxNome = auxNome.Replace("SRTA.", "");
            auxNome = auxNome.Replace("SRTA. ", "");
            auxNome = auxNome.Replace("SRTA ", "");
            auxNome = auxNome.Replace("SR(A).", "");
            auxNome = auxNome.Replace("SR(A). ", "");
            auxNome = auxNome.Replace("SR(A)", "");
            auxNome = auxNome.Replace("SRA.", "");
            auxNome = auxNome.Replace("SRA. ", "");
            auxNome = auxNome.Replace("SRA ", "");
            auxNome = auxNome.Replace("SR.", "");
            auxNome = auxNome.Replace("SR. ", "");
            auxNome = auxNome.Replace("SR ", "");
            auxNome = auxNome.Replace("( DRIVE )", "");
            auxNome = auxNome.Replace("DRA.", "");
            auxNome = auxNome.Replace("DRA. ", "");
            auxNome = auxNome.Replace("DRA ", "");
            auxNome = auxNome.Replace("DR.", "");
            auxNome = auxNome.Replace("DR. ", "");
            auxNome = auxNome.Replace("DR ", "");
            auxNome = auxNome.Trim();

            return auxNome.Substring(0, auxNome.IndexOf(" "));
        }
    }
}
