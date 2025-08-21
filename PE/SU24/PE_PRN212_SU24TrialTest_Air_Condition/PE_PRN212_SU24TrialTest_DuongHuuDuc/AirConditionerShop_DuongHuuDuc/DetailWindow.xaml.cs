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
using AirConditionerShop.BLL.Services;
using AirConditionerShop.DAL.Models;

namespace AirConditionerShop_DuongHuuDuc
{
    /// <summary>
    /// Interaction logic for DetailWindow.xaml
    /// </summary>
    public partial class DetailWindow : Window
    {
        public AirConditioner EdittedAirCon { get; set; } = null;
        // Biến FLAG, phất lên tuỳ ngữ cảnh 
        // Nếu không phất lên || null --> tạo mới
        // Nếu phất lên thì sẽ là một AirCon đã có sẵn, cần update lại
        // USER chọn dòng muốn edit --> EdittedAirCon = AirCon đã chọn bên MAIN
        // != null --> ta có data của AirCon muốn edit, khi đó ta đổ vào các ô

        private AirConService _service = new AirConService();
        private SupplierService _supService = new SupplierService();
        public DetailWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Gọi service để lưu AirCon xuống table
            // Phải new 

            // TODO: Chặn data vớ vẩn || Validation
            AirConditioner x = new AirConditioner();
            x.AirConditionerId = int.Parse(AirConditionerIdTextBox.Text); // KEY tự tăng, không có lệnh này, hệ thống tự generate (nếu tạo mới)
                                                                          // Nếu update thì vẫn cần
            x.AirConditionerName = AirConditionerNameTextBox.Text;
            x.Warranty = WarrantyTextBox.Text;
            x.SoundPressureLevel = SoundPressureLevelTextBox.Text;
            x.FeatureFunction = FeatureFunctionTextBox.Text;
            x.Quantity = int.Parse(QuantityTextBox.Text);
            x.DollarPrice = float.Parse(DollarPriceTextBox.Text);
            x.SupplierId = SupplierIdComboBox.SelectedValue.ToString();


            // Check FLAG ==> Add hay Update
            if(EdittedAirCon == null)
            {
                _service.AddAirConditioner(x);
            }
            else
            {
                _service.UpdateAirConditioner(x);
            }
            // TODO: Bắt exception nếu trùng KEY
            // Đóng màn hình detail trở về main
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) 
        {
            FillComboBox();
            FillElements(EdittedAirCon);

            // Fill rõ màn hình làm gì
            if(EdittedAirCon != null)
            {
                DetailWindowModeLabel.Content = "Edit Air Conditioner";
            }
            else
            {
                DetailWindowModeLabel.Content = "Create New Air Conditioner";
            }
        }

        // Hàm này đổ vào các ô nhập data của 1 máy lạnh có sẵn
        private void FillElements(AirConditioner x)
        {

            if (x == null)
            {
                // Nếu không có máy lạnh nào được chọn thì ta sẽ không làm gì cả
                return;
            }

            // Nếu EdittedAirCon != null thì ta sẽ đổ dữ liệu vào các ô
            AirConditionerIdTextBox.Text = x.AirConditionerId.ToString();
            // Disable không cho sửa ID
            AirConditionerIdTextBox.IsEnabled = false; // Không cho sửa ID, chỉ đọc thôi 

            AirConditionerNameTextBox.Text = x.AirConditionerName;
            WarrantyTextBox.Text = x.Warranty;
            SoundPressureLevelTextBox.Text = x.SoundPressureLevel;
            FeatureFunctionTextBox.Text = x.FeatureFunction;
            QuantityTextBox.Text = x.Quantity.ToString();
            DollarPriceTextBox.Text = x.DollarPrice.ToString();
            SupplierIdComboBox.SelectedValue = x.SupplierId; // Đang có ID gì đưa cột name tương ứng

        }

        //Hàm helper đổ data vào combobox
        private void FillComboBox()
        {
            SupplierIdComboBox.ItemsSource = _supService.GetAllSuppliers();
            // Hiển thị column nào
            SupplierIdComboBox.DisplayMemberPath = "SupplierName"; // Hiển thị tên nhà cung cấp
            // Khi chọn thì lấy giá trị nào dùng làm FK cho AirCon
            SupplierIdComboBox.SelectedValuePath = "SupplierId"; // Lấy ID của nhà cung cấp
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
