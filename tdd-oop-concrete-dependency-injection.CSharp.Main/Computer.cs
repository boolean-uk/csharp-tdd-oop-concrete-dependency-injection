using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_concrete_dependency_injection.CSharp.Main
{
    public class Computer 
    {
        private List<Game> installedGames = new List<Game>();
        
        private PowerSupply powerSupply;

        public Computer(PowerSupply powerSupply) {
            this.powerSupply = powerSupply;
        }

        public void turnOn() {
            powerSupply.turnOn();
        }

        public void installGame(Game game) {
            installedGames.Add(game);
        }

        public String playGame(string name) {
            foreach (Game g in installedGames) {
                if (g.getName().Equals(name)) {
                    return g.start();
                }
            }

            return "Game not installed";
        }

        public List<Game> getInstalledGames()
        {
            return installedGames;
        }
    }




    /*
     * public class Computer 
    {
        public List<Game> installedGames = new List<Game>();
        
        public PowerSupply powerSupply;

        public Computer(PowerSupply powerSupply) {
            this.powerSupply = powerSupply;
        }

        public void turnOn() {
            PowerSupply psu = new PowerSupply();
            psu.turnOn();
        }

        public void installGame(string name) {
            Game game = new Game(name);
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
    */
}
