using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Xaml.Media.Animation;

namespace GameEngine.GameServices
{
    static public class MusicPlayer
    {
        public static MediaPlayer _mediaplayer = new MediaPlayer();
        public static bool isOn { get; set; } = false;

        public static void Play(string fileName)
        {
            isOn = true;
            _mediaplayer.IsLoopingEnabled = true;
            _mediaplayer.Source = MediaSource.CreateFromUri(new Uri($"ms-appx:///Assets/Music/{fileName}"));
            _mediaplayer.Play();
        }

        public static void Stop()
        {
            isOn = false;
            _mediaplayer.Pause();
        }

        public static void ChangeVolume(double volume) 
        {
                _mediaplayer.Volume = volume/100;
        }
    }
}
