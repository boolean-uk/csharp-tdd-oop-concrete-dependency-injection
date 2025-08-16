using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_concrete_dependency_injection.CSharp.Main
{
    public class Computer 
    {
        private readonly List<Game> _installedGames = new List<Game>();        
        private PowerSupply _powerSupply;

        public Computer(PowerSupply powerSupply, List<Game>? preInstalledGames = null)
        {
            _powerSupply = powerSupply;
            if (preInstalledGames != null)
            {
                _installedGames.AddRange(preInstalledGames);
            }
        }

        public void turnOn() {
            _powerSupply.turnOn();
        }

        public void installGame(Game game) {
            _installedGames.Add(game);
        }

        public String playGame(string name) {
            foreach (Game g in _installedGames) {
                if (g.Name.Equals(name)) {
                    return g.start();
                }
            }

            return "Game not installed";
        }

        public List<Game> InstalledGames => _installedGames;

    }
}
