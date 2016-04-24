using System;

namespace Savin2gisTest2
{
    class Program
    {
        private static string StartString { get; set; }
        static void Main()
        {
           ParseFile();
           Console.ReadLine();
        }

        public static void ParseFile()
        {
            StartString = Console.ReadLine();
            var textReader = new TextReader(StartString);
            textReader.ParseFile();
            var searchPharmacies = new SearchPharmacies(textReader);
            var phrmacies = searchPharmacies.Find3Pharmacies();
            Console.WriteLine(phrmacies);
        }
    }
}
