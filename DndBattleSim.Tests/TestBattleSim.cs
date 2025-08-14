using DndBattleSim.App.BattleSimulator;
using DndBattleSim.Tests.Helpers;

namespace DndBattleSim.Tests
{
    [TestFixture]
    public class BattleSimTests
    {
        [Test]
        public void Check_That_Singleton_BattleSim_Returns_Same_Instance()
        {
            // Act
            var instance1 = BattleSim.CreateGame(new MockUserInput(""));
            var instance2 = BattleSim.CreateGame(new MockUserInput(""));

            // Assert
            Assert.That(instance1, Is.SameAs(instance2));
        }

        [Test]
        public void Check_That_PlayAgain_Returns_Correct_Value()
        {
            // Act
            var instance = BattleSim.CreateGame(new MockUserInput(""));
            bool result1 = instance.PlayAgain(new MockUserInput("yes"));
            bool result2 = instance.PlayAgain(new MockUserInput("no"));

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result1, Is.True);
                Assert.That(result2, Is.False);
            });
        }
    }
}