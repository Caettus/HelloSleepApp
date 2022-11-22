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
using System.Windows.Shell;
using HelloSleep.ArdConnectie;
using HelloSleep.DB;
using HelloSleep.Models;
using System.Windows.Navigation;
using System.Threading;
using Google.Protobuf.WellKnownTypes;

namespace HelloSleep
{
    /// <summary>
    /// Interaction logic for LiveFeedWindow.xaml
    /// </summary>
    public partial class LiveFeedWindow : Window
    {
        LiveData liveData = new();

        List<Data> DataList;

        List<double> LiveTempList = new();
        List<string> TempList = new();
        List<string> WakkerList = new();
        List<string> SlapenList = new();

        public LiveFeedWindow(List<Data> dataList)
        {
            InitializeComponent();

            DataList = dataList;

            UpdateData();
            SendDataDb();
        }

        public async void UpdateData()
        {
            var timer = new PeriodicTimer(TimeSpan.FromSeconds(1));

            while (await timer.WaitForNextTickAsync())
            {
                MainCon.SendCommand(liveData, "TEMP_LEZEN");
                DataList.Clear();
                GetDBdata.GetData(DataList);
                AddItemsList();
                FillTextBoxes();
                if (LiveTempList.Count > 0)
                {
                    liveData.AvgTemp = Math.Round(LiveTempList.Average(), 2).ToString();
                }
            }
        }

        public async void SendDataDb()
        {
            var timer = new PeriodicTimer(TimeSpan.FromSeconds(20));

            while (await timer.WaitForNextTickAsync())
            {
                if (liveData.CurrentTemp == "")
                {
                    DataToDb.StuurData(liveData.AvgTemp, LiveTempList.Last().ToString());
                }
                else
                {
                    DataToDb.StuurData(liveData.AvgTemp, liveData.CurrentTemp);
                }
            }
        }

        private void AddItemsList()
        {
            foreach (Data item in DataList)
            {
                if (liveData.CurrentTemp != "")
                {
                    LiveTempList.Add(double.Parse(liveData.CurrentTemp));
                }
                TempList.Add(item.Temperatuur);
                WakkerList.Add(item.Wakker);
                SlapenList.Add(item.Slapen);
            }
        }

        private void FillTextBoxes()
        {
            foreach (Data item in DataList)
            {
                wakkerTb.Text = item.Wakker + " wakker";
                slapenTb.Text = item.Slapen + " slapen";

                if (item.Temperatuur == TempList.AsQueryable().Min())
                {
                    TijdLaagTb.Text = item.Datum;
                }

                laagsteTempTb.Text = TempList.AsQueryable().Min() + " graden";

                if (item.Temperatuur == TempList.AsQueryable().Max())
                {
                    TijdHoogTb.Text = item.Datum;
                }
                hoogsteTempTb.Text = TempList.AsQueryable().Max() + " graden";

                currentTempTb.Text = "Baby heeft nu een temperatuur van " +  liveData.CurrentTemp + "\nGemiddeld temperatuur: " + liveData.AvgTemp;
            }
        }
        private void LogoBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
       private void DataBtn_Click(object sender, RoutedEventArgs e)
       {
            DataWindow windowData = new(DataList);

            windowData.Show();
       }
        private void RefreshPagina()
        {
            LiveFeedWindow liveFeedWindow = new(DataList);
            liveFeedWindow.Show();
            this.Close();
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            RefreshPagina();
        }
    }
}
