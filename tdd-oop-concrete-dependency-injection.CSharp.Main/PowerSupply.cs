using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_concrete_dependency_injection.CSharp.Main
{
    public class PowerSupply {
        private bool isOn = false;

        public void turnOn()
        {
            this.isOn = true;
        }

        public bool Status { get => isOn; }
    }
}
