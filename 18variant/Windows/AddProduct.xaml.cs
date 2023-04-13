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

namespace _18variant.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        public AddProduct()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            Classes.ConstantData.DoCommand($"Insert into Product (ProductName, MinCost, ProductType, NumOfPeaple, WorkshopNum, ProductStatus) Values ({tbProductName.Text}, {tbCost.Text}, {(cbTypeProduct.SelectedIndex + 1).ToString()}, {tbQuantity.Text}, {tbNumber.Text}, {tbStatus.Text})", tbCost.Text != "" && tbNumber.Text != "" && tbProductName.Text != "" && tbQuantity.Text != "" && cbTypeProduct.Text != "" && tbStatus.Text != "");

            Classes.ConstantData.Win.LoadData();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Classes.ConstantData.Win.LoadData();
        }
    }
}
