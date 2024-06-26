using System;

namespace Vetelkedo {
    public class Versenyzo {
        public static int ZsurikSzama = 0;
        private static int VersenyzokSzama = 0;
        private static Random r = new Random();

        private string nev;
        private string szak;
        private int rajtszam;
        private int pontszam = 0;

        public string Nev => nev;
        public string Szak => szak;
        public int Rajtszam => rajtszam;
        public int Pontszam => pontszam;

        public Versenyzo(string nev, string szak)
        {
            VersenyzokSzama++;
            this.nev = nev;
            this.szak = szak;
            rajtszam = VersenyzokSzama;
        }

        public void PontotKap()
        {
            for (int i = 0; i < ZsurikSzama; i++)
            {
                pontszam += r.Next(10);
            }
        }

        public override string ToString()
        {
            return $"{rajtszam}, név: {nev}, szak: {szak}, pontszám: {pontszam}";
        }
    }
}