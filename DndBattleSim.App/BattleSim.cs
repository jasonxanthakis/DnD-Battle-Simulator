namespace DndBattleSim.App.BattleSimulator
{
    public sealed class BattleSim
    {
        private static BattleSim _instance;

        private BattleSim() { }

        public static BattleSim CreateGame()
        {
            if (BattleSim._instance == null)
            {
                BattleSim._instance = new BattleSim();
            }
            return BattleSim._instance;
        }
    }
}