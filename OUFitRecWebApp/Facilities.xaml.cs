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
using System.Configuration;
using System.Data.SqlClient;

namespace OUFitRecWebApp
{
    /// <summary>
    /// Interaction logic for Facilities.xaml
    /// </summary>
    public partial class Facilities : Window
    {
        public Facilities()
        {
            InitializeComponent();
            LoadData();
        }

        private void FHomeIcon_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void FSIB_Click(object sender, RoutedEventArgs e)
        {
            LogInPage logInPage = new LogInPage();
            logInPage.Show();
            this.Close();
        }
        private void LoadData()
        {
            MCS1.Text = GetTextFromDatabase("Select Description From Facility Where FacilityID = 1");
            MCS2.Text = GetTextFromDatabase("Select Location From Facility Where FacilityID = 1");
            RF1.Text = GetTextFromDatabase("Select Description From Facility Where FacilityID = 3");
            RF2.Text = GetTextFromDatabase("Select Location From Facility Where FacilityID = 3");
            SF1.Text = GetTextFromDatabase("Select Description From Facility Where FacilityID = 2");
            SF2.Text = GetTextFromDatabase("Select Location From Facility Where FacilityID = 2");
        }
        private string GetTextFromDatabase(string query)
        {
            string result = string.Empty;

            // Get the connection string from the app config
            string connectionString = ConfigurationManager.ConnectionStrings["MyDatabaseContext"].ConnectionString;

            // Connect to the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                // Execute the query and get the result
                var data = cmd.ExecuteScalar();
                result = data?.ToString() ?? "No data found";
            }

            return result;
        }
    }
}
