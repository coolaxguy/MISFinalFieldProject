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
    /// Interaction logic for IMSportsList.xaml
    /// </summary>
    public partial class IMSportsList : Window
    {
        public IMSportsList()
        {
            InitializeComponent();
        }

        private void IMLHomeIcon_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();

        }

        private void IMSIB_Click(object sender, RoutedEventArgs e)
        {
            LogInPage logInPage = new LogInPage();
            logInPage.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IMPage iMPage = new IMPage();
            iMPage.Show();
            this.Close();
        }
    }
}
