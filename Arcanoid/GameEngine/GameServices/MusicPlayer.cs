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
    public  class MusicPlayer
    {
        private static MediaPlayer _mediaplayer = new MediaPlayer();
        private static bool _isOn = false;
        private static double _volume = 100; // Initial volume

        public static bool IsOn
        {
            get { return _isOn; }
            set
            {
                _isOn = value;
                UpdatePlaybackState();
            }
        }

        public static double Volume
        {
            get { return _volume; }
            set
            {
                _volume = value;
                if (_mediaplayer != null)
                {
                    _mediaplayer.Volume = value / 100;
                }
            }
        }

        private static void UpdatePlaybackState()
        {
            if (_mediaplayer.PlaybackSession != null)
            {
                if (_isOn)
                {
                    _mediaplayer.Play();
                }
                else
                {
                    _mediaplayer.Pause();
                }
            }
        }

        public static void Play(string fileName)
        {
            _mediaplayer.IsLoopingEnabled = true;
            _mediaplayer.Source = MediaSource.CreateFromUri(new Uri($"ms-appx:///Assets/Music/{fileName}"));

            if (_mediaplayer.PlaybackSession != null && _mediaplayer.PlaybackSession.PlaybackState == MediaPlaybackState.Playing)
            {
                // If music is already playing, update the playback state
                UpdatePlaybackState();
            }
            else if (_isOn)
            {
                // Start playing only if the IsOn flag is true
                _mediaplayer.Play();
            }
        }

        public static void Stop()
        {
            _isOn = false;
            _mediaplayer.Pause();
        }

        public static void ChangeVolume(double volume)
        {
            _volume = volume * 100;
            if (_mediaplayer != null)
            {
                _mediaplayer.Volume = volume;
            }
        }
    }

}
