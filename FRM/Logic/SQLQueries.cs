using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FRM.Logic
{
    internal class SQLQueries
    {

        //Checks if user/password combination exists in table: AuthUsers
        public static bool isAuthorised(string user, string password)
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MyInstance;Initial Catalog=FRM;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand($"SELECT * FROM AuthUsers WHERE Username = @user AND Password = @pass", con);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", password);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            cmd.ExecuteNonQuery();

            if (dt.Rows.Count > 0)
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                MessageBox.Show("Wrong username/password");
                return false;

            }
        }

        //Adds entry to table _selectedMeter and values sn, type, _username & date(getdate())
        public static void addEntry(string _selectedMeter, string sn, string type, string _username, string failure)
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MyInstance;Initial Catalog=FRM;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand($"Insert INTO {_selectedMeter} (Type, SN, Failure, Date_Added, Username) VALUES (@type, @sn, @failure, GetDate(), @user)", con);
            cmd.Parameters.AddWithValue("@sn", sn);
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.AddWithValue("@user", _username);
            cmd.Parameters.AddWithValue("@failure", failure);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void removeEntry(DataGrid dataGrid, string _selectedMeter, string sn, string failure, DateTime date)
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MyInstance;Initial Catalog=FRM;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand($"DELETE FROM {_selectedMeter} WHERE SN = @sn AND Failure = @failure AND Date_Added = @date", con);
            cmd.Parameters.AddWithValue("@sn", sn);
           // cmd.Parameters.AddWithValue("@type", type);
            //cmd.Parameters.AddWithValue("@user", _username);
            cmd.Parameters.AddWithValue("@failure", failure);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //Retrieves entries from table _selectedMeter and loads them into passed DataGrid object
        public static void getEntries(DataGrid dataGrid, string _selectedMeter)
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MyInstance;Initial Catalog=FRM;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand($"Select * from {_selectedMeter}", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.DefaultView.Sort = "Date_Added desc";
            dataGrid.ItemsSource = dt.DefaultView;
            
            con.Close();
        }

        public static void getEntriesByDate(DataGrid dataGrid, string _selectedMeter, DateTime dateFrom, DateTime dateTo)
        {

            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MyInstance;Initial Catalog=FRM;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand($"Select * from {_selectedMeter} WHERE Date_Added BETWEEN @dateFrom AND @dateTo", con);
            cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
            cmd.Parameters.AddWithValue("@dateTo", dateTo);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.DefaultView.Sort = "Date_Added desc";
            dataGrid.ItemsSource = dt.DefaultView;

            con.Close();
        }


        //Loads passes ComboBox with table names
        public static void loadComboBox(ComboBox comboBox)
        {

            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MyInstance;Initial Catalog=FRM;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from sys.tables", con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                if (!row["name"].Equals("sysdiagrams") && !row["name"].Equals("AuthUsers") && !row["name"].Equals("Failures"))
                {

                    comboBox.Items.Add(row["name"]);
                }
            }


            con.Close();

        }

        public static void loadFailures(ComboBox comboBox)
        {

            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MyInstance;Initial Catalog=FRM;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Failures", con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach(DataRow item in dt.Rows)
            {
                comboBox.Items.Add(item[0].ToString());
            }


            con.Close();

        }


    }
}
