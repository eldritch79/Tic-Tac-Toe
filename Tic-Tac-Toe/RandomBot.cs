using System;
// This is the stupid computer player using the bot template made by mrapan.
// Prepare to...win?
using System.Collections;
using System.Collections.Generic;

class RandomBot
{
    public static bool MyTurn { get; set; }
    public static List<string> CurrentBoard { get; set; }
    public static string CurrentBoardString { get; set; }

    public static void StartRandomBot()
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
