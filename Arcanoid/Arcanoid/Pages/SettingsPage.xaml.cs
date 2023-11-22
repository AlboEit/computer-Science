using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.Media.Playback;
using Windows.Media.Core;
using GameEngine.GameServices;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Arcanoid.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        MediaPlayer player;
        bool playing;
        public SettingsPage()
        {
            this.InitializeComponent();
            player = new MediaPlayer(); 
            playing = false;


        }
        private void SettingsPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            // This method is called when the SettingsPage is loaded

            // Set the state as needed
            GameEngine.GameServices.MusicPlayer.IsOn = true;

            // Play music only if IsOn is true
            if (GameEngine.GameServices.MusicPlayer.IsOn)
            {
                GameEngine.GameServices.MusicPlayer.Play("YourMusicFileName.mp3");
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MenuPage));

        }
        private void btnPointerEntered(object sender, PointerRoutedEventArgs e)
        {
            // Change the image source when hovering over the button
            if (sender is Button button)
            {
                string imageName = button.Name.Substring(3);
                Image image = button.Content as Image;
                if (image != null)
                {
                    image.Source = new BitmapImage(new Uri($"ms-appx:///Assets/Buttons/{imageName} (2).png"));
                    Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
                }
            }
        }

        private void btnPointerExited(object sender, PointerRoutedEventArgs e)
        {
            // Restore the original image source when exiting the hover state
            if (sender is Button button)
            {
                string imageName = button.Name.Substring(3);
                Image image = button.Content as Image;
                if (image != null)
                {
                    image.Source = new BitmapImage(new Uri($"ms-appx:///Assets/Buttons/{imageName} (1).png"));
                    Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
                }
            }
        }
        private void VolumeSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (player != null)
            {
                // Adjust the volume based on the slider value
                MusicPlayer.ChangeVolume(VolumeSlider.Value / 100);
            }
        }



        //private async void PlayPauseButton_Click(object sender, RoutedEventArgs e)
        //{
        //    Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
        //    Windows.Storage.StorageFile file = await folder.GetFileAsync("Kahoot Phonk theme song 1 Hour [FULL VERSION, Looped].mp3");

        //    player.AutoPlay = false;
        //    player.Source = MediaSource.CreateFromStorageFile(file);

        //    if (playing)
        //    {
        //        player.Source = null;
        //        playing = false;

        //    }
        //    else { 
        //        player.Play(); 
        //        playing = true; 
        //    }

        //}

        private void MusicToggle_Toggled(object sender, RoutedEventArgs e)
        {
            MusicPlayer.IsOn = MusicToggle.IsOn;

            if (MusicToggle.IsOn)
            {
                MusicPlayer.Play("Kahoot Phonk theme song 1 Hour [FULL VERSION, Looped].mp3");
            }
            else
            {
                MusicPlayer.Stop();
            }
        }


        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
           

            // Save the state before navigating away
            SaveState();
            base.OnNavigatedFrom(e);
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // Restore the state when navigating back
            RestoreState();

          
        }


        private void SaveState()
        {
            // Save the MusicPlayer state, e.g., IsOn and Volume
            // You may use local settings, session state, or other storage mechanisms
            // For simplicity, let's use ApplicationData.LocalSettings in this example

            Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

            // Save IsOn state
            localSettings.Values["MusicPlayerIsOn"] = MusicPlayer.IsOn;

            // Save Volume state
            localSettings.Values["MusicPlayerVolume"] = MusicPlayer.Volume;
        }

        private void RestoreState()
        {
            // Restore the MusicPlayer state
            // Use the same storage mechanism as in SaveState()

            Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

            // Restore IsOn state
            if (localSettings.Values.ContainsKey("MusicPlayerIsOn"))
            {
                MusicPlayer.IsOn = (bool)localSettings.Values["MusicPlayerIsOn"];
            }

            // Restore Volume state
            if (localSettings.Values.ContainsKey("MusicPlayerVolume"))
            {
                MusicPlayer.Volume = (double)localSettings.Values["MusicPlayerVolume"];
            }

            // Update the UI based on the restored state
            MusicToggle.IsOn = MusicPlayer.IsOn;
            VolumeSlider.Value = MusicPlayer.Volume;
        }

    }
}
