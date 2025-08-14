using DndBattleSim.App.Randomisers;

namespace DndBattleSim.App.Characters
{
    public abstract class Character : ICharacter
    {
        public int HP { get; private set; }
        public int Attack { get; private set; }

        public Character(IRandomiser randomiser)
        {
            HP = randomiser.Next(1, 11);
            Attack = randomiser.Next(1, 11);
        }

        public void RandomAttack()
        {

        }

        public void GotHit(int damage)
        {
            this.HP -= damage;
        }
    }
}