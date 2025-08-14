using DndBattleSim.App.BattleTeams;
using DndBattleSim.Tests.Helpers;
using DndBattleSim.App.Characters;

namespace DndBattleSim.Tests
{
    [TestFixture]
    public class BattleTeamTests
    {
        [Test]
        public void Check_That_GetTeamName_Works_As_Expected()
        {
            // Assign
            MockUserInput mockUserInput = new MockUserInput("Team 1");

            // Act
            string teamName = BattleTeam.GetTeamName(mockUserInput);

            // Assert
            Assert.That(teamName, Is.EqualTo("Team 1"));
        }

        [Test]
        public void Check_That_CreateCharacter_Returns_Correct_Character_Derivative()
        {
            // Assign
            MockUserInput mockUserInput1 = new MockUserInput("warrior");
            MockUserInput mockUserInput2 = new MockUserInput("wizard");
            MockUserInput mockUserInput3 = new MockUserInput("cleric");

            // Act
            ICharacter hero1 = BattleTeam.CreateCharacter(mockUserInput1, "example team");
            ICharacter hero2 = BattleTeam.CreateCharacter(mockUserInput2, "example team");
            ICharacter hero3 = BattleTeam.CreateCharacter(mockUserInput3, "example team");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(hero1, Is.InstanceOf<Warrior>());
                Assert.That(hero2, Is.InstanceOf<Wizard>());
                Assert.That(hero3, Is.InstanceOf<Cleric>());
            });
        }

        // [Test]
        // public void experiment()
        // {
        //     // Assign
        //     MockUserInput mockUserInput = new MockUserInput("bad input");

        //     // Assert
        //     Assert.Throws<TimeoutException>(() => { BattleTeam.CreateCharacter(mockUserInput); });
        // }
    }
}