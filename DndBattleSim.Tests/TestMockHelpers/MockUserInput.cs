using DndBattleSim.App.UserInput;

namespace DndBattleSim.Tests.Helpers
{
    public class MockUserInput : IUserInput
    {
        private readonly string? _input;

        public MockUserInput(string input)
        {
            this._input = input;
        }

        public string? ReadLine()
        {
            return this._input;
        }
    }
}