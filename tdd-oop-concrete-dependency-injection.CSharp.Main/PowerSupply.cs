using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_concrete_dependency_injection.CSharp.Main
{
    public class PowerSupply {
        private bool _isOn = false;
        public List<Game> preInstalled = new List<Game>();
        public void turnOn() {
            _isOn = true;
        }

        public bool IsOn { get => _isOn; }
    }
}
