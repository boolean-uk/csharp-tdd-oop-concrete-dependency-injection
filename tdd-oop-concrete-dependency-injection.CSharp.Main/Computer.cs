using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Software;

namespace tdd_oop_concrete_dependency_injection.CSharp.Main
{
    public class Computer 
    {
        public List<ISoftware> installedPrograms { get { return new List<ISoftware>(installedPrograms); } set { new List<ISoftware>(); } }
        
        private PowerSupply _powerSupply;

        public Computer(PowerSupply powerSupply) {
            this._powerSupply = powerSupply;
            
        }

        public void turnOn() {
            _powerSupply.turnOn();
        }

        public void installSoftware(ISoftware program) {
            this.installedPrograms.Add(program);
            
        }

        public void preInstallSoftware(List<ISoftware> games) 
        {
            foreach (Game game in games) 
            {
                installedPrograms.Add(game);
            }
        }

        public String playGame(ISoftware program) {
            ISoftware? targetProgram = this.installedPrograms.Where(g => g.Equals(program)).FirstOrDefault();
            if (targetProgram != null) 
            {
                return targetProgram.start();
            }
            return "Game not installed";
        }
    }
}
