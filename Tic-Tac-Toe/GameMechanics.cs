using System;
using System.Collections.Generic;
using System.Linq;

public class GameMechanics
{
    public static void Input()
    {
        //string Player1 = Class1.Player1;
        //string Player2 = Class1.Player2;
        string Player = Board.Player1Turn ? UserGreeting.Player2 : UserGreeting.Player1;
        Console.WriteLine("{0}, choose a position to place your {1}", Player, Board.MarkerType);
        string position = Console.ReadLine();
        Board.PlaceMarker(position.ToUpper());
    }
}
