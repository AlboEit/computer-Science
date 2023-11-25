using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Core;
using Windows.Media.Playback;

namespace GameEngine.GameServices
{
    public class SoundsPlayer
    {
        public static MediaPlayer _mediaPlayer = new MediaPlayer();
        public static bool IsOn { get; set; } = false;

        public static void Play(string Filename) 
        {
            if (IsOn)
            {
                _mediaPlayer.Source = MediaSource.CreateFromUri(new Uri($"ms-appx:///Assets/Sounds/{Filename}"));
                _mediaPlayer.Play();
            }
        }
        public static void Stop()
        {
            _mediaPlayer.Pause();
        }
    }
}
