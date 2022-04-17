using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Exercises.Sav._4.V2
{
    class InOut
    {
        public static string[] ReadText(string fileName)
        {
            return File.ReadAllLines(fileName);
        }
        public static void PrintData(string CFr, string[] Lines)
        {
            File.WriteAllLines(CFr, Lines);
        }
    }
}
