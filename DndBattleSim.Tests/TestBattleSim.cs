using DndBattleSim.App.BattleSimulator;
using DndBattleSim.App.BattleTeams;
using DndBattleSim.App.Characters;
using DndBattleSim.App.UserInput;
using DndBattleSim.Tests.Helpers;

namespace DndBattleSim.Tests
{
    [TestFixture]
    public class BattleSimTests
    {
        private IUserInput mockUserCompleteInput;

        [SetUp]
        public void SetUp()
        {
            // Assign
            this.mockUserCompleteInput = new MockUserCompleteInput();
        }

        [Test]
        public void Check_That_MockUserCompleteInput_Returns_Correct_User_Inputs()
        {
            // Act
            var game = BattleSim.CreateGame(this.mockUserCompleteInput);
            var team1 = new BattleTeam("1", this.mockUserCompleteInput);
            var team2 = new BattleTeam("2", this.mockUserCompleteInput);
            var response = game.PlayAgain(this.mockUserCompleteInput);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(team1.teamName, Is.EqualTo("team1"));
                Assert.That(team2.teamName, Is.EqualTo("team2"));
                Assert.That(response, Is.EqualTo(false));
            });
        }

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

        [Test]
        public void Check_That_SetUpQueue_Works_As_Intended()
        {
            // Assign
            var game = BattleSim.CreateGame(this.mockUserCompleteInput);
            var team1 = new BattleTeam("1", this.mockUserCompleteInput);
            var team2 = new BattleTeam("2", this.mockUserCompleteInput);
            var turnQueue = new Queue<ICharacter>();

            // Act
            turnQueue = game.SetUpQueue(turnQueue, team1, team2);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(turnQueue.Count, Is.EqualTo(6));
                Assert.That(turnQueue.Peek, Is.InstanceOf<Warrior>());
            });
        }
    }
}