using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _18variant.Classes
{
    class ConstantData
    {
        public static MySqlConnection connection = new MySqlConnection("Database = vosmerka; Pwd = 251436; Uid = root; Server = localhost;");
        public static Windows.MainWindow Win;
        public static DataTable GetTable(string select)
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(select, connection);
            adapter.Fill(table);

            return table;
        }
        public static void DoCommand(string query, bool condition)
        {
            if (condition)
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Успешно!");
            }
            else
                MessageBox.Show("Заполните все поля!");
        }

        public static void DoCommandImage(string query, bool condition, string img)
        {
            if (condition)
            {
                FileStream FileStream = new FileStream(img, FileMode.Open, FileAccess.Read);
                BinaryReader BinaryReader = new BinaryReader(FileStream);
                byte[] Image_AsBytes = BinaryReader.ReadBytes((int)FileStream.Length);

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.Add(new MySqlParameter("@Image", Image_AsBytes));
                command.ExecuteNonQuery();
                MessageBox.Show("Успешно!");
            }
            else
                MessageBox.Show("Заполните все поля!");
        }
    }
}
