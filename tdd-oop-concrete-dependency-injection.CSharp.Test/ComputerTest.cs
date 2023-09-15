using tdd_oop_concrete_dependency_injection.CSharp.Main;
using NUnit.Framework;

namespace tdd_oop_concrete_dependency_injection.CSharp.Test
{
    class ComputerTest
    {
        [Test]
        public void shouldTurnOn()
        {
            PowerSupply myPsu = new PowerSupply();
            Computer myPc = new Computer(myPsu, new List<Game>());
            myPc.turnOn();

            Assert.IsTrue(myPsu.isOn);
        }

        [Test]
        public void shouldInstallGames()
        {
            PowerSupply myPsu = new PowerSupply();
            List<Game> installedGames = new List<Game>();
            Computer myPc = new Computer(myPsu, installedGames);
            myPc.installGame("Final Fantasy XI");
            Assert.AreEqual(1, installedGames.Count());
            Assert.AreEqual("Final Fantasy XI", installedGames[0].name);
        }

        [Test]
        public void shouldPlayGames()
        {
            PowerSupply myPsu = new PowerSupply();
            List<Game> installedGames = new List<Game>();
            Computer myPc = new Computer(myPsu, installedGames);

            myPc.installGame("Duck Game");
            myPc.installGame("Dragon's Dogma: Dark Arisen");

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


            Computer myPc = new Computer(myPsu, preInstalled);

            Assert.AreEqual(2, preInstalled.Count());
            Assert.AreEqual("Dwarf Fortress", preInstalled[0].name);
            Assert.AreEqual("Baldur's Gate", preInstalled[1].name);
        }
    }
}