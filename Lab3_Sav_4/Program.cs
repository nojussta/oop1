using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sav_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "Studentai.txt";
            string fileNameResult = "Pradiniai duomenys.txt";

            StudentContainer students = InOutUtils.ReadStudents(fileName);
            InOutUtils.PrintStudents(fileNameResult, students);

            List<string> SortLetters = students.FindGroups();

            GroupContainer groups = GroupContainer.GetGroups(SortLetters, students);

            groups.Sort();

            InOutUtils.PrintData(students, "Pradiniai duomenys:");
            InOutUtils.PrintGroupData(groups, "Sudarytos grupės:");
        }
    }
}
