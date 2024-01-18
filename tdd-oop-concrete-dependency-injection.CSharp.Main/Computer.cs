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

        public Computer(PowerSupply powerSupply) {
            this.powerSupply = powerSupply;
        }

        public void turnOn() {
            powerSupply.turnOn();
        }

        public void installGame(Game game) {
            this.installedGames.Add(game);
        }

        public void preInstallGames(List<Game> games) 
        {
            foreach (Game game in games) 
            {
                installedGames.Add(game);
            }
        }

        public String playGame(Game game) {
            Game? gameToPlay = this.installedGames.Where(g => g.Equals(game)).FirstOrDefault();
            if (gameToPlay != null) 
            {
                return gameToPlay.start();
            }
            return "Game not installed";
        }
    }
}
