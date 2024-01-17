using tdd_oop_concrete_dependency_injection.CSharp.Main;
using NUnit.Framework;

namespace tdd_oop_concrete_dependency_injection.CSharp.Test
{
    class ComputerTest
    {
        PowerSupply myPsu;
        public ComputerTest()
        {
            myPsu = new PowerSupply();
        }
        [Test]
        public void shouldTurnOn()
        {
            Computer myPc = new Computer(myPsu);
            myPc.turnOn();

            Assert.IsTrue(myPsu.isOn);
        }

        [Test]
        public void shouldInstallGames()
        {
            Computer myPc = new Computer(myPsu);
            Game game = new Game("Final Fantasy XI");

            myPc.installGame(game);

            Assert.AreEqual(1, myPc.installedGames.Count());
            Assert.AreEqual("Final Fantasy XI", myPc.installedGames[0].name);
        }

        [Test]
        public void shouldPlayGames()
        {
            Computer myPc = new Computer(myPsu);
            Game DuckGame = new Game("Duck Game");
            Game DDDA = new Game("Dragon's Dogma: Dark Arisen");

            myPc.installGame(DuckGame);
            myPc.installGame(DDDA);

            Assert.AreEqual("Playing Duck Game", myPc.playGame(DuckGame));
            Assert.AreEqual("Playing Dragon's Dogma: Dark Arisen", myPc.playGame(DDDA));
            Assert.AreEqual("Game not installed", myPc.playGame(new Game("Morrowind")));
        }
        
        [Test]
        public void canPreinstallGames()
        {
            List<Game> preInstalled = new List<Game>();
            preInstalled.Add(new Game("Dwarf Fortress"));
            preInstalled.Add(new Game("Baldur's Gate"));


            Computer myPc = new Computer(myPsu, preInstalled);

            Assert.AreEqual(2, myPc.installedGames.Count());
            Assert.AreEqual("Dwarf Fortress", myPc.installedGames[0].name);
            Assert.AreEqual("Baldur's Gate", myPc.installedGames[1].name);
        }
    }
}