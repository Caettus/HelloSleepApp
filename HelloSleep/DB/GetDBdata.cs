using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloSleep.Models;

namespace HelloSleep.DB
{
    internal class GetDBdata
    {
        public static void GetData(List<Data> dataList)
        {
            string dbstring = "Server=127.0.0.1;Database=hellosleep;Uid=root;Pwd=;";

            MySqlConnection db = new MySqlConnection(dbstring);
            db.Open();
            MySqlCommand com = new MySqlCommand("SELECT * from data", db);
            com.ExecuteNonQuery();

            MySqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                Data dataClass = new();

                dataClass.Id = (int)read["id"];
                dataClass.Datum = read["datum"].ToString();
                dataClass.AvgTemp = (string)read["avgtemp"];
                dataClass.Temperatuur = (string)read["temp"];
                dataClass.Hartslag = (string)read["hartslag"];
                dataClass.Slapen = (string)read["slaaptijd"];
                dataClass.Wakker = (string)read["wakkertijd"];

                dataList.Add(dataClass);
            }
            db.Close();
        }
    }
}
