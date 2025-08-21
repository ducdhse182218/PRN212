using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AirConditionerShop.BLL.Services;
using AirConditionerShop.DAL.Models;
using Microsoft.IdentityModel.Tokens;

namespace AirConditionerShop_DuongHuuDuc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AirConService _service = new();

        // Chuyển giao Account đã Login thành công từ LoginWindow sang MainWindow để chào, disable chức năng
        public StaffMember CurrentAccount { get; set; } 

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            DetailWindow d = new();
            // d.Show(); --> Show nhiều màn hình
            d.ShowDialog();
            // F5 Lại GRID khi đóng màn hình
            // TODO: Đúng chuẩn phải check nếu có tạo mới, nhấn Save thì mới F5  
            FillDataGrid();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillDataGrid();

            // Hiển thị tên tài khoản đã đăng nhập
            if (CurrentAccount != null)
            {
                HelloMsgLabel.Content = $"Welcome, {CurrentAccount.FullName}!";
            }
            // Check role để disable button
            if (CurrentAccount.Role == 2) // Staff
            {
                CreateButton.IsEnabled = false;
                UpdateButton.IsEnabled = false;
                DeleteButton.IsEnabled = false;
            }
            else if (CurrentAccount.Role == 1) // Admin
            {
                CreateButton.IsEnabled = true;
                UpdateButton.IsEnabled = true;
                DeleteButton.IsEnabled = true;
            }
        }

        // Hàm Helper, trợ giúp cho hàm khác
        private void FillDataGrid()
        {
            // Hiển thị lên DataGrid
            AirConsDataGrid.ItemsSource = null; //xoá grid
            AirConsDataGrid.ItemsSource = _service.GetAllAirConditioners(); //lấy dữ liệu từ service
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            AirConditioner? selected = AirConsDataGrid.SelectedItem as AirConditioner;
            if(selected == null)
            {
                MessageBox.Show("Plese select an AirCon before editting", "Select a row", MessageBoxButton.OK, MessageBoxImage.Exclamation );
                return;
            }
            // Chạy đến đây là đã chọn, ta đẩy sang DetailWindow - EdittedAirCon được gán value

            DetailWindow d = new();
            d.EdittedAirCon = selected; // Đẩy dữ liệu đã chọn sang DetailWindow
            d.ShowDialog();
            FillDataGrid();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            AirConditioner? selected = AirConsDataGrid.SelectedItem as AirConditioner;
            if (selected == null)
            {
                MessageBox.Show("Plese select an AirCon before deleting", "Select a row", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            else
            {
                MessageBoxResult answer = MessageBox.Show($"Are you sure you want to delete {selected.AirConditionerName}?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (answer == MessageBoxResult.Yes)
                {
                    _service.DeleteAirConditioner(selected);
                    FillDataGrid();
                }
                else
                {
                    return;
                }
                
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            // Validation quantity
            int? quantity = null;
            int tmpQuantity; // Hứng convert thành công, hoặc string == 0 
            bool quantStatus = int.TryParse(QuantityTextBox.Text, out tmpQuantity);
            if(!quantStatus && !QuantityTextBox.Text.IsNullOrEmpty()) 
            {
                MessageBox.Show("Please enter a valid number for Quantity", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
                return; // Không làm gì nữa
            }
            else if (quantStatus == true)
            {
                quantity = tmpQuantity;
            }

            var result = _service.SearchAirConsByFeatureAndQuantity(FeatureFunctionTextBox.Text, quantity);

            // Đổ kết quả vào grid
            AirConsDataGrid.ItemsSource = null; //xoá grid
            AirConsDataGrid.ItemsSource = result;
        }
        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}