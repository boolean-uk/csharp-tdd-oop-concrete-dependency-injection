using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_concrete_dependency_injection.CSharp.Main
{
    public class Game 
    {
        private string _name;


        public Game(string name) {
            _name = name;
        }

        public string start() {
            return "Playing " + this.name;
        }

        public string name { get { return _name; } }
    }
    
}
