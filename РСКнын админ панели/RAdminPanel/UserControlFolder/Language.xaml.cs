using RAdminPanel.ClassUserControl;
using RAdminPanel.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace RAdminPanel.UserControlFolder
{
    /// <summary>
    /// Логика взаимодействия для Language.xaml
    /// </summary>
    public partial class Language : UserControl
    {
        static int count = 0;
        static string shorting;
        Base dataBase;
        List<langgrid> list; List<langgrid> lister;
        public Language()
        {
            InitializeComponent();
            UpdateComboBoxBranch();
        }

        private void Languages_DropDownClosed(object sender, EventArgs e)
        {
            if (Languages.Text != String.Empty)
                UpdateData();
        }
        public void UpdateComboBoxBranch()
        {
            dataBase = new Base();
            dataBase.eventDysplay2 += delegate (List<string> db)
            {
                Languages.ItemsSource = db;
                DeleteComBox.ItemsSource = db;
            };
            dataBase.Display("SELECT locale FROM langs");
        }

        public void UpdateData()
        {
            list = new List<langgrid>();
            dataBase = new Base();
            dataBase.del += db =>
            {
                if (db.Rows.Count > 0)
                {
                    count = db.Rows.Count;
                    for (int i = 0; i < db.Rows.Count; i++)
                    {
                        list.Add(new langgrid
                        {
                            id = (i + 1).ToString(),
                            currentlan = db.Rows[i][0].ToString(),
                            newlan = ""
                        });
                    }
                    dataGrid.ItemsSource = list;
                }
            };
            dataBase.SoursData("SELECT name FROM service_langs where locale = '" + Languages.Text + "'");
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (Languages.Text != String.Empty && ShortName.Text != String.Empty)
            {
                dataBase = new Base();
                lister = (List<langgrid>)dataGrid.ItemsSource;
                for (int i = 0, c = 1; i < count; i++, c++)
                {
                    MessageBox.Show(lister[i].newlan.ToString());
                    dataBase.RegistrToBase("update service_langs set name='" + lister[i].newlan.ToString() + "' where service_id = " + c + " and locale = '" + shorting + "'");
                }
                Refresh();
            }
            else 
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }

        private void Refresh()
        {
            Language1.Text = String.Empty;
            Languages.SelectedItem = null;
            ShortName.Text = String.Empty;
            dataGrid.ItemsSource = null;
        }
        private void RefreshDeleteField()
        {
            DeleteComBox.SelectedItem = null;
        }

        private void ShortName_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (count > 0 && ShortName.Text != String.Empty && Languages.Text != String.Empty)
            {
                dataBase = new Base();
                for (int i = 1; i < count + 1; i++)
                {
                    dataBase.RegistrToBase("insert into service_langs(service_id,locale) values(" + i + ",'" + ShortName.Text + "')");
                }
                dataBase.RegistrToBase("insert into langs(locale)values('" + ShortName.Text + "')");
                shorting = ShortName.Text;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dataBase = new Base();
            if (DeleteComBox.Text != String.Empty)
            {
                dataBase.RegistrToBase("delete from langs where locale = '" + DeleteComBox.Text + "'");
                dataBase.RegistrToBase("delete from service_langs where locale = '" + DeleteComBox.Text + "'");
            }
        }
    }
}
