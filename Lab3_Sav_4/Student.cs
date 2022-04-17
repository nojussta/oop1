using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sav_4
{
    class Student
    {
        public string SurName { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public int MarksCounter { get; set; }
        public int[] Marks { get; set; }
        public Student(string surName, string name, string group, int marksCounter, int[] marks)
        {
            this.SurName = surName;
            this.Name = name;
            this.Group = group;
            this.MarksCounter = marksCounter;
            this.Marks = marks;
        }
        public override bool Equals(object other)
        {
            return this.Group == ((Student)other).Group;
        }
        public override int GetHashCode()
        {
            return this.Group.GetHashCode();
        }
        public override string ToString()
        {
            return string.Format("| {0, -20} | {1, -20} | {2, -10} | {3, 14} | {4, 20} |", SurName, Name,Group, MarksCounter, Marks);
        }
    }
}
