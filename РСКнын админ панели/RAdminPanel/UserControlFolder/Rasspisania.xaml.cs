using RAdminPanel.DataBase;
using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RAdminPanel.UserControlFolder
{
    /// <summary>
    /// Логика взаимодействия для Rasspisania.xaml
    /// </summary>
    public partial class Rasspisania : UserControl
    {
        Base Bases = new Base();
        string id_1;
        int ID;
        public Rasspisania()
        {
            InitializeComponent();
            UpdateData();
            UpdateComboBox();
            Day_Grafik1();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Power_Date.Text != "" && Power_OF.Text != "" && Power_ON.Text != "" && TerminalPower.Text != "" && TerminalName.Text != "")
            {
                Bases.RegistrToBase("insert INTO terminals_options(terminal_id,t_key,t_ON,t_OF,t_date)VALUES('" + ID.ToString() + "','" + TerminalPower.Text + "','" + Power_ON.Text + "','" + Power_OF.Text + "','" + Power_Date.Text + "')");
                Power_Date.Text = "";
                Power_OF.Text = "";
                Power_ON.Text = "";
                ID = 0;
                TerminalPower.Text = "";
                TerminalName.Text = "";
                UpdateData();
            }    
        }
        public void UpdateData()
        {
            Bases.SoursDataGrid("SELECT tm.id,tm.t_ON,tm.t_OF,t.name AS t_name,tm.t_key as t_key, DATE_FORMAT(tm.t_date,'%d.%m.%Y') as t_date FROM terminals_options tm INNER JOIN terminals t ON tm.terminal_id=t.id and t_date IS not null", ref RaspisaniaData);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)RaspisaniaData.SelectedItem;
            if (dataRow != null)
            {
                id_1 = dataRow.Row.ItemArray[0].ToString();
                Message messageO = new Message();
                if (id_1 != "")
                {
                    messageO.Id = id_1;
                    messageO.TableBasa = "terminals_options";
                    messageO.del_ += () => UpdateData();
                    messageO.ShowDialog();
                }
            }
        }
        public void UpdateComboBox()
        {
            Bases.eventDysplay3 += delegate (Dictionary<string,string> mass)
             {
                 foreach (var item in mass)
                 {
                     TerminalName.Items.Add(item.Value.ToString());
                     TerminalName_Copy.Items.Add(item.Value.ToString());
                 }
             };
            Bases.Display_Dictionary1("SELECT NAME AS name,id FROM terminals");
        }

        private void TerminalName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TerminalName_Copy.SelectedValue!=null)
            {
                ID = Bases.ReturnID("SELECT id FROM terminals WHERE NAME='" + TerminalName_Copy.SelectedValue.ToString() + "'");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (ID != 0 && ON_Time.Text!="" && OF_Time.Text!="" && TerminalPower_Copy.Text != "" && DayCombobox.Text != "")
            {
                Bases.RegistrToBase("insert INTO terminals_options(terminal_id,t_key,t_ON,t_OF,t_day) VALUES (" + ID + ",'" + TerminalPower_Copy.Text + "','" + ON_Time.Text + "','" + OF_Time.Text + "','" + DayCombobox.Text + "')");
                ID = 0;
                TerminalPower_Copy.Text = "";
                ON_Time.Text = "";
                OF_Time.Text = "";
                DayCombobox.Text = "";
                Day_Grafik1();
            }
        }
        void Day_Grafik1()
        {
            Bases.SoursDataGrid("SELECT tm.id as id,tm.t_ON as t_on,tm.t_OF as t_of,t.name AS t_name,tm.t_key as t_key, d.day as day FROM terminals_options tm INNER JOIN terminals t INNER JOIN day d ON tm.terminal_id=t.id AND tm.t_day=d.day and t_day IS not null", ref Day_Grafik);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)Day_Grafik.SelectedItem;
            if (dataRow != null)
            {
                id_1 = dataRow.Row.ItemArray[0].ToString();
                Message messageO = new Message();
                if (id_1 != "")
                {
                    messageO.Id = id_1;
                    messageO.TableBasa = "terminals_options";
                    messageO.del_ += () => UpdateData();
                    messageO.ShowDialog();
                }
            }
        }

        private void TerminalName_Copy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TerminalName.SelectedValue != null)
            {
                ID = Bases.ReturnID("SELECT id FROM terminals WHERE NAME='" + TerminalName.SelectedValue.ToString() + "'");
            }
        }
    }
}
