using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace program_conversii_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti baza 1 , baza 2 si numarul pe care doriti sa il covnertiti,daca numarul este intreg se va scrie cu ,0");
            string[] t = Console.ReadLine().Split(' ');
            int b1 = int.Parse(t[0]);
            int b2 = int.Parse(t[1]);
            string[] t2 = Console.ReadLine().Split(',');
            string intreg=t2[0];
            string fractionar=t2[1];
            double S = 0, F = 0;
            bool negativ = false;
            int j=0;
            string intregb2 ="";
            List<double> resturi = new List<double>();
            if (b1 == 10)
            {
                S = int.Parse(intreg);
                F = int.Parse(fractionar);
                if(S<0) negativ = true;
            }
            else
            {
                if (intreg.Contains("-")) negativ = true;
                if (b1 == 2 && (intreg[0]-'0') == 1) negativ = true;
                if (negativ) intreg = intreg.Remove(0, 1);
                 j = 0;
                for (int i = intreg.Length-1; i >=0; i--)
                {int a =Convert.ToInt32(intreg[i]);
                    switch (a)
                    {
                        case 48:a = 0;break;
                        case 49:a = 1;break;
                        case 50:a = 2;break;
                        case 51:a = 3;break;
                        case 52:a = 4;break;
                        case 53:a = 5;break;
                        case 54:a = 6;break;
                        case 55:a = 7;break;
                        case 56:a = 8;break;
                        case 57:a = 9;break;
                        case 97:a = 10;break;
                        case 98:a = 11;break;
                        case 99:a = 12;break;
                        case 100:a = 13;break;
                        case 101:a = 14;break;
                        case 102:a = 15;break;
                    }
                    S += a * Math.Pow(b1, j);
                    j++;
                }
                j = -1;
                for(int i=0;i<fractionar.Length;i++)
                {
                    int a = Convert.ToInt32(fractionar[i]);
                    switch (a)
                    {
                        case 48: a = 0; break;
                        case 49: a = 1; break;
                        case 50: a = 2; break;
                        case 51: a = 3; break;
                        case 52: a = 4; break;
                        case 53: a = 5; break;
                        case 54: a = 6; break;
                        case 55: a = 7; break;
                        case 56: a = 8; break;
                        case 57: a = 9; break;
                        case 97: a = 10; break;
                        case 98: a = 11; break;
                        case 99: a = 12; break;
                        case 100: a = 13; break;
                        case 101: a = 14; break;
                        case 102: a = 15; break;
                    }
                    F =F+ a*Math.Pow(b1,j);
                    j--;
                }  
            }
            if (b2 == 10)

                if (negativ) Console.WriteLine($"Numarul in baza {b2} este -{S + F}");
                else Console.WriteLine($"Numarul in baza {b2} este {S + F}");
            else
            {
                Console.WriteLine($"Numarul in baza {b2} este");
                if (b2 == 2 && negativ) Console.Write("1");
                    else if (negativ) Console.Write("-");
                int T = Convert.ToInt32(S);
                bool periodica = false;
                while (T > 0)
                {
                    int k=(T % b2);
                    switch (k)
                    {
                        case 0:intregb2+="0";break;
                        case 1:intregb2+="1";break;
                        case 2:intregb2+="2";break;
                        case 3:intregb2+="3";break;
                        case 4:intregb2+="4";break;
                        case 5:intregb2+="5";break;
                        case 6:intregb2+="6";break;
                        case 7:intregb2+="7";break;
                        case 8:intregb2+="8";break;
                        case 9:intregb2+="9";break;
                        case 10:intregb2+='a';break;
                        case 11:intregb2+='b';break;
                        case 12:intregb2+='c';break;
                        case 13:intregb2+='d';break;
                        case 14:intregb2+="e";break;
                        case 15:intregb2+="f";break;
                    }
                    T = T / b2;
                }
                for (int i = intregb2.Length-1; i >=0; i--) Console.Write(intregb2[i]);
                if(F!=0)Console.Write(",");
                string vir = "";
                int index = 0;
                while (F != 0)
                {
                    int cifra = Convert.ToInt32(Math.Truncate(F * b2));
                    F = F * b2 - cifra;
                    index++;
                    if (!resturi.Contains(cifra))
                    {
                        resturi.Add(cifra);
                        switch (cifra)
                        {
                            case 0: vir+="0"; break;
                            case 1: vir+="1"; break;
                            case 2: vir+="2"; break;
                            case 3: vir+="3"; break;
                            case 4: vir+="4"; break;
                            case 5: vir+="5"; break;
                            case 6: vir+="6"; break;
                            case 7: vir+="7"; break;
                            case 8: vir+="8"; break;
                            case 9: vir+="9"; break;
                            case 10: vir+='a'; break;
                            case 11: vir+='b'; break;
                            case 12: vir+='c'; break;
                            case 13: vir+='d'; break;
                            case 14: vir+="e"; break;
                            case 15: vir+="f"; break;
                        }
                    }
                    else
                    {
                        periodica = true;
                        vir = vir.Insert(index-resturi.IndexOf(cifra) -2 , "(");
                        vir += ")";
                        break;
                    }
                }
                Console.WriteLine(vir);
                
            }
        }
    }
}
