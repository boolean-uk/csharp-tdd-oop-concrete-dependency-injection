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
            myPc.turnOn();

            Assert.That(myPsu.IsOn(), Is.True);
        }

        [Test]
        public void shouldInstallGames()
        {
            PowerSupply myPsu = new PowerSupply();
            Computer myPc = new Computer(myPsu);

            myPc.installGame(new Game("Final Fantasy XI"));

            int timesFFXInstalled = 0;
            for (int i = 0; i < myPc.installedGames.Count; i++)
            {
                if (myPc.installedGames[i].name == "Final Fantasy XI")
                {
                    timesFFXInstalled += 1;
                }
            }

            Assert.That(timesFFXInstalled, Is.EqualTo(1));
        }

        [Test]
        public void shouldPlayGames()
        {
            PowerSupply myPsu = new PowerSupply();
            Computer myPc = new Computer(myPsu);

            myPc.installGame(new Game("Duck Game"));
            myPc.installGame(new Game("Dragon's Dogma: Dark Arisen"));

            Assert.That("Playing Duck Game", Is.EqualTo(myPc.playGame("Duck Game")));
            Assert.That("Playing Dragon's Dogma: Dark Arisen", Is.EqualTo(myPc.playGame("Dragon's Dogma: Dark Arisen")));
            Assert.That("Game not installed", Is.EqualTo(myPc.playGame("Morrowind")));
        }
        
        [Test]
        public void canPreinstallGames()
        {
            PowerSupply myPsu = new PowerSupply();
            List<Game> preInstalled = new List<Game>();
            preInstalled.Add(new Game("Dwarf Fortress"));
            preInstalled.Add(new Game("Baldur's Gate"));


            Computer myPc = new Computer(myPsu);

            Assert.That(myPc.getInstalledGames().Count(), Is.EqualTo(2));
            Assert.That("Dwarf Fortress", Is.EqualTo(myPc.getInstalledGames()[0].name));
            Assert.That("Baldur's Gate", Is.EqualTo(myPc.getInstalledGames()[1].name));
        }
    }
}