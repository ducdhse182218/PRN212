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
using AirConditionerShop.BLL.Services;
using AirConditionerShop.DAL.Models;
using Microsoft.IdentityModel.Tokens;

namespace AirConditionerShop_DuongHuuDuc
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private MemberService _service = new MemberService();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            StaffMember account = _service.Authenticate(EmailAddressTextBox.Text, PasswordTextBox.Password);

            // Kiểm tra empty or null
            if(EmailAddressTextBox.Text.IsNullOrEmpty() || PasswordTextBox.Password.IsNullOrEmpty())
            {
                MessageBox.Show("Please enter both username and password", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            } 

            // Kiểm tra tài khoản có tồn tại không
            if (account == null)
            {
                MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // Phải thông báo rõ sai cái gì: định dạng, password, cả hai...
            // Nếu nhập sai 5 lần --> khoá trong bao lâu...

            if (account.Role == 3)
            {
                MessageBox.Show("You have no permission to access this function!", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            
            //Role 1, 2 đi tiếp
            //Authenticate thành công mới gọi MainWindow
            MainWindow main = new MainWindow();
            main.CurrentAccount = account; // Đẩy account Login sang bên Main
            main.Show();
            this.Hide(); // Ẩn login window
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown(); // Đóng toàn bộ ứng dụng
        }
    }
}
