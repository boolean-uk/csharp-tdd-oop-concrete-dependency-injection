using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace tdd_oop_concrete_dependency_injection.CSharp.Main
{
    public class PowerSupply 
    {
        public bool isOn = false;
        public void TurnOn() 
        {
            this.isOn = true;
        }
    }
}