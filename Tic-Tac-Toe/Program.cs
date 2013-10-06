using System;

class Program
{
    // Remembers choice of opponent for next round.
    public static string LastGameOpponent { get; set; }

    public static void InitiatePvpSession()
    {
        // This is a pvp game (Player vs. Player)
        const bool pvp = true;
        const string gameType = "pvp";
        LastGameOpponent = "pvp";

        UserGreeting.UserInputName(pvp);
        Board.FirstGame();
        GameStarter(gameType);
    }

    public static void InitiateBotSession(string botname)
    {
        // This is a pve game (Player vs. Enviroment), pvp is false
        const bool pvp = false;
        LastGameOpponent = botname;

        UserGreeting.UserInputName(pvp);
        Board.FirstGame();
        GameStarter(botname);
    }
    
    // First game when program starts begins here.
    public static void StartNewGame()
    {
        SoundEffect.PlaySound();
        UserGreeting.PvpOrPve();
    }

    // This method is needed to start a new round
    // Clearing the board from last game and starting a new.
    public static void StartNextGame()
    {
        GameMechanics.XStarts = !GameMechanics.XStarts;
        //if (GameMechanics.xStarts)
        Board.Player2Turn = GameMechanics.XStarts;
        Board.ProgramBoard.Clear();
        Board.VisualBoard.Clear();
        Console.Clear();
        GameStarter(LastGameOpponent);
    }

    // This is needed for first games and next games
    public static void GameStarter(string opponent)
    {
        Board.CreateVisualBoard();
        Board.CreateProgramBoard();
        GameMechanics.TypeOfInput(opponent);
    }

    static void Main()
    {
        StartNewGame();
    }
}

