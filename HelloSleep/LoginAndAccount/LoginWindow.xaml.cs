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
         
            MySqlCommand com = new MySqlCommand($"SELECT * FROM users WHERE email = {txtboxEmail}", db);
            com.ExecuteScalar();
            

            

            //try
            //{
            //    db.Open();
            //    string stm = "select email,password from users WHERE email = @Email AND password =@Password";
            //    var cmd = new MySqlCommand(stm, db);

            //    cmd.Parameters.AddWithValue("@Name", txtboxEmail.Text);
            //    cmd.Parameters.AddWithValue("@Password", txtblockPassword.Text);
            //    cmd.ExecuteReader();
            //}
            //catch(Exception ex) { Console.WriteLine("Login failed"); }
            //db.Close();
        }

        //private void itwork()
        //{
        //    this.Hide();
        //    itwork frm = new itwork();
        //    frm.Show();
        //    this.Close();
        //}

    }
}
