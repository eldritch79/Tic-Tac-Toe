using System;

class Program
{
    public static void StartNewGame()
    {
        UserGreeting.userInputName();
        Board.FirstGame();
        GameStarter();
    }

    public static void StartNextGame()
    {
        Board.ProgramBoard.Clear();
        Board.VisualBoard.Clear();
        Console.Clear();
        GameStarter();
    }

    public static void GameStarter()
    {

        Board.CreateVisualBoard();
        Board.CreateProgramBoard();
        GameMechanics.TypeOfInput();
    }

    static void Main()
    {
        StartNewGame();
    }
}

