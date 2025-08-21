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
using ResearchProjectManagement.BLL.Services;
using ResearchProjectManagement.DAL.Entities;

namespace ResearchProjectManagement_SE181867
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        UserAccountService _service;
        public LoginWindow()
        {
            InitializeComponent();
            _service = new UserAccountService();
        }

        private void btnLogin_Click_1(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordTextBox.Text;
            if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both Email and Password.", "Missing Information", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            UserAccount? userAccount = _service.Authenticate(email, password);
            if(userAccount != null)
            {
                if(userAccount.Role == 4)
                {
                    MessageBox.Show("You have no permission to access this function!",
                "Access Denied",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
                    return;
                }
                ResearchWindow researchWindow = new ResearchWindow(userAccount);
                researchWindow.Show();
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
