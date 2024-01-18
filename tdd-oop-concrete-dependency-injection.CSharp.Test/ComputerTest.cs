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
            Game ff11 = new Game("Final Fantasy XI");

            myPc.installGame(ff11);

            Assert.That(1, Is.EqualTo(myPc.installedGames.Count()));
            Assert.That("Final Fantasy XI", Is.EqualTo(myPc.installedGames[0]._name));
        }

        [Test]
        public void shouldPlayGames()
        {
            PowerSupply myPsu = new PowerSupply();
            Computer myPc = new Computer(myPsu);
            Game duck = new Game("Duck Game");
            Game dragon = new Game("Dragon's Dogma: Dark Arisen");
            Game morrowwind = new Game("Morrowwind");

            myPc.installGame(duck);
            myPc.installGame(dragon);

            Assert.That("Playing Duck Game", Is.EqualTo(myPc.playGame(duck)));
            Assert.That("Playing Dragon's Dogma: Dark Arisen", Is.EqualTo(myPc.playGame(dragon)));
            Assert.That("Game not installed", Is.EqualTo(myPc.playGame(morrowwind)));
        }
        
        [Test]
        public void canPreinstallGames()
        {
            PowerSupply myPsu = new PowerSupply();
            List<Game> preInstalled = new List<Game>();
            preInstalled.Add(new Game("Dwarf Fortress"));
            preInstalled.Add(new Game("Baldur's Gate"));


            Computer myPc = new Computer(myPsu);

            myPc.installedGames = preInstalled;


            Assert.That(2, Is.EqualTo(myPc.installedGames.Count));
            Assert.That("Dwarf Fortress", Is.EqualTo(myPc.installedGames[0]._name));
            Assert.That("Baldur's Gate", Is.EqualTo(myPc.installedGames[1]._name));
        }
    }
}