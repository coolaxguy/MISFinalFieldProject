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

namespace OUFitRecWebApp
{
    /// <summary>
    /// Interaction logic for MembershipsPage.xaml
    /// </summary>
    public partial class MembershipsPage : Window
    {
        public MembershipsPage()
        {
            InitializeComponent();
        }

        private void MHomeIcon_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void MSIB_Click(object sender, RoutedEventArgs e)
        {
            LogInPage logIn = new LogInPage();
            logIn.Show();
            this.Close();
        }
    }
}
