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

namespace OUFitRecWebApp
{
    /// <summary>
    /// Interaction logic for F45.xaml
    /// </summary>
    public partial class F45 : Window
    {
        public F45()
        {
            InitializeComponent();
        }

        private void F45HomeIcon_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void F45SIB_Click(object sender, RoutedEventArgs e)
        {
            LogInPage logInPage = new LogInPage();
            logInPage.Show();
            this.Close();
        }
    }
}
