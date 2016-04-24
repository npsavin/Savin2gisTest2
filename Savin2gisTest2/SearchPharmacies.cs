using System;
using System.Linq;
using System.Text;

namespace Savin2gisTest2
{
    public class SearchPharmacies
    {
        TextReader TextReader { get; set; }
        public SearchPharmacies(TextReader textReader)
        {
            TextReader = textReader;
        }

        public string Find3Pharmacies()
        {
            const double different = 0.000000001;
            var sbForRetrun = new StringBuilder();
            for (var i = 0; i <= 2; i++)
            {
                try
                {
                    var first = TextReader.Pharmacies.First(x => Math.Abs(x.Value - TextReader.Pharmacies.Values.Min()) < different);
                    sbForRetrun.AppendLine(first.Key);
                    TextReader.Pharmacies.Remove(first.Key);
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Аптек меньше трёх");
                    Program.ParseFile();
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Файл не соответсвует формату");
                    Program.ParseFile();
                }
                
            }

            return sbForRetrun.ToString();
        }
        

    }
}
