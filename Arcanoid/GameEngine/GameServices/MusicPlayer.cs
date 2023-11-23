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
    public static class MusicPlayer
    {

        private static MediaPlayer _BackgroundMusic;
        public static bool IsPlaying { get; set; } = true;
        public static double Volume { get; set; } = 70;

        public static void LoadMusicPlayer(string filename)
        {
            _BackgroundMusic = new MediaPlayer();
            _BackgroundMusic.Volume = Volume;
            _BackgroundMusic.AutoPlay = true;
            _BackgroundMusic.IsLoopingEnabled = true;
            _BackgroundMusic.Source = MediaSource.CreateFromUri(new Uri($"ms-appx:///Assets/Music/{filename}.mp3"));
        }
        public static void Play()
        {
            IsPlaying = true;
            _BackgroundMusic.Play();
        }
        public static void Pause()
        {
            IsPlaying = false;
            _BackgroundMusic.Pause();
        }
        public static void ChangeVolume(double volume)
        {
            Volume = volume;
            _BackgroundMusic.Volume = volume / 100;
        }
    }

}
