using tdd_oop_concrete_dependency_injection.CSharp.Main;
using NUnit.Framework;

namespace tdd_oop_concrete_dependency_injection.CSharp.Test
{
    class ComputerTest
    {
        private PowerSupply myPsu;
        private Computer myPc;
        private List<Game> installedGames;

        [SetUp]
        public void Setup()
        {
            myPsu = new PowerSupply();
            installedGames = new List<Game>();
            myPc = new Computer(myPsu, installedGames);
        }

        [Test]
        public void shouldTurnOn()
        {
            myPc.turnOn();
            Assert.IsTrue(myPsu.isOn);
        }

        [Test]
        public void shouldInstallGames()
        {
            Game finalFantasyXI = new Game("Final Fantasy XI");
            myPc.installGame(finalFantasyXI);
            Assert.AreEqual(1, installedGames.Count);
            Assert.Contains(finalFantasyXI, installedGames);
        }

        [Test]
        public void shouldPlayGames()
        {
            Game duckGame = new Game("Duck Game");
            Game dragonsDogma = new Game("Dragon's Dogma: Dark Arisen");
            myPc.installGame(duckGame);
            myPc.installGame(dragonsDogma);
            Assert.AreEqual("Playing Duck Game", myPc.playGame(duckGame.Name));
            Assert.AreEqual("Playing Dragon's Dogma: Dark Arisen", myPc.playGame(dragonsDogma.Name));
            Assert.AreEqual("Game not installed", myPc.playGame("Morrowind"));
        }

        [Test]
        public void canPreinstallGames()
        {
            Game dwarfFortress = new Game("Dwarf Fortress");
            Game baldursGate = new Game("Baldur's Gate");
            installedGames.Add(dwarfFortress);
            installedGames.Add(baldursGate);
            Assert.AreEqual(2, installedGames.Count);
            Assert.Contains(dwarfFortress, installedGames);
            Assert.Contains(baldursGate, installedGames);
        }
    }
}