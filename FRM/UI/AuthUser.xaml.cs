using FRM.Logic;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace FRM
{

    public partial class AuthUser : Window
    {

        public AuthUser()
        {
            InitializeComponent();
            textBox.Focus();
        }



        private void button_Click(object sender, RoutedEventArgs e)
        {
            string user = textBox.Text.ToString();
            string password = passwordBox.Password.ToString();

            if (SQLQueries.isAuthorised(user, password))
            {
                App.Current.Properties["Username"] = textBox.Text.ToString();   //pass as a global property/variable the username for use in other classes.
                MainWindow mainW = new MainWindow();
                this.Close();
                mainW.Show();
            }

        }

        private void passwordBox_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.Key == Key.Enter)
                    button_Click(sender, e);
            
        }

    }
}
