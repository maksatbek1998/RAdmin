using System;
using System.Collections.Generic;
using System.Linq;
using RAdminPanel.DataBase;
using RAdminPanel.ViewModel.Models;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace RAdminPanel.UserControlFolder
{
    
    public partial class WorkPlaces : UserControl
    {
        Base dataBase;
        string id_1;
        public WorkPlaces()
        {
            InitializeComponent();
            UpdateData();
            UpdateComboBoxBranch();
        }
        public void Refresh()
        {
            workName.Text = "";
            workWindow.Text = "";
            PriorityComboBox.SelectedItem = 0;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (workName.Text != String.Empty && workWindow.Text != String.Empty && PriorityComboBox.Text != String.Empty)
            {
                dataBase = new Base();               
                dataBase.RegistrToBase("insert into workplaces(name_w,windowName,priority) values ('" + workName.Text + "','" + workWindow.Text + "'," + PriorityComboBox.Text + ")");
                UpdateData();
                Refresh();
            }
            else
            {
                MessageBox.Show("Данные введены не правильно");
                Refresh();
            }
        }
        public void UpdateData()
        {
            dataBase = new Base();
            dataBase.SoursDataGrid("select id,name_w,windowName,priority from workplaces order by priority desc", ref dataGrid);
        }
        public void UpdateComboBoxBranch()
        {
            dataBase = new Base();
            dataBase.eventDysplay2 += delegate (string[] db)
            {
                workName.ItemsSource = db;
            };
            dataBase.Display("SELECT name_p FROM position");
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)dataGrid.SelectedItem;
            if (dataRow != null)
            {
                id_1 = dataRow.Row.ItemArray[0].ToString();
                Message messageO = new Message();
                if (id_1 != "")
                {
                    messageO.Id = id_1;
                    messageO.TableBasa = "workplaces";
                    messageO.del_ += () => UpdateData();
                    messageO.ShowDialog();
                }
            }
        }
    }
}
