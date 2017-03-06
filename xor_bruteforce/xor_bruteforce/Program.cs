using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace xor_bruteforce
{
    class Program
    {
        //szavak az ellenőruéshez
        static string[] szavak = { "feladat", "szöveg", };

        static string kodoltszoveg;

        public static int probalkozas = 1;

        public static bool megoldva = false;

        static Thread core1 = new Thread(new ThreadStart(Core1));
        static Thread core2 = new Thread(new ThreadStart(Core2));
        static Thread core3 = new Thread(new ThreadStart(Core3));
        static Thread core4 = new Thread(new ThreadStart(Core4));

        //beállítások
        static int minhossz = 0;
        static int maxhossz = 10;
        // 1 = igen | 2 = nem
        static int lehet_nagybetu = 0;
        static int lehet_kisbetu = 0;
        static int lehet_szam = 1;
        static int lehet_special = 0;

        static string input = "";
        static string output = "";

        //készít egy kódolt szöveget
        static string feladatkeszites()
        {
            string text;
            text = exor("A titkositt szöveges feladat", "1234567");

            return text;
        }

        //static void Main(string[] args)
        static void Main(string[] args)
        {
            if (args.Length != 0)
            {
                if (args.Length > 0)
                    input = args[0];
                if (args.Length > 1)
                    output = args[1];
            }
            //minhossz beállítása
            core1prog.minhossz(minhossz);
            core2prog.minhossz(minhossz);
            core3prog.minhossz(minhossz);
            core4prog.minhossz(minhossz);

            //feladatkészítés hívása
            //kodoltszoveg = feladatkeszites();

            //feladat beolvasása
            string szoveg = System.IO.File.ReadAllText(input);
            kodoltszoveg = exor(szoveg, "123");
            Console.WriteLine(kodoltszoveg);
            Console.ReadKey();

            //kiírás fájlba
            //System.IO.File.WriteAllLines(output, szoveg);

            //multithread indítása
            /*
            core1.Start();
            core2.Start();
            core3.Start();
            core4.Start();
            */



        }

        //exor 
        static string exor(string text, string key)
        {
            char[] output = new char[text.Length];

            for (int i = 0; i < text.Length; i++)
                output[i] = (char)(text[i] ^ key[i % key.Length]);

            return new string(output);
        }

        //dedolt szöveg tesztelése
        static void teszt(string text, string key)
        {
            //tartalmaz-e megadott szavakat
            if (szavak.Any(text.Contains))
            {
                Console.WriteLine("Megoldás: " + text);
                Console.WriteLine("Próba: " + probalkozas);
                Console.WriteLine("Kulcs: " + key);
            }
            //vagy szóhosszúság ellenőrzése
            if (text.Contains(' '))
            {
                int space = text.Split(' ').Length - 1;
                int szoveghossz = text.Length;
                int szohossz = szoveghossz / space;
                if (szohossz > 6 && szohossz < 9
                    && text.Contains("hogy")
                    && text.Contains("az")
                    && text.Contains("nem")
                    && text.Contains("ha"))
                {
                    Console.WriteLine("Megoldás: " + text);
                    Console.WriteLine("Próba: " + probalkozas);
                    Console.WriteLine("Kulcs: " + key);
                }
            }
        }

        
        static void Core1()
        {
            //checkpoint az időnkénti kiíratáshoz
            int checkpoint = 0;
            //megadja a kulcs karakterkészletét
            core1prog.arraybuilder(lehet_nagybetu, lehet_kisbetu, lehet_szam, lehet_special, 0);
            string kulcs;
            //páratlan számú kulcs miatt 1x
            kulcs = core1prog.strconst(maxhossz);
            while (megoldva == false)
            {
                //2x generál kulcsot hogy páratlan maradjon
                kulcs = core1prog.strconst(maxhossz);
                kulcs = core1prog.strconst(maxhossz);
                //időnkénti kiíratás
                if (probalkozas > checkpoint + 20000000)
                {
                    Console.WriteLine("Próba: " + probalkozas);
                    Console.WriteLine("Kulcs: " + kulcs);
                    checkpoint = probalkozas;
                }
                probalkozas++;

                //szöveg tesztelése
                teszt(exor(kodoltszoveg, kulcs), kulcs);
            }
        }
        static void Core2()
        {

            core2prog.arraybuilder(lehet_nagybetu, lehet_kisbetu, lehet_szam, lehet_special, 0);
            string kulcs;
            //2x hogy páros legyen
            kulcs = core2prog.strconst(maxhossz);
            kulcs = core2prog.strconst(maxhossz);
            while (megoldva == false)
            {
                //2x hogy páros maradjon
                kulcs = core2prog.strconst(maxhossz);
                kulcs = core2prog.strconst(maxhossz);

                probalkozas++;

                teszt(exor(kodoltszoveg, kulcs), kulcs);
            }
        }
        static void Core3()
        {
            core3prog.arraybuilder(lehet_nagybetu, lehet_kisbetu, lehet_szam, lehet_special, 1);
            string kulcs;
            kulcs = core3prog.strconst(maxhossz);
            while (megoldva == false)
            {
                kulcs = core3prog.strconst(maxhossz);
                kulcs = core3prog.strconst(maxhossz);

                probalkozas++;

                teszt(exor(kodoltszoveg, kulcs), kulcs);
            }
        }
        static void Core4()
        {
            core4prog.arraybuilder(lehet_nagybetu, lehet_kisbetu, lehet_szam, lehet_special, 1);
            string kulcs;
            kulcs = core4prog.strconst(maxhossz);
            kulcs = core4prog.strconst(maxhossz);
            while (megoldva == false)
            {
                kulcs = core4prog.strconst(maxhossz);
                kulcs = core4prog.strconst(maxhossz);

                probalkozas++;

                teszt(exor(kodoltszoveg, kulcs), kulcs);
            }
        }
    }
}
