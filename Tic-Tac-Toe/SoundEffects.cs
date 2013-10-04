using System;
using System.Media;

class SoundEffect
{
    public static void PlaySound()
    {
        string path = System.Environment.CurrentDirectory;
        string path2 = path.Substring(0, path.LastIndexOf("bin")) + "SoundFiles" + "//playgame.wav";

        Console.WriteLine("Welcome to a wonderful game of Tic-Tac-Toe!\n");

       using (SoundPlayer player = new SoundPlayer (path2))
        {
            player.PlaySync();
        }
    }
}
