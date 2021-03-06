﻿using RAdminPanel.DataBase;
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
        int ID=0;
        public Rasspisania()
        {
            InitializeComponent();
            UpdateData();
            UpdateComboBox();
            Day_Grafik1();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ID!=0 && Power_Date.Text != "" && Power_OF.Text != "" && TerminalName.Text != "")
            {
                Bases.RegistrToBase("insert INTO terminals_options(terminal_id,t_OF,t_date)VALUES(" + ID + ",'" + Power_OF.Text + "','" + Power_Date.SelectedDate.Value.Date.ToString("yyyy-M-dd") + "')");
                Power_Date.Text = "";
                Power_OF.Text = "";
                ID = 0;
                TerminalName.Text = "";
                UpdateData();
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "Внимание!", MessageBoxButton.OK);
            }
        }
        public void UpdateData()
        {
            Bases.SoursDataGrid("SELECT tm.id,tm.t_OF,t.name AS t_name, DATE_FORMAT(tm.t_date,'%d.%m.%Y') as t_date FROM terminals_options tm INNER JOIN terminals t ON tm.terminal_id=t.id and t_date IS not null", ref RaspisaniaData);
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
            Bases.eventDysplay2 += delegate (List<string> mass)
             {
                 foreach (var item in mass)
                 {
                     TerminalName.ItemsSource = mass;
                     TerminalName_Copy.ItemsSource = mass;
                 }
             };
            Bases.Display("SELECT NAME AS name,id FROM terminals");
        }

        private void TerminalName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TerminalName.SelectedValue!=null)
            {
                ID = Bases.ReturnID("SELECT id FROM terminals WHERE NAME='" + TerminalName.SelectedValue.ToString() + "'");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (ID != 0 && OF_Time.Text !="" && TerminalName_Copy.Text !="" && TerminalPower_Copy.Text != "" && DayCombobox.Text != "")
            {
                Bases.RegistrToBase("insert INTO terminals_options(terminal_id,t_key,t_OF,t_day) VALUES (" + ID + ",'" + TerminalPower_Copy.Text + "','" + OF_Time.Text + "','" + DayCombobox.Text + "')");
                ID = 0;
                TerminalPower_Copy.Text = "";
                OF_Time.Text = "";
                DayCombobox.Text = "";
                TerminalName_Copy.Text = "";
                Day_Grafik1();
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "Внимание!",MessageBoxButton.OK);
            }
        }
        void Day_Grafik1()
        {
            Bases.SoursDataGrid("SELECT tm.id as id,tm.t_OF as t_of,t.name AS t_name,tm.t_key as t_key, d.day as day FROM terminals_options tm INNER JOIN terminals t INNER JOIN day d ON tm.terminal_id=t.id AND tm.t_day=d.day and t_day IS not null", ref Day_Grafik);
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
                    messageO.del_ += () => Day_Grafik1();
                    messageO.ShowDialog();
                }
            }
        }

        private void TerminalName_Copy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TerminalName_Copy.SelectedValue != null)
            {
                ID = Bases.ReturnID("SELECT id FROM terminals WHERE NAME='" + TerminalName_Copy.SelectedValue.ToString() + "'");
            }
        }
    }
}
