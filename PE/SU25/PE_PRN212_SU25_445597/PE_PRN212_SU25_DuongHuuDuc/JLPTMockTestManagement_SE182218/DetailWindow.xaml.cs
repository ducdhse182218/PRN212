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
using JLPTMockTestManagement.BLL.Services;
using JLPTMockTestManagement.DAL.Entities;

namespace JLPTMockTestManagement_SE182218
{
    /// <summary>
    /// Interaction logic for DetailWindow.xaml
    /// </summary>
    
    public partial class DetailWindow : Window
    {
        private MockTestService _mockTestService;
        private CandidateService _candidateService;

        public MockTest EdittedMockTest { get; set; }
        public DetailWindow()
        {
            InitializeComponent();
            _mockTestService = new MockTestService();
            _candidateService = new CandidateService();
            if(EdittedMockTest != null)
            {
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            MockTest mockTest = new MockTest();
            mockTest.TestId = int.Parse(TestIdTextBox.Text);
            mockTest.TestTitle = TestTitleTextBox.Text;
            mockTest.SkillArea = SkillAreaTextBox.Text;
            mockTest.StartTime = TimeOnly.Parse(StartTimeTextBox.Text);
            mockTest.EndTime = TimeOnly.Parse(EndTimeTextBox.Text);
            mockTest.CandidateId = int.Parse(CandidateComboBox.SelectedValue.ToString());
            if (EdittedMockTest == null)
            {
                _mockTestService.Save(mockTest);
                MessageBox.Show("Mock Test added successfully!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                TestIdTextBox.Text = null;
            }
            else
            {
                _mockTestService.Update(mockTest);
            }
            this.Close();
        }

        private void FillComboBox()
        {
            CandidateComboBox.ItemsSource = _candidateService.GetAll();
            CandidateComboBox.DisplayMemberPath = "FullName";
            CandidateComboBox.SelectedValuePath = "CandidateId";
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillComboBox();
            FillElement(EdittedMockTest);
        }

        private void FillElement(MockTest EdittedMockTest)
        {
            if (EdittedMockTest == null) return;
            TestIdTextBox.Text = EdittedMockTest.TestId.ToString();
            TestTitleTextBox.Text = EdittedMockTest.TestTitle;
            SkillAreaTextBox.Text = EdittedMockTest.SkillArea;
            StartTimeTextBox.Text = EdittedMockTest.StartTime.ToString();
            EndTimeTextBox.Text = EdittedMockTest.EndTime.ToString();
            CandidateComboBox.SelectedValue = EdittedMockTest.CandidateId;
            TestIdTextBox.IsEnabled = false; 
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
