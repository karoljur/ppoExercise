using System;
using System.IO;
using zadanie1.Logic;

namespace zadanie1
{
    class Program
    {
        static void Main(string[] args)
        {
            OsobaZyjaca StworzOsobeIZwroc()
            {
                var osoba = new OsobaZyjaca("artur", "artur-dartur", "22/11/1994", Plec.mężczyzna, "123456789");
                osoba.DodajDziecko(new OsobaZyjaca("kasia", "artur-dartur", "11/11/2016", Plec.kobieta, "543216789"));
                osoba.UstawMalzonka(new OsobaZyjaca("asia", "artur-dartur", "13/09/1995", Plec.kobieta, "654321789"));
                return osoba;
            }

            void ZrobMiejsce()
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("");
                }
            }

            try
            {
                var osoba = StworzOsobeIZwroc();
                osoba.WypiszDrzewoGenealogiczne();
                var docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var fullPath = Path.Combine(docPath, "MojPlik.txt");
                DataManager.WriteToJsonFile(fullPath, osoba);
                ZrobMiejsce();
                OsobaZyjaca wczytanaOsoba = DataManager.ReadFromJsonFile<OsobaZyjaca>(fullPath);
                wczytanaOsoba.WypiszDrzewoGenealogiczne();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Wystąpił błąd: {e.ToString()}");
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}

