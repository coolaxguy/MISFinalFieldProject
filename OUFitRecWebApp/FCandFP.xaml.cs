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
    /// Interaction logic for FCandFP.xaml
    /// </summary>
    public partial class FCandFP : Window
    {
        public FCandFP()
        {
            InitializeComponent();
        }

        private void FCHomeIcon_Click(object sender, RoutedEventArgs e)
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
        public class ClassDisplayItem
        {
            public int ClassID { get; set; }
            public string SourceTable { get; set; } 
            public string DisplayText { get; set; }
            public override string ToString()
            {
                return DisplayText;
            }
        }

        private void FPDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FPDatePicker.SelectedDate == null) return;

            DateTime selectedDate = FPDatePicker.SelectedDate.Value.Date;
            List<ClassDisplayItem> classes = new List<ClassDisplayItem>();

            using (SqlConnection conn = new SqlConnection("Data Source=(localdb)\\ProjectModels;Initial Catalog=OUFitRecDatabase;Integrated Security=True"))
            {
                conn.Open();

                // ✅ Pull classes from FitnessClass table
                SqlCommand cmd1 = new SqlCommand("SELECT ClassID, Name, Type, Schedule, Location FROM Class WHERE CAST(Schedule AS DATE) = @date", conn);
                cmd1.Parameters.AddWithValue("@date", selectedDate);
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    classes.Add(new ClassDisplayItem
                    {
                        ClassID = (int)reader1["ClassID"],
                        SourceTable = "Class",
                        DisplayText = $"{reader1["Name"]} - {reader1["Type"]} @ {reader1["Schedule"]} in {reader1["Location"]}"
                    });
                }
                reader1.Close();

                
            }

            FPListBox.ItemsSource = classes; // bind the result to your ListBox
        }

        private void ClassSIButton_Click(object sender, RoutedEventArgs e)
        {
            if (FPListBox.SelectedItem is ClassDisplayItem selected)
            {
                using (SqlConnection conn = new SqlConnection("Data Source=(localdb)\\ProjectModels;Initial Catalog=OUFitRecDatabase;Integrated Security=True"))
                {
                    conn.Open();

                    SqlCommand cmd;

                    if (selected.SourceTable == "Class")
                    {
                        cmd = new SqlCommand("INSERT INTO UserClass (UserID, ClassID) VALUES (@uid, @cid)", conn);
                    }
                    else
                    {
                        MessageBox.Show("Unknown class type.");
                        return;
                    }

                    cmd.Parameters.AddWithValue("@uid", Session.CurrentUserID);
                    cmd.Parameters.AddWithValue("@cid", selected.ClassID);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("You have successfully signed up for the class!");
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Signup failed: Please Sign in to Sign Up for Classes");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a class from the list.");
            }
        }
    }
}
