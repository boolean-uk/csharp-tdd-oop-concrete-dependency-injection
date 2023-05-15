using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_concrete_dependency_injection.CSharp.Main
{
    public class Computer {
        private PowerSupply _powerSupply;
        public List<Game> installedGames = new List<Game>();
        public Computer(PowerSupply psu) {
        
            _powerSupply = psu;
        }
        public void turnOn() {
            _powerSupply.turnOn();
        }

        public void installGame(String name) {
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
}
