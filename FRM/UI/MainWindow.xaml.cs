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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FRM
{

    public partial class MainWindow : Window
    {
        private string _username;

        public MainWindow()
        {
            InitializeComponent();
            _username = App.Current.Properties["Username"].ToString();
            SQLQueries.loadComboBox(comboBox);

        }



        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            DataEntryUI dataEntryUI = new DataEntryUI();
            this.Close();
            dataEntryUI.Show();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ViewUI viewUI = new ViewUI();
            
            this.Close();
            viewUI.Show();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            App.Current.Properties["SelectedMeter"] = comboBox.SelectedItem.ToString();
            button.IsEnabled = true;
            button1.IsEnabled = true;
            button2.IsEnabled = true;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            

            DeleteAuth deleteAuth = new DeleteAuth(this);
            deleteAuth.ShowDialog();

        }
    }
}
