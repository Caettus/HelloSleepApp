using Google.Protobuf.WellKnownTypes;
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
        List<Data>Listtwee = new List<Data>();
        List<UserData> Userdatalist = new List<UserData>();

        public CRUDWindow(List<Data> listtwee, List<UserData> userdatalist)
        {
            InitializeComponent();
            Listtwee = listtwee;
            Userdatalist = userdatalist;
            
        }


        private void UserDataBn_Click(object sender, RoutedEventArgs e)
        {
            string dbstring = "Server=127.0.0.1;Database=hellosleep;Uid=root;Pwd=;";

            MySqlConnection db = new MySqlConnection(dbstring);
            db.Open();
            MySqlCommand com = new MySqlCommand("SELECT * from users", db);
            //com.ExecuteNonQuery();

            MySqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                UserData dataClass = new();
                //dataClass.Id = (int)read["id"];
                dataClass.Name = read["name"].ToString();
                dataClass.Email = (string)read["email"];
                //dataClass.EmailVerifiedAt = (string)read["email_verified_at"];
                dataClass.Password = (string)read["password"];
                //dataClass.RememberToken = (string)read["remember_token"];
                //dataClass.CreatedAt = (string)read["created_at"];
                //dataClass.UpdatedAt = (string)read["updated_at"];
                //dataClass.admin = (string)read["admin"];
                Userdatalist.Add(dataClass);                
                


            }
            BabyDataGrid.ItemsSource = Userdatalist;
            db.Close();
        }

        private void BabyDataBtn_Click(object sender, RoutedEventArgs e)
        {

            string dbstring = "Server=127.0.0.1;Database=hellosleep;Uid=root;Pwd=;";
            //Data string, dit is nodig om een connectie te maken met de database (de gegevens zoals de server en de UID in dit geval root)
            

            MySqlConnection db = new MySqlConnection(dbstring);
            //hier wordt er een nieuwe MySQLconnectie (note: dat er wordt gerefereerd naar de data string)
            //deze connectie wordt gelinkt aan een variabele genaamd "db"
            db.Open();
            //de "db" variabele (die dus gelinkt is aan de database) wordt hier geopend
            MySqlCommand com = new MySqlCommand("SELECT * from data", db);
            // hier wordt er na dat de database is geopend, meteen een nieuwe command uitgevoerd, namelijk dat die gewoon alle data moet pakken.
            com.ExecuteNonQuery();
            //hier wordt de "com" variabele (die dus gelinkt is aan de query). uitgevoerd

            MySqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                Data dataClass = new();
                dataClass.Id = (int)read["id"];
                dataClass.Datum = read["datum"].ToString();
                dataClass.AVGTemperatuur = (string)read["avgtemp"];
                dataClass.Temperatuur = (string)read["temp"];
                dataClass.Hartslag = (string)read["hartslag"];
                dataClass.Slapen = (string)read["slaaptijd"];
                dataClass.Wakker = (string)read["wakkertijd"];

                BabyDataGrid.ItemsSource = Listtwee;
                //hier wordt de datagrid gelinkt aan de list (die nu gelinkt is aan de class?)
                

            }
            db.Close();
            //hier wordt de database geclosed


        }
    }
}
