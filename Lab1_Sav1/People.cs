using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Sav1
{
    class People
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public double Money { get; set; }

        public People (string name, string surname, double money)
        {
            this.Name = name;
            this.Surname = surname;
            this.Money = money;
        }
    }
}
