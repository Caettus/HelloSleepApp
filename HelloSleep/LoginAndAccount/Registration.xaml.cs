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
using HelloSleep.Models;
using MySql.Data.MySqlClient;

namespace HelloSleep
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        List<UserData> UserRegistration = new List<UserData>();
        public Registration(List<UserData> userRegistration)
        {
            InitializeComponent();
            UserRegistration = userRegistration;
        }

        private void AccountAanmakenBTN_Click(object sender, RoutedEventArgs e)
        {
            string dbstring = "Server=127.0.0.1;Database=hellosleep;Uid=root;Pwd=;";

            MySqlConnection db = new MySqlConnection(dbstring);
            db.Open();
            MySqlCommand com = new MySqlCommand("SELECT * from users", db);
            

            MySqlDataReader read = com.ExecuteReader();
            string query = $"insert into users values('{txtboxFirstName.Text}','{txtboxEmail.Text}','{PassWordBox.Password}')";
            com.CommandText = query;
            
            
            
            db.Close();
            

        }
    }
}
