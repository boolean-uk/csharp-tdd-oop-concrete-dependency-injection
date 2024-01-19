using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tdd_oop_concrete_dependency_injection.CSharp.Main;

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
            //PowerSupply psu = new PowerSupply();
            powerSupply.turnOn();
        }

        public void installGame(string name) {
            Game game = new Game(name);
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

        public void PreInstallGames(List<Game> preInstalledGames)
        {
            installedGames.AddRange(preInstalledGames);
        }

        public List<Game> InstalledGames
        {
            get { return installedGames; }
        }
    }
}
