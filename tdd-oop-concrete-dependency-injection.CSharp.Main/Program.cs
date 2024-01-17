using tdd_oop_concrete_dependency_injection.CSharp.Main;

PowerSupply myPsu = new PowerSupply();
Computer myPc = new Computer(myPsu);

//myPc.installGame("Final Fantasy XI");


List<Game> preInstalled = new List<Game>();
myPc.installGame("Dark souls 2");
myPc.playGame("Dark souls 2");
preInstalled.Add(new Game("Dwarf Fortress"));
preInstalled.Add(new Game("Baldur's Gate"));
Console.WriteLine("");