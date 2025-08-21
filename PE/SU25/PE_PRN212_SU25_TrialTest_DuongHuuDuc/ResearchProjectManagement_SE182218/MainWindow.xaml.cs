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
using ResearchProjectManagement.BLL.Services;
using ResearchProjectManagement.DAL.Entities;

namespace ResearchProjectManagement_SE182218
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ResearchProjectService _researchProjectService;
        private UserAccount userAccount;
        public MainWindow(UserAccount user)
        {
            InitializeComponent();
            _researchProjectService = new ResearchProjectService();
            userAccount = user;
            if (userAccount.Role == 3)
            {
                AddButton.IsEnabled = false;
                UpdateButton.IsEnabled = false;
                DeleteButton.IsEnabled = false;
            }
            else if (userAccount.Role == 2)
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
            ResearchDataGrid.ItemsSource = null;
            ResearchDataGrid.ItemsSource = _researchProjectService.GetAllResearchProject();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            DetailWindow detailWindow = new DetailWindow();
            detailWindow.ShowDialog();
            FillDataGrid();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            ResearchProject? selected = ResearchDataGrid.SelectedItem as ResearchProject;
            if (selected == null)
            {
                MessageBox.Show("Please select a row", "Select a row", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            DetailWindow detailWindow = new DetailWindow();
            detailWindow.EditedProject = selected;
            detailWindow.ShowDialog();
            FillDataGrid();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            ResearchProject? selected = ResearchDataGrid.SelectedItem as ResearchProject;
            if (selected == null)
            {
                MessageBox.Show("Please select a row", "Select a row", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            var result = MessageBox.Show("Do you want to delete ?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                _researchProjectService.DeleteResearchProject(selected);
                FillDataGrid();
            }
            else return;

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = SearchTextBox.Text;
            ResearchDataGrid.ItemsSource = _researchProjectService.Search(searchTerm);
        }
    }
}