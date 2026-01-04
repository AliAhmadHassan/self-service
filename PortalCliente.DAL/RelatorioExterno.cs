using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.DAL
{
    public class RelatorioExterno : Conexao
    {
        public List<DTO.RelatorioExterno> SelectRelatorio(int MaillingId, int Status)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@MailingId", System.Data.SqlDbType.Int) { Value = MaillingId });
            parametros.Add(new SqlParameter("@Status", System.Data.SqlDbType.Int) { Value = Status });
            return AuxConsultas<DTO.RelatorioExterno>.Lista("SPSExtraiRelatorio", strConn(DTO.Base.TipoConexao.Core), parametros.ToArray());

            //if (Status == 5)
            //{
            //    List<SqlParameter> parametros = new List<SqlParameter>();
            //    parametros.Add(new SqlParameter("@MailingId", System.Data.SqlDbType.Int) { Value = MaillingId });

            //    return AuxConsultas<DTO.RelatorioExterno>.Lista("SPSRelatorioAcordo", strConn(DTO.Base.TipoConexao.Core), parametros.ToArray());
            //}
            //else if (Status == 4)
            //{
            //    List<SqlParameter> parametros = new List<SqlParameter>();
            //    parametros.Add(new SqlParameter("@MailingId", System.Data.SqlDbType.Int) { Value = MaillingId });

            //    return AuxConsultas<DTO.RelatorioExterno>.Lista("SPSRelatorioRetorno", strConn(DTO.Base.TipoConexao.Core), parametros.ToArray());
            //}
            //else if (Status == 3)
            //{
            //    List<SqlParameter> parametros = new List<SqlParameter>();
            //    parametros.Add(new SqlParameter("@MailingId", System.Data.SqlDbType.Int) { Value = MaillingId });

            //    return AuxConsultas<DTO.RelatorioExterno>.Lista("SPSRelatorioLogou", strConn(DTO.Base.TipoConexao.Core), parametros.ToArray());
            //}
            //else if (Status == 2)
            //{
            //    List<SqlParameter> parametros = new List<SqlParameter>();
            //    parametros.Add(new SqlParameter("@MailingId", System.Data.SqlDbType.Int) { Value = MaillingId });

            //    return AuxConsultas<DTO.RelatorioExterno>.Lista("SPSRelatorioAcessou", strConn(DTO.Base.TipoConexao.Core), parametros.ToArray());
            //}
            //else if (Status == 1)
            //{

            //    List<SqlParameter> parametros = new List<SqlParameter>();
            //    parametros.Add(new SqlParameter("@MailingId", System.Data.SqlDbType.Int) { Value = MaillingId });

            //    return AuxConsultas<DTO.RelatorioExterno>.Lista("SPSRelatorioBase", strConn(DTO.Base.TipoConexao.Core), parametros.ToArray());
            //}

            return null;
        }
    }
}
