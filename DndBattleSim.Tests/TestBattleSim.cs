using DndBattleSim.App.BattleSimulator;

namespace DndBattleSim.Tests
{
    [TestFixture]
    public class BattleSimTests
    {
        [Test]
        public void Check_That_Singleton_BattleSim_Returns_Same_Instance()
        {
            // Act
            var instance1 = BattleSim.CreateGame();
            var instance2 = BattleSim.CreateGame();

            Assert.That(instance1, Is.SameAs(instance2));
        }
    }
}