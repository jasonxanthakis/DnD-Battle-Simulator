using DndBattleSim.App.Randomisers;
using DndBattleSim.App.Characters;
using Moq;

namespace DndBattleSim.Tests
{
    public class TestCharacterStub : Character
    {
        public TestCharacterStub(IRandomiser randomiser) : base(randomiser){}
    }

    [TestFixture]
    public class CharacterTests
    {
        private Mock<IRandomiser> mockRandomiser1;
        private Mock<IRandomiser> mockRandomiser2;

        [SetUp]
        public void SetUp()
        {
            // Assign
            this.mockRandomiser1 = new Mock<IRandomiser>();
            this.mockRandomiser1.Setup(rnd => rnd.Next(1, 11)).Returns(1);

            this.mockRandomiser2 = new Mock<IRandomiser>();
            this.mockRandomiser2.Setup(rnd => rnd.Next(1, 11)).Returns(10);
        }

        [Test]
        public void Check_That_HP_Value_Is_Expected_Value()
        {
            // Act
            var character1 = new TestCharacterStub(this.mockRandomiser1.Object);
            var character2 = new TestCharacterStub(this.mockRandomiser2.Object);

            // Assert
            Assert.That(character1.HP, Is.EqualTo(1));
            Assert.That(character2.HP, Is.EqualTo(10));
        }

        [Test]
        public void Check_That_Attack_Value_Is_Expected_Value()
        {
            // Act
            var character1 = new TestCharacterStub(this.mockRandomiser1.Object);
            var character2 = new TestCharacterStub(this.mockRandomiser2.Object);

            // Assert
            Assert.That(character1.Attack, Is.EqualTo(1));
            Assert.That(character2.Attack, Is.EqualTo(10));
        }

        [Test]
        public void Check_That_GotHit_Acts_As_Intended()
        {
            // Act
            var character = new TestCharacterStub(this.mockRandomiser2.Object);
            character.GotHit(5);

            // Assert
            Assert.That(character.HP, Is.EqualTo(5));
        }
    }
}