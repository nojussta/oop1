using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Exercises.Sav4
{
    class InOut
    {
        public static IEnumerable<string> ReadByLines(string filename)
        {
            using (StreamReader reader = new StreamReader(filename, Encoding.UTF8))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }

        public static List<Player> ReadPlayers(string filename)
        {
            List<Player> players = new List<Player>();
            foreach (string line in ReadByLines(filename))
            {
                string[] parts = line.Split(';');
                string teamName = parts[0];
                string name = parts[1];
                string surname = parts[2];
                DateTime birthDate = DateTime.Parse(parts[3]);
                int gamesCount = int.Parse(parts[4]);
                int totalPoints = int.Parse(parts[5]);
                
                if (parts.Length == 8)
                {
                    int rebounds = int.Parse(parts[6]);
                    int assists = int.Parse(parts[7]);
                    Player player = new Basketball(teamName, name, surname, birthDate, gamesCount, totalPoints, rebounds, assists);
                    players.Add(player);
                }
                else
                {
                    int yellowCards = int.Parse(parts[6]);
                    Player player = new Football(teamName, name, surname, birthDate, gamesCount, totalPoints, yellowCards);
                    players.Add(player);
                }
            }
            return players;
        }

        public static List<Teams> ReadTeams(string teamsFilename, string playersFilename)
        {
            List<Player> allPlayers = ReadPlayers(playersFilename);
            List<Teams> teams = new List<Teams>();
            foreach (string line in ReadByLines(teamsFilename))
            {
                string[] parts = line.Split(';');
                string name = parts[0];
                string city = parts[1];
                string coach = parts[2];
                int gamesPlayed = int.Parse(parts[3]);
                List<Player> players = FindPlayersByTeam(allPlayers, name);
                Teams team = new Teams(name, city, coach, gamesPlayed, players);
                teams.Add(team);
            }
            return teams;
        }

        private static List<Player> FindPlayersByTeam(List<Player> players, string team)
        {
            List<Player> filtered = new List<Player>();
            foreach (Player player in players)
            {
                if (player.TeamName == team)
                {
                    filtered.Add(player);
                }
            }
            return filtered;
        }

        public static void Print(List<Player> players, string label)
        {
            string dashes = new string('-', 147);
            Console.WriteLine(dashes);
            Console.WriteLine("| {0,-143} |", label);
            Console.WriteLine(dashes);
            Console.WriteLine("|{0, -15}|{1, -15}|{2, -15}|{3, -15}|{4, 15}|{5, 15}|{6, 15}|{7, 15}|{8, 15}|", "Komanda", "Vardas", "Pavardė", "Gimimo data", "Žaidimų sk.", "Taškai", "Atkovoti k.", "Perduoti k.", "Geltonos kortelės");
            Console.WriteLine(dashes);
            foreach (Player player in players)
            {
                Console.WriteLine(player.ToString());
            }
            Console.WriteLine(dashes);
        }

        public static void PrintPlayers(List<Player> players)
        {
            Console.WriteLine(new string('-', 93));
            Console.WriteLine("| {0,-15} | {1,-12} | {2,-12} | {3} | {4} | {5, 13} |", "Komanda", "Vardas", "Pavardė", "Gimimo data", "Žaidimų sk.", "Taškai");
            Console.WriteLine(new string('-', 93));
            foreach (Player player in players)
            {
                Console.WriteLine("| {0,-15} | {1,-12} | {2,-12} | {3:yyyy-MM-dd}  |{4,12} | {5,13} |", player.TeamName, player.Name, player.Surname, player.BirthDate, player.GameCount, player.TotalPoints);
            }
            Console.WriteLine(new string('-', 93));
        }
    }
}
