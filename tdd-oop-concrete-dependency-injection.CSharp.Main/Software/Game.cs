using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tdd_oop_concrete_dependency_injection.CSharp.Main;

namespace Software
{
    public class Game : ISoftware
    {
        private string _name;

        public Game(string Name)
        {
            _name = Name;
        }

        public string getName()
        {
            return _name;
        }

        public string start()
        {
            return "Playing " + _name;
        }
    }
}
