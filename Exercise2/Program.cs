using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    class Program
    {
        public static void SC_58029_Cut(ref int sc_58029_DlugoscSlownika, ref string sc_58029_Dictionary, ref int sc_58029_RozmiarPrzycieciaSlownika, ref int sc_58029_DictionaryLenght)
        {
            sc_58029_DlugoscSlownika = sc_58029_Dictionary.Length;
            sc_58029_RozmiarPrzycieciaSlownika = sc_58029_DlugoscSlownika - sc_58029_DictionaryLenght;
            sc_58029_Dictionary = sc_58029_Dictionary.Remove(0, sc_58029_RozmiarPrzycieciaSlownika);
        }
        public static void SC_58029_PojZnak(ref string sc_58029_Dictionary, ref string sc_58029_Dopasowane, ref string sc_58029_Znak, ref List<string> sc_58029_ResultCode, ref string sc_58029_Pozostaly, ref string sc_58029_Roboczy)
        {
            sc_58029_Dictionary = sc_58029_Dictionary + sc_58029_Dopasowane + sc_58029_Znak;
            sc_58029_ResultCode.Add("(0, 0, " + sc_58029_Znak + ")");
            sc_58029_Pozostaly = sc_58029_Roboczy.Remove(0, 1);
            sc_58029_Dopasowane = "";
        }
        public static void SC_58029_Znacznik(ref int sc_58029_DlugoscDopasowania, ref string sc_58029_Dopasowane, ref List<string> sc_58029_ResultCode, ref int sc_58029_IndexStartowy)
        {
            sc_58029_DlugoscDopasowania = sc_58029_Dopasowane.Length;
            sc_58029_ResultCode.Add("(" + sc_58029_IndexStartowy.ToString() + ", " + sc_58029_DlugoscDopasowania.ToString() + ", |EOF|)");
        }
        public static void SC_58029_Kod(ref int sc_58029_DlugoscDopasowania, ref string sc_58029_Dopasowane, ref List<string> sc_58029_ResultCode, ref int sc_58029_DictionaryLenght, ref int sc_58029_BufferLenght, ref int sc_58029_IndexStartowy, ref string sc_58029_Znak, ref string sc_58029_Dictionary)
        {
            sc_58029_DlugoscDopasowania = sc_58029_Dopasowane.Length;
            sc_58029_ResultCode.Add("(" + sc_58029_IndexStartowy.ToString() + ", " + sc_58029_DlugoscDopasowania.ToString() + ", " + sc_58029_Znak + ")");
            sc_58029_Dictionary = sc_58029_Dictionary + sc_58029_Dopasowane + sc_58029_Znak;
            sc_58029_IndexStartowy = 0;
            sc_58029_Dopasowane = "";
        }
        public static void SC_58029_Index(ref int sc_58029_Index, ref string sc_58029_Dictionary, ref string sc_58029_Dopasowane, ref int sc_58029_Przesuniecie, ref List<int> sc_58029_ListaWystapien)
        {
            sc_58029_Index = sc_58029_Dictionary.IndexOf(sc_58029_Dopasowane, sc_58029_Przesuniecie) + 1;
            sc_58029_ListaWystapien.Add(sc_58029_Index);
            sc_58029_Przesuniecie = sc_58029_Przesuniecie + sc_58029_Index - 1;
        }
        public static void SC_58029_Next(ref int sc_58029_IloscDopasowan, ref string sc_58029_Dictionary, ref string sc_58029_Dopasowane, ref string sc_58029_Znak, ref int sc_58029_IndexStartowy)
        {
            sc_58029_IloscDopasowan = System.Text.RegularExpressions.Regex.Matches(sc_58029_Dictionary, sc_58029_Dopasowane + sc_58029_Znak).Count;
            sc_58029_Dopasowane = sc_58029_Dopasowane + sc_58029_Znak;
            sc_58029_IndexStartowy = sc_58029_Dictionary.IndexOf(sc_58029_Dopasowane) + 1;
            sc_58029_Znak = "";
        }

        static void Main(string[] args)
        {
            
            string sc_58029_Source = "ABDDCACDCCDCAACADDBBACDCBDADCACACBCACDACCDAACCBCBABDABCDBBCAAADDBCBDDAADBABBABBDCBBADACAADBBAADDCDDABBABCBDACADBCDCABADBDDADBCCDDCBAAADABDBCCA" +
                "CABCCADCABAACBBDACDDBDCCBACDCCDCBADBDADCBBCCCCDAAABBCDCACBDAADAAACBADCBADDDABBDDAAD";
            int sc_58029_DictionaryLenght = 8;
            int sc_58029_BufferLenght = 9;
            
            Console.WriteLine("Ciąg przed kompresją:\n" + sc_58029_Source);
            
            Console.WriteLine("Wynik kompresji:");
            List<string> sc_58029_Kompresja = new List<string>();
            SC_58029_KompresjaLZ77(sc_58029_Source, ref sc_58029_Kompresja, sc_58029_DictionaryLenght, sc_58029_BufferLenght);
            sc_58029_Kompresja.ForEach(sc_58029_sc => Console.Write("{0}, ", sc_58029_sc));
            Console.WriteLine();
           
            List<string> sc_58029_Dekompresja = new List<string>();
            SC_58029_DekompresjaLZ77(string.Join("", sc_58029_Kompresja), ref sc_58029_Dekompresja, sc_58029_DictionaryLenght);
            Console.WriteLine("Wynik dekompresji:");
            sc_58029_Dekompresja.ForEach(Console.Write);

            Console.ReadKey();
        }
        public static void SC_58029_KompresjaLZ77(string sc_58029_Source, ref List<string> sc_58029_ResultCode, int sc_58029_DictionaryLenght, int sc_58029_BufferLenght)
        {
            string sc_58029_Znak;
            string sc_58029_Roboczy;
            string sc_58029_Pozostaly;
            string sc_58029_Dopasowane = "";
            string sc_58029_Dictionary = "";
            int sc_58029_IndexStartowy = 0;
            int sc_58029_IloscDopasowan = 0;
            int sc_58029_DlugoscDopasowania = 0;
            int sc_58029_DlugoscSlownika = 0;
            int sc_58029_RozmiarPrzycieciaSlownika = 0;


            List<int> sc_58029_ListaWystapien = new List<int>();
            sc_58029_Pozostaly = sc_58029_Source;
            do
            {
                sc_58029_Roboczy = sc_58029_Pozostaly;
                sc_58029_Znak = "";
                sc_58029_Znak = sc_58029_Roboczy.Substring(0, 1);
                if (sc_58029_Dictionary.Length > 0)
                {
                    if (sc_58029_Dictionary.Contains(sc_58029_Znak) && sc_58029_Dopasowane.Length <= sc_58029_BufferLenght)
                    {
                        if (sc_58029_Dopasowane.Length == 0)
                        {
                            sc_58029_IndexStartowy = sc_58029_Dictionary.IndexOf(sc_58029_Znak) + 1;
                            sc_58029_Dopasowane = sc_58029_Dopasowane + sc_58029_Znak;

                        }
                        else

                        if (sc_58029_Dictionary.Contains(sc_58029_Dopasowane + sc_58029_Znak))
                        {
                            SC_58029_Next(ref sc_58029_IloscDopasowan, ref sc_58029_Dictionary, ref sc_58029_Dopasowane, ref sc_58029_Znak, ref sc_58029_IndexStartowy);
                        }
                        else
                        {
                            if (sc_58029_IloscDopasowan > 1)
                            {
                                int sc_58029_Przesuniecie = sc_58029_Dopasowane.Length;
                                int sc_58029_Index = 0;
                                do
                                {
                                    SC_58029_Index(ref sc_58029_Index, ref sc_58029_Dictionary, ref sc_58029_Dopasowane, ref sc_58029_Przesuniecie, ref sc_58029_ListaWystapien);
                                }
                                while (sc_58029_Przesuniecie <= sc_58029_Dictionary.Length);
                                sc_58029_IndexStartowy = sc_58029_ListaWystapien[0];
                                sc_58029_ListaWystapien.Clear();
                            }
                            SC_58029_Kod(ref sc_58029_DlugoscDopasowania, ref sc_58029_Dopasowane, ref sc_58029_ResultCode, ref sc_58029_DictionaryLenght, ref sc_58029_BufferLenght, ref sc_58029_IndexStartowy, ref sc_58029_Znak, ref sc_58029_Dictionary);
                        }
                        sc_58029_Pozostaly = sc_58029_Roboczy.Remove(0, 1);
                    }
                    else
                    {
                        SC_58029_Kod(ref sc_58029_DlugoscDopasowania, ref sc_58029_Dopasowane, ref sc_58029_ResultCode, ref sc_58029_DictionaryLenght, ref sc_58029_BufferLenght, ref sc_58029_IndexStartowy, ref sc_58029_Znak, ref sc_58029_Dictionary);
                        sc_58029_Pozostaly = sc_58029_Roboczy.Remove(0, 1);
                    }
                }
                else
                {
                    SC_58029_PojZnak(ref sc_58029_Dictionary, ref sc_58029_Dopasowane, ref sc_58029_Znak, ref sc_58029_ResultCode, ref sc_58029_Pozostaly, ref sc_58029_Roboczy);
                }
                if (sc_58029_Dictionary.Length > sc_58029_DictionaryLenght)
                {
                    SC_58029_Cut(ref sc_58029_DlugoscSlownika, ref sc_58029_Dictionary, ref sc_58029_RozmiarPrzycieciaSlownika, ref sc_58029_DictionaryLenght);
                }
            }
            while (sc_58029_Pozostaly.Length > 0);
            SC_58029_Znacznik(ref sc_58029_DlugoscDopasowania, ref sc_58029_Dopasowane, ref sc_58029_ResultCode, ref sc_58029_IndexStartowy);
        }
        public static void SC_58029_DekompresjaLZ77(string sc_58029_Source, ref List<string> sc_58029_RecultCode, int sc_58029_DictionaryLenght)
        {
            string sc_58029_Znak;
            string sc_58029_Roboczy;
            string sc_58029_Pozostaly;
            string sc_58029_Dictionary = "";
            string sc_58029_OdczytaneZnaki = "";
            int sc_58029_IndexDopasowania = 0;
            int sc_58029_DlugoscDopasowania = 0;
            int sc_58029_DlugoscSlownika = 0;
            int sc_58029_RozmiarPzycieciaSlownika = 0;
            List<int> sc_58029_ListaWystapien = new List<int>();
            sc_58029_Pozostaly = sc_58029_Source.Replace(" ", "").Replace("EOF|)", "");
            do
            {
                do
                {
                    sc_58029_Roboczy = sc_58029_Pozostaly;
                    sc_58029_Znak = sc_58029_Roboczy.Substring(0, 1);
                    sc_58029_Pozostaly = sc_58029_Roboczy.Remove(0, 1);
                }
                while (sc_58029_Znak != "(");
                sc_58029_Znak = "";
                do
                {
                    sc_58029_OdczytaneZnaki = sc_58029_OdczytaneZnaki + sc_58029_Znak;
                    sc_58029_Roboczy = sc_58029_Pozostaly;
                    sc_58029_Znak = sc_58029_Roboczy.Substring(0, 1);
                    sc_58029_Pozostaly = sc_58029_Roboczy.Remove(0, 1);
                }
                while (sc_58029_Znak != ",");
                sc_58029_IndexDopasowania = Convert.ToInt32(sc_58029_OdczytaneZnaki);
                sc_58029_OdczytaneZnaki = "";
                sc_58029_Znak = "";
                do
                {
                    sc_58029_OdczytaneZnaki = sc_58029_OdczytaneZnaki + sc_58029_Znak;
                    sc_58029_Roboczy = sc_58029_Pozostaly;
                    sc_58029_Znak = sc_58029_Roboczy.Substring(0, 1);
                    sc_58029_Pozostaly = sc_58029_Roboczy.Remove(0, 1);
                }
                while (sc_58029_Znak != ",");
                sc_58029_DlugoscDopasowania = Convert.ToInt32(sc_58029_OdczytaneZnaki);
                sc_58029_OdczytaneZnaki = "";
                sc_58029_Znak = "";
                sc_58029_Roboczy = sc_58029_Pozostaly;
                sc_58029_Znak = sc_58029_Roboczy.Substring(0, 1);
                sc_58029_Pozostaly = sc_58029_Roboczy.Remove(0, 1);
                if (sc_58029_DlugoscDopasowania > 0)
                {
                    if (sc_58029_Znak == "|")
                        sc_58029_Znak = "";
                    sc_58029_RecultCode.Add(sc_58029_Dictionary.Substring(sc_58029_IndexDopasowania - 1, sc_58029_DlugoscDopasowania) + sc_58029_Znak);
                    sc_58029_Dictionary = sc_58029_Dictionary + sc_58029_Dictionary.Substring(sc_58029_IndexDopasowania - 1, sc_58029_DlugoscDopasowania) + sc_58029_Znak;
                }
                else
                {
                    sc_58029_RecultCode.Add(sc_58029_Znak);
                    if (sc_58029_Dictionary.Length > 0)
                        sc_58029_Dictionary = sc_58029_Dictionary + sc_58029_Znak;
                    else
                        sc_58029_Dictionary = sc_58029_Znak;
                }
                if (sc_58029_Dictionary.Length > sc_58029_DictionaryLenght)
                {
                    sc_58029_DlugoscSlownika = sc_58029_Dictionary.Length;
                    sc_58029_RozmiarPzycieciaSlownika = sc_58029_DlugoscSlownika - sc_58029_DictionaryLenght;
                    sc_58029_Dictionary = sc_58029_Dictionary.Remove(0, sc_58029_RozmiarPzycieciaSlownika);
                }
                sc_58029_IndexDopasowania = 0;
                sc_58029_DlugoscDopasowania = 0;
                sc_58029_Znak = "";
            }
            while (sc_58029_Pozostaly != "|" && sc_58029_Pozostaly != "" && sc_58029_Pozostaly != ")");
        }
    }
}
