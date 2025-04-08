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

        private void F45DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (F45DatePicker.SelectedDate == null) return;

            DateTime selectedDate = F45DatePicker.SelectedDate.Value.Date;
            List<ClassDisplayItem> classes = new List<ClassDisplayItem>();

            using (SqlConnection conn = new SqlConnection("Data Source=(localdb)\\ProjectModels;Initial Catalog=OUFitRecDatabase;Integrated Security=True"))
            {
                conn.Open();

                SqlCommand cmd1 = new SqlCommand("SELECT F45ID, Name, Schedule FROM F45 WHERE CAST(Schedule AS DATE) = @date", conn);
                cmd1.Parameters.AddWithValue("@date", selectedDate);
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    classes.Add(new ClassDisplayItem
                    {
                        ClassID = (int)reader1["F45ID"],
                        SourceTable = "F45",
                        DisplayText = $"{reader1["Name"]} @ {reader1["Schedule"]}"
                    });
                }
                reader1.Close();


            }

            F45ListBox.ItemsSource = classes;
        }

        private void F45ClassTime_Click(object sender, RoutedEventArgs e)
        {
            if (F45ListBox.SelectedItem is ClassDisplayItem selected)
            {
                using (SqlConnection conn = new SqlConnection("Data Source=(localdb)\\ProjectModels;Initial Catalog=OUFitRecDatabase;Integrated Security=True"))
                {
                    conn.Open();

                    SqlCommand cmd;

                    if (selected.SourceTable == "F45")
                    {
                        cmd = new SqlCommand("INSERT INTO F45Class (UserID, F45ID) VALUES (@uid, @cid)", conn);
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
                        MessageBox.Show("Signup failed: Please Sign In to Sign Up for Classes");
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

