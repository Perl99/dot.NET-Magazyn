using System.ServiceModel.Security;
using System.Windows;
using GameStore.REST.JSONs;
using GameStore.WPF.Services;

namespace GameStore.WPF.Windows
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginServiceClient loginClient = new LoginServiceClient("LoginEndpoint");

            LoginJson json = new LoginJson
            {
                Login = LoginTextBox.Text,
                Password = PasswordBox.Password
            };

            try
            {
                LoginFailedLabel.Visibility = Visibility.Hidden;

                loginClient.Login(json);

                var productList = new ProductList();
                productList.Show();
                Close();
            }
            catch (MessageSecurityException)
            {
                LoginFailedLabel.Visibility = Visibility.Visible;
            }
        }
    }
}
