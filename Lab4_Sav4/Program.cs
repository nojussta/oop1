using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Exercises.Sav._4.V2
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CFd = "Duomenys.txt";
            const string CFr = "Rezultatai.txt";
            string[] Lines = InOut.ReadText(CFd);
            Console.WriteLine("Įveskite žodį, kurį norite pašalinti: ");
            string[] ToRemove = { Console.ReadLine() };
            TaskUtils.RemoveWords(Lines, ToRemove);
            InOut.PrintData(CFr, Lines);
        }
    }
}

