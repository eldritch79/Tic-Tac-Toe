using System;

class UserGreeting
{
    public static string Player1{ get; set; }
    public static string Player2{ get; set; }
    public static void userInputName()
    {
        Console.WriteLine("Please enter the name of player one: ");
        Player1 = Console.ReadLine();
        Console.WriteLine("Please enter the name of player two: ");
        Player2 = Console.ReadLine();
        Console.Clear();
    }
}
