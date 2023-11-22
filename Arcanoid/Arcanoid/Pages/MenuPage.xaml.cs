using Arcanoid.Pages;
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
using Windows.UI.Core;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Arcanoid
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class MenuPage : Page
    {
        private MediaElement videoPlayer;
        private DispatcherTimer timer;
        private bool isUserActive;

        public MenuPage()
        {
            this.InitializeComponent();


            // Initialize and start the timer

            //InitializationTwoPointO();
            //timer = new DispatcherTimer();
            //timer.Interval = TimeSpan.FromSeconds(5);
            //timer.Tick += Timer_Tick;
            //timer.Start();
        }
        //public void OnPointerMoved(object sender, PointerRoutedEventArgs e)
        //{
        //    // Reset the timer on mouse movement
            
        //    InitializationOfTimer();

        //    if (!isUserActive)
        //    {
        //        // Show the buttons
        //        btnExit.Visibility = Visibility.Visible;
        //        btnOptions.Visibility = Visibility.Visible;
        //        btnShop.Visibility = Visibility.Visible;
        //        btnPlay.Visibility = Visibility.Visible;
        //        btnProfile.Visibility = Visibility.Visible;
        //        btnHelp.Visibility = Visibility.Visible;

        //        // Stop the video playback
        //        InitializationTwoPointO();
        //        videoPlayer.Visibility = Visibility.Collapsed;

        //        isUserActive = true;
        //    }
        //}


        //private void Timer_Tick(object sender, object e)
        //{
        //    isUserActive = false;
        //    timer.Stop();

        //    if (!isUserActive)
        //    {
        //        // Show the video
        //        videoPlayer.Visibility = Visibility.Visible;
                

        //        // Hide the buttons
        //        btnExit.Visibility = Visibility.Collapsed;
        //        btnOptions.Visibility = Visibility.Collapsed;
        //        btnShop.Visibility = Visibility.Collapsed;
        //        btnPlay.Visibility = Visibility.Collapsed;
        //        btnProfile.Visibility = Visibility.Collapsed;
        //        btnHelp.Visibility = Visibility.Collapsed;

        //        // Play the video
        //        videoPlayer.Play();
        //    }
            
            
        //}

        //private void InitializationTwoPointO()
        //{
        //    videoPlayer = new MediaElement();
        //    videoPlayer.AutoPlay = false;
        //    videoPlayer.Visibility = Visibility.Collapsed;
        //    videoPlayer.Source = new Uri("ms-appx:///911 GT2 RS _ Never Let Go Of Me (slowed, tiktok version) x NFS.mp4");
        //}
        //private void InitializationOfTimer()
        //{
        //    timer = new DispatcherTimer();
        //    timer.Interval = TimeSpan.FromSeconds(5);
        //    timer.Tick += Timer_Tick;
        //    timer.Start();
        //}






        //private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        //{
        //    if (!isUserActive)
        //    {
        //        timer.Start();
        //        videoPlayer.Stop();

        //    }
        //    isUserActive = true;
        //    // Show the buttons
        //    btnExit.Visibility = Visibility.Visible;
        //    btnOptions.Visibility = Visibility.Visible;
        //    btnShop.Visibility = Visibility.Visible;
        //    btnPlay.Visibility = Visibility.Visible;
        //    btnProfile.Visibility = Visibility.Visible;
        //    btnHelp.Visibility = Visibility.Visible;

        //    // Hide the video player
        //    videoPlayer.Visibility = Visibility.Collapsed;

        //    // Pause the video playback
        //    videoPlayer.Pause();
        //}




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
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // Check if the navigation parameter is a string
            if (e.Parameter is string message)
            {
                // Do something with the received message
                textBlock.Text =  message;
            }
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            ExitPopUp.Visibility = Visibility.Visible;
        }

        private void btnReturnClick(object sender, RoutedEventArgs e)
        {
            ExitPopUp.Visibility = Visibility.Collapsed;
        }

        private void btnQuitClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SignInUpPage));
        }

        private void btnLevelList_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LevelsPage));
        }
        private void btnOptions_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SettingsPage));
        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HelpPage));
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(GamePage));
        }
    }
}
    




