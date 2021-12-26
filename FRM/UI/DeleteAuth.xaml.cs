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
using System.Windows.Shapes;
using FRM.Logic;

namespace FRM.UI
{

    public partial class DeleteAuth : Window
    {
        private MainWindow _mainWindow;
        private string _username;
        private string _selectedMeter;

        public DeleteAuth(MainWindow mainWindow)
        {
            _selectedMeter = App.Current.Properties["SelectedMeter"].ToString();
            _mainWindow = mainWindow;
            _username = App.Current.Properties["Username"].ToString();
            
            InitializeComponent();
            passwordBox.Focus();


        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            if (Logic.Logic.canDelete(passwordBox.Password.ToString()))
            {
                //_mainWindow.Close();
                DataRemoval dataRemoval = new DataRemoval();
                dataRemoval.Show();
                _mainWindow.Close();
                this.Close();
                
            } else
            {
                //MainWindow mainWindow = new MainWindow(_username);
                //_mainWindow.Close();
                //mainWindow.Show();
                this.Close();
            }
        }

        private void passwordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                button_Click(sender, e);
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            button.IsEnabled = true;
        }
    }
}
