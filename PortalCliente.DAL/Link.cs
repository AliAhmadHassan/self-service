using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.DAL
{
    public class Link : Base<DTO.Link>
    {
        public DTO.Link SelectClienteId(int ClienteId, int TelId, int MailingId)
        {
            return AuxConsultas<DTO.Link>.Entidade("SPSLinkByClienteIdTelId", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@ClienteId", System.Data.SqlDbType.Int) { Value = ClienteId }, new SqlParameter("@TelId", System.Data.SqlDbType.Int) { Value = TelId }, new SqlParameter("@MailingId", System.Data.SqlDbType.Int) { Value = MailingId });
        }

        public DTO.Link SelecionarLinkId(int Id)
        {
            return AuxConsultas<DTO.Link>.Entidade("SPSLinkByLinkId", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@LinkId", System.Data.SqlDbType.Int) { Value = Id });
        }

        public DTO.Link Insert(int ClienteId, int TelId, int MailingId)
        {
            return AuxConsultas<DTO.Link>.Entidade("SPILink", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@ClienteId", System.Data.SqlDbType.Int) { Value = ClienteId }, new SqlParameter("@TelId", System.Data.SqlDbType.Int) { Value = TelId }, new SqlParameter("@MailingId", System.Data.SqlDbType.Int) { Value = MailingId });
        }

        public void Alterar(DTO.Link Entidade)
        {
            using (SqlConnection Conn = new SqlConnection(strConn(DTO.Base.TipoConexao.Core)))
            {
                using (SqlCommand cmd = new SqlCommand("SPULink", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LinkId", Entidade.LinkId);
                        cmd.Parameters.AddWithValue("@ClienteId", Entidade.ClienteId);
                        cmd.Parameters.AddWithValue("@TelId", Entidade.TelId);
                        cmd.Parameters.AddWithValue("@MailingId", Entidade.MailingId);

                        if (!Entidade.AcessouLink.ToString().Contains("01/01/0001"))
                            cmd.Parameters.AddWithValue("@AcessouLink", Entidade.AcessouLink);
                        else
                            cmd.Parameters.AddWithValue("@AcessouLink", DateTime.Parse("1/1/1753"));

                        if (!Entidade.ConfirmouSenha.ToString().Contains("01/01/0001"))
                            cmd.Parameters.AddWithValue("@ConfirmouSenha", Entidade.ConfirmouSenha);
                        else
                            cmd.Parameters.AddWithValue("@ConfirmouSenha", DateTime.Parse("1/1/1753"));

                        if (!Entidade.SolicitouRetorno.ToString().Contains("01/01/0001"))
                            cmd.Parameters.AddWithValue("@SolicitouRetorno", Entidade.SolicitouRetorno);
                        else
                            cmd.Parameters.AddWithValue("@SolicitouRetorno", DateTime.Parse("1/1/1753"));

                        if (!Entidade.FezAcordo.ToString().Contains("01/01/0001"))
                            cmd.Parameters.AddWithValue("@FezAcordo", Entidade.FezAcordo);
                        else
                            cmd.Parameters.AddWithValue("@FezAcordo", DateTime.Parse("1/1/1753"));

                        Conn.Open();
                        SqlDataReader Dr = cmd.ExecuteReader();
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
        }
    }
}
