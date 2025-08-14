using DndBattleSim.App.Randomisers;

namespace DndBattleSim.App.Characters
{
    public abstract class Character : ICharacter
    {
        public int HP { get; protected set; }
        public int Attack { get; protected set; }
        public string Team { get; }
        public string Name { get; protected set; }

        public Character(IRandomiser randomiser, string teamName)
        {
            this.HP = randomiser.Next(1, 11);
            this.Attack = randomiser.Next(1, 11);
            this.Team = teamName;
        }

        public virtual void RandomAttack(ICharacter enemy)
        {
            enemy.GotHit(this.Attack);
        }

        public void GotHit(int damage)
        {
            this.HP -= damage;
        }
    }
}