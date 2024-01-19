using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_concrete_dependency_injection.CSharp.Main
{
    public class Computer 
    {
        public List<Game> installedGames { get; set; } = new List<Game>();
        
        private PowerSupply powerSupply;

        public Computer(PowerSupply powerSupply) {
            this.powerSupply = powerSupply;
        }

        public Computer(PowerSupply powerSupply, List<Game> preinstalled)
        {
            this.powerSupply = powerSupply;
            this.installedGames = preinstalled;
        }

        public void turnOn() {
            powerSupply.turnOn();
        }

        public void installGame(Game game) {
            this.installedGames.Add(game);
        }

        public String playGame(string name) {
            foreach (Game g in this.installedGames) {
                if (g.name.Equals(name)) {
                    return g.start();
                }
            }

            return "Game not installed";
        }
    }
}
