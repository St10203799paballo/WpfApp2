using System;
using System.Collections.Generic;
using System.Linq;
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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Window
    {
        private NavigationService navigationService;
        private Dictionary<string, string> userAccounts = new Dictionary<string, string>();
        public login()
        {
            InitializeComponent();
            this.navigationService = NavigationService.GetNavigationService(this);
        }

        private void modules_Click(object sender, RoutedEventArgs e)
        {
            string username = LoginUsername.Text;
            string password = LoginPassword.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username and password are required.");
                return;
            }

            if (userAccounts.TryGetValue(username, out string storedPassword) && VerifyPassword(password, storedPassword))
            {
                MessageBox.Show("Login successful.");
            }
            else
            {
                MessageBox.Show("Login failed. Please check your credentials.");
            }
            if (IsLoginSuccessful()) 
            {
                Registration registrationWindow = new Registration();
                registrationWindow.Show();
                this.Close(); 
            }

        }
            private void NavigateToLogin(object sender, RoutedEventArgs e)
            {
                navigationService.Navigate(new Uri("Registration.xaml", UriKind.Relative));
            }
        private string HashPassword(string password)
        {
            
            return password;
        }

        private bool VerifyPassword(string inputPassword, string hashedPassword)
        {
            
            return inputPassword == hashedPassword;
        }
        private bool IsLoginSuccessful()
        {
           
            return true; 
        }



    }
}
