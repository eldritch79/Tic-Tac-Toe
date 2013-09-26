using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

public class Board
{
    public static List<string> _theBoard = new List<string>();
    public static bool Player1Turn { get; set; }
    public static string markerType { get; set; }

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
        markerType = "X";
    }

    // Method will take an input, i.e. A2, B3 ...

    public static int PositionTable(string position)
    {
        // Create a hashtable with the positions of the fields
        // where a player may put his/hers mark 
        Hashtable positionOfSquares = new Hashtable();

        positionOfSquares.Add("A1", 20);
        positionOfSquares.Add("A2", 22);
        positionOfSquares.Add("A3", 24);

        positionOfSquares.Add("B1", 38);
        positionOfSquares.Add("B2", 40);
        positionOfSquares.Add("B3", 42);

        positionOfSquares.Add("C1", 56);
        positionOfSquares.Add("C2", 58);
        positionOfSquares.Add("C3", 60);

        int realPosition = (int)positionOfSquares[position.ToUpper()];
        return realPosition;

    }

    public static void PlaceMarker(string position)
    {

        // Translate Xn to actual index position in list _theBoard
        int positionToPlaceMarker = PositionTable(position);

        // Remove existing empty space and replace with marker X or O.
        _theBoard.RemoveAt(positionToPlaceMarker);
        _theBoard.Insert(positionToPlaceMarker, markerType);
        Console.Clear();
        Console.WriteLine(string.Join(" ", _theBoard));
        Winner();
        SwitchPlayer();
    }

    public static void SwitchPlayer()
    {
        // Changes the marker X/O depending on player turn.
        markerType = Player1Turn ? "X" : "O";

        Player1Turn = !Player1Turn;
        GameMechanics.Input();
    }

    public static void Winner()
    {
        string A1, A2, A3, B1, B2, B3, C1, C2, C3;
        A1 = _theBoard[20];
        A2 = _theBoard[22];
        A3 = _theBoard[24];

        B1 = _theBoard[38];
        B2 = _theBoard[40];
        B3 = _theBoard[42];

        C1 = _theBoard[56];
        C2 = _theBoard[58];
        C3 = _theBoard[60];

        // Possible winning combinations
        string aTop = A1 + A2 + A3;
        string bMiddle = B1 + B2 + B3;
        string cBottom = C1 + C2 + C3;
        string IVertical = A1 + B1 + C1;
        string IIVertical = A2 + B2 + C2;
        string IIIVertical = A3 + B3 + C3;
        string aDiagonal = A1 + B2 + C3;
        string cDiagonal = C1 + B2 + A3;
        
        // Atm the first player always wins, there's three empty spaces in a row everywhere ...
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

