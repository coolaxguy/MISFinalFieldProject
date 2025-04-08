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
    /// Interaction logic for ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Window
    {
        public ProfilePage()
        {
            InitializeComponent();
            LoadUserProfileData();
        }

        private void ProfileHomeIcon_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void LoadUserProfileData()
        {
            string firstName = "";
            string lastName = "";

            // Lists to store class names, F45 class names, and memberships
            List<string> classNames = new List<string>();
            List<string> f45ClassNames = new List<string>();
            List<string> memberships = new List<string>();

            // Connect to the database
            using (SqlConnection conn = new SqlConnection("Data Source=(localdb)\\ProjectModels;Initial Catalog=OUFitRecDatabase;Integrated Security=True"))
            {
                conn.Open();

                // Retrieve user's first and last name based on the current logged-in user
                SqlCommand cmd = new SqlCommand("SELECT FName, LName FROM Account WHERE UserID = @uid", conn);
                cmd.Parameters.AddWithValue("@uid", Session.CurrentUserID); // Assuming the logged-in user ID is stored in the session

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    firstName = reader["FName"].ToString();
                    lastName = reader["LName"].ToString();
                }
                reader.Close();

                // Retrieve class names and schedules linked to the user from UserClass
                SqlCommand cmdClasses = new SqlCommand(@"
            SELECT c.Name, c.Schedule
            FROM Class c
            JOIN UserClass uc ON c.ClassID = uc.ClassID
            WHERE uc.UserID = @uid", conn);
                cmdClasses.Parameters.AddWithValue("@uid", Session.CurrentUserID);

                SqlDataReader readerClasses = cmdClasses.ExecuteReader();
                while (readerClasses.Read())
                {
                    // Concatenate Name and Schedule with ' - ' separator
                    string classInfo = readerClasses["Name"].ToString() + " - " + readerClasses["Schedule"].ToString();
                    classNames.Add(classInfo);
                }
                readerClasses.Close();

                // Retrieve F45 class names and schedules linked to the user from F45Class
                SqlCommand cmdF45Classes = new SqlCommand(@"
            SELECT f.Name, f.Schedule
            FROM F45 f
            JOIN F45Class ufc ON f.F45ID = ufc.F45ID
            WHERE ufc.UserID = @uid", conn);
                cmdF45Classes.Parameters.AddWithValue("@uid", Session.CurrentUserID);

                SqlDataReader readerF45Classes = cmdF45Classes.ExecuteReader();
                while (readerF45Classes.Read())
                {
                    // Concatenate Name and Schedule with ' - ' separator
                    string f45ClassInfo = readerF45Classes["Name"].ToString() + " - " + readerF45Classes["Schedule"].ToString();
                    f45ClassNames.Add(f45ClassInfo);
                }
                readerF45Classes.Close();

                // Retrieve membership types linked to the user from UserMember
                SqlCommand cmdMemberships = new SqlCommand(@"
            SELECT m.Type
            FROM Membership m
            JOIN UserMember um ON m.MembershipID = um.MembershipID
            WHERE um.UserID = @uid", conn);
                cmdMemberships.Parameters.AddWithValue("@uid", Session.CurrentUserID);

                SqlDataReader readerMemberships = cmdMemberships.ExecuteReader();
                while (readerMemberships.Read())
                {
                    memberships.Add(readerMemberships["Type"].ToString());
                }
                readerMemberships.Close();
            }

            // Set the values of the profile page controls
            FPTextBox.Text = firstName; // Set First Name in TextBox
            LPTextBox.Text = lastName;  // Set Last Name in TextBox

            // Set the ListBox data sources for memberships, class registrations, and F45 classes
            MembershipListBox.ItemsSource = memberships;  // Set Membership ListBox data source
            FPPlusClassRegister.ItemsSource = classNames;  // Set Registered Classes ListBox data source
            RegisteredClassListBox.ItemsSource = f45ClassNames;
        }
    
}
}
