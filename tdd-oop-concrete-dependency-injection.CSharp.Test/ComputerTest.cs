using tdd_oop_concrete_dependency_injection.CSharp.Main;
using NUnit.Framework;

namespace tdd_oop_concrete_dependency_injection.CSharp.Test
{
    class ComputerTest
    {
        private List<Game> installedGames = new List<Game>();
        [Test]
        public void shouldTurnOn()
        {
            PowerSupply myPsu = new PowerSupply();
            Computer myPc = new Computer(myPsu, installedGames);
            myPc.turnOn();

            Assert.That(myPsu.isOn);
        }

        /*
        [Test]
        public void shouldInstallGames()
        {
            PowerSupply myPsu = new PowerSupply();
            Computer myPc = new Computer(myPsu);

            myPc.installGame("Final Fantasy XI");

            Assert.That(1, Is.EqualTo(myPc.installedGames.Count()));
            Assert.That("Final Fantasy XI", Is.EqualTo(myPc.installedGames[0].name));
        }
        */

        [Test]
        public void shouldInstallGames()
        {
            PowerSupply myPsu = new PowerSupply();
            Computer myPc = new Computer(myPsu, installedGames);

            myPc.installGame("Final Fantasy XI");

            int timesFFXInstalled = 0;
            for (int i = 0; i < myPc.installedGames.Count; i++)
            {
                if (myPc.installedGames[i].name == "Final Fantasy XI")
                {
                    timesFFXInstalled += 1;
                }
            }

            Assert.AreEqual(1, timesFFXInstalled);
        }



        [Test]
        public void shouldPlayGames()
        {
            PowerSupply myPsu = new PowerSupply();
            Computer myPc = new Computer(myPsu, installedGames);

            myPc.installGame("Duck Game");
            myPc.installGame("Dragon's Dogma: Dark Arisen");

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


            Computer myPc = new Computer(myPsu, preInstalled);

            Assert.That(2, Is.EqualTo(myPc.installedGames.Count));
            Assert.That("Dwarf Fortress", Is.EqualTo(myPc.installedGames[0].name));
            Assert.That("Baldur's Gate", Is.EqualTo(myPc.installedGames[1].name));
        }
    }
}