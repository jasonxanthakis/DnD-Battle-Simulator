namespace DndBattleSim.App.Randomisers
{
    public class Randomiser : IRandomiser
    {
        private Random rnd = new Random();

        public int Next(int min, int max)
        {
            return this.rnd.Next(min, max);
        }
    }
}