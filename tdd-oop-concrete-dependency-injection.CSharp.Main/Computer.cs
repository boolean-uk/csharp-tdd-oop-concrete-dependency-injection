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

        public void TurnOn() {
            powerSupply.TurnOn();
        }

        public void InstallGame(Game game) {
            this.installedGames.Add(game);
        }

        public String PlayGame(string name) {
            foreach (Game g in this.installedGames) {
                if (g.Name.Equals(name)) {
                    return g.Start();
                }
            }

            return "Game not installed";
        }

        public List<Game> InstalledGames { get => installedGames; set => installedGames = value; }
        public PowerSupply PowerSupply { get => powerSupply; }
    }
}
