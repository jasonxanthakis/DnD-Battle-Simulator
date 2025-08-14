namespace DndBattleSim.App.Characters
{
    public interface ICharacter
    {
        int HP { get; }
        int Attack { get; }

        void RandomAttack();

        void GotHit(int damage);
    }
}