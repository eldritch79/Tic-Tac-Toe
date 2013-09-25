using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

public class Board
{
    public static List<string> _theBoard = new List<string>();

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

    // X horizontal, Y vertical
    public static void PlaceMarker(string positionX, string positionY)
    {

    }

}

