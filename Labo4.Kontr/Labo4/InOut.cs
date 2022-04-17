using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo4
{
    class InOut
    {
        /// <summary>
        /// Prints all words that are only in 1 file + prints how many times that word is used to file (maximum of 10 words)
        /// </summary>
        /// <param name="CFd"></param>
        /// <param name="CFd2"></param>
        /// <param name="CFr"></param>
        /// <param name="separated"></param>
        /// <param name="repeated"></param>
        public static void PrintWords(string CFd, string CFd2, string CFr, List<string> separated, List<int> repeated)
        {
            string dashes = new string('-', 39);
            using (var writer = File.AppendText(CFr))
            {
                if (separated.Count == 0 && repeated.Count == 0)
                {
                    writer.WriteLine("Žodžiai abiejuose failuose vienodi!");
                    writer.WriteLine();
                }
                else
                {
                    writer.WriteLine($"Žodžiai kurie yra tik faile: { CFd }, bet nėra faile { CFd2 } (max 10 žodžių):");
                    writer.WriteLine(dashes);
                    writer.WriteLine("|{0, -14}|{1, -22}|", "Unikalus žodis", "Pasikartojimų skaičius");
                    writer.WriteLine(dashes);
                    for (int i = 0; i < separated.Count; i++)
                    {
                        writer.WriteLine("|{0, -14}|{1, 22}|", separated[i], repeated[i]);
                    }
                    writer.WriteLine(dashes);
                    writer.WriteLine();
                }
            }
        }
        /// <summary>
        /// Prints the sentence and all the required information about that sentence
        /// </summary>
        /// <param name="CFr"></param>
        /// <param name="StartOfSentence"></param>
        /// <param name="CFd"></param>
        /// <param name="punctuation"></param>
        public static void PrintSentence(string CFr, KeyValuePair<string, int> StartOfSentence, string CFd, char[] punctuation)
        {
            string dashes = new string('-', 66);
            using (var writer = File.AppendText(CFr))
            {
                writer.WriteLine("Ilgiausias sakinys faile {0}:", CFd);
                writer.WriteLine(dashes);
                writer.WriteLine("|{0, -35}|{1, -14}|{2, -13}|", "Ilgiausio sakinio kiekis simboliais", "Ilgis žodžiais", "Eilutės vieta");
                writer.WriteLine(dashes);
                writer.WriteLine("|{0, 35}|{1, 14}|{2, 13}|", StartOfSentence.Key.Length, TaskUtils.WordCount(StartOfSentence.Key, punctuation), StartOfSentence.Value + 1);
                writer.WriteLine(dashes);
                writer.WriteLine();
            }
        }
    }
}
