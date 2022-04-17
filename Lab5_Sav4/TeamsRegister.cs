using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Exercises.Sav4
{
    class TeamsRegister
    {
        private List<Teams> allTeams;

        public TeamsRegister()
        {
            allTeams = new List<Teams>();
        }

        public TeamsRegister(List<Teams> initialTeams)
        {
            allTeams = new List<Teams>();
            foreach (Teams team in initialTeams)
            {
                Add(team);
            }
        }

        public void Add(Teams team)
        {
            allTeams.Add(team);
        }

        public Teams Get(int index)
        {
            return allTeams[index];
        }

        public int Count()
        {
            return allTeams.Count;
        }

        public TeamsRegister FilterByCity(string city)
        {
            List<Teams> filtered = new List<Teams>();
            foreach (Teams team in allTeams)
            {
                if (team.City == city)
                {
                    filtered.Add(team);
                }
            }
            return new TeamsRegister(filtered);
        }

        public List<Player> FindPlayerActiveAndWithHighPoints()
        {
            List<Player> players = new List<Player>();
            foreach (Teams team in allTeams)
            {
                float averagePoints = team.GetAveragePointsScored();
                Console.WriteLine("Vidurkis: {0}",Math.Round(averagePoints, 3));
                foreach (Player player in team.Players)
                {
                    if (team.GameCount <= player.GameCount && player.TotalPoints > averagePoints)
                    {
                        players.Add(player);
                    }
                }
            }
            return players;
        }
        public TeamsRegister CityList()
        {
            string dashes = new string('-', 20);
            Console.WriteLine(dashes);
            Console.WriteLine("| {0, -16} |", "Miestų sąrašas");
            Console.WriteLine(dashes);
            foreach (Teams teams in allTeams)
            {
                Console.WriteLine("| {0, -16} |", teams.City);
            }
            Console.WriteLine(dashes);
            return null;
        }
    }
}
