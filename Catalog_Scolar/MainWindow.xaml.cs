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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Catalog_Scolar
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DB baza_date = DB.GetInstance();
            if(baza_date.Connect())
            {
                string parola = Convert.ToString(baza_date.GetParola("bianca@gmail.com"));
                textbox.Text = parola;
            }
            baza_date.Disconnect(); 
        }
    }
}
