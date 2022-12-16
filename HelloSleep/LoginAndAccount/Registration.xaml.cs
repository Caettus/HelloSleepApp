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
            try
            {
                string dbstring = "Server=127.0.0.1;Database=hellosleep;Uid=root;Pwd=;";
                string pwdToHash = PassWordBox.Password;
                string hashToStoreInDatabase = BCrypt.Net.BCrypt.HashPassword(pwdToHash, BCrypt.Net.BCrypt.GenerateSalt());

                using (MySqlConnection db = new MySqlConnection(dbstring))
                {
                    db.Open();
                    
                    MySqlCommand cmd = new MySqlCommand($"INSERT INTO users (name,email,password) VALUES (@Name,@Email,@Password)", db);

                    cmd.Parameters.Add(new MySqlParameter("@Name", MySqlDbType.VarChar));
                    cmd.Parameters.Add(new MySqlParameter("@Email", MySqlDbType.VarChar));
                    cmd.Parameters.Add(new MySqlParameter("@Password", MySqlDbType.VarChar));
                    //cmd.Parameters.Add("@Name", MySqlDbType.VarChar);
                    //cmd.Parameters.Add("@Email", MySqlDbType.VarChar);
                    //cmd.Parameters.Add("@Name", MySqlDbType.VarChar);
                    cmd.Parameters["@Name"].Value = (txtboxFirstName.Text);
                    cmd.Parameters["@Email"].Value = txtboxEmail.Text;
                    cmd.Parameters["@Password"].Value = hashToStoreInDatabase;

                    cmd.ExecuteNonQuery();

                    db.Close();

                   
                    
                    
                    //string passwordHash = BCrypt.Net.BCrypt.HashPassword($"{PassWordBox.Password}");
                    
                    //MySqlCommand testcom = new MySqlCommand($"INSERT INTO (users) (name,email,password) VALUES ('{txtboxFirstName},{txtboxEmail},{passwordHash}')");
                    
                    //testcom.ExecuteNonQuery();
                    
                    //db.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
            
            


        }
    }
}
