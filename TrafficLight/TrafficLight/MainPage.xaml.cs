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
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TrafficLight
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private SolidColorBrush redBrush;
        private SolidColorBrush yellowBrush;
        private SolidColorBrush greenBrush;
        private int currentLightIndex;
        public MainPage()
        {
            this.InitializeComponent();
            redBrush = new SolidColorBrush(Windows.UI.Colors.DarkRed);
            yellowBrush = new SolidColorBrush(Windows.UI.Colors.DarkOrange);
            greenBrush = new SolidColorBrush(Windows.UI.Colors.DarkGreen);

            currentLightIndex = 0; // Start with red light
        }

        private void btnManual_Click(object sender, RoutedEventArgs e)
        {
            // Get the current color of the traffic light
            SolidColorBrush redBrush = new SolidColorBrush(Windows.UI.Colors.DarkRed);
            SolidColorBrush yellowBrush = new SolidColorBrush(Windows.UI.Colors.Yellow);
            SolidColorBrush greenBrush = new SolidColorBrush(Windows.UI.Colors.Green);

            SolidColorBrush currentRedBrush = (SolidColorBrush)elpRed.Fill;
            SolidColorBrush currentYellowBrush = (SolidColorBrush)elpYellow.Fill;
            SolidColorBrush currentGreenBrush = (SolidColorBrush)elpGreen.Fill;

            if (currentRedBrush.Color == redBrush.Color)
            {
                // Change to yellow
                elpRed.Fill = new SolidColorBrush(Windows.UI.Colors.Gray);
                elpYellow.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                elpGreen.Fill = new SolidColorBrush(Windows.UI.Colors.Gray);
            }
            else if (currentYellowBrush.Color == yellowBrush.Color)
            {
                // Change to green
                elpRed.Fill = new SolidColorBrush(Windows.UI.Colors.Gray);
                elpYellow.Fill = new SolidColorBrush(Windows.UI.Colors.Gray);
                elpGreen.Fill = new SolidColorBrush(Windows.UI.Colors.Green);
            }
            else
            {
                // Change back to red
                elpRed.Fill = new SolidColorBrush(Windows.UI.Colors.DarkRed);
                elpYellow.Fill = new SolidColorBrush(Windows.UI.Colors.Gray);
                elpGreen.Fill = new SolidColorBrush(Windows.UI.Colors.Gray);
            }
        }
        private async void btnAuto_Click(object sender, RoutedEventArgs e)
        {
            await Task.Delay(3000);
            SetLightColor(1);

            // Change to green after 3 seconds
            await Task.Delay(3000);
            SetLightColor(2);

            // Change back to red after 3 seconds
            await Task.Delay(3000);
            SetLightColor(0);
        }
        private void SetLightColor(int lightIndex)
        {
            // Reset all lights to gray
            elpRed.Fill = new SolidColorBrush(Windows.UI.Colors.Gray);
            elpYellow.Fill = new SolidColorBrush(Windows.UI.Colors.Gray);
            elpGreen.Fill = new SolidColorBrush(Windows.UI.Colors.Gray);

            // Set the appropriate light to its color
            switch (lightIndex)
            {
                case 0: // Red
                    elpRed.Fill = redBrush;
                    break;
                case 1: // Yellow
                    elpYellow.Fill = yellowBrush;
                    break;
                case 2: // Green
                    elpGreen.Fill = greenBrush;
                    break;
                default:
                    break;
            }
        }

        // Other event handlers and methods can go here...
    }
}

