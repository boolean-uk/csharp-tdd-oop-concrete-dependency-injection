using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_concrete_dependency_injection.CSharp.Main
{
    public class Computer 
    {        
        public PowerSupply powerSupply;
        public List<Game> installedGames = new List<Game>();

        public Computer(PowerSupply powerSupply, List<Game> InstalledGames) {
            this.powerSupply = powerSupply;
            this.installedGames = InstalledGames;   
        }

        public void turnOn() {
            powerSupply.turnOn();
        }

        public void installGame(Game name) {
            installedGames.Add(name);
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
