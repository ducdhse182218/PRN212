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
using PlantNurseryManagement.BLL.Services;
using PlantNurseryManagement.DAL.Entities;

namespace PlantNurseryManagement_SE182218
{
    /// <summary>
    /// Interaction logic for DetailWindow.xaml
    /// </summary>
    public partial class DetailWindow : Window
    {
        private InventoryService _inventoryService;
        private PlantService _plantService;

        public Inventory EdittedInventory { get; set; }
        public DetailWindow()
        {
            InitializeComponent();
            _inventoryService = new InventoryService();
            _plantService = new PlantService();
            if (EdittedInventory != null)
            {
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Inventory newInventory = new();
            newInventory.InventoryId = int.Parse(InventoryIdTextBox.Text);
            newInventory.Quantity = int.Parse(QuantityTextBox.Text);
            newInventory.Price = decimal.Parse(PriceTextBox.Text);
            newInventory.ArrivalDate = DateOnly.FromDateTime(ArrivalDatePicker.SelectedDate.Value);
            newInventory.ShelfLife = int.Parse(ShelfLifeTextBox.Text);
            newInventory.Supplier = SupplierTextBox.Text;
            newInventory.PlantId = int.Parse(PlantComboBox.SelectedValue.ToString());

            if (EdittedInventory == null)
            {
                _inventoryService.Save(newInventory);
                MessageBox.Show("Add inventory successfully!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                InventoryIdTextBox.Text = null;
            }
            else
            {
                _inventoryService.Update(newInventory);
            }
            this.Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FillComboBox()
        {
            PlantComboBox.ItemsSource = _plantService.GetAll();
            PlantComboBox.SelectedValuePath = "Name";
            PlantComboBox.SelectedValuePath = "PlantId";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillComboBox();
            FillElement(EdittedInventory);
        }
        private void FillElement(Inventory EdittedInventory)
        {
            if (EdittedInventory == null) return;
            InventoryIdTextBox.Text = EdittedInventory.InventoryId.ToString();
            QuantityTextBox.Text = EdittedInventory.Quantity.ToString();
            PriceTextBox.Text = EdittedInventory.Price.ToString();
            ArrivalDatePicker.SelectedDate = DateTime.Parse(EdittedInventory.ArrivalDate.ToString());
            ShelfLifeTextBox.Text = EdittedInventory.ShelfLife.ToString();
            SupplierTextBox.Text = EdittedInventory.Supplier;
            PlantComboBox.SelectedValue = EdittedInventory.PlantId;
            InventoryIdTextBox.IsEnabled = false;
        }
    }
}
