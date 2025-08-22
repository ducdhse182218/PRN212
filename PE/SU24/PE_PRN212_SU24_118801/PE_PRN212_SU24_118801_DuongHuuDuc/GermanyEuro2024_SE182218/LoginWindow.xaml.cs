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
using GermanyEuro2024.BLL.Services;
using GermanyEuro2024.DAL.Entities;

namespace GermanyEuro2024_SE182218
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        UefaacountService _service = new();
        public LoginWindow()
        {
            InitializeComponent();
            _service = new();
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordTextBox.Text;
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both Email and Password.", "Missing Information", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Uefaaccount uefaaccount = _service.Authenticate(email, password);
            if (uefaaccount != null)
            {
                if (uefaaccount.Role == 4 || uefaaccount.Role == 1)
                {
                    MessageBox.Show("You have no permission to access this function!", "Access Denied",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                    return;
                }
                MainWindow mainWindow = new MainWindow(uefaaccount);
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
