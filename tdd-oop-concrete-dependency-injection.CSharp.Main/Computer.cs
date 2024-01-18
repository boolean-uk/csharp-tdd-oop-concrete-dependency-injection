namespace tdd_oop_concrete_dependency_injection.CSharp.Main
{
    public class Computer
    {
        public List<Game> installedGames = new List<Game>();

        public PowerSupply powerSupply;

        public Computer(PowerSupply powerSupply)
        {
            this.powerSupply = powerSupply;
        }

        public void turnOn()
        {
            powerSupply.turnOn();
        }

        public void installGame(Game game)
        {
            this.installedGames.Add(game);
        }

        public String playGame(Game game)
        {
            foreach (Game g in this.installedGames)
            {
                if (g == game)
                {
                    return g.start();
                }
            }

            return "Game not installed";
        }
    }
}
