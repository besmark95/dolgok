using System;

namespace xor_bruteforce
{
    //a többi core.cs is ugyan ez


    static class core1prog
    {
        //karakterkészletek
        public static char[] upper = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', };
        public static char[] lower = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', };
        public static char[] number = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public static char[] special = new char[] { '`', '~', '!', '@', '#', '$', '%', '^', '*', '(', ')', '_', '+', '-', '=', '{', '}', '|', '[', ']', '&', '\\', ':', '\'', ';', '\'', '<', '>', '?', ',', '.', '/' };

        public static string[] egyedi = new string[] { "1", "2" };

        public static int a, b, c, d, e, f, g, h, i, j = 0;

        public static string[] arrayka;

        //karakterkészlet összerakása
        public static void arraybuilder(int up, int low, int num, int spec, int rev)
        {
            int arraylenght = 0;
            string sztring = "";
            if (up >= 1)
            {
                sztring += new string(upper);
                arraylenght += upper.Length;
            }
            if (low >= 1)
            {
                sztring += new string(lower);
                arraylenght += lower.Length;
            }
            if (num >= 1)
            {
                sztring += new string(number);
                arraylenght += number.Length;
            }
            if (spec >= 1)
            {
                sztring += new string(special);
                arraylenght += special.Length;
            }

            char[] chararray = sztring.ToCharArray();

            string[] stringarray = new string[arraylenght + 1];
            //az első elem üres
            stringarray[0] = null;

            for (int x = 1; x < arraylenght + 1; x++)
            {
                stringarray[x] = chararray[x - 1].ToString();
            }

            if (rev >= 1)
                Array.Reverse(stringarray);

            arrayka = stringarray;
        }

        //minimum hosszúság beállítása
        public static void minhossz(int min)
        {
            if (min == 0)
                return;
            if (min > 0)
                a = 1;
            if (min > 1)
                b = 1;
            if (min > 2)
                c = 1;
            if (min > 3)
                d = 1;
            if (min > 4)
                e = 1;
            if (min > 5)
                f = 1;
            if (min > 6)
                g = 1;
            if (min > 7)
                h = 1;
            if (min > 8)
                i = 1;
            if (min > 9)
                j = 1;
            if (min > 10)
                Console.WriteLine("A minimum rövidség túl nagy! A beírt érték: " + min);
        }

        //a kulcs összerakása
        public static string strconst(int maxhossz)
        {
            string egesz;


            egesz = arrayka[a] + arrayka[b] + arrayka[c] + arrayka[d] + arrayka[e] + arrayka[f] + arrayka[g] + arrayka[h] + arrayka[i] + arrayka[j];
            if (egesz.Length > maxhossz)
                return "Max hossz elérve!";

            a++;

            if (a == arrayka.Length)
            {
                a = 1;
                b++;
            }
            if (b == arrayka.Length)
            {
                b = 1;
                c++;
            }
            if (c == arrayka.Length)
            {
                c = 1;
                d++;
            }
            if (d == arrayka.Length)
            {
                d = 1;
                e++;
            }
            if (e == arrayka.Length)
            {
                e = 1;
                f++;
            }
            if (f == arrayka.Length)
            {
                f = 1;
                g++;
            }
            if (g == arrayka.Length)
            {
                g = 1;
                h++;
            }
            if (h == arrayka.Length)
            {
                h = 1;
                i++;
            }
            if (i == arrayka.Length)
            {
                i = 1;
                j++;
            }
            return egesz;
        }
    }
}