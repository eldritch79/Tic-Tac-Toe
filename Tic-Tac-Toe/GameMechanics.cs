using System;

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
        else
        {
            Console.Clear();
            Console.WriteLine("Would you like to start a new game? YES / NO");
            string playAgain = Console.ReadLine();
            playAgain += playAgain.ToUpper();
            if (playAgain == "yes")
            {
                Program.StartNewGame();
            }
            else
            {
                Console.WriteLine("You SUCK");
            }
        }
    }
}
