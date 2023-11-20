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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Arcanoid.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HelpPage : Page
    {
        public HelpPage()
        {
            this.InitializeComponent();
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
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MenuPage));
        }
    }
}
