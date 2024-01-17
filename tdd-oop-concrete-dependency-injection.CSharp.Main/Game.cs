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
        private static List<Game> _installedGames = new List<Game>();
        public static List<Game> InstalledGames { get { return _installedGames; } }

        public Game(string name) {
           
            this.name = name;
            _installedGames.Add(this);
        }

        public String start() {
            return "Playing " + this.name;
        }
    }
}
