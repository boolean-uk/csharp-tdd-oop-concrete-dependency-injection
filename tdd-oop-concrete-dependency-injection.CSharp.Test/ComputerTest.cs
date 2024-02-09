using tdd_oop_concrete_dependency_injection.CSharp.Main;
using NUnit.Framework;

namespace tdd_oop_concrete_dependency_injection.CSharp.Test
{
    class ComputerTest
    {
        GameCreator gameCreator;
        [SetUp]
        public void Setup()
        {
            gameCreator = new GameCreator();
        }

        [Test]
        public void shouldTurnOn()
        {
            PowerSupply myPsu = new PowerSupply();
            Computer myPc = new Computer(myPsu, new List<Game>());
            myPc.turnOn();

            Assert.IsTrue(myPsu.isOn);
        }

         [Test]
        public void shouldInstallGames()
        {
            PowerSupply myPsu = new PowerSupply();
            Computer myPc = new Computer(myPsu, new List<Game>());

            myPc.installGame(gameCreator.createGame("Duck Game"));

            int timesFFXInstalled = 0;
            for(int i = 0; i < myPc.installedGames.Count; i++) {
                if(myPc.installedGames[i].name == "Duck Game") {
                    timesFFXInstalled += 1;
                }
            }

            Assert.AreEqual(1, timesFFXInstalled);
        }

        [Test]
        public void shouldPlayGames()
        {
            PowerSupply myPsu = new PowerSupply();
            Computer myPc = new Computer(myPsu, new List<Game>());

            myPc.installGame(gameCreator.createGame("Duck Game"));
            myPc.installGame(gameCreator.createGame("Dark Arisen"));

            Assert.AreEqual("Playing Duck Game", myPc.playGame("Duck Game"));
            Assert.AreEqual("Playing Dark Arisen", myPc.playGame("Dark Arisen"));
        }
        
        [Test]
        public void canPreinstallGames()
        {
            PowerSupply myPsu = new PowerSupply();
            List<Game> preInstalled = new List<Game>
            {
                gameCreator.createGame("Dwarf Fortress"),
                gameCreator.createGame("Baldur's Gate")
            };


            Computer myPc = new Computer(myPsu, new List<Game>(preInstalled));

            Assert.AreEqual(2, myPc.installedGames.Count());
            Assert.AreEqual("Dwarf Fortress", myPc.installedGames[0].name);
            Assert.AreEqual("Baldur's Gate", myPc.installedGames[1].name);
        }
    }
}