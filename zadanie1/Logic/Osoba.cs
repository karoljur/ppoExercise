using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace zadanie1.Logic
{
    abstract class Osoba
    {
        private String _imie;
        private String _nazwisko;
        private DateTime _dataUrodzenia;
        public Plec _Plec { get; set; } = Plec.niezdefiniowana;
        public ArrayList ListaDzieci { get; set; } = new ArrayList();
        public Osoba Malzonek { get; set; }

        protected Osoba()
        {
            Imie = "Jan";
            Nazwisko = "Kowalski";
            DataUrodzenia = "22/10/1994";
            _Plec = Plec.niezdefiniowana;
        }

        protected Osoba(String imie, String nazwisko, String dataUrodzenia, Plec plec)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            DataUrodzenia = dataUrodzenia;
            _Plec = plec;
        }

        public String Imie
        {
            get => _imie;
            set
            {
                Regex regex = new Regex("[^a-z]");
                String val = value.ToLower();
                if (!regex.IsMatch(val))
                {
                    _imie = char.ToUpper(val[0]) + val.Substring(1);
                }
                else
                {
                    throw new ArgumentException("Invalid first name");
                }
            }
        }

        public String Nazwisko
        {
            get => _nazwisko;
            set
            {
                Regex regex = new Regex("[^a-z -]");
                String name = value.ToLower();
                if (!regex.IsMatch(name))
                {
                    String nameSubstring;
                    if (name.Contains("-"))
                    {
                        int dashIndex = name.IndexOf('-');
                        nameSubstring = name.Substring(1, dashIndex) + char.ToUpper(name[dashIndex + 1]) + name.Substring(dashIndex + 2);
                    }
                    else
                    {
                        nameSubstring = name.Substring(1);
                    }
                    _nazwisko = char.ToUpper(name[0]) + nameSubstring;
                }
                else
                {
                    throw new ArgumentException("Invalid last name");
                }
            }
        }

        public string DataUrodzenia
        {
            get => _dataUrodzenia.ToString("dd/MM/yyyy");
            set
            {
                DateTime val;
                bool isDateTime = DateTime.TryParse(value, out val);
                if (isDateTime && val.Date < DateTime.Today)
                {
                    _dataUrodzenia = val;
                }
                else
                {
                    throw new ArgumentException($"Invalid date of birth {value}");
                }
            }
        }

        public bool UstawMalzonka(Osoba malzonek)
        {
            if (_Plec != malzonek._Plec)
            {
                Malzonek = malzonek;
                return true;
            }
            else return false;
        }

        public void DodajDziecko(Osoba dziecko) => ListaDzieci.Add(dziecko);

        public void WypiszDzieci()
        {
            foreach (Osoba dziecko in ListaDzieci)
            {

                Console.WriteLine($"{ZwrocNazweDziecka(dziecko)} {dziecko.ZwrocImieINazwisko()}");
            }
        }

        public String ZwrocNazweDziecka(Osoba dziecko)
        {
            switch (dziecko._Plec)
            {
                case Plec.kobieta:
                    return "córka";
                case Plec.mężczyzna:
                    return "syn";
                default:
                    return "dziecko";
            }
        }

        public String ZwrocNazwePartnera()
        {
            if (Malzonek == null)
                return "";
            String partner;
            if (_Plec == Plec.mężczyzna)
            {
                partner = ", żona";
            }
            else
            {
                partner = ", partner";
            }
            return $"{partner} {Malzonek.ZwrocImieINazwisko()}";
        }

        public String ZwrocImieINazwisko() => $"{Imie} {Nazwisko}";

        virtual public void WypiszDrzewoGenealogiczne()
        {
            Console.WriteLine($"{ZwrocImieINazwisko()}{ZwrocNazwePartnera()}");
            WypiszDzieci();
            foreach (Osoba dziecko in ListaDzieci)
            {
                Console.WriteLine("");
                dziecko.WypiszDrzewoGenealogiczne();
            }
        }
    }
}
