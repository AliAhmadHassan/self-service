using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.BLL
{
    public class OpcaoLinhaDigitavel
    {
        public List<DTO.OpcaoLinhaDigitavel> SelectById(int Id)
        {
            return new DAL.OpcaoLinhaDigitavel().SelectByOpcaoId(Id);
        }

        public void Cadastro(DTO.OpcaoLinhaDigitavel Entidade)
        {
            using (SqlConnection sqlConn = new SqlConnection("Data Source=192.168.21.94;Initial Catalog=PortalClienteDB;Persist Security Info=True;User ID=sa;Password=Admin357/"))
            {
                string sql = "Insert into OpcaoLinhaDigitavel values(" + Entidade.OpcaoId + ", '" + Entidade.LinhaDigitavel.Replace(".", "").Replace(" ", "") + "','" + Entidade.CodigoBarras + "')";

                sqlConn.Open();
                SqlCommand sqlCmmd = new SqlCommand(sql, sqlConn);
                sqlCmmd.ExecuteNonQuery();
                sqlConn.Close();
            }
        }
    }
}
