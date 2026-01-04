using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCliente.DAL
{
    public class Telefone : Base<DTO.Telefone>
    {
        public List<DTO.Telefone> SelectByClienteId(int ClienteId)
        {
            return AuxConsultas<DTO.Telefone>.Lista("SPSTelefoneByClienteId", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@ClienteId", ClienteId));
        }

        public DTO.Telefone SelectByIdCobNet(int TelId)
        {
            DTO.Telefone telefone = null;

            using (SqlConnection conn = new SqlConnection(strConn(DTO.Base.TipoConexao.CobNet)))
            {
                using (SqlCommand cmd = new SqlCommand("Select Tel_DDD, Tel_Telefone from tb_telefone (Nolock) where Tel_Id = @Tel_Id", conn))
                {
                    conn.Open();
                    SqlParameter param = new SqlParameter("@Tel_Id", System.Data.SqlDbType.Int);
                    param.Value = TelId;

                    cmd.Parameters.Add(param);
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            telefone = new DTO.Telefone();
                            telefone.DDD = dr["Tel_DDD"].ToString();
                            telefone.Numero = dr["Tel_Telefone"].ToString();
                        }
                    }
                }
            }
            return telefone;
        }

        public DTO.Telefone SelectByIdCobNetBradesco(int TelId)
        {
            DTO.Telefone telefone = null;

            using (SqlConnection conn = new SqlConnection(strConn(DTO.Base.TipoConexao.CobNetBradesco)))
            {
                using (SqlCommand cmd = new SqlCommand("Select Tel_DDD, Tel_Telefone from tb_telefone (Nolock) where Tel_Id = @Tel_Id", conn))
                {
                    conn.Open();
                    SqlParameter param = new SqlParameter("@Tel_Id", System.Data.SqlDbType.Int);
                    param.Value = TelId;

                    cmd.Parameters.Add(param);
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            telefone = new DTO.Telefone();
                            telefone.DDD = dr["Tel_DDD"].ToString();
                            telefone.Numero = dr["Tel_Telefone"].ToString();
                        }
                    }
                }
            }
            return telefone;
        }

        public void ValidaTelefoneCobNet(int TelId)
        {
            using (SqlConnection conn = new SqlConnection(strConn(DTO.Base.TipoConexao.CobNet)))
            {
                using (SqlCommand cmd = new SqlCommand("Update Tb_Telefone set Tel_Qualidade = 5 where Tel_Id = @Tel_Id", conn))
                {
                    conn.Open();
                    SqlParameter param = new SqlParameter("@Tel_Id", System.Data.SqlDbType.Int);
                    param.Value = TelId;

                    cmd.Parameters.Add(param);
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ValidaTelefoneCobNetBradesco(int TelId)
        {
            using (SqlConnection conn = new SqlConnection(strConn(DTO.Base.TipoConexao.CobNetBradesco)))
            {
                using (SqlCommand cmd = new SqlCommand("Update Tb_Telefone set Tel_Qualidade = 5 where Tel_Id = @Tel_Id", conn))
                {
                    conn.Open();
                    SqlParameter param = new SqlParameter("@Tel_Id", System.Data.SqlDbType.Int);
                    param.Value = TelId;

                    cmd.Parameters.Add(param);
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ValidaTelefoneSRC(int TelId)
        {
            using (SqlConnection conn = new SqlConnection(strConn(DTO.Base.TipoConexao.SRC)))
            {
                using (SqlCommand cmd = new SqlCommand(@"update [cad_devT]
set Perc_Tel = 100
from[cad_devT](Nolock)
    inner join Orcozol_PortalCliente_Telefone on Orcozol_PortalCliente_Telefone.cpf_dev = [cad_devT].cpf_dev

        and Orcozol_PortalCliente_Telefone.Cod_Tel = [cad_devT].Cod_Tel
where Orcozol_PortalCliente_Telefone.TelId = @Tel_Id", conn))
                {
                    conn.Open();
                    SqlParameter param = new SqlParameter("@Tel_Id", System.Data.SqlDbType.Int);
                    param.Value = TelId;

                    cmd.Parameters.Add(param);
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DTO.Telefone SelectByIdSRC(int TelId)
        {
            DTO.Telefone telefone = null;

            using (SqlConnection conn = new SqlConnection(strConn(DTO.Base.TipoConexao.SRC)))
            {
                using (SqlCommand cmd = new SqlCommand(@"Select ddd_Tel as Tel_DDD, Tel_Tel as Tel_Telefone
from [cad_devT] (Nolock)

    inner join Orcozol_PortalCliente_Telefone on Orcozol_PortalCliente_Telefone.cpf_dev = [cad_devT].cpf_dev

        and Orcozol_PortalCliente_Telefone.Cod_Tel = [cad_devT].Cod_Tel
where Orcozol_PortalCliente_Telefone.TelId = @Tel_Id", conn))
                {
                    conn.Open();
                    SqlParameter param = new SqlParameter("@Tel_Id", System.Data.SqlDbType.Int);
                    param.Value = TelId;

                    cmd.Parameters.Add(param);
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            telefone = new DTO.Telefone();
                            telefone.DDD = dr["Tel_DDD"].ToString();
                            telefone.Numero = dr["Tel_Telefone"].ToString();
                        }
                    }
                }
            }
            return telefone;
        }
        public List<DTO.Telefone> SelectByTel(int ClienteId)
        {
            return AuxConsultas<DTO.Telefone>.Lista("SPSTelefoneByClienteId", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@ClienteId", ClienteId));
        }
        public List<DTO.Telefone> SelectByTel_CPFCobNet(string CpfCnpj)
        {
            List<DTO.Telefone> telefones = new List<DTO.Telefone>();

            using (SqlConnection conn = new SqlConnection(strConn(DTO.Base.TipoConexao.CobNet)))
            {
                using (SqlCommand cmd = new SqlCommand("SPSPortalClienteTelefoneByTel_CPF", conn))
                {
                    conn.Open();
                    SqlParameter param = new SqlParameter("@Tel_CPF", System.Data.SqlDbType.VarChar, 15);
                    param.Value = CpfCnpj.Replace(" ", "").PadLeft(15, '0');

                    cmd.Parameters.Add(param);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            DTO.Telefone telefone = new DTO.Telefone();

                            telefone = new DTO.Telefone();
                            telefone.DDD = dr["DDD"].ToString();
                            telefone.Numero = dr["Numero"].ToString();
                            telefone.TelId = Convert.ToInt32(dr["TelId"].ToString());
                            telefones.Add(telefone);
                        }
                    }
                }
            }
            return telefones;
        }

        public List<DTO.Telefone> SelectByTel_CPFCobNetBradesco(string CpfCnpj)
        {
            List<DTO.Telefone> telefones = new List<DTO.Telefone>();

            using (SqlConnection conn = new SqlConnection(strConn(DTO.Base.TipoConexao.CobNetBradesco)))
            {
                using (SqlCommand cmd = new SqlCommand("SPSPortalClienteTelefoneByTel_CPF", conn))
                {
                    conn.Open();
                    SqlParameter param = new SqlParameter("@Tel_CPF", System.Data.SqlDbType.VarChar, 15);
                    param.Value = CpfCnpj.Replace(" ", "").PadLeft(15, '0');

                    cmd.Parameters.Add(param);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            DTO.Telefone telefone = new DTO.Telefone();

                            telefone = new DTO.Telefone();
                            telefone.DDD = dr["DDD"].ToString();
                            telefone.Numero = dr["Numero"].ToString();
                            telefone.TelId = Convert.ToInt32(dr["TelId"].ToString());
                            telefones.Add(telefone);
                        }
                    }
                }
            }
            return telefones;
        }

        public List<DTO.Telefone> SelectByTel_CPFSRC(string CpfCnpj)
        {
            List<DTO.Telefone> telefones = new List<DTO.Telefone>();

            using (SqlConnection conn = new SqlConnection(strConn(DTO.Base.TipoConexao.SRC)))
            {
                using (SqlCommand cmd = new SqlCommand("SPSPortalClienteTelefoneByTel_CPF", conn))
                {
                    conn.Open();
                    SqlParameter param = new SqlParameter("@Tel_CPF", System.Data.SqlDbType.VarChar, 15);
                    param.Value = CpfCnpj;

                    cmd.Parameters.Add(param);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            DTO.Telefone telefone = new DTO.Telefone();

                            telefone = new DTO.Telefone();
                            telefone.DDD = dr["DDD"].ToString();
                            telefone.Numero = dr["Numero"].ToString();
                            telefone.TelId = Convert.ToInt32(dr["TelId"].ToString());
                            telefones.Add(telefone);
                        }
                    }
                }
            }
            return telefones;
        }


        public List<DTO.Telefone> SelectByTelId(int TelId)
        {
            return AuxConsultas<DTO.Telefone>.Lista("SPSPortalClienteTelefoneByTel_CPF", strConn(DTO.Base.TipoConexao.CobNet), new SqlParameter("@TelId", System.Data.SqlDbType.Int, 15) { Value = TelId });
        }

        public void AtualizaCobNet(int TelId)
        {
            using (SqlConnection conn = new SqlConnection(strConn(DTO.Base.TipoConexao.CobNet)))
            {
                using (SqlCommand cmd = new SqlCommand("SPIPortalClienteTelefone", conn))
                {
                    conn.Open();

                    SqlParameter param = new SqlParameter("@Tel_Id", System.Data.SqlDbType.Int);
                    param.Value = TelId;

                    cmd.Parameters.Add(param);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void AtualizaCobNetBradesco(int TelId)
        {
            using (SqlConnection conn = new SqlConnection(strConn(DTO.Base.TipoConexao.CobNetBradesco)))
            {
                using (SqlCommand cmd = new SqlCommand("SPIPortalClienteTelefone", conn))
                {
                    conn.Open();

                    SqlParameter param = new SqlParameter("@Tel_Id", System.Data.SqlDbType.Int);
                    param.Value = TelId;

                    cmd.Parameters.Add(param);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
