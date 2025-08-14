using DndBattleSim.App.Randomisers;

namespace DndBattleSim.App.Characters
{
    public class Cleric : Character
    {
        public Cleric(IRandomiser randomiser, string teamName) : base(randomiser, teamName) { }

        public override void RandomAttack(ICharacter enemy)
        {
            base.RandomAttack(enemy);
            this.HP++;
        }
    }
}