namespace DndBattleSim.App
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("hello world");
            var game = BattleSimulator.BattleSim.CreateGame();
        }
    }
}