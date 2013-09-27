using System;
using System.Collections.Generic;
using System.Linq;

public class GameMechanics
{
    public static void Input()
    {
        if (!Board.GameOver)
        {
            string Player = Board.Player1Turn ? UserGreeting.Player2 : UserGreeting.Player1;
            Console.WriteLine("{0}, choose a position to place your {1}", Player, Board.MarkerType);
            string position = Console.ReadLine();
            Board.PlaceMarker(position.ToUpper());
        }
    }
}
