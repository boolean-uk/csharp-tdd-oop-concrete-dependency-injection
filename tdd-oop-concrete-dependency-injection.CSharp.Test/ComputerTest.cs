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

            Assert.That(myPsu.isOn);
        }

        [Test]
        public void shouldInstallGames()
        {
            PowerSupply myPsu = new PowerSupply();
            Computer myPc = new Computer(myPsu);
            Game ff = new Game("Final Fantasy XI");
            myPc.installGame(ff);

            Assert.That(1, Is.EqualTo(myPc.installedGames.Count()));
            Assert.That("Final Fantasy XI", Is.EqualTo(myPc.installedGames[0].Name));
        }

        [Test]
        public void shouldPlayGames()
        {
            PowerSupply myPsu = new PowerSupply();
            Computer myPc = new Computer(myPsu);
            Game duckGame = new Game("Duck Game");
            Game dragonsDogma = new Game("Dragon's Dogma: Dark Arisen");

            myPc.installGame(duckGame);
            myPc.installGame(dragonsDogma);

            Assert.That("Playing Duck Game", Is.EqualTo(myPc.playGame("Duck Game")));
            Assert.That("Playing Dragon's Dogma: Dark Arisen", Is.EqualTo(myPc.playGame("Dragon's Dogma: Dark Arisen")));
            Assert.That("Game not installed", Is.EqualTo(myPc.playGame("Morrowind"))); //An unforgivable crime. All PC's should have Morrowind installed!
        }
        
        [Test]
        public void canPreinstallGames()
        {
            PowerSupply myPsu = new PowerSupply();
            List<Game> preInstalled = new List<Game>();
            Game dorfFortress = new Game("Dwarf Fortress");
            Game baldursGate = new Game("Baldur's Gate");

            preInstalled.Add(dorfFortress);
            preInstalled.Add(baldursGate);

            Computer myPc = new Computer(myPsu, preInstalled);

            //Checking that the preInstalled list is passed in correctly and will install games regularly afterwards.
            Game europaU = new Game("Europa Universalis IV");
            myPc.installGame(europaU);

            Assert.That(3, Is.EqualTo(myPc.installedGames.Count));
            Assert.That("Dwarf Fortress", Is.EqualTo(myPc.installedGames[0].Name));
            Assert.That("Baldur's Gate", Is.EqualTo(myPc.installedGames[1].Name));
            Assert.That("Europa Universalis IV", Is.EqualTo(myPc.installedGames[2].Name));
        }
    }
}