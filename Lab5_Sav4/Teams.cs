using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Exercises.Sav4
{
    class Teams
    {
        public string TeamName { get; set; }
        public string City { get; set; }
        public string Coach { get; set; }
        public int GameCount { get; set; }
        public List<Player> Players { get; set; }

        public Teams(string teamName, string city, string coach, int gameCount, List<Player> players)
        {
            TeamName = teamName;
            City = city;
            Coach = coach;
            GameCount = gameCount;
            Players = players;
        }

        public int GetTotalPointsScored()
        {
            int total = 0;
            foreach (Player player in Players)
            {
                total += player.TotalPoints;
            }
            return total;
        }

        public float GetAveragePointsScored()
        {
            return (float)GetTotalPointsScored() / Players.Count;
        }
    }
}
