using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Exercises.Sav4
{
    public abstract class Player
    {
        public string TeamName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public int GameCount { get; set; }
        public int TotalPoints { get; set; }

        public Player(string teamName, string name, string surname, DateTime birthDate, int gameCount, int totalPoints)
        {
            TeamName = teamName;
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
            GameCount = gameCount;
            TotalPoints = totalPoints;
        }

        public override string ToString()
        {
            return string.Format("|{0, -15}|{1, -15}|{2, -15}|{3, -15}|{4, 15}|{5, 15}|", TeamName, Name, Surname, BirthDate.ToString("dd-MM-yyyy"), GameCount, TotalPoints);
        }
    }
}
