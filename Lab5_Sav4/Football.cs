using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Exercises.Sav4
{
    public class Football : Player
    {
        public int YellowCards { get; set; }
        public Football(string teamName, string name, string surname, DateTime birthDate, int gameCount, int totalPoints, int yellowCards) : base(teamName, name, surname, birthDate, gameCount, totalPoints)
        {
            YellowCards = yellowCards;
        }

        public override string ToString()
        {
            return string.Format("{0}{1, 15}|{2, 15}|{3, 17}|", base.ToString(), "-", "-", YellowCards);
        }
    }
}
