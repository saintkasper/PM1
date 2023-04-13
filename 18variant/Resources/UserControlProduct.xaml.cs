using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _18variant.Resources
{
    /// <summary>
    /// Логика взаимодействия для UserControlProduct.xaml
    /// </summary>
    public partial class UserControlProduct : UserControl
    {
        string ID;
        public UserControlProduct(string ID)
        {
            InitializeComponent();
            this.ID = ID;

            DataTable table = Classes.ConstantData.GetTable("select ProductTypeName, ProductName, ProductArticle, MinCost, ProductPhoto, ProductStatus from product, product_type where product.ProductType = product_type.ProductTypeID And ProductArticle = " + ID);
            tbProductType.Text = table.Rows[0][0].ToString();
            tbProductName.Text = table.Rows[0][1].ToString();
            tbProductArticle.Text = table.Rows[0][2].ToString();
            tbCost.Text = table.Rows[0][3].ToString();
            cbStatus.Text = table.Rows[0][5].ToString();


            if (table.Rows[0][4].ToString().Length != 0)
            {
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.StreamSource = new MemoryStream((byte[])table.Rows[0][4]);
                img.EndInit();

                Product_Image.Source = img;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Classes.ConstantData.DoCommand("Update product set ProductName = '" + tbProductName.Text.ToString() + "', MinCost = " + tbCost.Text.ToString() + ", ProductStatus = '" + cbStatus.Text + "' Where ProductArticle = " + ID, tbCost.Text != "" && tbProductArticle.Text != "" && tbProductName.Text != "" && tbProductType.Text != "");
            Classes.ConstantData.Win.LoadData();
        }
    }
}
