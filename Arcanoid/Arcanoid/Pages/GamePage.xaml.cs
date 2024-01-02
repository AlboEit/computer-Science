using Arcanoid.GameServices;
using GameEngine.GameServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Arcanoid.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage : Page
    {
        private int _score;


        public int Score
        {
            get { return _score; }
            set
            {
                _score = value;
                // Update the UI or perform other actions when the score changes
                txtScore.Text = $"Score: {_score}";
            }
        }
        private GameManager _gameManager;
        public GamePage()
        {
            this.InitializeComponent();
            Manager.GameEvent.OnWin += OnWin;
        }

        private void OnWin(int brickcount)
        {
            if (brickcount <= 0)
            {
                GameWonPopUp.Visibility= Visibility.Visible;
            }
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
        

        private void UpdateScore(int score)
        {
            // Handle the score update here if needed
            // For example, you can update the UI or perform other actions
            Score = score;
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

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MenuPage));
        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HelpPage));
        }
        private void addScore() 
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _gameManager = new GameManager(scene);
            _gameManager.Start();
            Manager.GameEvent.OnRemoveHeart += RemoveHeart;
            // Subscribe to the OnUpdateScore event
            Manager.GameEvent.OnUpdateScore += UpdateScore;
        }

        private void RemoveHeart(int lifes)
        {
           Image[] hearts = new Image[3];
            hearts[0] = Heart1;
            hearts[1] = Heart2;
            hearts[2] = Heart3;
            if (lifes > 0)
            {
                hearts[lifes].Visibility = Visibility.Collapsed;
            }
            else
            {
                GameLostPopUp.Visibility = Visibility.Visible;
            }
        }

        private void ButtonReturn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MenuPage));
        }
    }
}
