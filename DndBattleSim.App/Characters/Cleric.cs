using DndBattleSim.App.Randomisers;

namespace DndBattleSim.App.Characters
{
    public class Cleric : Character
    {
        public Cleric(IRandomiser randomiser) : base(randomiser) { }

        public override void RandomAttack(ICharacter enemy)
        {
            base.RandomAttack(enemy);
            this.HP++;
        }
    }
}