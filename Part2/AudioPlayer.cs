using System;
using System.IO;
using System.Media;
using System.Windows;

namespace Part2
{
    public class AudioPlayer
    {
        public static void PlayGreeting()
        {
            try
            {
                SoundPlayer player = new SoundPlayer(Part2.Properties.Resources.Greeting);
                player.Play();
            }
            catch
            {
                MessageBox.Show("Error playing audio.");
            }
        }
    }
}
