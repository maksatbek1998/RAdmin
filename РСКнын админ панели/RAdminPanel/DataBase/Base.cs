using System;
using System.Data;
using System.Windows.Controls;
using MySql.Data.MySqlClient;


namespace RAdminPanel.DataBase
{
    class Base
    {
        public MySqlConnection connection = new MySqlConnection("datasource=192.168.0.108; port=3306;Initial Catalog='rskbank';username=root;password=doni2429;CharSet=utf8;");
        public delegate void DisplaySourse(DataTable db);
        public delegate void DisplaySourse2(string[] a);
        public event DisplaySourse eventDysplay;
        public delegate void SendData(DataTable data);
        public event SendData del;
        public event DisplaySourse2 eventDysplay2;
        public Base()
        {

        }

        public void SoursDataGrid(string s, ref DataGrid data)
        {

            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = s;
            cmd.ExecuteNonQuery();
            DataTable dta1 = new DataTable();
            MySqlDataAdapter dataadap = new MySqlDataAdapter(cmd);
            dataadap.Fill(dta1);
            data.ItemsSource = dta1.DefaultView; ;
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
            cmd.CommandText = "DELETE FROM " + table + " WHERE id= '" + id + "';";
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
    }
}