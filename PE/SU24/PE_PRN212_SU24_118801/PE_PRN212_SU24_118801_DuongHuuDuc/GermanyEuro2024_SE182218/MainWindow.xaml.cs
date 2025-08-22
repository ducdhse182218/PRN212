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
using GermanyEuro2024.BLL.Services;
using GermanyEuro2024.DAL.Entities;

namespace GermanyEuro2024_SE182218
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FootballPlayerService _footballPlayerService;
        Uefaaccount _uefaaccount;
        public MainWindow(Uefaaccount uefaaccount)
        {
            InitializeComponent();
            _footballPlayerService = new FootballPlayerService();
            _uefaaccount = new();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            FootballTeamDataGrid.ItemsSource = null;
            FootballTeamDataGrid.ItemsSource = _footballPlayerService.GetAll();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            DetailWindow detailWindow = new DetailWindow();
            detailWindow.ShowDialog();
            FillDataGrid();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            FootballPlayer selected = FootballTeamDataGrid.SelectedItem as FootballPlayer;
            if (selected == null)
            {
                MessageBox.Show("Please select a row", "Select a row", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            DetailWindow detailWindow = new DetailWindow();
            detailWindow.EdittedFootballPlayer = selected;
            detailWindow.ShowDialog();
            FillDataGrid();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            FootballPlayer selected = FootballTeamDataGrid.SelectedItem as FootballPlayer;
            if (selected == null)
            {
                MessageBox.Show("Please select a row", "Select a row", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            var result = MessageBox.Show("Do you want to delete ?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                _footballPlayerService.Delete(selected);
                FillDataGrid();
            }
            else return;
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchString = SearchTextBox.Text.Trim();
            FootballTeamDataGrid.ItemsSource = _footballPlayerService.Search(searchString);
        }
    }
}