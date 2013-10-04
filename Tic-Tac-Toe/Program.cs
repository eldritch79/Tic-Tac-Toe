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
        GameMechanics.xStarts = !GameMechanics.xStarts;
        //if (GameMechanics.xStarts)
        Board.Player1Turn = GameMechanics.xStarts;
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
        SoundEffect.PlaySound();
        StartNewGame();
    }
}

