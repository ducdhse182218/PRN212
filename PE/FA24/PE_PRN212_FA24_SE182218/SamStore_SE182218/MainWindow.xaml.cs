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
using SamStore.BLL.Services;
using SamStore.DAL.Entities;

namespace SamStore_SE182218
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SamPreOrderService _samPreOrderService;
        private Member _member;
        public MainWindow(Member member)
        {
            InitializeComponent();
            _samPreOrderService = new SamPreOrderService();
            _member = member;

            if (_member.RoleId == 2)
            {
                AddButton.IsEnabled = false;
                UpdateButton.IsEnabled = false;
                DeleteButton.IsEnabled = false;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            SamPreOrderDataGrid.ItemsSource = null;
            SamPreOrderDataGrid.ItemsSource = _samPreOrderService.GetAll();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            DetailWindow detailWindow = new DetailWindow();
            detailWindow.ShowDialog();
            FillDataGrid();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            SamPreOrder selected = SamPreOrderDataGrid.SelectedItem as SamPreOrder;
            if (selected == null)
            {
                MessageBox.Show("Please select a row", "Select a row", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            DetailWindow detailWindow = new DetailWindow();
            detailWindow.EdittedOrder = selected;
            detailWindow.ShowDialog();
            FillDataGrid();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            SamPreOrder selected = SamPreOrderDataGrid.SelectedItem as SamPreOrder;
            if (selected == null)
            {
                MessageBox.Show("Please select a row", "Select a row", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            var result = MessageBox.Show("Do you want to delete ?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                _samPreOrderService.Delete(selected);
                FillDataGrid();
            }
            else return;
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchString = SearchTextBox.Text.Trim();
            SamPreOrderDataGrid.ItemsSource = _samPreOrderService.Search(searchString);
        }
    }
}