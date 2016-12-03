using System;
using System.Net;
using System.ServiceModel.Web;
using System.Windows;
using GameStore.REST.JSONs;
using GameStore.WPF.LoginService;

namespace GameStore.WPF
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

            int userId = -1;
            try
            {
                userId = loginClient.Login(json);
            }
            catch (WebFaultException exception)
            {
                if (exception.StatusCode == HttpStatusCode.Unauthorized)
                {
                    LoginFailedLabel.Visibility = Visibility.Visible;
                }
            }

            // TODO
            Console.Out.Write(userId);
        }
    }
}
