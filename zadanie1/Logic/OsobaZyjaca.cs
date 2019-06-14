using System;

namespace zadanie1.Logic
{
    class OsobaZyjaca : Osoba
    {
        public String Telefon { get; set; }

        public OsobaZyjaca() : base()
        {
            Telefon = "";
        }

        public OsobaZyjaca(String imie, String nazwisko, String dataUrodzenia, Plec plec) : base(imie, nazwisko, dataUrodzenia, plec)
        {
            Telefon = "";
        }

        public OsobaZyjaca(String imie, String nazwisko, String dataUrodzenia, Plec plec, String nrTelefonu) : base(imie, nazwisko, dataUrodzenia, plec)
        {
            Telefon = nrTelefonu;
        }

        public override void WypiszDrzewoGenealogiczne()
        {
            Console.WriteLine($"{ZwrocImieINazwisko()}{ZwrocTelefon()}{ZwrocNazwePartnera()}");
            WypiszDzieci();
            foreach (Osoba dziecko in ListaDzieci)
            {
                Console.WriteLine("");
                dziecko.WypiszDrzewoGenealogiczne();
            }
        }

        protected String ZwrocTelefon()
        {
            if (Telefon == null || Telefon.Length == 0)
            {
                return "";
            }
            else
            {
                return $", telefon {Telefon}";
            }
        }
    }
}

