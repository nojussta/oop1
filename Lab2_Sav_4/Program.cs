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
            FlatRegister allFlats = InOutUtils.ReadFlats("Flats.csv");
            InOutUtils.PrintFlats(allFlats);

            Console.WriteLine("Pasirinkite kambarių kiekį:");
            int chosenNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Nurodykite buto aukštų intervalą(nuo - iki) kuriame ieškote buto");
            Console.WriteLine("Nuo:");
            int from = int.Parse(Console.ReadLine());
            Console.WriteLine("Iki:");
            int to = int.Parse(Console.ReadLine());
            Console.WriteLine("Įrašykite sumą, kurią galite mokėti už butą:");
            int cost = int.Parse(Console.ReadLine());

            int[] ChosenFlat = new int[4] { chosenNumber, from, to, cost };
            FlatRegister SuggestedFlat = allFlats.FilterFlats(ChosenFlat);
            InOutUtils.PrintFlats(SuggestedFlat);
        }
    }
}
