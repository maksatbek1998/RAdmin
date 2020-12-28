using RAdminPanel.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace RAdminPanel.UserControlFolder
{
    /// <summary>
    /// Логика взаимодействия для Terminal.xaml
    /// </summary>
    public partial class Terminal : UserControl
    {
        Base Base1;
        string id_1;
        string ID = "";
        int IntID = 0;
        int PoslednyElement = 0;
        string SaveID = "";
        int Flag = 0;

        public Terminal()
        {
            InitializeComponent();
            UpdateLang();
            UpdateDataGrid();
            SourseCombo();
            UpdateDataGrid1();
            UpdateDataGridInsert();
            Sufficss();
        }
        public void UpdateLang()
        {
            Base1 = new Base();
            Base1.eventDysplay2 += delegate (List<string> list)
            {
                LangTerminal.ItemsSource = list;
            };
            Base1.Display("SELECT locale FROM langs");
        }
        public void UpdateDataGrid()
        {
            Base1 = new Base();
            Base1.SoursDataGrid("SELECT id,locale FROM langs WHERE is_aktiv=1", ref LangData);
        }

        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)LangData.SelectedItem;
            if (dataRow != null)
            {
                id_1 = dataRow.Row.ItemArray[0].ToString();
                Message messageO = new Message();
                if (id_1 != "")
                {
                    Base1.SoursDataGrid("UPDATE langs SET is_aktiv=0 WHERE id= " + id_1 + "", ref LangData);
                }
            }
            UpdateDataGrid();
        }

        private void LangTerminal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ID = Base1.ReturnID1("SELECT id FROM langs WHERE locale='" + LangTerminal.SelectedValue + "'");
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Base1 = new Base();
            if (ID != "")
            {
                Base1.SoursDataGrid("UPDATE langs SET is_aktiv=1 WHERE id= " + ID + "", ref LangData);
            }
            UpdateDataGrid();
        }
        public void UpdateTerminalDataGrid()
        {

            Base1 = new Base();
            Base1.SoursDataGrid("SELECT id,locale FROM langs WHERE is_aktiv=1", ref LangData);
        }

        private void Button_Click_2(object sender, System.Windows.RoutedEventArgs e)
        {
            DeleteData(1);
        }

        private void Button_Click_3(object sender, System.Windows.RoutedEventArgs e)
        {
            DeleteData(2);
        }

        private void Button_Click_4(object sender, System.Windows.RoutedEventArgs e)
        {
            DeleteData(3);
        }

        private void Button_Click_5(object sender, System.Windows.RoutedEventArgs e)
        {
            DeleteData(4);
        }

        private void Button_Click_6(object sender, System.Windows.RoutedEventArgs e)
        {
            DeleteData(5);
        }

        private void Button_Click_7(object sender, System.Windows.RoutedEventArgs e)
        {
            DeleteData(6);
        }

        private void Button_Click_8(object sender, System.Windows.RoutedEventArgs e)
        {
            DeleteData(7);
        }

        private void Button_Click_9(object sender, System.Windows.RoutedEventArgs e)
        {
            DeleteData(8);
        }

        private void Button_Click_10(object sender, System.Windows.RoutedEventArgs e)
        {
            DeleteData(9);
        }

        private void Button_Click_13(object sender, System.Windows.RoutedEventArgs e)
        {
            if (Is_Activen.Text != String.Empty && ComboPrioritet_Copy.Text != String.Empty && Flag != 0 && SaveID != "")
            {
                Base1 = new Base();
                Base1.RegistrToBase("UPDATE services SET `index`=" + ComboPrioritet_Copy.Text + ",is_active=" + Is_Activen.SelectedIndex + " WHERE id=" + SaveID);
                UpdateDataGridInsert();
                SaveID = "";
                NameCatedory.Text = "";
                Is_Activen.Text = "";
                ComboSuffix.Text = "";
                ComboPrioritet_Copy.Text = "";
            }
        }

        private void Button_Click_11(object sender, System.Windows.RoutedEventArgs e)
        {
            SaveID = "";
            NameCatedory.Text = "";
            Is_Activen.Text = "";
            ComboPrioritet_Copy.Text = "";
            ComboSuffix.Text = "";
        }

        private void Button_Click_12(object sender, System.Windows.RoutedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)DataGridD.SelectedItem;
            if (dataRow != null)
            {
               // Base1 = new Base();
              // AlfavitID=Base1.ReturnID("SELECT a.id FROM services AS s INNER JOIN alfavit AS a ON s.suffix=a.name1 AND s.id="+ dataRow.Row.ItemArray[0].ToString());
                SaveID = dataRow.Row.ItemArray[0].ToString();
                NameCatedory.Text = dataRow.Row.ItemArray[1].ToString();
                ComboPrioritet_Copy.Text = dataRow.Row.ItemArray[2].ToString();
                Is_Activen.Text = dataRow.Row.ItemArray[3].ToString();
                ComboSuffix.Text= dataRow.Row.ItemArray[4].ToString();
                Flag = 1;            
                
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Base1 = new Base();
            if (ComboCategoria.SelectedValue != null)
            {
                IntID = Convert.ToInt32(Base1.ReturnID1("SELECT id FROM services WHERE NAME='" + ComboCategoria.SelectedValue + "'"));
            }
        }

        private void TextBox_SelectionChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            Base1 = new Base();
            Base1.SoursDataGrid("SELECT id,`name`,`index`,case when is_active='0' then 'OF' ELSE 'ON' END AS is_active from services WHERE `name` LIKE '" + SearchText.Text + "%'", ref DataGridD);
        }
        public void SourseCombo()
        {
            Base1 = new Base();
            Base1.eventDysplay2 += delegate (List<string> list)
            {
                ComboCategoria.ItemsSource = list;
            };
            Base1.Display("SELECT name FROM services");

        }
        void UpdateDataGrid1()
        {
            Base1 = new Base();
            Base1.SoursDataGrid("SELECT id,parent,child1,child2,child3,child4,child5,child6,child7,child8 FROM services_table", ref GlavDataGrid);
        }

        private void Button_Click_14(object sender, System.Windows.RoutedEventArgs e)
        {
            ComboCategoria.Text = "";
            CattegoryName.Text = "";
            ComboPrioritet.Text = "";
            ComboActiv.Text = "";
            ComboSufics.Text = "";
            IntID = 0;
        }

        private void Button_Click_15(object sender, System.Windows.RoutedEventArgs e)
        {
            Base1 = new Base();
            if (CattegoryName.Text != "" && ComboPrioritet.Text != "" && ComboActiv.Text != "" && ComboSufics.Text != "")
            {
                Base1.RegistrToBase("INSERT INTO services VALUES(NULL,'" + CattegoryName.Text + "','" + ComboPrioritet.Text + "'," + IntID + "," + ComboActiv.SelectedIndex + ",'" + ComboSufics.Text + "')");
               // Base1.RegistrToBase("UPDATE alfavit SET STATUS=1 WHERE NAME1='" + ComboSufics.Text + "'");
                if (ComboCategoria.Text == string.Empty)
                {
                    CategoriID();
                    if (PoslednyElement != 0)
                    {
                        Base1.RegistrToBase("UPDATE services SET parent_id=" + PoslednyElement + " WHERE id=" + PoslednyElement + "");
                        Base1.RegistrToBase("INSERT INTO service_langs(service_id,NAME,locale)VALUES(" + PoslednyElement + ",'" + CattegoryName.Text + "','" + ComboCategoria_Copy.Text + "')");
                        PoslednyElement = 0;
                    }
                }
                else
                {
                    CategoriID();
                    if (PoslednyElement != 0)
                    {
                        Base1.RegistrToBase("INSERT INTO service_langs VALUES(NULL,'" + PoslednyElement + "','" + CattegoryName.Text + "','" + ComboCategoria_Copy.Text + "')");
                        PoslednyElement = 0;
                    }
                }
                ComboCategoria.Text = "";
                CattegoryName.Text = "";
                ComboPrioritet.Text = "";
                ComboActiv.Text = "";
                ComboSufics.Text = "";
                IntID = 0;
                UpdateDataGrid1();
                SourseCombo();
                Sufficss();
                UpdateDataGridInsert();
            }
            else
            {
                MessageBox.Show("Заполните поля", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        void CategoriID()
        {
            Base1 = new Base();
            PoslednyElement = Convert.ToInt32(Base1.ReturnID1("SELECT id FROM services ORDER BY id DESC LIMIT 1"));
        }
        public void DeleteData(int column)
        {
            string id = "";
            DataRowView dataRow = (DataRowView)GlavDataGrid.SelectedItem;
            if (dataRow != null)
            {
                id = dataRow.Row.ItemArray[column].ToString();
                if (id != "")
                {
                    if (id != "Нет")
                    {
                        Base1 = new Base();
                        Message messageO = new Message();
                        string ID1 = Base1.ReturnID1("SELECT id from services WHERE  NAME='" + id + "'");
                        messageO.Id = ID1;
                        messageO.TableBasa = "services";
                        messageO.del_ += () => UpdateDataGrid1();
                        messageO.ShowDialog();
                        SourseCombo();
                        Base1.RegistrToBase("UPDATE alfavit AS a INNER JOIN services AS s ON a.name1=s.suffix SET a.`status`=0 WHERE s.name='" + id + "'");
                        Base1.RegistrToBase("DELETE FROM service_langs WHERE NAME='" + id + "'");
                    }
                    else
                    {
                        MessageBox.Show("Это пусто !", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            UpdateDataGridInsert();
            Sufficss();
        }
        void UpdateDataGridInsert()
        {
            Base1 = new Base();
            Base1.SoursDataGrid("SELECT id,`name`,`index`,case when is_active='0' then 'OF' ELSE 'ON' END AS is_active,suffix as suff from services", ref DataGridD);
        }
        void Sufficss()
        {
            Base1 = new Base();
            Base1.eventDysplay2 += delegate (List<string> list)
              {
                  ComboSufics.ItemsSource = list;
                  ComboSuffix.ItemsSource = list;
              };
            Base1.Display("SELECT NAME1 FROM alfavit");
        }
    }
}
