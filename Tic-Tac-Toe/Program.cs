using System;

class Program
{
    public static void StartNewGame()
    {
        UserGreeting.userInputName();
        Board.CreateVisualBoard();
        Board.CreateProgramBoard();
        GameMechanics.TypeOfInput();
    }

    static void Main()
    {
        StartNewGame();
    }
}

