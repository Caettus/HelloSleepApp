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
using HelloSleep.Models;

namespace HelloSleep
{
    /// <summary>
    /// Interaction logic for LiveFeedWindow.xaml
    /// </summary>
    public partial class LiveFeedWindow : Window
    {
        List<Data> DataList;

        List<string> TempList = new List<string>();
        List<string> WakkerList = new List<string>();
        List<string> SlapenList = new List<string>();
        public LiveFeedWindow(List<Data> dataList)
        {
            InitializeComponent();

            DataList = dataList;
          
            AddItemsList();
            FillTextBoxes();
           
        }

        private void AddItemsList()
        {
            foreach (Data item in DataList)
            {
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
            }
        }
        private void LogoBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
