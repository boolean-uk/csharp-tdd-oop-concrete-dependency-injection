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
            Game game = new Game("Final Fantasy XI");

            myPc.installGame(game);

            Assert.That(1, Is.EqualTo(myPc.installedGames.Count()));
            Assert.That("Final Fantasy XI", Is.EqualTo(myPc.installedGames[0].name));
        }

        [Test]
        public void shouldPlayGames()
        {
            PowerSupply myPsu = new PowerSupply();
            Computer myPc = new Computer(myPsu);
            Game game = new Game("Duck Game");
            Game game1 = new Game("Dragon's Dogma: Dark Arisen");
            myPc.installGame(game);
            myPc.installGame(game1);

            Assert.That("Playing Duck Game", Is.EqualTo(myPc.playGame(game.name)));
            Assert.That("Playing Dragon's Dogma: Dark Arisen", Is.EqualTo(myPc.playGame(game1.name)));
            Assert.That("Game not installed", Is.EqualTo(myPc.playGame("Morrowind")));
        }
        
        [Test]
        public void canPreinstallGames()
        {
            PowerSupply myPsu = new PowerSupply();
            
            Computer myPc = new Computer(myPsu);

            Game game = new Game("Dwarf Fortress"); 
            Game game1 = new Game("Baldur's Gate"); 

            myPc.installedGames.Add(game);
            myPc.installedGames.Add(game1);


            Assert.That(2, Is.EqualTo(myPc.installedGames.Count));
            Assert.That("Dwarf Fortress", Is.EqualTo(myPc.installedGames[0].name));
            Assert.That("Baldur's Gate", Is.EqualTo(myPc.installedGames[1].name));
        }
    }
}