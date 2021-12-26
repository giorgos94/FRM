using FRM.Logic;
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

namespace FRM.UI
{
    /// <summary>
    /// Interaction logic for FailuresSelection.xaml
    /// </summary>
    public partial class FailuresSelection : Window
    {
        private string _selectedMeter;
        private string _sn;
        private string _type;
        private string _username;
        public FailuresSelection(string selectedMeter, string sn, string type, string username)
        {
            InitializeComponent();
            SQLQueries.loadFailures(comboBox);
             _selectedMeter = selectedMeter;
             _sn = sn;
             _type = type;
            _username = username;
            comboBox.Focus();

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string failure = comboBox.SelectedItem.ToString();
            SQLQueries.addEntry(_selectedMeter, _sn, _type, _username, failure);
            this.Close();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //button_Click(sender, e);
            button.IsEnabled = true;
        }

        private void comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                button_Click(sender, e);
        }
    }
}
