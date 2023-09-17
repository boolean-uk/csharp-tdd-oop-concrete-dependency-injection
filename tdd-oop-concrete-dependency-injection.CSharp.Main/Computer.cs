using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace tdd_oop_concrete_dependency_injection.CSharp.Main
{
    public class Computer
    {
        public List<Game> installedGames = new List<Game>();
        public PowerSupply powerSupply;

        public Computer(PowerSupply powerSupply, List<Game> preInstalledGames = null)
        {
            this.powerSupply = powerSupply;

            if (preInstalledGames != null)
            {
                this.installedGames.AddRange(preInstalledGames);
            }
        }

        public void TurnOn()
        {
            powerSupply.TurnOn();
        }

        public void InstallGame(Game game)
        {
            this.installedGames.Add(game);
        }

        public string PlayGame(string name)
        {
            foreach (Game g in this.installedGames)
            {
                if (g.name.Equals(name))
                {
                    return g.Start();
                }
            }

            return "Game not installed";
        }
    }
}