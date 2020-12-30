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
        static string ID;
        Base dataBase;
        List<langgrid> list;
        List<langgrid> lister;
        List<langgrid> Updatelist;
        List<langgrid> Updatelister;
        List<int> langlist = new List<int>();
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
                UpdateComboBox.ItemsSource = db;
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
                            currentlan = db.Rows[i][1].ToString(),
                            newlan = ""
                        });
                        langlist.Add(int.Parse(db.Rows[i][0].ToString()));
                    }
                    dataGrid.ItemsSource = list;
                }
            };
            dataBase.SoursData("SELECT service_id,name FROM service_langs where locale = '" + Languages.Text + "'");
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (Languages.Text != String.Empty && ShortName.Text != String.Empty)
            {
                dataBase = new Base();
                lister = (List<langgrid>)dataGrid.ItemsSource;
                for (int i = 0; i < count; i++)
                {
                    dataBase.RegistrToBase("update service_langs set name='" + lister[i].newlan.ToString() + "' where service_id = " + langlist[i].ToString() + " and locale = '" + shorting + "'");
                }
                Refresh();
                MessageBox.Show("Сохранение прошло успешно");
                UpdateComboBoxBranch();
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
                dataBase.RegistrToBase("insert into langs(locale) values ('" + ShortName.Text + "')");
                for (int i = 0; i < langlist.Count; i++)
                {
                    dataBase.RegistrToBase("insert into service_langs(service_id,locale) values(" + langlist[i].ToString() + ",'" + ShortName.Text + "')");
                }
                shorting = ShortName.Text;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dataBase = new Base();
            if (DeleteComBox.Text != String.Empty)
            {
                if (DeleteComBox.Text == "RU")
                {
                    MessageBox.Show("Нельзя удалить начальный язык");
                    DeleteComBox.SelectedItem = null;
                }
                else
                {
                    dataBase.RegistrToBase("DELETE from service_langs WHERE locale  ='" + DeleteComBox.Text + "'");
                    dataBase.RegistrToBase("DELETE from langs WHERE id=" + ID + "");
                    MessageBox.Show("Успешно удалено", "", MessageBoxButton.OK);
                    DeleteComBox.SelectedItem = null;
                    UpdateComboBoxBranch();
                }

            }
        }

        private void DeleteComBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dataBase = new Base();
            ID = dataBase.ReturnID1("SELECT id FROM langs WHERE `locale`='" + DeleteComBox.SelectedValue + "'");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (UpdateComboBox.Text != String.Empty)
            {
                dataBase = new Base();
                Updatelister = (List<langgrid>)dataGridUpdate.ItemsSource;
                for (int i = 0, c = 1; i < count; i++, c++)
                {
                    dataBase.RegistrToBase("update service_langs set name='" + Updatelister[i].currentlan.ToString() + "' where service_id = " + c + " and locale = '" + UpdateComboBox.Text + "'");
                }
                dataGridUpdate.ItemsSource = null;
                UpdateComboBox.SelectedItem = null;
                MessageBox.Show("Успешно изменено");
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }

        private void UpdateComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (UpdateComboBox.Text != String.Empty)
            {
                if (UpdateComboBox.Text != "RU")
                {
                    DataGridUpdate();
                }
                else
                {
                    MessageBox.Show("Нельзя изменить начальный язык");
                    UpdateComboBox.SelectedItem = null;
                }
            }
            else
            {
                MessageBox.Show("Выберите язык");
            }

        }
        public void DataGridUpdate()
        {
            Updatelist = new List<langgrid>();
            dataBase = new Base();
            dataBase.del += db =>
            {
                if (db.Rows.Count > 0)
                {
                    count = db.Rows.Count;
                    for (int i = 0; i < db.Rows.Count; i++)
                    {
                        Updatelist.Add(new langgrid
                        {
                            id = (i + 1).ToString(),
                            currentlan = db.Rows[i][0].ToString()
                        });
                    }
                    dataGridUpdate.ItemsSource = Updatelist;
                }
            };
            dataBase.SoursData("SELECT name FROM service_langs where locale = '" + UpdateComboBox.Text + "'");
        }
    }
}
