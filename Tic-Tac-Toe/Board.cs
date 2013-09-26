using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Board
{
    public static List<string> _theBoard = new List<string>();
    public static bool Player1Turn { get; set; }
    public static string MarkerType { get; set; }

    public static void CreateBoard()
    {
        _theBoard.AddRange(new[] { " ", "  ", "1", " ", "2", " ", "3", " ", "\n" });
        _theBoard.AddRange(new[] { " ", "+", "-", "+", "-", "+", "-", "+", "\n" });
        _theBoard.AddRange(new[] { "A", "|", " ", "|", " ", "|", " ", "|", "\n" });
        _theBoard.AddRange(new[] { " ", "+", "-", "+", "-", "+", "-", "+", "\n" });
        _theBoard.AddRange(new[] { "B", "|", " ", "|", " ", "|", " ", "|", "\n" });
        _theBoard.AddRange(new[] { " ", "+", "-", "+", "-", "+", "-", "+", "\n" });
        _theBoard.AddRange(new[] { "C", "|", " ", "|", " ", "|", " ", "|", "\n" });
        _theBoard.AddRange(new[] { " ", "+", "-", "+", "-", "+", "-", "+", "\n" });
        Console.WriteLine(string.Join(" ", _theBoard));
        MarkerType = "X";
    }

    // Method will take an input, i.e. A2, B3 ...

    public static int PositionTable(string position)
    {
        // Create a hashtable with the positions of the fields
        // where a player may put his/hers mark 
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

        int realPosition = (int)positionOfSquares[position.ToUpper()];
        return realPosition;

    }

    public static void PlaceMarker(string position)
    {

        // Translate Xn to actual index position in list _theBoard
        int positionToPlaceMarker = PositionTable(position);

        // Remove existing empty space and replace with marker X or O.
        _theBoard.RemoveAt(positionToPlaceMarker);
        _theBoard.Insert(positionToPlaceMarker, MarkerType);
        Console.Clear();
        Console.WriteLine(string.Join(" ", _theBoard));
        Winner();
        SwitchPlayer();
    }

    public static void SwitchPlayer()
    {
        // Changes the marker X/O depending on player turn.
        MarkerType = Player1Turn ? "X" : "O";

        Player1Turn = !Player1Turn;
        GameMechanics.Input();
    }

    public static void Winner()
    {
        string A1 = _theBoard[20];
        string A2 = _theBoard[22];
        string A3 = _theBoard[24];

        string B1 = _theBoard[38];
        string B2 = _theBoard[40];
        string B3 = _theBoard[42];

        string C1 = _theBoard[56];
        string C2 = _theBoard[58];
        string C3 = _theBoard[60];

        // Possible winning combinations
        string aTop = A1 + A2 + A3;
        string bMiddle = B1 + B2 + B3;
        string cBottom = C1 + C2 + C3;
        string IVertical = A1 + B1 + C1;
        string IIVertical = A2 + B2 + C2;
        string IIIVertical = A3 + B3 + C3;
        string aDiagonal = A1 + B2 + C3;
        string cDiagonal = C1 + B2 + A3;
        
        // Ugly fix to get the work done temporarily
        if (aTop.Distinct().Count() == 1 && !aTop.Contains(" ")|| bMiddle.Distinct().Count() == 1 && !bMiddle.Contains(" ")|| cBottom.Distinct().Count() == 1 && !cBottom.Contains(" "))
        {
            AnnounceWinner("horizontal");
        }
        else if (IVertical.Distinct().Count() == 1 && !IVertical.Contains(" ")|| IIVertical.Distinct().Count() == 1 && !IIVertical.Contains(" ")||
                 IIIVertical.Distinct().Count() == 1 && !IIIVertical.Contains(" "))
        {
            AnnounceWinner("vertical");
        }
        else if (aDiagonal.Distinct().Count() == 1 && !aDiagonal.Contains(" ")|| cDiagonal.Distinct().Count() == 1 && !cDiagonal.Contains(" "))
        {
            AnnounceWinner("diagonal");
        }
    }

    public static void AnnounceWinner(string winType)
    {
        Console.WriteLine("YAY!!! {0} won with three in a row in a {1} line!", Player1Turn ? "Player2" : "Player1", winType);
    }
}

