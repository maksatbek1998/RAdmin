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
        }
        public void Refresh()
        {
            workName.Text = "";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (workName.Text != String.Empty )
            {
                dataBase = new Base();              
                dataBase.RegistrToBase("insert into workplaces(name) values ('" +workName.Text + "')");
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
            dataBase.SoursDataGrid("SELECT w.id,w.name from workplaces AS w", ref dataGrid);
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
