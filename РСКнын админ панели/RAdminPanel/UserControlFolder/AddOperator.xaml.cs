using RAdminPanel.DataBase;
using RAdminPanel.ViewModel.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RAdminPanel.UserControlFolder
{
    /// <summary>
    /// Логика взаимодействия для AddOperator.xaml
    /// </summary>
    public partial class AddOperator : UserControl
    {
        string id_1;
        Base dataBase;
        public AddOperator()
        {
            InitializeComponent();          
            UpdateData();
            UpdateComboBoxBranch();
            UpdateComboBoxPosition();
            
        }
        public void Refresh() 
        {
            UserNameTextBox.Text = "";
            LoginTextBox.Text = "";
            PasswordTextBox.Text = "";
            BranchComboBox.SelectedIndex = 0;
            PositionComboBox.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTextBox.Text != "" && UserNameTextBox.Text != "" && PasswordTextBox.Text != "" && BranchComboBox.SelectedItem != null && PositionComboBox.SelectedItem != null)
            {
                dataBase = new Base();
                dataBase.RegistrToBase("insert into users(name,login,password,branches_id,position_id) values ('" + UserNameTextBox.Text + "','" + LoginTextBox.Text + "','" + PasswordTextBox.Text + "','"+ BranchComboBox.SelectedItem.ToString() + "','" + PositionComboBox.SelectedItem.ToString() + "')");
                UpdateData();       
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
            dataBase.SoursDataGrid("select id,name,login,password,branches_id from users", ref dataGrid);
        }
        public void UpdateComboBoxBranch()
        {
            dataBase = new Base();
            dataBase.eventDysplay2 += delegate (string[] db)
            {                
                BranchComboBox.ItemsSource = db;
            };
            dataBase.Display("SELECT name FROM branches");
        }
        public void UpdateComboBoxPosition()
        {
            dataBase = new Base();
            dataBase.eventDysplay2 += delegate (string[] db)
            {
                PositionComboBox.ItemsSource = db;
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
                    messageO.TableBasa = "users";
                    messageO.del_ += () => UpdateData();
                    messageO.ShowDialog();
                }
            }
        }
    }
}
