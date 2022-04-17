using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Sav1
{
    static class TaskUtils
    {

        public static double CountMoney(List<People> Peoples, ref List<People> p)
        {
            double Sum = 0;
            double max = 0; 
            foreach (People people in Peoples)
            {
                
                double Residue = people.Money % 4;
                double MoneyLeft = people.Money - Residue;
                double Quarter = MoneyLeft / 4;
                 Sum += Quarter;
                if (max <= Quarter)
                {
                    max = Quarter;
                    p.Add(people);
                }
            }
            return Sum;
        }
    }
}
