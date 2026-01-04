using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;


/// <summary>
/// Summary description for Cs_Acerta
/// </summary>
public partial class Cs_Acerta
{
    public static SqlParameter CustomParameter(string Nome, SqlDbType tipo, int tamanho, object valor)
    {
        SqlParameter param = null;

        if (valor == null || string.IsNullOrEmpty(valor.ToString()))
        {
            return new SqlParameter(Nome, DBNull.Value);
        }

        if (tipo == SqlDbType.VarChar)
            param = new SqlParameter(Nome, SqlDbType.VarChar, tamanho);
        else
            param = new SqlParameter(Nome, tipo);

        if (tipo == SqlDbType.DateTime)
        {
            if ((DateTime)valor == DateTime.MinValue)
                param.Value = DBNull.Value;
            else
                param.Value = valor;
        }
        else
        {
            param.Value = valor;
        }

        return param;
    }





    public static string RemoveCaracteres(string Texto)
    {
        // Prepara a tabela de símbolos.
        Dictionary<char, char[]> symbolTable = new Dictionary<char, char[]>();
        symbolTable.Add('a', new char[] { 'à', 'á', 'ä', 'â', 'ã' });
        symbolTable.Add('c', new char[] { 'ç' });
        symbolTable.Add('e', new char[] { 'è', 'é', 'ë', 'ê' });
        symbolTable.Add('i', new char[] { 'ì', 'í', 'ï', 'î' });
        symbolTable.Add('o', new char[] { 'ò', 'ó', 'ö', 'ô', 'õ' });
        symbolTable.Add('u', new char[] { 'ù', 'ú', 'ü', 'û' });
        symbolTable.Add(' ', new char[] { '?', '!', '@', '#', '$', '%', '&', '*', '_', '+', '-', '§', '¬', '¢', '£', '³', '²', '¹', 'ª', 'º', '{', '}', '[', ']', '(', ')', '°', '\\', '/', ':', ';', '>', '<', '.', ',', '|', '"', '´', '`', '^', '~' });

        // Substitui os símbolos.
        foreach (char key in symbolTable.Keys)
        {
            foreach (char symbol in symbolTable[key])
            {
                Texto = Texto.Replace(symbol, key);
                Texto = Texto.Replace(symbol.ToString().ToUpper(), key.ToString().ToUpper());
            }
        }

        string[] Aux = Texto.ToLower().Split(' ');
        string Ajustado = string.Empty;
        string Retorno = string.Empty;

        foreach (string s in Aux)
        {
            if (string.IsNullOrEmpty(s))
                continue;
            if (s.Length > 1)
                Ajustado = string.Concat(s.Replace(" ", "").Remove(1).ToUpper(), s.Replace(" ", "").Substring(1));
            else
                Ajustado = s.ToUpper();

            Retorno = string.Concat(Retorno, " ", Ajustado).TrimStart();
        }
        return Retorno;
    }

    public static string AcertaData(string Data, string Formato, string Para)
    {
        if (Data.Equals("nulo", StringComparison.InvariantCultureIgnoreCase))
            return Data;

        if (!Data.Contains(" "))
            Data = Data + " 00:00:00";

        Data = Data.Replace("-", "/");

        string[] DataHora = Data.Split(' ');
        Data = DataHora[0];
        string MMDDAAAA = null, DDMMAAAA = null;
        Data = Data.Replace("'", "");
        string pri = null, seg = null, ter = null;

        int a = 0, ant = 0;
        if ((Formato == "DD/MM/AAAA") || (Formato == "MM/DD/AAAA") || (Formato == "AAAA/MM/DD") || (Formato == "AAAA/DD/MM") || (Formato == "MM/AAAA/DD") || (Formato == "DD/AAAA/MM"))
        {
            Data += '/';
            for (int i = 0; i < Data.Length; i++)
            {
                if (Data[i].ToString() == "/")
                {
                    if (a == 0)
                        for (int j = ant; j < i; j++)
                            pri += Data[j].ToString();
                    if (a == 1)
                        for (int j = ant; j < i; j++)
                            seg += Data[j].ToString();
                    if (a == 2)
                        for (int j = ant; j < i; j++)
                            ter += Data[j].ToString();
                    ant = i + 1;
                    a++;
                }
            }
        }
        pri = DuasCasas(pri);
        seg = DuasCasas(seg);

        if (Para == "MM/DD/AAAA")
        {
            if (Formato == "DDMMAAAA")
                MMDDAAAA = Data[2].ToString() + Data[3].ToString() + '/' + Data[0].ToString() + Data[1].ToString() + '/' + Data[4].ToString() + Data[5].ToString() + Data[6].ToString() + Data[7].ToString();
            if (Formato == "MMDDAAAA")
                MMDDAAAA = Data[0].ToString() + Data[1].ToString() + '/' + Data[2].ToString() + Data[3].ToString() + '/' + Data[4].ToString() + Data[5].ToString() + Data[6].ToString() + Data[7].ToString();
            if (Formato == "AAAAMMDD")
                MMDDAAAA = Data[4].ToString() + Data[5].ToString() + '/' + Data[6].ToString() + Data[7].ToString() + '/' + Data[0].ToString() + Data[1].ToString() + Data[2].ToString() + Data[3].ToString();
            if (Formato == "AAAADDMM")
                MMDDAAAA = Data[6].ToString() + Data[7].ToString() + '/' + Data[4].ToString() + Data[5].ToString() + '/' + Data[0].ToString() + Data[1].ToString() + Data[2].ToString() + Data[3].ToString();
            if (Formato == "MMAAAADD")
                MMDDAAAA = Data[0].ToString() + Data[1].ToString() + '/' + Data[6].ToString() + Data[7].ToString() + '/' + Data[2].ToString() + Data[3].ToString() + Data[4].ToString() + Data[5].ToString();
            if (Formato == "DDAAAAMM")
                MMDDAAAA = Data[6].ToString() + Data[7].ToString() + '/' + Data[0].ToString() + Data[1].ToString() + '/' + Data[2].ToString() + Data[3].ToString() + Data[4].ToString() + Data[5].ToString();

            if (Formato == "DD/MM/AAAA")
                MMDDAAAA = seg + '/' + pri + '/' + ter;
            if (Formato == "MM/DD/AAAA")
                MMDDAAAA = pri + '/' + seg + '/' + ter;
            if (Formato == "AAAA/MM/DD")
                MMDDAAAA = seg + '/' + ter + '/' + pri;
            if (Formato == "AAAA/DD/MM")
                MMDDAAAA = ter + '/' + seg + '/' + pri;
            if (Formato == "MM/AAAA/DD")
                MMDDAAAA = pri + '/' + ter + '/' + seg;
            if (Formato == "DD/AAAA/MM")
                MMDDAAAA = ter + '/' + pri + '/' + seg;

            return MMDDAAAA + ' ' + DataHora[1];
        }
        else
            if (Para == "DD/MM/AAAA")
            {
                if (Formato == "DDMMAAAA")
                    MMDDAAAA = Data[0].ToString() + Data[1].ToString() + '/' + Data[2].ToString() + Data[3].ToString() + '/' + Data[4].ToString() + Data[5].ToString() + Data[6].ToString() + Data[7].ToString();
                if (Formato == "MMDDAAAA")
                    MMDDAAAA = Data[2].ToString() + Data[3].ToString() + '/' + Data[0].ToString() + Data[1].ToString() + '/' + Data[4].ToString() + Data[5].ToString() + Data[6].ToString() + Data[7].ToString();
                if (Formato == "AAAAMMDD")
                    MMDDAAAA = Data[6].ToString() + Data[7].ToString() + '/' + Data[4].ToString() + Data[5].ToString() + '/' + Data[0].ToString() + Data[1].ToString() + Data[2].ToString() + Data[3].ToString();
                if (Formato == "AAAADDMM")
                    MMDDAAAA = Data[4].ToString() + Data[5].ToString() + '/' + Data[6].ToString() + Data[7].ToString() + '/' + Data[0].ToString() + Data[1].ToString() + Data[2].ToString() + Data[3].ToString();
                if (Formato == "MMAAAADD")
                    MMDDAAAA = Data[6].ToString() + Data[7].ToString() + '/' + Data[0].ToString() + Data[1].ToString() + '/' + Data[2].ToString() + Data[3].ToString() + Data[4].ToString() + Data[5].ToString();
                if (Formato == "DDAAAAMM")
                    MMDDAAAA = Data[0].ToString() + Data[1].ToString() + '/' + Data[6].ToString() + Data[7].ToString() + '/' + Data[2].ToString() + Data[3].ToString() + Data[4].ToString() + Data[5].ToString();

                if (Formato == "DD/MM/AAAA")
                    MMDDAAAA = pri + '/' + seg + '/' + ter;
                if (Formato == "MM/DD/AAAA")
                    MMDDAAAA = seg + '/' + pri + '/' + ter;
                if (Formato == "AAAA/MM/DD")
                    MMDDAAAA = ter + '/' + seg + '/' + pri;
                if (Formato == "AAAA/DD/MM")
                    MMDDAAAA = seg + '/' + ter + '/' + pri;
                if (Formato == "MM/AAAA/DD")
                    MMDDAAAA = ter + '/' + pri + '/' + seg;
                if (Formato == "DD/AAAA/MM")
                    MMDDAAAA = pri + '/' + ter + '/' + seg;

                return MMDDAAAA + ' ' + DataHora[1];
            }
            else
                if (Para == "AAAA/MM/DD")
                {
                    if (Formato == "DDMMAAAA")
                        MMDDAAAA = Data[4].ToString() + Data[5].ToString() + Data[6].ToString() + Data[7].ToString() + '/' + Data[2].ToString() + Data[3].ToString() + '/' + Data[0].ToString() + Data[1].ToString();
                    if (Formato == "MMDDAAAA")
                        MMDDAAAA = Data[4].ToString() + Data[5].ToString() + Data[6].ToString() + Data[7].ToString() + '/' + Data[0].ToString() + Data[1].ToString() + '/' + Data[2].ToString() + Data[3].ToString();
                    if (Formato == "AAAAMMDD")
                        MMDDAAAA = Data[0].ToString() + Data[1].ToString() + Data[2].ToString() + Data[3].ToString() + '/' + Data[4].ToString() + Data[5].ToString() + '/' + Data[6].ToString() + Data[7].ToString();
                    if (Formato == "AAAADDMM")
                        MMDDAAAA = Data[0].ToString() + Data[1].ToString() + Data[2].ToString() + Data[3].ToString() + '/' + Data[6].ToString() + Data[7].ToString() + '/' + Data[4].ToString() + Data[5].ToString();
                    if (Formato == "MMAAAADD")
                        MMDDAAAA = Data[2].ToString() + Data[3].ToString() + Data[4].ToString() + Data[5].ToString() + '/' + Data[0].ToString() + Data[1].ToString() + '/' + Data[6].ToString() + Data[7].ToString();
                    if (Formato == "DDAAAAMM")
                        MMDDAAAA = Data[2].ToString() + Data[3].ToString() + Data[4].ToString() + Data[5].ToString() + '/' + Data[6].ToString() + Data[7].ToString() + '/' + Data[0].ToString() + Data[1].ToString();

                    if (Formato == "DD/MM/AAAA")
                        MMDDAAAA = ter + '/' + seg + '/' + pri;
                    if (Formato == "MM/DD/AAAA")
                        MMDDAAAA = ter + '/' + pri + '/' + seg;
                    if (Formato == "AAAA/MM/DD")
                        MMDDAAAA = pri + '/' + seg + '/' + ter;
                    if (Formato == "AAAA/DD/MM")
                        MMDDAAAA = pri + '/' + ter + '/' + seg;
                    if (Formato == "MM/AAAA/DD")
                        MMDDAAAA = seg + '/' + pri + '/' + ter;
                    if (Formato == "DD/AAAA/MM")
                        MMDDAAAA = seg + '/' + ter + '/' + pri;

                    return MMDDAAAA + ' ' + DataHora[1];
                }
                else
                    if (Para == "MMDDAAAA")
                    {
                        if (Formato == "DDMMAAAA")
                            MMDDAAAA = Data[2].ToString() + Data[3].ToString() + Data[0].ToString() + Data[1].ToString() + Data[4].ToString() + Data[5].ToString() + Data[6].ToString() + Data[7].ToString();
                        if (Formato == "MMDDAAAA")
                            MMDDAAAA = Data[0].ToString() + Data[1].ToString() + Data[2].ToString() + Data[3].ToString() + Data[4].ToString() + Data[5].ToString() + Data[6].ToString() + Data[7].ToString();
                        if (Formato == "AAAAMMDD")
                            MMDDAAAA = Data[4].ToString() + Data[5].ToString() + Data[6].ToString() + Data[7].ToString() + Data[0].ToString() + Data[1].ToString() + Data[2].ToString() + Data[3].ToString();
                        if (Formato == "AAAADDMM")
                            MMDDAAAA = Data[6].ToString() + Data[7].ToString() + Data[4].ToString() + Data[5].ToString() + Data[0].ToString() + Data[1].ToString() + Data[2].ToString() + Data[3].ToString();
                        if (Formato == "MMAAAADD")
                            MMDDAAAA = Data[0].ToString() + Data[1].ToString() + Data[6].ToString() + Data[7].ToString() + Data[2].ToString() + Data[3].ToString() + Data[4].ToString() + Data[5].ToString();
                        if (Formato == "DDAAAAMM")
                            MMDDAAAA = Data[6].ToString() + Data[7].ToString() + Data[0].ToString() + Data[1].ToString() + Data[2].ToString() + Data[3].ToString() + Data[4].ToString() + Data[5].ToString();

                        if (Formato == "DD/MM/AAAA")
                            MMDDAAAA = seg + pri + ter;
                        if (Formato == "MM/DD/AAAA")
                            MMDDAAAA = pri + seg + ter;
                        if (Formato == "AAAA/MM/DD")
                            MMDDAAAA = seg + ter + pri;
                        if (Formato == "AAAA/DD/MM")
                            MMDDAAAA = ter + seg + pri;
                        if (Formato == "MM/AAAA/DD")
                            MMDDAAAA = pri + ter + seg;
                        if (Formato == "DD/AAAA/MM")
                            MMDDAAAA = ter + pri + seg;

                        return MMDDAAAA + ' ' + DataHora[1];
                    }
                    else
                        if (Para == "DDMMAAAA")
                        {
                            if (Formato == "DDMMAAAA")
                                MMDDAAAA = Data[0].ToString() + Data[1].ToString() + Data[2].ToString() + Data[3].ToString() + Data[4].ToString() + Data[5].ToString() + Data[6].ToString() + Data[7].ToString();
                            if (Formato == "MMDDAAAA")
                                MMDDAAAA = Data[2].ToString() + Data[3].ToString() + Data[0].ToString() + Data[1].ToString() + Data[4].ToString() + Data[5].ToString() + Data[6].ToString() + Data[7].ToString();
                            if (Formato == "AAAAMMDD")
                                MMDDAAAA = Data[6].ToString() + Data[7].ToString() + Data[4].ToString() + Data[5].ToString() + Data[0].ToString() + Data[1].ToString() + Data[2].ToString() + Data[3].ToString();
                            if (Formato == "AAAADDMM")
                                MMDDAAAA = Data[4].ToString() + Data[5].ToString() + Data[6].ToString() + Data[7].ToString() + Data[0].ToString() + Data[1].ToString() + Data[2].ToString() + Data[3].ToString();
                            if (Formato == "MMAAAADD")
                                MMDDAAAA = Data[6].ToString() + Data[7].ToString() + Data[0].ToString() + Data[1].ToString() + Data[2].ToString() + Data[3].ToString() + Data[4].ToString() + Data[5].ToString();
                            if (Formato == "DDAAAAMM")
                                MMDDAAAA = Data[0].ToString() + Data[1].ToString() + Data[6].ToString() + Data[7].ToString() + Data[2].ToString() + Data[3].ToString() + Data[4].ToString() + Data[5].ToString();

                            if (Formato == "DD/MM/AAAA")
                                MMDDAAAA = pri + seg + ter;
                            if (Formato == "MM/DD/AAAA")
                                MMDDAAAA = seg + pri + ter;
                            if (Formato == "AAAA/MM/DD")
                                MMDDAAAA = ter + seg + pri;
                            if (Formato == "AAAA/DD/MM")
                                MMDDAAAA = seg + ter + pri;
                            if (Formato == "MM/AAAA/DD")
                                MMDDAAAA = ter + pri + seg;
                            if (Formato == "DD/AAAA/MM")
                                MMDDAAAA = pri + ter + seg;

                            return MMDDAAAA + ' ' + DataHora[1];
                        }
                        else
                            if (Para == "AAAAMMDD")
                            {
                                if (Formato == "DDMMAAAA")
                                    MMDDAAAA = Data[4].ToString() + Data[5].ToString() + Data[6].ToString() + Data[7].ToString() + Data[2].ToString() + Data[3].ToString() + Data[0].ToString() + Data[1].ToString();
                                if (Formato == "MMDDAAAA")
                                    MMDDAAAA = Data[4].ToString() + Data[5].ToString() + Data[6].ToString() + Data[7].ToString() + Data[0].ToString() + Data[1].ToString() + Data[2].ToString() + Data[3].ToString();
                                if (Formato == "AAAAMMDD")
                                    MMDDAAAA = Data[0].ToString() + Data[1].ToString() + Data[2].ToString() + Data[3].ToString() + Data[4].ToString() + Data[5].ToString() + Data[6].ToString() + Data[7].ToString();
                                if (Formato == "AAAADDMM")
                                    MMDDAAAA = Data[0].ToString() + Data[1].ToString() + Data[2].ToString() + Data[3].ToString() + Data[6].ToString() + Data[7].ToString() + Data[4].ToString() + Data[5].ToString();
                                if (Formato == "MMAAAADD")
                                    MMDDAAAA = Data[2].ToString() + Data[3].ToString() + Data[4].ToString() + Data[5].ToString() + Data[0].ToString() + Data[1].ToString() + Data[6].ToString() + Data[7].ToString();
                                if (Formato == "DDAAAAMM")
                                    MMDDAAAA = Data[2].ToString() + Data[3].ToString() + Data[4].ToString() + Data[5].ToString() + Data[6].ToString() + Data[7].ToString() + Data[0].ToString() + Data[1].ToString();

                                if (Formato == "DD/MM/AAAA")
                                    MMDDAAAA = ter + seg + pri;
                                if (Formato == "MM/DD/AAAA")
                                    MMDDAAAA = ter + pri + seg;
                                if (Formato == "AAAA/MM/DD")
                                    MMDDAAAA = pri + seg + ter;
                                if (Formato == "AAAA/DD/MM")
                                    MMDDAAAA = pri + ter + seg;
                                if (Formato == "MM/AAAA/DD")
                                    MMDDAAAA = seg + pri + ter;
                                if (Formato == "DD/AAAA/MM")
                                    MMDDAAAA = seg + ter + pri;

                                return MMDDAAAA + ' ' + DataHora[1];
                            }
                            else
                                if (Para == "MMDDAA")
                                {
                                    if (Formato == "DDMMAAAA")
                                        MMDDAAAA = Data[2].ToString() + Data[3].ToString() + Data[0].ToString() + Data[1].ToString() + Data[6].ToString() + Data[7].ToString();
                                    if (Formato == "MMDDAAAA")
                                        MMDDAAAA = Data[0].ToString() + Data[1].ToString() + Data[2].ToString() + Data[3].ToString() + Data[6].ToString() + Data[7].ToString();
                                    if (Formato == "AAAAMMDD")
                                        MMDDAAAA = Data[4].ToString() + Data[5].ToString() + Data[6].ToString() + Data[7].ToString() + Data[2].ToString() + Data[3].ToString();
                                    if (Formato == "AAAADDMM")
                                        MMDDAAAA = Data[6].ToString() + Data[7].ToString() + Data[4].ToString() + Data[5].ToString() + Data[2].ToString() + Data[3].ToString();
                                    if (Formato == "MMAAAADD")
                                        MMDDAAAA = Data[0].ToString() + Data[1].ToString() + Data[6].ToString() + Data[7].ToString() + Data[4].ToString() + Data[5].ToString();
                                    if (Formato == "DDAAAAMM")
                                        MMDDAAAA = Data[6].ToString() + Data[7].ToString() + Data[0].ToString() + Data[1].ToString() + Data[4].ToString() + Data[5].ToString();

                                    if (Formato == "DD/MM/AAAA")
                                        MMDDAAAA = seg + pri + ter.Substring(2, 2);
                                    if (Formato == "MM/DD/AAAA")
                                        MMDDAAAA = pri + seg + ter.Substring(2, 2);
                                    if (Formato == "AAAA/MM/DD")
                                        MMDDAAAA = seg + ter + pri.Substring(2, 2);
                                    if (Formato == "AAAA/DD/MM")
                                        MMDDAAAA = ter + seg + pri.Substring(2, 2);
                                    if (Formato == "MM/AAAA/DD")
                                        MMDDAAAA = pri + ter + seg.Substring(2, 2);
                                    if (Formato == "DD/AAAA/MM")
                                        MMDDAAAA = ter + pri + seg.Substring(2, 2);

                                    return MMDDAAAA + ' ' + DataHora[1];
                                }
                                else
                                    if (Para == "DDMMAA")
                                    {
                                        if (Formato == "DDMMAAAA")
                                            MMDDAAAA = Data[0].ToString() + Data[1].ToString() + Data[2].ToString() + Data[3].ToString() + Data[6].ToString() + Data[7].ToString();
                                        if (Formato == "MMDDAAAA")
                                            MMDDAAAA = Data[2].ToString() + Data[3].ToString() + Data[0].ToString() + Data[1].ToString() + Data[6].ToString() + Data[7].ToString();
                                        if (Formato == "AAAAMMDD")
                                            MMDDAAAA = Data[6].ToString() + Data[7].ToString() + Data[4].ToString() + Data[5].ToString() + Data[2].ToString() + Data[3].ToString();
                                        if (Formato == "AAAADDMM")
                                            MMDDAAAA = Data[4].ToString() + Data[5].ToString() + Data[6].ToString() + Data[7].ToString() + Data[2].ToString() + Data[3].ToString();
                                        if (Formato == "MMAAAADD")
                                            MMDDAAAA = Data[6].ToString() + Data[7].ToString() + Data[0].ToString() + Data[1].ToString() + Data[4].ToString() + Data[5].ToString();
                                        if (Formato == "DDAAAAMM")
                                            MMDDAAAA = Data[0].ToString() + Data[1].ToString() + Data[6].ToString() + Data[7].ToString() + Data[4].ToString() + Data[5].ToString();

                                        if (Formato == "DD/MM/AAAA")
                                            MMDDAAAA = pri + seg + ter.Substring(2, 2);
                                        if (Formato == "MM/DD/AAAA")
                                            MMDDAAAA = seg + pri + ter.Substring(2, 2);
                                        if (Formato == "AAAA/MM/DD")
                                            MMDDAAAA = ter + seg + pri.Substring(2, 2);
                                        if (Formato == "AAAA/DD/MM")
                                            MMDDAAAA = seg + ter + pri.Substring(2, 2);
                                        if (Formato == "MM/AAAA/DD")
                                            MMDDAAAA = ter + pri + seg.Substring(2, 2);
                                        if (Formato == "DD/AAAA/MM")
                                            MMDDAAAA = pri + ter + seg;

                                        return MMDDAAAA + ' ' + DataHora[1];
                                    }
                                    else
                                        if (Para == "AAMMDD")
                                        {
                                            if (Formato == "DDMMAAAA")
                                                MMDDAAAA = Data[6].ToString() + Data[7].ToString() + Data[2].ToString() + Data[3].ToString() + Data[0].ToString() + Data[1].ToString();
                                            if (Formato == "MMDDAAAA")
                                                MMDDAAAA = Data[6].ToString() + Data[7].ToString() + Data[0].ToString() + Data[1].ToString() + Data[2].ToString() + Data[3].ToString();
                                            if (Formato == "AAAAMMDD")
                                                MMDDAAAA = Data[2].ToString() + Data[3].ToString() + Data[4].ToString() + Data[5].ToString() + Data[6].ToString() + Data[7].ToString();
                                            if (Formato == "AAAADDMM")
                                                MMDDAAAA = Data[2].ToString() + Data[3].ToString() + Data[6].ToString() + Data[7].ToString() + Data[4].ToString() + Data[5].ToString();
                                            if (Formato == "MMAAAADD")
                                                MMDDAAAA = Data[4].ToString() + Data[5].ToString() + Data[0].ToString() + Data[1].ToString() + Data[6].ToString() + Data[7].ToString();
                                            if (Formato == "DDAAAAMM")
                                                MMDDAAAA = Data[4].ToString() + Data[5].ToString() + Data[6].ToString() + Data[7].ToString() + Data[0].ToString() + Data[1].ToString();

                                            if (Formato == "DD/MM/AAAA")
                                                MMDDAAAA = ter.Substring(2, 2) + seg + pri;
                                            if (Formato == "MM/DD/AAAA")
                                                MMDDAAAA = ter.Substring(2, 2) + pri + seg;
                                            if (Formato == "AAAA/MM/DD")
                                                MMDDAAAA = pri.Substring(2, 2) + seg + ter;
                                            if (Formato == "AAAA/DD/MM")
                                                MMDDAAAA = pri.Substring(2, 2) + ter + seg;
                                            if (Formato == "MM/AAAA/DD")
                                                MMDDAAAA = seg.Substring(2, 2) + pri + ter;
                                            if (Formato == "DD/AAAA/MM")
                                                MMDDAAAA = seg.Substring(2, 2) + ter + pri;

                                            return MMDDAAAA + ' ' + DataHora[1];
                                        }
                                        else
                                        {
                                            if (Para == "DDMMAAAA")
                                                DDMMAAAA = pri + seg + ter;
                                            if (Para == "MMDDAAAA")
                                                DDMMAAAA = Data[2].ToString() + Data[3].ToString() + '/' + Data[0].ToString() + Data[1].ToString() + '/' + Data[4].ToString() + Data[5].ToString() + Data[6].ToString() + Data[7].ToString();
                                            if (Para == "AAAAMMDD")
                                                DDMMAAAA = ter + seg + pri;
                                            if (Para == "AAAADDMM")
                                                DDMMAAAA = ter + pri + seg;
                                            if (Para == "MMAAAADD")
                                                DDMMAAAA = Data[6].ToString() + Data[7].ToString() + '/' + Data[0].ToString() + Data[1].ToString() + '/' + Data[2].ToString() + Data[3].ToString() + Data[4].ToString() + Data[5].ToString();
                                            if (Para == "DDAAAAMM")
                                                DDMMAAAA = Data[0].ToString() + Data[1].ToString() + '/' + Data[6].ToString() + Data[7].ToString() + '/' + Data[2].ToString() + Data[3].ToString() + Data[4].ToString() + Data[5].ToString();

                                            if (Para == "DD/MM/AAAA")
                                                DDMMAAAA = pri + '/' + seg + '/' + ter;
                                            if (Para == "MM/DD/AAAA")
                                                DDMMAAAA = seg + '/' + pri + '/' + ter;
                                            if (Para == "AAAA/MM/DD")
                                                DDMMAAAA = ter + '/' + seg + '/' + pri;
                                            if (Para == "AAAA/DD/MM")
                                                DDMMAAAA = seg + '/' + ter + '/' + pri;
                                            if (Para == "MM/AAAA/DD")
                                                DDMMAAAA = ter + '/' + pri + '/' + seg;
                                            if (Para == "DD/AAAA/MM")
                                                DDMMAAAA = pri + '/' + ter + '/' + seg;
                                            if (Para == "DDMMAA")
                                                DDMMAAAA = pri + "" + seg + "" + ter.Substring(2, 2);

                                            return DDMMAAAA + ' ' + DataHora[1];
                                        }

        return "";
    }
    public static string DuasCasas(string Numero)
    {
        if (Convert.ToInt32(Numero) == 0)
            return "00";
        if (Convert.ToInt32(Numero) == 1)
            return "01";
        if (Convert.ToInt32(Numero) == 2)
            return "02";
        if (Convert.ToInt32(Numero) == 3)
            return "03";
        if (Convert.ToInt32(Numero) == 4)
            return "04";
        if (Convert.ToInt32(Numero) == 5)
            return "05";
        if (Convert.ToInt32(Numero) == 6)
            return "06";
        if (Convert.ToInt32(Numero) == 7)
            return "07";
        if (Convert.ToInt32(Numero) == 8)
            return "08";
        if (Convert.ToInt32(Numero) == 9)
            return "09";

        return Numero;
    }
    public static string CodUsuario(string Usuario)
    {
        string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["CobNetDataBaseConnectionString"].ConnectionString.ToString();
        SqlDataAdapter TaConsulta = new SqlDataAdapter("Select Us_Id from Tb_Usuario (NOLOCK) where Us_Senha='" + Usuario + "'", strConn);
        DataTable TableConsulta = new DataTable();

        TaConsulta.Fill(TableConsulta);

        if (TableConsulta.Rows.Count > 0)
            return TableConsulta.Rows[0]["Us_Id"].ToString();

        return "Null";
    }
    public static string NomeUsuario(string Usuario)
    {
        string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["CobNetDataBaseConnectionString"].ConnectionString.ToString();
        SqlDataAdapter TaConsulta = new SqlDataAdapter("Select Us_Nome from Tb_Usuario (NOLOCK) where Us_Id='" + Usuario + "'", strConn);
        DataTable TableConsulta = new DataTable();

        TaConsulta.Fill(TableConsulta);

        if (TableConsulta.Rows.Count > 0)
            return TableConsulta.Rows[0]["Us_Nome"].ToString();

        return "Null";
    }
    public static string AcrescentaZeros(string Valor, int Tamanho)
    {
        for (int QuantidadeZeros = Valor.Length + 1; QuantidadeZeros <= Tamanho; QuantidadeZeros++)
        {
            Valor = '0' + Valor;
        }
        return Valor;
    }
    public static string AcrescentaEspaco(string Valor, int Tamanho)
    {
        //Int64 i64 = 0;
        //if (Int64.TryParse(Valor, out i64))
        //    Valor = i64.ToString();

        if (Valor.Length > Tamanho)
            throw new Exception("Valor é maior do que o tamanho máximo permitido!");

        for (int QuantidadeZeros = Valor.Length + 1; QuantidadeZeros <= Tamanho; QuantidadeZeros++)
        {
            Valor = Valor + " ";
        }
        return Valor;
    }
    public static string AcrescentaEspacoEsquerda(string Valor, int Tamanho)
    {
        for (int QuantidadeZeros = Valor.Length + 1; QuantidadeZeros <= Tamanho; QuantidadeZeros++)
        {
            Valor = " " + Valor;
        }
        return Valor;
    }
    public static string AjustaTamanho(string Valor, int Tamanho, bool Zero, bool Esquerda)
    {
        string Variavel = " ";
        if (Zero)
            Variavel = "0";

        if (Valor.Length < Tamanho)
        {
            for (int Quantidade = Valor.Length + 1; Quantidade <= Tamanho; Quantidade++)
            {
                if (Esquerda)
                    Valor = Variavel + Valor;
                else
                    Valor = Valor + Variavel;
            }
        }
        if (Valor.Length > Tamanho)
        {
            if (Esquerda)
                Valor = Valor.Substring(Valor.Length - Tamanho);
            else
                Valor = Valor.Substring(0, Tamanho);
        }

        return Valor;
    }
    public static string CPFCNPJ(string CPFCNPJ)
    {
        string Acertado;
        int i;

        for (i = 0; i < CPFCNPJ.Length; i++)
            if (Convert.ToString("123456789").Contains(CPFCNPJ[i].ToString()))
                break;

        Acertado = CPFCNPJ.Substring(i, CPFCNPJ.Length - i);

        return Acertado;
    }

    public static bool ENumero(string Texto)
    {
        try
        {
            Convert.ToDouble(Texto);
        }
        catch (Exception ex)
        {
            return false;
        }

        return true;
    }

    public static bool EData(string Texto)
    {
        try
        {
            Convert.ToDateTime(Texto);
        }
        catch (Exception ex)
        {
            return false;
        }
        return true;
    }

    public static string TirarAcentos(string texto)
    {
        string strTextoResul = "";

        for (int i = 0; i < texto.Length; i++)
        {
            if (texto[i].ToString() == "ã") strTextoResul += "a";
            else if (texto[i].ToString() == "á") strTextoResul += "a";
            else if (texto[i].ToString() == "à") strTextoResul += "a";
            else if (texto[i].ToString() == "â") strTextoResul += "a";
            else if (texto[i].ToString() == "ä") strTextoResul += "a";
            else if (texto[i].ToString() == "é") strTextoResul += "e";
            else if (texto[i].ToString() == "è") strTextoResul += "e";
            else if (texto[i].ToString() == "ê") strTextoResul += "e";
            else if (texto[i].ToString() == "ë") strTextoResul += "e";
            else if (texto[i].ToString() == "í") strTextoResul += "i";
            else if (texto[i].ToString() == "ì") strTextoResul += "i";
            else if (texto[i].ToString() == "ï") strTextoResul += "i";
            else if (texto[i].ToString() == "õ") strTextoResul += "o";
            else if (texto[i].ToString() == "ó") strTextoResul += "o";
            else if (texto[i].ToString() == "ò") strTextoResul += "o";
            else if (texto[i].ToString() == "ö") strTextoResul += "o";
            else if (texto[i].ToString() == "ú") strTextoResul += "u";
            else if (texto[i].ToString() == "ù") strTextoResul += "u";
            else if (texto[i].ToString() == "ü") strTextoResul += "u";
            else if (texto[i].ToString() == "ç") strTextoResul += "c";
            else if (texto[i].ToString() == "Ã") strTextoResul += "A";
            else if (texto[i].ToString() == "Á") strTextoResul += "A";
            else if (texto[i].ToString() == "À") strTextoResul += "A";
            else if (texto[i].ToString() == "Â") strTextoResul += "A";
            else if (texto[i].ToString() == "Ä") strTextoResul += "A";
            else if (texto[i].ToString() == "É") strTextoResul += "E";
            else if (texto[i].ToString() == "È") strTextoResul += "E";
            else if (texto[i].ToString() == "Ê") strTextoResul += "E";
            else if (texto[i].ToString() == "Ë") strTextoResul += "E";
            else if (texto[i].ToString() == "Í") strTextoResul += "I";
            else if (texto[i].ToString() == "Ì") strTextoResul += "I";
            else if (texto[i].ToString() == "Ï") strTextoResul += "I";
            else if (texto[i].ToString() == "Õ") strTextoResul += "O";
            else if (texto[i].ToString() == "Ó") strTextoResul += "O";
            else if (texto[i].ToString() == "Ò") strTextoResul += "O";
            else if (texto[i].ToString() == "Ö") strTextoResul += "O";
            else if (texto[i].ToString() == "Ú") strTextoResul += "U";
            else if (texto[i].ToString() == "Ù") strTextoResul += "U";
            else if (texto[i].ToString() == "Ü") strTextoResul += "U";
            else if (texto[i].ToString() == "Ç") strTextoResul += "C";
            else strTextoResul += texto[i];
        }
        return strTextoResul;
    }

    public static string AcrescentaProximoMes(string DATA)
    {
        try
        {
            Convert.ToDateTime(DATA);
        }
        catch (Exception ex)
        {
            return null;
        }

        int MesHoje = Convert.ToDateTime(DATA).Month;
        int MesAmanha = Convert.ToDateTime(DATA).AddDays(1).Month;

        int DiasARetirar = 0;

        DateTime ProximaData;

        if (MesHoje != MesAmanha)
        {
            ProximaData = Convert.ToDateTime(DATA).AddMonths(2);
            DiasARetirar = ProximaData.Day;
            ProximaData = ProximaData.AddDays(-DiasARetirar);
        }
        else
        {
            ProximaData = Convert.ToDateTime(DATA).AddMonths(1);
        }

        return ProximaData.ToString("dd/MM/yyyy");
    }

    public static string IniciarLog(string Usuario, string Select, string Nome)
    {
        SqlCommand Command = new SqlCommand();
        string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["CobNetDataBaseConnectionString"].ConnectionString.ToString();
        Command.Connection = new SqlConnection(strConn);
        Command.Connection.Open();
        Command.CommandText = "Select max(AnaliseQuery_id) as AnaliseQuery_id from Tb_AnaliseQuery (NOLOCK) ";
        string AnaliseQuery_id = Command.ExecuteScalar().ToString();
        if (AnaliseQuery_id == "")
            AnaliseQuery_id = "0";
        AnaliseQuery_id = Convert.ToString(Convert.ToInt32(AnaliseQuery_id) + 1);

        Command.CommandText = "Insert into Tb_AnaliseQuery (AnaliseQuery_id, AnaliseQuery_Usuario, AnaliseQuery_Query, AnaliseQuery_Inicio, AnaliseQuery_Modulo) values (" + AnaliseQuery_id + ", " + Usuario + ", '" + Select.Replace("'", "\"") + "', getdate(), '" + Nome + "')";
        Command.ExecuteNonQuery();
        Command.Connection.Close();

        return AnaliseQuery_id;
    }
    public static void FecharLog(string Codigo)
    {
        SqlCommand Command = new SqlCommand();
        string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["CobNetDataBaseConnectionString"].ConnectionString.ToString();
        Command.Connection = new SqlConnection(strConn);
        Command.Connection.Open();
        Command.CommandText = "Update Tb_AnaliseQuery set AnaliseQuery_Fim = getdate() where AnaliseQuery_id = " + Codigo + ";";
        Command.ExecuteNonQuery();
        Command.Connection.Close();
    }

    public static void AjustaSaldoContrato(string contrato)
    {
        string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["CobNetDataBaseConnectionString"].ConnectionString.ToString();

        SqlDataAdapter TaPesquisaContrato = new SqlDataAdapter(@"Select Sum(Tb_Parcela.Parc_Saldo) as Saldo
	, Min(Tb_Parcela.Parc_Vencimento) as Vencimento
	, count(tb_Parcela.Parc_parc_Plano) as QtdeParc 
	, MIN(dbo.FSParcela(Parc_Parc_Plano)) as Parcela
	, MIN(dbo.FSPlano(Parc_Parc_Plano)) as Plano
	, convert(int,round(convert(decimal,MIN(dbo.FSParcela(Parc_Parc_Plano))) / MIN(dbo.FSPlano(Parc_Parc_Plano)),2)*100) PercPlanoPago
from tb_Parcela (NOLOCK) 
where contr_contrato = @Contrato 
	and Parc_OrigemParcela = 'Credor - Original' 
	and parc_saldo > 0", strConn);
        DataTable TablePesquisaContrato = new DataTable();

        //TaPesquisaContrato.SelectCommand.Parameters.AddWithValue("@Contrato", contrato);
        TaPesquisaContrato.SelectCommand.Parameters.Add(Cs_Acerta.CustomParameter( "@Contrato", SqlDbType.VarChar, 50, contrato));
        TaPesquisaContrato.Fill(TablePesquisaContrato);

        if (TablePesquisaContrato.Rows[0]["Vencimento"].ToString() != "")
        {
            SqlCommand Command = new SqlCommand();
            Command.Connection = new SqlConnection(strConn);

            Command.Connection.Open();
            Command.CommandText = "Update tb_contrato set Contr_MinVencimento = '" + Cs_Acerta.AcertaData(TablePesquisaContrato.Rows[0]["Vencimento"].ToString(), "DD/MM/AAAA", "MM/DD/AAAA") + "', Contr_SaldoContrato = " + TablePesquisaContrato.Rows[0]["Saldo"].ToString().Replace(",", ".") + ", Contr_QtdeParcelas = " + TablePesquisaContrato.Rows[0]["QtdeParc"].ToString() + ", Contr_MinParcela = " + TablePesquisaContrato.Rows[0]["Parcela"].ToString() + ", Contr_Plano = " + TablePesquisaContrato.Rows[0]["Plano"].ToString() + ", Contr_PercPlanoPago = " + TablePesquisaContrato.Rows[0]["PercPlanoPago"].ToString() + " where contr_contrato = '" + contrato + "'";
            Command.ExecuteNonQuery();
            Command.Connection.Close();
        }
        else
        {
            SqlCommand Command = new SqlCommand();
            Command.Connection = new SqlConnection(strConn);

            Command.Connection.Open();
            Command.CommandText = "Update tb_contrato set Contr_MinVencimento = NULL, Contr_SaldoContrato = 0, Contr_QtdeParcelas = 0 where contr_contrato = '" + contrato + "'";
            Command.ExecuteNonQuery();
            Command.Connection.Close();
        }
    }

    public static string AcertaCEP(string strCEP)
    {
        string CEPResult = "";

        try
        {
            int CEP = 0;

            if (strCEP == string.Empty)
                return string.Empty;

            CEP = Convert.ToInt32(strCEP.Replace("-", "").Replace(".", ""));

            if (strCEP.Length == 8)
            {
                if (!(strCEP.Contains("000000")
                    || strCEP.Contains("111111")
                    || strCEP.Contains("222222")
                    || strCEP.Contains("333333")
                    || strCEP.Contains("444444")
                    || strCEP.Contains("555555")
                    || strCEP.Contains("666666")
                    || strCEP.Contains("777777")
                    || strCEP.Contains("888888")
                    || strCEP.Contains("999999")))
                {
                    CEPResult = CEP.ToString();
                    return CEPResult;
                }
            }
        }
        catch (Exception ex)
        {
            string Erro = ex.Message;

            return "";
        }

        return "";
    }

    public static string AcertaRamal(string strRamal)
    {
        string RamalResult = string.Empty;

        try
        {
            int Ramal = 0;

            if (string.IsNullOrEmpty(strRamal.Trim()))
                return string.Empty;

            if (Int32.TryParse(strRamal.Trim(), out Ramal))
                return Ramal.ToString();
            else
                return string.Empty;

            //if (Ramal >= 2 && Ramal <= 6)
            //{
            //    RamalResult = Ramal.ToString();
            //    return RamalResult;
            //}
        }
        catch (Exception ex)
        {
            string Erro = ex.Message;

            return "";
        }

        return "";
    }

    public static string AcertaDDD(string strDDD)
    {
        string DDDResult = "";

        try
        {
            int DDD = 0;


            if (strDDD == string.Empty)
                return string.Empty;

            DDD = Convert.ToInt16(strDDD);

            if (DDD > 10 && DDD < 100)
            {
                DDDResult = DDD.ToString();
                return DDDResult;
            }
        }
        catch (Exception ex)
        {
            string Erro = ex.Message;

            return "";
        }

        return "";
    }

    public static string AcertaTelefone(string strTelefone)
    {
        string TelResult = "";

        try
        {
            string Telefone = string.Empty;

            if (string.IsNullOrEmpty(strTelefone))
                return string.Empty;


            Telefone = strTelefone.Trim();

            if (strTelefone.Length == 8 || strTelefone.Length == 9)
            {
                if (!(strTelefone.Contains("000000")
                    || strTelefone.Contains("111111")
                    || strTelefone.Contains("222222")
                    || strTelefone.Contains("333333")
                    || strTelefone.Contains("444444")
                    || strTelefone.Contains("555555")
                    || strTelefone.Contains("666666")
                    || strTelefone.Contains("777777")
                    || strTelefone.Contains("888888")
                    || strTelefone.Contains("999999")))
                {
                    TelResult = Telefone;
                    return TelResult;
                }
            }
        }
        catch (Exception ex)
        {
            string Erro = ex.Message;

            return "";
        }

        return "";
    }
}
