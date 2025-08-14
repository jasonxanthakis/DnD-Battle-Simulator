# DnD Battle Simulator

A console game that allows the creation of two teams (3 characters each) that fight in a turn based environment in a last man standing scenario.

## Prerequisites
- Microsoft .NET 8.0.0^

## Installation
1. Clone the repository
2. Change directory into the main directory `DnD-Battle-Simulator`
3. Run the command `dotnet build`

## How to Run the Game
1. Change directory into the app using `cd .\DndBattleSim.App\`
2. Run the command `dotnet run`

## How to Run the Tests
1. Change directory into the main directory `DnD-Battle-Simulator`
2. Run the command `dotnet test`

## Playing the Game
This is an explanation of how the game is played when run:
1. Player 1 will get to create a team name and select three characters to play.
    - The player can choose between the following: Warrior, Wizard and Cleric.
        - Each character by default has randomly generated HP and attack values (range of 1-10).
        - The Warrior gets a bonus 5HP regardless of their random HP value.
        - The Wizard gets their attack score doubled but loses 1 HP for every attack they make.
        - The Cleric heals themselves by 1 HP for every attack they make.
    - The player can choose multiple of each type of character.
2. Player 2 then gets to create a team name and select three characters to play, from the same options as Player 1.
3. The game will then simulate a battle by having each character attack an enemy character randomly in the order they were created.
4. The battle ends when one of the two teams has no characters left.
    - The last team standing is the winner.
    - In the unlikely event that neither has any characters left (i.e. a wizard killing themselves), the game is a draw.
5. The players are then prompted if they want to play again.
    - Should they accept, they get to create new teams.
    - Should they refuse, the game terminates.

## Assumptions Made
- During team creation, Team 1 will create its name and select all its characters first, then Team 2 will create its name and select its characters.
- Each character's attack action counts as a turn.
- Characters will attack in the order they are created. This means that all of the Team 1 characters will attack before any character from Team 2 can.
- Keeping track of records and metrics (e.g. how many games played or won) isn't required.
- Users can choose to play again once their current match is finished.