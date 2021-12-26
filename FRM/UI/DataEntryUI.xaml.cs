using FRM.Logic;
using FRM.UI;
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

    public partial class DataEntryUI : Window
    {
        private string _selectedMeter;
        private string _username;
        
        
        public DataEntryUI()
        {
            InitializeComponent();

            _selectedMeter = App.Current.Properties["SelectedMeter"].ToString();
            _username = App.Current.Properties["Username"].ToString();
            textBox.Focus();

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {          
            string sn = textBox.Text;
            string type = textBox.Text.Substring(0, 6);
            FailuresSelection failuresSelection = new FailuresSelection(_selectedMeter, sn, type, _username);
            failuresSelection.ShowDialog();
            

            textBox.Clear();
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                button_Click(sender, e);
        }


        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            button.IsEnabled = true;
        }
    }
}
