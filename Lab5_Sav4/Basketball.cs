using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Exercises.Sav4
{
    public class Basketball : Player
    {
        public int Rebounds { get; set; }
        public int Assists { get; set; }

        public Basketball(string teamName, string name, string surname, DateTime birthDate, int gamesPlayed, int pointsScored, int rebounds, int assists) : base(teamName, name, surname, birthDate, gamesPlayed, pointsScored)
        {
            Rebounds = rebounds;
            Assists = assists;
        }

        public override string ToString()
        {
            return string.Format("{0}{1, 15}|{2, 15}|{3, 17}|", base.ToString(), Rebounds, Assists, "-");
        }
    }
}
