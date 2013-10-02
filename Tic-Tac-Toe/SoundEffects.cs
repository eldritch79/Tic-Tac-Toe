using System;
using System.Media;
using System.IO;
using System.Reflection;

class SoundEffect
{
    public static void PlaySound()
    {
        string path = System.Environment.CurrentDirectory;
        string path2 = path.Substring(0, path.LastIndexOf("bin")) + "SoundFiles" + "//playgame.wav";

        using (SoundPlayer player = new SoundPlayer (@"playgame.wav"))
        {
            player.PlaySync();
        }
    }
}
