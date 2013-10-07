using System;
// This is the computer player made by mrapan.
// Prepare to loose!
using System.Collections;
using System.Collections.Generic;

class MonkeyBot
{
    public static bool MyTurn { get; set; }
    public static List<string> CurrentBoard { get; set; }
    public static string CurrentBoardString { get; set; }

    public static void StartMonkeyBot()
    {
        Console.WriteLine("ProgramBoard Count: " + Board.ProgramBoard.Count);
        Board.MarkerType = Board.Player2Turn ? "O" : "X";
        ImportCurrentBoard();
        BlockOpponentWin();


    }

    public static string TranslatePositions(int internalPosition)
    {
        Hashtable translate = new Hashtable
         {
            {0, "A1"},
            {1, "A2"},
            {2, "A3"},
            {3, "B1"},
            {4, "B2"},
            {5, "B3"},
            {6, "C1"},
            {7, "C2"},
            {8, "C3"}
        };

        string externalPosition = (string)translate[internalPosition];
        if (internalPosition < 0 || internalPosition > 8)
        {
            Console.WriteLine("Positionen är felaktig, den ska vara 0-8 men är nu {0}", internalPosition);
            string a = Console.ReadLine();
        }
        return externalPosition;
    }

    public static void ImportCurrentBoard()
    {
        CurrentBoard = new List<string>(Board.ProgramBoard);
        CurrentBoard.Insert(3, "\n");
        CurrentBoard.Insert(7, "\n");
        CurrentBoardString = string.Join("", CurrentBoard);
    }

    public static void IsItMyTurnYet()
    {
        // This is where it is decided if this bot acts as player 1 or 2
        MyTurn = Board.Player2Turn;

        if (MyTurn)
        {
            BlockOpponentWin();
        }
    }

    public static void BlockOpponentWin()
    {
        int emptySpot = 100;
        int k;

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
        // if the player who just put his mark, now has two in a row
        // anywhere on the board.
        for (int i = 0; i < 8; i++) // The "outer" array in Winners
        {
            for (int j = 0; j < 3; j++) // The "inner" array in Winners
            {
                k = 0;
                // If the first index in the inner array holds the players mark
                // we do the j++ and check the next index.
                if (Board.MarkerType == Board.ProgramBoard[winners[i, j]])
                {
                    k++;

                }
                else if (" " == Board.ProgramBoard[winners[i, j]])
                {
                    emptySpot = winners[i, j];
                    Console.WriteLine("BlockPos = {0}", emptySpot);
                }
                // If j reaches 2, it means that we have had 2 of the players
                // MarkerType on a winning row, STOP HIM!
                if (k == 2)
                {
                    // Make a move!
                    if (emptySpot != 100) PlacePiece(emptySpot);
                    break;
                }

            }
        }
        PlaceAtRandom();
    }

    public static void PlaceAtRandom()
    {
        int position = Board.ProgramBoard.IndexOf(" ");
        Console.WriteLine("RandomPos = {0}", position);
        PlacePiece(position);
    }

    public static void PlacePiece(int position)
    {
        KeyboardClass.AddPosition(TranslatePositions(position));
        Board.PlaceMarker(TranslatePositions(position));
    }

}
