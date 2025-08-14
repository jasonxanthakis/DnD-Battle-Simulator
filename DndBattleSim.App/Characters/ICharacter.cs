namespace DndBattleSim.App.Characters
{
    public interface ICharacter
    {
        int HP { get; }
        int Attack { get; }

        void RandomAttack(ICharacter character);

        void GotHit(int damage);
    }
}