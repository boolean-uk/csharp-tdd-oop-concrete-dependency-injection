using tdd_oop_concrete_dependency_injection.CSharp.Main;
using NUnit.Framework;

namespace tdd_oop_concrete_dependency_injection.CSharp.Test
{
    class ComputerTest
    {
        GameFactory factory = new GameFactory();
        [Test]
        public void shouldTurnOn()
        {
            PowerSupply myPsu = new PowerSupply();
            Computer myPc = new Computer(myPsu, new List<Game>());
            myPc.turnOn();

            Assert.That(myPsu.isOn);
        }

        [Test]
        public void shouldInstallGames()
        {
            PowerSupply myPsu = new PowerSupply();
            Computer myPc = new Computer(myPsu, new List<Game>());

            Game finalFantasyXI = factory.createGame("Final Fantasy XI");
            myPc.installGame(finalFantasyXI);   

            Assert.That(1, Is.EqualTo(myPc.installedGames.Count()));
            Assert.That("Final Fantasy XI", Is.EqualTo(myPc.installedGames[0].name));
        }

        [Test]
        public void shouldPlayGames()
        {
            PowerSupply myPsu = new PowerSupply();
            Computer myPc = new Computer(myPsu, new List<Game>());

            Game DuckGame = factory.createGame("Duck Game");
            Game DragonsDogma = factory.createGame("Dragon's Dogma: Dark Arisen");

            myPc.installGame(DuckGame);
            myPc.installGame(DragonsDogma);

            Assert.That("Playing Duck Game", Is.EqualTo(myPc.playGame("Duck Game")));
            Assert.That("Playing Dragon's Dogma: Dark Arisen", Is.EqualTo(myPc.playGame("Dragon's Dogma: Dark Arisen")));
            Assert.That("Game not installed", Is.EqualTo(myPc.playGame("Morrowind")));
        }
        
        [Test]
        public void canPreinstallGames()
        {
            PowerSupply myPsu = new PowerSupply();
            List<Game> preInstalled = new List<Game>();

            Game DwarfFortress = factory.createGame("Dwarf Fortress");
            Game BaldursGate = factory.createGame("Baldur's Gate");
            preInstalled.Add(DwarfFortress);
            preInstalled.Add(BaldursGate);


            Computer myPc = new Computer(myPsu, preInstalled);

            Assert.That(2, Is.EqualTo(myPc.installedGames.Count));
            Assert.That("Dwarf Fortress", Is.EqualTo(myPc.installedGames[0].name));
            Assert.That("Baldur's Gate", Is.EqualTo(myPc.installedGames[1].name));
        }
    }
}