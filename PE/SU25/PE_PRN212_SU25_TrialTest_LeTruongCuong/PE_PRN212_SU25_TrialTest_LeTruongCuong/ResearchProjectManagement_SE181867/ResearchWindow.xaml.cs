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
    /// Interaction logic for ResearchWindow.xaml
    /// </summary>
    public partial class ResearchWindow : Window
    {
        private ResearchProjectService _researchProjectService;
        private UserAccount _userAccount;

        public ResearchWindow(UserAccount userAccount)
        {
            InitializeComponent();
            _researchProjectService = new ResearchProjectService();
            _userAccount = userAccount;
            if(userAccount.Role == 3)
            {
                AddButton.IsEnabled = false;
                UpdateButton.IsEnabled = false;
                DeleteButton.IsEnabled = false;
            }else if(userAccount.Role == 2)
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
            ResearchDataGrid.ItemsSource = _researchProjectService.GetAll();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            DetailResearchWindow detailResearchWindow = new DetailResearchWindow();
            detailResearchWindow.ShowDialog();
            FillDataGrid();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            ResearchProject? selected = ResearchDataGrid.SelectedItem as ResearchProject;
            if(selected == null) { 
                MessageBox.Show("Please select a row","Select a row",MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            DetailResearchWindow detailResearchWindow = new DetailResearchWindow();
            detailResearchWindow.EditedProject = selected;
            detailResearchWindow.ShowDialog();
            FillDataGrid();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            ResearchProject? selected = ResearchDataGrid.SelectedItem as ResearchProject;
            if(selected == null)
            {
                MessageBox.Show("Please select a row", "Select a row", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            var result = MessageBox.Show("Do you want to delete ?","Confirm",MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                _researchProjectService.Delete(selected);
                FillDataGrid();
            }
            else return;
            
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchString = SearchTextBox.Text;
            ResearchDataGrid.ItemsSource = _researchProjectService.Search(searchString);
        }
    }
}
