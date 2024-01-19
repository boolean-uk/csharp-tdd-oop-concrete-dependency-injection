using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_concrete_dependency_injection.CSharp.Main
{
    public class Computer 
    {
        private List<Game> _installedGames = new List<Game>();
        
        private PowerSupply _powerSupply;

        public List<Game> installedGames { get => _installedGames; set => _installedGames = value; }
        public PowerSupply powerSupply { get => _powerSupply; set => _powerSupply = value; }

        public Computer(PowerSupply psu) {
            powerSupply = psu;
        }

        public void turnOn() {
            powerSupply.turnOn();
        }

        public void installGame(string name) {
            Game game = new Game(name);
            game.Name = name;
            installedGames.Add(game);
        }

        public String playGame(string name) {
            foreach (Game g in installedGames) {
                if (g.Name.Equals(name)) {
                    return g.start();
                }
            }

            return "Game not installed";
        }
    }
}
