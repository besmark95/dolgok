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
		//a debug mappában(/xor_bruteforce/xor_bruteforce/bin/Debug) az indítófájl mellett található
		//egy lorem fájl ami lorem ipsumot tartalmazza ékezet nélküli ezért nincs benne hiba
		//egy ekezetes fájl ami ékezetes szöveget tartalmaz amit már nem jól jelenít meg
		//mindkét fájl az 123 kulccsal lett kódolva
		//más kulcsokkal szintén fenn áll ez a hiba

		//futtatni mono segítségével szoktam : mono xor_bruteforce.exe inputfájl
		//a beállításait csak programkódon belül lehet még változtatni


        //szavak az ellenőrzéshez
        static string[] szavak = { "feladat", "szöveg"," ipsum " };

        static string kodoltszoveg;
        static int probalkozas = 1;

        public static bool vege = false;

        static Thread core1 = new Thread(new ThreadStart(Core1));
        static Thread core2 = new Thread(new ThreadStart(Core2));
        static Thread core3 = new Thread(new ThreadStart(Core3));
        static Thread core4 = new Thread(new ThreadStart(Core4));

        //beállítások
        static int minhossz = 0;
        static int maxhossz = 10;
        // 1 = igen | 0 = nem
        static int lehet_nagybetu = 0;
        static int lehet_kisbetu = 0;
        static int lehet_szam = 1;
        static int lehet_special = 0;

        static string input = "";
		//jelenleg nincs output
        //static string output = "";

        //static void Main(string[] args)
        static void Main(string[] args)
        {
            if (args.Length != 0)
            {
                if (args.Length > 0)
                    input = args[0];
                /*if (args.Length > 1)
                    output = args[1];
                    */
            }

            /*
            //ez a rész csak arra van hogy megmutassa hogy azt az ékezetes szöveget 
            //amit ezzel kódolunk úgy adja vissza dekódolás után ahogy volt
            string elsostring = exor("Ékezetes szöveg éáűúőpóü", "kulcs");
            string dekodolva = exor(elsostring, "kulcs");
            Console.WriteLine(dekodolva);
            Console.ReadLine();
            */
            



            //minhossz beállítása
            core1prog.minhossz(minhossz);
            core2prog.minhossz(minhossz);
            core3prog.minhossz(minhossz);
            core4prog.minhossz(minhossz);

            //feladat beolvasása
            //UTF7-ben jobb az olvashatóság
            string szoveg = File.ReadAllText(input, Encoding.UTF7);
            //kodoltszoveg változót fogja törni
            kodoltszoveg = szoveg;

            //kiírás fájlba
            //System.IO.File.WriteAllLines(output, szoveg);
			Console.WriteLine("\n");
            //multithread indítása
            core1.Start();
            core2.Start();
            core3.Start();
            core4.Start();

        }

        //exor 
        static string exor(string text, string key)
        {
            char[] output = new char[text.Length];

            for (int i = 0; i < text.Length; i++)
                output[i] = (char)(text[i] ^ key[i % key.Length]);

            return new string(output);
        }

        //dekódolt szöveg tesztelése
        static void teszt(string text, string key)
        {
            //tartalmaz-e megadott szavakat
            if (szavak.Any(text.Contains))
            {
                Console.WriteLine("Megoldás: \n" + text);
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
                    Console.WriteLine("Megoldás: \n" + text);
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
            while (vege == false)
            {
                //2x generál kulcsot hogy páratlan maradjon
                kulcs = core1prog.strconst(maxhossz);
                kulcs = core1prog.strconst(maxhossz);
                //időnkénti kiíratás
				//nem lesz pontos a próbálkozás száma mert közben a többi is növeli a változó értékét
                if (probalkozas > checkpoint + 50000000)
                {
                    Console.WriteLine("Próba: " + probalkozas);
                    Console.WriteLine("Kulcs: " + kulcs);
                    Console.WriteLine(exor(kodoltszoveg, kulcs));
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
            while (vege == false)
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
            while (vege == false)
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
            while (vege == false)
            {
                kulcs = core4prog.strconst(maxhossz);
                kulcs = core4prog.strconst(maxhossz);

                probalkozas++;

                teszt(exor(kodoltszoveg, kulcs), kulcs);
            }
        }
    }
}
