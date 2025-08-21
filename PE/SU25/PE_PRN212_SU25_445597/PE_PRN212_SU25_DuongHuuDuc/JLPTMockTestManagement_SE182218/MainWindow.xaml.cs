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
using JLPTMockTestManagement.BLL.Services;
using JLPTMockTestManagement.DAL.Entities;

namespace JLPTMockTestManagement_SE182218
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MockTestService _mockTestService;
        private Jlptaccount _jlptaccount;
        public MainWindow(Jlptaccount jlptaccount)
        {
            InitializeComponent();
            
            _mockTestService = new MockTestService();
            _jlptaccount = jlptaccount;

            if (_jlptaccount.Role == 3)
            {
                AddButton.IsEnabled = false;
                UpdateButton.IsEnabled = false;
                DeleteButton.IsEnabled = false;
            } else if( _jlptaccount.Role == 2)
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
            MockTestDataGrid.ItemsSource = null;
            MockTestDataGrid.ItemsSource = _mockTestService.GetAll();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            DetailWindow detailWindow = new DetailWindow();
            detailWindow.ShowDialog();
            FillDataGrid();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            MockTest selected = MockTestDataGrid.SelectedItem as MockTest;
            if (selected == null)
            {
                MessageBox.Show("Please select a row", "Select a row", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            DetailWindow detailWindow = new DetailWindow();
            detailWindow.EdittedMockTest = selected;
            detailWindow.ShowDialog();
            FillDataGrid();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            MockTest selected = MockTestDataGrid.SelectedItem as MockTest;
            if(selected == null)
            {
                MessageBox.Show("Please select a row", "Select a row", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            var result = MessageBox.Show("Do you want to delete ?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                _mockTestService.Delete(selected);
                FillDataGrid();
            }
            else return;
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchString = SearchTextBox.Text.Trim();
            MockTestDataGrid.ItemsSource = _mockTestService.Search(searchString);
        }
    }
}