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
    /// Interaction logic for DetailResearchWindow.xaml
    /// </summary>
    public partial class DetailResearchWindow : Window
    {
        private ResearchProjectService _researchProjectService;
        private ResearcherService _researcherService;
        public ResearchProject EditedProject {  get; set; }
        public DetailResearchWindow()
        {
            InitializeComponent();
            _researchProjectService = new ResearchProjectService();
            _researcherService = new();
            if(EditedProject != null)
            {
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            ResearchProject newResearchProject = new();
            newResearchProject.ProjectId = int.Parse(ProjectIdTextBox.Text);
            newResearchProject.ProjectTitle= ProjectTitleTextBox.Text;
            newResearchProject.ResearchField = ResearchFieldTextBox.Text;
            newResearchProject.Budget = decimal.Parse(BudgetTextBox.Text);
            newResearchProject.StartDate= DateOnly.FromDateTime(StartDatePicker.SelectedDate.Value);
            newResearchProject.EndDate= DateOnly.FromDateTime(EndDatePicker.SelectedDate.Value);
            newResearchProject.LeadResearcherId =int.Parse(LeadResearcherComboBox.SelectedValue.ToString()) ;
            if(EditedProject == null)
            {
                _researchProjectService.Save(newResearchProject);
                MessageBox.Show("Add project successfully!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                ProjectIdTextBox.Text = null;
            }
            else
            {

                _researchProjectService.Update(newResearchProject);
            }
            this.Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FillComboBox()
        {
            LeadResearcherComboBox.ItemsSource = _researcherService.GetAll();
            LeadResearcherComboBox.SelectedValuePath = "FullName";
            LeadResearcherComboBox.SelectedValuePath = "ResearcherId";

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillComboBox();
            FillElement(EditedProject);
        }

        private void FillElement(ResearchProject EditedProject)
        {
            if(EditedProject == null) return;
            ProjectIdTextBox.Text = EditedProject.ProjectId.ToString();
            ProjectTitleTextBox.Text = EditedProject.ProjectTitle.ToString();
            ResearchFieldTextBox.Text = EditedProject.ResearchField.ToString();
            BudgetTextBox.Text = EditedProject.Budget.ToString();
            StartDatePicker.SelectedDate = DateTime.Parse(EditedProject.StartDate.ToString()) ;
            EndDatePicker.SelectedDate = DateTime.Parse(EditedProject.EndDate.ToString()) ;
            LeadResearcherComboBox.SelectedValue = EditedProject.LeadResearcherId;
            ProjectIdTextBox.IsEnabled = false;
        }
    }
}
