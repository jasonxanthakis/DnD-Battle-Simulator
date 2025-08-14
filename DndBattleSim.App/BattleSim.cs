using System.Security.Cryptography;
using DndBattleSim.App.Characters;
using DndBattleSim.App.Randomisers;
using DndBattleSim.App.BattleTeams;
using DndBattleSim.App.UserInput;
using System.Collections;

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
                this.RunTurnLoop(new Randomiser());

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

        public Queue<ICharacter> CleanQueue(Queue<ICharacter> turnQueue)
        {
            for (int i = turnQueue.Count; i > 0; i--)
            {
                var current = turnQueue.Dequeue();
                if (current.HP > 0)
                {
                    turnQueue.Enqueue(current);
                }
            }

            return turnQueue;
        }

        public void RunTurnLoop(IRandomiser randomiser)
        {
            int turnCount = 1;
            while (this.team1.AliveCount() > 0 && this.team2.AliveCount() > 0)
            {
                this.CleanQueue(this.turnQueue);

                System.Console.WriteLine($"Turn {turnCount}");
                this.OutputCharacters();

                ICharacter currentHero = this.turnQueue.Peek();
                string team = currentHero.Team;

                ICharacter enemy;
                if (this.team1.teamName == team)
                {
                    var aliveCharacters = this.team2.team.Where(c => c.HP > 0).ToList();
                    enemy = aliveCharacters[randomiser.Next(0, aliveCharacters.Count)];
                }
                else if (this.team2.teamName == team)
                {
                    var aliveCharacters = this.team1.team.Where(c => c.HP > 0).ToList();
                    enemy = aliveCharacters[randomiser.Next(0, aliveCharacters.Count)];
                }
                else
                {
                    throw new Exception("Fatal error: couldn't identify team");
                }

                currentHero.RandomAttack(enemy);

                this.turnQueue.Dequeue();
                if (currentHero.HP > 0)
                {
                    this.turnQueue.Enqueue(currentHero);
                }

                turnCount++;
            }

            
            this.OutputCharacters();

            this.OutputWinningText();
        }

        public void OutputCharacters()
        {
            foreach (var hero in this.team1.team)
            {
                System.Console.Write($" {hero.Name} : {hero.HP}HP  {(hero.HP <= 0 ? "(DEAD)" : "")}  ");
            }
            System.Console.Write("\n");
            foreach (var hero in this.team2.team)
            {
                System.Console.Write($" {hero.Name} : {hero.HP}HP  {(hero.HP <= 0 ? "(DEAD)" : "")}  ");
            }
            System.Console.Write("\n");
            System.Console.WriteLine();
        }

        public void OutputWinningText()
        {
            if (this.team1.team.Count == 0 && this.team2.team.Count == 0)
            {
                System.Console.WriteLine("Plotwist: Everyone is dead, so it's a draw");
            }

            if (this.team1.team.Count == 0)
            {
                System.Console.WriteLine($"Congratulations to {this.team1.teamName}! They are victorious!");
            }
            else if (this.team2.team.Count == 0)
            {
                System.Console.WriteLine($"Congratulations to {this.team2.teamName}! They are victorious!");
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