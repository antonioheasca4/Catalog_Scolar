using Catalog_Scolar_Online.UserControls;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Catalog_Scolar_Online
{
    public partial class Register : Window
    {

        public Register()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void ClearCommonFields()
        {
            tb_lastName.Text = string.Empty;
            tb_firstName.Text = string.Empty;
            tb_email.Text = string.Empty;
            tb_password.Text = string.Empty;
        }

        private bool ValidateCommonFields()
        {
            return !string.IsNullOrWhiteSpace(tb_lastName.Text) &&
                   !string.IsNullOrWhiteSpace(tb_firstName.Text) &&
                   !string.IsNullOrWhiteSpace(tb_email.Text) &&
                   !string.IsNullOrWhiteSpace(tb_password.Text);
        }


        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            foreach (var control in gridMain.Children)
            {
                if (control is StackPanel stackpanel)
                {
                    foreach (var item in stackpanel.Children)
                    {
                        if (item is Catalog_Scolar_Online.UserControls.MyTextBox tb)
                        {
                            tb.Clear();
                        }
                    }
                }
            }
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            //if (ValidateCommonFields())
            //{
            //    if (DB.SaveData(tb_email.Text,tb_lastName.Text,tb_firstName.Text,tb_password.Text,tb_role.Text))
            //    {
            //        MessageBox.Show("Data saved successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            //        ClearFields();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Failed to save data. Email might already be in use.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("All fields must be filled.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            //}
        }

        private void cb_role_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            string selectedRole = (cb_role.SelectedItem as ComboBoxItem)?.Content.ToString();

            profesorFields.Visibility = Visibility.Collapsed;
            elevFields.Visibility = Visibility.Collapsed;
            parinteFields.Visibility = Visibility.Collapsed;


            switch (selectedRole)
            {
                case "Profesor":
                    profesorFields.Visibility = Visibility.Visible;
                    break;
                case "Elev":
                    elevFields.Visibility = Visibility.Visible;
                    break;
                case "Părinte":
                    parinteFields.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void btn_black_Click(object sender, RoutedEventArgs e)
        {
            grid_register.Visibility = Visibility.Visible;
        }

        private void close_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void minimize_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }


    }
}
