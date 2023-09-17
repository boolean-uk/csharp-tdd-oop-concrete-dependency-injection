using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_concrete_dependency_injection.CSharp.Main
{
    public class Computer 
    {
        public List<Game> installedGames = new List<Game>();

        public List<Game> preInstalled = new List<Game>();
        

        public PowerSupply powerSupply;

        public Computer(PowerSupply powerSupply) {
            this.powerSupply = powerSupply;
        }

        public void turnOn() {
            // PowerSupply psu = new PowerSupply();
            powerSupply.turnOn();
        }

        public void installGame(Game game) {
            this.installedGames.Add(game);
        }

        // added this because Im confused with what I should do for the last test
        public void preInstallGame(Game game)
        {
            this.preInstalled.Add(game);
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
