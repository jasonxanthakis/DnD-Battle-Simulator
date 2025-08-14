using DndBattleSim.App.Characters;
using DndBattleSim.App.Randomisers;
using DndBattleSim.App.UserInput;

namespace DndBattleSim.App.BattleTeams
{
    public class BattleTeam
    {
        public string teamName = "";
        public List<ICharacter> team = new List<ICharacter>();
        private static readonly string[] charOptions = ["warrior", "wizard", "cleric"];

        public BattleTeam(string playerNum, IUserInput input)
        {
            System.Console.WriteLine($"Creating team for Player {playerNum}...");

            // Get Team Name
            this.teamName = BattleTeam.GetTeamName(input);

            // Create Characters
            this.team.Add(BattleTeam.CreateCharacter(input));
            this.team.Add(BattleTeam.CreateCharacter(input));
            this.team.Add(BattleTeam.CreateCharacter(input));
        }

        public static string GetTeamName(IUserInput input)
        {
            string? userInput = null;
            while (userInput == null)
            {
                System.Console.Write("Enter your team name: ");
                userInput = input.ReadLine()?.Trim();
            }

            return userInput;
        }

        public static ICharacter CreateCharacter(IUserInput input)
        {
            string? userInput;
            while (true)
            {
                System.Console.WriteLine($"Choose your class [ {string.Join("  ", BattleTeam.charOptions)} ] ");
                userInput = input.ReadLine()?.Trim();

                if (charOptions.Contains(userInput))
                {
                    break;
                }

                System.Console.WriteLine("Invalid character. Try again.");
            }

            if (userInput == "warrior")
            {
                return new Warrior(new Randomiser());
            }
            else if (userInput == "wizard")
            {
                return new Wizard(new Randomiser());
            }
            else
            {
                return new Cleric(new Randomiser());
            }
        }
    }
}