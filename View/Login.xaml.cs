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
using Catalog_Scolar_Online;


namespace Catalog_Scolar_Online.View
{
    public partial class Login : Window
    {

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

            //if(email.Length>0 && password.Length>0)
            //{ 
            //    StudentWindow studentWindow = new StudentWindow();
            //    studentWindow.Show();
            //    this.Close();
            //}
            //    else
            //    {
            //        ConnectionErrorText.Visibility = Visibility.Visible;
            //    }
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


    }
}
