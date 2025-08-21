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
using PerfumeManagement.BLL.Services;
using PerfumeManagement.DAL.Entities;

namespace PerfumeManagement_SE182218
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PerfumeInformationService _perfumeInformationService;
        private Psaccount _psaccount;
        public MainWindow(Psaccount psaccount)
        {
            InitializeComponent();
            _perfumeInformationService = new PerfumeInformationService();
            _psaccount = psaccount;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            PerfumeDataGrid.ItemsSource = null;
            PerfumeDataGrid.ItemsSource = _perfumeInformationService.GetAll();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            DetailWindow detailWindow = new DetailWindow();
            detailWindow.ShowDialog();
            FillDataGrid();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            PerfumeInformation selected = PerfumeDataGrid.SelectedItem as PerfumeInformation;
            if (selected == null)
            {
                MessageBox.Show("Please select a row", "Select a row", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            DetailWindow detailWindow = new DetailWindow();
            detailWindow.EdittedPerfume = selected;
            detailWindow.ShowDialog();
            FillDataGrid();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            PerfumeInformation selected = PerfumeDataGrid.SelectedItem as PerfumeInformation;
            if (selected == null)
            {
                MessageBox.Show("Please select a row", "Select a row", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            var result = MessageBox.Show("Do you want to delete ?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                _perfumeInformationService.Delete(selected);
                FillDataGrid();
            }
            else return;
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchString = SearchTextBox.Text.Trim();
            PerfumeDataGrid.ItemsSource = _perfumeInformationService.Search(searchString);
        }
    }
}