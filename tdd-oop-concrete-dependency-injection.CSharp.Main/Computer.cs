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

        public Computer(PowerSupply powerSupply, List<Game> preInstalled = null) {
            this.powerSupply = powerSupply;
            if (preInstalled != null)
            {
                foreach (Game game in preInstalled)
                {
                    installedGames.Add(game);
                }
            }
        }

        public void turnOn() {
            this.powerSupply.turnOn();
        }

        public void installGame(string name) {
            Game game = new Game(name);
            installedGames.Add(game);
        }

        public void preInstall(List<Game> preGames)
        {
            foreach (Game g in preGames)
            {
                installedGames.Add(g);
            }
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
