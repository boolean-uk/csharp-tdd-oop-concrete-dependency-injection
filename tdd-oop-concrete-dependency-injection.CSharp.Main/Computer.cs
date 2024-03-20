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
        
        public PowerSupply powerSupply;

        public Computer(PowerSupply powerSupply)
        {
            this.powerSupply = powerSupply;
        }

        public Computer(PowerSupply psu, List<Game> preInstalledGames) {
            this.powerSupply = psu;
            this.installedGames = preInstalledGames;
        }

        public void turnOn() {
            //PowerSupply psu = new PowerSupply();
            this.powerSupply.turnOn();
        }

        public void installGame(Game game) {
            this.installedGames.Add(game);

        }

        public String playGame(Game game) {
            foreach (Game g in this.installedGames) {
                if (g.name.Equals(game.name)) {
                    return g.start();
                }
            }

            return "Game not installed";
        }
    }
}
