namespace tdd_oop_concrete_dependency_injection.CSharp.Main;

public class Computer 
{
    public List<Game> installedGames;
    
    public PowerSupply powerSupply;

    public Computer(PowerSupply powerSupply) {
        this.powerSupply = powerSupply;
        installedGames = new List<Game>();
    }

    public Computer(PowerSupply powerSupply, List<Game> preInstalledGames)
    {
        this.powerSupply = powerSupply;
        installedGames = preInstalledGames;
    }

    public void turnOn() {
        powerSupply.turnOn();
    }

    public void installGame(Game game) {
        installedGames.Add(game);
    }

    public string playGame(string name) {
        foreach (Game g in installedGames) {
            if (g.name.Equals(name)) {
                return g.start();
            }
        }

        return "Game not installed";
    }
}
