using System;
using System.Data;
using System.Windows.Controls;
using MySql.Data.MySqlClient;


namespace RAdminPanel.DataBase
{
    class Base
    {
        public MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1; port=3306;Initial Catalog='rskbank';username=root;password=doni2429;CharSet=utf8;");
        public delegate void DisplaySourse(DataTable db);
        public delegate void DisplaySourse2(string[] a);
        public event DisplaySourse2 eventDysplay2;
        public delegate void SendData(DataTable data);
        public event SendData del;
        public Base()
        {

        }
        public void Display(string s,int count = 5)
        {
            connection.Open();
            int i = 0;
            string sql = s;
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            string[] a = new string[count];           
            while (reader.Read())
            {
                a[i] = reader[0].ToString();
                i++;
            }
            connection.Close();
            eventDysplay2(a);
        }

        public void SoursDataGrid(string s,ref DataGrid data)
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
            DataTable dta1 = new DataTable();
            MySqlDataAdapter dataadap = new MySqlDataAdapter(cmd);
            dataadap.Fill(dta1);
            data.ItemsSource = dta1.DefaultView;
            connection.Close();         
            
        }
        public void SourComboBox(string s, ref ComboBox data)
        {          
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(s, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            data.ItemsSource = dt.DefaultView;
            cmd.Dispose();
            connection.Close();
        }

        public void SoursData(string s)
        {
            connection.Close();
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
            DataTable dta1 = new DataTable();
            MySqlDataAdapter dataadap = new MySqlDataAdapter(cmd);
            dataadap.Fill(dta1);
            del(dta1);
            connection.Close();
        }
        public void RemoveData(string table, string id)
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM " + table + " WHERE id= " + id + "";
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void RegistrToBase(string s)
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public int ReturnID(string s)
        {
            connection.Open();
            string sql = s, value = "";
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                value = reader[0].ToString();
            }
            int x = Convert.ToInt32(value);
            connection.Close();
            return x;
        }
        public string Return1String(string s)
        {
            connection.Open();
            string sql = s, value = "";
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                value = reader[0].ToString();
            }
            connection.Close();
            return value;
        }
    }
}
