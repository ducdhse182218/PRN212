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
using JLPTMockTestManagement.BLL.Services;
using JLPTMockTestManagement.DAL.Entities;

namespace JLPTMockTestManagement_SE182218
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        JlptaccountService _service = new();
        public LoginWindow()
        {
            InitializeComponent();
            _service = new JlptaccountService();
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

            Jlptaccount jlptaccount = _service.Authenticate(email, password);
            if (jlptaccount != null)
            {
                if(jlptaccount.Role == 4)
                {
                    MessageBox.Show("You have no permission to access this function!", "Access Denied",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                    return;
                }
                MainWindow mainWindow = new MainWindow(jlptaccount);
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
