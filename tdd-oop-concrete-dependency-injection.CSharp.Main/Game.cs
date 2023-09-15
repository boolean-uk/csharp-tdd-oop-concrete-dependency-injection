using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace tdd_oop_concrete_dependency_injection.CSharp.Main
{
    public class Game
    {
        public string name;

        public Game(string name)
        {
            this.name = name; 
        }

        public string Start()
        {
            return "Playing " + this.name;
        }
    }
}