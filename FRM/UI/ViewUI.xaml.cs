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
    public partial class ViewUI : Window
    {

        private string _selectedMeter;
        private string _username;

        public ViewUI()
        {
            InitializeComponent();
            _username = App.Current.Properties["Username"].ToString();
            _selectedMeter = App.Current.Properties["SelectedMeter"].ToString();
            SQLQueries.getEntries(dataGrid, _selectedMeter);
        }




        private void button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void btnGetDataClick(object sender, RoutedEventArgs e)
        {
            SQLQueries.getEntries(dataGrid, _selectedMeter);

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
