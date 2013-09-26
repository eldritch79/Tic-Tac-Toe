using System;
using System.Collections.Generic;
using System.Linq;

public class GameMechanics
{
    public static void Input()
    {
        string Player = Board.Player1Turn ? "Player 2" : "Player 1";
        Console.WriteLine("{0} Choose a position to place your {1}", Player, Board.MarkerType);
        string position = Console.ReadLine();
        Board.PlaceMarker(position.ToUpper());
    }
}
