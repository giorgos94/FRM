using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FRM.Logic
{
    internal class Logic
    {

        private MainWindow _mainWindow;

        public Logic(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }


        public static Boolean canDelete(string password)
        {
            if (password.Equals("2741041287"))
            {
                return true;
            }
            MessageBox.Show("Wrong username/password");
            return false;
        }

    }
}
