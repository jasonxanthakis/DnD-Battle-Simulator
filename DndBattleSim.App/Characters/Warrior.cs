using DndBattleSim.App.Randomisers;

namespace DndBattleSim.App.Characters
{
    public class Warrior : Character
    {
        public Warrior(IRandomiser randomiser) : base(randomiser)
        {
            this.HP += 5;
        }
    }
}