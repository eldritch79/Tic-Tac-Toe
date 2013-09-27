using System;
using System.Collections.Generic;
using System.Linq;


class Program
{
    static void Main()
    {
        UserGreeting.userInputName();
        Board.CreateVisualBoard();
        Board.CreateProgramBoard();
        GameMechanics.Input();
//        Board.PlaceMarker("B2");
//        Board.PlaceMarker("A1");
//        Board.PlaceMarker("C3");
//        Board.PlaceMarker("A3");
    }
}

