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

        public String start() {
            return "Playing " + Name;
        }

        public string Name { get { return _name; } }
    }
}
