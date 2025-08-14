using DndBattleSim.App.Randomisers;

namespace DndBattleSim.App.Characters
{
    public class Warrior : Character
    {
        public Warrior(IRandomiser randomiser, string teamName) : base(randomiser, teamName)
        {
            this.HP += 5;
            this.Name = "Warrior";
        }
    }
}