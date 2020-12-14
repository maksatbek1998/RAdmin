using System;
using System.Collections.Generic;
using System.Linq;
using RAdminPanel.DataBase;
using RAdminPanel.ViewModel.Models;
using System.Data;
using System.Windows;
using System.Windows.Controls;

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
        }
        public void Refresh()
        {
            workName.Text = "";
            workWindow.Text = "";
            PriorityComboBox.SelectedItem = 0;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (workName.Text != "" && workWindow.Text != "" && PriorityComboBox.Text != String.Empty)
            {
                dataBase = new Base();
                /*if (PriorityComboBox.SelectedItem == Priority1)
                {
                    dataBase.RegistrToBase("insert into workplaces(name,windowName,priority) values ('" + workName.Text + "','" + workWindow.Text + "'," + 1 + ")");
                }
                else if (PriorityComboBox.SelectedItem == Priority2)
                {
                    dataBase.RegistrToBase("insert into workplaces(name,windowName,priority) values ('" + workName.Text + "','" + workWindow.Text + "'," + 2 + ")");
                }
                else
                {
                    dataBase.RegistrToBase("insert into workplaces(name,windowName,priority) values ('" + workName.Text + "','" + workWindow.Text + "'," + 3 + ")");
                }*/
                dataBase.RegistrToBase("insert into workplaces(name,windowName,priority) values ('" + workName.Text + "','" + workWindow.Text + "'," + PriorityComboBox.Text + ")");
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
            dataBase.SoursDataGrid("select * from workplaces order by priority desc", ref dataGrid);
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
