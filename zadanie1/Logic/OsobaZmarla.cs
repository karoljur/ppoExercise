using System;

namespace zadanie1.Logic
{
    class OsobaZmarla : Osoba
    {
        private DateTime _dataSmierci;

        public String DataSmierci
        {
            get => _dataSmierci.ToString("dd/mm/yyyy");
            set
            {
                DateTime val;
                bool isDateTime = DateTime.TryParse(value, out val);
                if (isDateTime && val.Date < DateTime.Today)
                    _dataSmierci = val;
            }
        }

        public override void WypiszDrzewoGenealogiczne()
        {
            Console.WriteLine($"{ZwrocImieINazwisko()} zmarł {DataSmierci}, {ZwrocNazwePartnera()}");
            WypiszDzieci();
            foreach (Osoba dziecko in ListaDzieci)
            {
                Console.WriteLine("");
                dziecko.WypiszDrzewoGenealogiczne();
            }
        }
    }
}