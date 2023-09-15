using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_concrete_dependency_injection.CSharp.Main
{
    public class Computer 
    {   
        private List<Game> installedGames;
        private PowerSupply powerSupply;

        public Computer(PowerSupply powerSupply, List <Game> installedGames)
        {
            this.powerSupply = powerSupply;
            this.installedGames = installedGames;
        }

        public void turnOn() 
        {
            powerSupply.turnOn();           // use the powersupply provided
        }

        public void installGame(Game game) 
        {
            installedGames.Add(game);
        }

        public String playGame(string name) {
            foreach (Game g in installedGames) 
            {
                if (g.name.Equals(name)) 
                {
                    return g.start();
                }
            }

            return "Game not installed";
        }
    }
}
