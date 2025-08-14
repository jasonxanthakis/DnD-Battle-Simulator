using DndBattleSim.App.Characters;
using DndBattleSim.App.Randomisers;
using Moq;

namespace DndBattleSim.Tests
{
    [TestFixture]
    public class WarriorTests
    {
        private Mock<IRandomiser> mockRandomiser;

        [SetUp]
        public void SetUp()
        {
            // Assign
            this.mockRandomiser = new Mock<IRandomiser>();
            this.mockRandomiser.Setup(rnd => rnd.Next(1, 11)).Returns(10);
        }

        [Test]
        public void Check_That_HP_Value_Is_Expected_Value()
        {
            // Act
            var warrior = new Warrior(this.mockRandomiser.Object);

            // Assert
            Assert.That(warrior.HP, Is.EqualTo(15));
        }

        [Test]
        public void Check_That_RandomAttack_Works_As_Intended()
        {
            // Act
            var warrior = new Warrior(this.mockRandomiser.Object);
            var enemy = new Warrior(this.mockRandomiser.Object);
            warrior.RandomAttack(enemy);

            // Assert
            Assert.That(enemy.HP, Is.EqualTo(5));
        }
    }
}