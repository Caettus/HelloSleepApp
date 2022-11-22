using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using HelloSleep.Models;
using Org.BouncyCastle.Bcpg.OpenPgp;

namespace HelloSleep.ArdConnectie
{
    public class MainCon
    {
        const char startChar = '#';
        const char endChar = '%';        

        public static void SendCommand(LiveData liveData, string command)
        {
            SerialPort port = new SerialPort(
              "COM3", 115200, Parity.None, 8, StopBits.One);

            port.Open();

            string serialCommand = $"{startChar}{command}{endChar}";

            port.Write(serialCommand);

            if (command == "TEMP_LEZEN")
            {
                liveData.CurrentTemp = port.ReadExisting();
            }

            port.Close();
        }    
    }
}
