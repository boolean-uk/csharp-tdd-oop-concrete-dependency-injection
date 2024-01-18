using NUnit.Framework;
using tdd_oop_concrete_dependency_injection.CSharp.Main;

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

            Assert.That(myPsu.isOn);
        }

        [Test]
        public void shouldInstallGames()
        {
            PowerSupply myPsu = new PowerSupply();
            Computer myPc = new Computer(myPsu);

            myPc.installGame(new Game("Final Fantasy XI"));

            Assert.That(1, Is.EqualTo(myPc.installedGames.Count()));
            Assert.That("Final Fantasy XI", Is.EqualTo(myPc.installedGames[0].name));
        }

        [Test]
        public void shouldPlayGames()
        {
            PowerSupply myPsu = new PowerSupply();
            Computer myPc = new Computer(myPsu);

            Game duckGame = new("Duck Game");
            Game dragonsDGame = new("Dragon's Dogma: Dark Arisen");
            Game morrowindGame = new("Morrowind");
            myPc.installGame(duckGame);
            myPc.installGame(dragonsDGame);

            Assert.That("Playing Duck Game", Is.EqualTo(myPc.playGame(duckGame)));
            Assert.That("Playing Dragon's Dogma: Dark Arisen", Is.EqualTo(myPc.playGame(dragonsDGame)));
            Assert.That("Game not installed", Is.EqualTo(myPc.playGame(morrowindGame)));
        }

        [Test]
        public void canPreinstallGames()
        {
            PowerSupply myPsu = new PowerSupply();
            List<Game> preInstalled = [new Game("Dwarf Fortress"), new Game("Baldur's Gate")];


            Computer myPc = new Computer(myPsu);
            preInstalled.ForEach(myPc.installGame);

            Assert.That(2, Is.EqualTo(myPc.installedGames.Count));
            Assert.That("Dwarf Fortress", Is.EqualTo(myPc.installedGames[0].name));
            Assert.That("Baldur's Gate", Is.EqualTo(myPc.installedGames[1].name));
        }
    }
}