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
using PerfumeManagement.BLL.Services;
using PerfumeManagement.DAL.Entities;

namespace PerfumeManagement_SE182218
{
    /// <summary>
    /// Interaction logic for DetailWindow.xaml
    /// </summary>
    public partial class DetailWindow : Window
    {
        private PerfumeInformationService _perfumeInformationService;
        private ProductionCompanyService _productionCompanyService;
        public PerfumeInformation EdittedPerfume { get; set; }
        public DetailWindow()
        {
            InitializeComponent();
            _perfumeInformationService = new PerfumeInformationService();
            _productionCompanyService = new ProductionCompanyService();
            if(EdittedPerfume != null)
            {
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            PerfumeInformation perfume = new PerfumeInformation();
            perfume.PerfumeId = PerfumeIdTextBox.Text;
            perfume.PerfumeName = PerfumeNameTextBox.Text;
            perfume.Ingredients = IngredientsTextBox.Text;
            perfume.ReleaseDate = ReleaseDatePicker.SelectedDate;
            perfume.Concentration = ConcentrationTextBox.Text;
            perfume.Longevity = LongevityTextBox.Text;
            perfume.ProductionCompanyId = ProductionCompanyComboBox.SelectedValue.ToString();
            if (EdittedPerfume == null)
            {
                _perfumeInformationService.Save(perfume);
                MessageBox.Show("Perfume added successfully!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                PerfumeIdTextBox.Text = null;
            }
            else
            {
                _perfumeInformationService.Update(perfume);
            }
            this.Close();
        }

        private void FillComboBox()
        {
            ProductionCompanyComboBox.ItemsSource = _productionCompanyService.GetAll();
            ProductionCompanyComboBox.DisplayMemberPath = "ProductionCompanyName";
            ProductionCompanyComboBox.SelectedValuePath = "ProductionCompanyId";
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillComboBox();
            FillElement(EdittedPerfume);
        }

        private void FillElement(PerfumeInformation EdittedPerfume)
        {
            if (EdittedPerfume == null) return;
            PerfumeIdTextBox.Text = EdittedPerfume.PerfumeId.ToString();
            PerfumeNameTextBox.Text = EdittedPerfume.PerfumeName;
            IngredientsTextBox.Text = EdittedPerfume.Ingredients;
            ReleaseDatePicker.SelectedDate = EdittedPerfume.ReleaseDate;
            ConcentrationTextBox.Text = EdittedPerfume.Concentration;
            LongevityTextBox.Text = EdittedPerfume.Longevity;
            ProductionCompanyComboBox.SelectedValue = EdittedPerfume.ProductionCompanyId;
            PerfumeIdTextBox.IsEnabled = false;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
