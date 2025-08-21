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
using SamStore.BLL.Services;
using SamStore.DAL.Entities;

namespace SamStore_SE182218
{
    /// <summary>
    /// Interaction logic for DetailWindow.xaml
    /// </summary>
    public partial class DetailWindow : Window
    {
        private SamPreOrderService _samPreOrderService;
        private SamProductService _samProductService;

        public SamPreOrder EdittedOrder { get; set; }
        public DetailWindow()
        {
            InitializeComponent();
            _samPreOrderService = new SamPreOrderService();
            _samProductService = new SamProductService();
            if(EdittedOrder != null)
            {
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SamPreOrder samPreOrder = new SamPreOrder();
            //samPreOrder.PreOrderId = int.Parse(PreOrderIdTextBox.Text);
            samPreOrder.PreOrderNo = PreOrderNoTextBox.Text;
            samPreOrder.DepositAmount = int.Parse(DepositAmountTextBox.Text);
            samPreOrder.TotalAmount = int.Parse(TotalAmountTextBox.Text);
            samPreOrder.CustomerName = CustomerNameTextBox.Text;
            samPreOrder.CustomerPhone = CustomerPhoneTextBox.Text;
            samPreOrder.CustomerAddress = CustomerAddressTextBox.Text;
            samPreOrder.Status = StatusTextBox.Text;
            samPreOrder.CreatedAt = DateOnly.FromDateTime(DateTime.Now);
            samPreOrder.UpdatedAt = DateOnly.FromDateTime(DateTime.Now);
            samPreOrder.ProductId = int.Parse(ProductComboBox.SelectedValue.ToString());

            if (EdittedOrder == null)
            {
                _samPreOrderService.Save(samPreOrder);
                MessageBox.Show("PreOrder added successfully!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                //PreOrderIdTextBox.Text = null;
            }
            else
            {
                samPreOrder.PreOrderId = EdittedOrder.PreOrderId;
                _samPreOrderService.Update(samPreOrder);
            }
            this.Close();
        }

        private void FillComboBox()
        {
            ProductComboBox.ItemsSource = _samProductService.GetAll();
            ProductComboBox.DisplayMemberPath = "ProductName";
            ProductComboBox.SelectedValuePath = "ProductId";
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillComboBox();
            FillElement(EdittedOrder);
        }

        private void FillElement(SamPreOrder EdittedOrder)
        {
            if (EdittedOrder == null) return;
            //PreOrderIdTextBox.Text = EdittedOrder.PreOrderId.ToString();
            PreOrderNoTextBox.Text = EdittedOrder.PreOrderNo;
            DepositAmountTextBox.Text = EdittedOrder.DepositAmount.ToString();
            TotalAmountTextBox.Text = EdittedOrder.TotalAmount.ToString();
            CustomerNameTextBox.Text = EdittedOrder.CustomerName;
            CustomerPhoneTextBox.Text = EdittedOrder.CustomerPhone;
            CustomerAddressTextBox.Text = EdittedOrder.CustomerAddress;
            StatusTextBox.Text = EdittedOrder.Status;
            CreatedAtDatePicker.SelectedDate = DateTime.Parse(EdittedOrder.CreatedAt.ToString());
            UpdatedAtDatePicker.SelectedDate = DateTime.Parse(EdittedOrder.UpdatedAt.ToString());
            ProductComboBox.SelectedValue = EdittedOrder.ProductId;
            //PreOrderIdTextBox.IsEnabled = false;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
