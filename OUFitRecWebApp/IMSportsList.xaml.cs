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
using static System.Net.Mime.MediaTypeNames;
using System.Configuration;
using System.Data.SqlClient;

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
            LoadData();
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
        private void LoadData()
        { 
        IM1.Text = GetTextFromDatabase("Select Name,Description,Season From IMSport where SportID = 1");
        IM2.Text = GetTextFromDatabase("Select Name, Description, Season From IMSport where SportID = 2");
        IM3.Text = GetTextFromDatabase("Select Name, Description, Season From IMSport where SportID = 3");
        IM4.Text = GetTextFromDatabase("Select Name, Description, Season From IMSport where SportID = 4");
        IM5.Text = GetTextFromDatabase("Select Name, Description, Season From IMSport where SportID = 5");
        IM6.Text = GetTextFromDatabase("Select Name, Description, Season From IMSport where SportID = 6");
        IM7.Text = GetTextFromDatabase("Select Name, Description, Season From IMSport where SportID = 7");
        IM8.Text = GetTextFromDatabase("Select Name, Description, Season From IMSport where SportID = 8");
        IM9.Text = GetTextFromDatabase("Select Name, Description, Season From IMSport where SportID = 9");
        }
        private string GetTextFromDatabase(string query)
        {
            string result = "";

            string connectionString = ConfigurationManager.ConnectionStrings["MyDatabaseContext"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Combine all the fields you want
                        string name = reader["Name"].ToString();
                        string description = reader["Description"].ToString();
                        string season = reader["Season"].ToString();

                        result = $"{name}\n\n{description}\nLeague Start Date:\n{season}";
                    }
                }
            }

            return result;
        }

    }
}
