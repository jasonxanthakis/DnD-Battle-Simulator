using System.Security.Cryptography;
using DndBattleSim.App.Characters;
using DndBattleSim.App.Randomisers;
using DndBattleSim.App.BattleTeams;
using DndBattleSim.App.UserInput;

namespace DndBattleSim.App.BattleSimulator
{
    public sealed class BattleSim
    {
        private static BattleSim _instance;
        private readonly IUserInput InputSource;

        private BattleSim(IUserInput input)
        {
            this.InputSource = input;
        }

        public static BattleSim CreateGame(IUserInput input)
        {
            if (BattleSim._instance == null)
            {
                BattleSim._instance = new BattleSim(input);
            }
            return BattleSim._instance;
        }

        private BattleTeam team1;
        private BattleTeam team2;
        private Queue<ICharacter> turnQueue = new Queue<ICharacter>();

        public void RunGame()
        {
            bool play = true;
            while (play)
            {
                // Set up teams
                this.team1 = new BattleTeam("1", this.InputSource);
                this.team2 = new BattleTeam("2", this.InputSource);

                // Set up Turn Queue
                this.turnQueue = SetUpQueue(this.turnQueue, this.team1, this.team2);

                // Turn loop
                // this.RunTurnLoop();

                // Check if they want to play again
                play = this.PlayAgain(this.InputSource);
            }
        }

        public Queue<ICharacter> SetUpQueue(Queue<ICharacter> turnQueue, BattleTeam team1, BattleTeam team2)
        {
            foreach (ICharacter hero in team1.team)
            {
                if (hero.HP > 0)
                {
                    turnQueue.Enqueue(hero);
                }
            }
            foreach (ICharacter hero in team2.team)
            {
                if (hero.HP > 0)
                {
                    turnQueue.Enqueue(hero);
                }
            }

            return turnQueue;
        }

        public void RunTurnLoop()
        {
            while (this.team1.team.Count > 0 && this.team2.team.Count > 0)
            {
                ICharacter currentHero = this.turnQueue.Dequeue();

                // select enemy to attack

                // attack enemy

                // if enemy died or hero died > recreate Queue
            }
        }

        public bool PlayAgain(IUserInput input)
        {
            System.Console.Write("Do you want to play again? ");
            string? userInput = input.ReadLine()?.Trim().ToLower();
            if (userInput == "yes" || userInput == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}