using RAdminPanel.DataBase;
using RAdminPanel.ViewModel.Models;
using System;
using System.Collections.Generic;
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
        static int returnedFili;
        static int returnedWork;
        static int returnedPositionId;

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
            BranchComboBox.SelectedItem =  null;
            PositionComboBox.SelectedItem = null;
            WorkPod.SelectedItem = null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTextBox.Text != "" && UserNameTextBox.Text != "" && PasswordTextBox.Text != "" && BranchComboBox.SelectedItem != null && PositionComboBox.SelectedItem != null && WorkPod.SelectedItem != null)
            {
                dataBase = new Base();
                dataBase.RegistrToBase("insert into users(name_u,login,password,branches_id,workplace_id) values ('" + UserNameTextBox.Text + "','" + LoginTextBox.Text + "','" + PasswordTextBox.Text + "',"+ returnedFili + "," + returnedWork + ")");
                dataBase.RegistrToBase("update workplaces set status = 1 where id = "+returnedWork+"");
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
            dataBase.SoursDataGrid("SELECT u.id,u.name_u, b.name_b,p.name_p,w.windowName,u.login,u.password FROM users AS u INNER JOIN branches AS b ON u.branches_id = b.id INNER JOIN workplaces AS w ON u.workplace_id = w.id INNER JOIN position AS p ON w.name_id = p.id", ref dataGrid);
        }
        public void UpdateComboBoxBranch()
        {
            dataBase = new Base();
            dataBase.eventDysplay2 += delegate (List<string> db)
            {                
                BranchComboBox.ItemsSource = db;
            };
            dataBase.Display("SELECT name_b FROM branches");
        }
        public void UpdateComboBoxPosition()
        {
            dataBase = new Base();
            dataBase.eventDysplay2 += delegate (List<string> db)
            {
                PositionComboBox.ItemsSource = db;
            };
            dataBase.Display("SELECT name_p FROM position");
        }
        public void UpdateComboBoxWindow()
        {
            dataBase = new Base();
            dataBase.eventDysplay2 += delegate (List<string> db)
            {
                WorkPod.ItemsSource = db;
            };
            dataBase.Display("SELECT windowName FROM workplaces where name_id = "+returnedPositionId+" and status = 0");
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

        private void BranchComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (BranchComboBox.SelectedItem != null)
            {
                dataBase = new Base();
                returnedFili = dataBase.ReturnID("select id from branches where name_b = '" + BranchComboBox.SelectedValue.ToString() + "'");
            }
        }

        private void PositionComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (PositionComboBox.SelectedItem != null)
            {
                dataBase = new Base();
                returnedPositionId= dataBase.ReturnID("select id from  position where name_p = '" +PositionComboBox.SelectedValue.ToString() + "'");
                UpdateComboBoxWindow();
            }
        }
        private void UpdateButtonClick(object sender, RoutedEventArgs e)
        {
            UpdateButton.Visibility = Visibility.Visible;
            DataRowView dataRow = (DataRowView)dataGrid.SelectedItem;
            if (dataRow != null)
            {
                id_1 = dataRow.Row.ItemArray[0].ToString();
                UserNameTextBox.Text = dataRow.Row.ItemArray[1].ToString();
                LoginTextBox.Text = dataRow.Row.ItemArray[4].ToString();
                PasswordTextBox.Text = dataRow.Row.ItemArray[5].ToString();
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (UserNameTextBox.Text != String.Empty && BranchComboBox.Text != String.Empty && PositionComboBox.Text != String.Empty && LoginTextBox.Text != String.Empty && PasswordTextBox.Text != String.Empty)
            {

                dataBase = new Base();
                dataBase.RegistrToBase("UPDATE users AS u SET u.name_u = '" + UserNameTextBox.Text + "' ,u.login ='" + LoginTextBox.Text + "' , u.password = '" + PasswordTextBox.Text + "', u.branches_id = " + returnedFili + ",u.position_id = " + returnedWork + " WHERE id = " + id_1 + "");
                MessageBox.Show("Данные успешно обновлены!");
                UpdateData();
            }
            else 
            {
                MessageBox.Show("Не верно введены данные");
            }
        }

        private void WorkPod_DropDownClosed(object sender, EventArgs e)
        {
            if (WorkPod.SelectedItem != null)
            {
                dataBase = new Base();
                returnedWork = dataBase.ReturnID("select id from workplaces where windowName = '" + WorkPod.SelectedValue.ToString() + "'") ;
            }
        }
    }
}
