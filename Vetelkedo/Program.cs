using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Vetelkedo {
    internal class Program {
        public static void Main(string[] args)
        {
            // Zsűrik beállítása, lista létrehozása
            Versenyzo.ZsurikSzama = 4;
            List<Versenyzo> versenyzok = new List<Versenyzo>();

            // Fájl beolvasása
            using (StreamReader sr = new StreamReader("versenyzok.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string nev = sr.ReadLine();
                    string szak = sr.ReadLine();
                    versenyzok.Add(new Versenyzo(nev, szak));
                }
            }

            // Kezdő adatok kiírása és pontozás
            foreach (Versenyzo versenyzo in versenyzok)
            {
                Console.WriteLine(versenyzo);
                versenyzo.PontotKap();
            }

            // Rendezés
            versenyzok = versenyzok.OrderByDescending(x => x.Pontszam).ToList();

            //// Eredmények
            WriteLineColored("\n\nEredmények:", ConsoleColor.DarkCyan);
            Console.WriteLine("Nyertes(ek):");
            // Nyertesek kiválasztása
            int max = versenyzok.Max(x => x.Pontszam);
            List<Versenyzo> nyertesek = versenyzok.Where(x => x.Pontszam == max).ToList();
            foreach (Versenyzo versenyzo in nyertesek)
            {
                Console.WriteLine(versenyzo);
            }

            Console.WriteLine("\nÖsszes eredmény");
            foreach (Versenyzo versenyzo in versenyzok)
            {
                Console.WriteLine(versenyzo);
            }

            // Eredmények keresése szakma alapján
            do
            {
                WriteLineColored("Keresés menü: ", ConsoleColor.DarkCyan);
                Console.WriteLine("1. Szakma alapján");
                Console.WriteLine("2. Rajtszám alapján");
                Console.WriteLine("3. Név alapján");
                Console.WriteLine("4. Kilépés");
                int kereses;
                while (!int.TryParse(Console.ReadLine(), out kereses))
                {
                    WriteLineColored("A válasz csak számot tartalmazhat", ConsoleColor.Red);
                }

                bool quit = false;
                bool talalt = false;
                List<Versenyzo> talalatok = new List<Versenyzo>();

                switch (kereses)
                {
                    // Szakma alapján
                    case 1:
                        Console.WriteLine("Adja meg egy szakma nevét");
                        string szakmaNeve = Console.ReadLine().Trim().ToLower();

                        foreach (Versenyzo versenyzo in versenyzok)
                        {
                            if (versenyzo.Szak.Trim().ToLower() == szakmaNeve)
                            {
                                talalt = true;
                                talalatok.Add(versenyzo);
                            }
                        }
                        break;
                    // Rajtszám alapján
                    case 2:
                        Console.WriteLine("Adja meg a versenyző rajtszámát");
                        int rajtszam;
                        while(!int.TryParse(Console.ReadLine(), out rajtszam))
                            WriteLineColored("Hibás adat, csak számokat tartalmazhat\nPróbálja újra", ConsoleColor.Red);

                        talalatok = versenyzok.Where(x => x.Rajtszam == rajtszam).ToList();
                        talalt = talalatok.Count > 0;
                        break;
                    // Név alapján
                    case 3:
                        Console.WriteLine("Adja meg a versenyző nevét");
                        string nev = Console.ReadLine().Trim().ToLower();

                        talalatok = versenyzok.Where(x => x.Nev.ToLower() == nev).ToList();
                        talalt = talalatok.Count > 0;
                        break;
                    // Kilépés
                    case 4:
                        quit = true;
                        break;
                    default:
                        WriteLineColored("Nincs ilyen számú opció", ConsoleColor.Red);
                        Console.WriteLine("Szeretné újrapróbálni? ([I]gen, [N]em)");
                        continue;
                }

                // Kilépés kezelése
                if (quit)
                    break;

                if(!talalt)
                    WriteLineColored("Nincs találat", ConsoleColor.Red);
                else
                {
                    WriteLineColored("Keresési eredmények: ", ConsoleColor.DarkCyan);
                    foreach (Versenyzo talalat in talalatok)
                    {
                        Console.WriteLine(talalat);
                    }
                }

                Console.WriteLine("Szeretne újból keresni? ([I]gen, [N]em)");
            } while (Console.ReadLine().ToLower()[0] == 'i');
        }

        #region Helpers

        static void WriteLineColored(string msg, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        #endregion
    }
}