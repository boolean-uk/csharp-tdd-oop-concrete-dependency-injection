using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_concrete_dependency_injection.CSharp.Main
{
    public class Computer 
    {
        public List<Game> installedGames;
        
        public PowerSupply powerSupply;

        public Computer(PowerSupply powerSupply, List<Game> games) {
            this.powerSupply = powerSupply;
            this.installedGames = games;
        }

        public Computer(PowerSupply powerSupply) {
            this.powerSupply = powerSupply;
            this.installedGames = new List<Game>();
        }

        public void turnOn() {
            powerSupply.turnOn();
        }

        public void installGame(Game game) {
            installedGames.Add(game);
        }

        public String playGame(Game game) {
            foreach (Game g in this.installedGames) {
                if (g.name == game.name) {
                    return g.start();
                }
            }

            return "Game not installed";
        }
    }
}
