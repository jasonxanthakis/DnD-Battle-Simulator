using DndBattleSim.App.Randomisers;

namespace DndBattleSim.App.Characters
{
    public class Wizard : Character
    {
        public Wizard(IRandomiser randomiser, string teamName) : base(randomiser, teamName)
        {
            this.Attack *= 2;
        }

        public override void RandomAttack(ICharacter enemy)
        {
            base.RandomAttack(enemy);
            this.HP--;
        }
    }
}