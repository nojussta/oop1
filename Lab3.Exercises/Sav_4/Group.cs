using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sav_4
{
    class Group
    {
        public string SortLetters { get; set; }
        public double GroupAverage { get; set; }
        public Group(string sortLetters, double groupAverage)
        {
            this.SortLetters = sortLetters;
            this.GroupAverage = groupAverage;
        }
        public Group(string sortLetters)
        {
            this.SortLetters = sortLetters;
            this.GroupAverage = 0;
        }
        public int CompareTo(Group group)
        {
            if (this.GroupAverage.CompareTo(group.GroupAverage) < 0)
            {
                return -1;
            }
            else if (this.GroupAverage.CompareTo(group.GroupAverage) == 0 && this.SortLetters.CompareTo(group.SortLetters) > 0)
            {
                return -1;
            }
            return 1;
        }
        public override string ToString()
        {
            return string.Format("| {0, -6} | {1, 8} |", SortLetters, GroupAverage);
        }
    }
}
