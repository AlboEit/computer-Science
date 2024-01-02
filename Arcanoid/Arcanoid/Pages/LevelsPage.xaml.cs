using DataBase.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel.Channels;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Arcanoid.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LevelsPage : Page
    {
        public static Level level = new Level();
        public LevelsPage()
        {
            this.InitializeComponent();
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (sender is Image tappedImage)
            {
                string strForMessage = tappedImage.Name.Substring(3);
                int number = Convert.ToInt32(strForMessage);
                
                switch (number)
                {
                    case 4:
                        level.BarWidth = 100;
                        level.BallSpeed = 2;
                        level.CountPinkJelly = 20;
                        level.CountYellowJelly = 10;
                        level.CountGreenJelly = 0;
                        break;
                    case 3:
                        level.BarWidth = 200;
                        level.BallSpeed = 1.5;
                        level.CountPinkJelly = 15;
                        level.CountYellowJelly = 10;
                        level.CountGreenJelly = 5;
                        break;
                    case 2:
                        level.BarWidth = 250;
                        level.BallSpeed = 1;
                        level.CountPinkJelly = 0;
                        level.CountYellowJelly = 20;
                        level.CountGreenJelly = 10;
                        break;
                    case 1:
                        level.BarWidth = 400;
                        level.BallSpeed = 0.5;
                        level.CountPinkJelly = 0;
                        level.CountYellowJelly = 0;
                        level.CountGreenJelly = 30;
                        break;
                }

                Frame.Navigate(typeof(GamePage));
            }
        }
    }
}
