﻿using System;
using System.Linq;

public class GameMechanics
{
    public static ConsoleKeyInfo key;
    // Check if GameOver is false - start next round, or true - end game.
    public static void TypeOfInput()
    {
        if (!Board.GameOver) NextRound();
        else GameOver();
    }
    
    public static void NextRound()
    {
        Board.MarkerType = Board.Player1Turn ? "O" : "X";
        string[] acceptableInput = {"A1", "A2", "A3", "B1", "B2", "B3", "C1", "C2", "C3"};
        string Player = Board.Player1Turn ? UserGreeting.Player2 : UserGreeting.Player1;
        Console.WriteLine("Player {0}, choose a position to place your {1}:", Player, Board.MarkerType);
        //string position = Console.ReadLine().ToUpper();

        do
        {
            key = Console.ReadKey();
            KeyboardClass.MoveMarker(key);
            Console.WriteLine("we are in! " + KeyboardClass.getMarkerPosition());

        } while (key.Key != ConsoleKey.Enter);
        string position = KeyboardClass.getMarkerPosition();
        // If the user input is not a valid position he/she will be informed
        // and asked to choose another position.
        if (acceptableInput.Contains(position))
        {
            KeyboardClass.AddPosition(position);
            Board.PlaceMarker(position.ToUpper());
        }
        else
        {
            Console.WriteLine("The position does not exist.");
            NextRound();
        }
    }

    public static void GameOver()
    {
        Console.WriteLine("Would you like to start a new game? YES / NO");
        string playAgain = Console.ReadLine();
        playAgain = playAgain.ToUpper();
        if (playAgain == "YES" || playAgain == "Y")
        {
            Board.GameOver = false;
            Program.StartNextGame();  
        }
        else
        {
            Console.WriteLine("I'm sorry to see you go. Global Thermonuclear War initiated.\nHave a nice day!");
        }

    }
}
