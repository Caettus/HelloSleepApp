using HelloSleep.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloSleep.DB
{
    public class DataToDb
    {
        public static void StuurData(string avgTemp, string temp)
        {
            string dbstring = "Server=127.0.0.1;Database=hellosleep;Uid=root;Pwd=;";
            DateTime datum = DateTime.Now;

            MySqlConnection db = new MySqlConnection(dbstring);
            db.Open();
            MySqlCommand com = new MySqlCommand("INSERT INTO data (temp, avgtemp, datum) VALUES (@temp, @avgtemp, @datum);", db);
            com.Parameters.AddWithValue("@temp", temp);
            com.Parameters.AddWithValue("@avgtemp", avgTemp);
            com.Parameters.AddWithValue("@datum", datum);
            com.ExecuteNonQuery();

            db.Close();


            db.Close();
        }
    }
}
