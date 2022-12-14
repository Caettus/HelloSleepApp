using HelloSleep.DB;
using HelloSleep.DocumentDownloads;
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

namespace HelloSleep
{
    /// <summary>
    /// Interaction logic for DataWindow.xaml
    /// </summary>
    public partial class DataWindow : Window
    {
        List<Data> DataList;
        public DataWindow(List<Data> dataList)
        {
            InitializeComponent();

            DataList = dataList;

            DgGebruikers.ItemsSource = dataList;
        }
        private void downloadDataBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedCell = DgGebruikers.SelectedCells[0];
            var id = (selectedCell.Column.GetCellContent(selectedCell.Item) as TextBlock).Text;

            DownloadExcel.Download(DataList, id);
        }

        private void downloadAllesBtn_Click(object sender, RoutedEventArgs e)
        {
            string id = null;
            DownloadExcel.Download(DataList, id);
        }
    }
}
