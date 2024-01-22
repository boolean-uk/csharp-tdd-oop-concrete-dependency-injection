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

        public Computer(PowerSupply psu, List<Game>? preInstalled = null) {
            powerSupply = psu;
            //I interpret the "canPreInstallGames" to represent a prebuilt PC that comes with some games already installed
            if(preInstalled != null)
            {
                installedGames = preInstalled;
            }

        }

        public void turnOn() {
            powerSupply.turnOn();
        }

        public void installGame(Game game) {
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
