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
            Computer myPc = new Computer(myPsu);
            myPc.TurnOn();

            Assert.That(myPsu.IsOn);
        }

        [Test]
        public void shouldInstallGames()
        {
            PowerSupply myPsu = new PowerSupply();
            Computer myPc = new Computer(myPsu);

            myPc.InstallGame(new Game("Final Fantasy XI"));

            Assert.That(1, Is.EqualTo(myPc.InstalledGames.Count()));
            Assert.That("Final Fantasy XI", Is.EqualTo(myPc.InstalledGames[0].Name));
        }

        [Test]
        public void shouldPlayGames()
        {
            PowerSupply myPsu = new PowerSupply();
            Computer myPc = new Computer(myPsu);

            myPc.InstallGame(new Game("Duck Game"));
            myPc.InstallGame(new Game("Dragon's Dogma: Dark Arisen"));

            Assert.That("Playing Duck Game", Is.EqualTo(myPc.PlayGame("Duck Game")));
            Assert.That("Playing Dragon's Dogma: Dark Arisen", Is.EqualTo(myPc.PlayGame("Dragon's Dogma: Dark Arisen")));
            Assert.That("Game not installed", Is.EqualTo(myPc.PlayGame("Morrowind")));
        }
        
        [Test]
        public void canPreinstallGames()
        {
            PowerSupply myPsu = new PowerSupply();
            List<Game> preInstalled = new List<Game>();
            preInstalled.Add(new Game("Dwarf Fortress"));
            preInstalled.Add(new Game("Baldur's Gate"));


            Computer myPc = new Computer(myPsu);
            myPc.InstalledGames = preInstalled;

            Assert.That(2, Is.EqualTo(myPc.InstalledGames.Count));
            Assert.That("Dwarf Fortress", Is.EqualTo(myPc.InstalledGames[0].Name));
            Assert.That("Baldur's Gate", Is.EqualTo(myPc.InstalledGames[1].Name));
        }
    }
}