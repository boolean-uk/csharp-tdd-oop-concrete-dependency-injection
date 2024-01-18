using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_concrete_dependency_injection.CSharp.Main
{
    public class Computer 
    {
        public List<Game> InstalledGames = [];
        
        private readonly PowerSupply _powerSupply;

        public Computer(PowerSupply powerSupply) {
            _powerSupply = powerSupply;
        }

        public Computer(PowerSupply powerSupply, List<Game> preinstalledGames)
        {
            _powerSupply = powerSupply;
            InstalledGames = preinstalledGames;
        }

        public void TurnOn() {
            _powerSupply.turnOn();
        }

        public void InstallGame(Game game) {
            InstalledGames.Add(game);
        }

        public string PlayGame(string name) {
            foreach (Game g in InstalledGames) {
                if (g.name.Equals(name)) {
                    return g.start();
                }
            }

            return "Game not installed";
        }
    }
}
