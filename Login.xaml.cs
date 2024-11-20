using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Catalog_Scolar_Online
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        DB db = DB.GetInstance();

        public Login()
        {
            InitializeComponent();
        }

        private void textEmail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtEmail.Focus();
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text) && txtEmail.Text.Length > 0)
            {
                textEmail.Visibility = Visibility.Collapsed;
            }
            else
            {
                textEmail.Visibility = Visibility.Visible;
            }

            if (!IsValidEmail(txtEmail.Text))
            {
                EmailErrorText.Visibility = Visibility.Visible;
            }
            else
            {
                EmailErrorText.Visibility = Visibility.Collapsed;
            }
        }
        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtPassword.Focus();
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ConnectionErrorText.Visibility = Visibility.Collapsed;
            if (!string.IsNullOrEmpty(txtPassword.Password) && txtPassword.Password.Length > 0)
            {
                textPassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                textPassword.Visibility = Visibility.Visible;
            }
        }
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Password;

            if(email.Length>0 && password.Length>0)
            using (SqlCommand checkEmailPassword = new SqlCommand("SELECT UtilizatorID FROM [Online_School_Catalog].[dbo].[Utilizatori] WHERE Email = @Email AND Parola = @Parola", db.GetSqlConnection()))
            {
                checkEmailPassword.Parameters.AddWithValue("@Email", email);
                checkEmailPassword.Parameters.AddWithValue("@Parola", password);

                object result = checkEmailPassword.ExecuteScalar();

                int utilizatorID = Convert.ToInt32(result);

                if (result != null)
                {
                    //using (SqlCommand command = new SqlCommand("SELECT [ElevID], [Nume], [Prenume], [Data_nasterii], [Adresa], [ClasaID], [ParinteID], [UtilizatorID] FROM [Online_School_Catalog].[dbo].[Elevi] WHERE [UtilizatorID] = @UtilizatorID", db.GetSqlConnection()))
                    //{
                    //    command.Parameters.AddWithValue("@UtilizatorID", utilizatorID);

                    //    using (SqlDataReader reader = command.ExecuteReader())
                    //    {
                    //        if (reader.Read())
                    //        {
                    //            int elevID = reader.GetInt32(0); 
                    //            string lastName = reader.GetString(1); 
                    //            string firstName = reader.GetString(2); 
                    //            DateTime birthDate = reader.GetDateTime(3); 
                    //            string emailStudent = reader.GetString(4); 
                    //            int clas = reader.GetInt32(5); 

                    //            Student student = new Student(firstName, lastName, email, clas, birthDate);

                    //            StudentWindow studentWindow = new StudentWindow(student);
                    //            studentWindow.Show();
                    //            }
                    //    }
                    //}

                        StudentWindow studentWindow = new StudentWindow();
                        studentWindow.Show();
                        this.Close();
                    }
                else
                {
                    ConnectionErrorText.Visibility = Visibility.Visible;
                }
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Register registerWindow = new Register();
            registerWindow.Show();

            this.Close();
        }

        private void TogglePasswordVisibility(object sender, MouseButtonEventArgs e)
        {
            if (txtPasswordVisible.Visibility == Visibility.Collapsed)
            {
                txtPasswordVisible.Text = txtPassword.Password;
                txtPasswordVisible.Visibility = Visibility.Visible;
                txtPassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                txtPassword.Password = txtPasswordVisible.Text;
                txtPasswordVisible.Visibility = Visibility.Collapsed;
                txtPassword.Visibility = Visibility.Visible;
            }
        }
    }
}
