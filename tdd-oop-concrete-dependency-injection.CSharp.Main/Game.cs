using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_concrete_dependency_injection.CSharp.Main
{
    public class Game 
    {
        public string name;
        private static List<Game> preInstalledGames = new List<Game>();
        public static List<Game> InstalledGames { get { return preInstalledGames; } }

        public Game(string name) {
           this.name = name;
            preInstalledGames.Add(this);
        }

        public String start() {
            return "Playing " + this.name;
        }

        public void AddGame(Game game)
        {
            preInstalledGames.Add(game);
        }
    }
}