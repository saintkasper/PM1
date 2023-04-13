using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                Classes.ConstantData.connection.Open();
            }
            catch { }

            Classes.ConstantData.Win = this;

            LoadData();
        }

        string Filtration, AscDesc;
        int kolvo = 0;

        public void LoadData()
        {
            StackPanel_Users.Children.Clear();
            DataTable table = Classes.ConstantData.GetTable("SELECT ProductArticle FROM Product, Product_type where product.ProductType = product_type.ProductTypeID and ProductName LIKE '%" + TextBox_Search.Text + "%'" + Filtration + AscDesc);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                StackPanel_Users.Children.Add(new Resources.UserControlProduct(table.Rows[i][0].ToString()));
            }
        }

        private void TextBox_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadData();
        }

        //private void ComboBox_Filtration_DropDownClosed(object sender, EventArgs e)
        //{
            

        //}

        private void RadioButton_Asc_Checked(object sender, RoutedEventArgs e)
        {
            AscDesc = " ORDER BY MinCost asc";
            LoadData();
        }

        private void RadioButton_Desc_Checked(object sender, RoutedEventArgs e)
        {
            AscDesc = " ORDER BY MinCost desc";
            LoadData();
        }


        private void ComboBox_Filtration_DropDownClosed(object sender, EventArgs e)
        {
            if (ComboBox_Filtration.SelectedIndex == 0)
            {
                Filtration = "";
            }
            else if (ComboBox_Filtration.SelectedIndex == 1)
            {
                Filtration = " AND ProductTypeName = '" + ComboBox_Filtration.Text + "' ";
            }
            else if (ComboBox_Filtration.SelectedIndex == 2)
            {
                Filtration = " AND ProductTypeName = '" + ComboBox_Filtration.Text + "' ";
            }
            else if (ComboBox_Filtration.SelectedIndex == 3)
            {
                Filtration = " AND ProductTypeName = '" + ComboBox_Filtration.Text + "' ";
            }
            else if (ComboBox_Filtration.SelectedIndex == 4)
            {
                Filtration = " AND ProductTypeName = '" + ComboBox_Filtration.Text + "' ";
            }
            LoadData();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Navigation navigation = new Navigation();
            navigation.Show();
            Hide();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            //DataTable table = Classes.ConstantData.GetTable("SELECT ProductArticle FROM Product, Product_type where product.ProductType = product_type.ProductTypeID and ProductName LIKE '%" + TextBox_Search.Text + "%'" + Filtration + AscDesc);
            //if (table.Rows.Count - kolvo >= 0 )
            //{

            //}
            //kolvo += 10;
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            Windows.AddProduct win = new Windows.AddProduct();
            win.Show();
        }
    }
}
