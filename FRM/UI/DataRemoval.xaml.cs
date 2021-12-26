using FRM.Logic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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

    public partial class DataRemoval : Window
    {
        private string _username;
        private string _selectedMeter;
        public DataRemoval()
        {
            _username = App.Current.Properties["Username"].ToString();
            _selectedMeter = App.Current.Properties["SelectedMeter"].ToString();
            InitializeComponent();
            SQLQueries.getEntries(dataGrid, _selectedMeter);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            SQLQueries.getEntries(dataGrid, _selectedMeter);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //assigns selectedItem(from dataGrid mouse selection) as a DataRowView. Pretty much parses selected item from cell and passes whole row into DataRowView that we access with romview.Row[0].ToString()
            DataRowView romview = dataGrid.SelectedItem as DataRowView;
            string sn = romview.Row[1].ToString();
            string failure = romview.Row[2].ToString();
            DateTime date = (DateTime) romview.Row[3];
            SQLQueries.removeEntry(dataGrid, _selectedMeter, sn, failure, date);
            SQLQueries.getEntries(dataGrid, _selectedMeter);
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView romview = dataGrid.SelectedItem as DataRowView;
            if (romview != null)
            {
                button1.IsEnabled = true;
            }
            else
            {
                button1.IsEnabled = false;
            }
        }

        private void applyDate_Click(object sender, RoutedEventArgs e)
        {
            if (datePickerFrom.SelectedDate.HasValue && datePickerTo.SelectedDate.HasValue)
            {
                DateTime toOld = (DateTime)datePickerTo.SelectedDate;
                DateTime toNew = toOld.AddDays(1);
                SQLQueries.getEntriesByDate(dataGrid, _selectedMeter, (DateTime)datePickerFrom.SelectedDate, toNew);

            }
            else
            {
                MessageBox.Show("Please pick a valid Date Range!");
            }
        }
    }
}
