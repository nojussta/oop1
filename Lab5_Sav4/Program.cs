using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Exercises.Sav4
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CFd1 = "Players.csv";
            const string CFd2 = "Teams.csv";
            const string label = "Pradiniai duomenys";
            List<Teams> teams = InOut.ReadTeams(CFd2, CFd1);
            TeamsRegister register = new TeamsRegister(teams);
            List<Player> read = InOut.ReadPlayers(CFd1);

            InOut.Print(read, label);
            Console.WriteLine("\nKomandų skaičius: {0}\n", register.Count());
            register.CityList();

            Console.WriteLine("\nPasirinkite norimo miesto komdanas: ");
            string chosenCity = Console.ReadLine();
            List<Player> foundPlayers = register.FilterByCity(chosenCity).FindPlayerActiveAndWithHighPoints();

            InOut.PrintPlayers(foundPlayers);
        }
    }
}
