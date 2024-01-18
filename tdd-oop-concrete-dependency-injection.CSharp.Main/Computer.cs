using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_concrete_dependency_injection.CSharp.Main
{
    public class Computer 
    {
        public List<Game> installedGames = new();
        
        public PowerSupply powerSupply;

        public Computer(PowerSupply powerSupply) {
            this.powerSupply = powerSupply;
        }

        public Computer(PowerSupply powerSupply, List<Game> preinstalledGames)
        {
            this.powerSupply = powerSupply;
            installedGames = preinstalledGames;

        }

        public void turnOn() {
            powerSupply.turnOn();
        }

        public void installGame(string name) {
            installedGames.Add(new Game(name));
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
