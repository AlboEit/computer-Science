using Windows.UI.Xaml.Controls;

namespace Arcanoid
{
    public sealed partial class ConfirmationPage : Page
    {
        public ConfirmationPage()
        {
            this.InitializeComponent();
        }

        private void btnYes_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            // Close the confirmation window and exit the application
            App.Current.Exit();
        }

        private void btnNo_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            // Close the confirmation window and return to the MenuPage
            Frame.GoBack();
        }
    }
}
