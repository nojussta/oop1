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
        public static FlatRegister ReadFlats(string fileName)
        {
            FlatRegister RegisteredFlats = new FlatRegister();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                int flatNumber = int.Parse(Values[0]);
                int flatSpace = int.Parse(Values[1]);
                int roomsAmount = int.Parse(Values[2]);
                int flatCost = int.Parse(Values[3]);
                string sellersNumber = Values[4];

                Flats flat = new Flats(flatNumber, flatSpace, roomsAmount, flatCost, sellersNumber);
                RegisteredFlats.Add(flat);
            }
            return RegisteredFlats;
        }
        public static void PrintFlats(FlatRegister Flats)
        {
            if (Flats.FlatsCount() > 0)
            {
                Console.WriteLine(new string('-', 81));

                Console.WriteLine("| {0,-12} | {1,-6} | {2,-18} | {3,-7} | {4,-22} |", "Buto numeris", "Plotas", "Kambarių skaičius", "Kaina", "Pardavėjo tel. numeris");
                Console.WriteLine(new string('-', 81));
                for (int i = 0; i < Flats.FlatsCount(); i++)
                {
                    Flats flat = Flats.TakeByIndex(i);
                    Console.WriteLine("| {0, 12} | {1,6} | {2, 18} | {3,7} | {4, 22} |", flat.FlatNumber, flat.FlatSpace, flat.RoomsAmount, flat.FlatCost, flat.SellersNumber);
                }
                Console.WriteLine(new string('-', 81));
            }
            else
            {
                Console.WriteLine("Norimų butų nėra.");
                System.Environment.Exit(0);
            }
        }
    }
}
