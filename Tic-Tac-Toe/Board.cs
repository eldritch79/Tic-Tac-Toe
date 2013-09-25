using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

public class Board
{
    public static List<string> _theBoard = new List<string>();
    public static bool Player1Turn { get; set; }

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

        int realPosition = (int) positionOfSquares[position];
        return realPosition;

    }

    public static void PlaceMarker(string position)
    {
        string markerType;


        // Translate Xn to actual index position in list _theBoard
        int positionToPlaceMarker = PositionTable(position);

        // Changes the marker X/O depending on player turn.
        markerType = Player1Turn ? "X" : "O";

        // Remove existing empty space and replace with marker X or O.
        _theBoard.RemoveAt(positionToPlaceMarker);
        _theBoard.Insert(positionToPlaceMarker, markerType);
        Console.Clear();
        Console.WriteLine(string.Join(" ", _theBoard));
        SwitchPlayer();
    }

    public static void SwitchPlayer()
    {
        Player1Turn = !Player1Turn;
    }
}

