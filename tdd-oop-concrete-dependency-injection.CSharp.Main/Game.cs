﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_concrete_dependency_injection.CSharp.Main
{
    public class Game 
    {
        public string Name { get; }

        public Game(string name) 
        {
            this.Name = name;
           
        }

        public String start() {
            return "Playing " + this.Name;
        }
    }
}
