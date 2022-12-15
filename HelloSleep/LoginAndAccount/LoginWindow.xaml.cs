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
using Org.BouncyCastle.Asn1.Cmp;

namespace HelloSleep.LoginAndAccount
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        List<UserData> InLoggen = new List<UserData>();
        public LoginWindow(List<UserData> inloggen)
        {
            InitializeComponent();
            InLoggen = inloggen;
        }

        private void LoginBTN_Click(object sender, RoutedEventArgs e)
        {
            string dbstring = "Server=127.0.0.1;Database=hellosleep;Uid=root;Pwd=;";
            MySqlConnection db = new MySqlConnection(dbstring);

            db.Open();

            //eerst selecteert je ALLES van de database zodat de if statement de juiste data kan pakken.
            MySqlCommand com = new MySqlCommand("SELECT * FROM users", db);
            
            //op deze manier heb je een read functie.
            MySqlDataReader read = com.ExecuteReader();
            
            //de Read functie leest maar 1 regel, dus het moet door een while loop want zolang er regels zijn in de database moet die
            //blijven doorlezen om te kijken of de text binnen txtboxEmail overeenkomt met een regel in de database.
            //alle andere manieren werken niet (op de een of andere manier), dus doe dit.
            while (read.Read())
            {
                if ((string)read["email"] == txtboxEmail.Text)
                {
                    MessageBox.Show("Het werkt");
                }
            }
            
            db.Close();
        }

    }
}
