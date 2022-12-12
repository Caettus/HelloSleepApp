﻿using System;
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

        }
    }
}
