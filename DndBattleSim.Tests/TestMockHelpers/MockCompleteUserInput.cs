using DndBattleSim.App.UserInput;

namespace DndBattleSim.Tests.Helpers
{
    public class MockUserCompleteInput : IUserInput
    {
        private int _counter = 0;

        public MockUserCompleteInput(){}

        public string? ReadLine()
        {
            this._counter++;

            return this._counter switch
            {
                1 => "team1",
                5 => "team2",
                9 => "no",
                _ => "warrior",
            };
        }
    }
}