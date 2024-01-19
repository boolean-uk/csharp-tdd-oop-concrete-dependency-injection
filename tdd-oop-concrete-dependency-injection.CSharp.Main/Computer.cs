using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_concrete_dependency_injection.CSharp.Main
{
    public class Computer 
    {
        public List<Game> _installedGames = new List<Game>();
        
        public PowerSupply _powerSupply;

        public Computer(List<Game> installedGames, PowerSupply powerSupply) {
            _installedGames = installedGames;
            _powerSupply = powerSupply;
        }

        public Computer(PowerSupply powerSupply)
        {
            _powerSupply = powerSupply;
        }

        public List<Game> InstalledGames { get { return _installedGames; } set { _installedGames = value; } }
        public PowerSupply PowerSupply { get { return _powerSupply; } set { _powerSupply = value; } }

        public void turnOn() {
            PowerSupply.turnOn();
        }

        public void installGame(string name) {
            Game game = new Game(name);
            InstalledGames.Add(game);
        }

        public String playGame(string name) {
            foreach (Game g in InstalledGames) {
                if (g.Name.Equals(name)) {
                    return g.start();
                }
            }

            return "Game not installed";
        }
    }
}
