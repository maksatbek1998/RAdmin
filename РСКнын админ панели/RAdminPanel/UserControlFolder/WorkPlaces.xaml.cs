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
        static int returnedWork;
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
                dataBase.RegistrToBase("insert into workplaces(name_id,windowName,priority,status) values (" +returnedWork + "," + workWindow.Text + "," + PriorityComboBox.Text + ", 0)");
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
            dataBase.SoursDataGrid("SELECT w.id,p.name_p,w.windowName,w.priority,w.status from workplaces AS w INNER JOIN position AS p ON w.name_id = p.id order by priority desc", ref dataGrid);
        }
        public void UpdateComboBoxBranch()
        {
            dataBase = new Base();
            dataBase.eventDysplay2 += delegate (List<string> db)
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

        private void workName_DropDownClosed(object sender, EventArgs e)
        {
            if (workName.SelectedItem != null)
            {
                dataBase = new Base();
                returnedWork = dataBase.ReturnID("select id from workplaces where windowName = '" + workName.SelectedValue.ToString() + "'");
            }
        }
    }
}
