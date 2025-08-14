namespace DndBattleSim.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = BattleSimulator.BattleSim.CreateGame(new UserInput.ConsoleUserInput());
            game.RunGame();
        }
    }
}