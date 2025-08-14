namespace DndBattleSim.App.Randomisers
{
    public interface IRandomiser
    {
        int Next(int min, int max);
    }
}