using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Controls;
using MySql.Data.MySqlClient;


namespace RAdminPanel.DataBase
{
    class Base
    {
        public MySqlConnection connection = new MySqlConnection("datasource=192.168.0.7; port=3306;Initial Catalog='rskbank';username=admin;password=1;CharSet=utf8;");
        //public MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1; port=3306;Initial Catalog='rskbank';username=root;password=123456;CharSet=utf8;");
        public delegate void DisplaySourse(DataTable db);
        public delegate void DisplaySourse2(List<string> a);
        public delegate void Display_Dictionary(Dictionary<string,string> a);
        public event DisplaySourse2 eventDysplay2;
        public event Display_Dictionary eventDysplay3;
        public delegate void SendData(DataTable data);
        public event SendData del;
        public Base()
        {

        }

        public void Display(string s,int count =5)
        {
            connection.Open();
            List<string> lister = new List<string>();
            int i = 0;
            string sql = s;
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
        
            while (reader.Read())
            {
                lister.Add(reader[0].ToString());
                i++;
            }
            connection.Close();
            eventDysplay2(lister);
        }
        public void Display_Dictionary1(string s)
        {
            connection.Open();
            Dictionary<string, string> a = new Dictionary<string, string>();
            int i = 0;
            string sql = s;
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                a.Add(reader[0].ToString(), reader[1].ToString());
                i++;
            }
            connection.Close();
            eventDysplay3(a);
        }
        public void SoursDataGrid(string s,ref DataGrid data)
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
        public string ReturnID1(string s)
        {
            connection.Open();
            string sql = s, value = "";
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                value = reader[0].ToString();
            };
            connection.Close();
            return value;
        }
        public string ReturnIDString(string s)
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
      public static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
