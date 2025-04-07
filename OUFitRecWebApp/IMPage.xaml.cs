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
using System.Diagnostics;

namespace OUFitRecWebApp
{
    /// <summary>
    /// Interaction logic for IMPage.xaml
    /// </summary>
    public partial class IMPage : Window
    {
        public IMPage()
        {
            InitializeComponent();
        }

        private void IMHomeIcon_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void HPSIB_Click(object sender, RoutedEventArgs e)
        {
            LogInPage logIn = new LogInPage();
            logIn.Show();
            this.Close();
        }

        private void VIMB_Click(object sender, RoutedEventArgs e)
        {
            IMSportsList imSportsList = new IMSportsList();
            imSportsList.Show();
            this.Close();
        }

        private void JIMB_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
                { FileName = "https://play.fusionfamily.com/login?returnUrl=%2Fhome%2Fdashboard",
                    UseShellExecute = true });
        }
    }
}
