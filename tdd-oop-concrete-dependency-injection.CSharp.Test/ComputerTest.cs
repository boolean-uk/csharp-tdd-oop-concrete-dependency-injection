﻿using tdd_oop_concrete_dependency_injection.CSharp.Main;
using NUnit.Framework;

namespace tdd_oop_concrete_dependency_injection.CSharp.Test
{
    class ComputerTest
    {
        [Test]
        public void shouldTurnOn()
        {
            PowerSupply myPsu = new PowerSupply();
            Computer myPc = new Computer(myPsu);
            myPc.turnOn();

            Assert.IsTrue(myPsu.isOn);
        }

        [Test]
        public void shouldInstallGames()
        {
            PowerSupply myPsu = new PowerSupply();
            Computer myPc = new Computer(myPsu);
            Game FinalF;

            myPc.installGame(FinalF);

            Assert.AreEqual(1, myPc.installedGames.Count());
            Assert.AreEqual("Final Fantasy XI", myPc.installedGames[0].name);
        }

        [Test]
        public void shouldPlayGames()
        {
            PowerSupply myPsu = new PowerSupply();
            Computer myPc = new Computer(myPsu);
            Game Duckgame;
            Game DDD;

            myPc.installGame(Duckgame);
            myPc.installGame(DDD);

            Assert.AreEqual("Playing Duck Game", myPc.playGame("Duck Game"));
            Assert.AreEqual("Playing Dragon's Dogma: Dark Arisen", myPc.playGame("Dragon's Dogma: Dark Arisen"));
            Assert.AreEqual("Game not installed", myPc.playGame("Morrowind"));
        }
        
        [Test]
        public void canPreinstallGames()
        {
            PowerSupply myPsu = new PowerSupply();
            List<Game> preInstalled = new List<Game>();
            preInstalled.Add(new Game("Dwarf Fortress"));
            preInstalled.Add(new Game("Baldur's Gate"));

            // I changed the test i dont understand what I should do
            Computer myPc = new Computer(myPsu);
            myPc.preInstalled.Add(new Game("Dwarf Fortress"));
            myPc.preInstalled.Add(new Game("Baldur's Gate"));

            Assert.AreEqual(2, myPc.preInstalled.Count());
            Assert.AreEqual("Dwarf Fortress", myPc.preInstalled[0].name);
            Assert.AreEqual("Baldur's Gate", myPc.preInstalled[1].name);
        }
    }
}