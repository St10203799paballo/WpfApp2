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
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        private NavigationService navigationService;
        private Dictionary<string, string> userAccounts = new Dictionary<string, string>();
        public Registration()
        {
            InitializeComponent();
            this.navigationService = NavigationService.GetNavigationService(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string username = RegisterUsername.Text;
            string password = RegisterPassword.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username and password are required.");
                return;
            }

            if (userAccounts.ContainsKey(username))
            {
                MessageBox.Show("Username already exists. Please choose another one.");
                return;
            }

            // Hashing the password 
            string hashedPassword = HashPassword(password);
            userAccounts[username] = hashedPassword;

            MessageBox.Show("Registration successful.");

        }


        private void NavigateToRegistration(object sender, RoutedEventArgs e)
        {
            navigationService.Navigate(new Uri("Login.xaml", UriKind.Relative));
        }

        private string HashPassword(string password)
        {
            
            return password; 
        }

        private bool VerifyPassword(string inputPassword, string hashedPassword)
        {

            return inputPassword == hashedPassword;
        }
    }
    
}
