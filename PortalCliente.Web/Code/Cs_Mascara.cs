using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


/// <summary>
/// Summary description for Cs_Acerta
/// </summary>
public partial class Cs_Mascara
{
    public static string ParaValor(string ValorStr)
    {
        try
        {
            if (ValorStr.Length == 0)
                ValorStr = "0";

            if (ValorStr == "&nbsp;")
                ValorStr = "0";

            if (!char.IsDigit(ValorStr[0]))
                return "0";

            string Valor = Convert.ToString(Math.Round(Convert.ToDecimal(ValorStr.Trim()), 2));
            string DecimalPosVirgula, inteiro;
            string[] InteiroPreVirgula = new string[5];
            int Dividido = 0;
            int ContaCaracter = 0;
            string Temp = null, ValorComMascara = null;

            if (!Valor.Contains(","))
                Valor += ",00";

            DecimalPosVirgula = Valor.Substring(Valor.IndexOf(',') + 1, Valor.Length - Valor.IndexOf(',') - 1);
            inteiro = Valor.Substring(0, Valor.IndexOf(','));

            if (DecimalPosVirgula.Length == 1)
                DecimalPosVirgula += "0";

            for (int i = inteiro.Length - 1; i >= 0; i--)
            {
                ContaCaracter++;
                Temp = inteiro[i].ToString() + Temp;
                if (ContaCaracter % 3 == 0)
                {
                    InteiroPreVirgula[Dividido] = Temp;
                    Dividido++;
                    Temp = null;
                    ContaCaracter = 0;
                }

            }
            InteiroPreVirgula[Dividido] = Temp;
            if (inteiro.Length > 3)
                for (int i = Dividido; i >= 0; i--)
                {
                    ValorComMascara += InteiroPreVirgula[i] + '.';
                }
            else
                ValorComMascara = inteiro;
            ValorComMascara += ',' + DecimalPosVirgula;
            ValorComMascara = ValorComMascara.Replace(".,", ",");

            if (ValorComMascara[0].ToString() == ".")
                ValorComMascara = ValorComMascara.Substring(1, ValorComMascara.Length - 1);

            ValorComMascara = ValorComMascara.Replace("-.", "");
            return ValorComMascara;
        }
        catch
        {
            return ValorStr;
        }
    }
    public static string ParaData(string DataStr)
    {
        string[] DataSeparado = DataStr.Split('/');

        string dia, mes, ano;

        dia = Cs_Acerta.AcrescentaZeros(DataSeparado[0], 2);
        mes = Cs_Acerta.AcrescentaZeros(DataSeparado[1], 2);
        ano = Cs_Acerta.AcrescentaZeros(DataSeparado[2].Substring(0, 4), 4);

        return dia + "/" + mes + "/" + ano;
    }
    public static string ParaCep(string CepStr)
    {
        string CepAntesTraco, CepDepoisTraco;
        if (CepStr.Length > 5)
        {
            CepAntesTraco = CepStr.Substring(0, 5);
            CepDepoisTraco = CepStr.Remove(0, 5);

            return CepAntesTraco + "-" + CepDepoisTraco;
        }

        return CepStr;
    }
    public static string ParaCPF(string strCPF)
    {
        strCPF = Convert.ToUInt64(strCPF).ToString(@"000\.000\.000\-00");
        //if (strCPF.Length > 10)
        //    strCPF = strCPF.Substring(strCPF.Length - 11, 3) + "." + strCPF.Substring(strCPF.Length - 8, 3) + "." + strCPF.Substring(strCPF.Length - 5, 3) + "-" + strCPF.Substring(strCPF.Length - 2);
        return strCPF;
    }
    public static string ParaCNPJ(string strCNPJ)
    {
        strCNPJ = Convert.ToUInt64(strCNPJ).ToString(@"00\.000\.000\/0000\-00");
        //if (strCNPJ.Length > 13)
        //    strCNPJ = strCNPJ.Substring(strCNPJ.Length - 14, 2) + "." + strCNPJ.Substring(strCNPJ.Length - 12, 3) + "." + strCNPJ.Substring(strCNPJ.Length - 9, 3) + "/" + strCNPJ.Substring(strCNPJ.Length - 6, 4) + "-" + strCNPJ.Substring(strCNPJ.Length - 2);
        return strCNPJ;
    }
}
