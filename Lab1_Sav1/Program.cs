using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Sav1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<People> allPeople = InOutUtils.ReadPeople(@"People.csv");
            List<People> p = new List<People>();
            InOutUtils.PrintResults(allPeople, TaskUtils.CountMoney(allPeople, ref p), p);
        }
    }
}
