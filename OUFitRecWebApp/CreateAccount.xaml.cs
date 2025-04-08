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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OUFitRecWebApp
{
    /// <summary>
    /// Interaction logic for CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : Window
    {
        public CreateAccount()
        {
            InitializeComponent();
        }

        private void CAHomeIcon_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LogInPage logInPage = new LogInPage();
            logInPage.Show();
            this.Close();
        }

        private void ReturnB_Click(object sender, RoutedEventArgs e)
        {
            LogInPage logInPage = new LogInPage();
            logInPage.Show();
            this.Close();
        }

        private void CreateAccountButton_Click(object sender, RoutedEventArgs e)
        {
            string username = EmailCreate.Text;
            string password = PasswordCreate.Text;
            string hash = PasswordHelper.Password(password); // hash it
            string fname = FNC.Text;
            string lname = LNC.Text;

            using (SqlConnection conn = new SqlConnection("Data Source=(localdb)\\ProjectModels;Initial Catalog=OUFitRecDatabase;Integrated Security=True"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Account (Email, Passwords, FName, LName) VALUES (@u, @p, @f, @l)", conn);
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", hash); // use hashed value
                cmd.Parameters.AddWithValue("@f", fname);
                cmd.Parameters.AddWithValue("@l", lname);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Account created! You can log in now.");
                    LogInPage logInPage = new LogInPage();
                    logInPage.Show();
                    this.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
