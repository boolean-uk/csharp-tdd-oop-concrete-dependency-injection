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
        private List<ISoftware> _installedPrograms;

        public List<ISoftware> InstalledPrograms
        {
            get { return _installedPrograms; }
        }

        private PowerSupply _powerSupply;

        public Computer(PowerSupply powerSupply) {
            this._powerSupply = powerSupply;
            _installedPrograms = new List<ISoftware>();


        }



        public void turnOn() {
            _powerSupply.turnOn();
        }

        public void installSoftware(ISoftware program) {
            this._installedPrograms.Add(program);
            
        }

        public void preInstallSoftware(List<ISoftware> games) 
        {
            foreach (ISoftware sw in games) 
            {
                installSoftware(sw);
            }
        }

        public String playGame(ISoftware program) {
            ISoftware? targetProgram = this._installedPrograms.Where(g => g.Equals(program)).FirstOrDefault();
            if (targetProgram != null) 
            {
                return targetProgram.start();
            }
            return "Game not installed";
        }
    }
}
