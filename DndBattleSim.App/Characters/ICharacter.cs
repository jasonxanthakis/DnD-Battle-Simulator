namespace DndBattleSim.App.Characters
{
    public interface ICharacter
    {
        string Name { get; }
        int HP { get; }
        int Attack { get; }
        string Team { get; }

        void RandomAttack(ICharacter character);

        void GotHit(int damage);
    }
}