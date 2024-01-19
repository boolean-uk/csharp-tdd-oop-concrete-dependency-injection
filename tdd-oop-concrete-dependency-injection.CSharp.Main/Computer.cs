using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_concrete_dependency_injection.CSharp.Main
{
    public class Computer 
    {
        public List<Game> installedGames = new List<Game>();
        
        public PowerSupply powerSupply;

        public Game game;

        public Computer(PowerSupply powerSupply) {
            this.powerSupply = powerSupply;
        }

        /*
         Dependency Injection:

         Original Code: This code creates a new instance of PowerSupply within the turnOn
         method.It tightly couples the Computer class to a specific implementation of PowerSupply.
         which means f.example. one class (in this case, Computer) is highly dependent on the details of
         another class (PowerSupply). Tight coupling makes the classes more interconnected and less independent 
         if you decide to change the way PowerSupply works or want to use a different 
         class for power supply, you would need to modify the Computer class as well.

         public void turnOn()
         {
            PowerSupply psu = new PowerSupply();
            psu.turnOn();
         } 
         */
        //using dependency injection, we pass an instance of 
        //PowerSupply through the constructor. This allows different implementaions of 
        //Powersupply to be used with the computer class.
        public void turnOn() {
            this.powerSupply.turnOn();
        }

        //Adds a Game instance to the list of installed games on the Computer.
        public void installGame(Game game) {
            this.installedGames.Add(game);
        }

        public String playGame(string name) {
            foreach (Game g in this.installedGames) {
                if (g.name.Equals(name)) {
                    return g.start();
                }
            }

            return "Game not installed";
        }
    }
}
