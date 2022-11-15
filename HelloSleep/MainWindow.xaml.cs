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
using System.Windows.Navigation;
using System.Windows.Shapes;
using HelloSleep.DB;
using HelloSleep.Models;
using HelloSleep.DocumentDownloads;

namespace HelloSleep
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Data> dataList = new();

        public MainWindow()
        {
            InitializeComponent();

            GetDBdata.GetData(dataList);

            
        }

        private void DataBtn_Click(object sender, RoutedEventArgs e)
        {
            DataWindow windowData = new(dataList);

            windowData.Show();
        }

        private void LiveFeedBtn_Click(object sender, RoutedEventArgs e)
        {
            LiveFeedWindow windowLive = new(dataList);

            windowLive.Show();
        }

        private void WekkerBtn_Click(object sender, RoutedEventArgs e)
        {
            UnderConstructionPage underConstructionPage = new UnderConstructionPage();
            underConstructionPage.Show();
        }
        private void LogoBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void MuziekBtn_Click(object sender, RoutedEventArgs e)
        {
            UnderConstructionPage underConstructionPage = new UnderConstructionPage();
            underConstructionPage.Show();
        }
    }
}
