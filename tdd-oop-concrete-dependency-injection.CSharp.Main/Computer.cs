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


        public Computer(PowerSupply powerSupply, List<Game> preinstalled = null) {
            if (preinstalled is not null) installedGames = preinstalled;
            this.powerSupply = powerSupply;
        }

        public void turnOn() {
            powerSupply.turnOn();
        }

        public void installGame(Game game) {
            installedGames.Add(game);
        }

        public String playGame(Game game) {
            if (installedGames.Contains(game))
                return game.start();
            return "Game not installed";
        }
    }
}
