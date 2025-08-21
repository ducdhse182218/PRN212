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
using PlantNurseryManagement.BLL.Services;
using PlantNurseryManagement.DAL.Entities;

namespace PlantNurseryManagement_SE182218
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private InventoryService _inventoryService = new InventoryService();
        private SystemUser _systemUser;
        public MainWindow(SystemUser systemUser)
        {
            InitializeComponent();
            _inventoryService = new InventoryService();
            _systemUser = systemUser;

            if (_systemUser.UserRole == 3)
            {
                AddButton.IsEnabled = false;
                UpdateButton.IsEnabled = false;
                DeleteButton.IsEnabled = false;
            }
            else if(_systemUser.UserRole == 2)
            {
                DeleteButton.IsEnabled = false;
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            InventoryDataGrid.ItemsSource = null;
            InventoryDataGrid.ItemsSource = _inventoryService.GetAll();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            DetailWindow detailWindow = new DetailWindow();
            detailWindow.ShowDialog();
            FillDataGrid();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Inventory selected = InventoryDataGrid.SelectedItem as Inventory;
            if(selected == null)
            {
                MessageBox.Show("Please select a row", "Select a row", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            DetailWindow detailWindow = new DetailWindow();
            detailWindow.EdittedInventory = selected;
            detailWindow.ShowDialog();
            FillDataGrid();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Inventory selected = InventoryDataGrid.SelectedItem as Inventory;
            if (selected == null)
            {
                MessageBox.Show("Please select a row", "Select a row", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            var result = MessageBox.Show("Do you want to delete ?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                _inventoryService.Delete(selected);
                FillDataGrid();
            }
            else return;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string searchString = SearchTextBox.Text;
            InventoryDataGrid.ItemsSource = _inventoryService.Search(searchString);
        }
    }
}