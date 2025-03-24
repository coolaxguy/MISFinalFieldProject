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

namespace OUFitRecWebApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void HPFE_Click(object sender, RoutedEventArgs e)
        {
            Facilities fac = new Facilities();
            fac.Show();
            this.Close();
        }

        private void HPIME_Click(object sender, RoutedEventArgs e)
        {
            MembershipsPage mem = new MembershipsPage();
            mem.Show();
            this.Close();
        }

        private void HPME_Click(object sender, RoutedEventArgs e)
        {
            FCandFP fCandFP = new FCandFP();
            fCandFP.Show();
            this.Close();
        }

        private void HPFPE_Click(object sender, RoutedEventArgs e)
        {
            IMPage iMPage = new IMPage();
            iMPage.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Facilities fac = new Facilities();
            fac.Show();
            this.Close();
        }

        private void HPSIB_Click(object sender, RoutedEventArgs e)
        {
            LogInPage logInPage = new LogInPage();
            logInPage.Show();
            this.Close();
        }
    }
}
