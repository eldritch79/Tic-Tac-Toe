using System;
using System.Media;

class SoundEffect
{
    public static void PlaySound()
    {
        string path = System.Environment.CurrentDirectory;
        string path2 = path.Substring(0, path.LastIndexOf("bin")) + "SoundFiles" + "//playgame.wav";

       using (SoundPlayer player = new SoundPlayer (path2))
        {
            player.PlaySync();
        }
    }
}
