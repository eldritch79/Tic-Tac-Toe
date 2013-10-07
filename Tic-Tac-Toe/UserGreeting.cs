using System;

class UserGreeting
{
    public static int Player1Wins {get;set;} // initializes the scoreboards
    public static int Player2Wins { get; set; }
    public static string Player1{ get; set; }
    public static string Player2{ get; set; }

    public static void PvpOrPve()
    {
        string welcome = "";
        welcome += "\nWould you like to play against a friend or dare you\n";
        welcome += "take on one of our superintelligent bots?\n";
        Console.WriteLine(welcome);

        string choices = "";
        choices += "1. Play against a friend. Warning! This may end friendship.\n";
        choices += "2. Play against Emils bot.\n"; // Replace with the name of Emils murderbot, add personal taunt.
        choices += "3. Play against Johans bot.\n"; // Replace with the name of Johans deathbot, add personal taunt.
        choices += "4. Play against MonkeyBot. Can you beat a monkey?\n";
        choices += "5. Play against Pauls bot.\n"; // Replace with the name of Pauls exterminatorbot, add personal taunt.
        Console.WriteLine(choices);

        int userChoice;
        bool isNum = int.TryParse(Console.ReadLine(), out userChoice);
        Console.WriteLine(isNum);
        // Make sure the user typed an int, if TryParse fails, this takes user back to beginning of method.
        if (!isNum) PvpOrPve();

        switch (userChoice)
        {
            case 1:
                Program.InitiatePvpSession();
                break;
            case 2:
                Player2 = "Emils"; // Input name of your bot here
                Program.InitiateBotSession("Emil");
                break;
            case 3:
                Player2 = "Johans"; // Input name of your bot here
                Console.WriteLine("This is not the droid you are looking for.");    
                 // Program.InitiateBotSession("Johan");
                break;
            case 4:
                Player2 = "MonkeyBot";
                Program.InitiateBotSession("Linus");
                break;
            case 5:
                Player2 = "RandomBot"; // Input name of your bot here
                Program.InitiateBotSession("Paul");
                break;
            default:
                PvpOrPve();
                break;
        }
    }

    // This method collects the names when two players compete against eachother.
    public static void UserInputName(bool pvp)
    {
        Console.WriteLine("Please enter the name of player one: ");
        Player1 = Console.ReadLine();
        if (pvp)
        {
            Console.WriteLine("Please enter the name of player two: ");
            Player2 = Console.ReadLine();
        }
        Console.Clear();
    }
}
