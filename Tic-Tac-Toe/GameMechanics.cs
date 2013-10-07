using System;
using System.Linq;

public class GameMechanics

{
    public static bool XStarts {get;set;}
    public static ConsoleKeyInfo key;
    // Check if GameOver is false - start next round, or true - end game.
    public  GameMechanics(){
        XStarts = true;

    }
    public static void TypeOfInput(string opponent)
    {
        if (!Board.GameOver) NextRound(opponent);
        else GameOver();
    }
    
    public static void NextRound(string opponent)
    {
        string Opponent = opponent;
        Board.MarkerType = Board.Player2Turn ? "O" : "X";
        string[] acceptableInput = {"A1", "A2", "A3", "B1", "B2", "B3", "C1", "C2", "C3"};
        string Player = Board.Player2Turn ? UserGreeting.Player2 : UserGreeting.Player1;
        
            string positionYourPiece = "Player " + Player + 
                                        ", choose (with the arrow keys) a position to place your " + 
                                        Board.MarkerType + ":";
        
        // If this game is pvp mode, output message to both players
        if (opponent == "pvp")
        {
            Console.WriteLine(positionYourPiece);
        }

        // If this game is bot mode, only output this message when it's the users turn.
        if (!Board.Player2Turn && opponent != "pvp")
        {
            Console.WriteLine(positionYourPiece);
        }

        //string position = Console.ReadLine().ToUpper();

        //if the key we press isn't Enter keep going
        //and only do this if not player 2
        if(!Board.Player2Turn){
        
            do
            {
                key = Console.ReadKey();
                KeyboardClass.MoveMarker(key);//sends the pressed key into the class
                //Console.WriteLine("we are in! " + KeyboardClass.getMarkerPosition());

            } while (key.Key != ConsoleKey.Enter);
        //when Enter is pressed we continue down the code
        }

        //the position is fetched from keyboard class
        string position = KeyboardClass.getMarkerPosition();
        // If the user input is not a valid position he/she will be informed
        // and asked to choose another position.
        if (acceptableInput.Contains(position))
        {
            //if the position is accepted we add that position to a list 
            //so we know what not to replace when moving around the marker
            KeyboardClass.AddPosition(position);
            if (KeyboardClass.list.Count == 9)
            {
                Console.WriteLine("It's a draw!");
                GameOver();
            }
            Board.PlaceMarker(position.ToUpper());
        }
        else
        {
            Console.WriteLine("The position does not exist.");
            NextRound(Opponent);
        }
    }

    public static void GameOver()
    {
        Console.WriteLine("Would you like to start a new game? YES / NO");
        string playAgain = Console.ReadLine();
        playAgain = playAgain.ToUpper();
        if (playAgain == "YES" || playAgain == "Y")
        {
            //clear list of stored positions not to replace with marker when start new game
            EmkesBot.ResetList();
            KeyboardClass.ClearList();
            Board.GameOver = false;
            Program.StartNextGame();  
        }
        else
        {
            Board.GameOver = true;
            Console.WriteLine("I'm sorry to see you go. Global Thermonuclear War initiated.\nHave a nice day!");
        }

    }
}
