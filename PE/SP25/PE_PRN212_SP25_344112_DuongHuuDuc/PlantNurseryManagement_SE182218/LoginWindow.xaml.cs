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
using System.Windows.Shapes;
using PlantNurseryManagement.BLL.Services;
using PlantNurseryManagement.DAL.Entities;

namespace PlantNurseryManagement_SE182218
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        SystemUserService _service;
        public LoginWindow()
        {
            InitializeComponent();
            _service = new();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailAddressTextBox.Text;
            string password = PasswordTextBox.Text;
            if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both email and password.", 
                "Missing Information", 
                MessageBoxButton.OK, 
                MessageBoxImage.Warning);
                return;
            }

            SystemUser? systemUser = _service.Authenticate(email, password);
            if(systemUser != null)
            {
                if(systemUser.UserRole == 4)
                {
                    MessageBox.Show("You have no permission to access this function!", 
                    "Access Denied",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                    return;
                }
                MainWindow mainWindow = new MainWindow(systemUser);
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Login failed. Please check your email and password.",
                "Login Failed",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
            }
        }
    }
}
