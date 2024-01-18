using tdd_oop_concrete_dependency_injection.CSharp.Main;

PowerSupply powerSupply = new PowerSupply();
List<Game> preInstalled = new List<Game>();
preInstalled.Add(new Game("Dwarf Fortress"));
preInstalled.Add(new Game("Baldur's Gate"));
Computer computer = new Computer(powerSupply, preInstalled);