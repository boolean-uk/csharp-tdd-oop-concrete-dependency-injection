using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tdd_oop_concrete_dependency_injection.CSharp.Main;

namespace tdd_oop_concrete_dependency_injection.CSharp.Main
{
    public class PowerSupply {
        public bool isOn = false;

        public void turnOn() {
            this.isOn = true;
        }
    }
}