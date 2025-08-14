using DndBattleSim.App.Characters;
using DndBattleSim.App.Randomisers;
using Moq;

namespace DndBattleSim.Tests
{
    [TestFixture]
    public class WizardTests
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
            var wizard = new Wizard(this.mockRandomiser.Object, "example team");

            // Assert
            Assert.That(wizard.Attack, Is.EqualTo(20));
        }

        [Test]
        public void Check_That_RandomAttack_Works_As_Intended()
        {
            // Act
            var wizard = new Wizard(this.mockRandomiser.Object, "example team");
            var enemy = new Warrior(this.mockRandomiser.Object, "example team");
            wizard.RandomAttack(enemy);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(enemy.HP, Is.EqualTo(-5));
                Assert.That(wizard.HP, Is.EqualTo(9));
            });
        }
    }
}