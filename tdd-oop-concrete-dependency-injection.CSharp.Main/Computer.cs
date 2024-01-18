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

        public Computer(PowerSupply powerSupply, List<Game> preInstalledGames = null) {
            this.powerSupply = powerSupply;

            if (preInstalledGames != null)
                installedGames = preInstalledGames;
        }

        public void turnOn() {
            powerSupply.turnOn();
        }

        public void installGame(string name) {
            installedGames.Add(new Game(name));
        }

        public String playGame(string name) {
            Game game = installedGames.Find(x => x.Name == name);

            if (game == default(Game) || game == null)
                return "Game not installed";

            return game.start();
        }
    }
}
