using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace consolePlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            var totalNamescore = 0;

            StreamReader reader = File.OpenText(@"C:\Users\holweje\Source\Repos\mvcPlayground\consolePlayground\bin\Debug\names.txt");
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                string[] items = line.Split(',');
                var list = items.OrderBy(x => x).ToList();
                var position = 1;

                foreach (string item in list)
                {
                    var namescore = 0;
                    foreach (var character in item)
                    {
                        namescore += GetScoreForChar(character);
                    }
                    namescore *= position;
                    totalNamescore += namescore;
                    position++;
                }
            }

            Console.WriteLine(totalNamescore);
            Console.ReadLine();
        }

        private static int GetScoreForChar(char character)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            return alphabet.IndexOf(character) + 1;
        }
    }
}
