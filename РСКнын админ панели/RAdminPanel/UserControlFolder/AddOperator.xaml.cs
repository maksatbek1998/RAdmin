using RAdminPanel.DataBase;
using RAdminPanel.ViewModel;
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
        static int returnedPositionId;
        static int returnedWindowId;

        public AddOperator()
        {
            InitializeComponent();          
            UpdateData();
            UpdateComboBoxBranch();
            UpdateComboBoxPosition();
            Restart();
          //  WindowComboBoxNanes();
        }
        public void Refresh() 
        {
            UserNameTextBox.Text = "";
            LoginTextBox.Text = "";
            PasswordTextBox.Text = "";
          // WindowComboBox.Text = "";
            BranchComboBox.SelectedItem =  null;
            PositionComboBox.SelectedItem = null;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTextBox.Text != "" && UserNameTextBox.Text != "" && PasswordTextBox.Text != "" && BranchComboBox.SelectedItem != null && PositionComboBox.SelectedItem != null)
            {
                dataBase = new Base();

                dataBase.RegistrToBase("insert into users(name_u,login,password,position_id,branches_id) values ('" + UserNameTextBox.Text + "','" + LoginTextBox.Text + "','" + Base.ComputeSha256Hash(PasswordTextBox.Text).ToString()+ "'," + returnedPositionId + "," + returnedFili + ")");
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
            dataBase.SoursDataGrid("SELECT u.id,u.name_u,b.name_b,p.name_p,u.login,u.password FROM users AS u INNER JOIN position AS p ON p.id = u.position_id INNER JOIN branches AS b ON b.id = u.branches_id ", ref dataGrid);
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
/*        public void WindowComboBoxNanes()
        {
            dataBase = new Base();
            dataBase.eventDysplay2 += delegate (List<string> db)
            {
                WindowComboBox.ItemsSource = db;
            };
            dataBase.Display("SELECT NAME FROM workplaces");
        }*/
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
                returnedPositionId= dataBase.ReturnID("select id from position where name_p = '" +PositionComboBox.SelectedValue.ToString() + "'");
            }
        }
        private void UpdateButtonClick(object sender, RoutedEventArgs e)
        {
            SaveButton.Visibility = Visibility.Hidden;
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
                dataBase.RegistrToBase("UPDATE users AS u SET u.name_u = '" + UserNameTextBox.Text + "' ,u.login ='" + LoginTextBox.Text + "' , u.password = '" +Base.ComputeSha256Hash(PasswordTextBox.Text).ToString() + "', u.branches_id = " + returnedFili + ", u.position_id = "+returnedPositionId+" WHERE id = " + id_1 + "");
                MessageBox.Show("Данные успешно обновлены!");
                UpdateData();
                Refresh();
                SaveButton.Visibility = Visibility.Visible;
                UpdateButton.Visibility = Visibility.Collapsed;
            }
            else 
            {
                MessageBox.Show("Не верно введены данные");
                Refresh();
            }
        }

        /*        private void PositionComboBox_Copy_DropDownClosed(object sender, EventArgs e)
                {
                    if (WindowComboBox.SelectedItem != null)
                    {
                        dataBase = new Base();
                        returnedWindowId = dataBase.ReturnID("SELECT id FROM workplaces WHERE NAME='" + WindowComboBox.SelectedValue.ToString() + "'");
                    }
                }*/
        private void Restart()
        {
            if (staticClaseForLangue.Lang == "RUS")
            {
                UserNameTextBox1.Text = "Ф.И.О";
                UserNameTextBox1.Tag = "Ф.И.О";
                Filial.Text = "Филиал";
                Otdel.Text = "Отдел";
                log.Text = "Логин";
                LoginTextBox.Tag = "Логин";
                pass.Text = "Пароль";
                PasswordTextBox.Tag = "Пароль";
                fio.Header = "Ф.И.О";
                fil.Header = "Филиал";
                otd.Header = "Отдел";
                log1.Header = "Логин";
                pass1.Header = "Пароль";
                izmenit.Header = "Изменить";
                udalit.Header = "Удалить";
                SaveButton.Content = "Сактоо";
            }
            else if (staticClaseForLangue.Lang == "KG")
            {
                UserNameTextBox1.Text = "Ф.И.О";
                UserNameTextBox1.Tag = "Ф.И.О";
                Filial.Text = "Филиал";
                Otdel.Text = "Бөлүм";
                log.Text = "Логин";
                LoginTextBox.Tag = "Логин";
                pass.Text = "Купуя сөз";
                PasswordTextBox.Tag = "Купуя сөз";
                fio.Header = "Ф.И.О";
                fil.Header = "Филиал";
                otd.Header = "Бөлүм";
                log1.Header = "Логин";
                pass1.Header = "Купуя сөз";
                izmenit.Header = "Өзгөртүү";
                udalit.Header = "Өчүрүү"; 
                SaveButton.Content = "Сохранить";
            }
            if (staticClaseForLangue.Lang == "EN")
            {
                UserNameTextBox1.Text = "Surname";
                UserNameTextBox1.Tag = "Surname";
                Filial.Text = "Branch";
                Otdel.Text = "Section";
                log.Text = "Login";
                LoginTextBox.Tag = "Login";
                pass.Text = "Password";
                PasswordTextBox.Tag = "Password";
                fio.Header = "Surname";
                fil.Header = "Branch";
                otd.Header = "Section";
                log1.Header = "Login";
                pass1.Header = "Password";
                izmenit.Header = "Change in";
                udalit.Header = "Delete";
                SaveButton.Content = "Save";
            }
        }
    }
}
