using Catalog_Scolar_Online.UserControls;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using Catalog_Scolar_Online.View;

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

            Login loginWindow = new Login();
            loginWindow.Show();
            this.Close();

        }


        private bool verifyAccount(string email)
        {
            Online_School_CatalogDataContext osc = new Online_School_CatalogDataContext();


            return osc.Conturis.Any(c => c.Email == email);
        }

        private bool insertUtilizator(string selectedRole)
        {
            Online_School_CatalogDataContext osc = new Online_School_CatalogDataContext();

            bool userExists = osc.Utilizatoris.Any(u => u.Email == tb_email.Text);

            if(!userExists)
            {
                Utilizatori user = new Utilizatori();
                user.Email = tb_email.Text;
                user.Parola = tb_password.Text;

                switch (selectedRole)
                {
                    case "Profesor":
                        user.Rol = 2;
                        break;
                    case "Elev":
                        user.Rol = 0;
                        break;
                    case "Părinte":
                        user.Rol = 1;
                        break;
                }

                osc.Utilizatoris.InsertOnSubmit(user);

                osc.SubmitChanges();

                MessageBox.Show("Utilizatorul a fost adaugat cu succes");
                return true;
            }
            else
            {
                MessageBox.Show($"Utilizatorul cu emailul {tb_email.Text} exista");
                return false;
            }
             
        }
        private void insertProfesor()
        {
            Online_School_CatalogDataContext osc = new Online_School_CatalogDataContext();

            int userID =
                (int)(from u in osc.Utilizatoris
                      where u.Email == tb_email.Text
                      select u.UtilizatorID).First();

            if(userID <= 0)
            {
                MessageBox.Show("Eroare UserID");
            }
            Profesori profesor = new Profesori
            { 
                UtilizatorID = userID,
                Nume = tb_lastName.Text,
                Prenume = tb_firstName.Text,
                Grad = tb_grad_didactic.Text,
            };

            osc.Profesoris.InsertOnSubmit(profesor);
            osc.SubmitChanges();

            MessageBox.Show($"Profesorul {profesor.Nume} a fost adaugat cu succes");

        }
        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            string selectedRole = (cb_role.SelectedItem as ComboBoxItem)?.Content.ToString();
            if(verifyAccount(tb_email.Text))
            {
                if (insertUtilizator(selectedRole))
                    switch (selectedRole)
                    {
                        case "Profesor":
                            insertProfesor();
                            break;
                        case "Elev":
                            break;
                        case "Părinte":
                            break;
                    }
            }
            else
            {
                MessageBox.Show("Emailul nu se afla in lista de Conturi!!!");
            }
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
