using tdd_oop_concrete_dependency_injection.CSharp.Main;
using NUnit.Framework;

namespace tdd_oop_concrete_dependency_injection.CSharp.Test
{
    [TestFixture]
    public class ComputerTests
    {
        [Test]
        public void ShouldTurnOn()
        {
            PowerSupply myPsu = new PowerSupply();
            Computer myPc = new Computer(myPsu);
            myPc.TurnOn();

            Assert.IsTrue(myPsu.isOn);
        }

        [Test]
        public void ShouldInstallGames()
        {
            PowerSupply myPsu = new PowerSupply();
            Computer myPc = new Computer(myPsu);

            Game game1 = new Game("Final Fantasy XI");
            
            myPc.InstallGame(game1);

            Assert.AreEqual(1, myPc.installedGames.Count());
            Assert.AreEqual("Final Fantasy XI", myPc.installedGames[0].name);
        }

        [Test]
        public void ShouldPlayGames()
        {
            PowerSupply myPsu = new PowerSupply();
            Computer myPc = new Computer(myPsu);

            Game game1 = new Game("Duck Game");
            Game game2 = new Game("Dragon's Dogma: Dark Arisen");

            myPc.InstallGame(game1);
            myPc.InstallGame(game2);

            Assert.AreEqual("Playing Duck Game", myPc.PlayGame("Duck Game"));
            Assert.AreEqual("Playing Dragon's Dogma: Dark Arisen", myPc.PlayGame("Dragon's Dogma: Dark Arisen"));
            Assert.AreEqual("Game not installed", myPc.PlayGame("Morrowind"));
        }

        [Test]
        public void CanPreinstallGames()
        {
            PowerSupply myPsu = new PowerSupply();
            List<Game> preInstalled = new List<Game>
            {
               new Game("Dwarf Fortress"),
               new Game("Baldur's Gate")
            };

            Computer myPc = new Computer(myPsu, preInstalled);

            Assert.AreEqual(2, myPc.installedGames.Count());
            Assert.AreEqual("Dwarf Fortress", myPc.installedGames[0].name);
            Assert.AreEqual("Baldur's Gate", myPc.installedGames[1].name);
        }

        [Test]
        public void ShouldInstallMultipleGames()
        {
            PowerSupply myPsu = new PowerSupply();
            Computer myPc = new Computer(myPsu);

            Game game1 = new Game("Duck Game");
            Game game2 = new Game("Dragon's Dogma: Dark Arisen");

            myPc.InstallGame(game1);
            myPc.InstallGame(game2);

            Assert.AreEqual(2, myPc.installedGames.Count());
            Assert.Contains(game1, myPc.installedGames);
            Assert.Contains(game2, myPc.installedGames);
        }

        [Test]
        public void ShouldPlayInstalledGames()
        {
            PowerSupply myPsu = new PowerSupply();
            Computer myPc = new Computer(myPsu);

            Game game1 = new Game("Duck Game");
            Game game2 = new Game("Dragon's Dogma: Dark Arisen");

            myPc.InstallGame(game1);
            myPc.InstallGame(game2);

            string result1 = myPc.PlayGame("Duck Game");
            string result2 = myPc.PlayGame("Dragon's Dogma: Dark Arisen");

            Assert.AreEqual("Playing Duck Game", result1);
            Assert.AreEqual("Playing Dragon's Dogma: Dark Arisen", result2);
        }
    }
}