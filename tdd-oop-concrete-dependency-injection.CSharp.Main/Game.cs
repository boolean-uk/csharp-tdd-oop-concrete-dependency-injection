using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_concrete_dependency_injection.CSharp.Main
{
    public class Game 
    {
        public string name;

        public Game(string name) {
            this.name = name;
        }

        public String start() {
            return "Playing " + this.name;
        }

        public Game FinalF = new Game("Final Fantasy XI");
        Game Duckgame = new Game("Duck Game");
        Game DDD = new Game("Dragon's Dogma: Dark Arisen");
    }
}
