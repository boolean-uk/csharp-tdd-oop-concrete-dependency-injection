using tdd_oop_concrete_dependency_injection.CSharp.Main;
using NUnit.Framework;
using Software;

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
            ISoftware FFXI = new Game("Final Fantasy XI");

            myPc.installSoftware(FFXI);

            Assert.That(1, Is.EqualTo(myPc.installedPrograms.Count()));
            Assert.That("Final Fantasy XI", Is.EqualTo(myPc.installedPrograms[0].getName()));
        }

        [Test]
        public void shouldPlayGames()
        {
            PowerSupply myPsu = new PowerSupply();
            Computer myPc = new Computer(myPsu);
            ISoftware duckGame = new Game("Duck Game");
            ISoftware dragonsDogma = new Game("Dragon's Dogma: Dark Arisen");
            ISoftware morrowwind = new Game("Morrowwind");

            myPc.installSoftware(duckGame);
            myPc.installSoftware(dragonsDogma);

            Assert.That("Playing Duck Game", Is.EqualTo(myPc.playGame(duckGame)));
            Assert.That("Playing Dragon's Dogma: Dark Arisen", Is.EqualTo(myPc.playGame(dragonsDogma)));
            Assert.That("Game not installed", Is.EqualTo(myPc.playGame(morrowwind)));
        }
        
        [Test]
        public void canPreinstallGames()
        {
            PowerSupply myPsu = new PowerSupply();
            List<ISoftware> preInstalled = new List<ISoftware>();
            preInstalled.Add(new Game("Dwarf Fortress"));
            preInstalled.Add(new Game("Baldur's Gate"));


            Computer myPc = new Computer(myPsu);
            myPc.preInstallSoftware(preInstalled);

            Assert.That(2, Is.EqualTo(myPc.installedPrograms.Count));
            Assert.That("Dwarf Fortress", Is.EqualTo(myPc.installedPrograms[0].getName()));
            Assert.That("Baldur's Gate", Is.EqualTo(myPc.installedPrograms[1].getName()));
        }
    }
}