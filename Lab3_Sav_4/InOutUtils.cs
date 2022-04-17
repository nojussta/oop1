using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sav_4
{
    class InOutUtils
    {
        public static StudentContainer ReadStudents(string fileName)
        {
            StudentContainer students = new StudentContainer();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                string surName = Values[0];
                string name = Values[1];
                string group = Values[2];
                int marksCounter = int.Parse(Values[3]);
                int[] marks = new int[marksCounter];
                for (int i = 0; i < marks.Length; i++)
                {
                    marks[i] = int.Parse(Values[i + 4]);
                }
                Student student = new Student(surName, name, group, marksCounter, marks);
                students.Add(student);
            }
            return students;
        }
        public static void PrintStudents(string fileName, StudentContainer students)
        {
            string[] Lines = new string[students.Count];
            for (int i = 0; i < students.Count; i++)
            {
                Student student = students.Get(i);
                string marks = "";
                for (int j = 0; j < student.MarksCounter; j++)
                {
                    marks += student.Marks[j];
                    if (j != student.MarksCounter - 1) marks += " ";
                }
                Lines[i] = String.Format("{0};{1};{2};{3};{4}", student.SurName, student.Name, student.Group, student.MarksCounter, marks);
            }
            File.WriteAllLines(fileName, Lines, Encoding.UTF8);
        }
        public static void PrintData(StudentContainer students, string label)
        {
            Console.WriteLine(label);
            Console.WriteLine(new string('-', 100));
            Console.WriteLine("| {0, -20} | {1, -20} | {2, -10} | {3, 14} | {4, 20} |", "Pavardė", "Vardas", "Grupė", "Pažymių kiekis", "Pažymiai");
            Console.WriteLine(new string('-', 100));
            for (int i = 0; i < students.Count; i++)
            {
                Student student = students.Get(i);
                string marks = "";
                for (int j = 0; j < student.MarksCounter; j++)
                {
                    marks += student.Marks[j] + " ";
                }
                Console.WriteLine("| {0, -20} | {1, -20} | {2, -10} | {3, 14} | {4, 20} |", student.SurName, student.Name, student.Group, student.MarksCounter, marks);
            }
            Console.WriteLine(new string('-', 100));
        }
        public static void PrintGroupData(GroupContainer groups, string label)
        {
            Console.WriteLine(label);
            Console.WriteLine(new string('-', 21));
            Console.WriteLine("| {0, -6} | {1, 8} |", "Grupė", "Vidurkis");
            Console.WriteLine(new string('-', 21));
            for (int i = 0; i < groups.Count; i++)
            {
                Console.WriteLine(groups.Get(i).ToString());
            }
            Console.WriteLine(new string('-', 21));
        }
    }
}
