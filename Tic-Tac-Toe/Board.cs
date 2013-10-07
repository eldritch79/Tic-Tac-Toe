using System;
using System.Collections;
using System.Collections.Generic;

public class Board
{
    public static List<string> VisualBoard { get; set; } 
    public static bool Player2Turn { get; set; }
    public static string MarkerType { get; set; }
    public static List<string> ProgramBoard { get; set; }
    public static bool GameOver { get; set; }
    // This board is purely visual only, no calculations of winner or any
    // other calculations are made with this board/list. It will only show
    // the grid and update it with the markers X/O input by users.

    public static void FirstGame()
    {
        VisualBoard = new List<string>();
        ProgramBoard = new List<string>();
    }

    public static void CreateVisualBoard()
    {
        VisualBoard.AddRange(new[] { " ", "  ", "1", " ", "2", " ", "3", " ", "\n" });
        VisualBoard.AddRange(new[] { " ", "┌", "─", "┬", "─", "┬", "─", "┐", "\n" });
        VisualBoard.AddRange(new[] { "A", "|", " ", "|", " ", "|", " ", "|", "\n" });
        VisualBoard.AddRange(new[] { " ", "├", "─", "┼", "-", "┼", "─", "┤", "\n" });
        VisualBoard.AddRange(new[] { "B", "|", " ", "|", " ", "|", " ", "|", "\n" });
        VisualBoard.AddRange(new[] { " ", "├", "─", "┼", "-", "┼", "─", "┤", "\n" });
        VisualBoard.AddRange(new[] { "C", "|", " ", "|", " ", "|", " ", "|", "\n" });
        VisualBoard.AddRange(new[] { " ", "└", "─", "┴", "─", "┴", "─", "┘", "\n" });
        Console.WriteLine(string.Join(" ", VisualBoard));
    }

    // This is the actual game board behind the scenes.
    // This is the board/array the program uses for calculations.
    // The items put in this array (0-8) are for readability purposes only
    // and has no other purpose than to reflect its index for us to read.
    // They will be set to X or O when a player sets his mark on the board.
    public static void CreateProgramBoard()
    {
        ProgramBoard.AddRange(new[] { " ", " ", " ", " ", " ", " ", " ", " ", " " });
    }

    // This method puts the player marks on the ProgramBoard.
    public static void PlaceInProgramBoard(string position)
    {
        // Translates user input into real positions in the ProgramBoard array
        Hashtable positionOfSquares = new Hashtable
        {
            {"A1", 0},
            {"A2", 1},
            {"A3", 2},
            {"B1", 3},
            {"B2", 4},
            {"B3", 5},
            {"C1", 6},
            {"C2", 7},
            {"C3", 8}
        };

        ProgramBoard[(int)positionOfSquares[position]] = MarkerType;

        // WriteLine for test purposes, allows us to see the ProgramBoard change
        // during gameplay.
        Console.WriteLine(string.Join(", ", ProgramBoard));
    }

    // Method will take user input, i.e. A2, B3, translate it to the
    // real position in the VisualBoard.
    public static int PositionTableForVisualBoard(string position)
    {
        // Create a hashtable with the positions of the fields
        // on the VisualBoard where a player may put his/hers mark 
        Hashtable positionOfSquares = new Hashtable
        {
            {"A1", 20},
            {"A2", 22},
            {"A3", 24},
            {"B1", 38},
            {"B2", 40},
            {"B3", 42},
            {"C1", 56},
            {"C2", 58},
            {"C3", 60}
        };

        int realPosition = (int)positionOfSquares[position];
        return realPosition;
    }

    public static void PlaceMarker(string position)
    {

        // Translate Xn (ie. A1) to actual index position in list VisualBoard
        int positionToPlaceMarker = PositionTableForVisualBoard(position);

        // Make sure the player does not try to place a piece on an already
        // occupied position
        //added "?" to acceptable chars to remove and replace
        if (VisualBoard[positionToPlaceMarker] == " " || VisualBoard[positionToPlaceMarker] == "?")
        {
            // Remove existing empty space and replace with MarkerType (X or O).
            VisualBoard.RemoveAt(positionToPlaceMarker);
            VisualBoard.Insert(positionToPlaceMarker, MarkerType);
            Console.Clear();
            Console.WriteLine(string.Join(" ", VisualBoard));

            //Testing new board and winnercontrol
            PlaceInProgramBoard(position);
            TestForWinner();
            SwitchPlayer();
        }
        else
        {
            Console.WriteLine("This position has already been taken! Trying to cheat, huh?");
            GameMechanics.TypeOfInput(Program.LastGameOpponent);
        }
    }

    public static void SwitchPlayer()
    {
        // Changes the marker X/O depending on player turn.
        MarkerType = Player2Turn ? "O" : "X";

        // Invert Player2Turn
        Player2Turn = !Player2Turn;

        if (Player2Turn && Program.LastGameOpponent != "pvp")
        {
            if (!Board.GameOver) InitiateBotTurn(Program.LastGameOpponent);
            else GameMechanics.GameOver();
            
        }

        // Allow next turn to start
        if (!Board.GameOver)
        {
            GameMechanics.TypeOfInput(Program.LastGameOpponent);
        }
    }

    // Brand new method for checking if there's a winner
    // A lot less messy than the ultralong if's we had before.
    public static void TestForWinner()
    {
        // Using arrays within arrays, inception yay!
        // Each array in this array (ie. {0,1,2}) represents
        // a possible winning row.
        int[,] winners = new int[,]
                   {
                        {0,1,2},
                        {3,4,5},
                        {6,7,8},
                        {0,3,6},
                        {1,4,7},
                        {2,5,8},
                        {0,4,8},
                        {2,4,6}
                   };

        // This loops thru the positions in the Winners array to check
        // if the player who just put his mark, now has three in a row
        // anywhere on the board.
        for (int i = 0; i < 8; i++) // The "outer" array in Winners
        {
            for (int j = 0; j <= 3; ) // The "inner" array in Winners
            {
                // If the first index in the inner array holds the players mark
                // we do the j++ and check the next index.
                if (MarkerType == ProgramBoard[winners[i, j]])
                {
                    j++;
                }
                // If the first or second index in a possible winners row
                // was not marked by the player, there's no need to check
                // the rest of the row, hence break.
                else
                    break;
                // If j reaches 3, it means that we have had 3 of the players
                // MarkerType on a winning row, a winner!
                if (j == 3)
                {
                    AnnounceWinner();
                    break;
                }
            }
        }
    }

    // Someone has won and we celebrate with this great announcement!
    public static void AnnounceWinner()
    {
        Console.WriteLine("YAY!!! {0} won with three in a row!", Player2Turn ? UserGreeting.Player2 : UserGreeting.Player1);
        HighScoreTable(Player2Turn ? UserGreeting.Player2 : UserGreeting.Player1);
        GameOver = true;
    }

    public static void HighScoreTable(string player)
    {

        if (player == UserGreeting.Player1)
        {
            UserGreeting.Player1Wins++;
        }
        else if (player == UserGreeting.Player2)
        {
            UserGreeting.Player2Wins++;
        }

        Console.WriteLine("\nCurrent score for this tournament:\n");
        
        Console.WriteLine("{0}: {1} wins.", UserGreeting.Player1, UserGreeting.Player1Wins);
        Console.WriteLine("{0}: {1} wins.", UserGreeting.Player2, UserGreeting.Player2Wins);
    }

    public static void InitiateBotTurn(string botname)
    {
        switch (botname)
        {
            case "Emil":
                EmkesBot.StartHalfBrainBot();
                break;
            case "Johan":
                // Call the class.method() that starts your bot here
                break;
            case "Linus":
                MonkeyBot.StartMonkeyBot();
                break;
            case "Paul":
                RandomBot.StartRandomBot();
                break;
        }
    }
}