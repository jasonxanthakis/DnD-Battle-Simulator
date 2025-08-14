namespace DndBattleSim.App.UserInput
{
    public class ConsoleUserInput : IUserInput
    {
        public string? ReadLine()
        {
            return System.Console.ReadLine();
        }
    }
}