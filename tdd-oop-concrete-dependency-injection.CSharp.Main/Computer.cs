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

        public Computer(PowerSupply powerSupply)
        {
            this.powerSupply = powerSupply;
        }

        public Computer(PowerSupply powerSupply, List<Game> preInstalled)
        {
            this.powerSupply = powerSupply;
            foreach (Game game in preInstalled)
            {
                installedGames.Add(game);
            }
        }

        public void turnOn()
        {
            powerSupply.turnOn();
        }

        public void installGame(Game game)
        {
            installedGames.Add(game);
        }

        public string playGame(Game game)
        {
            foreach (Game g in this.installedGames)
            {
                if (g.name.Equals(game.name))
                {
                    return g.start();
                }
            }

            return "Game not installed";
        }
    }
}
