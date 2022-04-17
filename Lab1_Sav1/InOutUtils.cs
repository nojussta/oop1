using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab1_Sav1
{
    class InOutUtils
    {
        public static List<People> ReadPeople(string fileName)
        {
            List<People> Peoples = new List<People>();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (var line in Lines)
            {
                string[] Values = line.Split(';');

                string name = Values[0];
                string surname = Values[1];
                double money = double.Parse(Values[2]);

                People people = new People(name, surname, money);
                Peoples.Add(people);
            }
            return Peoples;
        }
        public static void PrintPeople(List<People> Peoples)
        {
            foreach (var people in Peoples)
            {
                Console.WriteLine($"Vardas: { people.Name } | Pavardė: { people.Surname } | Turi pinigų: { people.Money }");
            }
        }

        public static void PrintResults(List<People> Peoples, double Sum, List<People> Spentage)
        {
            PrintPeople(Peoples);
            Console.WriteLine();
            Console.WriteLine($"Iš viso skirta: { Sum }");
            Console.WriteLine("Daugiausiai skyrė: ");
            Console.WriteLine();
            foreach (var people in Spentage)
            {
                Console.WriteLine($"{ people.Name }{ people.Surname }");
            }
        }
    }
}
