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
using TrafficLights.Objects;

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
        private  TrafficL _trafficlight;
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
            _trafficlight.SetState();
            
        }
        private async void btnAuto_Click(object sender, RoutedEventArgs e)
        {
            _trafficlight.IsAuto = !_trafficlight.IsAuto;
            if (_trafficlight.IsAuto)//כך משנים כתוביות ללחצן
                btnAuto.Content = "Stop";
            else
                btnAuto.Content = "Auto";
            btnManual.IsEnabled = !_trafficlight.IsAuto;
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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _trafficlight = new TrafficL(elpRed, elpYellow, elpGreen);  
        }
    }
}

