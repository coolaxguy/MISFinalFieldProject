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
using System.Configuration;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Data.Entity;

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
            LoadData();
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

        private void F45Button_Click(object sender, RoutedEventArgs e)
        {
            F45 f45 = new F45();
            f45.Show();
            this.Close();
        }
        private void LoadData()
        {
            // Retrieve the connection string from App.config
            string connectionString = ConfigurationManager.ConnectionStrings["MyDatabaseContext"].ConnectionString;

            string query = "SELECT Body FROM Home WHERE ContentID = 1";

            // Connect to the database and retrieve the data
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                // Execute the query and get the result
                var data = cmd.ExecuteScalar();  // Or ExecuteReader() if fetching multiple rows
                NewNews.Text = data?.ToString() ?? "No data found";  // Set the TextBlock with the fetched data
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ProfilePage profilePage = new ProfilePage();
            profilePage.Show();
            this.Close();
        }
    }
}
