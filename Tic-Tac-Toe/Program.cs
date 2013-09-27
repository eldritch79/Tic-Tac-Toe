using System;

class Program
{
    public static void StartNewGame()
    {
        UserGreeting.userInputName();
        Board.CreateVisualBoard();
        Board.CreateProgramBoard();
        GameMechanics.Input();
    }

    static void Main()
    {
        StartNewGame();
    }
}

