using DndBattleSim.App.Characters;
using DndBattleSim.App.Randomisers;
using Moq;

namespace DndBattleSim.Tests
{
    [TestFixture]
    public class ClericTests
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
        public void Check_That_RandomAttack_Works_As_Intended()
        {
            // Act
            var cleric = new Cleric(this.mockRandomiser.Object);
            var enemy = new Warrior(this.mockRandomiser.Object);
            cleric.RandomAttack(enemy);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(enemy.HP, Is.EqualTo(5));
                Assert.That(cleric.HP, Is.EqualTo(11));
            });
        }
    }
}