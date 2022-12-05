using HelloSleep.Models;
using MySql.Data.MySqlClient;
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

namespace HelloSleep
{
    /// <summary>
    /// Interaction logic for CRUDWindow.xaml
    /// </summary>
    public partial class CRUDWindow : Window
    {
        public CRUDWindow()
        {
            InitializeComponent();
        }

        private void UserDataBn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BabyDataBtn_Click(object sender, RoutedEventArgs e)
        {
            
                string dbstring = "Server=127.0.0.1;Database=hellosleep;Uid=root;Pwd=;";

                MySqlConnection db = new MySqlConnection(dbstring);
                db.Open();
                MySqlCommand com = new MySqlCommand("SELECT * from data", db);
                com.ExecuteNonQuery();

                MySqlDataReader read = com.ExecuteReader();
                while (read.Read())
                {
                    //(int)read["id"];
                    //(string)read["datum"];
                    //(string)read["temp"];
                    //(string)read["hartslag"];
                    //(string)read["slaaptijd"];
                    //(string)read["wakkertijd"];

                    TextBoxCRUD.Text = (string)read["temp"];
                    BabyDataGrid = read;
            }
                db.Close();
            

        }
    }
}
