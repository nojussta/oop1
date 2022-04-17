using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Exercises.Sav._4.V2
{
    class TaskUtils
    {
        public static void RemoveWord(string[] Lines, string ToRemove)
        {
            string pattern = @"\b" + ToRemove + @"\b([\s.,;:<>?!]+)?";
            Regex rgx = new Regex(pattern);
            for (int i = 0; i < Lines.Length; i++)
            {
                Lines[i] = rgx.Replace(Lines[i], "");
            }
        }
        public static void RemoveWords(string[] Lines, string[] ToRemove)
        {
            foreach (string word in ToRemove)
            {
                RemoveWord(Lines, word);
            }
        }
    }
}
