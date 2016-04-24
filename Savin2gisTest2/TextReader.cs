using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Savin2gisTest2
{
    public class TextReader
    {

        string[] StringForStart { get; set; }

        public Point PointForFind { get; private set; }
        public Dictionary<string, double> Pharmacies = new Dictionary<string, double>();
        public TextReader(string stringForStart)
        {

            try
            {
                StringForStart = stringForStart.Split(' ');
                if (3 != StringForStart.Length)
                {
                    throw new InvalidDataException();
                }
                PointForFind =
                    new Point(Convert.ToDouble(StringForStart[1].Replace(".", ",")),
                        Convert.ToDouble(StringForStart[2].Replace(".", ",")));
                var lines = File.ReadAllLines(@StringForStart[0]);
                foreach (var line in lines)
                {
                    if (line == lines[0]) continue;
                    var parseLine = line.Split('|');
                    var point = new Point(Convert.ToDouble(parseLine[2].Replace(".", ",")),
                        Convert.ToDouble(parseLine[3].Replace(".", ",")));
                    var discance = CalculatDistance(point, PointForFind);
                    var sb = new StringBuilder();
                    sb.Append(parseLine[0]);
                    sb.Append("|");
                    sb.Append(parseLine[1]);

                    Pharmacies.Add(sb.ToString(), discance);
                }

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Некорректный путь до файла");
                Program.ParseFile();
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Некорректный путь до файла");
                Program.ParseFile();
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверное значение широты или долготы");
                Program.ParseFile();
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Неверный ввод данных");
                Program.ParseFile();
            }
            catch (InvalidDataException)
            {
                Console.WriteLine("Неверный ввод данных");
                Program.ParseFile();
            }
            
        }

        private static double CalculatDistance(Point point, Point findPoint)
        {
            const double power = 2;
            return Math.Sqrt(Math.Pow((point.Longitude - findPoint.Longitude), power) + Math.Pow((point.Latitude - findPoint.Latitude), power));
        }
    }
}
