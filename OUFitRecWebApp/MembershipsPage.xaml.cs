using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        private void MB1_Click(object sender, RoutedEventArgs e)
        {
            SignUpForMembership(1);
        }

        private void MB2_Click(object sender, RoutedEventArgs e)
        {
            SignUpForMembership(2);
        }

        private void MB3_Click(object sender, RoutedEventArgs e)
        {
            SignUpForMembership(3);
        }

        private void MB4_Click(object sender, RoutedEventArgs e)
        {
            SignUpForMembership(4);
        }

        private void SignUpForMembership(int membershipID)
        {
            int userID = Session.CurrentUserID; // Get the logged-in user ID

            using (SqlConnection conn = new SqlConnection("Data Source=(localdb)\\ProjectModels;Initial Catalog=OUFitRecDatabase;Integrated Security=True"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO UserMember (UserID, MembershipID) VALUES (@UserID, @MembershipID)", conn);
                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@MembershipID", membershipID);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Membership signed up successfully!");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: Please Sign In to Register a Membership");
                }
            }
        }
    }
}
