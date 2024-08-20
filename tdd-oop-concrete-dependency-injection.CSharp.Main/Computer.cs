using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_concrete_dependency_injection.CSharp.Main
{
    public class Computer 
    {
        public List<Game> _installedGames;
        
        private PowerSupply _powerSupply;

        private Game _game;

        public Computer(PowerSupply powerSupply) {
            _powerSupply = powerSupply;
            _installedGames = new List<Game>();
        }

        public void turnOn() {
            _powerSupply.turnOn();
        }

        public void installGame(string name) {
            _game = new Game(name);
            this._installedGames.Add(_game);
        }

        public String playGame(string name) {
            foreach (Game g in this._installedGames) {
                if (g.name.Equals(name)) {
                    return g.start();
                }
            }

            return "Game not installed";
        }
    }
}
