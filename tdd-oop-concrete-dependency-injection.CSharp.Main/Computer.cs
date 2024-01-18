using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_concrete_dependency_injection.CSharp.Main
{
    public class Computer 
    {
        private List<Game> _installedGames = new List<Game>();
        
        private PowerSupply _powerSupply;
        
        public Computer(PowerSupply powerSupply, List<Game> preInstalledGame = null) {
            _powerSupply = powerSupply;
            if(preInstalledGame != null)
            {
                _installedGames = preInstalledGame;
            }
        }

        public void turnOn() {
            PowerSupply.turnOn();
        }

        public void installGame(Game game) {
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
    public List<Game> InstalledGames { get { return _installedGames; } set { _installedGames = value; }  }
    public PowerSupply PowerSupply { get { return _powerSupply; } set { _powerSupply = value; } }
    }

}
