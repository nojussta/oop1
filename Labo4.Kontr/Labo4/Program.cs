using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Labo4
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CFd1 = "Knyga1.txt";
            const string CFd2 = "Knyga2.txt";
            //TEST1: Words in both files are the same - no different words, copying the text of file 1 until an equal word is found in file 2 and vice versa

            const string CFd3 = "Knyga1_1.txt";
            const string CFd4 = "Knyga2_1.txt";
            //TEST2: Test of finding some different words in file 1

            const string CFd5 = "Knyga1_2.txt";
            const string CFd6 = "Knyga2_2.txt";
            //TEST3: Inputing numbers in a pattern which should be put in a logic order after the copy of files method is used

            const string CFd7 = "Knyga1_3.txt";
            const string CFd8 = "Knyga2_3.txt";
            //TEST4: File 1 is full, file 2 is empty, finding many different words inf file 1, easily checking if sort method works

            const string CFr1 = "Rodikliai.txt";
            const string CFr2 = "ManoKnyga.txt";

            char[] punctuation = { '"', '“', '„', ' ', '.', ',', '!', '?', ';', ':', '(', ')', '\n', '\t' };
            char[] endOfSentence = { '.', '!', '?', ';', ':' };
            string punctuations = "[\\ \n.;,()\r─\t:!?\\-]+";

            if (File.Exists(CFr1)) File.Delete(CFr1);
            if (File.Exists(CFr2)) File.Delete(CFr2);

            List<string> Words1 = TaskUtils.GroupingWords(CFd7, punctuation);
            List<string> Words2 = TaskUtils.GroupingWords(CFd8, punctuation);

            List<string> Separated = TaskUtils.SeparateWords(Words1, Words2);
            List<int> Repeated = TaskUtils.Repetition(Separated, CFd7, punctuation);

            TaskUtils.Sort(Separated, Repeated);
            InOut.PrintWords(CFd7, CFd8, CFr1, Separated, Repeated);

            KeyValuePair<string, int> StartOfSentence = TaskUtils.Process(CFd7, punctuation, endOfSentence);
            InOut.PrintSentence(CFr1, StartOfSentence, CFd7, punctuation);
            StartOfSentence = TaskUtils.Process(CFd8, punctuation, endOfSentence);
            InOut.PrintSentence(CFr1, StartOfSentence, CFd8, punctuation);

            using (var writer = File.CreateText(CFr2)) TaskUtils.Combine(CFd7, CFd8, writer, punctuations);
        }
    }
}
