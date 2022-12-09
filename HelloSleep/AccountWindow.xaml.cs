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
    /// Interaction logic for AccountWindow.xaml
    /// </summary>
    public partial class AccountWindow : Window
    {
        List<Data> listTest = new List<Data>();
        List<UserData> userData = new List<UserData>();
        public AccountWindow(List<Data> TestList, List<UserData> UserData)
        {
            InitializeComponent();
            listTest = TestList;
            userData = UserData;
        }

        private void CrudBTN_Click(object sender, RoutedEventArgs e)
        {
            CRUDWindow CRUDWindow= new CRUDWindow(listTest, userData);
            CRUDWindow.Show();
        }

        private void RegisterBTN_Click(object sender, RoutedEventArgs e)
        {
            Registration Registration= new Registration();
            Registration.Show();
        }
    }
}
