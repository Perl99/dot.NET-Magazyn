using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
            LoginServiceClient loginClient = new LoginServiceClient();

            LoginJson json = new LoginJson
            {
                Login = LoginTextBox.Text,
                Password = PasswordBox.Password
            };

            try
            {
                int userId = loginClient.Login(json);
            }
            catch (WebFaultException exception)
            {
                if (exception.StatusCode == HttpStatusCode.Unauthorized)
                {
                    LoginFailedLabel.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
