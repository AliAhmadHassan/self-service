using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


/// <summary>
/// Summary description for Cs_Acerta
/// </summary>
public partial class Cs_Boleto
{
    public static string Mod_11(string Valor)
    {
        int ContaMod = 2;
        int Acumulativo = 0;
        string ValorPosicao;
        for (int i = Valor.Length - 1; i >= 0; i--)
        {
            if (ContaMod == 10)
                ContaMod = 2;
            ValorPosicao = Valor[i].ToString();
            Acumulativo += Convert.ToInt32(ValorPosicao) * ContaMod;
            
            ContaMod++;
        }
        Acumulativo = Acumulativo % 11;
        Acumulativo = 11 - Acumulativo;
        if ((Acumulativo > 9) || (Acumulativo == 0) || (Acumulativo == 1))
            Acumulativo = 1;
        return Acumulativo.ToString();
    }
    public static string Mod_NossoNumeroSantander(string Valor)
    {
        int ContaMod = 2;
        int Acumulativo = 0;
        string ValorPosicao;
        for (int i = Valor.Length - 1; i >= 0; i--)
        {
            if (ContaMod == 10)
                ContaMod = 2;
            ValorPosicao = Valor[i].ToString();
            Acumulativo += Convert.ToInt32(ValorPosicao) * ContaMod;
            ContaMod++;
        }
        Acumulativo = Acumulativo % 11;

        if (Acumulativo == 10)
            Acumulativo = 1;
        else
            if ((Acumulativo == 1) || (Acumulativo == 0))
                Acumulativo = 0;
            else
                Acumulativo = 11 - Acumulativo;

        return Acumulativo.ToString();
    }
    public static string Mod_11Santander(string Valor)
    {
        int ContaMod = 2;
        int Acumulativo = 0;
        string ValorPosicao;
        for (int i = Valor.Length - 1; i >= 0; i--)
        {
            if (ContaMod == 10)
                ContaMod = 2;
            ValorPosicao = Valor[i].ToString();
            Acumulativo += Convert.ToInt32(ValorPosicao) * ContaMod;
            ContaMod++;
        }
        Acumulativo *= 10;
        Acumulativo = Acumulativo % 11;
        if ((Acumulativo == 10) || (Acumulativo == 0))
            Acumulativo = 1;

        return Acumulativo.ToString();
    }
    public static string Mod_11Citibank(string Valor)
    {
        int ContaMod = 2;
        int Acumulativo = 0;
        string ValorPosicao;
        for (int i = Valor.Length - 1; i >= 0; i--)
        {
            if (ContaMod == 10)
                ContaMod = 2;
            ValorPosicao = Valor[i].ToString();
            Acumulativo += Convert.ToInt32(ValorPosicao) * ContaMod;
            ContaMod++;
        }
        Acumulativo = Acumulativo % 11;

        if ((Acumulativo == 0) || (Acumulativo == 1))
            Acumulativo = 0;
        else
            Acumulativo = 11 - Acumulativo;

        return Acumulativo.ToString();
    }
    public static string Mod_11CitibankCodigoBarras(string Valor)
    {
        int ContaMod = 2;
        int Acumulativo = 0;
        string ValorPosicao;
        for (int i = Valor.Length - 1; i >= 0; i--)
        {
            if (ContaMod == 10)
                ContaMod = 2;
            ValorPosicao = Valor[i].ToString();
            Acumulativo += Convert.ToInt32(ValorPosicao) * ContaMod;
            ContaMod++;
        }
        Acumulativo = Acumulativo % 11;

        if ((Acumulativo == 0) || (Acumulativo == 1))
            Acumulativo = 1;
        else
            Acumulativo = 11 - Acumulativo;

        return Acumulativo.ToString();
    }
    public static string Mod_10(string Valor)
    {
        int ContaMod = 2;
        decimal Acumulativo = 0;
        string ValorPosicao;
        for (int i = Valor.Length - 1; i >= 0; i--)
        {
            if (ContaMod == 0)
                ContaMod = 2;
            ValorPosicao = Valor[i].ToString();
            if (Convert.ToInt32(ValorPosicao) * ContaMod < 10)
                Acumulativo += Convert.ToInt32(ValorPosicao) * ContaMod;
            else
            {
                decimal ValorMult = Convert.ToInt32(ValorPosicao) * ContaMod;
                decimal DecimalDeValorMult = Convert.ToDecimal((Convert.ToDouble(ValorPosicao) * ContaMod) / 10);
                if (DecimalDeValorMult.ToString().Replace(".", ",").Contains(","))
                    DecimalDeValorMult = Convert.ToDecimal(DecimalDeValorMult.ToString().Substring(0, DecimalDeValorMult.ToString().Replace(",", ".").IndexOf(".")));
                else
                    DecimalDeValorMult = DecimalDeValorMult;
                Acumulativo += DecimalDeValorMult + (ValorMult - DecimalDeValorMult * 10);

            }
            ContaMod--;
        }
        Acumulativo = (10 - (Acumulativo % 10));
        if (Acumulativo > 9)
            Acumulativo -= 10;
        return Acumulativo.ToString();
    }
    //public static string Mod_10Santander(string Valor)
    //{
    //    int ContaMod = 2;
    //    decimal Acumulativo = 0;
    //    string ValorPosicao;
    //    for (int i = Valor.Length - 1; i >= 0; i--)
    //    {
    //        if (ContaMod == 0)
    //            ContaMod = 2;
    //        ValorPosicao = Valor[i].ToString();
    //        if (Convert.ToInt32(ValorPosicao) * ContaMod < 10)
    //            Acumulativo += Convert.ToInt32(ValorPosicao) * ContaMod;
    //        else
    //        {
    //            string strValorMult = Convert.ToString(Convert.ToInt32(ValorPosicao) * ContaMod);
    //            Acumulativo += Convert.ToDecimal(strValorMult[0].ToString()) + Convert.ToDecimal(strValorMult[1].ToString());

    //        }
    //        ContaMod--;
    //    }
    //    Acumulativo = (10 - (Acumulativo % 10));
    //    if (Acumulativo > 9)
    //        Acumulativo -= 10;
    //    return Acumulativo.ToString();
    //}
    public static string Mod_11Base7(string Valor)
    {
        int ContaMod = 2;
        int Acumulativo = 0;
        string ValorPosicao;
        for (int i = Valor.Length - 1; i >= 0; i--)
        {
            if (ContaMod == 8)
                ContaMod = 2;
            ValorPosicao = Valor[i].ToString();
            Acumulativo += Convert.ToInt32(ValorPosicao) * ContaMod;
            ContaMod++;
        }
        Acumulativo = Acumulativo % 11;
        if (Acumulativo == 1)
            return "P";
        if (Acumulativo == 0)
            return "0";

        Acumulativo = 11 - Acumulativo;
        return Acumulativo.ToString();
    }
    public static string Mod_11InvertResto0(string Valor)
    {
        int ContaMod = 9;
        int Acumulativo = 0;
        string ValorPosicao;
        for (int i = Valor.Length - 1; i >= 0; i--)
        {
            if (ContaMod == 1)
                ContaMod = 9;
            ValorPosicao = Valor[i].ToString();
            Acumulativo += Convert.ToInt32(ValorPosicao) * ContaMod;
            ContaMod--;
        }
        Acumulativo = Acumulativo % 11;

        if ((Acumulativo == 0) || (Acumulativo == 10))
            Acumulativo = 0;

        return Acumulativo.ToString();
    }
    public static string SubData(int Dias_Sub)
    {
        SqlCommand comando = new SqlCommand();
        comando.Connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CobNetDataBaseConnectionString"].ConnectionString.ToString());
        string Temp = "";
        try
        {
            comando.Connection.Open();

            comando.CommandText = "Select getdate() - " + Dias_Sub.ToString();
            Temp = comando.ExecuteScalar().ToString();
        } catch (Exception ex)
        { throw ex; } finally
        {
            comando.Connection.Close();
        }
        Temp = Temp.Substring(0, Temp.IndexOf(' '));
        return Temp;
    }
    public static string DataFormatoJuliano(DateTime Vencimento, string TipoIdentificador)
    {
        if (TipoIdentificador == "4")
        {
            string Ano, Dias;


            Ano = Vencimento.Year.ToString().Substring(Vencimento.Year.ToString().Length - 1, 1);

            DateTime DataBase = Convert.ToDateTime("01/01/" + Vencimento.Year.ToString());

            Dias = Cs_Acerta.AcrescentaZeros(Convert.ToString(Vencimento.Date - DataBase.Date), 3).Substring(0, 3);
            Dias = Convert.ToString(Convert.ToInt32(Dias) + 1);

            return Dias + Ano;
        }
        return "0000";
    }
    public static string AcrescentaZeros(string Valor, int Tamanho)
    {
        string ValorAcertado = Valor.Replace(",", "").Replace(".", "");
        for (int QuantidadeZeros = ValorAcertado.Length + 1; QuantidadeZeros <= Tamanho; QuantidadeZeros++)
        {
            ValorAcertado = '0' + ValorAcertado;
        }
        return ValorAcertado;
    }
    //Banco Real
    private static string GeraNumeroCodigoBarraBancoReal(string IdentBanco, string CodMoeda, string Vencimento, string Valor, string AgenciaCedente, string Carteira, string NossoNumero, string ContaCedente)
    {
        string DigVerificador, Zero, FatorVencimento;
        DateTime DataVencimento, DataInicio;
        string NumBoleto = "";
        IdentBanco = AcrescentaZeros(IdentBanco, 3);
        CodMoeda = "9";
        Vencimento = Vencimento;
        Valor = AcrescentaZeros(Cs_Mascara.ParaValor(Valor), 10);
        AgenciaCedente = AcrescentaZeros(AgenciaCedente, 4);
        Carteira = AcrescentaZeros(Carteira, 2);
        NossoNumero = AcrescentaZeros(NossoNumero, 13);
        ContaCedente = AcrescentaZeros(ContaCedente, 7);
        Zero = "0";

        DataInicio = Convert.ToDateTime("07/10/1997");
        DataVencimento = Convert.ToDateTime(Vencimento);

        FatorVencimento = Convert.ToString(DataVencimento.Date - DataInicio.Date).Replace(".00:00:00", "");

        //DigVerificador = Mod_11(IdentBanco + CodMoeda + FatorVencimento + Valor + AgenciaCedente + Carteira + NossoNumero + ContaCedente + Zero);
        string Digitao = Cs_Boleto.Mod_10(NossoNumero + AgenciaCedente + ContaCedente);
        DigVerificador = Mod_11(IdentBanco + CodMoeda + FatorVencimento + Valor + AgenciaCedente + ContaCedente + Digitao + NossoNumero);
        NumBoleto = IdentBanco + CodMoeda + DigVerificador + FatorVencimento + Valor + AgenciaCedente + ContaCedente + Digitao + NossoNumero;
        return NumBoleto;
    }
    private static string GeraNumeroDigitavelBancoReal(string IdentBanco, string CodMoeda, string Vencimento, string Valor, string AgenciaCedente, string Carteira, string NossoNumero, string ContaCedente)
    {
        string DigVerificador, Zero, FatorVencimento;
        string Campo1, Campo2, Campo3, Campo5, CampoLivre;
        DateTime DataVencimento, DataInicio;
        string NumBoleto = "";
        IdentBanco = AcrescentaZeros(IdentBanco, 3);
        CodMoeda = "9";
        Vencimento = Vencimento;
        Valor = AcrescentaZeros(Cs_Mascara.ParaValor(Valor), 10);
        AgenciaCedente = AcrescentaZeros(AgenciaCedente, 4);
        Carteira = AcrescentaZeros(Carteira, 2);
        NossoNumero = AcrescentaZeros(NossoNumero, 13);
        ContaCedente = AcrescentaZeros(ContaCedente, 7);
        Zero = "0";
        string Digitao = Mod_10(NossoNumero + AgenciaCedente + ContaCedente);
        CampoLivre = AgenciaCedente + ContaCedente + Digitao + NossoNumero;
        DataInicio = Convert.ToDateTime("07/10/1997");
        DataVencimento = Convert.ToDateTime(Vencimento);

        FatorVencimento = Convert.ToString(DataVencimento.Date - DataInicio.Date).Replace(".00:00:00", "");

        DigVerificador = Mod_11(IdentBanco + CodMoeda + FatorVencimento + Valor + AgenciaCedente + ContaCedente + Digitao + NossoNumero);

        Campo1 = IdentBanco + CodMoeda + CampoLivre.Substring(0, 5) + Mod_10(IdentBanco + CodMoeda + CampoLivre.Substring(0, 5));
        Campo2 = CampoLivre.Substring(5, 10) + Mod_10(CampoLivre.Substring(5, 10));
        Campo3 = CampoLivre.Substring(15, 10) + Mod_10(CampoLivre.Substring(15, 10));
        Campo5 = FatorVencimento + Valor;

        NumBoleto += Campo1.Substring(0, 5) + '.' + Campo1.Substring(5, 5) + " ";
        NumBoleto += Campo2.Substring(0, 5) + '.' + Campo2.Substring(5, 6) + " ";
        NumBoleto += Campo3.Substring(0, 5) + '.' + Campo3.Substring(5, 6) + " ";
        NumBoleto += DigVerificador + " ";
        NumBoleto += Campo5;

        return NumBoleto;
    }
    private static string GeraCodigoBarraBancoReal(string Codigo_Bara_Numero)
    {
        string Codigo_Barra = null;
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=1 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=1 />";
        //Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
        //Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=3 />";
        //Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=3 />";
        //Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=3 />";
        string Codigo_Bara_Faixas = "", Primeiro = "", Segundo = "";

        int i, j;

        for (i = 0; i < Codigo_Bara_Numero.Length; i++)
        {

            if (i % 2 == 0)
            {
                switch (Convert.ToInt32(Codigo_Bara_Numero[i].ToString()))
                {
                    case 0:
                        Primeiro = "00110";
                        break;
                    case 1:
                        Primeiro = "10001";
                        break;
                    case 2:
                        Primeiro = "01001";
                        break;
                    case 3:
                        Primeiro = "11000";
                        break;
                    case 4:
                        Primeiro = "00101";
                        break;
                    case 5:
                        Primeiro = "10100";
                        break;
                    case 6:
                        Primeiro = "01100";
                        break;
                    case 7:
                        Primeiro = "00011";
                        break;
                    case 8:
                        Primeiro = "10010";
                        break;
                    case 9:
                        Primeiro = "01010";
                        break;
                }
            }
            else
            {
                switch (Convert.ToInt32(Codigo_Bara_Numero[i].ToString()))
                {
                    case 0:
                        Segundo = "00110";
                        break;
                    case 1:
                        Segundo = "10001";
                        break;
                    case 2:
                        Segundo = "01001";
                        break;
                    case 3:
                        Segundo = "11000";
                        break;
                    case 4:
                        Segundo = "00101";
                        break;
                    case 5:
                        Segundo = "10100";
                        break;
                    case 6:
                        Segundo = "01100";
                        break;
                    case 7:
                        Segundo = "00011";
                        break;
                    case 8:
                        Segundo = "10010";
                        break;
                    case 9:
                        Segundo = "01010";
                        break;
                }
            }

            if ((Primeiro.Length != 0) && (Segundo.Length != 0))
            {
                for (j = 0; j < Segundo.Length; j++)
                {
                    Codigo_Bara_Faixas += Primeiro[j].ToString();
                    Codigo_Bara_Faixas += Segundo[j].ToString();
                }
                Primeiro = "";
                Segundo = "";
            }
        }
        //Response.Write(Codigo_Bara_Faixas);
        for (i = 0; i < Codigo_Bara_Faixas.Length; i += 2)
        {
            if (Codigo_Bara_Faixas[i].ToString() == "0")
                Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
            else
                Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=3 />";

            if (Codigo_Bara_Faixas[i + 1].ToString() == "0")
                Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=1 />";
            else
                Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=3 />";

        }
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=3 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=1 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";

        return Codigo_Barra;
    }
    
    //Banco Bradesco
    private static string GeraNumeroCodigoBarraBradesco(string IdentBanco, string CodMoeda, string Vencimento, string Valor, string AgenciaCedente, string Carteira, string NossoNumero, string ContaCedente)
    {
        string DigVerificador, Zero, FatorVencimento;
        DateTime DataVencimento, DataInicio;
        string NumBoleto = "";
        IdentBanco = AcrescentaZeros(IdentBanco, 3);
        CodMoeda = "9";
        Vencimento = Vencimento;
        Valor = AcrescentaZeros(Cs_Mascara.ParaValor(Valor), 10);
        AgenciaCedente = AcrescentaZeros(AgenciaCedente, 4);
        Carteira = AcrescentaZeros(Carteira, 2);
        NossoNumero = AcrescentaZeros(NossoNumero, 11);
        ContaCedente = AcrescentaZeros(ContaCedente, 7);
        Zero = "0";

        DataInicio = Convert.ToDateTime("07/10/1997");
        DataVencimento = Convert.ToDateTime(Vencimento);

        FatorVencimento = Convert.ToString(DataVencimento.Date - DataInicio.Date).Replace(".00:00:00", "");

        DigVerificador = Mod_11(IdentBanco + CodMoeda + FatorVencimento + Valor + AgenciaCedente + Carteira + NossoNumero + ContaCedente + Zero);
        NumBoleto = IdentBanco + CodMoeda + DigVerificador + FatorVencimento + Valor + AgenciaCedente + Carteira + NossoNumero + ContaCedente + Zero;
        return NumBoleto;
    }
    private static string GeraNumeroDigitavelBradesco(string IdentBanco, string CodMoeda, string Vencimento, string Valor, string AgenciaCedente, string Carteira, string NossoNumero, string ContaCedente)
    {
        string DigVerificador, Zero, FatorVencimento;
        string Campo1, Campo2, Campo3, Campo5, CampoLivre;
        DateTime DataVencimento, DataInicio;
        string NumBoleto = "";
        IdentBanco = AcrescentaZeros(IdentBanco, 3);
        CodMoeda = "9";
        Vencimento = Vencimento;
        Valor = AcrescentaZeros(Cs_Mascara.ParaValor(Valor), 10);
        AgenciaCedente = AcrescentaZeros(AgenciaCedente, 4);
        Carteira = AcrescentaZeros(Carteira, 2);
        NossoNumero = AcrescentaZeros(NossoNumero, 11);
        ContaCedente = AcrescentaZeros(ContaCedente, 7);
        Zero = "0";
        CampoLivre = AgenciaCedente + Carteira + NossoNumero + ContaCedente + Zero;
        DataInicio = Convert.ToDateTime("07/10/1997");
        DataVencimento = Convert.ToDateTime(Vencimento);

        FatorVencimento = Convert.ToString(DataVencimento.Date - DataInicio.Date).Replace(".00:00:00", "");

        DigVerificador = Mod_11(IdentBanco + CodMoeda + FatorVencimento + Valor + AgenciaCedente + Carteira + NossoNumero + ContaCedente + Zero);

        Campo1 = IdentBanco + CodMoeda + CampoLivre.Substring(0, 5) + Mod_10(IdentBanco + CodMoeda + CampoLivre.Substring(0, 5));
        Campo2 = CampoLivre.Substring(5, 10) + Mod_10(CampoLivre.Substring(5, 10));
        Campo3 = CampoLivre.Substring(15, 10) + Mod_10(CampoLivre.Substring(15, 10));
        Campo5 = FatorVencimento + Valor;

        NumBoleto += Campo1.Substring(0, 5) + '.' + Campo1.Substring(5, 5) + " ";
        NumBoleto += Campo2.Substring(0, 5) + '.' + Campo2.Substring(5, 6) + " ";
        NumBoleto += Campo3.Substring(0, 5) + '.' + Campo3.Substring(5, 6) + " ";
        NumBoleto += DigVerificador + " ";
        NumBoleto += Campo5;

        return NumBoleto;
    }
    private static string GeraCodigoBarraBradesco(string Codigo_Bara_Numero)
    {
        string Codigo_Barra = null;
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=1 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=1 />";
        //Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
        //Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=3 />";
        //Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=3 />";
        //Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=3 />";
        string Codigo_Bara_Faixas = "", Primeiro = "", Segundo = "";

        int i, j;

        for (i = 0; i < Codigo_Bara_Numero.Length; i++)
        {

            if (i % 2 == 0)
            {
                switch (Convert.ToInt32(Codigo_Bara_Numero[i].ToString()))
                {
                    case 0:
                        Primeiro = "00110";
                        break;
                    case 1:
                        Primeiro = "10001";
                        break;
                    case 2:
                        Primeiro = "01001";
                        break;
                    case 3:
                        Primeiro = "11000";
                        break;
                    case 4:
                        Primeiro = "00101";
                        break;
                    case 5:
                        Primeiro = "10100";
                        break;
                    case 6:
                        Primeiro = "01100";
                        break;
                    case 7:
                        Primeiro = "00011";
                        break;
                    case 8:
                        Primeiro = "10010";
                        break;
                    case 9:
                        Primeiro = "01010";
                        break;
                }
            }
            else
            {
                switch (Convert.ToInt32(Codigo_Bara_Numero[i].ToString()))
                {
                    case 0:
                        Segundo = "00110";
                        break;
                    case 1:
                        Segundo = "10001";
                        break;
                    case 2:
                        Segundo = "01001";
                        break;
                    case 3:
                        Segundo = "11000";
                        break;
                    case 4:
                        Segundo = "00101";
                        break;
                    case 5:
                        Segundo = "10100";
                        break;
                    case 6:
                        Segundo = "01100";
                        break;
                    case 7:
                        Segundo = "00011";
                        break;
                    case 8:
                        Segundo = "10010";
                        break;
                    case 9:
                        Segundo = "01010";
                        break;
                }
            }

            if ((Primeiro.Length != 0) && (Segundo.Length != 0))
            {
                for (j = 0; j < Segundo.Length; j++)
                {
                    Codigo_Bara_Faixas += Primeiro[j].ToString();
                    Codigo_Bara_Faixas += Segundo[j].ToString();
                }
                Primeiro = "";
                Segundo = "";
            }
        }
        //Response.Write(Codigo_Bara_Faixas);
        for (i = 0; i < Codigo_Bara_Faixas.Length; i += 2)
        {
            if (Codigo_Bara_Faixas[i].ToString() == "0")
                Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
            else
                Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=3 />";

            if (Codigo_Bara_Faixas[i + 1].ToString() == "0")
                Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=1 />";
            else
                Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=3 />";

        }
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=3 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=1 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";

        return Codigo_Barra;
    }

    //Banco Bradesco Ibi
    private static string GeraNumeroCodigoBarraBradescoIbi(string IdentBanco, string CodMoeda, string Vencimento, string Valor, string AgenciaCedente, string Carteira, string NossoNumero, string ContaCedente)
    {
        string DigVerificador, Zero, FatorVencimento;
        DateTime DataVencimento, DataInicio;
        string NumBoleto = "";
        IdentBanco = AcrescentaZeros(IdentBanco, 3);
        CodMoeda = "9";
        Vencimento = Vencimento;
        Valor = AcrescentaZeros(Cs_Mascara.ParaValor(Valor), 10);
        AgenciaCedente = AcrescentaZeros(AgenciaCedente, 4);
        Carteira = AcrescentaZeros(Carteira, 2);
        NossoNumero = AcrescentaZeros(NossoNumero, 13);
        ContaCedente = "12345";
        Zero = "0";

        DataInicio = Convert.ToDateTime("07/10/1997");
        DataVencimento = Convert.ToDateTime(Vencimento);

        FatorVencimento = Convert.ToString(DataVencimento.Date - DataInicio.Date).Replace(".00:00:00", "");

        DigVerificador = Mod_11(IdentBanco + CodMoeda + FatorVencimento + Valor + AgenciaCedente + Carteira + NossoNumero + ContaCedente + Zero);
        NumBoleto = IdentBanco + CodMoeda + DigVerificador + FatorVencimento + Valor + AgenciaCedente + Carteira + NossoNumero + ContaCedente + Zero;
        return NumBoleto;
    }
    private static string GeraNumeroDigitavelBradescoIbi(string IdentBanco, string CodMoeda, string Vencimento, string Valor, string AgenciaCedente, string Carteira, string NossoNumero, string ContaCedente)
    {
        string DigVerificador, Zero, FatorVencimento;
        string Campo1, Campo2, Campo3, Campo5, CampoLivre;
        DateTime DataVencimento, DataInicio;
        string NumBoleto = "";
        IdentBanco = AcrescentaZeros(IdentBanco, 3);
        CodMoeda = "9";
        Vencimento = Vencimento;
        Valor = AcrescentaZeros(Cs_Mascara.ParaValor(Valor), 10);
        AgenciaCedente = AcrescentaZeros(AgenciaCedente, 4);
        Carteira = AcrescentaZeros(Carteira, 2);
        NossoNumero = AcrescentaZeros(NossoNumero, 13);
        ContaCedente = "12345";
        Zero = "0";
        CampoLivre = AgenciaCedente + Carteira + NossoNumero + ContaCedente + Zero;
        DataInicio = Convert.ToDateTime("07/10/1997");
        DataVencimento = Convert.ToDateTime(Vencimento);

        FatorVencimento = Convert.ToString(DataVencimento.Date - DataInicio.Date).Replace(".00:00:00", "");

        DigVerificador = Mod_11(IdentBanco + CodMoeda + FatorVencimento + Valor + AgenciaCedente + Carteira + NossoNumero + ContaCedente + Zero);

        Campo1 = IdentBanco + CodMoeda + CampoLivre.Substring(0, 5) + Mod_10(IdentBanco + CodMoeda + CampoLivre.Substring(0, 5));
        Campo2 = CampoLivre.Substring(5, 10) + Mod_10(CampoLivre.Substring(5, 10));
        Campo3 = CampoLivre.Substring(15, 10) + Mod_10(CampoLivre.Substring(15, 10));
        Campo5 = FatorVencimento + Valor;

        NumBoleto += Campo1.Substring(0, 5) + '.' + Campo1.Substring(5, 5) + " ";
        NumBoleto += Campo2.Substring(0, 5) + '.' + Campo2.Substring(5, 6) + " ";
        NumBoleto += Campo3.Substring(0, 5) + '.' + Campo3.Substring(5, 6) + " ";
        NumBoleto += DigVerificador + " ";
        NumBoleto += Campo5;

        return NumBoleto;
    }
    private static string GeraCodigoBarraBradescoIbi(string Codigo_Bara_Numero)
    {
        string Codigo_Barra = null;
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=1 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=1 />";
        //Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
        //Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=3 />";
        //Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=3 />";
        //Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=3 />";
        string Codigo_Bara_Faixas = "", Primeiro = "", Segundo = "";

        int i, j;

        for (i = 0; i < Codigo_Bara_Numero.Length; i++)
        {

            if (i % 2 == 0)
            {
                switch (Convert.ToInt32(Codigo_Bara_Numero[i].ToString()))
                {
                    case 0:
                        Primeiro = "00110";
                        break;
                    case 1:
                        Primeiro = "10001";
                        break;
                    case 2:
                        Primeiro = "01001";
                        break;
                    case 3:
                        Primeiro = "11000";
                        break;
                    case 4:
                        Primeiro = "00101";
                        break;
                    case 5:
                        Primeiro = "10100";
                        break;
                    case 6:
                        Primeiro = "01100";
                        break;
                    case 7:
                        Primeiro = "00011";
                        break;
                    case 8:
                        Primeiro = "10010";
                        break;
                    case 9:
                        Primeiro = "01010";
                        break;
                }
            }
            else
            {
                switch (Convert.ToInt32(Codigo_Bara_Numero[i].ToString()))
                {
                    case 0:
                        Segundo = "00110";
                        break;
                    case 1:
                        Segundo = "10001";
                        break;
                    case 2:
                        Segundo = "01001";
                        break;
                    case 3:
                        Segundo = "11000";
                        break;
                    case 4:
                        Segundo = "00101";
                        break;
                    case 5:
                        Segundo = "10100";
                        break;
                    case 6:
                        Segundo = "01100";
                        break;
                    case 7:
                        Segundo = "00011";
                        break;
                    case 8:
                        Segundo = "10010";
                        break;
                    case 9:
                        Segundo = "01010";
                        break;
                }
            }

            if ((Primeiro.Length != 0) && (Segundo.Length != 0))
            {
                for (j = 0; j < Segundo.Length; j++)
                {
                    Codigo_Bara_Faixas += Primeiro[j].ToString();
                    Codigo_Bara_Faixas += Segundo[j].ToString();
                }
                Primeiro = "";
                Segundo = "";
            }
        }
        //Response.Write(Codigo_Bara_Faixas);
        for (i = 0; i < Codigo_Bara_Faixas.Length; i += 2)
        {
            if (Codigo_Bara_Faixas[i].ToString() == "0")
                Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
            else
                Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=3 />";

            if (Codigo_Bara_Faixas[i + 1].ToString() == "0")
                Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=1 />";
            else
                Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=3 />";

        }
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=3 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=1 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";

        return Codigo_Barra;
    }

    //Banco PanAmericano
    private static string GeraNumeroCodigoBarraPanAmericano(string IdentBanco, string CodMoeda, string Vencimento, string Valor, string AgenciaCedente, string Carteira, string NossoNumero, string ContaCedente)
    {
        string DigVerificador, Zero, FatorVencimento;
        DateTime DataVencimento, DataInicio;
        string NumBoleto = "";
        IdentBanco = AcrescentaZeros(IdentBanco, 3);
        CodMoeda = "9";
        Vencimento = Vencimento;
        Valor = AcrescentaZeros(Cs_Mascara.ParaValor(Valor), 10);
        AgenciaCedente = AcrescentaZeros(AgenciaCedente, 4);
        Carteira = AcrescentaZeros(Carteira, 3);
        NossoNumero = AcrescentaZeros(NossoNumero, 10);
        ContaCedente = AcrescentaZeros(ContaCedente, 6);
        Zero = "0";

        DataInicio = Convert.ToDateTime("07/10/1997");
        DataVencimento = Convert.ToDateTime(Vencimento);

        FatorVencimento = Convert.ToString(DataVencimento.Date - DataInicio.Date).Replace(".00:00:00", "");

        DigVerificador = Mod_11(IdentBanco + CodMoeda + FatorVencimento + Valor + AgenciaCedente + Carteira + "0" + ContaCedente + NossoNumero + Mod_10(AgenciaCedente + Carteira + NossoNumero));

        NumBoleto = IdentBanco + CodMoeda + DigVerificador + FatorVencimento + Valor + AgenciaCedente + Carteira + "0" + ContaCedente + NossoNumero + Mod_10(AgenciaCedente + Carteira + NossoNumero);
        return NumBoleto;
    }
    private static string GeraNumeroDigitavelPanAmericano(string IdentBanco, string CodMoeda, string Vencimento, string Valor, string AgenciaCedente, string Carteira, string NossoNumero, string ContaCedente)
    {
        string DigVerificador, Zero, FatorVencimento;
        string Campo1, Campo2, Campo3, Campo5, CampoLivre;
        DateTime DataVencimento, DataInicio;
        string NumBoleto = "";
        IdentBanco = AcrescentaZeros(IdentBanco, 3);
        CodMoeda = "9";
        Vencimento = Vencimento;
        Valor = AcrescentaZeros(Cs_Mascara.ParaValor(Valor), 10);
        AgenciaCedente = AcrescentaZeros(AgenciaCedente, 4);
        Carteira = AcrescentaZeros(Carteira, 3);
        NossoNumero = AcrescentaZeros(NossoNumero, 10);
        ContaCedente = AcrescentaZeros(ContaCedente, 6);
        Zero = "0";
        CampoLivre = AgenciaCedente + Carteira + "0" + ContaCedente + NossoNumero + Mod_10(AgenciaCedente + Carteira + NossoNumero);
        DataInicio = Convert.ToDateTime("07/10/1997");
        DataVencimento = Convert.ToDateTime(Vencimento);

        FatorVencimento = Convert.ToString(DataVencimento.Date - DataInicio.Date).Replace(".00:00:00", "");

        DigVerificador = Mod_11(IdentBanco + CodMoeda + FatorVencimento + Valor + AgenciaCedente + Carteira + "0" + ContaCedente + NossoNumero + Mod_10(AgenciaCedente + Carteira + NossoNumero));

        Campo1 = IdentBanco + CodMoeda + CampoLivre.Substring(0, 5) + Mod_10(IdentBanco + CodMoeda + CampoLivre.Substring(0, 5));
        Campo2 = CampoLivre.Substring(5, 10) + Mod_10(CampoLivre.Substring(5, 10));
        Campo3 = CampoLivre.Substring(15, 10) + Mod_10(CampoLivre.Substring(15, 10));
        Campo5 = FatorVencimento + Valor;

        NumBoleto += Campo1.Substring(0, 5) + '.' + Campo1.Substring(5, 5) + " ";
        NumBoleto += Campo2.Substring(0, 5) + '.' + Campo2.Substring(5, 6) + " ";
        NumBoleto += Campo3.Substring(0, 5) + '.' + Campo3.Substring(5, 6) + " ";
        NumBoleto += DigVerificador + " ";
        NumBoleto += Campo5;

        return NumBoleto;
    }
    private static string GeraCodigoBarraPanAmericano(string Codigo_Bara_Numero)
    {
        string Codigo_Barra = null;
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=1 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=1 />";
        //Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
        //Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=3 />";
        //Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=3 />";
        //Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=3 />";
        string Codigo_Bara_Faixas = "", Primeiro = "", Segundo = "";

        int i, j;

        for (i = 0; i < Codigo_Bara_Numero.Length; i++)
        {

            if (i % 2 == 0)
            {
                switch (Convert.ToInt32(Codigo_Bara_Numero[i].ToString()))
                {
                    case 0:
                        Primeiro = "00110";
                        break;
                    case 1:
                        Primeiro = "10001";
                        break;
                    case 2:
                        Primeiro = "01001";
                        break;
                    case 3:
                        Primeiro = "11000";
                        break;
                    case 4:
                        Primeiro = "00101";
                        break;
                    case 5:
                        Primeiro = "10100";
                        break;
                    case 6:
                        Primeiro = "01100";
                        break;
                    case 7:
                        Primeiro = "00011";
                        break;
                    case 8:
                        Primeiro = "10010";
                        break;
                    case 9:
                        Primeiro = "01010";
                        break;
                }
            }
            else
            {
                switch (Convert.ToInt32(Codigo_Bara_Numero[i].ToString()))
                {
                    case 0:
                        Segundo = "00110";
                        break;
                    case 1:
                        Segundo = "10001";
                        break;
                    case 2:
                        Segundo = "01001";
                        break;
                    case 3:
                        Segundo = "11000";
                        break;
                    case 4:
                        Segundo = "00101";
                        break;
                    case 5:
                        Segundo = "10100";
                        break;
                    case 6:
                        Segundo = "01100";
                        break;
                    case 7:
                        Segundo = "00011";
                        break;
                    case 8:
                        Segundo = "10010";
                        break;
                    case 9:
                        Segundo = "01010";
                        break;
                }
            }

            if ((Primeiro.Length != 0) && (Segundo.Length != 0))
            {
                for (j = 0; j < Segundo.Length; j++)
                {
                    Codigo_Bara_Faixas += Primeiro[j].ToString();
                    Codigo_Bara_Faixas += Segundo[j].ToString();
                }
                Primeiro = "";
                Segundo = "";
            }
        }
        //Response.Write(Codigo_Bara_Faixas);
        for (i = 0; i < Codigo_Bara_Faixas.Length; i += 2)
        {
            if (Codigo_Bara_Faixas[i].ToString() == "0")
                Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
            else
                Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=3 />";

            if (Codigo_Bara_Faixas[i + 1].ToString() == "0")
                Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=1 />";
            else
                Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=3 />";

        }
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=3 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=1 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";

        return Codigo_Barra;
    }

    //Banco ITAU
    private static string GeraNumeroCodigoBarraItau(string IdentBanco, string CodMoeda, string Vencimento, string Valor, string AgenciaCedente, string Carteira, string NossoNumero, string ContaCedente)
    {
        string DigVerificador, Zero, FatorVencimento;
        DateTime DataVencimento, DataInicio;
        string NumBoleto = "";
        IdentBanco = AcrescentaZeros(IdentBanco, 3);
        CodMoeda = "9";
        Vencimento = Vencimento;
        Valor = AcrescentaZeros(Cs_Mascara.ParaValor(Valor), 10);
        AgenciaCedente = AcrescentaZeros(AgenciaCedente, 4);
        Carteira = AcrescentaZeros(Carteira, 3);
        NossoNumero = AcrescentaZeros(Convert.ToInt64(NossoNumero).ToString(), 8);
        ContaCedente = AcrescentaZeros(ContaCedente, 5);
        Zero = "000";

        DataInicio = Convert.ToDateTime("07/10/1997");
        DataVencimento = Convert.ToDateTime(Vencimento);

        FatorVencimento = AcrescentaZeros(Convert.ToString(DataVencimento.Date - DataInicio.Date).Replace(".00:00:00", ""), 4);

        string DigVerificadorACCNN = Mod_10(AgenciaCedente + ContaCedente + Carteira + NossoNumero);
        string DigVerificadorAC = Mod_10(AgenciaCedente + ContaCedente);

        DigVerificador = Mod_11(IdentBanco + CodMoeda + FatorVencimento + Valor + Carteira + NossoNumero + DigVerificadorACCNN + AgenciaCedente + ContaCedente + DigVerificadorAC + Zero);
        NumBoleto = IdentBanco + CodMoeda + DigVerificador + FatorVencimento + Valor + Carteira + NossoNumero + DigVerificadorACCNN + AgenciaCedente + ContaCedente + DigVerificadorAC + Zero;
        return NumBoleto;
    }
    private static string GeraNumeroCodigoBarraItau(string LinhaDigitavel)
    {
        string[] Blocos = SepararBlocosCodigoBarras(LinhaDigitavel);
        string IdentBanco = Blocos[0].Substring(0, 3);
        string CodMoeda = Blocos[0].Substring(3, 1);
        string Vencimento = new DateTime(1997, 10, 7).AddDays(Convert.ToInt16(Blocos[8])).ToShortDateString();
        string Valor = (Convert.ToDecimal(Blocos[9]) / 100).ToString();
        string AgenciaCedente = Blocos[3].Substring(7, 3) + Blocos[5].Substring(0, 1);
        string NossoNumero = Blocos[1] + Blocos[3].Substring(0, 7);
        //string NossoNumero = Blocos[1] + Blocos[3].Substring(0, 6);
        string ContaCedente = Blocos[5].Substring(1, 5);

        List<string> CarteirasExcecao = new List<string>();

        CarteirasExcecao.Add("126");
        CarteirasExcecao.Add("131");
        CarteirasExcecao.Add("146");
        CarteirasExcecao.Add("150");
        CarteirasExcecao.Add("168");
        CarteirasExcecao.Add("880");

        string DigVerificador, Zero, FatorVencimento;
        DateTime DataVencimento, DataInicio;
        string NumBoleto = "";
        IdentBanco = IdentBanco.PadLeft(3, '0');
        CodMoeda = "9";
        Valor = Convert.ToDecimal(Valor).ToString("0.00").Replace(",", "").Replace(".", "").PadLeft(10, '0');
        AgenciaCedente = AgenciaCedente.PadLeft(4, '0');
        NossoNumero = NossoNumero.PadLeft(8, '0');
        ContaCedente = ContaCedente.PadLeft(5, '0');
        Zero = "000";

        DataInicio = Convert.ToDateTime("07/10/1997");
        DataVencimento = Convert.ToDateTime(Vencimento);

        FatorVencimento = Convert.ToString(DataVencimento.Date - DataInicio.Date).Replace(".00:00:00", "").PadLeft(4, '0');

        string DigVerificadorAC = Mod_10(AgenciaCedente + ContaCedente);

        DigVerificador = Mod_11(IdentBanco + CodMoeda + FatorVencimento + Valor + NossoNumero + AgenciaCedente + ContaCedente + DigVerificadorAC + Zero);
        NumBoleto = IdentBanco + CodMoeda + DigVerificador + FatorVencimento + Valor + NossoNumero + AgenciaCedente + ContaCedente + DigVerificadorAC + Zero;
        return NumBoleto;
    }
    private static string GeraNossoNumeroItau(string LinhaDigitavel, string ParcAcordoId)
    {
        string[] Blocos = SepararBlocosCodigoBarras(LinhaDigitavel);
        string NossoNumero = Blocos[1].Substring(3) + Blocos[3].Substring(0, 6);

        GravaNossoNumero(NossoNumero, ParcAcordoId);

        return NossoNumero;
    }
    private static string GeraNumeroDigitavelItau(string IdentBanco, string CodMoeda, string Vencimento, string Valor, string AgenciaCedente, string Carteira, string NossoNumero, string ContaCedente)
    {
        string DigVerificador, Zero, FatorVencimento;
        string Campo1, Campo2, Campo3, Campo5, CampoLivre;
        DateTime DataVencimento, DataInicio;
        string NumBoleto = "";
        IdentBanco = AcrescentaZeros(IdentBanco, 3);
        CodMoeda = "9";
        Vencimento = Vencimento;
        Valor = AcrescentaZeros(Cs_Mascara.ParaValor(Valor), 10);
        AgenciaCedente = AcrescentaZeros(AgenciaCedente, 4);
        Carteira = AcrescentaZeros(Carteira, 3);
        NossoNumero = AcrescentaZeros(Convert.ToInt64(NossoNumero).ToString(), 8);
        ContaCedente = AcrescentaZeros(ContaCedente, 5);
        Zero = "000";

        //CampoLivre = AgenciaCedente + Carteira + NossoNumero + ContaCedente + Zero;
        DataInicio = Convert.ToDateTime("07/10/1997");
        DataVencimento = Convert.ToDateTime(Vencimento);

        FatorVencimento = Convert.ToString(DataVencimento.Date - DataInicio.Date).Replace(".00:00:00", "");

        string DigVerificadorACCNN = Mod_10(AgenciaCedente + ContaCedente + Carteira + NossoNumero);
        string DigVerificadorAC = Mod_10(AgenciaCedente + ContaCedente);
        DigVerificador = Mod_11(IdentBanco + CodMoeda + FatorVencimento + Valor + Carteira + NossoNumero + DigVerificadorACCNN + AgenciaCedente + ContaCedente + DigVerificadorAC + Zero);

        Campo1 = IdentBanco + CodMoeda + Carteira + NossoNumero.Substring(0, 2) + Mod_10(IdentBanco + CodMoeda + Carteira + NossoNumero.Substring(0, 2));
        Campo2 = NossoNumero.Substring(2, NossoNumero.Length - 2) + Mod_10(AgenciaCedente + ContaCedente + Carteira + NossoNumero) + AgenciaCedente.Substring(0, 3) + Mod_10(NossoNumero.Substring(2, NossoNumero.Length - 2) + Mod_10(AgenciaCedente + ContaCedente + Carteira + NossoNumero) + AgenciaCedente.Substring(0, 3));
        Campo3 = AgenciaCedente.Substring(3, 1) + ContaCedente + DigVerificadorAC + Zero + Mod_10(AgenciaCedente.Substring(3, 1) + ContaCedente + DigVerificadorAC + Zero);
        Campo5 = FatorVencimento + Valor;

        NumBoleto += Campo1.Substring(0, 5) + '.' + Campo1.Substring(5, 5) + " ";
        NumBoleto += Campo2.Substring(0, 5) + '.' + Campo2.Substring(5, 6) + " ";
        NumBoleto += Campo3.Substring(0, 5) + '.' + Campo3.Substring(5, 6) + " ";
        NumBoleto += DigVerificador + " ";
        NumBoleto += Campo5;

        return NumBoleto;
    }
    private static string GeraCodigoBarraItau(string Codigo_Bara_Numero)
    {
        string Codigo_Barra = null;
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=1 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=1 />";

        //Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
        //Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=3 />";
        //Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=3 />";
        //Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=3 />";
        string Codigo_Bara_Faixas = "", Primeiro = "", Segundo = "";

        int i, j;

        for (i = 0; i < Codigo_Bara_Numero.Length; i++)
        {

            if (i % 2 == 0)
            {
                switch (Convert.ToInt32(Codigo_Bara_Numero[i].ToString()))
                {
                    case 0:
                        Primeiro = "00110";
                        break;
                    case 1:
                        Primeiro = "10001";
                        break;
                    case 2:
                        Primeiro = "01001";
                        break;
                    case 3:
                        Primeiro = "11000";
                        break;
                    case 4:
                        Primeiro = "00101";
                        break;
                    case 5:
                        Primeiro = "10100";
                        break;
                    case 6:
                        Primeiro = "01100";
                        break;
                    case 7:
                        Primeiro = "00011";
                        break;
                    case 8:
                        Primeiro = "10010";
                        break;
                    case 9:
                        Primeiro = "01010";
                        break;
                }
            }
            else
            {
                switch (Convert.ToInt32(Codigo_Bara_Numero[i].ToString()))
                {
                    case 0:
                        Segundo = "00110";
                        break;
                    case 1:
                        Segundo = "10001";
                        break;
                    case 2:
                        Segundo = "01001";
                        break;
                    case 3:
                        Segundo = "11000";
                        break;
                    case 4:
                        Segundo = "00101";
                        break;
                    case 5:
                        Segundo = "10100";
                        break;
                    case 6:
                        Segundo = "01100";
                        break;
                    case 7:
                        Segundo = "00011";
                        break;
                    case 8:
                        Segundo = "10010";
                        break;
                    case 9:
                        Segundo = "01010";
                        break;
                }
            }

            if ((Primeiro.Length != 0) && (Segundo.Length != 0))
            {
                for (j = 0; j < Segundo.Length; j++)
                {
                    Codigo_Bara_Faixas += Primeiro[j].ToString();
                    Codigo_Bara_Faixas += Segundo[j].ToString();
                }
                Primeiro = "";
                Segundo = "";
            }
        }
        //Response.Write(Codigo_Bara_Faixas);
        for (i = 0; i < Codigo_Bara_Faixas.Length; i += 2)
        {
            if (Codigo_Bara_Faixas[i].ToString() == "0")
                Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
            else
                Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=3 />";

            if (Codigo_Bara_Faixas[i + 1].ToString() == "0")
                Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=1 />";
            else
                Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=3 />";

        }
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=3 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=1 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";

        return Codigo_Barra;
    }
    //Banco do Brasil
    #region Antigo
    /// <summary>
    /// Utilizado pela Telefonica
    /// </summary>
    private static string GeraNumeroCodigoBarraBrasil(string IdentBanco, string CodMoeda, string Vencimento, string Valor, string AgenciaCedente, string Carteira, string NossoNumero, string ContaCedente)
    {
        string DigVerificador, Zero, FatorVencimento;
        DateTime DataVencimento, DataInicio;
        string NumBoleto = "";
        IdentBanco = AcrescentaZeros(IdentBanco, 3);
        CodMoeda = "9";
        Vencimento = Vencimento;
        Valor = AcrescentaZeros(Cs_Mascara.ParaValor(Valor), 10);
        Carteira = AcrescentaZeros(Carteira, 2);
        if (NossoNumero.Length > 17)
            NossoNumero = NossoNumero.Substring(NossoNumero.Length - 17, 17);
        NossoNumero = AcrescentaZeros(NossoNumero, 17);
        Zero = "000000";
        DataInicio = Convert.ToDateTime("07/10/1997");
        DataVencimento = Convert.ToDateTime(Vencimento);

        FatorVencimento = AcrescentaZeros(Convert.ToString(DataVencimento.Date - DataInicio.Date).Replace(".00:00:00", ""), 4);

        DigVerificador = Mod_11(IdentBanco + CodMoeda + FatorVencimento + Valor + Zero + NossoNumero + Carteira);
        NumBoleto = IdentBanco + CodMoeda + DigVerificador + FatorVencimento + Valor + Zero + NossoNumero + Carteira;
        return NumBoleto;
    }
    /// <summary>
    /// Utilizado pela Telefonica
    /// </summary>
    private static string GeraNumeroDigitavelBrasil(string IdentBanco, string CodMoeda, string Vencimento, string Valor, string AgenciaCedente, string Carteira, string NossoNumero, string ContaCedente)
    {
        string Campo1, Campo2, Campo3, Campo5;
        string DigVerificador, Zero, FatorVencimento;
        DateTime DataVencimento, DataInicio;
        string NumBoleto = "";
        IdentBanco = AcrescentaZeros(IdentBanco, 3);
        CodMoeda = "9";
        Vencimento = Vencimento;
        Valor = AcrescentaZeros(Cs_Mascara.ParaValor(Valor), 10);
        Carteira = AcrescentaZeros(Carteira, 2);
        if (NossoNumero.Length > 17)
            NossoNumero = NossoNumero.Substring(NossoNumero.Length - 17, 17);
        Zero = "000000";
        DataInicio = Convert.ToDateTime("07/10/1997");
        DataVencimento = Convert.ToDateTime(Vencimento);

        FatorVencimento = AcrescentaZeros(Convert.ToString(DataVencimento.Date - DataInicio.Date).Replace(".00:00:00", ""), 4);

        DigVerificador = Mod_11(IdentBanco + CodMoeda + FatorVencimento + Valor + Zero + NossoNumero + Carteira);
        NumBoleto = IdentBanco + CodMoeda + DigVerificador + FatorVencimento + Valor + Zero + NossoNumero + Carteira;

        Campo1 = IdentBanco + CodMoeda + NumBoleto.Substring(19, 5) + Mod_10(IdentBanco + CodMoeda + NumBoleto.Substring(19, 5));
        Campo2 = NumBoleto.Substring(24, 10) + Mod_10(NumBoleto.Substring(24, 10));
        Campo3 = NumBoleto.Substring(34, 10) + Mod_10(NumBoleto.Substring(34, 10));
        Campo5 = FatorVencimento + Valor;

        NumBoleto = "";
        NumBoleto += Campo1.Substring(0, 5) + '.' + Campo1.Substring(5, 5) + " ";
        NumBoleto += Campo2.Substring(0, 5) + '.' + Campo2.Substring(5, 6) + " ";
        NumBoleto += Campo3.Substring(0, 5) + '.' + Campo3.Substring(5, 6) + " ";
        NumBoleto += DigVerificador + " ";
        NumBoleto += Campo5;

        return NumBoleto;
    }
    #endregion Antigo


    ///CONVENIO DE 06 POSIÇOES
    ///NOSSO NUMERO DE 17 POSIÇÕES
    ///CARTEIRAS DE 16 E 18
    ///EXCLUSIVO PARA COBRANÇAS SEM REGISTRO
    private static string GeraNumeroCodigoBarraBrasilConvenio06NossoNumero17(string IdentBanco, string CodMoeda, string Vencimento, string Valor, string AgenciaCedente, string Carteira, string NossoNumero, string ContaCedente, string NumeroConvenio)
    {
        string DigVerificador, FatorVencimento;
        DateTime DataVencimento, DataInicio;
        string NumBoleto = "";
        IdentBanco = AcrescentaZeros(IdentBanco, 3);
        CodMoeda = "9";

        Valor = AcrescentaZeros(Cs_Mascara.ParaValor(Valor), 10);
        Carteira = AcrescentaZeros(Carteira, 2);


        if (NossoNumero.Length != 17)
            return string.Empty;

        DataInicio = Convert.ToDateTime("07/10/1997");
        DataVencimento = Convert.ToDateTime(Vencimento);
        string Zero = "000000".PadLeft(6,'0');

        FatorVencimento = AcrescentaZeros(Convert.ToString(DataVencimento.Date - DataInicio.Date).Replace(".00:00:00", ""), 4);

        DigVerificador = Mod_11(IdentBanco + CodMoeda + FatorVencimento + Valor + Zero + NossoNumero + Carteira);
        //DigVerificador = Mod_11(IdentBanco + CodMoeda + FatorVencimento + Valor + NumeroConvenio.PadLeft(6, '0') + NossoNumero.PadLeft(17, '0') + Carteira.PadLeft(2, '0'));
        NumBoleto = IdentBanco + CodMoeda + DigVerificador + FatorVencimento + Valor + Zero + NossoNumero + Carteira;
        //NumBoleto = IdentBanco + CodMoeda + DigVerificador + FatorVencimento + Valor + NumeroConvenio.PadLeft(6, '0') + NossoNumero.PadLeft(17, '0') + Carteira.PadLeft(2, '0');
        return NumBoleto;
    }


    ///CONVENIO DE 06 POSIÇOES
    ///NOSSO NUMERO DE 17 POSIÇÕES
    ///CARTEIRAS DE 16 E 18
    ///EXCLUSIVO PARA COBRANÇAS SEM REGISTRO
    private static string GeraNumeroDigitavelBrasilConvenio06NossoNumero17(string IdentBanco, string CodMoeda, string Vencimento, string Valor, string AgenciaCedente, string Carteira, string NossoNumero, string ContaCedente, string NumeroConvenio)
    {
        string Campo1, Campo2, Campo3, Campo5;
        string DigVerificador, FatorVencimento;
        DateTime DataVencimento, DataInicio;
        string NumBoleto = "";
        IdentBanco = AcrescentaZeros(IdentBanco, 3);
        CodMoeda = "9";

        Valor = AcrescentaZeros(Cs_Mascara.ParaValor(Valor), 10);
        Carteira = AcrescentaZeros(Carteira, 2);


        if (NossoNumero.Length != 17)
            return string.Empty;

        DataInicio = Convert.ToDateTime("07/10/1997");
        DataVencimento = Convert.ToDateTime(Vencimento);
        string Zero = "000000".PadLeft(6,'0');

        FatorVencimento = AcrescentaZeros(Convert.ToString(DataVencimento.Date - DataInicio.Date).Replace(".00:00:00", ""), 4);

        DigVerificador = Mod_11(IdentBanco + CodMoeda + FatorVencimento + Valor + Zero + NossoNumero + Carteira);
        //DigVerificador = Mod_11(IdentBanco + CodMoeda + FatorVencimento + Valor + NumeroConvenio.PadLeft(6, '0') + NossoNumero.PadLeft(17, '0') + Carteira.PadLeft(2, '0'));
        NumBoleto = IdentBanco + CodMoeda + DigVerificador + FatorVencimento + Valor + Zero + NossoNumero + Carteira;
        //NumBoleto = IdentBanco + CodMoeda + DigVerificador + FatorVencimento + Valor + NumeroConvenio.PadLeft(6, '0') + NossoNumero.PadLeft(17, '0') + Carteira.PadLeft(2, '0');

        //Campo1 = IdentBanco + CodMoeda + NumBoleto.Substring(19, 5) + Mod_10(IdentBanco + CodMoeda + NumBoleto.Substring(19, 5));
        //Campo2 = NumBoleto.Substring(24, 10) + Mod_10(NumBoleto.Substring(24, 10));
        //Campo3 = NumBoleto.Substring(34, 10) + Mod_10(NumBoleto.Substring(34, 10));
        //Campo5 = FatorVencimento + Valor;

        Campo1 = IdentBanco + CodMoeda + NumBoleto.Substring(19, 5) + Mod_10(IdentBanco + CodMoeda + NumBoleto.Substring(19, 5));
        Campo2 = NumBoleto.Substring(24, 10) + Mod_10(NumBoleto.Substring(24, 10));
        Campo3 = NumBoleto.Substring(34, 10) + Mod_10(NumBoleto.Substring(34, 10));
        Campo5 = FatorVencimento + Valor;

        NumBoleto = "";
        NumBoleto += Campo1.Substring(0, 5) + '.' + Campo1.Substring(5, 5) + " ";
        NumBoleto += Campo2.Substring(0, 5) + '.' + Campo2.Substring(5, 6) + " ";
        NumBoleto += Campo3.Substring(0, 5) + '.' + Campo3.Substring(5, 6) + " ";
        NumBoleto += DigVerificador + " ";
        NumBoleto += Campo5;

        return NumBoleto;
    }

    

    public static string GeraDadosBoletoBbrasil(string Tipo, string IdentBanco, string CodMoeda, string Vencimento, string Valor, string AgenciaCedente, string Carteira, string NossoNumero, string ContaCedente, string CVT, string NumeroCliente, string NumeroConvenio)
    {
        //Boleto Banco do Brasil
        #region
        if (IdentBanco == "001")
        {
            /*VERIFICAR*/
            Carteira = "18";
            //Caso seja pedido o codigo de barras
            if (Tipo.ToUpper() == "CODIGO BARRA")
            {
                string NumeroCodigoBarras = string.Empty;
                NossoNumero = NossoNumero.PadLeft(10, '0');
                NumeroCodigoBarras = GeraNumeroCodigoBarraBrasilConvenio06NossoNumero17(IdentBanco, CodMoeda, Vencimento, Valor, AgenciaCedente, Carteira, NossoNumero, ContaCedente, NumeroConvenio);
                return GeraCodigoBarraBrasil(NumeroCodigoBarras);
            }
            //Caso seja pedido a Linha Digitavel
            if (Tipo.ToUpper() == "LINHA DIGITAVEL")
            {
                NossoNumero = NossoNumero.PadLeft(10, '0');
                return GeraNumeroDigitavelBrasilConvenio06NossoNumero17(IdentBanco, CodMoeda, Vencimento, Valor, AgenciaCedente, Carteira, NossoNumero, ContaCedente, NumeroConvenio);
            }
            if (Tipo.ToUpper() == "NUMERO CODIGO BARRA")
            {
                NossoNumero = NossoNumero.PadLeft(10, '0');
                return GeraNumeroCodigoBarraBrasilConvenio06NossoNumero17(IdentBanco, CodMoeda, Vencimento, Valor, AgenciaCedente, Carteira, NossoNumero, ContaCedente, NumeroConvenio);
            }
        }
        #endregion
        return "Tipo Não Confere";
    }


    private static string GeraCodigoBarraBrasil(string Codigo_Bara_Numero)
    {
        string Codigo_Barra = null;
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=1 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=1 />";

        //Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
        //Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=3 />";
        //Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=3 />";
        //Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=3 />";
        string Codigo_Bara_Faixas = "", Primeiro = "", Segundo = "";

        int i, j;

        for (i = 0; i < Codigo_Bara_Numero.Length; i++)
        {

            if (i % 2 == 0)
            {
                switch (Convert.ToInt32(Codigo_Bara_Numero[i].ToString()))
                {
                    case 0:
                        Primeiro = "00110";
                        break;
                    case 1:
                        Primeiro = "10001";
                        break;
                    case 2:
                        Primeiro = "01001";
                        break;
                    case 3:
                        Primeiro = "11000";
                        break;
                    case 4:
                        Primeiro = "00101";
                        break;
                    case 5:
                        Primeiro = "10100";
                        break;
                    case 6:
                        Primeiro = "01100";
                        break;
                    case 7:
                        Primeiro = "00011";
                        break;
                    case 8:
                        Primeiro = "10010";
                        break;
                    case 9:
                        Primeiro = "01010";
                        break;
                }
            }
            else
            {
                switch (Convert.ToInt32(Codigo_Bara_Numero[i].ToString()))
                {
                    case 0:
                        Segundo = "00110";
                        break;
                    case 1:
                        Segundo = "10001";
                        break;
                    case 2:
                        Segundo = "01001";
                        break;
                    case 3:
                        Segundo = "11000";
                        break;
                    case 4:
                        Segundo = "00101";
                        break;
                    case 5:
                        Segundo = "10100";
                        break;
                    case 6:
                        Segundo = "01100";
                        break;
                    case 7:
                        Segundo = "00011";
                        break;
                    case 8:
                        Segundo = "10010";
                        break;
                    case 9:
                        Segundo = "01010";
                        break;
                }
            }

            if ((Primeiro.Length != 0) && (Segundo.Length != 0))
            {
                for (j = 0; j < Segundo.Length; j++)
                {
                    Codigo_Bara_Faixas += Primeiro[j].ToString();
                    Codigo_Bara_Faixas += Segundo[j].ToString();
                }
                Primeiro = "";
                Segundo = "";
            }
        }
        //Response.Write(Codigo_Bara_Faixas);
        for (i = 0; i < Codigo_Bara_Faixas.Length; i += 2)
        {
            if (Codigo_Bara_Faixas[i].ToString() == "0")
                Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
            else
                Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=3 />";

            if (Codigo_Bara_Faixas[i + 1].ToString() == "0")
                Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=1 />";
            else
                Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=3 />";

        }
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=3 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=1 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";

        return Codigo_Barra;
    }

    //Banco do HSBC
    private static string GeraNumeroCodigoBarraHSBC(string IdentBanco, string CodMoeda, string Vencimento, string Valor, string AgenciaCedente, string Carteira, string NossoNumero, string ContaCedente)
    {
        string DigVerificador, Zero, FatorVencimento, DataJuliano;
        DateTime DataVencimento, DataInicio;
        string NumBoleto = "";
        IdentBanco = AcrescentaZeros(IdentBanco, 3);
        CodMoeda = "9";
        Vencimento = Vencimento;
        Valor = AcrescentaZeros(Cs_Mascara.ParaValor(Valor), 10);
        Carteira = AcrescentaZeros(Carteira, 2);
        if (NossoNumero.Length > 13)
            NossoNumero = NossoNumero.Substring(NossoNumero.Length - 13, 13);
        NossoNumero = AcrescentaZeros(NossoNumero, 13);
        DataInicio = Convert.ToDateTime("07/10/1997");
        DataVencimento = Convert.ToDateTime(Vencimento);

        DataJuliano = DataFormatoJuliano(Convert.ToDateTime(Vencimento), "4");

        FatorVencimento = AcrescentaZeros(Convert.ToString(DataVencimento.Date - DataInicio.Date).Replace(".00:00:00", ""), 4);

        DigVerificador = Mod_11(IdentBanco + CodMoeda + FatorVencimento + Valor + ContaCedente + NossoNumero + DataJuliano + "2");
        NumBoleto = IdentBanco + CodMoeda + DigVerificador + FatorVencimento + Valor + ContaCedente + NossoNumero + DataJuliano + "2";
        return NumBoleto;
    }
    private static string GeraNumeroDigitavelHSBC(string IdentBanco, string CodMoeda, string Vencimento, string Valor, string AgenciaCedente, string Carteira, string NossoNumero, string ContaCedente)
    {
        string Campo1, Campo2, Campo3, Campo5;
        string DigVerificador, Zero, FatorVencimento, DataJuliano;
        DateTime DataVencimento, DataInicio;
        string NumBoleto = "";
        IdentBanco = AcrescentaZeros(IdentBanco, 3);
        CodMoeda = "9";
        Vencimento = Vencimento;
        Valor = AcrescentaZeros(Cs_Mascara.ParaValor(Valor), 10);
        Carteira = AcrescentaZeros(Carteira, 2);
        if (NossoNumero.Length > 13)
            NossoNumero = NossoNumero.Substring(NossoNumero.Length - 13, 13);
        NossoNumero = AcrescentaZeros(NossoNumero, 13);
        DataInicio = Convert.ToDateTime("07/10/1997");
        DataVencimento = Convert.ToDateTime(Vencimento);

        DataJuliano = DataFormatoJuliano(Convert.ToDateTime(Vencimento), "4");

        FatorVencimento = AcrescentaZeros(Convert.ToString(DataVencimento.Date - DataInicio.Date).Replace(".00:00:00", ""), 4);

        DigVerificador = Mod_11(IdentBanco + CodMoeda + FatorVencimento + Valor + ContaCedente + NossoNumero + DataJuliano + "2");
        //NumBoleto = IdentBanco + CodMoeda + ContaCedente + NossoNumero + DataJuliano + "2" + DigVerificador + FatorVencimento + Valor;

        Campo1 = IdentBanco + CodMoeda + ContaCedente.Substring(0, 5);
        Campo2 = ContaCedente.Substring(5).Trim() + NossoNumero.Substring(0, 8);
        Campo3 = NossoNumero.Substring(8) + DataJuliano + "2";
        Campo5 = FatorVencimento + Valor;

        NumBoleto = "";
        NumBoleto += Campo1.Substring(0, 5) + '.' + Campo1.Substring(5) + Mod_10(Campo1) + " ";
        NumBoleto += Campo2.Substring(0, 5) + '.' + Campo2.Substring(5) + Mod_10(Campo2) + " ";
        NumBoleto += Campo3.Substring(0, 5) + '.' + Campo3.Substring(5) + Mod_10(Campo3) + " ";
        NumBoleto += DigVerificador + " ";
        NumBoleto += Campo5;

        return NumBoleto;
    }
    private static string GeraCodigoBarraHSBC(string Codigo_Bara_Numero)
    {
        string Codigo_Barra = null;
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=1 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=1 />";

        //Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
        //Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=3 />";
        //Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=3 />";
        //Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=3 />";
        string Codigo_Bara_Faixas = "", Primeiro = "", Segundo = "";

        int i, j;

        for (i = 0; i < Codigo_Bara_Numero.Length; i++)
        {

            if (i % 2 == 0)
            {
                switch (Convert.ToInt32(Codigo_Bara_Numero[i].ToString()))
                {
                    case 0:
                        Primeiro = "00110";
                        break;
                    case 1:
                        Primeiro = "10001";
                        break;
                    case 2:
                        Primeiro = "01001";
                        break;
                    case 3:
                        Primeiro = "11000";
                        break;
                    case 4:
                        Primeiro = "00101";
                        break;
                    case 5:
                        Primeiro = "10100";
                        break;
                    case 6:
                        Primeiro = "01100";
                        break;
                    case 7:
                        Primeiro = "00011";
                        break;
                    case 8:
                        Primeiro = "10010";
                        break;
                    case 9:
                        Primeiro = "01010";
                        break;
                }
            }
            else
            {
                switch (Convert.ToInt32(Codigo_Bara_Numero[i].ToString()))
                {
                    case 0:
                        Segundo = "00110";
                        break;
                    case 1:
                        Segundo = "10001";
                        break;
                    case 2:
                        Segundo = "01001";
                        break;
                    case 3:
                        Segundo = "11000";
                        break;
                    case 4:
                        Segundo = "00101";
                        break;
                    case 5:
                        Segundo = "10100";
                        break;
                    case 6:
                        Segundo = "01100";
                        break;
                    case 7:
                        Segundo = "00011";
                        break;
                    case 8:
                        Segundo = "10010";
                        break;
                    case 9:
                        Segundo = "01010";
                        break;
                }
            }

            if ((Primeiro.Length != 0) && (Segundo.Length != 0))
            {
                for (j = 0; j < Segundo.Length; j++)
                {
                    Codigo_Bara_Faixas += Primeiro[j].ToString();
                    Codigo_Bara_Faixas += Segundo[j].ToString();
                }
                Primeiro = "";
                Segundo = "";
            }
        }
        //Response.Write(Codigo_Bara_Faixas);
        for (i = 0; i < Codigo_Bara_Faixas.Length; i += 2)
        {
            if (Codigo_Bara_Faixas[i].ToString() == "0")
                Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
            else
                Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=3 />";

            if (Codigo_Bara_Faixas[i + 1].ToString() == "0")
                Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=1 />";
            else
                Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=3 />";

        }
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=3 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=1 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";

        return Codigo_Barra;
    }
    //Banco do Santander
    private static string GeraNumeroCodigoBarraSantander(string IdentBanco, string CodMoeda, string Vencimento, string Valor, string AgenciaCedente, string Carteira, string NossoNumero, string ContaCedente)
    {
        string DV, Zero, FatorVencimento, DataJuliano;
        DateTime DataVencimento, DataInicio;
        string NumBoleto = "";
        DataInicio = Convert.ToDateTime("07/10/1997");


        IdentBanco = AcrescentaZeros(IdentBanco, 3);
        CodMoeda = "9";
        //DV
        DataVencimento = Convert.ToDateTime(Vencimento);
        FatorVencimento = AcrescentaZeros(Convert.ToString(DataVencimento.Date - DataInicio.Date).Replace(".00:00:00", ""), 4);
        Valor = AcrescentaZeros(Cs_Mascara.ParaValor(Valor), 10);
        //9     - Fixo
        ContaCedente = AcrescentaZeros(ContaCedente, 7); //PSK
        NossoNumero += Mod_NossoNumeroSantander(NossoNumero);
        NossoNumero = AcrescentaZeros(NossoNumero, 13);
        //0     - IOS
        //102   - Cobrança Simples - Sem Registro

        DV = Mod_11Santander(IdentBanco + CodMoeda + FatorVencimento + Valor + "9" + ContaCedente + NossoNumero + "0" + "102");
        NumBoleto = IdentBanco + CodMoeda + DV + FatorVencimento + Valor + "9" + ContaCedente + NossoNumero + "0" + "102";
        return NumBoleto;
    }
    private static string GeraNumeroDigitavelSantander(string IdentBanco, string CodMoeda, string Vencimento, string Valor, string AgenciaCedente, string Carteira, string NossoNumero, string ContaCedente)
    {
        string Campo1, Campo2, Campo3, Campo5;
        string DV, Zero, FatorVencimento, DataJuliano;
        DateTime DataVencimento, DataInicio;
        string NumBoleto = "";
        DataInicio = Convert.ToDateTime("07/10/1997");

        IdentBanco = AcrescentaZeros(IdentBanco, 3);
        CodMoeda = "9";
        Valor = AcrescentaZeros(Cs_Mascara.ParaValor(Valor), 10);
        Carteira = AcrescentaZeros(Carteira, 2);
        NossoNumero += Mod_NossoNumeroSantander(NossoNumero);
        NossoNumero = AcrescentaZeros(NossoNumero, 13);
        ContaCedente = AcrescentaZeros(ContaCedente, 7);
        DataVencimento = Convert.ToDateTime(Vencimento);
        FatorVencimento = AcrescentaZeros(Convert.ToString(DataVencimento.Date - DataInicio.Date).Replace(".00:00:00", ""), 4);

        DV = Mod_11Santander(IdentBanco + CodMoeda + FatorVencimento + Valor + "9" + ContaCedente + NossoNumero + "0" + "102");
        //NumBoleto = IdentBanco + CodMoeda + ContaCedente + NossoNumero + DataJuliano + "2" + DigVerificador + FatorVencimento + Valor;

        Campo1 = IdentBanco + CodMoeda + "9" + ContaCedente.Substring(0, 4);
        Campo2 = ContaCedente.Substring(4).Trim() + NossoNumero.Substring(0, 7);
        Campo3 = NossoNumero.Substring(7) + "0" + "102";
        Campo5 = FatorVencimento + Valor;

        NumBoleto = "";
        NumBoleto += Campo1.Substring(0, 5) + '.' + Campo1.Substring(5) + Mod_10(Campo1) + " ";
        NumBoleto += Campo2.Substring(0, 5) + '.' + Campo2.Substring(5) + Mod_10(Campo2) + " ";
        NumBoleto += Campo3.Substring(0, 5) + '.' + Campo3.Substring(5) + Mod_10(Campo3) + " ";
        NumBoleto += DV + " ";
        NumBoleto += Campo5;

        return NumBoleto;
    }
    private static string GeraCodigoBarraSantander(string Codigo_Bara_Numero)
    {
        string Codigo_Barra = null;
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=1 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=1 />";

        //Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
        //Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=3 />";
        //Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=3 />";
        //Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=3 />";
        string Codigo_Bara_Faixas = "", Primeiro = "", Segundo = "";

        int i, j;

        for (i = 0; i < Codigo_Bara_Numero.Length; i++)
        {

            if (i % 2 == 0)
            {
                switch (Convert.ToInt32(Codigo_Bara_Numero[i].ToString()))
                {
                    case 0:
                        Primeiro = "00110";
                        break;
                    case 1:
                        Primeiro = "10001";
                        break;
                    case 2:
                        Primeiro = "01001";
                        break;
                    case 3:
                        Primeiro = "11000";
                        break;
                    case 4:
                        Primeiro = "00101";
                        break;
                    case 5:
                        Primeiro = "10100";
                        break;
                    case 6:
                        Primeiro = "01100";
                        break;
                    case 7:
                        Primeiro = "00011";
                        break;
                    case 8:
                        Primeiro = "10010";
                        break;
                    case 9:
                        Primeiro = "01010";
                        break;
                }
            }
            else
            {
                switch (Convert.ToInt32(Codigo_Bara_Numero[i].ToString()))
                {
                    case 0:
                        Segundo = "00110";
                        break;
                    case 1:
                        Segundo = "10001";
                        break;
                    case 2:
                        Segundo = "01001";
                        break;
                    case 3:
                        Segundo = "11000";
                        break;
                    case 4:
                        Segundo = "00101";
                        break;
                    case 5:
                        Segundo = "10100";
                        break;
                    case 6:
                        Segundo = "01100";
                        break;
                    case 7:
                        Segundo = "00011";
                        break;
                    case 8:
                        Segundo = "10010";
                        break;
                    case 9:
                        Segundo = "01010";
                        break;
                }
            }

            if ((Primeiro.Length != 0) && (Segundo.Length != 0))
            {
                for (j = 0; j < Segundo.Length; j++)
                {
                    Codigo_Bara_Faixas += Primeiro[j].ToString();
                    Codigo_Bara_Faixas += Segundo[j].ToString();
                }
                Primeiro = "";
                Segundo = "";
            }
        }
        //Response.Write(Codigo_Bara_Faixas);
        for (i = 0; i < Codigo_Bara_Faixas.Length; i += 2)
        {
            if (Codigo_Bara_Faixas[i].ToString() == "0")
                Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
            else
                Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=3 />";

            if (Codigo_Bara_Faixas[i + 1].ToString() == "0")
                Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=1 />";
            else
                Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=3 />";

        }
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=3 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=1 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";

        return Codigo_Barra;
    }
    public static string GeraCodigoBarraSantanderOY(string LinhaDigitavel)
    {
        string IdentBanco = LinhaDigitavel.Substring(0, 3);
        string CodMoeda = LinhaDigitavel.Substring(3, 1);
        string Fixo = LinhaDigitavel.Substring(4, 1);
        string ContaCedente = LinhaDigitavel.Substring(5, 4) + LinhaDigitavel.Substring(10, 3);
        string NossoNumero = LinhaDigitavel.Substring(13, 7) + LinhaDigitavel.Substring(21, 6);
        string Modalidade = LinhaDigitavel.Substring(27, 4);
        string DV = LinhaDigitavel.Substring(32, 1);
        string FatorValor = LinhaDigitavel.Substring(33);

        //NumBoleto = IdentBanco + CodMoeda + DV + FatorVencimento + Valor + "9" + ContaCedente + NossoNumero + "0" + "102";

        string Codigo_Barra = IdentBanco + CodMoeda + DV + FatorValor + Fixo + ContaCedente + NossoNumero + Modalidade;

        return GeraCodigoBarraSantander(Codigo_Barra);
    }
    //Banco do Citibank
    private static string GeraNumeroCodigoBarraCitibank(string IdentBanco, string CodMoeda, string Vencimento, string Valor, string AgenciaCedente, string Carteira, string NossoNumero, string ContaCedente)
    {
        string DV, Zero, FatorVencimento, DataJuliano;
        DateTime DataVencimento, DataInicio;
        string NumBoleto = "";
        DataInicio = Convert.ToDateTime("07/10/1997");


        IdentBanco = AcrescentaZeros(IdentBanco, 3);
        CodMoeda = "9";
        //DV
        DataVencimento = Convert.ToDateTime(Vencimento);
        FatorVencimento = AcrescentaZeros(Convert.ToString(DataVencimento.Date - DataInicio.Date).Replace(".00:00:00", ""), 4);
        Valor = AcrescentaZeros(Cs_Mascara.ParaValor(Valor), 10);
        //3     - Fixo
        //680   - Portfólio
        ContaCedente = AcrescentaZeros(ContaCedente, 9);
        NossoNumero = AcrescentaZeros(NossoNumero, 11) + Mod_11Citibank(AcrescentaZeros(NossoNumero, 11));

        //DV = Mod_11CitibankCodigoBarras(IdentBanco + CodMoeda + FatorVencimento + Valor + "3" + "680" + ContaCedente + NossoNumero);
        DV = Mod_11CitibankCodigoBarras(IdentBanco + CodMoeda + FatorVencimento + Valor + "368" + Cs_Acerta.AcrescentaZeros(ContaCedente, 10) + NossoNumero);
        NumBoleto = IdentBanco + CodMoeda + DV + FatorVencimento + Valor + "3" + "680" + ContaCedente + NossoNumero;
        return NumBoleto;
    }
    private static string GeraNumeroDigitavelCitibank(string IdentBanco, string CodMoeda, string Vencimento, string Valor, string AgenciaCedente, string Carteira, string NossoNumero, string ContaCedente)
    {
        string Campo1, Campo2, Campo3, Campo5;
        string DV, Zero, FatorVencimento, DataJuliano;
        DateTime DataVencimento, DataInicio;
        string NumBoleto = "";
        DataInicio = Convert.ToDateTime("07/10/1997");

        IdentBanco = AcrescentaZeros(IdentBanco, 3);
        CodMoeda = "9";
        //3 - Código do produto
        //680   - Portfólio
        ContaCedente = AcrescentaZeros(ContaCedente, 9);
        //DV
        Valor = AcrescentaZeros(Cs_Mascara.ParaValor(Valor), 10);
        NossoNumero = AcrescentaZeros(NossoNumero, 11) + Mod_11Citibank(AcrescentaZeros(NossoNumero, 11));

        DataVencimento = Convert.ToDateTime(Vencimento);
        FatorVencimento = AcrescentaZeros(Convert.ToString(DataVencimento.Date - DataInicio.Date).Replace(".00:00:00", ""), 4);

        DV = Mod_11CitibankCodigoBarras(IdentBanco + CodMoeda + FatorVencimento + Valor + "3" + "680" + ContaCedente + NossoNumero);
        //DV = Mod_11Santander(IdentBanco + CodMoeda + FatorVencimento + Valor + "9" + ContaCedente + NossoNumero + "0" + "102");

        Campo1 = IdentBanco + CodMoeda + "3" + "680" + ContaCedente.Substring(0, 1);
        Campo2 = ContaCedente.Substring(1).Trim() + NossoNumero.Substring(0, 2);
        Campo3 = NossoNumero.Substring(2);
        Campo5 = FatorVencimento + Valor;

        NumBoleto = "";
        NumBoleto += Campo1.Substring(0, 5) + '.' + Campo1.Substring(5) + Mod_10(Campo1) + " ";
        NumBoleto += Campo2.Substring(0, 5) + '.' + Campo2.Substring(5) + Mod_10(Campo2) + " ";
        NumBoleto += Campo3.Substring(0, 5) + '.' + Campo3.Substring(5) + Mod_10(Campo3) + " ";
        NumBoleto += DV + " ";
        NumBoleto += Campo5;

        return NumBoleto;
    }
    private static string GeraCodigoBarraCitibank(string Codigo_Bara_Numero)
    {
        string Codigo_Barra = null;
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=1 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=1 />";

        //Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
        //Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=3 />";
        //Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=3 />";
        //Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=3 />";
        string Codigo_Bara_Faixas = "", Primeiro = "", Segundo = "";

        int i, j;

        for (i = 0; i < Codigo_Bara_Numero.Length; i++)
        {

            if (i % 2 == 0)
            {
                switch (Convert.ToInt32(Codigo_Bara_Numero[i].ToString()))
                {
                    case 0:
                        Primeiro = "00110";
                        break;
                    case 1:
                        Primeiro = "10001";
                        break;
                    case 2:
                        Primeiro = "01001";
                        break;
                    case 3:
                        Primeiro = "11000";
                        break;
                    case 4:
                        Primeiro = "00101";
                        break;
                    case 5:
                        Primeiro = "10100";
                        break;
                    case 6:
                        Primeiro = "01100";
                        break;
                    case 7:
                        Primeiro = "00011";
                        break;
                    case 8:
                        Primeiro = "10010";
                        break;
                    case 9:
                        Primeiro = "01010";
                        break;
                }
            }
            else
            {
                switch (Convert.ToInt32(Codigo_Bara_Numero[i].ToString()))
                {
                    case 0:
                        Segundo = "00110";
                        break;
                    case 1:
                        Segundo = "10001";
                        break;
                    case 2:
                        Segundo = "01001";
                        break;
                    case 3:
                        Segundo = "11000";
                        break;
                    case 4:
                        Segundo = "00101";
                        break;
                    case 5:
                        Segundo = "10100";
                        break;
                    case 6:
                        Segundo = "01100";
                        break;
                    case 7:
                        Segundo = "00011";
                        break;
                    case 8:
                        Segundo = "10010";
                        break;
                    case 9:
                        Segundo = "01010";
                        break;
                }
            }

            if ((Primeiro.Length != 0) && (Segundo.Length != 0))
            {
                for (j = 0; j < Segundo.Length; j++)
                {
                    Codigo_Bara_Faixas += Primeiro[j].ToString();
                    Codigo_Bara_Faixas += Segundo[j].ToString();
                }
                Primeiro = "";
                Segundo = "";
            }
        }
        //Response.Write(Codigo_Bara_Faixas);
        for (i = 0; i < Codigo_Bara_Faixas.Length; i += 2)
        {
            if (Codigo_Bara_Faixas[i].ToString() == "0")
                Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
            else
                Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=3 />";

            if (Codigo_Bara_Faixas[i + 1].ToString() == "0")
                Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=1 />";
            else
                Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=3 />";

        }
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=3 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=1 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";

        return Codigo_Barra;
    }

    public static string GeraCodigoBarraDireto(string IdentBanco, string NumeroCodigoBarras)
    {
        switch (IdentBanco)
        { 
            case "237":
                return GeraCodigoBarraBradesco(NumeroCodigoBarras);
            case "399":
                return GeraCodigoBarraHSBC(NumeroCodigoBarras);
            default:
                return string.Empty;
        }
        //if (IdentBanco == "237")
        //{
        //    return GeraCodigoBarraBradesco(NumeroCodigoBarras);
        //}
        //return "";
    }

    //Geral do Boleto
    public static string GeraDadosBoleto(string Tipo, string IdentBanco, string CodMoeda, string Vencimento, string Valor, string AgenciaCedente, string Carteira, string NossoNumero, string ContaCedente)
    {
        //Boletos Banco Real
        #region
        if (IdentBanco == "356")
        {
            //Caso seja pedido o codigo de barras
            if (Tipo.ToUpper() == "CODIGO BARRA")
            {
                string NumeroCodigoBarras = GeraNumeroCodigoBarraBancoReal(IdentBanco, CodMoeda, Vencimento, Valor, AgenciaCedente, Carteira, NossoNumero, ContaCedente);
                return GeraCodigoBarraBancoReal(NumeroCodigoBarras);
            }
            //Caso seja pedido a Linha Digitavel
            if (Tipo.ToUpper() == "LINHA DIGITAVEL")
            {
                return GeraNumeroDigitavelBancoReal(IdentBanco, CodMoeda, Vencimento, Valor, AgenciaCedente, Carteira, NossoNumero, ContaCedente);
            }
            //Caso Seja pedido o numero do codigo de barras
            if (Tipo.ToUpper() == "NUMERO CODIGO BARRA")
            {
                return GeraNumeroCodigoBarraBancoReal(IdentBanco, CodMoeda, Vencimento, Valor, AgenciaCedente, Carteira, NossoNumero, ContaCedente);
            }
        }
        #endregion
        //Boletos Bradesco
        #region
        if (IdentBanco == "237")
        {
            //Caso seja pedido o codigo de barras
            if (Tipo.ToUpper() == "CODIGO BARRA")
            {
                string NumeroCodigoBarras = GeraNumeroCodigoBarraBradesco(IdentBanco, CodMoeda, Vencimento, Valor, AgenciaCedente, Carteira, NossoNumero, ContaCedente);
                return GeraCodigoBarraBradesco(NumeroCodigoBarras);
            }
            //Caso seja pedido a Linha Digitavel
            if (Tipo.ToUpper() == "LINHA DIGITAVEL")
            {
                return GeraNumeroDigitavelBradesco(IdentBanco, CodMoeda, Vencimento, Valor, AgenciaCedente, Carteira, NossoNumero, ContaCedente);
            }
            //Caso Seja pedido o numero do codigo de barras
            if (Tipo.ToUpper() == "NUMERO CODIGO BARRA")
            {
                return GeraNumeroCodigoBarraBradesco(IdentBanco, CodMoeda, Vencimento, Valor, AgenciaCedente, Carteira, NossoNumero, ContaCedente);
            }
        }
        #endregion

        //Boletos Bradesco ibi
        #region
        if (IdentBanco == "238")
        {
            //Caso seja pedido o codigo de barras
            if (Tipo.ToUpper() == "CODIGO BARRA")
            {
                IdentBanco = "237";
                NossoNumero = NossoNumero.Substring(7) + NossoNumero.Substring(0, 7);
                string NumeroCodigoBarras = GeraNumeroCodigoBarraBradescoIbi(IdentBanco, CodMoeda, Vencimento, Valor, AgenciaCedente, Carteira, NossoNumero, ContaCedente);
                return GeraCodigoBarraBradesco(NumeroCodigoBarras);
            }
            //Caso seja pedido a Linha Digitavel
            if (Tipo.ToUpper() == "LINHA DIGITAVEL")
            {
                IdentBanco = "237";
                NossoNumero = NossoNumero.Substring(7) + NossoNumero.Substring(0, 7);
                return GeraNumeroDigitavelBradescoIbi(IdentBanco, CodMoeda, Vencimento, Valor, AgenciaCedente, Carteira, NossoNumero, ContaCedente);
            }
            //Caso Seja pedido o numero do codigo de barras
            if (Tipo.ToUpper() == "NUMERO CODIGO BARRA")
            {
                return GeraNumeroCodigoBarraBradescoIbi(IdentBanco, CodMoeda, Vencimento, Valor, AgenciaCedente, Carteira, NossoNumero, ContaCedente);
            }
        }
        #endregion

        //Boleto ITAU
        #region
        if (IdentBanco == "341")
        {
            //Caso seja pedido o codigo de barras
            if (Tipo.ToUpper() == "CODIGO BARRA")
            {
                string NumeroCodigoBarras = GeraNumeroCodigoBarraItau(IdentBanco, CodMoeda, Vencimento, Valor, AgenciaCedente, Carteira, NossoNumero, ContaCedente);
                return GeraCodigoBarraItau(NumeroCodigoBarras);
            }
            //Caso seja pedido a Linha Digitavel
            if (Tipo.ToUpper() == "LINHA DIGITAVEL")
            {
                return GeraNumeroDigitavelItau(IdentBanco, CodMoeda, Vencimento, Valor, AgenciaCedente, Carteira, NossoNumero, ContaCedente);
            }
            if (Tipo.ToUpper() == "NUMERO CODIGO BARRA")
            {
                return GeraNumeroCodigoBarraItau(IdentBanco, CodMoeda, Vencimento, Valor, AgenciaCedente, Carteira, NossoNumero, ContaCedente);
            }
        }
        #endregion
        //Boleto Banco do Brasil
        #region
        if (IdentBanco == "001")
        {
            //Caso seja pedido o codigo de barras
            if (Tipo.ToUpper() == "CODIGO BARRA")
            {
                string NumeroCodigoBarras = GeraNumeroCodigoBarraBrasil(IdentBanco, CodMoeda, Vencimento, Valor, AgenciaCedente, Carteira, NossoNumero, ContaCedente);
                return GeraCodigoBarraBrasil(NumeroCodigoBarras);
            }
            //Caso seja pedido a Linha Digitavel
            if (Tipo.ToUpper() == "LINHA DIGITAVEL")
            {
                return GeraNumeroDigitavelBrasil(IdentBanco, CodMoeda, Vencimento, Valor, AgenciaCedente, Carteira, NossoNumero, ContaCedente);
            }
            if (Tipo.ToUpper() == "NUMERO CODIGO BARRA")
            {
                return GeraNumeroCodigoBarraBrasil(IdentBanco, CodMoeda, Vencimento, Valor, AgenciaCedente, Carteira, NossoNumero, ContaCedente);
            }
        }
        #endregion
        //Boleto Banco HSBC
        #region
        if (IdentBanco == "399")
        {
            //Caso seja pedido o codigo de barras
            if (Tipo.ToUpper() == "CODIGO BARRA")
            {
                string NumeroCodigoBarras = GeraNumeroCodigoBarraHSBC(IdentBanco, CodMoeda, Vencimento, Valor, AgenciaCedente, Carteira, NossoNumero, ContaCedente);
                return GeraCodigoBarraHSBC(NumeroCodigoBarras);
            }
            //Caso seja pedido a Linha Digitavel
            if (Tipo.ToUpper() == "LINHA DIGITAVEL")
            {
                return GeraNumeroDigitavelHSBC(IdentBanco, CodMoeda, Vencimento, Valor, AgenciaCedente, Carteira, NossoNumero, ContaCedente);
            }
            if (Tipo.ToUpper() == "NUMERO CODIGO BARRA")
            {
                return GeraNumeroCodigoBarraHSBC(IdentBanco, CodMoeda, Vencimento, Valor, AgenciaCedente, Carteira, NossoNumero, ContaCedente);
            }
        }
        #endregion
        //Boleto Banco Santender
        #region
        if ((IdentBanco == "353") || (IdentBanco == "008") || (IdentBanco == "033"))
        {
            //Caso seja pedido o codigo de barras
            if (Tipo.ToUpper() == "CODIGO BARRA")
            {
                string NumeroCodigoBarras = GeraNumeroCodigoBarraSantander(IdentBanco, CodMoeda, Vencimento, Valor, AgenciaCedente, Carteira, NossoNumero, ContaCedente);
                return GeraCodigoBarraSantander(NumeroCodigoBarras);
            }
            //Caso seja pedido a Linha Digitavel
            if (Tipo.ToUpper() == "LINHA DIGITAVEL")
            {
                return GeraNumeroDigitavelSantander(IdentBanco, CodMoeda, Vencimento, Valor, AgenciaCedente, Carteira, NossoNumero, ContaCedente);
            }
            if (Tipo.ToUpper() == "NUMERO CODIGO BARRA")
            {
                return GeraNumeroCodigoBarraSantander(IdentBanco, CodMoeda, Vencimento, Valor, AgenciaCedente, Carteira, NossoNumero, ContaCedente);
            }
        }
        #endregion
        //Boleto Banco Citibank
        #region
        if (IdentBanco == "745")
        {
            //Caso seja pedido o codigo de barras
            if (Tipo.ToUpper() == "CODIGO BARRA")
            {
                string NumeroCodigoBarras = GeraNumeroCodigoBarraCitibank(IdentBanco, CodMoeda, Vencimento, Valor, AgenciaCedente, Carteira, NossoNumero, ContaCedente);
                return GeraCodigoBarraCitibank(NumeroCodigoBarras);
            }
            //Caso seja pedido a Linha Digitavel
            if (Tipo.ToUpper() == "LINHA DIGITAVEL")
            {
                return GeraNumeroDigitavelCitibank(IdentBanco, CodMoeda, Vencimento, Valor, AgenciaCedente, Carteira, NossoNumero, ContaCedente);
            }
            if (Tipo.ToUpper() == "NUMERO CODIGO BARRA")
            {
                return GeraNumeroCodigoBarraCitibank(IdentBanco, CodMoeda, Vencimento, Valor, AgenciaCedente, Carteira, NossoNumero, ContaCedente);
            }
        }
        #endregion

        //Boleto Banco PanAmericano
        #region
        if (IdentBanco == "623")
        {
            //Caso seja pedido o codigo de barras
            if (Tipo.ToUpper() == "CODIGO BARRA")
            {
                string NumeroCodigoBarras = GeraNumeroCodigoBarraPanAmericano(IdentBanco, CodMoeda, Vencimento, Valor, AgenciaCedente, Carteira, NossoNumero, ContaCedente);
                return GeraCodigoBarraPanAmericano(NumeroCodigoBarras);
            }
            //Caso seja pedido a Linha Digitavel
            if (Tipo.ToUpper() == "LINHA DIGITAVEL")
            {
                return GeraNumeroDigitavelPanAmericano(IdentBanco, CodMoeda, Vencimento, Valor, AgenciaCedente, Carteira, NossoNumero, ContaCedente);
            }
            if (Tipo.ToUpper() == "NUMERO CODIGO BARRA")
            {
                return GeraNumeroCodigoBarraPanAmericano(IdentBanco, CodMoeda, Vencimento, Valor, AgenciaCedente, Carteira, NossoNumero, ContaCedente);
            }
        }
        #endregion
        return "Tipo Não Confere";
    }
    public static string GeraCodigoBarraPelaLinha(string LinhaDigitavel, string IdentBanco)
    {
        string strRetorno = "";
        //Boleto ITAU
        #region
        if (IdentBanco == "341")
        {
            string NumeroCodigoBarras = GeraNumeroCodigoBarraItau(LinhaDigitavel);
            strRetorno = GeraCodigoBarraItau(NumeroCodigoBarras);
        }
        #endregion
        return strRetorno;
    }
    public static string GeraNossoNumeroPelaLinha(string LinhaDigitavel, string ParcAcordoId, string IdentBanco)
    {
        string strRetorno = "";

        //Boleto ITAU
        #region
        if (IdentBanco == "341")
        {
            strRetorno = GeraNossoNumeroItau(LinhaDigitavel, ParcAcordoId);
        }
        #endregion

        //Boleto NORDESTE
        #region
        if (IdentBanco == "XXX")
        {
            strRetorno = GeraNossoNumeroItau(LinhaDigitavel, ParcAcordoId);
        }
        #endregion
        return strRetorno;
    }
    //Codigo Barras Verso
    public static string GeraCodigoBarraVerso(string NumBarras)
    {
        string Codigo_Barra = null;
        Codigo_Barra += "<img border=0 height=30 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
        Codigo_Barra += "<img border=0 height=30 src=http://www.orcozol1.com.br/email/b.gif width=1 />";
        Codigo_Barra += "<img border=0 height=30 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
        Codigo_Barra += "<img border=0 height=30 src=http://www.orcozol1.com.br/email/b.gif width=1 />";

        string Codigo_Bara_Faixas = "", Primeiro = "", Segundo = "";

        int i, j;

        for (i = 0; i < NumBarras.Length; i++)
        {

            if (i % 2 == 0)
            {
                switch (Convert.ToInt32(NumBarras[i].ToString()))
                {
                    case 0:
                        Primeiro = "00110";
                        break;
                    case 1:
                        Primeiro = "10001";
                        break;
                    case 2:
                        Primeiro = "01001";
                        break;
                    case 3:
                        Primeiro = "11000";
                        break;
                    case 4:
                        Primeiro = "00101";
                        break;
                    case 5:
                        Primeiro = "10100";
                        break;
                    case 6:
                        Primeiro = "01100";
                        break;
                    case 7:
                        Primeiro = "00011";
                        break;
                    case 8:
                        Primeiro = "10010";
                        break;
                    case 9:
                        Primeiro = "01010";
                        break;
                }
            }
            else
            {
                switch (Convert.ToInt32(NumBarras[i].ToString()))
                {
                    case 0:
                        Segundo = "00110";
                        break;
                    case 1:
                        Segundo = "10001";
                        break;
                    case 2:
                        Segundo = "01001";
                        break;
                    case 3:
                        Segundo = "11000";
                        break;
                    case 4:
                        Segundo = "00101";
                        break;
                    case 5:
                        Segundo = "10100";
                        break;
                    case 6:
                        Segundo = "01100";
                        break;
                    case 7:
                        Segundo = "00011";
                        break;
                    case 8:
                        Segundo = "10010";
                        break;
                    case 9:
                        Segundo = "01010";
                        break;
                }
            }

            if ((Primeiro.Length != 0) && (Segundo.Length != 0))
            {
                for (j = 0; j < Segundo.Length; j++)
                {
                    Codigo_Bara_Faixas += Primeiro[j].ToString();
                    Codigo_Bara_Faixas += Segundo[j].ToString();
                }
                Primeiro = "";
                Segundo = "";
            }
        }
        //Response.Write(Codigo_Bara_Faixas);
        for (i = 0; i < Codigo_Bara_Faixas.Length; i += 2)
        {
            if (Codigo_Bara_Faixas[i].ToString() == "0")
                Codigo_Barra += "<img border=0 height=30 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
            else
                Codigo_Barra += "<img border=0 height=30 src=http://www.orcozol1.com.br/email/p.gif width=3 />";

            if (Codigo_Bara_Faixas[i + 1].ToString() == "0")
                Codigo_Barra += "<img border=0 height=30 src=http://www.orcozol1.com.br/email/b.gif width=1 />";
            else
                Codigo_Barra += "<img border=0 height=30 src=http://www.orcozol1.com.br/email/b.gif width=3 />";

        }
        Codigo_Barra += "<img border=0 height=30 src=http://www.orcozol1.com.br/email/p.gif width=3 />";
        Codigo_Barra += "<img border=0 height=30 src=http://www.orcozol1.com.br/email/b.gif width=1 />";
        Codigo_Barra += "<img border=0 height=30 src=http://www.orcozol1.com.br/email/p.gif width=1 />";

        return Codigo_Barra;
    }
    
    public static string GeraBarras(string NumBarras)
    {
        string Codigo_Barra = null;
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=1 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=1 />";

        string Codigo_Bara_Faixas = "", Primeiro = "", Segundo = "";

        int i, j;

        for (i = 0; i < NumBarras.Length; i++)
        {

            if (i % 2 == 0)
            {
                switch (Convert.ToInt32(NumBarras[i].ToString()))
                {
                    case 0:
                        Primeiro = "00110";
                        break;
                    case 1:
                        Primeiro = "10001";
                        break;
                    case 2:
                        Primeiro = "01001";
                        break;
                    case 3:
                        Primeiro = "11000";
                        break;
                    case 4:
                        Primeiro = "00101";
                        break;
                    case 5:
                        Primeiro = "10100";
                        break;
                    case 6:
                        Primeiro = "01100";
                        break;
                    case 7:
                        Primeiro = "00011";
                        break;
                    case 8:
                        Primeiro = "10010";
                        break;
                    case 9:
                        Primeiro = "01010";
                        break;
                }
            }
            else
            {
                switch (Convert.ToInt32(NumBarras[i].ToString()))
                {
                    case 0:
                        Segundo = "00110";
                        break;
                    case 1:
                        Segundo = "10001";
                        break;
                    case 2:
                        Segundo = "01001";
                        break;
                    case 3:
                        Segundo = "11000";
                        break;
                    case 4:
                        Segundo = "00101";
                        break;
                    case 5:
                        Segundo = "10100";
                        break;
                    case 6:
                        Segundo = "01100";
                        break;
                    case 7:
                        Segundo = "00011";
                        break;
                    case 8:
                        Segundo = "10010";
                        break;
                    case 9:
                        Segundo = "01010";
                        break;
                }
            }

            if ((Primeiro.Length != 0) && (Segundo.Length != 0))
            {
                for (j = 0; j < Segundo.Length; j++)
                {
                    Codigo_Bara_Faixas += Primeiro[j].ToString();
                    Codigo_Bara_Faixas += Segundo[j].ToString();
                }
                Primeiro = "";
                Segundo = "";
            }
        }
        //Response.Write(Codigo_Bara_Faixas);
        for (i = 0; i < Codigo_Bara_Faixas.Length; i += 2)
        {
            if (Codigo_Bara_Faixas[i].ToString() == "0")
                Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";
            else
                Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=3 />";

            if (Codigo_Bara_Faixas[i + 1].ToString() == "0")
                Codigo_Barra += "<img border=0 height=30 src=http://www.orcozol1.com.br/email/b.gif width=1 />";
            else
                Codigo_Barra += "<img border=0 height=30 src=http://www.orcozol1.com.br/email/b.gif width=3 />";

        }
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=3 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/b.gif width=1 />";
        Codigo_Barra += "<img border=0 height=50 src=http://www.orcozol1.com.br/email/p.gif width=1 />";

        return Codigo_Barra;
    }

    private static string TipoPagamentoPDD(string inAcordo, string strConn)
    {

        object[] sqlValues = new object[6];

        string retValue = "00"; //-> Maior Vencimento < Data Acordo - Algumas Vencidas

        SqlCommand sqlCmmd = null;
        SqlDataReader sqlRead = null;
        SqlConnection sqlConn = null;

        try
        {
            sqlConn = new SqlConnection(strConn);
            sqlConn.Open();

            sqlCmmd = new SqlCommand("SPSAA00SequencialPDD", sqlConn);
            sqlCmmd.CommandType = CommandType.StoredProcedure;
            sqlCmmd.Parameters.Add("@IN_ACORDO",SqlDbType.Int).Value = Convert.ToInt32(inAcordo);

            sqlRead = sqlCmmd.ExecuteReader();

            if (sqlRead.HasRows && sqlRead.Read())
            {

                sqlRead.GetValues(sqlValues);

                if (sqlValues[5] != null && sqlValues[5].ToString() == "S")
                {
                    if (Convert.ToInt32(sqlValues[2]) == 0 && Convert.ToInt32(sqlValues[3]) == 0)
                        retValue = "01";    //-> Todas Vencidas e Todas Vincendas
                    else if (Convert.ToDateTime(sqlValues[1]).Date < Convert.ToDateTime(sqlValues[4]).Date && Convert.ToInt32(sqlValues[2]) == 0)
                        retValue = "98";    //-> Todas Vencidas e Maior Vencimento < Data Acordo
                    else if (Convert.ToDateTime(sqlValues[0]).Date < Convert.ToDateTime(sqlValues[4]).Date && Convert.ToInt32(sqlValues[2]) == 0 && Convert.ToDateTime(sqlValues[1]).Date >= Convert.ToDateTime(sqlValues[4]).Date)
                        retValue = "99";    //-> Menor Vencimento < Data Acordo < Maior Vencimento - Todas as Parcelas Vencidas e Algumas Vincendas
                }
            }
        } finally
        {
            if (sqlConn != null && sqlConn.State != ConnectionState.Closed)
                sqlConn.Close();
        }
        return retValue;
    }

    private static void GravaNossoNumero(string NossoNumero, string ParcAcordoId)
    {
        using (SqlConnection SqlConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CobNetDataBaseConnectionString"].ConnectionString.ToString()))
        {
            try
            {
                SqlConn.Open();
                SqlCommand Comando;

                if (ParcAcordoId.Length > 0 && NossoNumero.Length > 0)
                {
                    Comando = new SqlCommand("UPDATE Tb_Parcela_Acordo SET ParcAcordo_Nosso_Numero = " + NossoNumero + " WHERE ParcAcordo_Id_Parcela = " + ParcAcordoId, SqlConn);
                    Comando.ExecuteNonQuery();

                    Comando = new SqlCommand("UPDATE Tb_Boleto SET Bol_Nosso_Numero = " + NossoNumero + " WHERE Bol_Id = (SELECT TOP 1 Bol_Id FROM Tb_Parcela_Acordo WHERE ParcAcordo_Id_Parcela = " + ParcAcordoId + ")", SqlConn);
                    Comando.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (SqlConn.State.Equals(ConnectionState.Open))
                    SqlConn.Close();
            }
        }
    }

    

    
   
    public static string[] SepararBlocosCodigoBarras(string LinhaDigitavel)
    {
        string[] Blocos = new string[10];

        Blocos[0] = LinhaDigitavel.Substring(0, 4);
        Blocos[1] = LinhaDigitavel.Substring(4, 5);
        Blocos[2] = LinhaDigitavel.Substring(9, 1);
        Blocos[3] = LinhaDigitavel.Substring(10, 10);
        Blocos[4] = LinhaDigitavel.Substring(20, 1);
        Blocos[5] = LinhaDigitavel.Substring(21, 10);
        Blocos[6] = LinhaDigitavel.Substring(31, 1);
        Blocos[7] = LinhaDigitavel.Substring(32, 1);
        Blocos[8] = LinhaDigitavel.Substring(33, 4);
        Blocos[9] = LinhaDigitavel.Substring(37, 10);

        return Blocos;
    }

    public static string FormatarLinhaDigitavel(string linhaDigitavel)
        {
            string LinhaFormatada = string.Empty;

            for (int i = 0; i < 47; i++)
            {
                LinhaFormatada += linhaDigitavel[i];

                switch(i)
                {
                    case 4:
                        LinhaFormatada += ".";
                        break;
                    case 9:
                        LinhaFormatada += " ";
                        break;
                    case 14:
                        LinhaFormatada += ".";
                        break;
                    case 20:
                        LinhaFormatada += " ";
                        break;
                    case 25:
                        LinhaFormatada += ".";
                        break;
                    case 31:
                        LinhaFormatada += " ";
                        break;
                    case 32:
                        LinhaFormatada += " ";
                        break;
                }
            }

            return LinhaFormatada;
        }

}
